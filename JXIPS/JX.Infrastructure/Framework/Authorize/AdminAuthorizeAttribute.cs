using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace JX.Infrastructure.Framework.Authorize
{
	/// <summary>
	/// 后台管理员授权特性
	/// </summary>
	public class AdminAuthorizeAttribute: AuthorizeAttribute
	{
		/// <summary>
		/// 后台认证方案（AdminAuthenticationScheme）
		/// </summary>
		public const string AdminAuthenticationScheme = "AdminAuthenticationScheme";
		/// <summary>
		/// 初始化构造，把AdminAuthenticationScheme常量赋值给AuthenticationSchemes属性
		/// </summary>
		public AdminAuthorizeAttribute()
		{
			this.AuthenticationSchemes = AdminAuthenticationScheme;
		}
	}
}
