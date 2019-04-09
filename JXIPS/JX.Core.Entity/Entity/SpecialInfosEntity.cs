// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: SpecialInfosEntity.cs
// 修改时间：2019/4/9 17:45:13
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：SpecialInfos 的实体类.
	/// </summary>
	public partial class SpecialInfosEntity
	{
		#region Properties
		private System.Int32 _specialInfoID = 0;
		/// <summary>
		/// 专题信息ID (主键)
		/// </summary>
		public System.Int32 SpecialInfoID
		{
			get {return _specialInfoID;}
			set {_specialInfoID = value;}
		}
		private System.Int32 _specialID = 0;
		/// <summary>
		/// 所属专题ID (主键)
		/// </summary>
		public System.Int32 SpecialID
		{
			get {return _specialID;}
			set {_specialID = value;}
		}
		private System.Int32 _generalID = 0;
		/// <summary>
		/// 所属实链接ID (主键)
		/// </summary>
		public System.Int32 GeneralID
		{
			get {return _generalID;}
			set {_generalID = value;}
		}
		#endregion
	}
}
