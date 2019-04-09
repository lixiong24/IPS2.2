using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：U_CompanyText 的仓储实现类.
	/// </summary>
	public partial class U_CompanyTextRepository : Repository<U_CompanyTextEntity>, IU_CompanyTextRepository
	{
		/// <summary>
		/// 构造器注入
		/// </summary>
		public U_CompanyTextRepository(ApplicationDbContext Context) : base(Context)
		{
		}
		
	}
}