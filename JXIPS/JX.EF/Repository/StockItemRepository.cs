using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：StockItem 的仓储实现类.
	/// </summary>
	public partial class StockItemRepository : Repository<StockItemEntity>, IStockItemRepository
	{
		/// <summary>
		/// 构造器注入
		/// </summary>
		public StockItemRepository(ApplicationDbContext Context) : base(Context)
		{
		}
		
	}
}