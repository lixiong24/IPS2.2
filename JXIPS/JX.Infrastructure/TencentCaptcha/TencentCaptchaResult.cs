using System;
using System.Collections.Generic;
using System.Text;

namespace JX.Infrastructure.TencentCaptcha
{
	/// <summary>
	/// 腾讯验证码返回信息类
	/// </summary>
	public class TencentCaptchaResult
	{
		/// <summary>
		/// 1:验证成功，0:验证失败，100:AppSecretKey参数校验错误[required]
		/// </summary>
		public int response { get; set; } = 0;
		/// <summary>
		/// [0,100]，恶意等级[optional]
		/// </summary>
		public int evil_level { get; set; } = 50;
		/// <summary>
		/// 验证错误信息[optional]
		/// </summary>
		public string err_msg { get; set; } = string.Empty;
	}
}
