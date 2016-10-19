using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Dewey.Dynamic
{
    /// <summary>
    /// Extension methods for Dynamic type
    /// </summary>
    public static class DynamicExtensions
    {
        /// <summary>
        /// Convert an object to a dynamic
        /// </summary>
        /// <param name="value">The object value to convert</param>
        /// <returns>The dunamic object result</returns>
        public static dynamic ToDynamic(this object value) => JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(value));

        /// <summary>
        /// Convert an object to a dynamic asynchronously
        /// </summary>
        /// <param name="value">The object value to convert</param>
        /// <returns>The dunamic object result</returns>
        public static Task<dynamic> ToDynamicAsync(this object value) => Task.Factory.StartNew(() => value.ToDynamic());
    }
}
