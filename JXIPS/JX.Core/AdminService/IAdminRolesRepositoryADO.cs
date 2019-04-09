using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.Core
{
	/// <summary>
	/// 数据库表：AdminRoles 的仓储接口.
	/// </summary>
	public partial interface IAdminRolesRepositoryADO : IRepositoryADO<AdminRolesEntity>
	{
		/// <summary>
		/// 移除指定管理员的所有角色
		/// </summary>
		/// <param name="adminId"></param>
		/// <returns></returns>
		bool RemoveMemberFromAllRoles(int adminId);
		/// <summary>
		/// 移除指定管理员的所有角色
		/// </summary>
		/// <param name="adminId"></param>
		/// <returns></returns>
		Task<bool> RemoveMemberFromAllRolesAsync(int adminId);

		/// <summary>
		/// 移除指定角色的所有管理员
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		bool RemoveAdminFromRolesByRoleId(int roleID);
		/// <summary>
		/// 移除指定角色的所有管理员
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		Task<bool> RemoveAdminFromRolesByRoleIdAsync(int roleID);

		/// <summary>
		/// 为指定管理员添加所有的角色，添加之前，先删除所有旧的角色记录
		/// </summary>
		/// <param name="adminId"></param>
		/// <param name="roles"></param>
		/// <returns></returns>
		bool AddMemberToRoles(int adminId, string roles);
		/// <summary>
		/// 为指定管理员添加所有的角色，添加之前，先删除所有旧的角色记录
		/// </summary>
		/// <param name="adminId"></param>
		/// <param name="roles"></param>
		/// <returns></returns>
		Task<bool> AddMemberToRolesAsync(int adminId, string roles);
	}
}