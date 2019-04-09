using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;
using JX.Infrastructure.Common;
using MyADO;
using JX.Infrastructure.Log;

namespace JX.ADO
{
	/// <summary>
	/// 数据库表：Log 的仓储实现类.
	/// </summary>
	public partial class LogRepositoryADO : ILog
	{
		/// <summary>
		/// 构造器，实现数据库连接
		/// </summary>
		public LogRepositoryADO()
		{
			_DB = new SqlDBOperator(ConfigHelper.AppSettingConfiguration["ConnectionStrings:DefaultConnection"]);
		}

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

		#region 添加、删除、修改
		/// <summary>
		/// 添加日志信息
		/// </summary>
		/// <param name="logInfo">日志信息类</param>
		public void Add(LogInfo logInfo)
		{
			Add(GetLog(logInfo));
		}

		/// <summary>
		/// 根据记录时间删除日志信息
		/// </summary>
		/// <param name="time">记录时间</param>
		/// <returns>true/false</returns>
		public bool Delete(DateTime time)
		{
			string strWhere = " and DATEDIFF(dd, [Timestamp], @Timestamp) > 0";
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("Timestamp", time.ToString("yyyy-MM-dd"));
			return Delete(strWhere,dict);
		}
		/// <summary>
		/// 根据日志ID删除日志信息，但保留最近两天之内的数据
		/// </summary>
		/// <param name="id">日志ID</param>
		/// <returns>TRUE/FALSE</returns>
		public bool Delete(string id)
		{
			string strWhere = " and LogID in ("+DataSecurity.ToValidId(id)+ ") AND [Timestamp] < DATEADD(dd,-2,GETDATE())";
			Dictionary<string, object> dict = new Dictionary<string, object>();
			return Delete(strWhere, dict);
		}
		/// <summary>
		/// 删除最后范围的日志信息，但保留最近两天之内的数据。如：最后一万条
		/// </summary>
		/// <param name="offset">删除数量</param>
		/// <returns>TRUE/FALSE</returns>
		public bool DeleteLastRange(int offset)
		{
			string strWhere = " and DATEDIFF(dd, [Timestamp], @Timestamp) > 0";
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("Timestamp", DateTime.Today.AddDays(-2.0).ToString("yyyy-MM-dd"));
			int num = GetCount(strWhere, dict);
			if (num <= 0) return true;
			if (offset > num)
			{
				offset = num;
			}
			strWhere = " and LogID < (SELECT MAX(LogID) FROM (SELECT TOP " + (offset + 1) + " LogID FROM Log ORDER BY LogID asc) AS T)";
			return Delete(strWhere,null);
		}

		/// <summary>
		/// 更新日志信息
		/// </summary>
		/// <param name="logInfo">日志信息对象</param>
		/// <returns>TRUE/FALSE</returns>
		public bool Update(LogInfo logInfo)
		{
			return Update(GetLog(logInfo));
		}
		#endregion

