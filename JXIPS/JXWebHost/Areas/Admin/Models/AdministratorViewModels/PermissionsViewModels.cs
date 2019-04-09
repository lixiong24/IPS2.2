using JX.Core.Entity;
using System.Collections.Generic;

namespace JXWebHost.Areas.Admin.Models.AdministratorViewModels
{
	public class PermissionsViewModels
    {
		/// <summary>
		/// 菜单列表
		/// </summary>
		public IList<MenuEntity> MenuEntityList { get; set; }
		/// <summary>
		/// 角色的权限码
		/// </summary>
		public IList<RolesPermissionsEntity> RolesPermissionsList { get; set; }

	}
}
