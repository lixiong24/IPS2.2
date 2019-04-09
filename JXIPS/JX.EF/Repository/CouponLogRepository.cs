using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：CouponLog 的仓储实现类.
	/// </summary>
	public partial class CouponLogRepository : Repository<CouponLogEntity>, ICouponLogRepository
	{
		/// <summary>
		/// 构造器注入
		/// </summary>
		public CouponLogRepository(ApplicationDbContext Context) : base(Context)
		{
		}
		
	}
}