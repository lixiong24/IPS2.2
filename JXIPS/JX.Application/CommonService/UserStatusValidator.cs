using JX.Core;
using JX.Core.Entity;
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
	/// 会员状态检查类。在每个请求中，都会通过此类来检查当前登录会员的状态，异常状态者会执行退出操作。
	/// </summary>
	public static class UserStatusValidator
    {
		/// <summary>
		/// 验证Cookies中的会员状态是否正常，不正常则清除Cookies。
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public static async Task ValidateAsync(CookieValidatePrincipalContext context)
		{
			// Pull database from registered DI services.
			var appUsersService = context.HttpContext.RequestServices.GetRequiredService<IUsersServiceApp>();
			var userPrincipal = context.Principal;

			// Look for the last changed claim.
			var userName = (from c in userPrincipal.Claims
						   where c.Type == ClaimTypes.Name
						  select c.Value).FirstOrDefault();
			UserStatusEnum userStatusEnum = appUsersService.GetUserStatus(userName);
			if (string.IsNullOrEmpty(userName) || userStatusEnum != UserStatusEnum.None)
			{
				context.RejectPrincipal();
				await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			}
		}
	}
}
