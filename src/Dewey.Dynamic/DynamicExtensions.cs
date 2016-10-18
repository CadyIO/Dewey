using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Dewey.Dynamic
{
    public static class DynamicExtensions
    {
        public static dynamic ToDynamic(this object value) => JsonConvert.DeserializeObject<dynamic>(JsonConvert.SerializeObject(value));

        public static Task<dynamic> ToDynamicAsync(this object value) => Task.Factory.StartNew(() => value.ToDynamic());
    }
}
