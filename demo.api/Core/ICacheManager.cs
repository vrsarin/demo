using Microsoft.Extensions.Caching.Distributed;
using System.Threading;
using System.Threading.Tasks;

namespace demo.api.Core
{
    public interface ICacheManager
    {
        Task<byte[]> GetAsync(string key, DistributedCacheEntryOptions cacheOptions = null, CancellationToken token = default);
    }
}