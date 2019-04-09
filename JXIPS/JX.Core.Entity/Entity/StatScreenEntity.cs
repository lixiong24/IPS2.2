// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: StatScreenEntity.cs
// 修改时间：2019/4/9 17:45:13
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：StatScreen 的实体类.
	/// </summary>
	public partial class StatScreenEntity
	{
		#region Properties
		private System.String _tScreen = string.Empty;
		/// <summary>
		/// 分辨率 (主键)
		/// </summary>
		public System.String TScreen
		{
			get {return _tScreen;}
			set {_tScreen = value;}
		}
		private System.Int32 _tScrNum = 0;
		/// <summary>
		/// 数量 
		/// </summary>
		public System.Int32 TScrNum
		{
			get {return _tScrNum;}
			set {_tScrNum = value;}
		}
		#endregion
	}
}
