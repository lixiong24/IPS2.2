using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：InfoNextProcessRoles 的仓储实现类.
	/// </summary>
	public partial class InfoNextProcessRolesRepository : Repository<InfoNextProcessRolesEntity>, IInfoNextProcessRolesRepository
	{
		/// <summary>
		/// 构造器注入
		/// </summary>
		public InfoNextProcessRolesRepository(ApplicationDbContext Context) : base(Context)
		{
		}
		
	}
}