using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;
using JX.Infrastructure.Log;

namespace JX.Core
{
	/// <summary>
	/// 数据库表：Log 的仓储接口.
	/// </summary>
	public partial interface ILogRepository : IRepository<LogEntity>
	{
		/// <summary>
		/// 记录日志到数据库
		/// </summary>
		/// <param name="logTitle">日志标题</param>
		/// <param name="logMsg">日志内容</param>
		/// <param name="userName">用户名</param>
		/// <param name="logCategory">日志类别</param>
		/// <param name="logPriority">日志等级</param>
		/// <param name="logSource">异常信息</param>
		void SaveLog(string logTitle, string logMsg, string userName = "", LogCategory logCategory = LogCategory.SystemAction, LogPriority logPriority = LogPriority.Normal, string logSource = "");

		/// <summary>
		/// 根据日志ID删除日志信息，但保留最近两天之内的数据
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		bool BatchDel(string ids="");
		/// <summary>
		/// 删除最后范围的日志信息，但保留最近两天之内的数据。如：最后一万条
		/// </summary>
		/// <param name="offset"></param>
		/// <param name="category"></param>
		/// <returns></returns>
		bool BatchDel(int offset, int category = -1);
		/// <summary>
		/// 根据记录时间删除日志信息
		/// </summary>
		/// <param name="time"></param>
		/// <param name="category"></param>
		/// <returns></returns>
		bool BatchDel(DateTime time, int category = -1);
	}
}