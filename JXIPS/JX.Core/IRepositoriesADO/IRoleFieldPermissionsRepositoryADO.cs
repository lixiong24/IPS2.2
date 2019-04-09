using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.Core
{
	/// <summary>
	/// 数据库表：RoleFieldPermissions 的仓储接口.
	/// </summary>
	public partial interface IRoleFieldPermissionsRepositoryADO : IRepositoryADO<RoleFieldPermissionsEntity>
	{
		/// <summary>
		/// 通过主键删除
		/// </summary>
		/// <returns></returns>
		bool Delete(System.Int32 roleID, System.Int32 modelID, System.String fieldName, System.String operateCode);
		/// <summary>
		/// 通过主键删除
		/// </summary>
		/// <returns></returns>
		Task<bool> DeleteAsync(System.Int32 roleID, System.Int32 modelID, System.String fieldName, System.String operateCode);
		
		/// <summary>
		/// 通过主键返回第一条信息的实体类。
		/// </summary>
		/// <returns></returns>
		RoleFieldPermissionsEntity GetEntity(System.Int32 roleID, System.Int32 modelID, System.String fieldName, System.String operateCode);
		/// <summary>
		/// 通过主键返回第一条信息的实体类。
		/// </summary>
		/// <returns></returns>
		Task<RoleFieldPermissionsEntity> GetEntityAsync(System.Int32 roleID, System.Int32 modelID, System.String fieldName, System.String operateCode);
	}
}