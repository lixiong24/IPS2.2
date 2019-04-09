// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: StatMozillaEntity.cs
// 修改时间：2019/4/9 17:45:13
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：StatMozilla 的实体类.
	/// </summary>
	public partial class StatMozillaEntity
	{
		#region Properties
		private System.String _tMozilla = string.Empty;
		/// <summary>
		/// URL字段 (主键)
		/// </summary>
		public System.String TMozilla
		{
			get {return _tMozilla;}
			set {_tMozilla = value;}
		}
		private System.Int32 _tMozNum = 0;
		/// <summary>
		/// 数量 
		/// </summary>
		public System.Int32 TMozNum
		{
			get {return _tMozNum;}
			set {_tMozNum = value;}
		}
		#endregion
	}
}
