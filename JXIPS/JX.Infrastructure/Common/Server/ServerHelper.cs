using System;
using System.Data;
using System.Data.SqlClient;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 服务器信息实用类（未测试 ）
	/// </summary>
	public class ServerHelper
    {
        /// <summary>
        /// 获取请求的用户代理信息：暂未实现
        /// </summary>
        public static　UserAgentInfo UserAgent
        {
            get 
            { 
                UserAgentInfo agent =  new UserAgentInfo();
                return agent;
            }
        }

        /// <summary>
        /// 获取当前WEB服务器信息
        /// </summary>
        public static　ServerInfo Server
        {
            get
            { 
                ServerInfo info = new ServerInfo() ;
				info.AspNetVersion = Environment.Version.ToString();
				info.IISVersion = MyHttpContext.Current.Request.Headers["SERVER_SOFTWARE"];
				info.ServerIP = MyHttpContext.Current.Connection.LocalIpAddress.MapToIPv4().ToString();
				info.OSVersion = ParseOSName(Environment.OSVersion.VersionString);
				info.ServicePack = Environment.OSVersion.ServicePack;

				return info;
            }
        }

        /// <summary>
        /// 获取当前网站进程性能信息
        /// </summary>
        public static WebProcessInfo Process
        {
            get
            {
                WebProcessInfo info = new WebProcessInfo();
                return info;
            }
        }

		/// <summary>
		/// 获取指定数据库的相关信息(sqlserver)
		/// </summary>
		/// <param name="connectionString">数据库连接字符串</param>
		/// <returns></returns>
		public static DataBaseInfo GetDatabaseInfo(string connectionString)
		{
			DataBaseInfo database = new DataBaseInfo();
			
			SqlConnection conn = new SqlConnection(connectionString);

			SqlDataAdapter ada = new SqlDataAdapter();
			DataTable dt = new DataTable();
			SqlCommand command = new SqlCommand();

			try
			{
				conn.Open();

				//数据库名称
				database.DatabaseName = conn.Database;
				database.DataSource = conn.DataSource;

				//数据库大小
				command.Connection = conn;
				command.CommandText = "select sum(size)/128,sum(maxsize)/128 from sysfiles";
				ada.SelectCommand = command;
				ada.Fill(dt);

				database.UseSize = dt.Rows[0][0].ToString();
				database.MaxSize = dt.Rows[0][1].ToString();
				if (database.MaxSize == "0") database.MaxSize = "无限制";
				//数据库版本
				dt = new DataTable();
				command.CommandText = "select SERVERPROPERTY('Collation') as Collation,SERVERPROPERTY('Edition') as Edition,SERVERPROPERTY('Engine Edition') as EngineEdition,SERVERPROPERTY('InstanceName') as InstanceName,SERVERPROPERTY('IsClustered') as IsClustered,SERVERPROPERTY('IsFullTextInstalled') as IsFullTextInstalled,SERVERPROPERTY('IsIntegratedSecurityOnly') as IsIntegratedSecurityOnly,SERVERPROPERTY('IsSingleUser') as IsSingleUser,SERVERPROPERTY('IsSyncWithBackup') as IsSyncWithBackup,SERVERPROPERTY('LicenseType') as LicenseType,SERVERPROPERTY('MachineName') as MachineName,SERVERPROPERTY('NumLicenses') as NumLicenses,SERVERPROPERTY('ProcessID') as ProcessID,SERVERPROPERTY('ProductVersion') as ProductVersion,SERVERPROPERTY('ProductLevel') as ProductLevel,SERVERPROPERTY('ServerName') as ServerName,@@DATEFIRST as DATEFIRST,@@LANGUAGE as LANGUAGE,@@LANGID as LANGID,@@LOCK_TIMEOUT as LOCK_TIMEOUT,@@MAX_CONNECTIONS as MAX_CONNECTIONS,@@OPTIONS as OPTIONS,@@REMSERVER as REMSERVER,@@SERVERNAME as SERVERNAME,@@SERVICENAME as SERVICENAME,@@VERSION  as VERSION,APP_NAME() as APP_NAME,CURRENT_USER as CURRENTUSER,HOST_ID() as HOST_ID,HOST_NAME() as HOST_NAME,USER_NAME() as USER_NAME,@@CPU_BUSY as CPU_BUSY,@@IDLE as IDLE,@@IO_BUSY as IO_BUSY,@@PACK_RECEIVED as PACK_RECEIVED,@@PACK_SENT as PACK_SENT,@@TOTAL_READ as TOTAL_READ,@@TOTAL_WRITE as TOTAL_WRITE";
				ada.SelectCommand = command;
				ada.Fill(dt);

				conn.Close();

				database.ServerVersion = dt.Rows[0]["VERSION"].ToString().Substring(0, 27);
				database.ProductLevel = dt.Rows[0]["ProductLevel"].ToString();
				database.Edition = dt.Rows[0]["Edition"].ToString();
				database.InstanceName = dt.Rows[0]["InstanceName"].ToString();
				database.MachineName = dt.Rows[0]["MachineName"].ToString();
				database.LANGUAGE = dt.Rows[0]["LANGUAGE"].ToString();

				return database;
			}
			catch
			{
				if (conn.State != ConnectionState.Closed)
					conn.Close();
				throw;
			}
		}

		/// <summary>
		/// 根据操作系统字符串解析操作系统版本名称
		/// </summary>
		/// <param name="agent"></param>
		/// <returns></returns>
		public static string ParseOSName(string agent)
        {
            if (agent.IndexOf("NT 4.0") > 0)
            {
                return "Windows NT ";
            }
            else if (agent.IndexOf("NT 5.0") > 0)
            {
                return "Windows 2000";
            }
            else if (agent.IndexOf("NT 5.1") > 0)
            {
                return "Windows XP";
            }
            else if (agent.IndexOf("NT 5.2") > 0)
            {
                return "Windows 2003";
            }
            else if (agent.IndexOf("NT 6.0") > 0)
            {
                return "Windows Vista";
            }
            else if (agent.IndexOf("WindowsCE") > 0)
            {
                return "Windows CE";
            }
            else if (agent.IndexOf("NT") > 0)
            {
                return "Windows NT ";
            }
            else if (agent.IndexOf("9x") > 0)
            {
                return "Windows ME";
            }
            else if (agent.IndexOf("98") > 0)
            {
                return "Windows 98";
            }
            else if (agent.IndexOf("95") > 0)
            {
                return "Windows 95";
            }
            else if (agent.IndexOf("Win32") > 0)
            {
                return "Win32";
            }
            else if (agent.IndexOf("Linux") > 0)
            {
                return "Linux";
            }
            else if (agent.IndexOf("SunOS") > 0)
            {
                return "SunOS";
            }
            else if (agent.IndexOf("Mac") > 0)
            {
                return "Mac";
            }
            else if (agent.IndexOf("Linux") > 0)
            {
                return "Linux";
            }
            else if (agent.IndexOf("Windows") > 0)
            {
                return "Windows";
            }
            return "unknown";
        }
    }   
}
