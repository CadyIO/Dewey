namespace Dewey.Types
{
    /// <summary>
    /// Extension methods for Object type
    /// </summary>
    public static class ObjectExtensions
    {
        public static bool IsBlank(this object value) => (value == null || value.ToString().IsEmpty());

        public static bool IsNotBlank(this object value) => !value.IsBlank();

        public static T Default<T>(this object value, T defaultValue = default(T)) => (value.IsBlank()) ? defaultValue : (T)value;
    }
}
