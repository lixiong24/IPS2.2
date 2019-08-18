using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using JX.Application;
using JX.Core.Entity;
using JX.Infrastructure;
using JX.Infrastructure.Common;
using JX.Infrastructure.Framework.Authorize;
using JXWebHost.Areas.Admin.Models.UserViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JXWebHost.Areas.Admin.Controllers
{
	[Area("Admin")]
	[AdminAuthorize]
	public class UserController : Controller
    {
		private IUsersServiceApp _UsersService;
		private IUserGroupsServiceApp _UserGroupsService;
		public UserController(IUsersServiceApp UsersService, IUserGroupsServiceApp UserGroupsService)
		{
			_UsersService = UsersService;
			_UserGroupsService = UserGroupsService;
		}

		public IActionResult Index()
        {
            return View();
        }

		#region 会员列表
		public IActionResult GetUserList()
		{
			int PageNum = Utility.Query("PageNum", 0);
			int PageSize = Utility.Query("PageSize", 10);
			int GroupID = Utility.Query("GroupID", 0);
			string SearchName = Utility.Query("SearchName");
			string SearchKeyword = Utility.Query("SearchKeyword");
			int TabStatus = Utility.Query("TabStatus", 0);
			string filter = " 1=1 ";
			if (GroupID != 0)
			{
				filter += " and GroupID = " + GroupID;
			}
			if (!string.IsNullOrEmpty(SearchKeyword))
			{
				filter += " and " + SearchName + " like '%" + DataSecurity.FilterBadChar(SearchKeyword) + "%'";
			}

			string strColumn = "";
			int RecordTotal;
			var result = _UsersService.GetList(PageNum * PageSize, PageSize, "UserID", strColumn, "desc", filter, "", out RecordTotal);
			PagerModel<UsersEntity> pagerModel = new PagerModel<UsersEntity>(PageNum, PageSize, RecordTotal, result);
			return Json(pagerModel);
		}

		public IActionResult SelectUser()
		{
			var result = _UserGroupsService.LoadListAll(p => true);
			return View(result);
		}
		#endregion

		#region 会员组列表
		[AdminAuthorize(Roles = "SuperAdmin,UserGroupManage")]
		public IActionResult UserGroupManage()
		{
			return View();
		}

		[AdminAuthorize(Roles = "SuperAdmin,UserGroupManage")]
		public IActionResult GetUserGroupManage()
		{
			int PageNum = Utility.Query("PageNum", 0);
			int PageSize = Utility.Query("PageSize", 10);
			string filter = " 1=1 ";
			int RecordTotal;
			var result = _UserGroupsService.GetList(PageNum * PageSize, PageSize, "GroupID", "", "asc", filter, "", out RecordTotal);
			_UserGroupsService.CountUserNumber(result);
			PagerModel<UserGroupsEntity> pagerModel = new PagerModel<UserGroupsEntity>(PageNum, PageSize, RecordTotal, result);
			return Json(pagerModel);
		}
		public IActionResult GetUserGroupsList()
		{
			var list = _UserGroupsService.LoadListAll(p => true);
			return Json(list);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,UserGroupManage")]
		public IActionResult DelUserGroup(int id)
		{
			if (id <= 0)
			{
				return Json(new
				{
					Result = "删除失败！没有指定要删除的记录ID！"
				});
			}
			try
			{
				if (_UserGroupsService.Delete(p=>p.GroupID==id))
				{
					return Json(new
					{
						Result = "ok"
					});
				}
				else
				{
					return Json(new
					{
						Result = "删除失败！"
					});
				}
			}
			catch (Exception ex)
			{
				return Json(new
				{
					Result = "删除失败！" + ex.Message
				});
			}
		}
		#endregion

		#region 会员组编辑
		[AdminAuthorize(Roles = "SuperAdmin,UserGroupManage")]
		public IActionResult UserGroupEdit(int id = 0)
		{
			var model = new UserGroupsEntity();
			model.GroupID = id;
			if (id == -2)
			{
				Utility.WriteMessage("匿名用户组不能编辑", "mClose");
				return View(model);
			}
			if (id <= 0)
				return View(model);
			model = _UserGroupsService.Get(p => p.GroupID == id);
			if (model == null || model.GroupID <= 0)
				return View(model);
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,UserGroupManage")]
		public async Task<ActionResult> UserGroupEdit(int id = 0, UserGroupsEntity model = null, IFormCollection collection = null)
		{
			if (id == -2)
			{
				ModelState.AddModelError(string.Empty, "匿名用户组不能编辑");
				return View(model);
			}
			if (string.IsNullOrWhiteSpace(model.GroupName))
			{
				ModelState.AddModelError(string.Empty, "会员组名称不能为空");
				return View(model);
			}
			if (string.IsNullOrWhiteSpace(model.Description))
			{
				model.Description = "";
			}
			if (id <= 0)
			{
				#region 添加
				if (!await _UserGroupsService.AddAsync(model))
				{
					ModelState.AddModelError(string.Empty, "添加失败");
					return View(model);
				}
				id = model.GroupID;
				#endregion
			}
			else
			{
				#region 修改
				model.GroupID = id;
				if (!await _UserGroupsService.UpdateAsync(model))
				{
					ModelState.AddModelError(string.Empty, "修改失败");
					return View(model);
				}
				#endregion
			}
			return RedirectToAction("UserGroupPermissions", new { id = id, groupName = model.GroupName });
		}
		#endregion

		#region 会员组-菜单权限设置
		[AdminAuthorize(Roles = "SuperAdmin,UserGroupManage")]
		public async Task<ActionResult> UserGroupPermissions(int id = 0, string groupName = "")
		{
			UserGroupPermissionsViewModels permissionsViewModels = new UserGroupPermissionsViewModels();
			if (id <= 0 && id != -2)
			{
				Utility.WriteMessage("权限配置必须指定会员组", "mClose");
				return View(permissionsViewModels);
			}
			var model = await _UserGroupsService.GetAsync(p => p.GroupID == id);
			if (model == null)
			{
				Utility.WriteMessage("指定的会员组不存在", "mClose");
				return View(permissionsViewModels);
			}
			ViewBag.ID = id;
			ViewBag.Name = model.GroupName;

			string userMenuPath = Utility.GetUserMenuPath();
			XmlHelper xmlHelper = XmlHelper.Instance(FileHelper.MapPath(userMenuPath), XmlType.File);
			XmlDocument xmlDoc = xmlHelper.XmlDoc;
			XmlNode rootNode = xmlDoc.SelectSingleNode("menu");
			if (rootNode == null)
			{
				Utility.WriteMessage("菜单配置文件不存在menu根元素", "mClose");
				return View(permissionsViewModels);
			}
			if (rootNode.HasChildNodes)
			{
				IList<MenuEntity> menuEntityList = new List<MenuEntity>();
				foreach (XmlNode channelMenuNode in rootNode)
				{
					string operateCode = XmlHelper.GetAttributesValue(channelMenuNode, "operateCode");
					string NodeName = channelMenuNode.Name;
					string menuID = XmlHelper.GetAttributesValue(channelMenuNode, "id");
					string title = XmlHelper.GetAttributesValue(channelMenuNode, "title");
					string Description = XmlHelper.GetAttributesValue(channelMenuNode, "Description");
					string rightUrl = XmlHelper.GetAttributesValue(channelMenuNode, "rightUrl");
					string MenuType = XmlHelper.GetAttributesValue(channelMenuNode, "type");
					string MenuIcon = XmlHelper.GetAttributesValue(channelMenuNode, "icon");
					bool ShowOnForm = DataConverter.CBoolean(XmlHelper.GetAttributesValue(channelMenuNode, "ShowOnForm"));
					bool ShowOnMenu = DataConverter.CBoolean(XmlHelper.GetAttributesValue(channelMenuNode, "ShowOnMenu"));
					if (!ShowOnForm)
						continue;
					MenuEntity menuEntity = new MenuEntity
					{
						NodeName = NodeName,
						ID = menuID,
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
				permissionsViewModels.MenuEntityList = menuEntityList;
				permissionsViewModels.GroupPermissionsList = "";//DataConverter.ToString(model.UserGroupPurview.AllCheckCode);
				return View(permissionsViewModels);
			}
			return View(permissionsViewModels);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,UserGroupManage")]
		public async Task<ActionResult> UserGroupPermissions(int id, IFormCollection collection)
		{
			if (id <= 0 && id != -2)
			{
				Utility.WriteMessage("权限配置必须指定会员组", "mClose");
				return Content("");
			}
			if (id == 0)
			{
				Utility.WriteMessage("超级管理员不用设置权限", "mClose");
				return Content("");
			}
			var ModelPurview = collection["ModelPurview"];
			//if (await _RolesService.AddPermissionToRoles(id, ModelPurview))
			//{
			//	Utility.WriteMessage("设置权限成功", "mRefresh");
			//}
			//else
			//{
			//	Utility.WriteMessage("设置权限失败", "mClose");
			//}
			return Content("");
		}
		#endregion

		#region 辅助方法
		private IList<MenuEntity> InitSubMenu(XmlNode channelMenuNode)
		{
			IList<MenuEntity> menuEntityList = new List<MenuEntity>();
			if (channelMenuNode == null || !channelMenuNode.HasChildNodes)
				return menuEntityList;

			foreach (XmlNode menuNode in channelMenuNode)
			{
				string operateCode = XmlHelper.GetAttributesValue(menuNode, "operateCode");
				string NodeName = menuNode.Name;
				string id = XmlHelper.GetAttributesValue(menuNode, "id");
				string title = XmlHelper.GetAttributesValue(menuNode, "title");
				string Description = XmlHelper.GetAttributesValue(menuNode, "Description");
				string rightUrl = XmlHelper.GetAttributesValue(menuNode, "rightUrl");
				string MenuType = XmlHelper.GetAttributesValue(menuNode, "type");
				string MenuIcon = XmlHelper.GetAttributesValue(channelMenuNode, "icon");
				bool ShowOnForm = DataConverter.CBoolean(XmlHelper.GetAttributesValue(menuNode, "ShowOnForm"));
				bool ShowOnMenu = DataConverter.CBoolean(XmlHelper.GetAttributesValue(menuNode, "ShowOnMenu"));
				if (!ShowOnForm)
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
				if (menuNode.HasChildNodes)
				{
					subMenuEntity.MenuItem = InitSubMenu(menuNode);
				}
				menuEntityList.Add(subMenuEntity);
			}
			return menuEntityList;
		}
		#endregion
	}
}