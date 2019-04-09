// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: IntegralProductTypeEntity.cs
// 修改时间：2019/4/9 17:45:09
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：IntegralProductType 的实体类.
	/// </summary>
	public partial class IntegralProductTypeEntity
	{
		#region Properties
		private System.Int32 _typeID = 0;
		/// <summary>
		/// 编号 (主键)(自增长)
		/// </summary>
		public System.Int32 TypeID
		{
			get {return _typeID;}
			set {_typeID = value;}
		}
		private System.String _typeName = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String TypeName
		{
			get {return _typeName;}
			set {_typeName = value;}
		}
		private System.String _keyword = string.Empty;
		/// <summary>
		/// 关键字 
		/// </summary>
		public System.String Keyword
		{
			get {return _keyword;}
			set {_keyword = value;}
		}
		private System.String _description = string.Empty;
		/// <summary>
		/// 描述 
		/// </summary>
		public System.String Description
		{
			get {return _description;}
			set {_description = value;}
		}
		private System.Int32 _eliteLevel = 0;
		/// <summary>
		/// 推荐级 
		/// </summary>
		public System.Int32 EliteLevel
		{
			get {return _eliteLevel;}
			set {_eliteLevel = value;}
		}
		private System.Int32 _parentID = 0;
		/// <summary>
		/// 父节点 
		/// </summary>
		public System.Int32 ParentID
		{
			get {return _parentID;}
			set {_parentID = value;}
		}
		#endregion
	}
}
