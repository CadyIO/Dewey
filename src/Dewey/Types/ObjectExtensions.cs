namespace Dewey.Types
{
    /// <summary>
    /// Extension methods for Object type.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Determine if the object is an empty or null string.
        /// </summary>
        /// <param name="value">The object to check.</param>
        /// <returns>True if empty or null, False otherwise.</returns>
        public static bool IsBlank(this object value) => (value == null || value.ToString().IsEmpty());

        /// <summary>
        /// Determine if the object is not an empty or null string.
        /// </summary>
        /// <param name="value">The object to check.</param>
        /// <returns>True if not empty or null, False otherwise.</returns>
        public static bool IsNotBlank(this object value) => !value.IsBlank();

        /// <summary>
        /// Determine if the object is the default value of the type.
        /// </summary>
        /// <typeparam name="T">The type of object.</typeparam>
        /// <param name="value">The object to check.</param>
        /// <param name="defaultValue">The default value if other than default(T).</param>
        /// <returns>True if object is default, False otherwise.</returns>
        public static T Default<T>(this object value, T defaultValue = default(T)) => (value.IsBlank()) ? defaultValue : (T)value;
    }
}
