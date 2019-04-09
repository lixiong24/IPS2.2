using System;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 序列化帮助类
	/// </summary>
	public static class SerializerHelper
    {
		/// <summary>
		/// 得到序列化实例
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static ISerializer GetSerializer(SerializeType type)
		{
			switch (type)
			{
				case SerializeType.Json:
					return GetJsonSerializer();
				case SerializeType.Xml:
					return GetXmlSerializer();
				default:
					return GetJsonSerializer();
			}
		}

		/// <summary>
		/// 得到json类型的序列化实例
		/// </summary>
		/// <returns></returns>
		public static ISerializer GetJsonSerializer()
		{
			return new JsonSerializer();
		}

		/// <summary>
		/// 得到XML类型的序列化实例
		/// </summary>
		/// <returns></returns>
		public static ISerializer GetXmlSerializer()
		{
			return new XmlSerializer();
		}

		/// <summary>
		/// 将 json 字符串转换为指定类型的对象表示形式。
		/// </summary>
		/// <typeparam name="T">要转换成的对象类型。</typeparam>
		/// <param name="json">json 字符串。</param>
		/// <returns>转换完后的 JSON 对象。</returns>
		public static T ToJsonObject<T>(this string json)
		{
			if (string.IsNullOrEmpty(json))
				throw new ArgumentNullException(nameof(json));

			ISerializer serializer = GetJsonSerializer();
			return serializer.Deserialize<T>(json);
		}

		/// <summary>
		/// 将给定 XML 字符串（<see paracref="xml"/>）转换为指定类型的对象表示形式。
		/// </summary>
		/// <typeparam name="T">要转换成的对象类型。</typeparam>
		/// <param name="xml">json 字符串。</param>
		/// <returns>转换完后的 Xml 对象。</returns>
		public static T ToXmlObject<T>(this string xml)
		{
			if (string.IsNullOrEmpty(xml))
				throw new ArgumentNullException(nameof(xml));

			ISerializer serializer = GetXmlSerializer();
			return serializer.Deserialize<T>(xml);
		}

		/// <summary>
		/// 把一个对象序列化成JSON字符串
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="tObj"></param>
		/// <returns></returns>
		public static string ToJson<T>(this T tObj)
		{
			if (tObj == null)
				throw new ArgumentNullException(nameof(tObj));

			ISerializer serializer = GetJsonSerializer();
			return serializer.Serialize(tObj);
		}

		/// <summary>
		/// 把一个对象序列化成XML字符串
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="tObj"></param>
		/// <returns></returns>
		public static string ToXml<T>(this T tObj)
		{
			if (tObj == null)
				throw new ArgumentNullException(nameof(tObj));

			ISerializer serializer = GetXmlSerializer();
			return serializer.Serialize(tObj);
		}
	}
}
