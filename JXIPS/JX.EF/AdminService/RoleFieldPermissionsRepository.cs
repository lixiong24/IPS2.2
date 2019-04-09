using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;
using System.Linq.Expressions;
using JX.Infrastructure.Common;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：RoleFieldPermissions 的仓储实现类.
	/// </summary>
	public partial class RoleFieldPermissionsRepository : Repository<RoleFieldPermissionsEntity>, IRoleFieldPermissionsRepository
	{
		/// <summary>
		/// 移除指定角色的指定模型字段的权限
		/// </summary>
		/// <returns></returns>
		public bool DeleteFieldPermissionFromRoles(int roleId = 0, int modelId = 0, string fieldName = "")
		{
			Expression<Func<RoleFieldPermissionsEntity, bool>> predicate = p=>1==1;
			if (roleId >= 0)
			{
				predicate = predicate.And(p=>p.RoleID==roleId);
			}
			if (modelId > 0)
			{
				predicate = predicate.And(p => p.ModelID == modelId);
			}
			if (!string.IsNullOrEmpty(fieldName))
			{
				predicate = predicate.And(p => p.FieldName == fieldName);
			}
			return Delete(predicate);
		}
		/// <summary>
		/// 移除指定角色的指定模型字段的权限
		/// </summary>
		/// <returns></returns>
		public async Task<bool> DeleteFieldPermissionFromRolesAsync(int roleId = 0, int modelId = 0, string fieldName = "")
		{
			Expression<Func<RoleFieldPermissionsEntity, bool>> predicate = p => 1 == 1;
			if (roleId >= 0)
			{
				predicate = predicate.And(p => p.RoleID == roleId);
			}
			if (modelId > 0)
			{
				predicate = predicate.And(p => p.ModelID == modelId);
			}
			if (!string.IsNullOrEmpty(fieldName))
			{
				predicate = predicate.And(p => p.FieldName == fieldName);
			}
			return await DeleteAsync(predicate);
		}
	}
}