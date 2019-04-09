using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：U_Award 的仓储实现类.
	/// </summary>
	public partial class U_AwardRepository : Repository<U_AwardEntity>, IU_AwardRepository
	{
		/// <summary>
		/// 构造器注入
		/// </summary>
		public U_AwardRepository(ApplicationDbContext Context) : base(Context)
		{
		}
		
	}
}