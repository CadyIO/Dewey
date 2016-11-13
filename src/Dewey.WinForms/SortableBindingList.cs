using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace Dewey.WinForms
{
    /// <summary>
    /// A sortable binding list to bind data to Windows Forms controls
    /// </summary>
    /// <typeparam name="T">The type of the list</typeparam>
    public class SortableBindingList<T> : BindingList<T>
    {
        /// <summary>
        /// The binding list internal dictionary
        /// </summary>
        private static readonly Dictionary<string, Func<List<T>, IEnumerable<T>>> _cachedOrderByExpressions = new Dictionary<string, Func<List<T>, IEnumerable<T>>>();

        /// <summary>
        /// A copy of the original list
        /// </summary>
        private List<T> _originalList;

        /// <summary>
        /// The populate binding list action
        /// </summary>
        private readonly Action<SortableBindingList<T>, List<T>> _populateBaseList = (a, b) => a.ResetItems(b);

        /// <summary>
        /// The sort direction
        /// </summary>
        private ListSortDirection _sortDirection;

        /// <summary>
        /// The property descriptor
        /// </summary>
        private PropertyDescriptor _sortProperty;

        /// <summary>
        /// Constructor
        /// </summary>
        public SortableBindingList()
        {
            _originalList = new List<T>();
        }

        /// <summary>
        /// Constructor with initial IEnumerable data
        /// </summary>
        /// <param name="enumerable">The data with which to initially set the list</param>
        public SortableBindingList(IEnumerable<T> enumerable)
        {
            if (enumerable != null) {
                _originalList = enumerable.ToList();
            }
            _populateBaseList(this, _originalList);
        }

        /// <summary>
        /// Constructor with initial List data
        /// </summary>
        /// <param name="list">The data with which to initially set the list</param>
        public SortableBindingList(List<T> list)
        {
            _originalList = list;
            _populateBaseList(this, _originalList);
        }

        /// <summary>
        /// Supports sorting core
        /// </summary>
        protected override bool SupportsSortingCore => true;

        /// <summary>
        /// The sort direction for the core
        /// </summary>
        protected override ListSortDirection SortDirectionCore => _sortDirection;

        /// <summary>
        /// The sort property for the core
        /// </summary>
        protected override PropertyDescriptor SortPropertyCore => _sortProperty;

        /// <summary>
        /// Action to apply the sorting core
        /// </summary>
        /// <param name="prop">The property on which to sort</param>
        /// <param name="direction">The direction to sort</param>
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            _sortProperty = prop;

            var orderByMethodName = (_sortDirection == ListSortDirection.Ascending) ? "OrderBy" : "OrderByDescending";
            var cacheKey = typeof(T).GUID + prop.Name + orderByMethodName;

            if (!_cachedOrderByExpressions.ContainsKey(cacheKey)) {
                CreateOrderByMethod(prop, orderByMethodName, cacheKey);
            }

            ResetItems(_cachedOrderByExpressions[cacheKey](_originalList).ToList());
            ResetBindings();
            _sortDirection = _sortDirection == ListSortDirection.Ascending ?
                ListSortDirection.Descending : ListSortDirection.Ascending;
        }

        private void CreateOrderByMethod(PropertyDescriptor prop, string orderByMethodName, string cacheKey)
        {
            var sourceParameter = Expression.Parameter(typeof(List<T>), "source");
            var lambdaParameter = Expression.Parameter(typeof(T), "lambdaParameter");
            var accesedMember = typeof(T).GetProperty(prop.Name);
            var propertySelectorLambda =
                Expression.Lambda(Expression.MakeMemberAccess(lambdaParameter,
                    accesedMember), lambdaParameter);
            var orderByMethod = typeof(Enumerable).GetMethods()
                                                   .Where(a => a.Name == orderByMethodName &&
                                                               a.GetParameters().Length == 2)
                                                   .Single()
                                                   .MakeGenericMethod(typeof(T), prop.PropertyType);

            var orderByExpression = Expression.Lambda<Func<List<T>, IEnumerable<T>>>(
                Expression.Call(orderByMethod,
                    new Expression[] {
                        sourceParameter,
                        propertySelectorLambda
                    }),
                sourceParameter);

            _cachedOrderByExpressions.Add(cacheKey, orderByExpression.Compile());
        }

        /// <summary>
        /// Reset the items in the core list
        /// </summary>
        protected override void RemoveSortCore()
        {
            ResetItems(_originalList);
        }

        /// <summary>
        /// Reset the list items with the provided list
        /// </summary>
        /// <param name="items">The list to use to reset the items</param>
        private void ResetItems(List<T> items)
        {
            ClearItems();

            if (items != null) {
                for (var i = 0; i < items.Count; i++) {
                    InsertItem(i, items[i]);
                }
            }
        }

        /// <summary>
        /// Action to take when the list data changes
        /// </summary>
        /// <param name="e">The ListChangedEventArgs</param>
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            _originalList = Items.ToList();
        }
    }
}
