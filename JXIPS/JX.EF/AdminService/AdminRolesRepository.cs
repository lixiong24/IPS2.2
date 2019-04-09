using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;
using JX.Infrastructure.Common;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：AdminRoles 的仓储实现类.
	/// </summary>
	public partial class AdminRolesRepository : Repository<AdminRolesEntity>, IAdminRolesRepository
	{
		/// <summary>
		/// 移除指定管理员的所有角色
		/// </summary>
		/// <param name="adminId"></param>
		/// <returns></returns>
		public bool RemoveMemberFromAllRoles(int adminId)
		{
			return Delete(p=>p.AdminID==adminId);
		}

		/// <summary>
		/// 移除指定管理员的所有角色
		/// </summary>
		/// <param name="adminId"></param>
		/// <returns></returns>
		public async Task<bool> RemoveMemberFromAllRolesAsync(int adminId)
		{
			return await DeleteAsync(p => p.AdminID == adminId);
		}

		/// <summary>
		/// 移除指定角色的所有管理员
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		public bool RemoveAdminFromRolesByRoleId(int roleID)
		{
			return Delete(p => p.RoleID == roleID);
		}
		/// <summary>
		/// 移除指定角色的所有管理员
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		public async Task<bool> RemoveAdminFromRolesByRoleIdAsync(int roleID)
		{
			return await DeleteAsync(p => p.RoleID == roleID);
		}

		/// <summary>
		/// 为指定管理员添加所有的角色，添加之前，先删除所有旧的角色记录
		/// </summary>
		/// <param name="adminId"></param>
		/// <param name="roles"></param>
		/// <returns></returns>
		public bool AddMemberToRoles(int adminId, string roles)
		{
			if (string.IsNullOrEmpty(roles)) return false;
			RemoveMemberFromAllRoles(adminId);
			foreach (string str in roles.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				Add(new AdminRolesEntity() { AdminID = adminId, RoleID = DataConverter.CLng(str) });
			}
			return true;
		}
		/// <summary>
		/// 为指定管理员添加所有的角色，添加之前，先删除所有旧的角色记录
		/// </summary>
		/// <param name="adminId"></param>
		/// <param name="roles"></param>
		/// <returns></returns>
		public async Task<bool> AddMemberToRolesAsync(int adminId, string roles)
		{
			if (string.IsNullOrEmpty(roles)) return false;
			await RemoveMemberFromAllRolesAsync(adminId);
			foreach (string str in roles.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				Add(new AdminRolesEntity() { AdminID = adminId, RoleID = DataConverter.CLng(str) });
			}
			return true;
		}

	}
}