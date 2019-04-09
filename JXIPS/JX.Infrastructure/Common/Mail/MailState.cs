namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 枚举 邮件状态
	/// </summary>
	public enum MailState
	{
		/// <summary>
		/// 
		/// </summary>
		None = 0,
		/// <summary>
		/// 没有可发送的信箱地址
		/// </summary>
		NoMailToAddress = 1,
		/// <summary>
		/// 没有邮件标题
		/// </summary>
		NoSubject = 2,
		/// <summary>
		/// 找不到要上传的文件
		/// </summary>
		FileNotFind = 3,
		/// <summary>
		/// 邮箱配置错误
		/// </summary>
		MailConfigIsNullOrEmpty = 4,
		/// <summary>
		/// 发送不成功
		/// </summary>
		SendFailure = 5,
		/// <summary>
		/// 配置文件只读
		/// </summary>
		ConfigFileIsWriteOnly = 6,
		/// <summary>
		/// 保存不成功
		/// </summary>
		SaveFailure = 7,
		/// <summary>
		/// 找不到指定的SMTP服务器
		/// </summary>
		SmtpServerNotFind = 8,
		/// <summary>
		/// 用户名或密码错误
		/// </summary>
		UserNameOrPasswordError = 9,
		/// <summary>
		/// 附件容量受到限制
		/// </summary>
		AttachmentSizeLimit = 10,
		/// <summary>
		/// SMTP 服务器要求安全连接(SSL)或客户端未通过身份验证
		/// </summary>
		MustIssueStartTlsFirst = 11,
		/// <summary>
		/// 服务器不支持安全连接
		/// </summary>
		NonsupportSsl = 12,
		/// <summary>
		/// 不能建立连接，或者SMTP端口设置有错误
		/// </summary>
		PortError = 13,
		/// <summary>
		/// 邮件发送成功
		/// </summary>
		Ok = 99
	}
}
