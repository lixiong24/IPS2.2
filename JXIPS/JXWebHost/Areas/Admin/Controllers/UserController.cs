using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using JX.Application;
using JX.Core.Entity;
using JX.Infrastructure;
using JX.Infrastructure.Common;
using JX.Infrastructure.Field;
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
		private INodesServiceApp _NodesService;
		private IModelsServiceApp _ModelsService;
		public UserController(IUsersServiceApp UsersService, 
			IUserGroupsServiceApp UserGroupsService, 
			INodesServiceApp NodesService,
			IModelsServiceApp ModelsService)
		{
			_UsersService = UsersService;
			_UserGroupsService = UserGroupsService;
			_NodesService = NodesService;
			_ModelsService = ModelsService;
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
		public async Task<ActionResult> DelUserGroup(int id)
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
				if (await _UserGroupsService.DeleteFullAsync(id))
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
				ModelState.AddModelError(string.Empty, "匿名会员组不能编辑");
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
				if (_UserGroupsService.UserGroupIsExist(model.GroupName))
				{
					ModelState.AddModelError(string.Empty, "添加失败！会员组名称已经存在！");
					return View(model);
				}
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
				var oldModel = _UserGroupsService.Get(p => p.GroupID == id);
				if(oldModel.GroupName != model.GroupName)
				{
					if (_UserGroupsService.UserGroupIsExist(model.GroupName))
					{
						ModelState.AddModelError(string.Empty, "该会员组已经存在，请使用另一会员组名！");
						return View(model);
					}
				}
				oldModel.GroupName = model.GroupName;
				oldModel.Description = model.Description;
				oldModel.GroupType = model.GroupType;
				if (!await _UserGroupsService.UpdateAsync(oldModel))
				{
					ModelState.AddModelError(string.Empty, "修改失败");
					return View(model);
				}
				#endregion
			}
			return RedirectToAction("UserGroupPermissions", new { id = id, groupName = model.GroupName });
		}
		#endregion

		#region 会员组-常规权限设置(菜单、字段)
		[AdminAuthorize(Roles = "SuperAdmin,UserGroupManage")]
		public async Task<ActionResult> UserGroupPermissions(int id = 0, int IdType = 1)
		{
			UserGroupsEntity userGroupsEntity = null;
			UsersEntity usersEntity = null;
			UserPurviewEntity userPurviewEntity = null;
			UserGroupPermissionsViewModels permissionsViewModels = new UserGroupPermissionsViewModels();
			if (IdType == 1)
			{
				if (id <= 0 && id != -2)
				{
					Utility.WriteMessage("权限配置必须指定会员组", "mClose");
					return View(permissionsViewModels);
				}
				userGroupsEntity = await _UserGroupsService.GetAsync(p => p.GroupID == id);
				if (userGroupsEntity == null)
				{
					Utility.WriteMessage("指定的会员组不存在", "mClose");
					return View(permissionsViewModels);
				}
				ViewBag.Name = userGroupsEntity.GroupName;
				userPurviewEntity = userGroupsEntity.UserGroupPurview;
			}
			else if (IdType == 0)
			{
				if (id <= 0)
				{
					Utility.WriteMessage("权限配置必须指定会员", "mClose");
					return View(permissionsViewModels);
				}
				usersEntity = await _UsersService.GetAsync(p => p.UserID == id);
				if (usersEntity == null)
				{
					Utility.WriteMessage("指定的会员不存在", "mClose");
					return View(permissionsViewModels);
				}
				ViewBag.Name = usersEntity.UserName;
				userPurviewEntity = usersEntity.UserPurview;
			}
			else
			{
				Utility.WriteMessage("权限类型没有指定", "mClose");
				return View(permissionsViewModels);
			}
			if (userPurviewEntity == null)
			{
				userPurviewEntity = new UserPurviewEntity();
			}
			ViewBag.ID = id;
			permissionsViewModels.IdType = IdType;
			permissionsViewModels.GroupPermissionsList = DataConverter.ToString(userPurviewEntity.AllCheckCode);
			permissionsViewModels.PurviewEntity = userPurviewEntity;
			//菜单权限
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
			}
			//字段权限
			var groupFieldPermissionsViewModelsList = new List<GroupFieldPermissionsViewModels>();
			var modelsEntityList = await _ModelsService.LoadListAllAsync(p => p.IsDisabled == false);
			foreach (ModelsEntity modelsEntity in modelsEntityList)
			{
				var fieldInfoList = modelsEntity.Field.ToXmlObject<List<FieldInfo>>();
				fieldInfoList.Sort(new FieldInfoComparer());
				var vm = new GroupFieldPermissionsViewModels();
				vm.ModelsEntity = modelsEntity;
				vm.FieldInfoList = fieldInfoList;
				vm.GroupFieldPermissionsEntityList = await _UserGroupsService.GetFieldPermissionsById(id, modelsEntity.ModelID, IdType);
				groupFieldPermissionsViewModelsList.Add(vm);
			}
			permissionsViewModels.GroupFieldPermissionsViewModelsList = groupFieldPermissionsViewModelsList;
			return View(permissionsViewModels);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,UserGroupManage")]
		public async Task<ActionResult> UserGroupPermissions(int id, int IdType, UserGroupPermissionsViewModels viewModel, IFormCollection collection)
		{
			UserGroupsEntity userGroupsEntity = null;
			UsersEntity usersEntity = null;
			UserPurviewEntity userPurviewEntity = null;
			if (IdType == 1)
			{
				if (id <= 0 && id != -2)
				{
					Utility.WriteMessage("权限配置必须指定会员组", "mClose");
					return Content("");
				}
				userGroupsEntity = await _UserGroupsService.GetAsync(p => p.GroupID == id);
				if (userGroupsEntity == null)
				{
					Utility.WriteMessage("指定的会员组不存在", "mClose");
					return Content("");
				}
				userPurviewEntity = userGroupsEntity.UserGroupPurview;
			}
			else if (IdType == 0)
			{
				if (id <= 0)
				{
					Utility.WriteMessage("权限配置必须指定会员", "mClose");
					return Content("");
				}
				usersEntity = await _UsersService.GetAsync(p => p.UserID == id);
				if (usersEntity == null)
				{
					Utility.WriteMessage("指定的会员不存在", "mClose");
					return Content("");
				}
				userPurviewEntity = usersEntity.UserPurview;
			}
			else
			{
				Utility.WriteMessage("权限类型没有指定", "mClose");
				return Content("");
			}

			//字段权限
			var ModelFieldPurview = collection["ModelFieldPurview"];
			await _UserGroupsService.DeleteFieldPermissionFromGroup(id,IdType);
			await _UserGroupsService.AddFieldPermissionToUserGroup(id, OperateCode.ContentFieldInput, ModelFieldPurview, IdType);

			if (userPurviewEntity == null)
			{
				userPurviewEntity = new UserPurviewEntity();
			}
			//菜单权限
			var ModelPurview = collection["ModelPurview"];
			userPurviewEntity.AllCheckCode = ModelPurview;
			//其他权限
			userPurviewEntity.EnableComment = viewModel.PurviewEntity.EnableComment;
			userPurviewEntity.CommentNeedCheck = viewModel.PurviewEntity.CommentNeedCheck;
			userPurviewEntity.EnableUpload = viewModel.PurviewEntity.EnableUpload;
			userPurviewEntity.UploadSize = viewModel.PurviewEntity.UploadSize;
			userPurviewEntity.Discount = viewModel.PurviewEntity.Discount;
			userPurviewEntity.Overdraft = viewModel.PurviewEntity.Overdraft;
			if (ConfigHelper.Get<UserConfig>().EnablePoint || ConfigHelper.Get<UserConfig>().EnableValidNum)
			{
				userPurviewEntity.ChargeType = viewModel.PurviewEntity.ChargeType;
			}
			if (ConfigHelper.Get<UserConfig>().EnablePoint)
			{
				userPurviewEntity.ChargePointType = viewModel.PurviewEntity.ChargePointType;
				userPurviewEntity.TotalViewInfoNumber = viewModel.PurviewEntity.TotalViewInfoNumber;
				userPurviewEntity.ViewInfoNumberOneDay = viewModel.PurviewEntity.ViewInfoNumberOneDay;
			}
			bool bFlag = false;
			if (userGroupsEntity != null)
			{
				userGroupsEntity.GroupSetting = userPurviewEntity.ToXml();
				bFlag = await _UserGroupsService.UpdateAsync(userGroupsEntity);
			}
			else if (usersEntity != null)
			{
				usersEntity.UserSetting = userPurviewEntity.ToXml();
				bFlag = await _UsersService.UpdateAsync(usersEntity);
			}
			if (bFlag)
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

		#region 会员组-发布权限设置(节点、专题)
		[AdminAuthorize(Roles = "SuperAdmin,UserGroupManage")]
		public async Task<ActionResult> PublishPermissions(int id = 0,int IdType = 1)
		{
			UserGroupsEntity userGroupsEntity = null;
			UsersEntity usersEntity = null;
			var permissionsViewModels = new PublishPermissionsViewModel();
			if (IdType == 1)
			{
				if (id <= 0 && id != -2)
				{
					Utility.WriteMessage("权限配置必须指定会员组", "mClose");
					return View(permissionsViewModels);
				}
				userGroupsEntity = await _UserGroupsService.GetAsync(p => p.GroupID == id);
				if (userGroupsEntity == null)
				{
					Utility.WriteMessage("指定的会员组不存在", "mClose");
					return View(permissionsViewModels);
				}
				permissionsViewModels.PurviewEntity = userGroupsEntity.UserGroupPurview;
			}
			else if (IdType == 0)
			{
				if (id <= 0)
				{
					Utility.WriteMessage("权限配置必须指定会员", "mClose");
					return View(permissionsViewModels);
				}
				usersEntity = await _UsersService.GetAsync(p => p.UserID == id);
				if (usersEntity == null)
				{
					Utility.WriteMessage("指定的会员不存在", "mClose");
					return View(permissionsViewModels);
				}
				permissionsViewModels.PurviewEntity = usersEntity.UserPurview;
			}
			else
			{
				Utility.WriteMessage("权限类型没有指定", "mClose");
				return View(permissionsViewModels);
			}
			if (permissionsViewModels.PurviewEntity == null)
			{
				permissionsViewModels.PurviewEntity = new UserPurviewEntity();
			}
			permissionsViewModels.IdType = IdType;
			permissionsViewModels.NodeList = _NodesService.GetNodeListByContainer();
			permissionsViewModels.GroupNodePermissionsList = await _UserGroupsService.GetNodePermissionsById(id,-3,OperateCode.None,IdType);
			return View(permissionsViewModels);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,UserGroupManage")]
		public async Task<ActionResult> PublishPermissions(int id, int IdType, PublishPermissionsViewModel viewModel, IFormCollection collection = null)
		{
			UserGroupsEntity userGroupsEntity = null;
			UsersEntity usersEntity = null;
			UserPurviewEntity userPurviewEntity = null;
			if (IdType == 1)
			{
				if (id <= 0 && id != -2)
				{
					Utility.WriteMessage("权限配置必须指定会员组", "mClose");
					return Content("");
				}
				userGroupsEntity = await _UserGroupsService.GetAsync(p => p.GroupID == id);
				if (userGroupsEntity == null)
				{
					Utility.WriteMessage("指定的会员组不存在", "mClose");
					return Content("");
				}
				userPurviewEntity = userGroupsEntity.UserGroupPurview;
			}
			else if (IdType == 0)
			{
				if (id <= 0)
				{
					Utility.WriteMessage("权限配置必须指定会员", "mClose");
					return Content("");
				}
				usersEntity = await _UsersService.GetAsync(p => p.UserID == id);
				if (usersEntity == null)
				{
					Utility.WriteMessage("指定的会员不存在", "mClose");
					return Content("");
				}
				userPurviewEntity = usersEntity.UserPurview;
			}
			else
			{
				Utility.WriteMessage("权限类型没有指定", "mClose");
				return Content("");
			}
			//保存节点权限设置
			await _UserGroupsService.DeleteNodePermissionFromGroup(id, -3, OperateCode.NodeContentInput, IdType);
			await _UserGroupsService.DeleteNodePermissionFromGroup(id, -3, OperateCode.NodeNoNeedCheck, IdType);
			await _UserGroupsService.DeleteNodePermissionFromGroup(id, -3, OperateCode.NodeManageSelfInfo, IdType);
			var ModelPurview = collection["ModelPurview"];
			if (!string.IsNullOrEmpty(ModelPurview))
			{
				await _UserGroupsService.AddNodePermissionToUserGroup(id, ModelPurview, IdType);
			}
			//保存会员组（会员）权限设置
			if (userPurviewEntity == null)
			{
				userPurviewEntity = new UserPurviewEntity();
			}
			userPurviewEntity.SetEditor = viewModel.PurviewEntity.SetEditor;
			userPurviewEntity.MaxPublicInfoOneDay = viewModel.PurviewEntity.MaxPublicInfoOneDay;
			userPurviewEntity.MaxPublicInfo = viewModel.PurviewEntity.MaxPublicInfo;
			userPurviewEntity.IsXssFilter = viewModel.PurviewEntity.IsXssFilter;
			if (ConfigHelper.Get<UserConfig>().EnableExp)
			{
				userPurviewEntity.GetExp = viewModel.PurviewEntity.GetExp;
			}
			if (ConfigHelper.Get<UserConfig>().EnablePoint)
			{
				userPurviewEntity.GetPoint = viewModel.PurviewEntity.GetPoint;
			}
			bool bFlag = false;
			if (userGroupsEntity != null)
			{
				userGroupsEntity.GroupSetting = userPurviewEntity.ToXml();
				bFlag = await _UserGroupsService.UpdateAsync(userGroupsEntity);
			}
			else if (usersEntity != null)
			{
				usersEntity.UserSetting = userPurviewEntity.ToXml();
				bFlag = await _UsersService.UpdateAsync(usersEntity);
			}
			if (bFlag)
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

		#region 会员组-前台权限设置(节点)
		[AdminAuthorize(Roles = "SuperAdmin,UserGroupManage")]
		public async Task<ActionResult> UserGroupFrontPermissions(int id = 0, int IdType = 1)
		{
			UserGroupsEntity userGroupsEntity = null;
			UsersEntity usersEntity = null;
			var permissionsViewModels = new PublishPermissionsViewModel();
			if (IdType == 1)
			{
				if (id <= 0 && id != -2)
				{
					Utility.WriteMessage("权限配置必须指定会员组", "mClose");
					return View(permissionsViewModels);
				}
				userGroupsEntity = await _UserGroupsService.GetAsync(p => p.GroupID == id);
				if (userGroupsEntity == null)
				{
					Utility.WriteMessage("指定的会员组不存在", "mClose");
					return View(permissionsViewModels);
				}
				permissionsViewModels.PurviewEntity = userGroupsEntity.UserGroupPurview;
			}
			else if (IdType == 0)
			{
				if (id <= 0)
				{
					Utility.WriteMessage("权限配置必须指定会员", "mClose");
					return View(permissionsViewModels);
				}
				usersEntity = await _UsersService.GetAsync(p => p.UserID == id);
				if (usersEntity == null)
				{
					Utility.WriteMessage("指定的会员不存在", "mClose");
					return View(permissionsViewModels);
				}
				permissionsViewModels.PurviewEntity = usersEntity.UserPurview;
			}
			else
			{
				Utility.WriteMessage("权限类型没有指定", "mClose");
				return View(permissionsViewModels);
			}
			if (permissionsViewModels.PurviewEntity == null)
			{
				permissionsViewModels.PurviewEntity = new UserPurviewEntity();
			}
			var nodeList = new List<NodesEntity>();
			var nodeListTemp = _NodesService.GetNodeListByContainer();
			foreach (var item in nodeListTemp)
			{
				string BeginTag = _NodesService.GetTreeLine(item.Depth, item.ParentPath, item.NextID, item.Child);
				string EndTag = _NodesService.GetNodeDir(item.Child, (NodeType)item.NodeType, item.NodeDir);
				if (item.NodeName == "所有栏目")
				{
					BeginTag = BeginTag + "<span style='color:red'>";
					EndTag = "</span>" + EndTag;
				}
				else
				{
					//根据父节点的栏目权限和当前节点的栏目权限，确定当前节点的栏目权限
					int purviewType = 0;
					if (item.ParentID > 0)
					{
						purviewType = _NodesService.GetCacheNodeById(item.ParentID).PurviewType;
					}
					if (purviewType < item.PurviewType)
					{
						purviewType = item.PurviewType;
					}
					item.PurviewType = purviewType;
				}
				item.NodeName = BeginTag + item.NodeName + EndTag;
				nodeList.Add(item);
			}
			permissionsViewModels.IdType = IdType;
			permissionsViewModels.NodeList = nodeList;
			permissionsViewModels.GroupNodePermissionsList = await _UserGroupsService.GetNodePermissionsById(id, -3, OperateCode.None, IdType);
			return View(permissionsViewModels);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[AdminAuthorize(Roles = "SuperAdmin,UserGroupManage")]
		public async Task<ActionResult> UserGroupFrontPermissions(int id, int IdType, IFormCollection collection = null)
		{
			if (IdType == 1)
			{
				if (id <= 0 && id != -2)
				{
					Utility.WriteMessage("权限配置必须指定会员组", "mClose");
					return Content("");
				}
			}
			else if (IdType == 0)
			{
				if (id <= 0)
				{
					Utility.WriteMessage("权限配置必须指定会员", "mClose");
					return Content("");
				}
			}
			else
			{
				Utility.WriteMessage("权限类型没有指定", "mClose");
				return Content("");
			}
			//保存节点权限设置
			bool bFlag = false;
			await _UserGroupsService.DeleteNodePermissionFromGroup(id, -3, OperateCode.NodeContentSkim, IdType);
			await _UserGroupsService.DeleteNodePermissionFromGroup(id, -3, OperateCode.NodeContentPreview, IdType);
			var ModelPurview = collection["ModelPurview"];
			if (!string.IsNullOrEmpty(ModelPurview))
			{
				bFlag = await _UserGroupsService.AddNodePermissionToUserGroup(id, ModelPurview, IdType);
			}
			if (bFlag)
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