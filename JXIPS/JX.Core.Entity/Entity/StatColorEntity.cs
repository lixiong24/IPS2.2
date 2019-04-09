// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: StatColorEntity.cs
// 修改时间：2019/4/9 17:45:13
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：StatColor 的实体类.
	/// </summary>
	public partial class StatColorEntity
	{
		#region Properties
		private System.String _tColor = string.Empty;
		/// <summary>
		/// 颜色 (主键)
		/// </summary>
		public System.String TColor
		{
			get {return _tColor;}
			set {_tColor = value;}
		}
		private System.Int32 _tColNum = 0;
		/// <summary>
		/// 数量 
		/// </summary>
		public System.Int32 TColNum
		{
			get {return _tColNum;}
			set {_tColNum = value;}
		}
		#endregion
	}
}
