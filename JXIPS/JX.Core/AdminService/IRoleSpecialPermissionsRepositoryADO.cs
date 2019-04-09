using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.Core
{
	/// <summary>
	/// 数据库表：RoleSpecialPermissions 的仓储接口.
	/// </summary>
	public partial interface IRoleSpecialPermissionsRepositoryADO : IRepositoryADO<RoleSpecialPermissionsEntity>
	{
		/// <summary>
		/// 移除指定角色的指定专题的权限
		/// </summary>
		/// <param name="roleID"></param>
		/// <param name="specialID">多个专题ID用“,”分隔</param>
		/// <param name="operateCode"></param>
		/// <returns></returns>
		bool DeleteSpecialPermissionFromRoles(System.Int32 roleID=0, System.String specialID="", System.String operateCode="");
		/// <summary>
		/// 移除指定角色的指定专题的权限
		/// </summary>
		/// <param name="roleID"></param>
		/// <param name="specialID">多个专题ID用“,”分隔</param>
		/// <param name="operateCode"></param>
		/// <returns></returns>
		Task<bool> DeleteSpecialPermissionFromRolesAsync(System.Int32 roleID = 0, System.String specialID = "", System.String operateCode = "");
		
	}
}