		#region 分页查询
		/// <summary>
		/// 得到日志列表，用于分页
		/// </summary>
		/// <param name="startRowIndexId">开始行索引</param>
		/// <param name="maxNumberRows">最大行数</param>
		/// <returns>日志列表对象</returns>
		public IList<LogInfo> GetList(int startRowIndexId, int maxNumberRows)
		{
			int total;
			IList<LogInfo> logList = GetLogInfoList(startRowIndexId, maxNumberRows,"", "", "", "", "", out total);
			m_TotalOfLog = total;
			return logList;
		}
		/// <summary>
		/// 得到日志列表，用于分页
		/// </summary>
		/// <param name="startRowIndexId">开始行索引</param>
		/// <param name="maxNumberRows">最大行数</param>
		/// <param name="category">日志类别</param>
		/// <returns>日志列表对象</returns>
		public IList<LogInfo> GetList(int startRowIndexId, int maxNumberRows, LogCategory category)
		{
			int total;
			IList<LogInfo> logList = GetLogInfoList(startRowIndexId, maxNumberRows, "", "", "", string.Format("Category = {0}", (int)category), "", out total);
			m_TotalOfLog = total;
			return logList;
		}
		/// <summary>
		/// 得到日志列表，用于分页
		/// </summary>
		/// <param name="startRowIndexId">开始行索引</param>
		/// <param name="maxNumberRows">最大行数</param>
		/// <param name="searchType">搜索类型(UserName：UserName LIKE '%keyword%'；Title：Title LIKE '%keyword%'；UserIP：UserIP LIKE '%keyword%'；)</param>
		/// <param name="keyword">关键字</param>
		/// <returns>日志列表对象</returns>
		public IList<LogInfo> GetList(int startRowIndexId, int maxNumberRows, string searchType, string keyword)
		{
			string filter = string.Empty;
			switch (searchType)
			{
				case "UserName":
					filter = "UserName LIKE '%" + DataSecurity.FilterBadChar(keyword) + "%'";
					break;
				case "Title":
					filter = "Title LIKE '%" + DataSecurity.FilterBadChar(keyword) + "%'";
					break;
				case "UserIP":
					filter = "UserIP LIKE '%" + DataSecurity.FilterBadChar(keyword) + "%'";
					break;
			}
			int total;
			IList<LogInfo> logList = GetLogInfoList(startRowIndexId, maxNumberRows, "", "", "", filter, "", out total);
			m_TotalOfLog = total;
			return logList;
		}

		/// <summary>
		/// 通过日志ID得到日志信息对象
		/// </summary>
		/// <param name="id">日志ID</param>
		/// <returns>日志信息对象</returns>
		public LogInfo GetLogById(int id)
		{
			return GetLogInfo(GetEntity(id));
		}

		private int m_TotalOfLog;
		/// <summary>
		/// 得到用于分页查询时的总记录数
		/// </summary>
		/// <returns>合计数</returns>
		public int GetTotalOfLog()
		{
			return m_TotalOfLog;
		}
		#endregion

