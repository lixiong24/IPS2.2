using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JX.Infrastructure.Framework.Authorize;
using JX.Application;
using JX.Infrastructure;
using JX.Infrastructure.Common;
using JXWebHost.Areas.Admin.Models.AdministratorViewModels;
using System.Xml;
using JX.Core.Entity;
using System.Security.Claims;
using System.Linq.Expressions;
using JX.Infrastructure.Data;
using JX.Infrastructure.Field;

namespace JXWebHost.Areas.Admin.Controllers
{
	[Area("Admin")]
	[AdminAuthorize]
	public class AdministratorController : Controller
    {
		private IAdminServiceApp _AdminService;
		private IRolesServiceApp _RolesService;
		private INodesServiceApp _NodesService;
		private IModelsServiceApp _ModelsService;
		public AdministratorController(IAdminServiceApp AdminService, 
			IRolesServiceApp RolesService, 
			INodesServiceApp NodesService,
			IModelsServiceApp ModelsService)
		{
			_AdminService = AdminService;
			_RolesService = RolesService;
			_NodesService = NodesService;
			_ModelsService = ModelsService;
		}

		#region 管理员列表
		[AdminAuthorize(Roles = "SuperAdmin,AdministratorManage")]
		public ActionResult Index()
        {
			var rolesList = _RolesService.LoadListAll(p=>1==1);
			return View(rolesList);
        }

