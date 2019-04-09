using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：Region_C 的仓储实现类.
	/// </summary>
	public partial class Region_CRepository : Repository<Region_CEntity>, IRegion_CRepository
	{
		/// <summary>
		/// 构造器注入
		/// </summary>
		public Region_CRepository(ApplicationDbContext Context) : base(Context)
		{
		}
		
	}
}