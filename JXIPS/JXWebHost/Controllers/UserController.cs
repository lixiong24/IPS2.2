using JX.Application;
using JX.Core;
using JX.Core.Entity;
using JX.Infrastructure.Common;
using JXWebHost.Models.UserViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JXWebHost.Controllers
{
	[Authorize]
	public class UserController : Controller
    {
		private IUsersServiceApp _UsersService;
		public UserController(IUsersServiceApp UsersService)
		{
			_UsersService = UsersService;
		}

		#region 注册/登录/退出
		[HttpGet]
		[AllowAnonymous]
		public IActionResult Register(string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			return View();
		}
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegViewModel model, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError(string.Empty, "验证未通过");
				return View(model);
			}

			var userEntity = new UsersEntity();
			userEntity.UserName = model.UserName;
			userEntity.UserPassword = Md5.EncryptHexString(model.UserPassword);

			bool bFlag = await _UsersService.AddAsync(userEntity);
			if (!bFlag)
			{
				ModelState.AddModelError(string.Empty, "注册失败");
				return View(model);
			}

			return RedirectToLocal(returnUrl);
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult Login(string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
		{
			ViewData["ReturnUrl"] = returnUrl;
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError(string.Empty, "验证未通过");
				return View(model);
			}

			var userStatus = _UsersService.Login(model.UserName, model.UserPassword);
			if (userStatus != UserStatusEnum.None)
			{
				switch (userStatus)
				{
					case UserStatusEnum.NoExist:
						ModelState.AddModelError(string.Empty, "用户名或密码不对");
						break;
					case UserStatusEnum.Locked:
						ModelState.AddModelError(string.Empty, "用户被锁定");
						break;
					case UserStatusEnum.WaitValidateByEmail:
					case UserStatusEnum.WaitValidateByAdmin:
					case UserStatusEnum.WaitValidateByMobile:
						ModelState.AddModelError(string.Empty, EnumHelper.GetDescription(userStatus));
						break;
				}
				return View(model);
			}

			var userDTO = _UsersService.GetByUserName(model.UserName);
			if (userDTO == null)
			{
				ModelState.AddModelError(string.Empty, "用户不存在");
				return View(model);
			}

			//you can add all of ClaimTypes in this collection 
			var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Name,userDTO.UserName)
				,new Claim(ClaimTypes.Email,userDTO.Email)
				,new Claim(ClaimTypes.MobilePhone,userDTO.Mobile)
				,new Claim(ClaimTypes.Gender,userDTO.Sex.ToString())
				,new Claim("TrueName",userDTO.TrueName)
				,new Claim("UserID",userDTO.UserID.ToString())
				,new Claim("GroupID",userDTO.GroupID.ToString())
				,new Claim("CompanyID",userDTO.CompanyID.ToString())
				,new Claim("ClientID",userDTO.ClientID.ToString())
				,new Claim("UserType",userDTO.UserType.ToString())
				,new Claim("UserFace",userDTO.UserFace)
				,new Claim("Sign",userDTO.Sign)
				//,new Claim(ClaimTypes.Role,"修改密码")
				,new Claim(ClaimTypes.Role,"管理员")
			};
			
			var userClaimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
			//init the identity instances 
			var userPrincipal = new ClaimsPrincipal(userClaimsIdentity);

			//signin 
			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
			{
				//ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
				IsPersistent = model.IsPersistent,
				AllowRefresh = false
			});

			return RedirectToLocal(returnUrl);
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			return RedirectToAction("Index", "Home");
		}
		#endregion

		public IActionResult Forbidden(string returnUrl = "/User/Welcome")
		{
			returnUrl = "/User/Welcome";
			ViewData["ReturnUrl"] = returnUrl;
			return View();
		}

		public IActionResult Index()
        {
			ViewData["UserName"] = this.User.FindFirst(ClaimTypes.Name).Value;
			
			return View();
        }

		[Authorize(Roles = "管理员")]
		public IActionResult Welcome()
		{
			ViewData["Email"] = this.User.FindFirst(ClaimTypes.Email).Value;
			ViewData["Mobile"] = this.User.FindFirst(ClaimTypes.MobilePhone).Value;
			ViewData["Sex"] = this.User.FindFirst(ClaimTypes.Gender).Value;
			ViewData["TrueName"] = this.User.FindFirst("TrueName").Value;
			ViewData["UserID"] = this.User.FindFirst("UserID").Value;
			ViewData["GroupID"] = this.User.FindFirst("GroupID").Value;
			return View();
		}

		[Authorize(Roles = "修改密码")]
		public IActionResult Password()
		{
			ViewData["UserName"] = this.User.FindFirst(ClaimTypes.Name).Value;

			return View();
		}

		private IActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			else
			{
				return RedirectToAction(nameof(HomeController.Index), "Home");
			}
		}
	}
}
