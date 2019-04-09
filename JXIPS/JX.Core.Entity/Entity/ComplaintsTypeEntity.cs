// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: ComplaintsTypeEntity.cs
// 修改时间：2019/4/9 17:45:06
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：ComplaintsType 的实体类.
	/// </summary>
	public partial class ComplaintsTypeEntity
	{
		#region Properties
		private System.Int32 _cid = 0;
		/// <summary>
		/// 类别ID (主键)
		/// </summary>
		public System.Int32 CID
		{
			get {return _cid;}
			set {_cid = value;}
		}
		private System.Int32 _cDType = 0;
		/// <summary>
		/// 属于那一类 投诉/举报 
		/// </summary>
		public System.Int32 CDType
		{
			get {return _cDType;}
			set {_cDType = value;}
		}
		private System.String _cName = string.Empty;
		/// <summary>
		/// 类型名称 
		/// </summary>
		public System.String CName
		{
			get {return _cName;}
			set {_cName = value;}
		}
		#endregion
	}
}
