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
	/// 数据库表：RoleSpecialPermissions 的仓储实现类.
	/// </summary>
	public partial class RoleSpecialPermissionsRepositoryADO : IRoleSpecialPermissionsRepositoryADO
	{
		/// <summary>
		/// 移除指定角色的指定专题的权限
		/// </summary>
		/// <param name="roleID"></param>
		/// <param name="specialID">多个专题ID用“,”分隔</param>
		/// <param name="operateCode"></param>
		/// <returns></returns>
		public bool DeleteSpecialPermissionFromRoles(System.Int32 roleID = 0, System.String specialID = "", System.String operateCode = "")
		{
			string strWhere = "";
			Dictionary<string, object> dict = new Dictionary<string, object>();
			if (roleID > 0)
			{
				strWhere = strWhere + " AND RoleID = @RoleID ";
				dict.Add("RoleID", roleID);
			}
			if (!string.IsNullOrEmpty(specialID))
			{
				strWhere = strWhere + " AND SpecialID in (" + DataSecurity.ToValidId(specialID) + ") ";
			}
			if (!string.IsNullOrEmpty(operateCode))
			{
				strWhere = strWhere + " AND OperateCode = @OperateCode ";
				dict.Add("OperateCode", operateCode);
			}
			return Delete(strWhere, dict);
		}
		/// <summary>
		/// 移除指定角色的指定专题的权限
		/// </summary>
		/// <param name="roleID"></param>
		/// <param name="specialID">多个专题ID用“,”分隔</param>
		/// <param name="operateCode"></param>
		/// <returns></returns>
		public async Task<bool> DeleteSpecialPermissionFromRolesAsync(System.Int32 roleID = 0, System.String specialID = "", System.String operateCode = "")
		{
			string strWhere = "";
			Dictionary<string, object> dict = new Dictionary<string, object>();
			if (roleID > 0)
			{
				strWhere = strWhere + " AND RoleID = @RoleID ";
				dict.Add("RoleID", roleID);
			}
			if (!string.IsNullOrEmpty(specialID))
			{
				strWhere = strWhere + " AND SpecialID in (" + DataSecurity.ToValidId(specialID) + ") ";
			}
			if (!string.IsNullOrEmpty(operateCode))
			{
				strWhere = strWhere + " AND OperateCode = @OperateCode ";
				dict.Add("OperateCode", operateCode);
			}
			return await DeleteAsync(strWhere, dict);
		}
	}
}