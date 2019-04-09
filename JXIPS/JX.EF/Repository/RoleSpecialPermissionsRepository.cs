using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：RoleSpecialPermissions 的仓储实现类.
	/// </summary>
	public partial class RoleSpecialPermissionsRepository : Repository<RoleSpecialPermissionsEntity>, IRoleSpecialPermissionsRepository
	{
		/// <summary>
		/// 构造器注入
		/// </summary>
		public RoleSpecialPermissionsRepository(ApplicationDbContext Context) : base(Context)
		{
		}
		
	}
}