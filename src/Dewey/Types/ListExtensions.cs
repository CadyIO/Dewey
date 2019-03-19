using System.Collections.Generic;

namespace Dewey.Types
{
    /// <summary>
    /// Extension methods for List type.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Check if a list is empty.
        /// </summary>
        /// <typeparam name="T">The list type.</typeparam>
        /// <param name="value">The object to check.</param>
        /// <returns>True if empty, False otherwise.</returns>
        public static bool IsEmpty<T>(this List<T> value) => (value == null || value.Count == 0);

        /// <summary>
        /// Check if a list has elements.
        /// </summary>
        /// <typeparam name="T">The list type.</typeparam>
        /// <param name="value">The object to check.</param>
        /// <returns>True if has elements, False otherwise.</returns>
        public static bool IsNotEmpty<T>(this List<T> value) => !value.IsEmpty();

        /// <summary>
        /// Fill a list with a type.
        /// </summary>
        /// <typeparam name="T">The list type.</typeparam>
        /// <param name="size">The number of elements to add.</param>
        /// <param name="value">The value to add.</param>
        /// <returns>The new list with filled values.</returns>
        public static List<T> Fill<T>(int size, T value)
        {
            var result = new List<T>();

            for (var i = 0; i < size; ++i) {
                result.Add(value);
            }

            return result;
        }
    }
}