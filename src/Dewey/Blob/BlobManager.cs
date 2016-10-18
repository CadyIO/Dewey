using System;
using System.IO;
using System.Threading.Tasks;

namespace Dewey.Blob
{
    public class BlobManager : IDisposable
    {
        public IBlobProvider Provider { get; set; }

        public BlobManager()
        {
            if (BlobSettings.DefaultProvider == null) {
                Provider = new Providers.LocalBlobProvider();
            } else {
                Provider = BlobSettings.DefaultProvider;
            }
        }

        public BlobManager(IBlobProvider provider)
        {
            Provider = provider;
        }

        public async Task<byte[]> DownloadAsync(string container, string name) => await Provider.DownloadAsync(container, name);

        public async Task<string> GetBlobUrlAsync(string container, string name) => await Provider.GetBlobUrlAsync(container, name);

        public async Task<Uri> GetBlobUriAsync(string container, string name) => await Provider.GetBlobUriAsync(container, name);

        public async Task<string> GetContainerUrlAsync(string container) => await Provider.GetContainerUrlAsync(container);

        public async Task<Uri> GetContainerUriAsync(string container) => await Provider.GetContainerUriAsync(container);

        public async Task UploadAsync(string container, string name, byte[] data) => await Provider.UploadAsync(container, name, data);

        public async Task UploadAsync(string container, string name, Stream stream) => await Provider.UploadAsync(container, name, stream);

        public async Task<bool> ExistsAsync(string container, string name) => await Provider.ExistsAsync(container, name);

        public async Task DeleteBlobAsync(string container, string name) => await Provider.DeleteBlobAsync(container, name);

        public async Task DeleteContainerAsync(string container) => await Provider.DeleteContainerAsync(container);
        
        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed) {
                if (disposing) {
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
