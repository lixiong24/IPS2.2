using JX.Core.Entity;
using System.Collections.Generic;

namespace JXWebHost.Areas.Admin.Models.AdministratorViewModels
{
	public class NodePermissionsViewModel
    {
		/// <summary>
		/// 栏目节点列表
		/// </summary>
		public IList<NodesEntity> NodeList { set; get; }
		/// <summary>
		/// 角色-节点权限列表
		/// </summary>
		public IList<RoleNodePermissionsEntity> RoleNodePermissionsList { get; set; }
	}
}
