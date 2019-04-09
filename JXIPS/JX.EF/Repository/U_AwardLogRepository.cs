using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：U_AwardLog 的仓储实现类.
	/// </summary>
	public partial class U_AwardLogRepository : Repository<U_AwardLogEntity>, IU_AwardLogRepository
	{
		/// <summary>
		/// 构造器注入
		/// </summary>
		public U_AwardLogRepository(ApplicationDbContext Context) : base(Context)
		{
		}
		
	}
}