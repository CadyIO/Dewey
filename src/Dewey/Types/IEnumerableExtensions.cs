using System;
using System.Collections.Generic;
using System.Linq;

namespace Dewey.Types
{
    /// <summary>
    /// Extension methods for IEnumerable type
    /// </summary>
    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            for (var i = 0; i < enumerable.Count(); i++) {
                var item = enumerable.ElementAt(i);

                action(item);
            }
        }
        
        public static IList<T> ToIList<T>(this IEnumerable<T> value) => value.ToList();

        public static bool IsEmpty<T>(this IEnumerable<T> value) => (value == null || value.Count() == 0);

        public static bool IsNotEmpty<T>(this IEnumerable<T> value) => !value.IsEmpty();

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
        {
            var keys = new HashSet<TKey>();

            return source.Where(element => keys.Add(selector(element)));
        }
    }
}
