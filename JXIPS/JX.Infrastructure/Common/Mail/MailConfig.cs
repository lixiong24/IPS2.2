namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 邮件配置文件类
	/// </summary>
	public class MailConfig
	{
		private AuthenticationType m_AuthenticationType;
		/// <summary>
		/// 验证类型
		/// </summary>
		public AuthenticationType AuthenticationType
		{
			get
			{
				return this.m_AuthenticationType;
			}
			set
			{
				this.m_AuthenticationType = value;
			}
		}

		private bool m_EnabledSsl;
		/// <summary>
		/// 是否启用安全连接(ssl)
		/// </summary>
		public bool EnabledSsl
		{
			get
			{
				return this.m_EnabledSsl;
			}
			set
			{
				this.m_EnabledSsl = value;
			}
		}

		private string m_MailFrom;
		/// <summary>
		/// 发送人邮箱
		/// </summary>
		public string MailFrom
		{
			get
			{
				return this.m_MailFrom;
			}
			set
			{
				this.m_MailFrom = value;
			}
		}

		private string m_MailServer;
		/// <summary>
		/// 发送邮件服务器(SMTP)
		/// </summary>
		public string MailServer
		{
			get
			{
				return this.m_MailServer;
			}
			set
			{
				this.m_MailServer = value;
			}
		}

		private int m_Port;
		/// <summary>
		/// 端口号
		/// </summary>
		public int Port
		{
			get
			{
				return this.m_Port;
			}
			set
			{
				this.m_Port = value;
			}
		}

		private string m_MailServerUserName;
		/// <summary>
		/// 发件人的用户名
		/// </summary>
		public string MailServerUserName
		{
			get
			{
				return this.m_MailServerUserName;
			}
			set
			{
				this.m_MailServerUserName = value;
			}
		}

		private string m_MailServerPassWord;
		/// <summary>
		/// 发件人的密码
		/// </summary>
		public string MailServerPassWord
		{
			get
			{
				return this.m_MailServerPassWord;
			}
			set
			{
				this.m_MailServerPassWord = value;
			}
		}
	}
}
