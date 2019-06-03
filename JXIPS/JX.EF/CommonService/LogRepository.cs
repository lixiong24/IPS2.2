using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;
using JX.Infrastructure.Log;
using JX.Infrastructure.Common;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：Log 的仓储实现类.
	/// </summary>
	public partial class LogRepository : Repository<LogEntity>, ILogRepository
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
			LogEntity info = new LogEntity();
			info.UserIP = IPHelper.GetClientIP();
			info.Timestamp = DateTime.Now;
			info.Category = (int)logCategory;
			info.Priority = (int)logPriority;
			info.UserName = userName;
			if (MyHttpContext.Current != null)
			{
				if (MyHttpContext.Current.Request.Path.HasValue)
				{
					info.ScriptName = MyHttpContext.Current.Request.Path.Value;
				}
			}
			string strHeaders = "Request Headers信息：";
			foreach (String strFormKey in MyHttpContext.Current.Request.Headers.Keys)
			{
				strHeaders += "\"" + strFormKey + "\":\"" + MyHttpContext.Current.Request.Headers[strFormKey] + "\",";
			}
			strHeaders = strHeaders.TrimEnd(',');
			string strForm = "Request Form信息：";
			if (MyHttpContext.Current.Request.Method == "POST" && MyHttpContext.Current.Request.HasFormContentType)
			{
				foreach (string strFormKey in MyHttpContext.Current.Request.Form.Keys)
				{
					strForm += "\"" + strFormKey + "\":\"" + DataConverter.ToString(MyHttpContext.Current.Request.Form[strFormKey]) + "\",";
				}
				strForm = strForm.TrimEnd(',');
			}
			info.PostString = strHeaders + Environment.NewLine + strForm;
			info.Source = logSource;
			info.Message = logMsg;
			info.Title = logTitle;
			Add(info);
		}

		/// <summary>
		/// 根据日志ID删除日志信息，但保留最近两天之内的数据
		/// </summary>
		/// <param name="ids"></param>
		/// <returns></returns>
		public bool BatchDel(string ids)
		{
			if(!DataValidator.IsValidId(ids))
			{
				return false;
			}
			string strSQL = "DELETE FROM Log WHERE LogID IN ( " + ids + " ) AND [Timestamp] < DATEADD(dd,-2,GETDATE())";
			int result = ExeSQL(strSQL);
			if(result > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 删除指定日期以前的记录
		/// </summary>
		/// <param name="time"></param>
		/// <param name="category"></param>
		/// <returns></returns>
		public bool BatchDel(DateTime time, int category = -1)
		{
			string filter = "";
			if (category >= 0)
			{
				filter = " and Category=" + category;
			}
			string strSQL = "DELETE FROM Log WHERE DATEDIFF(dd, [timestamp], '"+ time.ToString("yyyy-MM-dd") + "') > 0" + filter;
			int result = ExeSQL(strSQL);
			if (result > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 删除最后范围的日志信息，但保留最近两天之内的数据。如：最后一万条
		/// </summary>
		/// <param name="offset">删除数量</param>
		/// <param name="category"></param>
		/// <returns></returns>
		public bool BatchDel(int offset, int category = -1)
		{
			string filter = "";
			if (category >= 0)
			{
				filter = " and Category=" + category;
			}
			string strSQL = "SELECT COUNT([LogId]) FROM Log WHERE DATEDIFF(dd, [timestamp], '" + DateTime.Today.AddDays(-2.0).ToString("yyyy-MM-dd") + "') > 0" + filter;
			var resultCount = SqlQueryOne<int>(strSQL);
			if(resultCount.Count <= 0)
			{
				return true;
			}
			int num = resultCount[0];
			if (offset > num)
			{
				offset = num;
			}
			strSQL = "DELETE Log WHERE [LogId] < (SELECT MAX(LogId) FROM (SELECT TOP " + (offset + 1) + " LogId FROM Log where 1=1 " + filter + " ORDER BY LogId asc) AS T) " + filter;
			int result = ExeSQL(strSQL);
			if (result > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

	}
}