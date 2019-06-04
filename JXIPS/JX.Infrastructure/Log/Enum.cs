using System.ComponentModel;

namespace JX.Infrastructure.Log
{
	/// <summary>
	/// 日志类别，枚举 分为一般、登录成功、登录失败、注销、越权、异常、
	/// 管理错误、重大行为、系统行为。
	/// </summary>
	public enum LogCategory
	{
		/// <summary>
		/// 常规
		/// </summary>
		[Description("常规类型")]
		None,
		/// <summary>
		/// 登录成功
		/// </summary>
		[Description("登录成功")]
		LogOnOk,
		/// <summary>
		/// 登录失败
		/// </summary>
		[Description("登录失败")]
		LogOnFailure,
		/// <summary>
		/// 注销
		/// </summary>
		[Description("退出登录")]
		LogOff,
		/// <summary>
		/// 越权
		/// </summary>
		[Description("越权操作")]
		ExceedAuthority,
		/// <summary>
		/// 异常
		/// </summary>
		[Description("异常记录")]
		Exception,
		/// <summary>
		/// 管理错误
		/// </summary>
		[Description("管理错误")]
		AdminErr,
		/// <summary>
		/// 重大行为
		/// </summary>
		[Description("重大行为")]
		ImportantAction,
		/// <summary>
		/// 系统行为
		/// </summary>
		[Description("系统行为")]
		SystemAction
	}

	/// <summary>
	/// 日志类型 枚举
	/// 分为系统、文件、WEB、数据库
	/// </summary>
	public enum LogType
	{
		/// <summary>
		/// 系统
		/// </summary>
		System,
		/// <summary>
		/// 文件
		/// </summary>
		Files,
		/// <summary>
		/// WEB
		/// </summary>
		Web,
		/// <summary>
		/// 数据库
		/// </summary>
		DB
	}

	/// <summary>
	/// 日志配额类型
	/// </summary>
	public enum LogQuotaType
	{
		/// <summary>
		/// 
		/// </summary>
		No,
		/// <summary>
		/// 
		/// </summary>
		KBytes,
		/// <summary>
		/// 
		/// </summary>
		Rows
	}

	/// <summary>
	/// 日志优先级 枚举
	/// </summary>
	public enum LogPriority
	{
		/// <summary>
		/// 最低
		/// </summary>
		[Description("最低")]
		Lowest,
		/// <summary>
		/// 低
		/// </summary>
		[Description("低")]
		Low,
		/// <summary>
		/// 正常
		/// </summary>
		[Description("正常")]
		Normal,
		/// <summary>
		/// 高
		/// </summary>
		[Description("高")]
		High,
		/// <summary>
		/// 最高
		/// </summary>
		[Description("最高")]
		Highest
	}

	/// <summary>
	/// 日志名称类型
	/// </summary>
	public enum LogNameType
	{
		/// <summary>
		/// 
		/// </summary>
		None,
		/// <summary>
		/// 按小时
		/// </summary>
		Hour,
		/// <summary>
		/// 按天
		/// </summary>
		Day,
		/// <summary>
		/// 按周
		/// </summary>
		Week,
		/// <summary>
		/// 按月
		/// </summary>
		Month
	}
}
