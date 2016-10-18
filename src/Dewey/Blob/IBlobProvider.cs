using System;
using System.IO;
using System.Threading.Tasks;

namespace Dewey.Blob
{
    public interface IBlobProvider
    {
        Task<byte[]> DownloadAsync(string container, string name);
        
        Task UploadAsync(string container, string name, byte[] data, bool overwrite = true);
        Task UploadAsync(string container, string name, Stream stream, bool overwrite = true);
        
        Task<string> GetContainerUrlAsync(string container);
        
        Task<string> GetBlobUrlAsync(string container, string name);
        
        Task<Uri> GetContainerUriAsync(string container);
        
        Task<Uri> GetBlobUriAsync(string container, string name);
        
        Task<bool> ExistsAsync(string container, string name);
        
        Task CreateContainerAsync(string container);

        Task DeleteBlobAsync(string container, string name);

        Task DeleteContainerAsync(string container);
    }
}
