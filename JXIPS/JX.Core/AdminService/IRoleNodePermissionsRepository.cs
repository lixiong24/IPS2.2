using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.Core
{
	/// <summary>
	/// 数据库表：RoleNodePermissions 的仓储接口.
	/// </summary>
	public partial interface IRoleNodePermissionsRepository : IRepository<RoleNodePermissionsEntity>
	{
		/// <summary>
		/// 移除指定角色的指定节点的权限
		/// </summary>
		/// <param name="roleID"></param>
		/// <param name="nodeID">多个节点ID用“,”分隔</param>
		/// <param name="operateCode"></param>
		/// <returns></returns>
		bool DeleteNodePermissionFromRoles(System.Int32 roleID = 0, System.String nodeID = "", System.String operateCode = "");
		/// <summary>
		/// 移除指定角色的指定节点的权限
		/// </summary>
		/// <param name="roleID"></param>
		/// <param name="nodeID">多个节点ID用“,”分隔</param>
		/// <param name="operateCode"></param>
		/// <returns></returns>
		Task<bool> DeleteNodePermissionFromRolesAsync(System.Int32 roleID = 0, System.String nodeID = "", System.String operateCode = "");
	}
}