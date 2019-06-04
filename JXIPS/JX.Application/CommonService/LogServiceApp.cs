using AutoMapper;
using JX.Core;
using JX.Core.Entity;
using JX.Infrastructure.Common;
using JX.Infrastructure.Data;
using JX.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JX.Application
{
	/// <summary>
	/// 数据库表：Log 的应用层服务接口实现类.
	/// </summary>
	public partial class LogServiceApp : ILogServiceApp
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
		public void SaveLog(string logTitle, string logMsg, string userName = "", LogCategory logCategory = LogCategory.SystemAction, LogPriority logPriority = LogPriority.Normal, string logSource = "")
		{
			_repository.SaveLog(logTitle, logMsg, userName, logCategory, logPriority, logSource);
		}

		/// <summary>
		/// 根据日志ID删除日志信息，但保留最近两天之内的数据
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		public bool BatchDel(string ids)
		{
			return _repository.BatchDel(ids);
		}
		/// <summary>
		/// 删除指定日期以前的记录
		/// </summary>
		/// <param name="time"></param>
		/// <param name="category"></param>
		/// <returns></returns>
		public bool BatchDel(DateTime time, int category = -1)
		{
			return _repository.BatchDel(time, category);
		}
		/// <summary>
		/// 删除最后范围的日志信息，但保留最近两天之内的数据。如：最后一万条
		/// </summary>
		/// <param name="offset">删除数量</param>
		/// <param name="category"></param>
		/// <returns></returns>
		public bool BatchDel(int offset, int category = -1)
		{
			return _repository.BatchDel(offset, category);
		}
	}
}