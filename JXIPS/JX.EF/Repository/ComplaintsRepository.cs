using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：Complaints 的仓储实现类.
	/// </summary>
	public partial class ComplaintsRepository : Repository<ComplaintsEntity>, IComplaintsRepository
	{
		/// <summary>
		/// 构造器注入
		/// </summary>
		public ComplaintsRepository(ApplicationDbContext Context) : base(Context)
		{
		}
		
	}
}