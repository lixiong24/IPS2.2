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
	/// 数据库表：RoleFieldPermissions 的仓储实现类.
	/// </summary>
	public partial class RoleFieldPermissionsRepositoryADO : IRoleFieldPermissionsRepositoryADO
	{
		/// <summary>
		/// 移除指定角色的指定模型字段的权限
		/// </summary>
		/// <returns></returns>
		public bool DeleteFieldPermissionFromRoles(int roleId = 0, int modelId = 0, string fieldName = "")
		{
			string strWhere = "";
			Dictionary<string, object> dict = new Dictionary<string, object>();
			if (roleId >= 0)
			{
				strWhere = strWhere + " AND RoleID = @RoleID ";
				dict.Add("RoleID", roleId);
			}
			if (modelId > 0)
			{
				strWhere = strWhere + " AND ModelID = @ModelID ";
				dict.Add("ModelID", modelId);
			}
			if (!string.IsNullOrEmpty(fieldName))
			{
				strWhere = strWhere + " AND FieldName = @FieldName ";
				dict.Add("FieldName", fieldName);
			}
			return Delete(strWhere, dict);
		}
		/// <summary>
		/// 移除指定角色的指定模型字段的权限
		/// </summary>
		/// <returns></returns>
		public async Task<bool> DeleteFieldPermissionFromRolesAsync(int roleId = 0, int modelId = 0, string fieldName = "")
		{
			string strWhere = "";
			Dictionary<string, object> dict = new Dictionary<string, object>();
			if (roleId >= 0)
			{
				strWhere = strWhere + " AND RoleID = @RoleID ";
				dict.Add("RoleID", roleId);
			}
			if (modelId > 0)
			{
				strWhere = strWhere + " AND ModelID = @ModelID ";
				dict.Add("ModelID", modelId);
			}
			if (!string.IsNullOrEmpty(fieldName))
			{
				strWhere = strWhere + " AND FieldName = @FieldName ";
				dict.Add("FieldName", fieldName);
			}
			return await DeleteAsync(strWhere, dict);
		}
	}
}