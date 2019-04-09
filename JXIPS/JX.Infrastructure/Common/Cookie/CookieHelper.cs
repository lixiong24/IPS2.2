using Microsoft.AspNetCore.Http;
using System;
using System.Net;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// Cookie帮助类
	/// </summary>
	public class CookieHelper
    {
		#region 获取cookie值
		/// <summary>
		/// 获取Cookie值，不存在返回空值。Cookie值经过System.Net.WebUtility.UrlDecode方法解码
		/// </summary>
		/// <param name="name">Cookie Name</param>
		/// <returns></returns>
		public static string GetCookie(string name)
		{
			return GetCookie(name, "", true);
		}
		/// <summary>
		/// 获取cookie字符串值
		/// </summary>
		/// <param name="cookieName"></param>
		/// <param name="defaultValue">默认值</param>
		/// <param name="isDecode">是否用System.Net.WebUtility.UrlDecode解码</param>
		/// <returns></returns>
		public static string GetCookie(string cookieName, string defaultValue, bool isDecode)
		{
			var cookie = MyHttpContext.Current.Request.Cookies[cookieName];
			if (string.IsNullOrEmpty(cookie))
			{
				return defaultValue;
			}
			return isDecode ? WebUtility.UrlDecode(cookie) : cookie;
		}
		/// <summary>
		/// 获取cookie值,并将结果转为int32
		/// </summary>
		/// <param name="cookieName"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static int GetCookie(string cookieName, int defaultValue)
		{
			var cookie = MyHttpContext.Current.Request.Cookies[cookieName];
			if (!string.IsNullOrEmpty(cookie))
			{
				int result;
				bool success = int.TryParse(cookie, out result);
				return success ? result : defaultValue;
			}
			return defaultValue;
		}
		/// <summary>
		/// 获取cookie转换为时间
		/// </summary>
		/// <param name="cookieName"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static DateTime GetCookie(string cookieName, DateTime defaultValue)
		{
			var cookie = MyHttpContext.Current.Request.Cookies[cookieName];
			if (!string.IsNullOrEmpty(cookie))
			{
				DateTime result;
				bool success = DateTime.TryParse(cookie, out result);
				return success ? result : defaultValue;
			}
			return defaultValue;
		}
		#endregion

		#region 创建cookie
		/// <summary>
		/// 创建cookie
		/// </summary>
		/// <param name="cookieName">名称</param>
		/// <param name="cookieValue">值</param>
		public static void CreateCookie(string cookieName, string cookieValue)
		{
			CreateCookie(cookieName, cookieValue, 0);
		}
		/// <summary>
		/// 创建cookie
		/// </summary>
		/// <param name="cookieName">名称</param>
		/// <param name="cookieValue">值</param>
		/// <param name="expirMinute">过期时间，单位分钟</param>
		public static void CreateCookie(string cookieName, string cookieValue, int expirMinute)
		{
			CreateCookie(cookieName, cookieValue, expirMinute, "", "");
		}
		/// <summary>
		/// 创建cookie
		/// </summary>
		/// <param name="cookieName">名称</param>
		/// <param name="cookieValue">值</param>
		/// <param name="expirMinute">过期时间，单位分钟</param>
		/// <param name="cookieDomain">域名。</param>
		/// <param name="cookiePath">路径。默认为根路径</param>
		public static void CreateCookie(string cookieName, string cookieValue, int expirMinute, string cookieDomain, string cookiePath)
		{
			var MyCookie = new CookieOptions();
			MyCookie.HttpOnly = true;
			if (expirMinute > 0)
			{
				DateTime expires = DateTime.Now.AddMinutes(expirMinute);
				DateTimeOffset dateAndOffset = new DateTimeOffset(expires,TimeZoneInfo.Local.GetUtcOffset(expires));
				MyCookie.Expires = dateAndOffset;
			}
			if (string.IsNullOrEmpty(cookiePath))
			{
				cookiePath = "/";
			}
			MyCookie.Path = cookiePath;
			if (!string.IsNullOrEmpty(cookieDomain))
			{
				MyCookie.Domain = cookieDomain;
			}
			MyHttpContext.Current.Response.Cookies.Append(cookieName, cookieValue,MyCookie);
		}
		#endregion

		#region 删除cookie
		/// <summary>
		///  删除cookie
		/// </summary>
		/// <param name="cookieName"></param>
		public static void DeleteCookie(string cookieName)
		{
			MyHttpContext.Current.Response.Cookies.Delete(cookieName);
		}
		#endregion
	}
}
