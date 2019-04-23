using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Application;
using JX.Core.Entity;
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

		public IActionResult GetUserGroupsList()
		{
			var list = _UserGroupsService.LoadListAll(p => true);
			return Json(list);
		}
	}
}