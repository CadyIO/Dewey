using System.Net;

namespace Dewey.Json
{
    /// <summary>
    /// An HTTP-style result with status code
    /// </summary>
    /// <remarks>Can be used from services (anywhere outside a controller) to specify a result that includes an HTTP Status Code as well</remarks>
    /// <typeparam name="T">The type of object to return</typeparam>
    public class HttpResult<T>
    {
        /// <summary>
        /// The status code result of the operation
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// The result of the operation
        /// </summary>
        public T Result { get; set; }
    }
}
