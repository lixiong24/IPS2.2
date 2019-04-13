using System;

namespace JX.Infrastructure.Log
{
	/// <summary>
	/// 日志信息类
	/// </summary>
	public class LogInfo
    {
		private LogCategory m_Category;
		/// <summary>
		/// 获取或设置日志类别
		/// </summary>
		public LogCategory Category
        {
            get
            {
                return this.m_Category;
            }
            set
            {
                this.m_Category = value;
            }
        }

		private int m_LogId;
		/// <summary>
		/// 获取或设置日志ID
		/// </summary>
		public int LogId
        {
            get
            {
                return this.m_LogId;
            }
            set
            {
                this.m_LogId = value;
            }
        }

		private string m_Message;
		/// <summary>
		/// 获取或设置日志内容
		/// </summary>
		public string Message
        {
            get
            {
                return this.m_Message;
            }
            set
            {
                this.m_Message = value;
            }
        }

		private string m_PostString;
		/// <summary>
		/// 获取或设置提交信息
		/// </summary>
		public string PostString
        {
            get
            {
                return this.m_PostString;
            }
            set
            {
                this.m_PostString = value;
            }
        }

		private LogPriority m_Priority = LogPriority.Normal;
		/// <summary>
		/// 获取或设置日志优先级
		/// </summary>
		public LogPriority Priority
        {
            get
            {
                return this.m_Priority;
            }
            set
            {
                this.m_Priority = value;
            }
        }

		private string m_ScriptName;
		/// <summary>
		/// 获取或设置页面名称
		/// </summary>
		public string ScriptName
        {
            get
            {
                return this.m_ScriptName;
            }
            set
            {
                this.m_ScriptName = value;
            }
        }

		private string m_Source;
		/// <summary>
		/// 获取或设置异常源，堆栈跟踪等异常信息
		/// </summary>
		public string Source
        {
            get
            {
                return this.m_Source;
            }
            set
            {
                this.m_Source = value;
            }
        }

		private DateTime m_Timestamp = DateTime.MaxValue;
		/// <summary>
		/// 获取或设置记录日期
		/// </summary>
		public DateTime Timestamp
        {
            get
            {
                return this.m_Timestamp;
            }
            set
            {
                this.m_Timestamp = value;
            }
        }

		private string m_Title;
		/// <summary>
		/// 获取或设置标题
		/// </summary>
		public string Title
        {
            get
            {
                return this.m_Title;
            }
            set
            {
                this.m_Title = value;
            }
        }

		private string m_UserIP;
		/// <summary>
		/// 获取或设置用户IP
		/// </summary>
		public string UserIP
        {
            get
            {
                return this.m_UserIP;
            }
            set
            {
                this.m_UserIP = value;
            }
        }

		private string m_UserName;
		/// <summary>
		/// 获取或设置用户名
		/// </summary>
		public string UserName
        {
            get
            {
                return this.m_UserName;
            }
            set
            {
                this.m_UserName = value;
            }
        }
    }
}
