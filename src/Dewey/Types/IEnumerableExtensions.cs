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
        /// <summary>
        /// Iterate an IEnumerable and execute an action on each item
        /// </summary>
        /// <typeparam name="T">The type of object in the IEnumerable</typeparam>
        /// <param name="enumerable">The IEnumerable to iterate</param>
        /// <param name="action">The action to execute</param>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            for (var i = 0; i < enumerable.Count(); i++) {
                var item = enumerable.ElementAt(i);

                action(item);
            }
        }

        /// <summary>
        /// Convert an IEnumerable to an IList
        /// </summary>
        /// <typeparam name="T">The type of object in the IEnumerable</typeparam>
        /// <param name="enumerable">The IEnumerable to convert</param>
        /// <returns>The IList</returns>
        public static IList<T> ToIList<T>(this IEnumerable<T> enumerable) => enumerable.ToList();

        /// <summary>
        /// Determines whether an IEnumerable is empty
        /// </summary>
        /// <typeparam name="T">The type of object in the IEnumerable</typeparam>
        /// <param name="enumerable">The IEnumerable to check</param>
        /// <returns>True if empty, False otherwise</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> enumerable) => (enumerable == null || enumerable.Count() == 0);

        /// <summary>
        /// Determines whether an IEnumerable is not empty
        /// </summary>
        /// <typeparam name="T">The type of object in the IEnumerable</typeparam>
        /// <param name="enumerable">The IEnumerable to check</param>
        /// <returns>True if not empty, False otherwise</returns>
        public static bool IsNotEmpty<T>(this IEnumerable<T> enumerable) => !enumerable.IsEmpty();

        /// <summary>
        /// Get distinct items using a specific selector
        /// </summary>
        /// <typeparam name="TSource">The type of object in the IEnumerable</typeparam>
        /// <typeparam name="TKey">The type of object in the selector</typeparam>
        /// <param name="enumerable">The IEnumerable to iterate</param>
        /// <param name="selector">The selector function to use</param>
        /// <returns>The new IEnumerable with the distinct items</returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> enumerable, Func<TSource, TKey> selector)
        {
            var keys = new HashSet<TKey>();

            return enumerable.Where(element => keys.Add(selector(element)));
        }
    }
}
