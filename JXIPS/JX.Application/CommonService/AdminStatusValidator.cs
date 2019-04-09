using JX.Infrastructure.Common;
using JX.Infrastructure.Framework.Authorize;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JX.Application.CommonService
{
	/// <summary>
	/// 管理员状态检查类。在每个请求中，都会通过此类来检查当前登录管理员的状态，异常状态者会执行退出操作。
	/// </summary>
	public static class AdminStatusValidator
    {
		/// <summary>
		/// 验证Cookies中的管理员状态是否正常，不正常则清除Cookies。
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public static async Task ValidateAsync(CookieValidatePrincipalContext context)
		{
			// Pull database from registered DI services.
			var appAdminService = context.HttpContext.RequestServices.GetRequiredService<IAdminServiceApp>();
			var userPrincipal = context.Principal;

			// Look for the last changed claim.
			var adminID = (from c in userPrincipal.Claims
							where c.Type == ClaimTypes.Sid
							select c.Value).FirstOrDefault();
			var RndPassword = (from c in userPrincipal.Claims
								where c.Type == "RndPassword"
								select c.Value).FirstOrDefault();
			var adminDTO = appAdminService.Get(p=>p.AdminID==DataConverter.CLng(adminID));
			if (string.IsNullOrEmpty(adminID) || adminDTO == null || adminDTO.IsLock || (!adminDTO.IsMultiLogin && adminDTO.RndPassword != RndPassword))
			{
				context.RejectPrincipal();
				await context.HttpContext.SignOutAsync(AdminAuthorizeAttribute.AdminAuthenticationScheme);
			}
		}
	}
}
