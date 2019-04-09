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
	/// 数据库表：RoleNodePermissions 的仓储实现类.
	/// </summary>
	public partial class RoleNodePermissionsRepository : Repository<RoleNodePermissionsEntity>, IRoleNodePermissionsRepository
	{
		/// <summary>
		/// 移除指定角色的指定节点的权限
		/// </summary>
		/// <param name="roleID"></param>
		/// <param name="nodeID">多个节点ID用“,”分隔</param>
		/// <param name="operateCode"></param>
		/// <returns></returns>
		public bool DeleteNodePermissionFromRoles(System.Int32 roleID = 0, System.String nodeID = "", System.String operateCode = "")
		{
			Expression<Func<RoleNodePermissionsEntity, bool>> predicate = p => 1 == 1;
			if (roleID >= 0)
			{
				predicate = predicate.And(p => p.RoleID == roleID);
			}
			if (!string.IsNullOrEmpty(nodeID))
			{
				var arrNodeID = nodeID.Split(',');
				predicate = predicate.And(p => arrNodeID.Contains(p.NodeID.ToString()));
			}
			if (!string.IsNullOrEmpty(operateCode))
			{
				predicate = predicate.And(p => p.OperateCode == operateCode);
			}
			return Delete(predicate);
		}
		/// <summary>
		/// 移除指定角色的指定节点的权限
		/// </summary>
		/// <param name="roleID"></param>
		/// <param name="nodeID">多个节点ID用“,”分隔</param>
		/// <param name="operateCode"></param>
		/// <returns></returns>
		public async Task<bool> DeleteNodePermissionFromRolesAsync(System.Int32 roleID = 0, System.String nodeID = "", System.String operateCode = "")
		{
			Expression<Func<RoleNodePermissionsEntity, bool>> predicate = p => 1 == 1;
			if (roleID >= 0)
			{
				predicate = predicate.And(p => p.RoleID == roleID);
			}
			if (!string.IsNullOrEmpty(nodeID))
			{
				var arrNodeID = nodeID.Split(',');
				predicate = predicate.And(p => arrNodeID.Contains(p.NodeID.ToString()));
			}
			if (!string.IsNullOrEmpty(operateCode))
			{
				predicate = predicate.And(p => p.OperateCode == operateCode);
			}
			return await DeleteAsync(predicate);
		}
	}
}