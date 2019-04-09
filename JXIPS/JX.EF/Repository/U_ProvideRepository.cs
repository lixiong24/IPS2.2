using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：U_Provide 的仓储实现类.
	/// </summary>
	public partial class U_ProvideRepository : Repository<U_ProvideEntity>, IU_ProvideRepository
	{
		/// <summary>
		/// 构造器注入
		/// </summary>
		public U_ProvideRepository(ApplicationDbContext Context) : base(Context)
		{
		}
		
	}
}