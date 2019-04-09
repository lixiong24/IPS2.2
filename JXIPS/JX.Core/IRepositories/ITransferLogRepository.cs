using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.Core
{
	/// <summary>
	/// 数据库表：TransferLog 的仓储接口.
	/// </summary>
	public partial interface ITransferLogRepository : IRepository<TransferLogEntity>
	{
	}
}