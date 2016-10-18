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
        public static byte[] GetBytes(this Stream stream)
        {
            using (var memoryStream = new MemoryStream()) {
                stream.CopyTo(memoryStream);

                return memoryStream.ToArray();
            }
        }

        public static Stream ToStream(this byte[] buffer) => new MemoryStream(buffer);

        public static string ReadString(this Stream stream) => ReadString(stream, Encoding.UTF8);

        public static string ReadString(this Stream stream, Encoding encoding)
        {
            string result;

            using (var reader = new StreamReader(stream, encoding)) {
                result = reader.ReadToEnd();
            }

            return result;
        }

        public static async Task<string> ReadStringAsync(this Stream stream) => await ReadStringAsync(stream, Encoding.UTF8);

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
