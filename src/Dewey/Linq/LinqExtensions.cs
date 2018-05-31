using System;

namespace Dewey.Linq
{
    /// <summary>
    /// Extension methods for Linq functions.
    /// </summary>
    public static class LinqExtensions
    {
        /// <summary>
        /// Join two predicates together using 'And'.
        /// </summary>
        /// <typeparam name="T">The object type of the predicate.</typeparam>
        /// <param name="predicate1">The first predicate to join.</param>
        /// <param name="predicate2">The second predicate to join to the first.</param>
        /// <returns>A new predicate function joining the first and the second using 'And'.</returns>
        public static Func<T, bool> And<T>(this Func<T, bool> predicate1, Func<T, bool> predicate2) => (arg => predicate1(arg) && predicate2(arg));

        /// <summary>
        /// Join two predicates together using 'Or'.
        /// </summary>
        /// <typeparam name="T">The object type of the predicate.</typeparam>
        /// <param name="predicate1">The first predicate to join.</param>
        /// <param name="predicate2">The second predicate to join to the first.</param>
        /// <returns>A new predicate function joining the first and the second using 'Or'.</returns>
        public static Func<T, bool> Or<T>(this Func<T, bool> predicate1, Func<T, bool> predicate2) => (arg => predicate1(arg) || predicate2(arg));
    }
}
