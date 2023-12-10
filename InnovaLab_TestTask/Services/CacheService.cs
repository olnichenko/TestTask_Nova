using InnovaLab_TestTask.Services.Abstract;
using Microsoft.Extensions.Caching.Memory;

namespace InnovaLab_TestTask.Services
{
    public class CacheService : ICacheService
	{
		private readonly IMemoryCache _cache;
		public CacheService(IMemoryCache memoryCache)
		{
			_cache = memoryCache;
		}

		public T? Get<T>(string key)
		{
			if (!_cache.TryGetValue(key, out T? value))
			{
				return default;
			}

			return value;
		}

		public void Set<T>(string key, T value, TimeSpan? absoluteExpiration = null)
		{
			_cache.Set(key, value, absoluteExpiration ?? TimeSpan.FromMinutes(15));
		}
	}
}
