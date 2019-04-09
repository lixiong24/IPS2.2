using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Text;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// HttpRequest的扩展类
	/// </summary>
	public static class RequestExtensions
    {
		/// <summary>
		/// 得到User-Agent的值
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public static string UserAgent(this HttpRequest request)
		{
			return request.Headers[HeaderNames.UserAgent];
		}

		/// <summary>
		/// 得到Referer的值
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public static string UrlReferrer(this HttpRequest request)
		{
			return request.Headers[HeaderNames.Referer];
		}

		/// <summary>
		/// 得到当前请求的完整URL
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public static string AbsoluteUri(this HttpRequest request)
		{
			return new StringBuilder()
				.Append(request.Scheme)
				.Append("://")
				.Append(request.Host)
				.Append(request.PathBase)
				.Append(request.Path)
				.Append(request.QueryString)
				.ToString();
		}



	}
}
