using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;
using JX.Infrastructure.Common;
using System.Linq.Expressions;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：RoleSpecialPermissions 的仓储实现类.
	/// </summary>
	public partial class RoleSpecialPermissionsRepository : Repository<RoleSpecialPermissionsEntity>, IRoleSpecialPermissionsRepository
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
			Expression<Func<RoleSpecialPermissionsEntity, bool>> predicate = p => 1 == 1;
			if (roleID > 0)
			{
				predicate = predicate.And(p => p.RoleID == roleID);
			}
			if (!string.IsNullOrEmpty(specialID))
			{
				var arrNodeID = specialID.Split(',');
				predicate = predicate.And(p => arrNodeID.Contains(p.SpecialID.ToString()));
			}
			if (!string.IsNullOrEmpty(operateCode))
			{
				predicate = predicate.And(p => p.OperateCode == operateCode);
			}
			return Delete(predicate);
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
			Expression<Func<RoleSpecialPermissionsEntity, bool>> predicate = p => 1 == 1;
			if (roleID > 0)
			{
				predicate = predicate.And(p => p.RoleID == roleID);
			}
			if (!string.IsNullOrEmpty(specialID))
			{
				var arrNodeID = specialID.Split(',');
				predicate = predicate.And(p => arrNodeID.Contains(p.SpecialID.ToString()));
			}
			if (!string.IsNullOrEmpty(operateCode))
			{
				predicate = predicate.And(p => p.OperateCode == operateCode);
			}
			return await DeleteAsync(predicate);
		}

	}
}