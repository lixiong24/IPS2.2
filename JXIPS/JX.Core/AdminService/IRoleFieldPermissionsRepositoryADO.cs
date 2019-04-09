using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.Core
{
	/// <summary>
	/// 数据库表：RoleFieldPermissions 的仓储接口.
	/// </summary>
	public partial interface IRoleFieldPermissionsRepositoryADO : IRepositoryADO<RoleFieldPermissionsEntity>
	{
		/// <summary>
		/// 移除指定角色的指定模型字段的权限
		/// </summary>
		/// <param name="roleId"></param>
		/// <param name="modelId"></param>
		/// <param name="fieldName"></param>
		/// <returns></returns>
		bool DeleteFieldPermissionFromRoles(int roleId=0, int modelId=0, string fieldName="");
		/// <summary>
		/// 移除指定角色的指定模型字段的权限
		/// </summary>
		/// <param name="roleId"></param>
		/// <param name="modelId"></param>
		/// <param name="fieldName"></param>
		/// <returns></returns>
		Task<bool> DeleteFieldPermissionFromRolesAsync(int roleId = 0, int modelId = 0, string fieldName = "");
		
	}
}