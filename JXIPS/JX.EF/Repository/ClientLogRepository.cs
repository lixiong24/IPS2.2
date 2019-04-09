using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：ClientLog 的仓储实现类.
	/// </summary>
	public partial class ClientLogRepository : Repository<ClientLogEntity>, IClientLogRepository
	{
		/// <summary>
		/// 构造器注入
		/// </summary>
		public ClientLogRepository(ApplicationDbContext Context) : base(Context)
		{
		}
		
	}
}