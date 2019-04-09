using Microsoft.Extensions.Caching.Redis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 通过redis来实现分布式缓存
	/// </summary>
	public class RedisCacheService : ICacheService
	{
		/// <summary>
		/// 
		/// </summary>
		protected IDatabase m_Cache;
		private ConnectionMultiplexer m_Connection;
		private readonly string m_Instance;

		/// <summary>
		/// 通过构造器注入
		/// </summary>
		/// <param name="options"></param>
		/// <param name="database"></param>
		public RedisCacheService(RedisCacheOptions options, int database = 0)
		{
			m_Connection = ConnectionMultiplexer.Connect(options.Configuration);
			m_Cache = m_Connection.GetDatabase(database);
			m_Instance = options.InstanceName;
		}

		/// <summary>
		/// 组合Key值和实例名，就是Key值转为 实例名+Key
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public string GetKeyForRedis(string key)
		{
			return m_Instance + key;
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
			return m_Cache.KeyExists(GetKeyForRedis(key));
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
			var value = m_Cache.StringGet(GetKeyForRedis(key));
			if (!value.HasValue)
			{
				return default(T);
			}
			//return SerializerHelper.GetJsonSerializer().Deserialize<T>(value);
			return JsonConvert.DeserializeObject<T>(value);
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
			var value = m_Cache.StringGet(GetKeyForRedis(key));
			if (!value.HasValue)
			{
				return null;
			}
			//return SerializerHelper.GetJsonSerializer().Deserialize(typeof(object), value);
			return JsonConvert.DeserializeObject(value);
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
			keys.ToList().ForEach(item => dict.Add(item, Get(GetKeyForRedis(item))));
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
			return m_Cache.KeyDelete(GetKeyForRedis(key));
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
			keys.ToList().ForEach(item => Remove(item));
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
			//return m_Cache.StringSet(GetKeyForRedis(key), Encoding.UTF8.GetBytes(SerializerHelper.GetJsonSerializer().Serialize(value)));
			return m_Cache.StringSet(GetKeyForRedis(key), Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value)));
		}
		/// <summary>
		/// 添加缓存,如果存在则更新
		/// </summary>
		/// <param name="key">缓存Key</param>
		/// <param name="value">缓存Value</param>
		/// <param name="expiresSliding">滑动过期时长（如果在过期时间内有操作，则以当前时间点延长过期时间,Redis中无效）</param>
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
			//return m_Cache.StringSet(GetKeyForRedis(key), Encoding.UTF8.GetBytes(SerializerHelper.GetJsonSerializer().Serialize(value)), expiressAbsoulte);
			return m_Cache.StringSet(GetKeyForRedis(key), Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value)), expiressAbsoulte);
		}
		/// <summary>
		/// 添加缓存,如果存在则更新
		/// </summary>
		/// <param name="key">缓存Key</param>
		/// <param name="value">缓存Value</param>
		/// <param name="expiresIn">缓存时长</param>
		/// <param name="isSliding">是否滑动过期（如果在过期时间内有操作，则以当前时间点延长过期时间,Redis中无效）</param>
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
			//return m_Cache.StringSet(GetKeyForRedis(key), Encoding.UTF8.GetBytes(SerializerHelper.GetJsonSerializer().Serialize(value)), expiresIn);
			return m_Cache.StringSet(GetKeyForRedis(key), Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value)), expiresIn);
		}
		#endregion

		/// <summary>
		/// 销毁对象
		/// </summary>
		public void Dispose()
		{
			if (m_Connection != null)
				m_Connection.Dispose();
			GC.SuppressFinalize(this);
		}

	}
}
