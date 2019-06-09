using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Application;
using JX.Core.Entity;
using JX.Infrastructure;
using JX.Infrastructure.Common;
using JX.Infrastructure.Framework.Authorize;
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
		public IActionResult GetUserGroupsList()
		{
			var list = _UserGroupsService.LoadListAll(p => true);
			return Json(list);
		}
		#endregion

		


	}
}