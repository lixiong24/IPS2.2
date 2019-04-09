using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// Xml 序列化/反序列化。
	/// </summary>
	public class XmlSerializer : ISerializer
	{
		/// <summary>
		/// 获取序列化类型
		/// </summary>
		public SerializeType SerializeType
		{
			get
			{
				return SerializeType.Xml;
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
			
			System.Xml.Serialization.XmlSerializer mySerializer = new System.Xml.Serialization.XmlSerializer(objType);
			using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(str)))
			{
				using (StreamReader sr = new StreamReader(ms))
				{
					return mySerializer.Deserialize(sr);
				}
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

			System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
			//去除默认的命名空间声明。
			XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
			xmlNamespaces.Add("", "");
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.OmitXmlDeclaration = true;
			settings.Indent = true;
			settings.NewLineChars = "\r\n";
			settings.IndentChars = "    ";

			MemoryStream outStream = new MemoryStream();
			using (XmlWriter writer = XmlWriter.Create(outStream, settings))
			{
				serializer.Serialize(writer, obj, xmlNamespaces);
			}

			outStream.Position = 0;
			using (StreamReader reader = new StreamReader(outStream))
			{
				return reader.ReadToEnd();
			}
		}
	}
}
