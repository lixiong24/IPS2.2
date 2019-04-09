using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 数据安全检查相关类:转换JS,标签字符,XML标识符,过滤SQL非法字符,SQL关键字,生成随机文件名,安全取数据元素值等.
	/// </summary>
	public class DataSecurity
    {
		private static Random rnd = new Random();

		/// <summary>
		/// 将字符串转换为符合JS输出格式 (将\ \n \r \ " '等字符加上转义符)
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string ConvertToJavaScript(string str)
		{
			str = str.Replace(@"\", @"\\");
			str = str.Replace("\n", @"\n");
			str = str.Replace("\r", @"\r");
			str = str.Replace("\"", "\\\"");
			str = str.Replace("'", @"\'");
			return str;
		}

		#region 过滤SQL非法字符和关键字
		/// <summary>
		/// 过滤SQL非法字符
		/// </summary>
		/// <param name="strchar">要过滤的字符串</param>
		/// <returns></returns>
		public static string FilterBadChar(string strchar)
		{
			string input = string.Empty;
			if (string.IsNullOrEmpty(strchar))
			{
				return string.Empty;
			}
			string str = strchar;
			string[] strArray = new string[] { "+", "'", "%", "^", "&", "?", "(", ")", "<", ">", "[", "]", "{", "}", "/", "\"", ";", ":", "Chr(34)", "Chr(0)", "--" };
			StringBuilder builder = new StringBuilder(str);
			for (int i = 0; i < strArray.Length; i++)
			{
				input = builder.Replace(strArray[i], string.Empty).ToString();
			}
			return Regex.Replace(input, "@+", "@");
		}
		/// <summary>
		/// 过滤SQL关键字,如果发现输入的字符串有SQL关键字，则继续过滤SQL非法字符
		/// </summary>
		/// <param name="strchar">要过滤的字符串</param>
		/// <returns></returns>
		public static string FilterSqlKeyword(string strchar)
		{
			bool flag = false;
			if (string.IsNullOrEmpty(strchar))
			{
				return string.Empty;
			}
			strchar = strchar.ToUpperInvariant();
			string[] strArray = new string[] { "SELECT", "UPDATE", "INSERT", "DELETE", "DECLARE", "@", "EXEC", "DBCC", "ALTER", "DROP", "CREATE", "BACKUP", "IF", "ELSE", "END", "AND", "OR", "ADD", "SET", "OPEN", "CLOSE", "USE", "BEGIN", "RETUN", "AS", "GO", "EXISTS", "KILL" };
			for (int i = 0; i < strArray.Length; i++)
			{
				if (strchar.Contains(strArray[i]))
				{
					strchar = strchar.Replace(strArray[i], string.Empty);
					flag = true;
				}
			}
			if (flag)
			{
				return FilterBadChar(strchar);
			}
			return strchar;
		}
		/// <summary>
		/// 转换对象类型为INT类型，失败返回0
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static int ObjectToInt32(object value)
		{
			int result = 0;
			if ((!object.Equals(value, null) && !object.Equals(value, DBNull.Value)) && !int.TryParse(value.ToString(), out result))
			{
				result = 0;
			}
			return result;
		}
		/// <summary>
		/// 验证输入值是否数字，失败返回0，成功则原样返回。
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string ToNumber(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return "0";
			}
			if (!Regex.IsMatch(input, "^[+-]?[0-9]+[.]?[0-9]*$"))
			{
				return "0";
			}
			return input;
		}
		/// <summary>
		/// 验证输入值是否为“,”分隔的数字，失败返回0，成功则原样返回。
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string ToValidId(string input)
		{
			if (!string.IsNullOrEmpty(input))
			{
				string[] strArray = input.Split(new char[] { ',' });
				string str = "";
				for (int i = 0; i < strArray.GetLength(0); i++)
				{
					if (DataValidator.IsNumberSign(strArray[i]))
					{
						str = str + strArray[i] + ",";
					}
				}
				if (str.Length > 0)
				{
					return str.Substring(0, str.Length - 1);
				}
			}
			return "0";
		}
		#endregion

		#region 从字符数组安全地取元素值
		/// <summary>
		/// 从字符数组安全地取元素值(检查数组为空和索引越界)
		/// </summary>
		/// <param name="index">数组元素的索引</param>
		/// <param name="field">字符数组</param>
		/// <returns>如果字符数组为空或索引越界则返回空字符串，否则返回数组中指定元素的值</returns>
		public static string GetArrayValue(int index, string[] field)
		{
			if ((field != null) && ((index >= 0) && (index < field.Length)))
			{
				return field[index];
			}
			return string.Empty;
		}
		/// <summary>
		/// 从字符集合安全地取元素值(检查集合索引越界)
		/// </summary>
		/// <param name="index">元素的索引</param>
		/// <param name="field">字符集合</param>
		/// <returns>如果索引越界则返回空字符串，否则返回数组中指定元素的值</returns>
		public static string GetArrayValue(int index, Collection<string> field)
		{
			if ((index >= 0) && (index < field.Count))
			{
				return field[index];
			}
			return string.Empty;
		}
		#endregion

		#region ＨＴＭＬ代码与文本代码的转换
		/// <summary>
		/// 将对象值中的ＨＴＭＬ代码转换成文本代码
		/// 例如：把HTML中的 换行符 转换成 文本文件中的 换行符
		/// </summary>
		/// <param name="value">要解码的对象值</param>
		/// <returns>解码字符串</returns>
		public static string HtmlDecode(object value)
		{
			if (value == null)
			{
				return null;
			}
			return HtmlDecode(value.ToString());
		}
		/// <summary>
		/// 将字符串中的ＨＴＭＬ代码转换成文本代码
		/// 例如：把HTML中的 换行符 转换成 文本文件中的 换行符
		/// </summary>
		/// <param name="value">要解码的对象值</param>
		/// <returns></returns>
		public static string HtmlDecode(string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				value = value.Replace("<br>", "\n");
				value = value.Replace("<br/>", "\n");
				value = value.Replace("<br />", "\n");
				value = value.Replace("&gt;", ">");
				value = value.Replace("&lt;", "<");
				value = value.Replace("&nbsp;", " ");
				value = value.Replace("&#39;", "'");
				value = value.Replace("&quot;", "\"");
			}
			return value;
		}
		/// <summary>
		/// 将对象值中的文本代码转换成ＨＴＭＬ代码
		/// 例如：把文本文件中的 换行符 转换成 HTML中的 换行符
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string HtmlEncode(object value)
		{
			if (value == null)
			{
				return null;
			}
			return HtmlEncode(value.ToString());
		}
		/// <summary>
		/// 将字符串中的文本代码转换成ＨＴＭＬ代码
		/// 例如：把文本文件中的 换行符 转换成 HTML中的 换行符
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string HtmlEncode(string str)
		{
			if (!string.IsNullOrEmpty(str))
			{
				str = str.Replace("<", "&lt;");
				str = str.Replace(">", "&gt;");
				str = str.Replace(" ", "&nbsp;");
				str = str.Replace("'", "&#39;");
				str = str.Replace("\"", "&quot;");
				str = str.Replace("\r\n", "<br />");
				str = str.Replace("\n", "<br />");
			}
			return str;
		}
		#endregion

		#region 生成文件与文件夹名称
		/// <summary>
		/// 用日期时间格式生成自动文件名（格式：yyyyMMddHHmmss+ ４位随机数）
		/// </summary>
		/// <returns>自动文件名字符串</returns>
		public static string MakeFileRndName()
		{
			return (DateTime.Now.ToString("yyyyMMddHHmmss", CultureInfo.CurrentCulture) + MakeRandomString("0123456789", 4));
		}
		/// <summary>
		/// 用日期时间格式生成自动文件夹名（格式：yyyyMM）
		/// </summary>
		/// <returns></returns>
		public static string MakeFolderName()
		{
			return DateTime.Now.ToString("yyyyMM", CultureInfo.CurrentCulture);
		}
		#endregion

		#region 生成随机字符串
		/// <summary>
		/// 生成一个指定长度的随机字符串a-Z0-9_*
		/// </summary>
		/// <param name="pwdlen">字符串长度</param>
		/// <returns>随机字符串</returns>
		public static string MakeRandomString(int pwdlen)
		{
			return MakeRandomString("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_*", pwdlen);
		}
		/// <summary>
		/// 从一个指定的字符串中取出指定长度的随机字符串
		/// </summary>
		/// <param name="pwdchars">用于抽取随机字符串的字符串</param>
		/// <param name="pwdlen">生成的随机字符串长度</param>
		/// <returns>随机字符串</returns>
		public static string MakeRandomString(string pwdchars, int pwdlen)
		{
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < pwdlen; i++)
			{
				int num = rnd.Next(pwdchars.Length);
				builder.Append(pwdchars[num]);
			}
			return builder.ToString();
		}
		/// <summary>
		/// 生成一个指定位数的随机数
		/// </summary>
		/// <param name="intlong">生成的随机数的位数</param>
		/// <returns>指定位数的随机数</returns>
		public static string RandomNum(int intlong)
		{
			StringBuilder builder = new StringBuilder(string.Empty);
			for (int i = 0; i < intlong; i++)
			{
				builder.Append(rnd.Next(10));
			}
			return builder.ToString();
		}
		#endregion

		#region 替换自定义标签字符
		/// <summary>
		/// 将字符串中的自定义标签字符转换为“{”和“}” 
		/// “ζ#123;”转换为“{”
		/// “ζ#125;”转换为“}”
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string JXLabelDecode(string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				value = value.Replace("ζ#123;", "{");
				value = value.Replace("ζ#125;", "}");
			}
			return value;
		}
		/// <summary>
		/// 将字符串中的自定义标签字符进行编码
		/// “{”转换为“ζ#123;”
		/// “}”转换为“ζ#125;”
		/// “ζ#123;JX.SiteConfig.uploaddir/ζ#125;”转换为“{JX.SiteConfig.uploaddir/}”
		/// “ζ#123;JX.SiteConfig.ApplicationPath/ζ#125;”转换为“{JX.SiteConfig.ApplicationPath/}”
		/// </summary>
		/// <param name="value">要编码的标签字符串</param>
		/// <returns></returns>
		public static string JXLabelEncode(string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				value = value.Replace("{", "ζ#123;");
				value = value.Replace("}", "ζ#125;");
				value = Regex.Replace(value, @"<!--([^>]*?#include[\s\S]*?)-->", "&lt;!--$1--&gt;", RegexOptions.Compiled | RegexOptions.IgnoreCase);
				value = value.Replace("ζ#123;JX.SiteConfig.uploaddir/ζ#125;", "{JX.SiteConfig.uploaddir/}");
				value = value.Replace("ζ#123;JX.SiteConfig.ApplicationPath/ζ#125;", "{JX.SiteConfig.ApplicationPath/}");
			}
			return value;
		}
		#endregion

		#region URL编码
		/// <summary>
		/// 对ＵＲＬ对象进行ＵＲＬ编码(将非字母和数字字符转为相应％号表示的形式)
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string UrlEncode(object value)
		{
			if (value == null)
			{
				return null;
			}
			return UrlEncode(value.ToString());
		}
		/// <summary>
		/// 对ＵＲＬ字符串进行ＵＲＬ编码(将非字母和数字字符转为相应％号表示的形式)
		/// </summary>
		/// <param name="weburl"></param>
		/// <returns></returns>
		public static string UrlEncode(string weburl)
		{
			if (string.IsNullOrEmpty(weburl))
			{
				return null;
			}
			return Regex.Replace(weburl, @"[^a-zA-Z0-9,-_\.]+", new MatchEvaluator(DataSecurity.UrlEncodeMatch));
		}
		/// <summary>
		/// 对ＵＲＬ字符串进行ＵＲＬ编码
		/// </summary>
		/// <param name="weburl">要编码的ＵＲＬ</param>
		/// <param name="systemEncode">
		/// 是否启用系统内置的编码方式。
		/// 是：使用WebUtility.UrlEncode；
		/// 否：使用DataSecurity.UrlEncode</param>
		/// <returns></returns>
		public static string UrlEncode(string weburl, bool systemEncode)
		{
			if (string.IsNullOrEmpty(weburl))
			{
				return null;
			}
			if (systemEncode)
			{
				return WebUtility.UrlEncode(weburl);
			}
			return UrlEncode(weburl);
		}
		private static string UrlEncodeMatch(Match match)
		{
			string str = match.ToString();
			if (str.Length < 1)
			{
				return str;
			}
			StringBuilder builder = new StringBuilder();
			foreach (char ch in str)
			{
				if (ch > '\x007f')
				{
					builder.AppendFormat("%u{0:X4}", (int)ch);
				}
				else
				{
					builder.AppendFormat("%{0:X2}", (int)ch);
				}
			}
			return builder.ToString();
		}
		#endregion

		/// <summary>
		/// XML标记编码：将文本字符转换为xml代码格式
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string XmlEncode(string str)
		{
			if (!string.IsNullOrEmpty(str))
			{
				str = str.Replace("&", "&amp;");
				str = str.Replace("<", "&lt;");
				str = str.Replace(">", "&gt;");
				str = str.Replace("'", "&apos;");
				str = str.Replace("\"", "&quot;");
			}
			return str;
		}
	}
}
