using JX.Application;
using JX.Core.Entity;
using JX.Infrastructure;
using JX.Infrastructure.Common;
using JX.Infrastructure.Framework.Authorize;
using JXWebHost.Areas.Admin.Models.HomeViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml;

namespace JXWebHost.Areas.Admin.Controllers
{
	[Area("Admin")]
	[AdminAuthorize]
	public class HomeController : Controller
    {
		private IAdminServiceApp _AdminService;
		public HomeController(IAdminServiceApp adminService)
		{
			_AdminService = adminService;
		}

		#region 登录/退出
		[HttpGet]
		[AllowAnonymous]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError(string.Empty, "验证未通过");
				return View(model);
			}
			string code = DataConverter.ToString(Utility.GetSession("LoginValidateCode"));
			if (string.Compare(model.ValidateCode, code, true) != 0)
			{
				ModelState.AddModelError(string.Empty, "验证码不对");
				return View(model);
			}
			var identityResult = await _AdminService.Login(model.AdminName,model.AdminPassword);
			if (!identityResult.IsSuccess)
			{
				ModelState.AddModelError(string.Empty, identityResult.ErrorString);
				return View(model);
			}
			//signin 
			var authenticationProperties = new AuthenticationProperties();
			authenticationProperties.IsPersistent = false;
			authenticationProperties.AllowRefresh = false;
			if (ConfigHelper.Get<SiteOptionConfig>().TicketTime > 0)
			{
				authenticationProperties.ExpiresUtc = DateTime.UtcNow.AddMinutes((double)ConfigHelper.Get<SiteOptionConfig>().TicketTime);
			}
			await HttpContext.SignInAsync(AdminAuthorizeAttribute.AdminAuthenticationScheme, identityResult.User, authenticationProperties);
			return RedirectToAction("Index", "Home");
		}

		public async Task<IActionResult> Logout()
		{
			await _AdminService.Logout(User);
			await HttpContext.SignOutAsync(AdminAuthorizeAttribute.AdminAuthenticationScheme);

			return RedirectToAction("Login", "Home");
		}
		#endregion

		#region 首页/修改密码
		public IActionResult Index()
        {
			ViewData["Title"] = ConfigHelper.Get<SiteConfig>().SiteName;
			ViewData["AdminName"] = User.FindFirst(ClaimTypes.Name).Value;
			string adminMenuPath = Utility.GetAdminMenuPath();
			XmlHelper xmlHelper = XmlHelper.Instance(FileHelper.MapPath(adminMenuPath),XmlType.File);
			XmlDocument xmlDoc = xmlHelper.XmlDoc;
			XmlNode rootNode = xmlDoc.SelectSingleNode("menu");
			if (rootNode == null)
			{
				Utility.WriteMessage("菜单配置文件不存在menu根元素", "/admin/home/login");
				return View();
			}
			if(rootNode.HasChildNodes)
			{
				IList<MenuEntity> menuEntityList = new List<MenuEntity>();
				foreach (XmlNode channelMenuNode in rootNode)
				{
					string operateCode = XmlHelper.GetAttributesValue(channelMenuNode, "operateCode");
					if (Utility.AccessCheck(User,operateCode))
					{
						string NodeName = channelMenuNode.Name;
						string id = XmlHelper.GetAttributesValue(channelMenuNode, "id");
						string title = XmlHelper.GetAttributesValue(channelMenuNode, "title");
						string Description = XmlHelper.GetAttributesValue(channelMenuNode, "Description");
						string rightUrl = XmlHelper.GetAttributesValue(channelMenuNode, "rightUrl");
						string MenuType = XmlHelper.GetAttributesValue(channelMenuNode, "type");
						string MenuIcon = XmlHelper.GetAttributesValue(channelMenuNode, "icon");
						bool ShowOnForm = DataConverter.CBoolean(XmlHelper.GetAttributesValue(channelMenuNode, "ShowOnForm"));
						bool ShowOnMenu = DataConverter.CBoolean(XmlHelper.GetAttributesValue(channelMenuNode, "ShowOnMenu"));
						if (!ShowOnMenu)
							continue;
						MenuEntity menuEntity = new MenuEntity
						{
							NodeName = NodeName,
							ID = id,
							Title = title,
							OperateCode = operateCode,
							Description = Description,
							Url = rightUrl,
							MenuType = MenuType,
							MenuIcon = MenuIcon,
							ShowOnForm = ShowOnForm,
							ShowOnMenu = ShowOnMenu
						};
						menuEntity.MenuItem = InitSubMenu(channelMenuNode);
						menuEntityList.Add(menuEntity);
					}
				}
				return View(menuEntityList);
			}
			return View();
        }

		public IActionResult Welcome()
		{
			return View();
		}

		[HttpGet]
		public IActionResult ModifyPassword()
		{
            return View();
		}
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModifyPassword(ModifyPasswordViewModel model)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError(string.Empty, "验证未通过");
				return View(model);
			}
			string result = await _AdminService.ModifyPassword(User,model.OldPwd,model.NewPwd);
			if (result == "ok")
			{
				Utility.WriteMessage("修改密码成功", "/admin/home/modifypassword");
				return View();
			}
			ModelState.AddModelError(string.Empty, result);
			return View(model);
		}
		#endregion

		public IActionResult ShowMessage()
		{
			ViewData["Title"] = Utility.GetSession("MessageTitle","消息提示");
			ViewData["Message"] = Utility.GetSession("Message", "未知错误");
			string strReturnUrl = Utility.GetSession("ReturnUrl","");
			string strReturnUrlText = "返回上一页";
			//string strJS = "setTimeout(\"{0}\", 3000);";
			string strJS = "{0}";
			switch (strReturnUrl)
			{
				case "mClose":
					strReturnUrlText = "关闭";
					strReturnUrl = "javascript:layer_close();";
					strJS = string.Format(strJS, strReturnUrl);
					break;
				case "mRefresh":
					strReturnUrlText = "关闭";
					strReturnUrl = "javascript:HuiRefresh();";
					strJS = string.Format(strJS, strReturnUrl);
					break;
				default:
					if (string.IsNullOrEmpty(strReturnUrl))
					{
						if (string.IsNullOrEmpty(MyHttpContext.Current.Request.Headers["Referer"].ToString()))
						{
							strReturnUrlText = "关闭";
							strReturnUrl = "javascript:window.close();";
							strJS = string.Format(strJS, strReturnUrl);
						}
						else
						{
							strReturnUrl = "javascript:history.back();";
							strJS = string.Format(strJS, strReturnUrl);
						}
					}
					else
					{
						if ((strReturnUrl.StartsWith("http://", StringComparison.CurrentCultureIgnoreCase) || strReturnUrl.StartsWith("https://", StringComparison.CurrentCultureIgnoreCase)))
						{
							strJS = string.Format(strJS, "javascript:GoToUrl();");
						}
						else if (strReturnUrl.StartsWith("javascript:", StringComparison.CurrentCultureIgnoreCase))
						{
							strJS = string.Format(strJS, strReturnUrl);
						}
						else
						{
							strJS = string.Format(strJS, "javascript:GoToUrl();");
						}
					}
					break;
			}
			ViewData["ReturnUrl"] = strReturnUrl;
			ViewData["ReturnUrlText"] = strReturnUrlText;
			ViewData["ReturnJS"] = strJS;
			Utility.RemoveSession("MessageTitle");
			Utility.RemoveSession("Message");
			Utility.RemoveSession("ReturnUrl");
			return View();
		}
		public IActionResult Forbidden()
		{
			return View();
		}
		#region 辅助方法
		private IList<MenuEntity> InitSubMenu(XmlNode channelMenuNode)
		{
			IList<MenuEntity> menuEntityList = new List<MenuEntity>();
			if (channelMenuNode == null || !channelMenuNode.HasChildNodes)
				return menuEntityList;
			
			foreach (XmlNode menuNode in channelMenuNode)
			{
				string operateCode = XmlHelper.GetAttributesValue(menuNode, "operateCode");
				if (Utility.AccessCheck(User, operateCode))
				{
					string NodeName = menuNode.Name;
					string id = XmlHelper.GetAttributesValue(menuNode, "id");
					string title = XmlHelper.GetAttributesValue(menuNode, "title");
					string Description = XmlHelper.GetAttributesValue(menuNode, "Description");
					string rightUrl = XmlHelper.GetAttributesValue(menuNode, "rightUrl");
					string MenuType = XmlHelper.GetAttributesValue(menuNode, "type");
					string MenuIcon = XmlHelper.GetAttributesValue(channelMenuNode, "icon");
					bool ShowOnForm = DataConverter.CBoolean(XmlHelper.GetAttributesValue(menuNode, "ShowOnForm"));
					bool ShowOnMenu = DataConverter.CBoolean(XmlHelper.GetAttributesValue(menuNode, "ShowOnMenu"));
					if (!ShowOnMenu)
						continue;
					MenuEntity subMenuEntity = new MenuEntity
					{
						NodeName = NodeName,
						ID = id,
						Title = title,
						OperateCode = operateCode,
						Description = Description,
						Url = rightUrl,
						MenuType = MenuType,
						MenuIcon = MenuIcon,
						ShowOnForm = ShowOnForm,
						ShowOnMenu = ShowOnMenu
					};
					menuEntityList.Add(subMenuEntity);
				}
			}
			return menuEntityList;
		}
		#endregion
	}
}
