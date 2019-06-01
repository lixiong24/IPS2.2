using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Application;
using JX.Infrastructure;
using JX.Infrastructure.Common;
using JX.Infrastructure.Framework.Authorize;
using JXWebHost.Areas.Admin.Models.SiteConfigViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JXWebHost.Areas.Admin.Controllers
{
	[Area("Admin")]
	[AdminAuthorize]
	public class SiteConfigController : Controller
    {
		private IUserGroupsServiceApp _UserGroupsService;
		public SiteConfigController(IUserGroupsServiceApp UserGroupsService)
		{
			_UserGroupsService = UserGroupsService;
		}

		public ActionResult Index()
        {
			SiteConfigViewModel model = new SiteConfigViewModel();
			model.SiteConfigEntity = ConfigHelper.Get<SiteConfig>();
			return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SiteConfigViewModel model)
        {
            try
            {
				if (!ModelState.IsValid)
				{
					ModelState.AddModelError(string.Empty, "验证未通过");
					return View(model);
				}
				if(model.SiteConfigEntity != null)
				{
					ConfigHelper.Save(model.SiteConfigEntity);
					Utility.WriteMessage("保存成功", "/admin/SiteConfig/index");
				}
				else
				{
					Utility.WriteMessage("保存失败", "/admin/SiteConfig/index");
				}
				return View();
			}
            catch
            {
                return View();
            }
        }

		public ActionResult SiteOption()
		{
			SiteConfigViewModel model = new SiteConfigViewModel();
			model.SiteOptionConfigEntity = ConfigHelper.Get<SiteOptionConfig>();
			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult SiteOption(SiteConfigViewModel model)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					ModelState.AddModelError(string.Empty, "验证未通过");
					return View(model);
				}
				if (model.SiteOptionConfigEntity != null)
				{
					ConfigHelper.Save(model.SiteOptionConfigEntity);
					Utility.WriteMessage("保存成功", "/admin/SiteConfig/SiteOption");
				}
				else
				{
					Utility.WriteMessage("保存失败", "/admin/SiteConfig/SiteOption");
				}
				
				return View();
			}
			catch
			{
				return View();
			}
		}

		public ActionResult UserConfig()
		{
			SiteConfigViewModel model = new SiteConfigViewModel();
			model.UserConfigEntity = ConfigHelper.Get<UserConfig>();

			var userGroupsList = _UserGroupsService.LoadListAll(p => p.GroupID > 0);
			var selectList = new SelectList(userGroupsList, "GroupID", "GroupName");
			var selectItemList = new List<SelectListItem>();
			selectItemList.AddRange(selectList);
			ViewBag.GroupsList = selectItemList;
			ViewBag.PointName = model.UserConfigEntity.PointName;
			ViewBag.PointUnit = model.UserConfigEntity.PointUnit;
			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult UserConfig(SiteConfigViewModel model)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					ModelState.AddModelError(string.Empty, "验证未通过");
					return View(model);
				}
				if (model.UserConfigEntity != null)
				{
					ConfigHelper.Save(model.UserConfigEntity);
					Utility.WriteMessage("保存成功", "/admin/SiteConfig/UserConfig");
				}
				else
				{
					Utility.WriteMessage("保存失败", "/admin/SiteConfig/UserConfig");
				}
				
				return View();
			}
			catch
			{
				return View();
			}
		}

		public ActionResult UpLoadFilesConfig()
		{
			SiteConfigViewModel model = new SiteConfigViewModel();
			model.UploadFilesConfigEntity = ConfigHelper.Get<UploadFilesConfig>();
			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult UpLoadFilesConfig(SiteConfigViewModel model)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					ModelState.AddModelError(string.Empty, "验证未通过");
					return View(model);
				}
				if (model.UploadFilesConfigEntity != null)
				{
					ConfigHelper.Save(model.UploadFilesConfigEntity);
					Utility.WriteMessage("保存成功", "/admin/SiteConfig/UpLoadFilesConfig");
				}
				else
				{
					Utility.WriteMessage("保存失败", "/admin/SiteConfig/UpLoadFilesConfig");
				}
				
				return View();
			}
			catch
			{
				return View();
			}
		}

		public ActionResult MailConfig()
		{
			SiteConfigViewModel model = new SiteConfigViewModel();
			model.MailConfigEntity = ConfigHelper.Get<MailConfig>();
			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult MailConfig(SiteConfigViewModel model)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					ModelState.AddModelError(string.Empty, "验证未通过");
					return View(model);
				}
				if (model.MailConfigEntity != null)
				{
					ConfigHelper.Save(model.MailConfigEntity);
					Utility.WriteMessage("保存成功", "/admin/SiteConfig/MailConfig");
				}
				else
				{
					Utility.WriteMessage("保存失败", "/admin/SiteConfig/MailConfig");
				}
				
				return View();
			}
			catch
			{
				return View();
			}
		}

		public ActionResult ThumbConfig()
		{
			SiteConfigViewModel model = new SiteConfigViewModel();
			model.ThumbsConfigEntity = ConfigHelper.Get<ThumbsConfig>();
			model.WaterMarkConfigEntity = ConfigHelper.Get<WaterMarkConfig>();
			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ThumbConfig(SiteConfigViewModel model)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					ModelState.AddModelError(string.Empty, "验证未通过");
					return View(model);
				}
				if (model.ThumbsConfigEntity != null && model.WaterMarkConfigEntity != null)
				{
					ConfigHelper.Save(model.ThumbsConfigEntity);
					ConfigHelper.Save(model.WaterMarkConfigEntity);
					Utility.WriteMessage("保存成功", "/admin/SiteConfig/ThumbConfig");
				}
				else
				{
					Utility.WriteMessage("保存失败", "/admin/SiteConfig/ThumbConfig");
				}
				
				return View();
			}
			catch
			{
				return View();
			}
		}

		public ActionResult IPLockConfig()
		{
			SiteConfigViewModel model = new SiteConfigViewModel();
			model.IPLockConfigEntity = ConfigHelper.Get<IPLockConfig>();
			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult IPLockConfig(SiteConfigViewModel model)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					ModelState.AddModelError(string.Empty, "验证未通过");
					return View(model);
				}
				if (model.IPLockConfigEntity != null)
				{
					ConfigHelper.Save(model.IPLockConfigEntity);
					Utility.WriteMessage("保存成功", "/admin/SiteConfig/IPLockConfig");
				}
				else
				{
					Utility.WriteMessage("保存失败", "/admin/SiteConfig/IPLockConfig");
				}
				
				return View();
			}
			catch
			{
				return View();
			}
		}

		public ActionResult ShopConfig()
		{
			SiteConfigViewModel model = new SiteConfigViewModel();
			model.ShopConfigEntity = ConfigHelper.Get<ShopConfig>();
			ViewBag.Province = model.ShopConfigEntity.Province;
			ViewBag.City = model.ShopConfigEntity.City;
			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ShopConfig(SiteConfigViewModel model, IFormCollection form)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					ModelState.AddModelError(string.Empty, "验证未通过");
					return View(model);
				}
				if (model.ShopConfigEntity != null)
				{
					var ctlProvince = form["ctlProvince"];
					var ctlCity = form["ctlCity"];
					model.ShopConfigEntity.Province = ctlProvince;
					model.ShopConfigEntity.City = ctlCity;
					ConfigHelper.Save(model.ShopConfigEntity);
					Utility.WriteMessage("保存成功", "/admin/SiteConfig/ShopConfig");
				}
				else
				{
					Utility.WriteMessage("保存失败", "/admin/SiteConfig/ShopConfig");
				}

				return View();
			}
			catch
			{
				return View();
			}
		}

		public ActionResult ShopTemplateConfig()
		{
			SiteConfigViewModel model = new SiteConfigViewModel();
			model.ShopTemplateConfigEntity = ConfigHelper.Get<ShopTemplateConfig>();
			ViewBag.OrderFormat = model.ShopTemplateConfigEntity.OrderFormat.Replace("\r\n","").Replace("\"", "\\\"");
			ViewBag.ConsignmentFormat = model.ShopTemplateConfigEntity.ConsignmentFormat.Replace("\r\n", "").Replace("\"", "\\\"");
			ViewBag.FillProductFormat = model.ShopTemplateConfigEntity.FillProductFormat.Replace("\r\n", "").Replace("\"", "\\\"");
			return View(model);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult ShopTemplateConfig(SiteConfigViewModel model, IFormCollection form)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					ModelState.AddModelError(string.Empty, "验证未通过");
					return View(model);
				}
				if (model.ShopTemplateConfigEntity != null)
				{
					var ctlOrderFormat = form["ctlOrderFormat"];
					var ctlConsignmentFormat = form["ctlConsignmentFormat"];
					var ctlFillProductFormat = form["ctlFillProductFormat"];
					model.ShopTemplateConfigEntity.OrderFormat = ctlOrderFormat;
					model.ShopTemplateConfigEntity.ConsignmentFormat = ctlConsignmentFormat;
					model.ShopTemplateConfigEntity.FillProductFormat = ctlFillProductFormat;
					ConfigHelper.Save(model.ShopTemplateConfigEntity);
					Utility.WriteMessage("保存成功", "/admin/SiteConfig/ShopTemplateConfig");
				}
				else
				{
					Utility.WriteMessage("保存失败", "/admin/SiteConfig/ShopTemplateConfig");
				}

				return View();
			}
			catch
			{
				return View();
			}
		}
	}
}