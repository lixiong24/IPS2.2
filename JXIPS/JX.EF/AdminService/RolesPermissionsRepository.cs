using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：RolesPermissions 的仓储实现类.
	/// </summary>
	public partial class RolesPermissionsRepository : Repository<RolesPermissionsEntity>, IRolesPermissionsRepository
	{
		/// <summary>
		/// 通过角色ID，得到对应的权限码列表
		/// </summary>
		/// <param name="roleIDs">角色ID，多个ID用“,”分隔</param>
		/// <returns></returns>
		public IList<string> GetOperateCodeByRoleID(string roleIDs)
		{
			IList<string> operateCodeList = new List<string>();
			if (string.IsNullOrEmpty(roleIDs))
				return operateCodeList;

			string strSQL = "select distinct OperateCode from RolesPermissions WHERE RoleID in (" + roleIDs + ")";
			return SqlQueryOne<string>(strSQL);
		}

		/// <summary>
		/// 移除指定角色的所有常规权限
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		public bool DeletePermissionFromRoles(int roleID)
		{
			return Delete(p=>p.RoleID==roleID);
		}
		/// <summary>
		/// 移除指定角色的所有常规权限
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		public async Task<bool> DeletePermissionFromRolesAsync(int roleID)
		{
			return await DeleteAsync(p => p.RoleID == roleID);
		}
	}
}