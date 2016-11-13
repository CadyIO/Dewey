using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Dewey.Types
{
    /// <summary>
    /// Extension methods for Stream type
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Get the byte array value of a Stream
        /// </summary>
        /// <param name="stream">The Stream</param>
        /// <returns>The byte array value</returns>
        public static byte[] GetBytes(this Stream stream)
        {
            using (var memoryStream = new MemoryStream()) {
                stream.CopyTo(memoryStream);

                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Convert a byte array to a MemoryStream
        /// </summary>
        /// <param name="buffer">The byte array</param>
        /// <returns>The Stream</returns>
        public static Stream ToMemoryStream(this byte[] buffer) => new MemoryStream(buffer);

        /// <summary>
        /// Read a string from a UTF-8 encoded Stream
        /// </summary>
        /// <param name="stream">The Stream to read</param>
        /// <returns>The string value</returns>
        public static string ReadString(this Stream stream) => ReadString(stream, Encoding.UTF8);

        /// <summary>
        /// Read a string from a Stream
        /// </summary>
        /// <param name="stream">The Stream to read</param>
        /// <param name="encoding">The encoding of the Stream</param>
        /// <returns>The string value</returns>
        public static string ReadString(this Stream stream, Encoding encoding)
        {
            string result;

            using (var reader = new StreamReader(stream, encoding)) {
                result = reader.ReadToEnd();
            }

            return result;
        }

        /// <summary>
        /// Asynchcroneously read a string from a UTF-8 encoded Stream
        /// </summary>
        /// <param name="stream">The Stream to read</param>
        /// <returns>The string value task</returns>
        public static async Task<string> ReadStringAsync(this Stream stream) => await ReadStringAsync(stream, Encoding.UTF8);


        /// <summary>
        /// Asynchcroneously read a string from a Stream
        /// </summary>
        /// <param name="stream">The Stream to read</param>
        /// <param name="encoding">The encoding of the Stream</param>
        /// <returns>The string value task</returns>
        public static Task<string> ReadStringAsync(this Stream stream, Encoding encoding)
        {
            string result;

            using (var reader = new StreamReader(stream, encoding)) {
                result = reader.ReadToEnd();
            }

            return Task.FromResult(result);
        }
    }
}
