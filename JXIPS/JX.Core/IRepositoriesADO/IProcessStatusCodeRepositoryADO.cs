using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.Core
{
	/// <summary>
	/// 数据库表：ProcessStatusCode 的仓储接口.
	/// </summary>
	public partial interface IProcessStatusCodeRepositoryADO : IRepositoryADO<ProcessStatusCodeEntity>
	{
		/// <summary>
		/// 通过主键删除
		/// </summary>
		/// <returns></returns>
		bool Delete(System.Int32 flowID, System.Int32 processID, System.Int32 statusCode);
		/// <summary>
		/// 通过主键删除
		/// </summary>
		/// <returns></returns>
		Task<bool> DeleteAsync(System.Int32 flowID, System.Int32 processID, System.Int32 statusCode);
		
		/// <summary>
		/// 通过主键返回第一条信息的实体类。
		/// </summary>
		/// <returns></returns>
		ProcessStatusCodeEntity GetEntity(System.Int32 flowID, System.Int32 processID, System.Int32 statusCode);
		/// <summary>
		/// 通过主键返回第一条信息的实体类。
		/// </summary>
		/// <returns></returns>
		Task<ProcessStatusCodeEntity> GetEntityAsync(System.Int32 flowID, System.Int32 processID, System.Int32 statusCode);
	}
}