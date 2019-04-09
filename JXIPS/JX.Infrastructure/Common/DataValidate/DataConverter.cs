using System;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 数据类型转换类:将字符串或对象转换为指定类型的格式,并检查输入是否为空,作相应处理
	/// </summary>
	public class DataConverter
    {
		/// <summary>
		/// 将输入的字符串转换为布尔值类型
		/// </summary>
		/// <param name="input">要转换的字符串值:表示形式可以是 true|false,yes|no,1|0 </param>
		/// <returns>输入为true,1,yes 时返回true 其他字符均返回false </returns>
		/// <example>bool result = DataConverter.CBoolean("1");//返回true</example>
		public static bool CBoolean(string input)
		{
			bool flag = false;
			if (string.IsNullOrEmpty(input))
			{
				return flag;
			}
			input = input.Trim();
			if (((string.Compare(input, "true", StringComparison.OrdinalIgnoreCase) != 0) && (string.Compare(input, "yes", StringComparison.OrdinalIgnoreCase) != 0)) && (string.Compare(input, "1", StringComparison.OrdinalIgnoreCase) != 0))
			{
				return flag;
			}
			return true;
		}
		/// <summary>
		/// 将输入的值转换为布尔值类型
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static bool CBoolean(object input)
		{
			if (!object.Equals(input, null))
			{
				return CBoolean(input.ToString());
			}
			return false;
		}

		/// <summary>
		/// 将输入的对象值转换为日期，如果转换成功则返回转换结果，否则返回当前系统日期
		/// </summary>
		/// <param name="input">能够被转换为日期的对象</param>
		/// <returns>如果转换成功则返回转换结果，否则返回当前系统日期</returns>
		/// <example>bool result = DataConverter.CDate("2009-7-29");//返回true</example>
		public static DateTime CDate(object input)
		{
			if (!object.Equals(input, null))
			{
				return CDate(input.ToString());
			}
			return DateTime.Now;
		}
		/// <summary>
		/// 将输入的字符串转换为日期,如果转换成功则返回转换结果，否则返回当前系统日期
		/// </summary>
		/// <param name="input">能够被转换为日期的字符串</param>
		/// <returns>如果转换成功则返回转换结果，否则返回当前系统日期</returns>
		/// <example>bool result = DataConverter.CDate("2009-7-29");//返回true</example>
		public static DateTime CDate(string input)
		{
			DateTime now;
			if (!DateTime.TryParse(input, out now))
			{
				now = DateTime.Now;
			}
			return now;
		}
		/// <summary>
		/// 将输入的字符串转换为日期类型
		/// </summary>
		/// <param name="input">能够被转换为日期的字符串</param>
		/// <param name="outTime">如果转换成功则返回转换结果，否则返回outTime参数指定的值</param>
		/// <returns></returns>
		/// <example></example>
		public static DateTime CDate(string input, DateTime outTime)
		{
			DateTime time;
			if (DateTime.TryParse(input, out time))
			{
				return time;
			}
			return outTime;
		}
		/// <summary>
		/// 将输入的字符串转换为可空日期类型
		/// </summary>
		/// <param name="input">能够被转换为日期的字符串</param>
		/// <param name="outTime">如果转换成功则返回转换结果，否则返回outTime参数指定的值</param>
		/// <returns></returns>
		/// <example>bool result = DataConverter.CDate("2009-7-29");//返回true</example>
		public static DateTime? CDate(string input, DateTime? outTime)
		{
			DateTime time;
			if (!DateTime.TryParse(input, out time))
			{
				return outTime;
			}
			return new DateTime?(time);
		}
		/// <summary>
		/// 将输入的日期字符串转换为‘年-月-日’格式的字符串,如果转换成功则返回转换结果日期的年-月-日格式的字符串，否则返回空字符串
		/// </summary>
		/// <param name="input">能被转换为日期的字符串</param>
		/// <returns>如果转换成功则返回转换结果日期的年-月-日格式的字符串，否则返回空字符串</returns>
		public static string CDateString(string input)
		{
			DateTime time;
			if (!DateTime.TryParse(input, out time))
			{
				return string.Empty;
			}
			return time.ToString("yyyy-MM-dd");
		}

		/// <summary>
		/// 将输入的对象转换为 decimal 类型值
		/// </summary>
		/// <param name="input">能被转换为 decimal 的对象</param>
		/// <returns>如果转换成功则返回转换结果，否则返回 0 </returns>
		public static decimal CDecimal(object input)
		{
			return CDecimal(input, 0M);
		}
		/// <summary>
		/// 将输入的字符串转换为 decimal 类型值
		/// </summary>
		/// <param name="input">能被转换为 decimal 的数值字符串</param>
		/// <returns>如果转换成功则返回转换结果，否则返回 0 </returns>
		public static decimal CDecimal(string input)
		{
			return CDecimal(input, 0M);
		}
		/// <summary>
		/// 将输入的对象转换为 decimal 类型值
		/// </summary>
		/// <param name="input">能被转换为 decimal 的数值字符串</param>
		/// <param name="defaultValue">转换不成功时提供的默认值</param>
		/// <returns>如果转换成功则返回转换结果，如果输入为DBNull或null则返回0,否则返回 defaultValue参数指定的默认值 </returns>
		public static decimal CDecimal(object input, decimal defaultValue)
		{
			if (!object.Equals(input, null))
			{
				return CDecimal(input.ToString(), defaultValue);
			}
			return 0M;
		}
		/// <summary>
		/// 将输入的字符串转换为 decimal 类型值
		/// </summary>
		/// <param name="input">能被转换为 decimal 的数值字符串</param>
		/// <param name="defaultValue">转换不成功时提供的默认值</param>
		/// <returns>如果转换成功则返回转换结果，否则返回 defaultValue参数指定的默认值 </returns>
		public static decimal CDecimal(string input, decimal defaultValue)
		{
			decimal num;
			if (!decimal.TryParse(input, out num))
			{
				num = defaultValue;
			}
			return num;
		}

		/// <summary>
		/// 将输入的对象转换为 double 类型值
		/// </summary>
		/// <param name="input">能被转换为 double 的对象</param>
		/// <returns>如果转换成功则返回转换结果，否则返回 0.0 </returns>
		public static double CDouble(object input)
		{
			return CDouble(input, 0.0);
		}
		/// <summary>
		/// 将输入的字符串转换为 double 类型值
		/// </summary>
		/// <param name="input">能被转换为 double 的字符串</param>
		/// <returns>如果转换成功则返回转换结果，否则返回 0.0 </returns>     
		public static double CDouble(string input)
		{
			return CDouble(input, 0.0);
		}
		/// <summary>
		/// 将输入的对象转换为 double 类型值
		/// </summary>
		/// <param name="input">能被转换为 double 的数值字符串</param>
		/// <param name="defaultValue">转换不成功时提供的默认值</param>
		/// <returns>如果转换成功则返回转换结果，如果输入为DBNull或null则返回0.0，否则返回 defaultValue参数指定的默认值 </returns>
		public static double CDouble(object input, double defaultValue)
		{
			if (!object.Equals(input, null))
			{
				return CDouble(input.ToString(), defaultValue);
			}
			return 0.0;
		}
		/// <summary>
		/// 将输入的字符串转换为 double 类型值
		/// </summary>
		/// <param name="input">能被转换为 double 的数值字符串</param>
		/// <param name="defaultValue">转换不成功时提供的默认值</param>
		/// <returns>如果转换成功则返回转换结果，否则返回 defaultValue参数指定的默认值 </returns>
		public static double CDouble(string input, double defaultValue)
		{
			double num;
			if (!double.TryParse(input, out num))
			{
				return defaultValue;
			}
			return num;
		}

		/// <summary>
		/// 将输入的对象转换为 int 类型值
		/// </summary>
		/// <param name="input">能被转换为 int 的字符串</param>
		/// <returns>如果转换成功则返回转换结果，否则返回 0 </returns>   
		public static int CLng(object input)
		{
			return CLng(input, 0);
		}
		/// <summary>
		/// 将输入的字符串转换为 int 类型值
		/// </summary>
		/// <param name="input">能被转换为 int 的字符串</param>
		/// <returns>如果转换成功则返回转换结果，否则返回 0 </returns> 
		public static int CLng(string input)
		{
			return CLng(input, 0);
		}
		/// <summary>
		/// 将输入的对象转换为 int 类型值
		/// </summary>
		/// <param name="input">能被转换为 int 的数值字符串</param>
		/// <param name="defaultValue">转换不成功时提供的默认值</param>
		/// <returns>如果转换成功则返回转换结果，否则返回 defaultValue参数指定的默认值 </returns>
		public static int CLng(object input, int defaultValue)
		{
			if (!object.Equals(input, null))
			{
				return CLng(input.ToString(), defaultValue);
			}
			return defaultValue;
		}
		/// <summary>
		/// 将输入的字符串转换为 int 类型值
		/// </summary>
		/// <param name="input">能被转换为 int 的数值字符串</param>
		/// <param name="defaultValue">转换不成功时提供的默认值</param>
		/// <returns>如果转换成功则返回转换结果，否则返回 defaultValue参数指定的默认值 </returns>
		public static int CLng(string input, int defaultValue)
		{
			int num;
			if (!int.TryParse(input, out num))
			{
				num = defaultValue;
			}
			return num;
		}

		/// <summary>
		/// 将输入的对象转换为 float 类型值
		/// </summary>
		/// <param name="input">能被转换为 float 的字符串</param>
		/// <returns>如果转换成功则返回转换结果，否则返回 0f </returns>  
		public static float CSingle(object input)
		{
			return CSingle(input, 0f);
		}
		/// <summary>
		/// 将输入的字符串转换为 float 类型值
		/// </summary>
		/// <param name="input">能被转换为 float 的字符串</param>
		/// <returns>如果转换成功则返回转换结果，否则返回 0f </returns>  
		public static float CSingle(string input)
		{
			return CSingle(input, 0f);
		}
		/// <summary>
		/// 将输入的对象转换为 float 类型值
		/// </summary>
		/// <param name="input">能被转换为 float 的数值字符串</param>
		/// <param name="defaultValue">转换不成功时提供的默认值</param>
		/// <returns>如果转换成功则返回转换结果，如果输入为DBNull或null则返回0f，否则返回 defaultValue参数指定的默认值 </returns>
		public static float CSingle(object input, float defaultValue)
		{
			if (!object.Equals(input, null))
			{
				return CSingle(input.ToString(), defaultValue);
			}
			return 0f;
		}
		/// <summary>
		/// 将输入的字符串转换为 float 类型值
		/// </summary>
		/// <param name="input">能被转换为 float 的数值字符串</param>
		/// <param name="defaultValue">转换不成功时提供的默认值</param>
		/// <returns>如果转换成功则返回转换结果，否则返回 defaultValue参数指定的默认值 </returns>
		public static float CSingle(string input, float defaultValue)
		{
			float num;
			if (!float.TryParse(input, out num))
			{
				num = defaultValue;
			}
			return num;
		}

		/// <summary>
		/// 安全转换到字符串
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string ToString(object input)
		{
			return ToString(input, "");
		}
		/// <summary>
		/// 安全转换到字符串
		/// </summary>
		/// <param name="input"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static string ToString(object input, string defaultValue)
		{
			if (object.Equals(input, null) || string.IsNullOrEmpty(input.ToString()))
			{
				return defaultValue;
			}
			return input.ToString();
		}
	}
}
