using Dewey.Blob;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Dewey.Azure.Blob
{
    public class AzureBlobProvider : IBlobProvider
    {
        public static string ConnectionString { get; private set; }

        public AzureBlobProvider()
        {
        }

        public AzureBlobProvider(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public async Task<byte[]> DownloadAsync(string container, string name)
        {
            byte[] result;

            var blob = GetBlob(container, name);

            using (var memoryStream = new MemoryStream()) {
                await blob.DownloadToStreamAsync(memoryStream);
                result = memoryStream.ToArray();
            }

            return result;
        }

        public async Task UploadAsync(string container, string name, byte[] data, bool overwrite = true)
        {
            using (var stream = new MemoryStream(data)) {
                await UploadAsync(container, name, stream, overwrite);
            }
        }

        public async Task UploadAsync(string container, string name, Stream stream, bool overwrite = true)
        {
            var blob = GetBlob(container, name);

            var exists = await blob.ExistsAsync();

            if (!overwrite && exists) {
                return;
            }

            await CreateContainerAsync(container);

            // Create or overwrite the blob with contents from local file.
            await blob.UploadFromStreamAsync(stream);
        }
        
        public async Task<string> GetBlobUrlAsync(string container, string name)
        {
            var result = await GetBlobUriAsync(container, name);

            return result.AbsolutePath;
        }
        
        public Task<Uri> GetBlobUriAsync(string container, string name) => Task.FromResult(GetBlob(container, name).StorageUri.PrimaryUri);
        
        public async Task<string> GetContainerUrlAsync(string container)
        {
            var result = await GetContainerUriAsync(container);

            return result?.AbsolutePath;
        }
        
        public Task<Uri> GetContainerUriAsync(string container) => Task.FromResult(GetContainer(container)?.StorageUri?.PrimaryUri);
        
        public async Task<bool> ExistsAsync(string container, string name) => await GetBlob(container, name).ExistsAsync();
        
        public async Task CreateContainerAsync(string container)
        {
            var client = CloudStorageAccount.Parse(ConnectionString)
                                            .CreateCloudBlobClient();

            // Retrieve a reference to a container.
            var newContainer = client.GetContainerReference(container);

            // Create the container if it doesn't already exist.
            await newContainer.CreateIfNotExistsAsync();

            //make it publicly accessible
            await newContainer.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });
        }

        private CloudBlobClient GetClient() => CloudStorageAccount.Parse(ConnectionString).CreateCloudBlobClient();

        private CloudBlobContainer GetContainer(string container) => GetClient().GetContainerReference(container);

        private CloudBlockBlob GetBlob(string container, string name) => GetContainer(container).GetBlockBlobReference(name);
        
        public async Task DeleteBlobAsync(string container, string name) => await GetBlob(container, name).DeleteAsync();
        
        public async Task DeleteContainerAsync(string container) => await GetContainer(container).DeleteAsync();
    }
}
