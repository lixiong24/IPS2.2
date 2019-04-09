using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 通过.net core自带的内存缓存(MemoryCache)实现缓存接口。MemoryCache为单机缓存。
	/// </summary>
	public class MemoryCacheService : ICacheService
	{
		/// <summary>
		/// .net core自带的内存缓存(MemoryCache)实现缓存接口。MemoryCache为单机缓存。
		/// </summary>
		protected IMemoryCache m_Cache;

		/// <summary>
		/// 通过构造器注入
		/// </summary>
		/// <param name="cache"></param>
		public MemoryCacheService(IMemoryCache cache)
		{
			m_Cache = cache;
		}

		/// <summary>
		/// 验证缓存项是否存在
		/// </summary>
		/// <param name="key">缓存Key</param>
		/// <returns></returns>
		public bool Exists(string key)
		{
			if (key == null)
			{
				throw new ArgumentNullException(nameof(key));
			}
			object cached;
			return m_Cache.TryGetValue(key, out cached);
		}

		#region 得到缓存
		/// <summary>
		/// 获取缓存
		/// </summary>
		/// <typeparam name="T">获取缓存对象类型</typeparam>
		/// <param name="key">缓存Key</param>
		/// <returns>获取指定key对应的值</returns>
		public T Get<T>(string key) where T : class
		{
			if (key == null)
			{
				throw new ArgumentNullException(nameof(key));
			}
			return m_Cache.Get(key) as T;
		}
		/// <summary>
		/// 获取缓存
		/// </summary>
		/// <param name="key">缓存Key</param>
		/// <returns>获取指定key对应的值</returns>
		public object Get(string key)
		{
			if (key == null)
			{
				throw new ArgumentNullException(nameof(key));
			}
			return m_Cache.Get(key);
		}
		/// <summary>
		/// 获取缓存集合
		/// </summary>
		/// <param name="keys">缓存Key集合</param>
		/// <returns></returns>
		public IDictionary<string, object> GetAll(IEnumerable<string> keys)
		{
			if (keys == null)
			{
				throw new ArgumentNullException(nameof(keys));
			}

			var dict = new Dictionary<string, object>();
			keys.ToList().ForEach(item => dict.Add(item, m_Cache.Get(item)));
			return dict;
		}
		#endregion

		#region 删除缓存
		/// <summary>
		/// 删除缓存
		/// </summary>
		/// <param name="key">缓存Key</param>
		/// <returns></returns>
		public bool Remove(string key)
		{
			if (key == null)
			{
				throw new ArgumentNullException(nameof(key));
			}
			m_Cache.Remove(key);
			return !Exists(key);
		}
		/// <summary>
		/// 批量删除缓存
		/// </summary>
		/// <param name="keys">缓存Key集合</param>
		public void RemoveAll(IEnumerable<string> keys)
		{
			if (keys == null)
			{
				throw new ArgumentNullException(nameof(keys));
			}
			keys.ToList().ForEach(item => m_Cache.Remove(item));
		}
		#endregion

		#region 添加缓存
		/// <summary>
		/// 添加缓存,如果存在则更新
		/// </summary>
		/// <param name="key">缓存Key</param>
		/// <param name="value">缓存Value</param>
		/// <returns>是否添加成功</returns>
		public bool AddOrUpdate(string key, object value)
		{
			if (key == null)
			{
				throw new ArgumentNullException(nameof(key));
			}
			if (value == null)
			{
				throw new ArgumentNullException(nameof(value));
			}
			if (Exists(key))
			{
				if (!Remove(key))
					return false;
			}
			m_Cache.Set(key, value);
			return true;
		}
		/// <summary>
		/// 添加缓存,如果存在则更新
		/// </summary>
		/// <param name="key">缓存Key</param>
		/// <param name="value">缓存Value</param>
		/// <param name="expiresSliding">滑动过期时长（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
		/// <param name="expiressAbsoulte">绝对过期时长</param>
		/// <returns>是否添加成功</returns>
		public bool AddOrUpdate(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte)
		{
			if (key == null)
			{
				throw new ArgumentNullException(nameof(key));
			}
			if (value == null)
			{
				throw new ArgumentNullException(nameof(value));
			}
			if (Exists(key))
			{
				if (!Remove(key))
					return false;
			}
			var opt = new MemoryCacheEntryOptions();
			if (expiressAbsoulte != null)
				opt.SetAbsoluteExpiration(expiressAbsoulte);
			if (expiresSliding != null)
				opt.SetSlidingExpiration(expiresSliding);
			m_Cache.Set(key, value,opt);
			return true;
		}
		/// <summary>
		/// 添加缓存,如果存在则更新
		/// </summary>
		/// <param name="key">缓存Key</param>
		/// <param name="value">缓存Value</param>
		/// <param name="expiresIn">缓存时长</param>
		/// <param name="isSliding">是否滑动过期（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
		/// <returns>是否添加成功</returns>
		public bool AddOrUpdate(string key, object value, TimeSpan expiresIn, bool isSliding = false)
		{
			if (key == null)
			{
				throw new ArgumentNullException(nameof(key));
			}
			if (value == null)
			{
				throw new ArgumentNullException(nameof(value));
			}
			if (Exists(key))
			{
				if (!Remove(key))
					return false;
			}
			var opt = new MemoryCacheEntryOptions();
			if (isSliding)
			{
				opt.SetSlidingExpiration(expiresIn);
			}
			else
			{
				opt.SetAbsoluteExpiration(expiresIn);
			}
			m_Cache.Set(key, value, opt);
			return true;
		}
		#endregion

		/// <summary>
		/// 销毁对象
		/// </summary>
		public void Dispose()
		{
			if (m_Cache != null)
				m_Cache.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
