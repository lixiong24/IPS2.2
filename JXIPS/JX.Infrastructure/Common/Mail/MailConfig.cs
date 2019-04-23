using System.ComponentModel.DataAnnotations;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 邮件配置文件类
	/// </summary>
	public class MailConfig
	{
		/// <summary>
		/// 验证类型
		/// </summary>
		public AuthenticationType AuthenticationType { get; set; } = AuthenticationType.Basic;
		/// <summary>
		/// 是否启用安全连接(ssl)
		/// </summary>
		public bool EnabledSsl { get; set; } = false;
		/// <summary>
		/// 发送人邮箱
		/// </summary>
		[Required(ErrorMessage = "发送人邮箱不能为空")]
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string MailFrom { get; set; }
		/// <summary>
		/// 发送邮件服务器(SMTP)
		/// </summary>
		[Required(ErrorMessage = "发送邮件服务器不能为空")]
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string MailServer { get; set; }
		/// <summary>
		/// 端口号
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "端口号只能输入数字")]
		public int Port { get; set; }
		/// <summary>
		/// 发件人的用户名
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string MailServerUserName { get; set; }
		/// <summary>
		/// 发件人的密码
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string MailServerPassWord { get; set; }
	}
}
