using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Redis;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 缓存帮助类
	/// </summary>
	public static class CacheHelper
    {
		/// <summary>
		/// 缓存服务提供者,根据appsettings.json中的配置选项，来决定是使用RedisCache还是MemoryCache
		/// </summary>
		public static ICacheService CacheServiceProvider { get; }
		/// <summary>
		/// 根据appsettings.json中的配置选项，来决定是使用RedisCache还是MemoryCache
		/// </summary>
		static CacheHelper()
		{
			var redisConfig = ConfigHelper.GetAppSettingSection<RedisConfig>();
			if (redisConfig.IsUseRedis)
			{
				CacheServiceProvider = new RedisCacheService(new RedisCacheOptions()
				{
					Configuration = redisConfig.ConnectionString,
					InstanceName = redisConfig.InstanceName
				});
			}
			else
			{
				CacheServiceProvider = new MemoryCacheService(new MemoryCache(new MemoryCacheOptions()));
			}
		}
	}
}
