using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：Friend 的仓储实现类.
	/// </summary>
	public partial class FriendRepository : Repository<FriendEntity>, IFriendRepository
	{
		/// <summary>
		/// 构造器注入
		/// </summary>
		public FriendRepository(ApplicationDbContext Context) : base(Context)
		{
		}
		
	}
}