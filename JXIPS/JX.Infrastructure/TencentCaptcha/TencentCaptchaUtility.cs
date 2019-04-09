using JX.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace JX.Infrastructure.TencentCaptcha
{
	/// <summary>
	/// 腾讯验证码实用工具类
	/// </summary>
	public static class TencentCaptchaUtility
	{
		/// <summary>
		/// 检查ticket是否有效
		/// </summary>
		/// <param name="ticket"></param>
		/// <param name="randstr"></param>
		/// <param name="userIP"></param>
		/// <returns></returns>
		public static bool CheckTicket(string ticket, string randstr, string userIP)
		{
			var tencentCaptchaConfig = ConfigHelper.GetAppSettingSection<TencentCaptchaConfig>();
			string url = "https://ssl.captcha.qq.com/ticket/verify?";
			string parm = string.Format("aid={0}&AppSecretKey={1}&Ticket={2}&Randstr={3}&UserIP={4}", tencentCaptchaConfig.AppID, tencentCaptchaConfig.AppSecretKey, ticket, randstr, userIP);
			var tencentResultJson = Utility.HttpGet(url + parm);
			TencentCaptchaResult tencentCaptchaResult = tencentResultJson.ToJsonObject<TencentCaptchaResult>();
			return tencentCaptchaResult.response == 1 ? true : false;
		}
	}
}
