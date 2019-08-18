using JX.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JXWebHost.Areas.Admin.Models.UserViewModels
{
	public class UserGroupPermissionsViewModels
	{
		/// <summary>
		/// 菜单列表
		/// </summary>
		public IList<MenuEntity> MenuEntityList { get; set; }
		/// <summary>
		/// 权限码
		/// </summary>
		public string GroupPermissionsList { get; set; }
	}
}
