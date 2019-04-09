using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.Core
{
	/// <summary>
	/// 数据库表：NodesTemplate 的仓储接口.
	/// </summary>
	public partial interface INodesTemplateRepositoryADO : IRepositoryADO<NodesTemplateEntity>
	{
		/// <summary>
		/// 通过主键删除
		/// </summary>
		/// <returns></returns>
		bool Delete(System.Int32 nodeID, System.Int32 templateID);
		/// <summary>
		/// 通过主键删除
		/// </summary>
		/// <returns></returns>
		Task<bool> DeleteAsync(System.Int32 nodeID, System.Int32 templateID);
		
		/// <summary>
		/// 通过主键返回第一条信息的实体类。
		/// </summary>
		/// <returns></returns>
		NodesTemplateEntity GetEntity(System.Int32 nodeID, System.Int32 templateID);
		/// <summary>
		/// 通过主键返回第一条信息的实体类。
		/// </summary>
		/// <returns></returns>
		Task<NodesTemplateEntity> GetEntityAsync(System.Int32 nodeID, System.Int32 templateID);
	}
}