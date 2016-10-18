using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;

namespace Dewey.Caching
{
    public interface ICacheService : IDistributedCache
    {
        void SetPrefix(string prefix);
        Task SetPrefixAsync(string prefix);

        string GetKey<T>(string key);
        Task<string> GetKeyAsync<T>(string key);

        T Get<T>(string key);
        Task<T> GetAsync<T>(string key);

        void Set<T>(string key, T value);
        Task SetAsync<T>(string key, T value);

        void RemoveType<T>();
        Task RemoveTypeAsync<T>();

        bool Contains<T>(string key);
        Task<bool> ContainsAsync<T>(string key);

        void Flush();
        Task FlushAsync();
    }
}
