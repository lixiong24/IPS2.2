// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: StatReferEntity.cs
// 修改时间：2019/4/9 17:45:13
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：StatRefer 的实体类.
	/// </summary>
	public partial class StatReferEntity
	{
		#region Properties
		private System.String _tRefer = string.Empty;
		/// <summary>
		/// 引用地址 (主键)
		/// </summary>
		public System.String TRefer
		{
			get {return _tRefer;}
			set {_tRefer = value;}
		}
		private System.Int32 _tRefNum = 0;
		/// <summary>
		/// 数量 
		/// </summary>
		public System.Int32 TRefNum
		{
			get {return _tRefNum;}
			set {_tRefNum = value;}
		}
		#endregion
	}
}
