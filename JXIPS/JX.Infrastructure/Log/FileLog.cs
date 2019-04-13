using JX.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JX.Infrastructure.Log
{
	/// <summary>
	/// 文本文件日志类，只实现了添加方法。
	/// </summary>
	public class FileLog : ILog
	{
		private string logPath =  Path.Combine(FileHelper.ContentRootPath+FileHelper.DirectorySeparatorChar, "log");

		/// <summary>
		/// 添加日志信息
		/// </summary>
		/// <param name="logInfo"></param>
		public void Add(LogInfo logInfo)
		{
			if (logInfo != null)
			{
				var category = EnumHelper.GetDescription(logInfo.Category);
				string strContent = "============================================================="+ Environment.NewLine;
				strContent += "日志类型：" + category + Environment.NewLine;
				strContent += "日志标题：" + logInfo.Title + Environment.NewLine;
				strContent += "日志记录时间：" + logInfo.Timestamp.ToString("yyyy-MM-dd HH:mm:ss") + Environment.NewLine;
				strContent += "操作人：" + logInfo.UserName + " 操作IP：" + logInfo.UserIP + Environment.NewLine;
				strContent += "日志内容：" + logInfo.Message + Environment.NewLine;
				strContent += "访问地址：" + logInfo.ScriptName + Environment.NewLine;
				strContent += "提交的信息：" + logInfo.PostString + Environment.NewLine;
				strContent += "异常信息：" + logInfo.Source + Environment.NewLine;
				strContent += "=============================================================" + Environment.NewLine + Environment.NewLine;
				var filePath = logPath + FileHelper.DirectorySeparatorChar + category + FileHelper.DirectorySeparatorChar + DateTime.Now.Date.ToString("yyyy-MM-dd") + "-"+ DateTime.Now.Hour + ".log";
				FileHelper.WriteAppend(filePath, strContent);
			}
		}

		/// <summary>
		/// 删除日志（未实现）
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool Delete(string id)
		{
			return false;
		}

		/// <summary>
		/// 删除日志（未实现）
		/// </summary>
		/// <param name="time"></param>
		/// <returns></returns>
		public bool Delete(DateTime time)
		{
			return false;
		}

		/// <summary>
		/// 删除日志（未实现）
		/// </summary>
		/// <param name="offset"></param>
		/// <returns></returns>
		public bool DeleteLastRange(int offset)
		{
			return false;
		}

		/// <summary>
		/// 日志列表（未实现）
		/// </summary>
		/// <param name="startRowIndexId"></param>
		/// <param name="maxNumberRows"></param>
		/// <returns></returns>
		public IList<LogInfo> GetList(int startRowIndexId, int maxNumberRows)
		{
			return null;
		}
		/// <summary>
		/// 日志列表（未实现）
		/// </summary>
		/// <param name="startRowIndexId"></param>
		/// <param name="maxNumberRows"></param>
		/// <param name="category"></param>
		/// <returns></returns>
		public IList<LogInfo> GetList(int startRowIndexId, int maxNumberRows, LogCategory category)
		{
			return null;
		}
		/// <summary>
		/// 日志列表（未实现）
		/// </summary>
		/// <param name="startRowIndexId"></param>
		/// <param name="maxNumberRows"></param>
		/// <param name="searchType"></param>
		/// <param name="keyword"></param>
		/// <returns></returns>
		public IList<LogInfo> GetList(int startRowIndexId, int maxNumberRows, string searchType, string keyword)
		{
			return null;
		}
		/// <summary>
		/// 得到日志（未实现）
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public LogInfo GetLogById(int id)
		{
			return null;
		}

		/// <summary>
		/// 得到日志列表总数（未实现）
		/// </summary>
		/// <returns></returns>
		public int GetTotalOfLog()
		{
			return 0;
		}

		/// <summary>
		/// 更新日志（未实现）
		/// </summary>
		/// <param name="logInfo"></param>
		/// <returns></returns>
		public bool Update(LogInfo logInfo)
		{
			return false;
		}
	}
}
