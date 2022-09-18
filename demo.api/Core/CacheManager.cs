using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace demo.api.Core
{
    public class CacheManager : ICacheManager
    {
        private readonly IDistributedCache cache;

        public CacheManager(IDistributedCache cache)
        {
            this.cache = cache;
        }

        public async Task<byte[]> GetAsync(
            string key,
            DistributedCacheEntryOptions cacheOptions = default(DistributedCacheEntryOptions),
            CancellationToken token = default(CancellationToken))
        {

            var cacheValue = await this.cache.GetAsync(key, token);
            if (cacheValue is object)
            {
                return cacheValue;
            }

            return default;
        }


    }
}
