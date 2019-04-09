using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.XPath;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// xml文件帮助类
	/// </summary>
	public class XmlHelper
    {
		private XmlHelper()
		{
		}

		#region 属性
		/// <summary>
		/// XmlDocument对象
		/// </summary>
		private XmlDocument xmlDoc = new XmlDocument();
		/// <summary>
		/// 得到XmlDocument对象
		/// </summary>
		public XmlDocument XmlDoc
		{
			get
			{
				return this.xmlDoc;
			}
		}

		/// <summary>
		/// 得到XML文档内容
		/// </summary>
		public string Xml
		{
			get
			{
				StringWriter writer = new StringWriter();
				this.xmlDoc.Save(writer);
				string str = writer.ToString();
				writer.Dispose();
				return str;
			}
		}
		#endregion

		#region 加载XML文件
		/// <summary>
		/// 加载XML文件
		/// </summary>
		/// <param name="fileName">文件名</param>
		private void Load(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException(nameof(fileName));
			}
			if (!FileHelper.IsExist(fileName,FileMethod.File))
			{
				throw new ArgumentNullException(nameof(fileName));
			}
			xmlDoc.Load(FileHelper.MapPath(fileName));
		}
		/// <summary>
		/// 从指定的字符串中加载XML文档
		/// </summary>
		/// <param name="xmlContent">XML文档内容</param>
		private void LoadXml(string xmlContent)
		{
			this.xmlDoc.LoadXml(xmlContent);
		}
		#endregion

		#region 以数据表形式得到节点的值
		/// <summary>
		/// 得到节点的值，返回一个具有"NodeName"、"NodeValue"、"Attribute"的3列数据表。
		/// </summary>
		/// <param name="nodeName">节点所在xpath路径</param>
		/// <param name="attribute">属性名</param>
		/// <returns>数据表</returns>
		private DataTable GetNodeValue(string nodeName, string attribute)
		{
			DataTable table = new DataTable();
			DataColumn column = new DataColumn("NodeName", typeof(string));
			DataColumn column2 = new DataColumn("NodeValue", typeof(string));
			if (!string.IsNullOrEmpty(attribute))
			{
				DataColumn column3 = new DataColumn("Attribute", typeof(string));
				table.Columns.Add(column3);
			}
			table.Columns.Add(column);
			table.Columns.Add(column2);
			if (string.IsNullOrEmpty(nodeName))
			{
				foreach (System.Xml.XmlNode node2 in this.xmlDoc.DocumentElement.ChildNodes)
				{
					DataRow row = table.NewRow();
					row["NodeName"] = node2.Name.ToLower();
					row["NodeValue"] = node2.InnerText;
					if (!string.IsNullOrEmpty(attribute))
					{
						row["Attribute"] = node2.Attributes[attribute].Value;
					}
					table.Rows.Add(row);
				}
			}
			else
			{
				System.Xml.XmlNode node4 = this.xmlDoc.DocumentElement.SelectSingleNode(nodeName);
				if ((node4 != null) && node4.HasChildNodes)
				{
					foreach (System.Xml.XmlNode node5 in node4)
					{
						DataRow row2 = table.NewRow();
						row2["NodeName"] = node5.Name;
						row2["NodeValue"] = node5.InnerText;
						if (!string.IsNullOrEmpty(attribute))
						{
							row2["Attribute"] = node5.Attributes[attribute].Value;
						}
						table.Rows.Add(row2);
					}
				}
			}
			table.AcceptChanges();
			return table;
		}
		/// <summary>
		/// 得到所有的节点值和节点的指定属性的值。返回一个具有"NodeName"、"NodeValue"、"Attribute"的3列数据表。
		/// </summary>
		/// <param name="nodeName">节点名所在xpath路径</param>
		/// <param name="attribute">属性名</param>
		/// <returns>DataTable</returns>
		public DataTable GetAllNodeAndTheFirstAttribute(string nodeName, string attribute)
		{
			return this.GetNodeValue(nodeName, attribute);
		}
		/// <summary>
		/// 得到所有的节点值，返回一个具有"NodeName"、"NodeValue"、"Attribute"的3列数据表。
		/// </summary>
		/// <param name="nodeName">节点名所在xpath路径</param>
		/// <returns>DataTable</returns>
		public DataTable GetAllNodeValue(string nodeName)
		{
			return this.GetNodeValue(nodeName, null);
		}
		#endregion

		#region 得到节点的值
		/// <summary>
		/// 得到节点的值
		/// </summary>
		/// <param name="path">节点名</param>
		/// <returns>节点值/空</returns>
		public string GetNodeValue(string path)
		{
			return this.GetSingleNodeValue(path);
		}
		/// <summary>
		/// 得到单节点的值
		/// </summary>
		/// <param name="nodeName">节点名</param>
		/// <returns>节点值/空</returns>
		public string GetSingleNodeValue(string nodeName)
		{
			if (!string.IsNullOrEmpty(nodeName) && (this.xmlDoc.SelectSingleNode(nodeName) != null))
			{
				return this.xmlDoc.SelectSingleNode(nodeName).InnerText;
			}
			return string.Empty;
		}
		/// <summary>
		/// 得到指定节点名称的节点标记。
		/// </summary>
		/// <param name="nodeName">节点名</param>
		/// <returns>节点标记/空</returns>
		public string SelectNode(string nodeName)
		{
			System.Xml.XmlNode node = this.xmlDoc.SelectSingleNode(nodeName);
			if (node == null)
			{
				return string.Empty;
			}
			return node.OuterXml;
		}
		#endregion

		#region 得到指定节点下的指定属性名的值
		/// <summary>
		/// 得到指定节点的所有属性名和属性值的字典类
		/// </summary>
		/// <param name="nodeName">节点名所在xpath路径</param>
		/// <returns>Dictionary</returns>
		public Dictionary<string, string> GetAttributesValue(string nodeName)
		{
			if (string.IsNullOrEmpty(nodeName))
			{
				return null;
			}
			System.Xml.XmlNode node = this.xmlDoc.SelectSingleNode(nodeName);
			if (node.Attributes == null)
			{
				return null;
			}
			XmlAttributeCollection attributes = node.Attributes;
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			foreach (XmlAttribute attribute in attributes)
			{
				dictionary.Add(attribute.Name, attribute.Value);
			}
			return dictionary;
		}
		/// <summary>
		/// 得到指定节点下的指定属性名的值。
		/// </summary>
		/// <param name="nodeName">节点名所在xpath路径</param>
		/// <param name="arrtibuteName">属性名</param>
		/// <returns>属性值/空</returns>
		public string GetAttributesValue(string nodeName, string arrtibuteName)
		{
			if (!string.IsNullOrEmpty(nodeName) && !string.IsNullOrEmpty(arrtibuteName))
			{
				return this.xmlDoc.SelectSingleNode(nodeName).Attributes.GetNamedItem(arrtibuteName).Value.ToLower().Trim();
			}
			return string.Empty;
		}
		#endregion

		#region 设置节点和属性的值
		/// <summary>
		/// 设置节点的属性值。
		/// </summary>
		/// <param name="nodeName">节点名</param>
		/// <param name="key">属性名</param>
		/// <param name="val">属性值</param>
		/// <returns>true/false</returns>
		public bool SetAttributesValue(string nodeName, string key, string val)
		{
			System.Xml.XmlNode node = this.xmlDoc.SelectSingleNode(nodeName);
			if (node == null)
			{
				return false;
			}
			((XmlElement)node).SetAttribute(key, val);
			return true;
		}
		/// <summary>
		/// 设置节点的值
		/// </summary>
		/// <param name="nodeName">节点名</param>
		/// <param name="val">节点值</param>
		/// <returns>true/false</returns>
		public bool SetNodeValue(string nodeName, string val)
		{
			System.Xml.XmlNode node = this.xmlDoc.SelectSingleNode(nodeName);
			if (node == null)
			{
				return false;
			}
			node.InnerText = val;
			return true;
		}
		#endregion

		#region 其他操作
		/// <summary>
		/// xml节点是否存在
		/// </summary>
		/// <param name="nodeName">节点所在的xpath路径</param>
		/// <returns>true/false</returns>
		public bool ExistsNode(string nodeName)
		{
			if (this.xmlDoc.SelectSingleNode(nodeName) == null)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// 得到节点对象
		/// </summary>
		/// <param name="path">xpath路径</param>
		/// <returns>节点对象</returns>
		public IXPathNavigable XmlNode(string path)
		{
			return this.xmlDoc.SelectSingleNode(path);
		}

		/// <summary>
		/// 删除节点
		/// </summary>
		/// <param name="nodeName">节点名</param>
		/// <returns>true/false</returns>
		public bool Remove(string nodeName)
		{
			try
			{
				System.Xml.XmlNode oldChild = this.xmlDoc.SelectSingleNode(nodeName);
				oldChild.ParentNode.RemoveChild(oldChild);
			}
			catch (NullReferenceException)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// 保存XML文件
		/// </summary>
		/// <param name="fileName">XML文件路径</param>
		public void Save(string fileName)
		{
			xmlDoc.Save(FileHelper.MapPath(fileName));
		}
		#endregion

		#region 静态方法
		/// <summary>
		/// 得到XmlHelper类实例
		/// </summary>
		/// <param name="fileName">文件名</param>
		/// <param name="type">xml文件类型</param>
		/// <returns>XmlManage</returns>
		public static XmlHelper Instance(string fileName, XmlType type)
		{
			XmlHelper manage = new XmlHelper();
			switch (type)
			{
				case XmlType.None:
					manage.Load(fileName);
					return manage;

				case XmlType.File:
					manage.Load(fileName);
					return manage;

				case XmlType.Content:
					manage.LoadXml(fileName);
					return manage;
			}
			return manage;
		}

		/// <summary>
		/// 检查XML文件地址是否存在
		/// </summary>
		/// <param name="datasource">xml文件地址 如：http://www.a.com/a.xml 或 xml/a.xml </param>
		/// <returns>true/false</returns>
		public static bool CheckXmlDataSource(string datasource)
		{
			if (!string.IsNullOrEmpty(datasource))
			{
				XmlDocument document = new XmlDocument();
				string pattern = @"^http:\/\/(.*?)";
				if (Regex.IsMatch(datasource.ToLower(), pattern))
				{
					bool flag = false;
					Stream inStream = null;
					Uri requestUri = new Uri(datasource);
					HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);
					try
					{
						var task = request.GetResponseAsync();
						HttpWebResponse response = (HttpWebResponse)task.Result;
						if ("OK" == response.StatusCode.ToString())
						{
							flag = true;
							inStream = response.GetResponseStream();
						}
					}
					catch (WebException)
					{
						return false;
					}
					if (flag)
					{
						try
						{
							document.Load(inStream);
							return true;
						}
						catch (XmlException)
						{
							return false;
						}
					}
					return false;
				}
				
				if (!FileHelper.IsExist(datasource, FileMethod.File))
				{
					return false;
				}
				
				try
				{
					document.Load(FileHelper.MapPath(datasource));
					return true;
				}
				catch (XmlException)
				{
					return false;
				}
			}
			return false;
		}

		/// <summary>
		/// 得到特定节点下的指定属性名的值。
		/// </summary>
		/// <param name="node">节点元素</param>
		/// <param name="name">属性名</param>
		/// <returns>属性值/空</returns>
		public static string GetAttributesValue(IXPathNavigable node, string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				XmlElement element = (XmlElement)node;
				if (element.HasAttribute(name))
				{
					return element.Attributes.GetNamedItem(name).Value;
				}
			}
			return string.Empty;
		}

		/// <summary>
		/// 得到XML树结构.(没有搞清楚)
		/// </summary>
		/// <param name="inputNode">指定的节点</param>
		/// <param name="loopdeep"></param>
		/// <param name="outdeep"></param>
		/// <param name="xpath"></param>
		/// <param name="outype"></param>
		/// <param name="stat"></param>
		/// <returns></returns>
		public static IList<XmlScheme> GetXmlTree(IXPathNavigable inputNode, int loopdeep, int outdeep, string xpath, int outype, int stat)
		{
			IList<XmlScheme> list = new List<XmlScheme>();
			if ((outdeep == 0) || (outdeep > 100))
			{
				outdeep = 100;
			}
			if (loopdeep < outdeep)
			{
				XmlNode node = (XmlNode)inputNode;
				int num = loopdeep;
				num++;
				XmlScheme item = new XmlScheme();
				item.Level = loopdeep;
				item.Station = stat;
				item.Path = xpath;
				item.Name = node.Name;
				item.Text = node.InnerText;
				if (!node.HasChildNodes)
				{
					item.Type = "onlyone";
					list.Add(item);
					return list;
				}
				XmlNodeList childNodes = node.ChildNodes;
				IList<XmlNode> list3 = new List<XmlNode>();
				bool flag = false;
				foreach (XmlNode node2 in childNodes)
				{
					if (string.Compare(node2.GetType().Name, "XmlElement", StringComparison.OrdinalIgnoreCase) != 0)
					{
						continue;
					}
					flag = true;
					bool flag2 = false;
					if (outype > 0)
					{
						foreach (XmlNode node3 in list3)
						{
							if (string.Compare(node3.Name, node2.Name, StringComparison.OrdinalIgnoreCase) == 0)
							{
								XmlElement element = (XmlElement)node3;
								element.SetAttribute("jx_tempshownum", (Convert.ToInt32(element.GetAttribute("jx_tempshownum")) + 1).ToString());
								flag2 = true;
							}
						}
					}
					if (!flag2)
					{
						((XmlElement)node2).SetAttribute("jx_tempshownum", "1");
						list3.Add(node2);
					}
				}
				if (flag)
				{
					item.Type = "havechile";
				}
				else
				{
					item.Type = "nochile";
				}
				XmlElement element3 = (XmlElement)node;
				if (element3.HasAttribute("jx_tempshownum"))
				{
					item.Repnum = Convert.ToInt32(element3.GetAttribute("jx_tempshownum").ToString());
				}
				list.Add(item);
				foreach (XmlNode node4 in list3)
				{
					int num3 = 0;
					if (list3.IndexOf(node4) == 0)
					{
						num3 = 1;
					}
					else if (list3.IndexOf(node4) == (list3.Count - 1))
					{
						num3 = 2;
					}
					if (string.Compare(node4.Name, "#text", StringComparison.OrdinalIgnoreCase) > 0)
					{
						string str = xpath + "/" + node.Name;
						foreach (XmlScheme scheme2 in GetXmlTree(node4, num, outdeep, str, outype, num3))
						{
							list.Add(scheme2);
						}
						continue;
					}
				}
			}
			return list;
		}

		/// <summary>
		/// 读取指定节点的内容
		/// </summary>
		/// <param name="filepath">XML文件路径</param>
		/// <param name="nodename">节点名</param>
		/// <returns>节点内容/空</returns>
		public static string ReadFileNode(string filepath, string nodename)
		{
			if ((!string.IsNullOrEmpty(filepath) && !string.IsNullOrEmpty(nodename)) && FileHelper.IsExist(filepath, FileMethod.File))
			{
				XmlDocument document = new XmlDocument();
				try
				{
					document.Load(filepath);
				}
				catch (XmlException)
				{
					return string.Empty;
				}
				try
				{
					return document.SelectSingleNode(nodename).InnerText;
				}
				catch (NullReferenceException)
				{
					return string.Empty;
				}
			}
			return string.Empty;
		}

		/// <summary>
		/// 在指定的父节点下添加指定了名称和内容的节点，并保存XML文件。
		/// </summary>
		/// <param name="filepath">xml文件路径</param>
		/// <param name="nodepath">父节点的xpath节点表达式</param>
		/// <param name="nodename">节点名</param>
		/// <param name="nodevalue">节点值</param>
		/// <returns>true/false</returns>
		public static bool SaveFileNode(string filepath, string nodepath, string nodename, string nodevalue)
		{
			if (((!string.IsNullOrEmpty(filepath) && !string.IsNullOrEmpty(nodepath)) && !string.IsNullOrEmpty(nodename)) && FileHelper.IsExist(filepath))
			{
				XmlDocument document = new XmlDocument();
				try
				{
					document.Load(filepath);
					foreach (System.Xml.XmlNode node in document.SelectNodes(nodepath))
					{
						XmlNodeList list2 = node.SelectNodes(nodename);
						if (list2.Count > 0)
						{
							foreach (System.Xml.XmlNode node2 in list2)
							{
								XmlElement element = (XmlElement)node2;
								element.RemoveAll();
								if (!string.IsNullOrEmpty(nodevalue))
								{
									if (((nodevalue.IndexOf("<", StringComparison.Ordinal) > 0) || (nodevalue.IndexOf(">", StringComparison.Ordinal) > 0)) || (nodevalue.IndexOf("'", StringComparison.Ordinal) > 0))
									{
										XmlCDataSection section = document.CreateCDataSection(nodevalue);
										element.AppendChild(section);
										continue;
									}
									element.InnerText = nodevalue;
								}
							}
							continue;
						}
						XmlElement newChild = document.CreateElement("", nodename, "");
						if (((nodevalue.IndexOf("<", StringComparison.Ordinal) > 0) || (nodevalue.IndexOf(">", StringComparison.Ordinal) > 0)) || (nodevalue.IndexOf("'", StringComparison.Ordinal) > 0))
						{
							XmlCDataSection section2 = document.CreateCDataSection(nodevalue);
							newChild.AppendChild(section2);
						}
						else
						{
							newChild.InnerText = nodevalue;
						}
						node.AppendChild(newChild);
					}
					document.Save(filepath);
					return true;
				}
				catch (XmlException)
				{
					return false;
				}
			}
			return false;
		}

		/// <summary>
		/// 得到文件流
		/// </summary>
		/// <param name="fileName">文件路径</param>
		/// <returns></returns>
		private static FileStream GetFileStream(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentNullException(nameof(fileName));
			}
			if (!FileHelper.IsExist(fileName, FileMethod.File))
			{
				throw new ArgumentNullException(nameof(fileName));
			}
			FileStream stream = new FileStream(FileHelper.MapPath(fileName), FileMode.Open, FileAccess.Read);
			return stream;
		}
		#endregion
	}
}
