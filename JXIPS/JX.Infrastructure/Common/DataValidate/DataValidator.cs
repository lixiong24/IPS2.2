using System;
using System.Text.RegularExpressions;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 数据验证类:验证字符串是否合法的数字,IP,邮编,URL,EMAIL,城市区域
	/// </summary>
	public class DataValidator
    {
		/// <summary>
		/// 判断输入字符串是否为手机号码（11位数字）
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static bool IsMobile(string input)
		{
			return (IsNumber(input) && (input.Length == 11));
		}
		/// <summary>
		/// 判断输入字符串是否为身份证格式
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static bool IsIDCard(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return false;
			}
			return Regex.IsMatch(input, @"^\d{17}[\d|X]|\d{15}$");
		}
		/// <summary>
		/// 判断指定字符是否地区代码
		/// </summary>
		/// <param name="input">字符串</param>
		/// <returns>如果输入字符串是数字并且长度在3-5之内返回真,否则返回FALSE</returns>
		public static bool IsAreaCode(string input)
		{
			return ((IsNumber(input) && (input.Length >= 3)) && (input.Length <= 5));
		}
		/// <summary>
		/// 判断输入的字符串是否为Decimal数字(不带符号)
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static bool IsDecimal(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return false;
			}
			return Regex.IsMatch(input, @"^[0-9]+(\.[0-9]+)?$");
		}
		/// <summary>
		/// 判断输入的字符串是否为Decimal数字(带符号)
		/// </summary>
		/// <param name="input">输入字符串</param>
		/// <returns>bool值</returns>
		public static bool IsDecimalSign(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return false;
			}
			return Regex.IsMatch(input, @"^[+-]?[0-9]+(\.[0-9]+)?$");
		}
		/// <summary>
		/// 判断输入字符串是否为邮箱格式
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static bool IsEmail(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return false;
			}
			return Regex.IsMatch(input, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
		}
		/// <summary>
		/// 判断输入字符串是否为IP
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static bool IsIP(string input)
		{
			return (!string.IsNullOrEmpty(input) && Regex.IsMatch(input.Trim(), @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$"));
		}
		/// <summary>
		/// 判断输入字符串是否为整数
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static bool IsNumber(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return false;
			}
			return Regex.IsMatch(input, "^[0-9]+$");
		}
		/// <summary>
		/// 判断输入字符串是否为带符号整数
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static bool IsNumberSign(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return false;
			}
			return Regex.IsMatch(input, "^[+-]?[0-9]+$");
		}
		/// <summary>
		/// 判断输入字符串是否为邮编
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static bool IsPostCode(string input)
		{
			return (IsNumber(input) && (input.Length == 6));
		}
		/// <summary>
		/// 判断输入字符串是否为合法URL:http(s)://xxx.xxx.xxx
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static bool IsUrl(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return false;
			}
			return Regex.IsMatch(input, @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&;=]*)?$", RegexOptions.IgnoreCase);
		}
		/// <summary>
		/// 判断输入字符串是否有效的数字ID
		/// </summary>
		/// <param name="input">字符串</param>
		/// <returns>如果输入字符串去除| ,- 或空格后是数字则返回真,否则返回FALSE</returns>
		public static bool IsValidId(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return false;
			}
			input = input.Replace("|", string.Empty).Replace(",", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty).Trim();
			if (string.IsNullOrEmpty(input))
			{
				return false;
			}
			return IsNumber(input);
		}
		/// <summary>
		/// 判断输入字符串是否有效的用户名
		/// </summary>
		/// <param name="userName">字符串</param>
		/// <returns>如果字符串中不包含\\/\"[]:|〈〉+=;,?*@等字符,且长度小于20,且不是一个.字符则返回true,否则返回false</returns>
		public static bool IsValidUserName(string userName)
		{
			if (string.IsNullOrEmpty(userName))
			{
				return false;
			}
			if (userName.Length > 20)
			{
				return false;
			}
			if (userName.Trim().Length == 0)
			{
				return false;
			}
			if (userName.Trim(new char[] { '.' }).Length == 0)
			{
				return false;
			}
			string str = "\\/\"[]:|<>+=;,?*@";
			for (int i = 0; i < userName.Length; i++)
			{
				if (str.IndexOf(userName[i]) >= 0)
				{
					return false;
				}
			}
			return true;
		}
		/// <summary>
		/// 判断指定值是否为null,DBNull,DateTime.MinValue,0,空字符串
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		public static bool IsNull(object val)
		{
			if (val == null || val.Equals(DateTime.MinValue) || val.Equals(0) || val.Equals(0.00M) || string.IsNullOrEmpty(val.ToString()))
			{
				return true;
			}
			return false;
		}
	}
}
