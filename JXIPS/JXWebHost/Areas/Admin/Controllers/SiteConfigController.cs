using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JX.Application;
using JX.Core.Entity;
using JX.Infrastructure;
using JX.Infrastructure.Common;
using JX.Infrastructure.Framework.Authorize;
using JX.Infrastructure.Log;
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
		private ILogServiceApp _LogService;
		public SiteConfigController(IUserGroupsServiceApp UserGroupsService, ILogServiceApp LogService)
		{
			_UserGroupsService = UserGroupsService;
			_LogService = LogService;
		}

		#region 网站参数配置
		[AdminAuthorize(Roles = "SuperAdmin,SiteInfo")]
		public ActionResult Index()
        {
			SiteConfigViewModel model = new SiteConfigViewModel();
			model.SiteConfigEntity = ConfigHelper.Get<SiteConfig>();
			return View(model);
        }
		[AdminAuthorize(Roles = "SuperAdmin,SiteInfo")]
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

		[AdminAuthorize(Roles = "SuperAdmin,SiteOption")]
		public ActionResult SiteOption()
		{
			SiteConfigViewModel model = new SiteConfigViewModel();
			model.SiteOptionConfigEntity = ConfigHelper.Get<SiteOptionConfig>();
			return View(model);
		}
		[AdminAuthorize(Roles = "SuperAdmin,SiteOption")]
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

		[AdminAuthorize(Roles = "SuperAdmin,UserConfig")]
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
		[AdminAuthorize(Roles = "SuperAdmin,UserConfig")]
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

		[AdminAuthorize(Roles = "SuperAdmin,UpLoadFilesConfig")]
		public ActionResult UpLoadFilesConfig()
		{
			SiteConfigViewModel model = new SiteConfigViewModel();
			model.UploadFilesConfigEntity = ConfigHelper.Get<UploadFilesConfig>();
			return View(model);
		}
		[AdminAuthorize(Roles = "SuperAdmin,UpLoadFilesConfig")]
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

		[AdminAuthorize(Roles = "SuperAdmin,MailConfig")]
		public ActionResult MailConfig()
		{
			SiteConfigViewModel model = new SiteConfigViewModel();
			model.MailConfigEntity = ConfigHelper.Get<MailConfig>();
			return View(model);
		}
		[AdminAuthorize(Roles = "SuperAdmin,MailConfig")]
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

		[AdminAuthorize(Roles = "SuperAdmin,ThumbConfig")]
		public ActionResult ThumbConfig()
		{
			SiteConfigViewModel model = new SiteConfigViewModel();
			model.ThumbsConfigEntity = ConfigHelper.Get<ThumbsConfig>();
			model.WaterMarkConfigEntity = ConfigHelper.Get<WaterMarkConfig>();
			return View(model);
		}
		[AdminAuthorize(Roles = "SuperAdmin,ThumbConfig")]
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

		[AdminAuthorize(Roles = "SuperAdmin,IPLockConfig")]
		public ActionResult IPLockConfig()
		{
			SiteConfigViewModel model = new SiteConfigViewModel();
			model.IPLockConfigEntity = ConfigHelper.Get<IPLockConfig>();
			return View(model);
		}
		[AdminAuthorize(Roles = "SuperAdmin,IPLockConfig")]
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

		[AdminAuthorize(Roles = "SuperAdmin,ShopConfig")]
		public ActionResult ShopConfig()
		{
			SiteConfigViewModel model = new SiteConfigViewModel();
			model.ShopConfigEntity = ConfigHelper.Get<ShopConfig>();
			ViewBag.Province = model.ShopConfigEntity.Province;
			ViewBag.City = model.ShopConfigEntity.City;
			return View(model);
		}
		[AdminAuthorize(Roles = "SuperAdmin,ShopConfig")]
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

		[AdminAuthorize(Roles = "SuperAdmin,ShopTemplateConfig")]
		public ActionResult ShopTemplateConfig()
		{
			SiteConfigViewModel model = new SiteConfigViewModel();
			model.ShopTemplateConfigEntity = ConfigHelper.Get<ShopTemplateConfig>();
			ViewBag.OrderFormat = model.ShopTemplateConfigEntity.OrderFormat;
			ViewBag.ConsignmentFormat = model.ShopTemplateConfigEntity.ConsignmentFormat;
			ViewBag.FillProductFormat = model.ShopTemplateConfigEntity.FillProductFormat;
			return View(model);
		}
		[AdminAuthorize(Roles = "SuperAdmin,ShopTemplateConfig")]
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
		#endregion

		#region 日志管理
		[AdminAuthorize(Roles = "SuperAdmin,LogManager")]
		public ActionResult LogManager()
		{
			return View();
		}

		[AdminAuthorize(Roles = "SuperAdmin,LogManager")]
		public IActionResult GetLogManager()
		{
			int PageNum = Utility.Query("PageNum", 0);
			int PageSize = Utility.Query("PageSize", 10);
			string SearchName = Utility.Query("SearchName");
			string SearchKeyword = Utility.Query("SearchKeyword");
			int TabStatus = Utility.Query("TabStatus", -1);
			string filter = " 1=1 ";
			if (!string.IsNullOrEmpty(SearchKeyword))
			{
				filter += " and " + SearchName + " like '%" + DataSecurity.FilterBadChar(SearchKeyword) + "%'";
			}
			if (TabStatus >= 0)
			{
				filter += " and Category = " + TabStatus;
			}
			string strColumn = "LogID,Category,Priority,Title,Timestamp,UserName,UserIP,ScriptName";
			int RecordTotal;
			var result = _LogService.GetList(PageNum * PageSize, PageSize, "LogID", strColumn, "desc", filter, "", out RecordTotal);
			PagerModel<LogEntity> pagerModel = new PagerModel<LogEntity>(PageNum, PageSize, RecordTotal, result);
			return Json(pagerModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,LogManager")]
		public IActionResult DelLogMulti(string ids)
		{
			if (string.IsNullOrEmpty(ids))
			{
				return Json(new
				{
					Result = "删除失败！没有指定要删除的记录ID！"
				});
			}
			try
			{
				_LogService.BatchDel(ids);
				return Json(new
				{
					Result = "ok"
				});
			}
			catch (Exception ex)
			{
				return Json(new
				{
					Result = "删除失败！" + ex.Message
				});
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,LogManager")]
		public IActionResult DelLogAll()
		{
			try
			{
				_LogService.SaveLog("清空日志！保留最后两天的日志内容！", "清空日志！保留最后两天的日志内容！", User.FindFirst(ClaimTypes.Name).Value);
				_LogService.BatchDel(DateTime.Today.AddDays(-2.0));
				return Json(new
				{
					Result = "ok"
				});
			}
			catch (Exception ex)
			{
				return Json(new
				{
					Result = "删除失败！" + ex.Message
				});
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,LogManager")]
		public IActionResult OffSetDelLog(int OffSet,int LogCategory)
		{
			if (OffSet == 0)
			{
				return Json(new
				{
					Result = "请选择你要进行的操作！"
				});
			}
			try
			{
				string strOffSet = "";
				switch (OffSet)
				{
					case -7:
						strOffSet = "一个星期前的";
						break;
					case -15:
						strOffSet = "半个月前的";
						break;
					case -30:
						strOffSet = "一个月前的";
						break;
					case 1:
						strOffSet = "最后一万条";
						break;
					case 10:
						strOffSet = "最后十万条";
						break;
				}
				string strLogCategory = EnumHelper.GetDescription((LogCategory)LogCategory);
				string strLogTitle = "删除"+ strOffSet + strLogCategory + "日志";
				_LogService.SaveLog(strLogTitle, strLogTitle, User.FindFirst(ClaimTypes.Name).Value);
				if(OffSet == 1)
				{
					_LogService.BatchDel(10000,LogCategory);
				}
				else if(OffSet == 10)
				{
					_LogService.BatchDel(100000, LogCategory);
				}
				else
				{
					_LogService.BatchDel(DateTime.Today.AddDays(OffSet), LogCategory);
				}
				return Json(new
				{
					Result = "ok"
				});
			}
			catch (Exception ex)
			{
				return Json(new
				{
					Result = "删除失败！" + ex.Message
				});
			}
		}

		[AdminAuthorize(Roles = "SuperAdmin,LogManager")]
		public IActionResult ViewLog(int id = 0)
		{
			var entity = _LogService.Get(p => p.LogID == id);
			return View(entity);
		}
		#endregion
	}
}