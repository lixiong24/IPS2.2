using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 字符串辅助类
	/// </summary>
	public static class StringHelper
    {
		#region 字符串处理
		/// <summary>
		/// 得到以分隔符串联的字符串
		/// </summary>
		/// <param name="separator">分隔符</param>
		/// <param name="keys"></param>
		/// <returns></returns>
		public static string Join(string separator, string[] keys)
		{
			if (keys.Length <= 0) return "";

			StringBuilder sb = new StringBuilder();
			foreach (string key in keys)
			{
				sb.Append(key + separator);
			}
			if (sb.Length > 0)
			{
				sb.Remove(sb.Length - 1, 1);
			}
			return sb.ToString();
		}

		/// <summary>
		/// 向字符串生成对象添加字符串(并添加,分隔字符),用于生成以,分隔的字符串
		/// </summary>
		/// <param name="sb">字符串生成对象</param>
		/// <param name="append">要向sb对象添加的字符串</param>
		public static void AppendString(StringBuilder sb, string append)
		{
			AppendString(sb, append, ",");
		}
		/// <summary>
		/// 向字符串生成对象添加字符串(并添加指定的分隔字符)
		/// </summary>
		/// <param name="sb">字符串生成对象</param>
		/// <param name="append">要向sb对象添加的字符串</param>
		/// <param name="split">分隔符</param>
		public static void AppendString(StringBuilder sb, string append, string split)
		{
			if (sb.Length == 0)
			{
				sb.Append(append);
			}
			else
			{
				sb.Append(split);
				sb.Append(append);
			}
		}

		/// <summary>
		/// 将字符串中指定字符替换为新字符，并将源字符中所有重复字符替换为一个指定的新字符
		/// </summary>
		/// <param name="source">要替换的源字符串</param>
		/// <param name="replace">要查找的字符</param>
		/// <param name="newchar">要替换的新字符</param>
		/// <returns></returns>
		public static string ReplaceDoubleChar(string source, char replace, char newchar)
		{
			StringBuilder builder = new StringBuilder();
			if (string.IsNullOrEmpty(source))
			{
				return builder.ToString();
			}
			source = source.Trim();
			if (source.Contains(replace.ToString()))
			{
				for (int i = 0; i < source.Length; i++)
				{
					if (source[i] == replace)
					{
						if (i < (source.Length - 1))
						{
							if (source[i] != source[i + 1])
							{
								builder.Append(newchar);
							}
						}
						else
						{
							builder.Append(newchar);
						}
					}
					else
					{
						builder.Append(source[i]);
					}
				}
			}
			else
			{
				builder.Append(source);
			}
			return builder.ToString().Trim();
		}
		/// <summary>
		/// 替换字符串，替换时忽略大小写
		/// </summary>
		/// <param name="input">要替换的源字符串</param>
		/// <param name="oldValue">要查找的字符串</param>
		/// <param name="newValue">要替换的新字符串</param>
		/// <returns></returns>
		public static string ReplaceIgnoreCase(string input, string oldValue, string newValue)
		{
			return input.ToLower().Replace(oldValue.ToLower(), newValue.ToLower());
		}

		/// <summary>
		/// 从一个字符串中截取部分字符与另一字符串拼接成一个指定长度的字符串(一个汉字算两个字符)
		/// </summary>
		/// <param name="demand">源字符串</param>
		/// <param name="length">要截取的长度</param>
		/// <param name="substitute">要拼接的字符串</param>
		/// <returns></returns>
		public static string SubString(string demand, int length, string substitute)
		{
			demand = DataSecurity.HtmlDecode(demand);
			if (Encoding.UTF8.GetBytes(demand).Length <= length)
			{
				return demand;
			}
			ASCIIEncoding encoding = new ASCIIEncoding();
			length -= Encoding.UTF8.GetBytes(substitute).Length;
			int num = 0;
			StringBuilder builder = new StringBuilder();
			byte[] bytes = encoding.GetBytes(demand);
			for (int i = 0; i < bytes.Length; i++)
			{
				if (bytes[i] == 63)
				{
					num += 2;
				}
				else
				{
					num++;
				}
				if (num > length)
				{
					break;
				}
				builder.Append(demand.Substring(i, 1));
			}
			builder.Append(substitute);
			return builder.ToString();
		}
		/// <summary>
		/// 计算字符串中的字符数(一个汉字算两个字符)
		/// </summary>
		/// <param name="demand">源字符串</param>
		/// <returns></returns>
		public static int SubStringLength(string demand)
		{
			if (string.IsNullOrEmpty(demand))
			{
				return 0;
			}
			ASCIIEncoding encoding = new ASCIIEncoding();
			int num = 0;
			byte[] bytes = encoding.GetBytes(demand);
			for (int i = 0; i < bytes.Length; i++)
			{
				if (bytes[i] == 0x3f)
				{
					num += 2;
				}
				else
				{
					num++;
				}
			}
			return num;
		}

		/// <summary>
		/// 安全去除字符串中的空格字符(检查字符串为空的情况)
		/// </summary>
		/// <param name="returnStr"></param>
		/// <returns></returns>
		public static string Trim(string returnStr)
		{
			if (!string.IsNullOrEmpty(returnStr))
			{
				return returnStr.Trim();
			}
			return string.Empty;
		}

		/// <summary>
		/// 从字符串数组中查找是否包括"(,指定字符,)"
		/// </summary>
		/// <param name="checkStr">指定要查找的字符</param>
		/// <param name="findStr">要从中查找的字符</param>
		/// <returns></returns>
		public static bool FoundCharInArr(string checkStr, string findStr)
		{
			return FoundCharInArr(checkStr, findStr, ",");
		}
		/// <summary>
		/// 从字符串数组中查找是否包括"(指定分隔符+指定字符+指定分隔符)"
		/// </summary>
		/// <param name="checkStr">指定要查找的字符</param>
		/// <param name="findStr">要从中查找的字符</param>
		/// <param name="split">分隔符</param>
		/// <returns></returns>
		public static bool FoundCharInArr(string checkStr, string findStr, string split)
		{
			bool flag = false;
			if (string.IsNullOrEmpty(split))
			{
				split = ",";
			}
			if (!string.IsNullOrEmpty(checkStr))
			{
				if (string.IsNullOrEmpty(checkStr))
				{
					return flag;
				}
				checkStr = split + checkStr + split;
				if (findStr.IndexOf(split, StringComparison.Ordinal) != -1)
				{
					string[] strArray = findStr.Split(new char[] { Convert.ToChar(split, CultureInfo.CurrentCulture) });
					for (int i = 0; i < strArray.Length; i++)
					{
						if (checkStr.Contains(split + strArray[i] + split))
						{
							return true;
						}
					}
					return flag;
				}
				if (checkStr.Contains(split + findStr + split))
				{
					flag = true;
				}
			}
			return flag;
		}

		/// <summary>
		/// 替换字符串中的回车与换行为新字符串
		/// </summary>
		/// <param name="input"></param>
		/// <param name="newValue"></param>
		/// <returns></returns>
		public static string ReplaceEnterNewline(string input, string newValue="<br/>")
		{
			return input.Replace("\r\n", newValue).Replace("\n\r", newValue).Replace("\n", newValue).Replace("\r", newValue);
		}
		#endregion

		#region 对字符串数组的操作

		/// <summary>
		/// 移出数组中重复的项并返回新数组
		/// </summary>
		/// <param name="sourceArray">源数组</param>
		/// <returns></returns>
		public static string[] RemoveRepeatItem(string[] sourceArray)
		{
			List<string> list = new List<string>();
			//遍历数组成员
			foreach (string value in sourceArray)
			{
				//对每个成员做一次新数组查询如果没有相等的则加到新数组
				if (!list.Contains(value))
				{
					list.Add(value);
				}
			}
			return list.ToArray();
		}

		/// <summary>
		/// 获取数组元素的合并字符串,成功返回合并后的字符串，失败返回空。
		/// </summary>
		/// <param name="stringArray">源数组</param>
		/// <returns></returns>
		public static string GetArrayString(string[] stringArray)
		{
			string totalString = "";
			for (int i = 0; i < stringArray.Length; i++)
			{
				totalString = totalString + stringArray[i];
			}
			return totalString;
		}
		/// <summary>
		/// 获取数组元素用指定分隔符连接的合并字符串,成功返回合并后的字符串，失败返回空。
		/// </summary>
		/// <param name="stringArray">源数组</param>
		/// <param name="separator">分隔符</param>
		/// <returns></returns>
		public static string GetArrayString(string[] stringArray, string separator)
		{
			if (stringArray.Length <= 0) return "";

			StringBuilder sb = new StringBuilder();
			foreach (string key in stringArray)
			{
				sb.Append(key + separator);
			}
			if (sb.Length > 0)
			{
				sb.Remove(sb.Length - 1, 1);
			}
			return sb.ToString();
		}
		/// <summary>
		/// 获取数组元素用指定分隔符连接的合并字符串,成功返回合并后的字符串，失败返回空。
		/// </summary>
		/// <param name="stringArray">源数组</param>
		/// <param name="separator">分隔符</param>
		/// <param name="leftModifier">左修饰符</param>
		/// <param name="rightModifier">右修饰符</param>
		/// <returns></returns>
		public static string GetArrayString(string[] stringArray, string separator, string leftModifier, string rightModifier)
		{
			if (stringArray.Length <= 0) return "";

			StringBuilder sb = new StringBuilder();
			foreach (string key in stringArray)
			{
				sb.Append(leftModifier).Append(key).Append(rightModifier).Append(separator);
			}
			if (sb.Length > 0)
			{
				sb.Remove(sb.Length - 1, 1);
			}
			return sb.ToString();
		}
		/// <summary>
		/// 获取指定开始与结束索引的数组元素，用指定分隔符连接的合并字符串,成功返回合并后的字符串，失败返回空。
		/// </summary>
		/// <param name="beginIndex"></param>
		/// <param name="endIndex"></param>
		/// <param name="stringArray"></param>
		/// <param name="separator"></param>
		/// <param name="leftModifier"></param>
		/// <param name="rightModifier"></param>
		/// <returns></returns>
		public static string GetArrayString(int beginIndex, int endIndex, string[] stringArray, string separator = ",", string leftModifier = "", string rightModifier = "")
		{
			if (stringArray.Length <= 0) return "";

			StringBuilder sb = new StringBuilder();
			for (int i = beginIndex; i < endIndex + 1; i++)
			{
				sb.Append(leftModifier).Append(stringArray[i]).Append(rightModifier).Append(separator);
			}
			if (sb.Length > 0)
			{
				sb.Remove(sb.Length - 1, 1);
			}
			return sb.ToString();
		}

		/// <summary>
		/// 确定某字符串是否在数组中
		/// </summary>
		/// <param name="sourceArray">源数组</param>
		/// <param name="targetString">目标字符串</param>
		/// <returns></returns>
		public static bool Contains(string[] sourceArray, string targetString)
		{
			bool b = false;
			//遍历数组成员
			foreach (string value in sourceArray)
			{
				if (value.ToLower() == targetString.ToLower())
				{
					b = true;
					break;
				}
			}
			return b;
		}

		/// <summary>
		/// 获取某一字符串在字符串中出现的次数。
		/// </summary>
		/// <param name="sourceString">源字符串</param>
		/// <param name="findString">要找的字符串</param>
		/// <returns>匹配字符串数量</returns>
		public static int GetStringCount(string sourceString, string findString)
		{
			int count = 0;
			int findStringLength = findString.Length;
			string subString = sourceString;

			while (subString.IndexOf(findString) >= 0)
			{
				subString = subString.Substring(subString.IndexOf(findString) + findStringLength);
				count++;
			}
			return count;
		}

		/// <summary>
		/// 获取某一字符串在字符串数组中出现的次数。
		/// </summary>
		/// <param name="stringArray">字符串数组</param>
		/// <param name="findString">要找的字符串</param>
		/// <returns>匹配字符串数量</returns>
		public static int GetStringCount(string[] stringArray, string findString)
		{
			int count = 0;
			string totalString = GetArrayString(stringArray);
			string subString = totalString;

			while (subString.IndexOf(findString) >= 0)
			{
				subString = totalString.Substring(subString.IndexOf(findString));
				count++;
			}
			return count;
		}
		#endregion

		#region 编码转换
		/// <summary>
		/// 将字符串转换为UTF8字符
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string Base64StringDecode(string input)
		{
			byte[] bytes = Convert.FromBase64String(input);
			return Encoding.UTF8.GetString(bytes);
		}
		/// <summary>
		/// 将字符串从UTF8转换为普通字符
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string Base64StringEncode(string input)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
		}
		#endregion

		#region 字符串加密
		/// <summary>
		/// 得到输入字符串哈希值的长度
		/// </summary>
		/// <param name="input"></param>
		/// <param name="options"></param>
		/// <returns></returns>
		public static decimal GetHashKey(string input, StringFilterOptions options)
		{
			ulong num;
			if (string.IsNullOrEmpty(input))
			{
				return 0M;
			}
			input = FilterInvalidChar(input, options);
			var data = Encoding.UTF8.GetBytes(input);
			var encryData = Md5.Encrypt(data);
			num = BitConverter.ToUInt64(encryData,4);
			return DataConverter.CDecimal(num);
		}
		/// <summary>
		/// 得到输入字符串哈希值的长度
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static double GetStringHashKey(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return 0.0;
			}
			input = FilterInvalidChar(input, StringFilterOptions.SBCToDBC | StringFilterOptions.HoldChinese | StringFilterOptions.HoldLetter);
			string s = MD5(input).Substring(8, 16);
			return BitConverter.ToDouble(Encoding.UTF8.GetBytes(s), 0);
		}

		/// <summary>
		/// 对输入的字符串进行MD5加密
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string MD5(string input)
		{
			return Md5.EncryptHexString(input);
		}
		/// <summary>
		/// 得到以数字9开头，长度在9位以内的数字
		/// 1、对输入的字符串进行MD5加密
		/// 2、长度大于等于9位时，返回"9" + input.Substring(1, 8)
		/// 3、长度小于9位时，返回"9" + input
		/// </summary>
		/// <param name="strText"></param>
		/// <returns></returns>
		public static int MD5D(string strText)
		{
			var data = Encoding.UTF8.GetBytes(strText);
			var encryData = Md5.Encrypt(data);
			StringBuilder builder = new StringBuilder();
			foreach (byte num in encryData)
			{
				builder.Append(num.ToString("D", CultureInfo.CurrentCulture).ToLower());
			}
			string input = builder.ToString();
			if (input.Length >= 9)
			{
				input = "9" + input.Substring(1, 8);
			}
			else
			{
				input = "9" + input;
			}
			return DataConverter.CLng(input);
		}
		/// <summary>
		/// 对输入的字符串进行gb2312编码后在用MD5加密
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string MD5GB2312(string input)
		{
			return Md5.EncryptHexString(input, Encoding.GetEncoding("gb2312"));
		}

		/// <summary>
		/// 对输入的字符串进行Sha1加密
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string SHA1(string input)
		{
			return Sha1.Encrypt(input);
		}

		/// <summary>
		/// 比较两个经过ＭＤ５加密后输入的字符串是否相等
		/// </summary>
		/// <param name="password"></param>
		/// <param name="encryptedValue"></param>
		/// <returns></returns>
		public static bool ValidateMD5(string password, string encryptedValue)
		{
			if (string.Compare(password, encryptedValue, StringComparison.Ordinal) != 0)
			{
				return (string.Compare(password, encryptedValue.Substring(8, 16), StringComparison.Ordinal) == 0);
			}
			return true;
		}
		#endregion

		#region 拷贝字符串,生成 "xxx－复制(1) 样式" 的字符串
		/// <summary>
		/// 拷贝字符串,生成 "xxx－复制(1) 样式" 的字符串,用于生成模板标签名称
		/// </summary>
		/// <param name="returnStr">要拷贝的字符串</param>
		/// <returns>返回"returnStr－复制" ,如果字符串已经包含"－复制"则返回"returnStr－复制(2)"等 </returns>
		public static string CopyString(string returnStr)
		{
			if (returnStr.Contains("－复制"))
			{
				if (returnStr.Contains("－复制("))
				{
					Regex regex = new Regex(@"^.*[/－]复制[/(](\d)+[/)]$");
					if (regex.IsMatch(returnStr))
					{
						return (CopyStringNum(returnStr.Remove(returnStr.Length - 1)) + ")");
					}
					return (returnStr + "－复制");
				}
				return (returnStr + "(2)");
			}
			return (returnStr + "－复制");
		}
		/// <summary>
		/// 与 CopyString 函数一起使用生成 "xxx－复制(1) 样式" 的字符串
		/// </summary>
		/// <param name="returnStr"></param>
		/// <returns></returns>
		public static string CopyStringNum(string returnStr)
		{
			int length = 0;
			foreach (char ch in returnStr)
			{
				if (char.IsDigit(ch))
				{
					length++;
				}
				else
				{
					length = 0;
				}
			}
			if (length == 0)
			{
				return (returnStr + "1");
			}
			int num2 = DataConverter.CLng(returnStr.Substring(returnStr.Length - length, length)) + 1;
			return (returnStr.Remove(returnStr.Length - length, length) + num2.ToString(CultureInfo.CurrentCulture));
		}
		#endregion

		#region 中文处理
		/// <summary>
		/// 私有方法，获取中文字符对应首字母
		/// </summary>
		/// <param name="ch"></param>
		/// <returns></returns>
		private static string GetGbkX(char ch)
		{
			string strA = ch.ToString();
			if (string.Compare(strA, "吖", StringComparison.CurrentCulture) < 0) return strA;
			if (string.Compare(strA, "八", StringComparison.CurrentCulture) < 0) return "A";
			if (string.Compare(strA, "嚓", StringComparison.CurrentCulture) < 0) return "B";
			if (string.Compare(strA, "咑", StringComparison.CurrentCulture) < 0) return "C";
			if (string.Compare(strA, "妸", StringComparison.CurrentCulture) < 0) return "D";
			if (string.Compare(strA, "发", StringComparison.CurrentCulture) < 0) return "E";
			if (string.Compare(strA, "旮", StringComparison.CurrentCulture) < 0) return "F";
			if (string.Compare(strA, "铪", StringComparison.CurrentCulture) < 0) return "G";
			if (string.Compare(strA, "讥", StringComparison.CurrentCulture) < 0) return "H";
			if (string.Compare(strA, "咔", StringComparison.CurrentCulture) < 0) return "J";
			if (string.Compare(strA, "垃", StringComparison.CurrentCulture) < 0) return "K";
			if (string.Compare(strA, "嘸", StringComparison.CurrentCulture) < 0) return "L";
			if (string.Compare(strA, "拏", StringComparison.CurrentCulture) < 0) return "M";
			if (string.Compare(strA, "噢", StringComparison.CurrentCulture) < 0) return "N";
			if (string.Compare(strA, "妑", StringComparison.CurrentCulture) < 0) return "O";
			if (string.Compare(strA, "七", StringComparison.CurrentCulture) < 0) return "P";
			if (string.Compare(strA, "亽", StringComparison.CurrentCulture) < 0) return "Q";
			if (string.Compare(strA, "仨", StringComparison.CurrentCulture) < 0) return "R";
			if (string.Compare(strA, "他", StringComparison.CurrentCulture) < 0) return "S";
			if (string.Compare(strA, "哇", StringComparison.CurrentCulture) < 0) return "T";
			if (string.Compare(strA, "夕", StringComparison.CurrentCulture) < 0) return "W";
			if (string.Compare(strA, "丫", StringComparison.CurrentCulture) < 0) return "X";
			if (string.Compare(strA, "帀", StringComparison.CurrentCulture) < 0) return "Y";
			if (string.Compare(strA, "咗", StringComparison.CurrentCulture) < 0) return "Z";
			return strA.ToString();
		}
		/// <summary>
		/// 获取中文字符串拼音首字母，英文字母原样返回
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string GetInitial(string str)
		{
			str = FilterInvalidChar(str, StringFilterOptions.SBCToDBC | StringFilterOptions.HoldChinese | StringFilterOptions.HoldLetter | StringFilterOptions.HoldNumber);
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < str.Length; i++)
			{
				int num2 = str[i];
				if (num2 < 123)
				{
					builder.Append(str[i]);
				}
				else
				{
					builder.Append(GetGbkX(str[i]));
				}
			}
			return builder.ToString();
		}
		/// <summary>
		/// 判断字符串中是否含有中文字符
		/// </summary>
		/// <param name="inputData">输入字符串</param>
		/// <returns></returns>
		public static bool IsIncludeChinese(string inputData)
		{
			Regex regex = new Regex("[一-龥]");
			return regex.Match(inputData).Success;
		}
		#endregion

		#region 采集处理公用函数
		/// <summary>
		/// (用于数据采集)过滤字符串中的指定html标记
		/// </summary>
		/// <param name="conStr">要过滤的字符串内容</param>
		/// <param name="tagName">要过滤的HTML标签名称</param>
		/// <param name="filterType">过滤HTML标签的方式:1:单独标签 2:标签及其内的所有内容 3:标签的开始和结束标签(即不去除标签内容)</param>
		/// <returns>过滤后的字符串</returns>
		public static string CollectionFilter(string conStr, string tagName, int filterType)
		{
			string input = conStr;
			switch (filterType)
			{
				case 1:
					return Regex.Replace(input, "<" + tagName + "([^>])*>", string.Empty, RegexOptions.IgnoreCase);

				case 2:
					return Regex.Replace(input, "<" + tagName + "([^>])*>.*?</" + tagName + "([^>])*>", string.Empty, RegexOptions.IgnoreCase);

				case 3:
					return Regex.Replace(Regex.Replace(input, "<" + tagName + "([^>])*>", string.Empty, RegexOptions.IgnoreCase), "</" + tagName + "([^>])*>", string.Empty, RegexOptions.IgnoreCase);
			}
			return input;
		}

		/// <summary>
		/// (用于采集)过滤HTML中的部分标签
		/// </summary>
		/// <param name="conStr">要过滤的字符串内容</param>
		/// <param name="filterItem">要过滤的标签集(,分隔)如:Iframe,Object,Script,Style,Div,Span,Table,Img,Font,A,Html</param>
		/// <returns></returns>
		public static string FilterScript(string conStr, string filterItem)
		{
			string str = conStr.Replace("\r", "{$Chr13}").Replace("\n", "{$Chr10}");
			foreach (string str2 in filterItem.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				switch (str2)
				{
					case "Iframe": str = CollectionFilter(str, str2, 2); break;
					case "Object": str = CollectionFilter(str, str2, 2); break;
					case "Script": str = CollectionFilter(str, str2, 2); break;
					case "Style": str = CollectionFilter(str, str2, 2); break;
					case "Div": str = CollectionFilter(str, str2, 3); break;
					case "Span": str = CollectionFilter(str, str2, 3); break;
					case "Table": str = CollectionFilter(CollectionFilter(CollectionFilter(CollectionFilter(CollectionFilter(str, str2, 3), "Tbody", 3), "Tr", 3), "Td", 3), "Th", 3); break;
					case "Img": str = CollectionFilter(str, str2, 1); break;
					case "Font": str = CollectionFilter(str, str2, 3); break;
					case "A": str = CollectionFilter(str, str2, 3); break;
					case "Html":
						str = StripTags(str);
						if (!string.IsNullOrEmpty(str))
						{
							str = str.Replace("{$Chr13}", string.Empty).Replace("{$Chr10}", string.Empty).Trim();
						}
						goto Label_022D;
				}
			}
			Label_022D:
			return str.Replace("{$Chr13}", "\r").Replace("{$Chr10}", "\n");
		}

		/// <summary>
		/// 删除html内容中的所有非法脚本及对象标签
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string RemoveXss(string input)
		{
			string str;
			string str2;
			do
			{
				str = input;
				input = Regex.Replace(input, @"(&#*\w+)[\x00-\x20]+;", "$1;");
				input = Regex.Replace(input, "(&#x*[0-9A-F]+);*", "$1;", RegexOptions.IgnoreCase);
				input = Regex.Replace(input, "&(amp|lt|gt|nbsp|quot);", "&amp;$1;");
				input = WebUtility.HtmlDecode(input);
			}
			while (str != input);
			input = Regex.Replace(input, "(?<=(<[\\s\\S]*=\\s*\"[^\"]*))>(?=([^\"]*\"[\\s\\S]*>))", "&gt;", RegexOptions.IgnoreCase);
			input = Regex.Replace(input, @"(?<=(<[\s\S]*=\s*'[^']*))>(?=([^']*'[\s\S]*>))", "&gt;", RegexOptions.IgnoreCase);
			input = Regex.Replace(input, @"(?<=(<[\s\S]*=\s*`[^`]*))>(?=([^`]*`[\s\S]*>))", "&gt;", RegexOptions.IgnoreCase);
			do
			{
				str = input;
				input = Regex.Replace(input, @"(<[^>]+?style[\x00-\x20]*=[\x00-\x20]*[^>]*?)\\([^>]*>)", "$1/$2", RegexOptions.IgnoreCase);
			}
			while (str != input);
			input = Regex.Replace(input, @"[\x00-\x08\x0b-\x0c\x0e-\x19]", string.Empty);
			input = Regex.Replace(input, "(<[^>]+?[\\x00-\\x20\"'/])(on|xmlns)[^>]*>", "$1>", RegexOptions.IgnoreCase);
			input = Regex.Replace(input, "([a-z]*)[\\x00-\\x20]*=[\\x00-\\x20]*([`'\"]*)[\\x00-\\x20]*j[\\x00-\\x20]*a[\\x00-\\x20]*v[\\x00-\\x20]*a[\\x00-\\x20]*s[\\x00-\\x20]*c[\\x00-\\x20]*r[\\x00-\\x20]*i[\\x00-\\x20]*p[\\x00-\\x20]*t[\\x00-\\x20]*:", "$1=$2nojavascript...", RegexOptions.IgnoreCase);
			input = Regex.Replace(input, "([a-z]*)[\\x00-\\x20]*=[\\x00-\\x20]*([`'\"]*)[\\x00-\\x20]*v[\\x00-\\x20]*b[\\x00-\\x20]*s[\\x00-\\x20]*c[\\x00-\\x20]*r[\\x00-\\x20]*i[\\x00-\\x20]*p[\\x00-\\x20]*t[\\x00-\\x20]*:", "$1=$2novbscript...", RegexOptions.IgnoreCase);
			input = Regex.Replace(input, @"(<[^>]+style[\x00-\x20]*=[\x00-\x20]*[^>]*?)/\*[^>]*\*/([^>]*>)", "$1$2", RegexOptions.IgnoreCase);
			input = Regex.Replace(input, "(<[^>]+?)style[\\x00-\\x20]*=[\\x00-\\x20]*([`'\"]*).*?[eｅＥ][xｘＸ][pｐＰ][rｒＲ][eｅＥ][sｓＳ][sｓＳ][iｉＩ][oｏＯ][nｎＮ][\\x00-\\x20]*[\\(\\（][^>]*>", "$1>", RegexOptions.IgnoreCase);
			input = Regex.Replace(input, "(<[^>]+?)style[\\x00-\\x20]*=[\\x00-\\x20]*([`'\"]*).*?behaviour[^>]*>", "$1>", RegexOptions.IgnoreCase);
			input = Regex.Replace(input, "(<[^>]+?)style[\\x00-\\x20]*=[\\x00-\\x20]*([`'\"]*).*?behavior[^>]*>", "$1>", RegexOptions.IgnoreCase);
			input = Regex.Replace(input, "(<[^>]+?)style[\\x00-\\x20]*=[\\x00-\\x20]*([`'\"]*).*?s[\\x00-\\x20]*c[\\x00-\\x20]*r[\\x00-\\x20]*i[\\x00-\\x20]*p[\\x00-\\x20]*t[\\x00-\\x20]*:*[^>]*>", "$1>", RegexOptions.IgnoreCase);
			input = Regex.Replace(input, @"</*\w+:\w[^>]*>", "　");
			do
			{
				str2 = input;
				input = Regex.Replace(input, "</*(applet|meta|xml|blink|link|style|script|embed|object|iframe|frame|frameset|ilayer|layer|bgsound|title|base)[^>]*>?", "　", RegexOptions.IgnoreCase);
			}
			while (str2 != input);
			input = Regex.Replace(input, @"<!--([\s\S]*?)-->", "&lt;!--$1--&gt;");
			input = input.Replace("<!--", "&lt;!--");
			return input;
		}

		/// <summary>
		/// 去除字符串中的所有HTML标签
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string StripTags(string input)
		{
			Regex regex = new Regex("<([^<]|\n)+?>");
			return regex.Replace(input, string.Empty);
		}
		#endregion

		/// <summary>
		/// 用于StringHelper类从字符串中挑选符合条件的数字、字母、中文、全角字符, 选项可以叠加使用，如  StringFilterOptions.HoldLetter|StringFilterOptions.HoldNumber 表示从字符串中选取字母和数字
		/// </summary>
		/// <param name="str"></param>
		/// <param name="options"></param>
		/// <returns></returns>
		public static string FilterInvalidChar(string str, StringFilterOptions options)
		{
			if (string.IsNullOrEmpty(str))
			{
				return string.Empty;
			}
			StringBuilder builder = new StringBuilder(str.Length);
			for (int i = 0; i < str.Length; i++)
			{
				int num2 = str[i];
				if (((num2 >= 0x30) && (num2 <= 0x39)) && ((StringFilterOptions.HoldNumber & options) == StringFilterOptions.HoldNumber))
				{
					builder.Append(str[i]);
				}
				else if ((((num2 >= 0x41) && (num2 <= 90)) || ((num2 >= 0x61) && (num2 <= 0x7a))) && ((StringFilterOptions.HoldLetter & options) == StringFilterOptions.HoldLetter))
				{
					builder.Append(str[i]);
				}
				else if (((num2 >= 0x4e00) && (num2 <= 0x9fa5)) && ((StringFilterOptions.HoldChinese & options) == StringFilterOptions.HoldChinese))
				{
					builder.Append(str[i]);
				}
				else if (((((num2 >= 0xff10) && (num2 <= 0xff19)) || ((num2 >= 0xff21) && (num2 <= 0xff3a))) || ((num2 >= 0xff41) && (num2 <= 0xff5a))) && ((StringFilterOptions.SBCToDBC & options) == StringFilterOptions.SBCToDBC))
				{
					builder.Append((char)(num2 - 0xfee0));
				}
			}
			return builder.ToString();
		}
	}
}
