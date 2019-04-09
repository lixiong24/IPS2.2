namespace JX.Core
{
	/// <summary>
	/// 工作单元。
	/// 提供一个保存方法，它可以对调用层公开，为了减少连库次数
	/// </summary>
	public interface IUnitOfWork
	{
		/// <summary>
		/// 将操作提交到数据库，
		/// </summary>
		bool Commit();
	}
}
