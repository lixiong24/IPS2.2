using JX.Core;
using System;

namespace JX.EF
{
	/// <summary>
	/// 工作单元实现类
	/// </summary>
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		/// <summary>
		/// 数据上下文
		/// </summary>
		private ApplicationDbContext _Context;

		/// <summary>
		/// 通过构造器注入ApplicationDbContext
		/// </summary>
		/// <param name="Context"></param>
		public UnitOfWork(ApplicationDbContext Context)
		{
			_Context = Context;
		}

		/// <summary>
		/// 提交到数据库
		/// </summary>
		/// <returns></returns>
		public bool Commit()
		{
			return _Context.SaveChanges() > 0;
		}

		/// <summary>
		/// 销毁对象
		/// </summary>
		public void Dispose()
		{
			if (_Context != null)
				_Context.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
