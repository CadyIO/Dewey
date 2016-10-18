using System;
using System.IO;
using System.Threading.Tasks;
using Dewey.Types;

namespace Dewey.Blob.Providers
{
    public class LocalBlobProvider : IBlobProvider
    {
        public static string BlobDirectory { get; private set; }

        public LocalBlobProvider()
        {
            if (BlobDirectory.IsEmpty()) {
                BlobDirectory = Path.GetTempPath();
            }
        }

        public LocalBlobProvider(string blobDirectory)
        {
            BlobDirectory = blobDirectory;
        }

        public byte[] Download(string container, string name) => File.ReadAllBytes(GetBlobUri(container, name).AbsolutePath);

        public Task<byte[]> DownloadAsync(string container, string name) => Task.FromResult(Download(container, name));

        public string GetContainerUrl(string container) => GetContainerUri(container).AbsolutePath;

        public async Task<string> GetContainerUrlAsync(string container)
        {
            var result = await GetContainerUriAsync(container);

            return result.AbsolutePath;
        }

        public string GetBlobUrl(string container, string name) => GetBlobUri(container, name).AbsolutePath;

        public async Task<string> GetBlobUrlAsync(string container, string name)
        {
            var result = await GetBlobUriAsync(container, name);

            return result.AbsolutePath;
        }

        public Uri GetContainerUri(string container) => new Uri(Path.Combine(BlobDirectory, container));

        public Task<Uri> GetContainerUriAsync(string container) => Task.FromResult(GetContainerUri(container));

        public Uri GetBlobUri(string container, string name) => new Uri(Path.Combine(BlobDirectory, container, name));

        public Task<Uri> GetBlobUriAsync(string container, string name) => Task.FromResult(GetBlobUri(container, name));

        public void Upload(string container, string name, byte[] data, bool overwrite = true)
        {
            if (!overwrite) {
                var exists = Exists(container, name);

                if (exists) {
                    return;
                }
            }

            CreateContainer(container);

            var uri = GetBlobUri(container, name);

            File.WriteAllBytes(uri.AbsolutePath, data);
        }

        public Task UploadAsync(string container, string name, byte[] data, bool overwrite = true)
        {
            if (!overwrite) {
                var exists = Exists(container, name);

                if (exists) {
                    return Task.FromResult(false);
                }
            }

            CreateContainer(container);

            var uri = GetBlobUri(container, name);

            File.WriteAllBytes(uri.AbsolutePath, data);

            return Task.FromResult(true);
        }

        public void Upload(string container, string name, Stream stream, bool overwrite = true) => Upload(container, name, stream.GetBytes(), overwrite);

        public async Task UploadAsync(string container, string name, Stream stream, bool overwrite = true) => await UploadAsync(container, name, stream.GetBytes(), overwrite);

        public bool Exists(string container, string name) => File.Exists(GetBlobUrl(container, name));

        public async Task<bool> ExistsAsync(string container, string name)
        {
            var url = await GetBlobUrlAsync(container, name);

            return File.Exists(url);
        }

        public void CreateContainer(string container)
        {
            var path = Path.Combine(BlobDirectory, container);

            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
        }

        public Task CreateContainerAsync(string container)
        {
            var path = Path.Combine(BlobDirectory, container);

            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }

            return Task.FromResult(true);
        }
        
        public void DeleteBlob(string container, string name)
        {
            var path = Path.Combine(BlobDirectory, container);

            path = Path.Combine(path, name);

            if (File.Exists(path)) {
                File.Delete(path);
            }
        }

        public void DeleteContainer(string container)
        {
            var path = Path.Combine(BlobDirectory, container);

            if (Directory.Exists(path)) {
                Directory.Delete(path, true);
            }
        }

        public Task DeleteBlobAsync(string container, string name)
        {
            DeleteBlob(container, name);

            return Task.FromResult(true);
        }

        public Task DeleteContainerAsync(string container)
        {
            DeleteContainer(container);

            return Task.FromResult(true);
        }
    }
}