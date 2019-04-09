using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.Core
{
	/// <summary>
	/// 数据库表：GroupFieldPermissions 的仓储接口.
	/// </summary>
	public partial interface IGroupFieldPermissionsRepositoryADO : IRepositoryADO<GroupFieldPermissionsEntity>
	{
		/// <summary>
		/// 通过主键删除
		/// </summary>
		/// <returns></returns>
		bool Delete(System.Int32 groupID, System.Int32 operateCode, System.Int32 modelID, System.String fieldName, System.Int32 idType);
		/// <summary>
		/// 通过主键删除
		/// </summary>
		/// <returns></returns>
		Task<bool> DeleteAsync(System.Int32 groupID, System.Int32 operateCode, System.Int32 modelID, System.String fieldName, System.Int32 idType);
		
		/// <summary>
		/// 通过主键返回第一条信息的实体类。
		/// </summary>
		/// <returns></returns>
		GroupFieldPermissionsEntity GetEntity(System.Int32 groupID, System.Int32 operateCode, System.Int32 modelID, System.String fieldName, System.Int32 idType);
		/// <summary>
		/// 通过主键返回第一条信息的实体类。
		/// </summary>
		/// <returns></returns>
		Task<GroupFieldPermissionsEntity> GetEntityAsync(System.Int32 groupID, System.Int32 operateCode, System.Int32 modelID, System.String fieldName, System.Int32 idType);
	}
}