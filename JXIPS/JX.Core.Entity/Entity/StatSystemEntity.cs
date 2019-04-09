// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: StatSystemEntity.cs
// 修改时间：2019/4/9 17:45:13
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：StatSystem 的实体类.
	/// </summary>
	public partial class StatSystemEntity
	{
		#region Properties
		private System.String _tSystem = string.Empty;
		/// <summary>
		/// 操作系统 (主键)
		/// </summary>
		public System.String TSystem
		{
			get {return _tSystem;}
			set {_tSystem = value;}
		}
		private System.Int32 _tSysNum = 0;
		/// <summary>
		/// 数量 
		/// </summary>
		public System.Int32 TSysNum
		{
			get {return _tSysNum;}
			set {_tSysNum = value;}
		}
		#endregion
	}
}
