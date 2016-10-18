using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace Dewey.Caching.Redis
{
    public class RedisCacheService : ICacheService, IDistributedCache
    {
        //private readonly IOptions<DistributedCacheEntryOptions> _optionsAccessor;

        //public DistributedCacheEntryOptions Options { get; private set; }

        private static IDatabase _cache => lazyConnection.Value.GetDatabase();

        public static ConfigurationOptions ConfigurationOptions { get; set; }

        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() => {
            if (ConfigurationOptions == null) {
                throw new ArgumentNullException("ConfigurationOptions must be set.");
            }

            return ConnectionMultiplexer.Connect(ConfigurationOptions);
        });


        public bool Contains<T>(string key)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ContainsAsync<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void Flush()
        {
            foreach (var endpoint in lazyConnection.Value.GetEndPoints()) {
                lazyConnection.Value.GetServer(endpoint).FlushDatabase();
            }
        }

        public async Task FlushAsync()
        {
            foreach (var endpoint in lazyConnection.Value.GetEndPoints()) {
                await lazyConnection.Value.GetServer(endpoint).FlushDatabaseAsync();
            }
        }

        public byte[] Get(string key)
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync<T>(string key)
        {
            throw new NotImplementedException();
        }

        public string GetKey<T>(string key)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetKeyAsync<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void Refresh(string key)
        {
            throw new NotImplementedException();
        }

        public Task RefreshAsync(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string key)
        {
            throw new NotImplementedException();
        }

        public void RemoveType<T>()
        {
            throw new NotImplementedException();
        }

        public Task RemoveTypeAsync<T>()
        {
            throw new NotImplementedException();
        }

        public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
        {
            throw new NotImplementedException();
        }

        public void Set<T>(string key, T value)
        {
            key = GetKey<T>(key);

            _cache.StringSet(key, JsonConvert.SerializeObject(value), TimeToExpire);
        }

        public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options)
        {
            throw new NotImplementedException();
        }

        public Task SetAsync<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public void SetOptions(DistributedCacheEntryOptions options)
        {
            throw new NotImplementedException();
        }

        public Task SetOptionsAsync(DistributedCacheEntryOptions options)
        {
            throw new NotImplementedException();
        }

        public void SetPrefix(string prefix)
        {
            throw new NotImplementedException();
        }

        public Task SetPrefixAsync(string prefix)
        {
            throw new NotImplementedException();
        }
    }
}
