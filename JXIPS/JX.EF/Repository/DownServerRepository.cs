﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：DownServer 的仓储实现类.
	/// </summary>
	public partial class DownServerRepository : Repository<DownServerEntity>, IDownServerRepository
	{
		/// <summary>
		/// 构造器注入
		/// </summary>
		public DownServerRepository(ApplicationDbContext Context) : base(Context)
		{
		}
		
	}
}