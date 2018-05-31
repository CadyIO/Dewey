using System.Collections.Generic;

namespace Dewey.Types
{
    /// <summary>
    /// Extension methods for List type.
    /// </summary>
    public static class ListExtensions
    {
        public static bool IsEmpty<T>(this List<T> value) => (value == null || value.Count == 0);
        public static bool IsNotEmpty<T>(this List<T> value) => !value.IsEmpty();

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