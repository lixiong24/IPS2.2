namespace JX.Infrastructure.Data
{
	/// <summary>
	/// 日期查询函数常量集，返回常用的日期函数的SQL语句
	/// </summary>
	public sealed class DateStrings
	{
		/// <summary>
		/// 上个月的最后一天的SQL脚本
		/// </summary>
		public const string LastMonthEnd = "DATEADD(ms,-3, DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0))";
		/// <summary>
		/// 去年的最后一天的SQL 脚本
		/// </summary>
		public const string LastYearEnd = "DATEADD(ms,-3, DATEADD(yy, DATEDIFF(yy, 0, GETDATE()), 0))";
		/// <summary>
		/// 本月的最后一天的SQL 脚本
		/// </summary>
		public const string ThisMonthEnd = "DATEADD(ms,-3, DATEADD(mm, DATEDIFF(m, 0, GETDATE())+1, 0))";
		/// <summary>
		/// 本月的第一个星期一的SQL 脚本
		/// </summary>
		public const string ThisMonthFirstMonday = "DATEADD(wk, DATEDIFF(wk, 0, DATEADD(dd, 6 - DATEPART(day, GETDATE()), GETDATE())), 0)";
		/// <summary>
		/// 计算一个月第一天的SQL 脚本
		/// </summary>
		public const string ThisMonthStart = "DATEADD(mm, DATEDIFF(mm, 0, GETDATE()), 0)";
		/// <summary>
		/// 季度的第一天的SQL 脚本
		/// </summary>
		public const string ThisSeasonStart = "DATEADD(qq, DATEDIFF(qq, 0, GETDATE()), 0)";
		/// <summary>
		/// 本周的星期一的SQL 脚本
		/// </summary>
		public const string ThisWeekStart = "DATEADD(wk, DATEDIFF(wk, 0, GETDATE()), 0)";
		/// <summary>
		/// 本年的最后一天的SQL 脚本
		/// </summary>
		public const string ThisYearEnd = "DATEADD(ms,-3, DATEADD(yy, DATEDIFF(yy, 0, GETDATE())+1, 0))";
		/// <summary>
		/// 一年的第一天的SQL 脚本
		/// </summary>
		public const string ThisYearStart = "DATEADD(yy, DATEDIFF(yy, 0, GETDATE()), 0)";
		/// <summary>
		/// 当天的半夜的SQL 脚本
		/// </summary>
		public const string TodayStart = "DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 0)";
		/// <summary>
		/// 第二天的半夜的SQL 脚本
		/// </summary>
		public const string TomorrowStart = "DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), 1)";
		/// <summary>
		/// 昨天的半夜的SQL 脚本
		/// </summary>
		public const string YesterdayStart = "DATEADD(dd, DATEDIFF(dd, 0, GETDATE()), -1)";

		private DateStrings()
		{
		}
	}
}
