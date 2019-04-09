using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：U_Article 的仓储实现类.
	/// </summary>
	public partial class U_ArticleRepository : Repository<U_ArticleEntity>, IU_ArticleRepository
	{
		/// <summary>
		/// 构造器注入
		/// </summary>
		public U_ArticleRepository(ApplicationDbContext Context) : base(Context)
		{
		}
		
	}
}