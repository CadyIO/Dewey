using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using System.Threading;

namespace Dewey.Json
{
    /// <summary>
    /// A set of utilities for working with JSON API requests
    /// </summary>
    public class JsonUtils
    {
        /// <summary>
        /// The base address for the requests being made
        /// </summary>
        /// <example>https://api.example.com</example>
        public static string BaseAddress { get; set; }

        /// <summary>
        /// Make a Get request to the API
        /// </summary>
        /// <typeparam name="T">The type of object to return from the API request</typeparam>
        /// <param name="url">The URL of the API request (does not include base)</param>
        /// <returns>The HttpResult with status code and resulting object</returns>
        public static async Task<HttpResult<T>> Get<T>(string url)
        {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(BaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(url).ConfigureAwait(false);

                if (response.IsSuccessStatusCode) {
                    var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    return new HttpResult<T>
                    {
                        StatusCode = response.StatusCode,
                        Result = JsonConvert.DeserializeObject<T>(result)
                    };
                }

                return new HttpResult<T>
                {
                    StatusCode = response.StatusCode,
                };
            }
        }

        /// <summary>
        /// Make a Delete request to the API
        /// </summary>
        /// <param name="url">The URL of the API request (does not include base)</param>
        public static async void Delete(string url)
        {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(BaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode) {
                    return;
                }

                var result = await response.Content.ReadAsStringAsync();

                throw new Exception($"Failed with status code {response.StatusCode.ToString()}", new Exception(result));
            }
        }

        /// <summary>
        /// Make a Delete request to the API
        /// </summary>
        /// <typeparam name="T">The type of object to return from the API request</typeparam>
        /// <param name="url">The URL of the API request (does not include base)</param>
        /// <returns>The HttpResult with status code and resulting object</returns>
        public static async Task<HttpResult<T>> Delete<T>(string url)
        {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(BaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.DeleteAsync(url);

                if (response.IsSuccessStatusCode) {
                    var result = await response.Content.ReadAsStringAsync();

                    return new HttpResult<T>
                    {
                        StatusCode = response.StatusCode,
                        Result = JsonConvert.DeserializeObject<T>(result)
                    };
                }

                return new HttpResult<T>
                {
                    StatusCode = response.StatusCode,
                };
            }
        }

        /// <summary>
        /// Make a Post request to the API
        /// </summary>
        /// <typeparam name="T">The type of object to post to the API request</typeparam>
        /// <param name="url">The URL of the API request (does not include base)</param>
        /// <param name="data">The data to post to the URL</param>
        /// <returns>The HttpResult with status code and resulting object</returns>
        public static async Task<HttpResult<T>> Post<T>(string url, T data) => await Post<T, T>(url, data);

        /// <summary>
        /// Make a Post request to the API and return a different type of result object
        /// </summary>
        /// <typeparam name="T">The type of object to post to the API request</typeparam>
        /// <typeparam name="U">The type of object to return from the API request</typeparam>
        /// <param name="url">The URL of the API request (does not include base)</param>
        /// <param name="data">The data to post to the URL</param>
        /// <returns>The HttpResult with status code and resulting object</returns>
        public static async Task<HttpResult<U>> Post<T, U>(string url, T data)
        {
            var serialized = JsonConvert.SerializeObject(data);

            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(BaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsync(url, new StringContent(serialized, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode) {
                    var result = await response.Content.ReadAsStringAsync();

                    return new HttpResult<U> {
                        StatusCode = response.StatusCode,
                        Result = JsonConvert.DeserializeObject<U>(result)
                    };
                }

                return new HttpResult<U> {
                    StatusCode = response.StatusCode,
                };
            }
        }

        /// <summary>
        /// Make a Post request to the API and return a different type of result object and a cancellation token
        /// </summary>
        /// <typeparam name="T">The type of object to post to the API request</typeparam>
        /// <typeparam name="U">The type of object to return from the API request</typeparam>
        /// <param name="url">The URL of the API request (does not include base)</param>
        /// <param name="data">The data to post to the URL</param>
        /// <param name="cancellationToken">The cancellation token provided to the API request</param>
        /// <returns>The HttpResult with status code and resulting object</returns>
        public static async Task<HttpResult<U>> Post<T, U>(string url, T data, CancellationToken cancellationToken)
        {
            var serialized = JsonConvert.SerializeObject(data);

            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(BaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsync(url, new StringContent(serialized, Encoding.UTF8, "application/json"), cancellationToken);

                if (response.IsSuccessStatusCode) {
                    var result = await response.Content.ReadAsStringAsync();

                    return new HttpResult<U>
                    {
                        StatusCode = response.StatusCode,
                        Result = JsonConvert.DeserializeObject<U>(result)
                    };
                }

                return new HttpResult<U>
                {
                    StatusCode = response.StatusCode,
                };
            }
        }
    }
}
