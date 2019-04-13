using JX.Infrastructure.Common;
using System;
using System.Reflection;

namespace JX.Infrastructure.Log
{
	/// <summary>
	/// 日志工厂类，日志可以保存到文件或数据库。
	/// 1、保存到文件，直接把日志写入到网站根目录下的LOG文件夹中。
	/// 2、保存到数据库，通过反射机制动态的创建日志类。
	/// 3、WebHostConfig配置文件中定义的“LogFactoryName”的键值。例：JX.ADO.LogRepositoryADO,JX.ADO
	/// </summary>
	public static class LogFactory
    {
		/// <summary>
		/// WebHostConfig配置文件中定义的“LogFactoryName”的键值
		/// </summary>
		private static string DBLogPath
		{
			get
			{
				return ConfigHelper.Get<WebHostConfig>().LogFactoryName;
			}
		}

		/// <summary>
		/// 创建日志，只有指定类型为Files的时候，才会创建记录到文本文件的日志，其他的都是记录到数据库的日志
		/// </summary>
		/// <param name="logType">日志类型</param>
		/// <returns>日志接口</returns>
		public static ILog CreateLog(LogType logType)
		{
			switch (logType)
			{
				case LogType.Files:
					return new FileLog();
				default:
					return CreateDBLog();
			}
		}

		/// <summary>
		/// 创建数据库类型的日志
		/// </summary>
		/// <returns>日志接口</returns>
		public static ILog CreateDBLog()
        {
			string[] arrLogName = DBLogPath.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			string typeName = arrLogName[0];
			AssemblyName assemblyName = new AssemblyName(arrLogName[1]);
			return (ILog)Assembly.Load(assemblyName).CreateInstance(typeName);
        }

		/// <summary>
		/// 记录日志到文件
		/// </summary>
		/// <param name="logTitle">日志标题</param>
		/// <param name="logMsg">日志内容</param>
		/// <param name="userName">用户名</param>
		/// <param name="logCategory">日志类别</param>
		/// <param name="logPriority">日志等级</param>
		/// <param name="logSource">异常信息</param>
		public static void SaveFileLog(string logTitle, string logMsg, string userName = "", LogCategory logCategory= LogCategory.SystemAction, LogPriority logPriority = LogPriority.Normal,string logSource="")
		{
			LogInfo info = new LogInfo();
			info.UserIP = IPHelper.GetClientIP();
			info.Timestamp = DateTime.Now;
			info.Category = logCategory;
			info.Priority = logPriority;
			info.UserName = userName;
			if (MyHttpContext.Current != null)
			{
				if (MyHttpContext.Current.Request.Path.HasValue)
				{
					info.ScriptName =MyHttpContext.Current.Request.Path.Value;
				}
			}
			string strHeaders = "Request Headers信息：";
			foreach (string strFormKey in MyHttpContext.Current.Request.Headers.Keys)
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
			ILog log = CreateLog(LogType.Files);
			log.Add(info);
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
		public static void SaveDBLog(string logTitle, string logMsg,string userName="", LogCategory logCategory = LogCategory.SystemAction, LogPriority logPriority= LogPriority.Normal, string logSource = "")
		{
			LogInfo info = new LogInfo();
			info.UserIP = IPHelper.GetClientIP();
			info.Timestamp = DateTime.Now;
			info.Category = logCategory;
			info.Priority = logPriority;
			info.UserName = userName;
			if (MyHttpContext.Current != null)
			{
				if (MyHttpContext.Current.Request.Path.HasValue)
				{
					info.ScriptName = MyHttpContext.Current.Request.Path.Value;
				}
			}
			string strHeaders = "Request Headers信息：";
			foreach (string strFormKey in MyHttpContext.Current.Request.Headers.Keys)
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
			ILog log = CreateDBLog();
			log.Add(info);
		}
	}
}