		[AdminAuthorize(Roles = "SuperAdmin,AdministratorManage")]
		public IActionResult GetAdminList()
		{
			int PageNum = Utility.Query("PageNum", 0);
			int PageSize = Utility.Query("PageSize", 10);
			int RoleID = Utility.Query("RoleID",-1);
			string SearchName = Utility.Query("SearchName");
			string SearchKeyword = Utility.Query("SearchKeyword");
			int TabStatus = Utility.Query("TabStatus",0);
			string filter = " 1=1 ";
			if (RoleID > -1)
			{
				filter += " and AdminID IN (SELECT JXAR.AdminID FROM AdminRoles AS JXAR WHERE (JXAR.RoleID = " + RoleID + ")) ";
			}
			if (!string.IsNullOrEmpty(SearchKeyword))
			{
				filter += " and "+ SearchName + " like '%"+DataSecurity.FilterBadChar(SearchKeyword) +"%'";
			}
			switch (TabStatus)
			{
				case 1:
					filter += " and (DATEDIFF(d, ModifyPasswordTime, GETDATE()) > 30 OR ModifyPasswordTime IS NULL) ";
					break;

				case 2:
					filter += " and DATEDIFF(hh, LoginTime, GETDATE()) < 25";
					break;

				case 3:
					filter += " and IsLock = 1";
					break;

				case 4:
					filter += " and IsMultiLogin = 1";
					break;
			}
			int RecordTotal;
			var adminList = _AdminService.GetListFull(PageNum, PageSize, filter, out RecordTotal);
			PagerModel<AdminEntity> pagerModel = new PagerModel<AdminEntity>(PageNum, PageSize, RecordTotal, adminList);
			return Json(pagerModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,AdministratorManage")]
		public IActionResult DelAdmin(int id)
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
				if(_AdminService.DelAdminFull(User,id))
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
					Result = "删除失败！"+ ex.Message
				});
			}
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,AdministratorManage")]
		public IActionResult DelAdminMulti(string ids)
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
				_AdminService.BatchDel(User, ids);
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
		[AdminAuthorize(Roles = "SuperAdmin,AdministratorManage")]
		public IActionResult SetAdminStatus(int id)
		{
			if (id <= 0)
			{
				return Json(new
				{
					Result = "操作失败！没有指定要操作的记录ID！"
				});
			}
			try
			{
				string currentID = User.FindFirst(ClaimTypes.Sid).Value;
				if (DataConverter.CLng(currentID) == id)
				{
					return Json(new
					{
						Result = "操作失败！不能对自己进行操作！"
					});
				}
				if (_AdminService.SetAdminStatus(id))
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
						Result = "操作失败！"
					});
				}
			}
			catch (Exception ex)
			{
				return Json(new
				{
					Result = "操作失败！" + ex.Message
				});
			}
		}
		#endregion

		#region 管理员编辑
		[AdminAuthorize(Roles = "SuperAdmin,AdministratorManage")]
		public IActionResult AdminEdit(int id=0)
		{
			AdminViewModel adminViewModel = new AdminViewModel();
			adminViewModel.AdminID = 0;
			if (id <= 0)
				return View(adminViewModel);
			var admin = _AdminService.GetFull(id);
			if (admin == null || admin.AdminID <= 0)
				return View(adminViewModel);
			
			adminViewModel.AdminID = admin.AdminID;
			adminViewModel.AdminName = admin.AdminName;
			adminViewModel.UserName = admin.UserName;
			adminViewModel.IsLock = admin.IsLock;
			adminViewModel.IsModifyPassword = admin.IsModifyPassword;
			adminViewModel.IsMultiLogin = admin.IsMultiLogin;
			adminViewModel.RoleIDs = admin.RoleIDs;
			return View(adminViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,AdministratorManage")]
		public async Task<ActionResult> AdminEdit(int id, AdminViewModel adminViewModel, IFormCollection collection)
		{
			if (id <= 0)
			{
				#region 添加
				if (string.IsNullOrEmpty(adminViewModel.AdminPassword))
				{
					ModelState.AddModelError(string.Empty, "密码不能为空");
					return View(adminViewModel);
				}
				else if(adminViewModel.AdminPassword.Length < 6)
				{
					ModelState.AddModelError(string.Empty, "密码最少6位");
					return View(adminViewModel);
				}
				adminViewModel.RoleIDs = collection["RoleIDs"];
				var adminDTO = new AdminEntity();
				adminDTO.AdminName = adminViewModel.AdminName;
				adminDTO.UserName = adminViewModel.UserName;
				adminDTO.IsLock = adminViewModel.IsLock;
				adminDTO.IsModifyPassword = adminViewModel.IsModifyPassword;
				adminDTO.IsMultiLogin = adminViewModel.IsMultiLogin;
				adminDTO.AdminPassword = adminViewModel.AdminPassword;
				adminDTO.RoleIDs= collection["RoleIDs"];
				string msg = await _AdminService.AddAdminFull(adminDTO);
				if (msg != "ok")
				{
					ModelState.AddModelError(string.Empty, msg);
					return View(adminViewModel);
				}
				#endregion
			}
			else
			{
				#region 修改
				var adminDTO = _AdminService.Get(p=>p.AdminID==id);
				adminDTO.UserName = adminViewModel.UserName;
				adminDTO.IsLock = adminViewModel.IsLock;
				adminDTO.IsModifyPassword = adminViewModel.IsModifyPassword;
				adminDTO.IsMultiLogin = adminViewModel.IsMultiLogin;
				adminDTO.RoleIDs = collection["RoleIDs"];
				if (!string.IsNullOrEmpty(adminViewModel.AdminPassword))
				{
					if (adminViewModel.AdminPassword.Length < 6)
					{
						ModelState.AddModelError(string.Empty, "密码最少6位");
						return View(adminViewModel);
					}
					adminDTO.AdminPassword = StringHelper.MD5(adminViewModel.AdminPassword.Trim());
					adminDTO.ModifyPasswordTime = new DateTime?(DateTime.Now);
				}
				string msg = await _AdminService.UpdateAdminFull(adminDTO);
				if (msg != "ok")
				{
					ModelState.AddModelError(string.Empty, msg);
					return View(adminViewModel);
				}
				#endregion
			}
			adminViewModel.result = "ok";
			return View(adminViewModel);
		}
		#endregion

		#region 角色管理
		[AdminAuthorize(Roles = "SuperAdmin,AdminRoleManage")]
		public IActionResult RoleManage()
		{
			return View();
		}

		[AdminAuthorize(Roles = "SuperAdmin,AdminRoleManage")]
		public IActionResult GetRoleManage()
		{
			int PageNum = Utility.Query("PageNum", 0);
			int PageSize = Utility.Query("PageSize", 10);
			string filter = " 1=1 ";
			int RecordTotal;
			var result = _RolesService.GetList(PageNum, PageSize,"RoleID","","desc", filter,"", out RecordTotal);
			if(PageNum==0)
			{
				result.Insert(0, new RolesEntity() { RoleID = 0, RoleName = "超级管理员", Description = "拥有一切权限" });
			}
			PagerModel<RolesEntity> pagerModel = new PagerModel<RolesEntity>(PageNum, PageSize, RecordTotal, result);
			return Json(pagerModel);
		}

		[AdminAuthorize(Roles = "SuperAdmin,AdminRoleManage,AdministratorManage")]
		public IActionResult GetRoleList()
		{
			var roles = _RolesService.LoadListAll(p=>true);
			roles.Insert(0, new RolesEntity() { RoleID = 0, RoleName = "超级管理员", Description="拥有一切权限" });
			return Json(roles);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,AdminRoleManage")]
		public IActionResult DelRole(int id)
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
				if (_RolesService.DeleteFull(id))
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

		#region 角色编辑
		[AdminAuthorize(Roles = "SuperAdmin,AdminRoleManage")]
		public IActionResult RoleEdit(int id = -1)
		{
            var model = new RolesEntity();
            model.RoleID = id;
            if (id <= -1)
				return View(model);
			if(id==0)
			{
				Utility.WriteMessage("超级管理员角色不能编辑", "mClose");
				return View(model);
			}
			model = _RolesService.Get(p=>p.RoleID==id);
			if (model == null || model.RoleID <= 0)
				return View(model);
			return View(model);
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize(Roles = "SuperAdmin,AdminRoleManage")]
        public async Task<ActionResult> RoleEdit(int id=-1, RolesEntity model =null, IFormCollection collection=null)
		{
			if (id == 0)
			{
				ModelState.AddModelError(string.Empty, "超级管理员角色不能编辑");
				return View(model);
			}
			if (string.IsNullOrEmpty(model.RoleName))
			{
				ModelState.AddModelError(string.Empty, "角色名不能为空");
				return View(model);
			}
			if (string.IsNullOrEmpty(model.Description))
			{
				model.Description = "";
			}
			if (id <= 0)
			{
				#region 添加
				if (!await _RolesService.AddAsync(model))
				{
					ModelState.AddModelError(string.Empty, "添加失败");
					return View(model);
				}
				id = model.RoleID;
				#endregion
			}
			else
			{
				#region 修改
				model.RoleID = id;
				if (!await _RolesService.UpdateAsync(model))
				{
					ModelState.AddModelError(string.Empty, "修改失败");
					return View(model);
				}
				#endregion
			}
			return RedirectToAction("RolePermissions",new { id=id,roleName= model.RoleName });
		}
		#endregion

		#region 成员管理
		[AdminAuthorize(Roles = "SuperAdmin,AdminRoleManage")]
		public async Task<IActionResult> RoleMember(int id = -1, string roleName = "")
		{
			if (id <= -1)
			{
				Utility.WriteMessage("没有指定要管理的角色", "mClose");
				return View();
			}
			ViewBag.RoleName = roleName;
			RoleMemberViewModel roleMemberViewModel = new RoleMemberViewModel();
			roleMemberViewModel.MemberByRole = await _RolesService.GetMemberListByRoleID(id);
			roleMemberViewModel.MemberByNotRole = await _RolesService.GetMemberListNotInRole(id);
			return View(roleMemberViewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,AdminRoleManage")]
		public async Task<IActionResult> RoleMember(int id, IFormCollection collection)
		{
			if (id <= -1)
			{
				Utility.WriteMessage("没有指定要管理的角色", "mClose");
				return Content("");
			}
			await _RolesService.AddMembersToRole(collection["hidBelongToRole"],id);
			Utility.WriteMessage("提交成功", "mRefresh");
			return Content("");
		}
		#endregion

		#region 角色-菜单权限设置
		[AdminAuthorize(Roles = "SuperAdmin,AdminRoleManage")]
		public async Task<ActionResult> RolePermissions(int id = -1,string roleName="")
		{
			PermissionsViewModels permissionsViewModels = new PermissionsViewModels();
			if (id <= -1)
			{
				Utility.WriteMessage("权限配置必须指定角色", "mClose");
				return View(permissionsViewModels);
			}
			if (id == 0)
			{
				Utility.WriteMessage("超级管理员不用设置权限", "mClose");
				return View(permissionsViewModels);
			}
			ViewBag.RoleID = id;
			ViewBag.RoleName = roleName;

			string adminMenuPath = Utility.GetAdminMenuPath();
			XmlHelper xmlHelper = XmlHelper.Instance(FileHelper.MapPath(adminMenuPath), XmlType.File);
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
				permissionsViewModels.RolesPermissionsList = await _RolesService.GetRolesPermissionsByRoleID(id);
				return View(permissionsViewModels);
			}			
			return View(permissionsViewModels);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,AdminRoleManage")]
		public async Task<ActionResult> RolePermissions(int id,IFormCollection collection)
		{
			if (id <= -1)
			{
				Utility.WriteMessage("权限配置必须指定角色", "mClose");
				return Content("");
			}
			if (id == 0)
			{
				Utility.WriteMessage("超级管理员不用设置权限", "mClose");
				return Content("");
			}
			var ModelPurview = collection["ModelPurview"];
			await _RolesService.DeletePermissionFromRoles(id);
			if(await _RolesService.AddPermissionToRoles(id,ModelPurview))
			{
				Utility.WriteMessage("设置权限成功", "mRefresh");
			}
			else
			{
				Utility.WriteMessage("设置权限失败", "mClose");
			}
			return Content("");
		}
		#endregion

		#region 角色-节点权限设置
		[AdminAuthorize(Roles = "SuperAdmin,AdminRoleManage")]
		public async Task<ActionResult> NodePermissions(int id = -1, string PermissionsType = "Node")
		{
			NodePermissionsViewModel permissionsViewModels = new NodePermissionsViewModel();
			if (id <= -1)
			{
				Utility.WriteMessage("权限配置必须指定角色", "mClose");
				return View(permissionsViewModels);
			}
			if (id == 0)
			{
				Utility.WriteMessage("超级管理员不用设置权限", "mClose");
				return View(permissionsViewModels);
			}
			ViewBag.RoleID = id;
			ViewBag.PermissionsType = PermissionsType;

			switch (PermissionsType)
			{
				case "Node":
					permissionsViewModels.NodeList = _NodesService.GetNodeList();
					break;
				case "Content":
					permissionsViewModels.NodeList = _NodesService.GetNodeListByContainer();
					break;
				case "Product":
					permissionsViewModels.NodeList = _NodesService.GetNodeListByContainer();
					break;
				case "Comment":
					permissionsViewModels.NodeList = _NodesService.GetNodeListByContainer();
					break;
			}
			permissionsViewModels.RoleNodePermissionsList = await _RolesService.GetNodePermissionsById(id);
			return View(permissionsViewModels);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,AdminRoleManage")]
		public async Task<ActionResult> NodePermissions(int id, string PermissionsType = "Node", IFormCollection collection=null)
		{
			if (id <= -1)
			{
				Utility.WriteMessage("权限配置必须指定角色", "mClose");
				return Content("");
			}
			if (id == 0)
			{
				Utility.WriteMessage("超级管理员不用设置权限", "mClose");
				return Content("");
			}
			switch (PermissionsType)
			{
				case "Node":
					await _RolesService.DeleteNodePermissionFromRoles(id,-3,OperateCode.CurrentNodesManage);
					await _RolesService.DeleteNodePermissionFromRoles(id, -3, OperateCode.ChildNodesManage);
					break;
				case "Content":
				case "Product":
					await _RolesService.DeleteNodePermissionFromRoles(id, -3, OperateCode.NodeContentPreview);
					await _RolesService.DeleteNodePermissionFromRoles(id, -3, OperateCode.NodeContentInput);
					await _RolesService.DeleteNodePermissionFromRoles(id, -3, OperateCode.NodeContentCheck);
					await _RolesService.DeleteNodePermissionFromRoles(id, -3, OperateCode.NodeContentManage);
					break;
				case "Comment":
					await _RolesService.DeleteNodePermissionFromRoles(id, -3, OperateCode.NodeCommentReply);
					await _RolesService.DeleteNodePermissionFromRoles(id, -3, OperateCode.NodeCommentCheck);
					await _RolesService.DeleteNodePermissionFromRoles(id, -3, OperateCode.NodeCommentManage);
					break;
			}
			var ModelPurview = collection["ModelPurview"];
			if (!string.IsNullOrEmpty(ModelPurview))
			{
				if (await _RolesService.AddNodePermissionToRoles(id, ModelPurview))
				{
					Utility.WriteMessage("设置权限成功", "mRefresh");
				}
				else
				{
					Utility.WriteMessage("设置权限失败", "mClose");
				}
			}
			else
			{
				Utility.WriteMessage("设置权限成功", "mRefresh");
			}
			return Content("");
		}
		#endregion

		#region 角色-模型字段权限设置
		[AdminAuthorize(Roles = "SuperAdmin,AdminRoleManage")]
		public async Task<IActionResult> RoleFieldPermissions(int id = -1, string roleName = "")
		{
			var permissionsViewModels = new List<RoleFieldPermissionsViewModels>();
			if (id <= -1)
			{
				Utility.WriteMessage("权限配置必须指定角色", "mClose");
				return View(permissionsViewModels);
			}
			if (id == 0)
			{
				Utility.WriteMessage("超级管理员不用设置权限", "mClose");
				return View(permissionsViewModels);
			}
			ViewBag.RoleID = id;
			ViewBag.RoleName = roleName;

			var modelsEntityList = await _ModelsService.LoadListAllAsync(p=>p.IsDisabled==false);
			foreach (ModelsEntity modelsEntity in modelsEntityList)
			{
				List<FieldInfo> fieldInfoList = modelsEntity.Field.ToXmlObject<List<FieldInfo>>();
				fieldInfoList.Sort(new FieldInfoComparer());
				var vm = new RoleFieldPermissionsViewModels();
				vm.ModelsEntity = modelsEntity;
				vm.FieldInfoList = fieldInfoList;
				vm.RoleFieldPermissionsEntityList = await _RolesService.GetFieldPermissionsById(id, modelsEntity.ModelID);
				permissionsViewModels.Add(vm);
			}
			
			return View(permissionsViewModels);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,AdminRoleManage")]
		public async Task<IActionResult> RoleFieldPermissions(int id, IFormCollection collection)
		{
			if (id <= -1)
			{
				Utility.WriteMessage("权限配置必须指定角色", "mClose");
				return Content("");
			}
			if (id == 0)
			{
				Utility.WriteMessage("超级管理员不用设置权限", "mClose");
				return Content("");
			}
			var ModelPurview = collection["ModelPurview"];
			await _RolesService.DeleteFieldPermissionFromRoles(id);
			if (await _RolesService.AddFieldPermissionToRoles(id, OperateCode.ContentFieldInput, ModelPurview))
			{
				Utility.WriteMessage("设置权限成功", "mRefresh");
			}
			else
			{
				Utility.WriteMessage("设置权限失败", "mClose");
			}
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
				if(menuNode.HasChildNodes)
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