		#region 辅助方法
		/// <summary>
		/// 通过存储过程“Common_GetList”，得到分页后的数据
		/// </summary>
		/// <param name="startRowIndexId">开始行索引</param>
		/// <param name="maxNumberRows">每页最大显示数量</param>
		/// <param name="SortColumn">排序字段名，只能指定一个字段</param>
		/// <param name="StrColumn">返回列名</param>
		/// <param name="Sorts">排序方式（DESC,ASC）</param>
		/// <param name="Filter">查询条件(例如: Name = 'name' and id=1 )</param>
		/// <param name="TableName">查询表名，可以指定联合查询的SQL语句(例如: Comment LEFT JOIN Users ON Comment.UserName = Users.UserName)</param>
		/// <param name="Total">输出参数：查询总数</param>
		/// <returns></returns>
		private IList<LogInfo> GetLogInfoList(int startRowIndexId, int maxNumberRows, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total)
		{
			IList<LogInfo> list = new List<LogInfo>();
			if (string.IsNullOrEmpty(SortColumn))
			{
				SortColumn = "LogID";
			}
			if (string.IsNullOrEmpty(StrColumn))
			{
				StrColumn = "*";
			}
			if (string.IsNullOrEmpty(Sorts))
			{
				Sorts = "DESC";
			}
			if (string.IsNullOrEmpty(TableName))
			{
				TableName = "Log";
			}
			string storedProcedureName = "Common_GetList";
			SqlParameter parmStartRows = new SqlParameter("StartRows", startRowIndexId);
			SqlParameter parmPageSize = new SqlParameter("PageSize", maxNumberRows);
			SqlParameter parmSortColumn = new SqlParameter("SortColumn", SortColumn);
			SqlParameter parmStrColumn = new SqlParameter("StrColumn", StrColumn);
			SqlParameter parmSorts = new SqlParameter("Sorts", Sorts);
			SqlParameter parmTableName = new SqlParameter("TableName", TableName);
			SqlParameter parmFilter = new SqlParameter("Filter", Filter);
			SqlParameter parmTotal = new SqlParameter("Total", SqlDbType.Int);
			parmTotal.Direction = ParameterDirection.Output;
			IDataParameter[] parameterArray = new IDataParameter[8];
			parameterArray[0] = parmStartRows;
			parameterArray[1] = parmPageSize;
			parameterArray[2] = parmSortColumn;
			parameterArray[3] = parmStrColumn;
			parameterArray[4] = parmSorts;
			parameterArray[5] = parmTableName;
			parameterArray[6] = parmFilter;
			parameterArray[7] = parmTotal;
			using (NullableDataReader reader = _DB.GetDataReaderByProc(storedProcedureName, parameterArray))
			{
				while (reader.Read())
				{
					list.Add(GetLogInfoFromrdr(reader));
				}
			}
			Total = (int)parmTotal.Value;
			return list;
		}
		private static LogEntity GetLog(LogInfo logInfo)
		{
			LogEntity info = new LogEntity();
			info.LogID = logInfo.LogId;
			info.Category = (int)logInfo.Category;
			info.Priority = (int)logInfo.Priority;
			info.Title = logInfo.Title;
			info.Message = logInfo.Message;
			info.Timestamp = logInfo.Timestamp;
			info.UserName = logInfo.UserName;
			info.UserIP = logInfo.UserIP;
			info.Source = logInfo.Source;
			info.ScriptName = logInfo.ScriptName;
			info.PostString = logInfo.PostString;
			return info;
		}
		private static LogInfo GetLogInfo(LogEntity log)
		{
			LogInfo info = new LogInfo();
			info.LogId = log.LogID;
			info.Category = (LogCategory)log.Category;
			info.Priority = (LogPriority)log.Priority;
			info.Title = log.Title;
			info.Message = log.Message;
			info.Timestamp = log.Timestamp.Value;
			info.UserName = log.UserName;
			info.UserIP = log.UserIP;
			info.Source = log.Source;
			info.ScriptName = log.ScriptName;
			info.PostString = log.PostString;
			return info;
		}
		/// <summary>
		/// 把实体类转换成键/值对集合
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="dict"></param>
		private static void GetParameters(LogInfo entity, Dictionary<string, object> dict)
		{
			dict.Add("LogID", entity.LogId);
			dict.Add("Category", entity.Category);
			dict.Add("Priority", entity.Priority);
			dict.Add("Title", entity.Title);
			dict.Add("Message", entity.Message);
			dict.Add("Timestamp", entity.Timestamp);
			dict.Add("UserName", entity.UserName);
			dict.Add("UserIP", entity.UserIP);
			dict.Add("Source", entity.Source);
			dict.Add("ScriptName", entity.ScriptName);
			dict.Add("PostString", entity.PostString);
		}
		/// <summary>
		/// 通过数据读取器生成实体类
		/// </summary>
		/// <param name="rdr"></param>
		/// <returns></returns>
		private static LogInfo GetLogInfoFromrdr(NullableDataReader rdr)
		{
			LogInfo info = new LogInfo();
			info.LogId = rdr.GetInt32("LogID");
			info.Category = (LogCategory)rdr.GetInt32("Category");
			info.Priority = (LogPriority)rdr.GetInt32("Priority");
			info.Title = rdr.GetString("Title");
			info.Message = rdr.GetString("Message");
			info.Timestamp = rdr.GetNullableDateTime("Timestamp").Value;
			info.UserName = rdr.GetString("UserName");
			info.UserIP = rdr.GetString("UserIP");
			info.Source = rdr.GetString("Source");
			info.ScriptName = rdr.GetString("ScriptName");
			info.PostString = rdr.GetString("PostString");
			return info;
		}
		#endregion
	}
}