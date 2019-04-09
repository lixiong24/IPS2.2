using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.Core
{
	/// <summary>
	/// 数据库表：RolesPermissions 的仓储接口.
	/// </summary>
	public partial interface IRolesPermissionsRepository : IRepository<RolesPermissionsEntity>
	{
		/// <summary>
		/// 通过角色ID，得到对应的权限码列表
		/// </summary>
		/// <param name="roleIDs">角色ID，多个ID用“,”分隔</param>
		/// <returns></returns>
		IList<string> GetOperateCodeByRoleID(string roleIDs);

		/// <summary>
		/// 移除指定角色的所有常规权限
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		bool DeletePermissionFromRoles(int roleID);
		/// <summary>
		/// 移除指定角色的所有常规权限
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		Task<bool> DeletePermissionFromRolesAsync(int roleID);
	}
}