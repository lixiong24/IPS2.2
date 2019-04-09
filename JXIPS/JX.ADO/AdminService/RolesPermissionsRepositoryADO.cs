using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;
using JX.Infrastructure.Common;
using MyADO;

namespace JX.ADO
{
	/// <summary>
	/// 数据库表：RolesPermissions 的仓储实现类.
	/// </summary>
	public partial class RolesPermissionsRepositoryADO : IRolesPermissionsRepositoryADO
	{
		/// <summary>
		/// 通过角色ID，得到对应的权限码列表
		/// </summary>
		/// <param name="roleIDs">角色ID，多个ID用“,”分隔</param>
		/// <returns></returns>
		public IList<string> GetOperateCodeByRoleID(string roleIDs)
		{
			IList<string> operateCodeList = new List<string>();
			if(string.IsNullOrEmpty(roleIDs))
				return operateCodeList;

			string strSQL = "select distinct OperateCode from RolesPermissions WHERE RoleID in (" + roleIDs + ")";
			using (NullableDataReader reader = _DB.GetDataReader(strSQL))
			{
				while (reader.Read())
				{
					operateCodeList.Add(reader.GetString("OperateCode"));
				}
			}
			return operateCodeList;
		}

		/// <summary>
		/// 移除指定角色的所有常规权限
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		public bool DeletePermissionFromRoles(int roleID)
		{
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("RoleID", roleID);
			return Delete(" and RoleID = @RoleID", dict);
		}
		/// <summary>
		/// 移除指定角色的所有常规权限
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		public async Task<bool> DeletePermissionFromRolesAsync(int roleID)
		{
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("RoleID", roleID);
			return await DeleteAsync(" and RoleID = @RoleID", dict);
		}
	}
}