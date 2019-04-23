using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 正则表达式帮助类
	/// </summary>
	public class RegexHelper
	{
		#region 常用正则表达式
		/// <summary>
		/// 身份证正则表达式
		/// </summary>
		public const string IdCardPattern = @"^\d{17}[\d|X]|\d{15}$";
		/// <summary>
		/// 11位手机号正则表达式
		/// </summary>
		public const string MobilePattern = @"^1\d{10}$";
		/// <summary>
		/// email正则表达式
		/// </summary>
		public const string EmailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
		/// <summary>
		/// url正则表达式
		/// </summary>
		public const string UrlPattern = @"^http(s)?://([\w-]+\.)+[\w-]+(:\d{1,5})?(/[\w- ./?%&=]*)?$";
		/// <summary>
		/// IP正则表达式
		/// </summary>
		public const string IpPattern = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";
		/// <summary>
		/// 日期正则表达式
		/// </summary>
		public const string DatePattern = @"^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2][0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))(\s((([01]?[0-9])|([2][0-3]))\:([0-5]?[0-9])((\s)|(\:([0-5]?[0-9])))))?$";
		/// <summary>
		/// 贷币正则表达式，大于0的数字
		/// </summary>
		public const string MoneyPattern = @"^[1-9]+[0-9]*(\.?[0-9]+)?|0\.0*[1-9]+0*|[1-9]$";
		/// <summary>
		/// 正整数正则表达式
		/// </summary>
		public const string NumberPattern = @"^[0-9]*$";
		/// <summary>
		/// 带符号整数正则表达式
		/// </summary>
		public const string NumberSignPattern = @"^[+-]?[0-9]+$";
		/// <summary>
		/// 正浮点数正则表达式
		/// </summary>
		public const string PositiveNumPattern = @"^\d+[.]?\d*$";
		/// <summary>
		/// 带符号浮点数正则表达式
		/// </summary>
		public const string PositiveNumSignPattern = @"^[+-]?\d+[.]?\d*$";
		/// <summary>
		/// 邮政编码正则表达式,只能输入6位数字
		/// </summary>
		public const string ZipCodePattern = @"^\d{6}$";
		/// <summary>
		/// 地区代码正则表达式,只能输入3-5位数字
		/// </summary>
		public const string AreaCodePattern = @"^\d{3,5}$";
		/// <summary>
		/// 用户名正则表达式,只能输入字母、数字、下划线和汉字，长度在2-20之间
		/// </summary>
		public const string UserNamePattern = @"^\w{2,20}$";
		/// <summary>
		/// 密码正则表达式，只能包含字符、数字和下划线,长度在6-20之间
		/// </summary>
		public const string PasswordPattern = @"^[a-zA-Z0-9_]{6,20}$";

		#endregion

		/// <summary>
		/// 检查输入值是否匹配正则表达式
		/// </summary>
		/// <param name="input">输入值</param>
		/// <param name="pattern">正则表达式（例：^\d{17}[\d|X]|\d{15}$）</param>
		/// <returns></returns>
		public static bool IsMatch(string input,string pattern)
		{
			if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern))
			{
				return false;
			}
			return Regex.IsMatch(input, pattern);
		}
	}
}
