using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// Json 序列化/反序列化。
	/// </summary>
	public class JsonSerializer : ISerializer
	{
		/// <summary>
		/// 获取序列化类型
		/// </summary>
		public SerializeType SerializeType
		{
			get
			{
				return SerializeType.Json;
			}
		}

		/// <summary>
		/// 将一个字符串反序列化为一个对象
		/// </summary>
		/// <param name="objType">要反序列化的对象类型</param>
		/// <param name="str">要反序列化的字符串</param>
		/// <returns>反序列化得到的对象</returns>
		public object Deserialize(Type objType, string str)
		{
			if (objType == null)
				throw new ArgumentNullException(nameof(objType));
			if (string.IsNullOrEmpty(str))
				throw new ArgumentNullException(nameof(str));

			using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(str)))
			{
				return new DataContractJsonSerializer(objType).ReadObject(ms);
			}
		}
		/// <summary>
		/// 将一个字符串反序列化为一个对象
		/// </summary>
		/// <typeparam name="T">要反序列化的对象类型</typeparam>
		/// <param name="str">要反序列化的字符串</param>
		/// <returns></returns>
		public T Deserialize<T>(string str)
		{
			if (string.IsNullOrEmpty(str))
				throw new ArgumentNullException(nameof(str));

			return (T)Deserialize(typeof(T), str);
		}

		/// <summary>
		/// 将一个对象序列化成一个字符串。
		/// </summary>
		/// <param name="obj">要序列化的对象</param>
		/// <returns>序列化后的字符串</returns>
		public string Serialize(object obj)
		{
			if (obj == null)
				throw new ArgumentNullException(nameof(obj));

			using (var ms = new MemoryStream())
			{
				new DataContractJsonSerializer(obj.GetType()).WriteObject(ms, obj);
				return Encoding.UTF8.GetString(ms.ToArray());
			}
		}
	}
}
