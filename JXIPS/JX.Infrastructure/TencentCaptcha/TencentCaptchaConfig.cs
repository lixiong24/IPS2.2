using System;
using System.Collections.Generic;
using System.Text;

namespace JX.Infrastructure.TencentCaptcha
{
	/// <summary>
	/// 腾讯验证码使用配置文件
	/// </summary>
	public class TencentCaptchaConfig
	{
		/// <summary>
		/// AppID
		/// </summary>
		public string AppID { get; set; } = string.Empty;
		/// <summary>
		/// AppSecretKey
		/// </summary>
		public string AppSecretKey { get; set; } = string.Empty;
	}
}
