namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 邮件验证类型 枚举
	/// </summary>
	public enum AuthenticationType
	{
		/// <summary>
		/// 不验证
		/// </summary>
		None,
		/// <summary>
		/// 基本验证(如果您的电子邮件服务器要求在发送电子邮件时显式传入用户名和密码，请选择此选项。)
		/// </summary>
		Basic,
		/// <summary>
		/// Windows 身份验证(如果您的电子邮件服务器位于局域网上，并且您使用 Windows 凭据连接到该服务器，请选择此选项。)
		/// </summary>
		Ntlm
	}
}
