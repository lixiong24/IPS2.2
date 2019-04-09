// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: SpecialCategoryEntity.cs
// 修改时间：2019/4/9 17:45:12
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：SpecialCategory 的实体类.
	/// </summary>
	public partial class SpecialCategoryEntity
	{
		#region Properties
		private System.Int32 _specialCategoryID = 0;
		/// <summary>
		/// 专题类别ID (主键)
		/// </summary>
		public System.Int32 SpecialCategoryID
		{
			get {return _specialCategoryID;}
			set {_specialCategoryID = value;}
		}
		private System.String _specialCategoryName = string.Empty;
		/// <summary>
		/// 专题类别名称 
		/// </summary>
		public System.String SpecialCategoryName
		{
			get {return _specialCategoryName;}
			set {_specialCategoryName = value;}
		}
		private System.String _specialCategoryDir = string.Empty;
		/// <summary>
		/// 专题类别目录名 
		/// </summary>
		public System.String SpecialCategoryDir
		{
			get {return _specialCategoryDir;}
			set {_specialCategoryDir = value;}
		}
		private System.String _specialTemplatePath = string.Empty;
		/// <summary>
		/// 专题列表页模板 
		/// </summary>
		public System.String SpecialTemplatePath
		{
			get {return _specialTemplatePath;}
			set {_specialTemplatePath = value;}
		}
		private System.Int32 _orderSort = 0;
		/// <summary>
		/// 专题类别排序ID 
		/// </summary>
		public System.Int32 OrderSort
		{
			get {return _orderSort;}
			set {_orderSort = value;}
		}
		private System.Boolean _isNewOpen = false;
		/// <summary>
		/// 专题类别打开方式 
		/// </summary>
		public System.Boolean IsNewOpen
		{
			get {return _isNewOpen;}
			set {_isNewOpen = value;}
		}
		private System.String _description = string.Empty;
		/// <summary>
		/// 专题类别描述 
		/// </summary>
		public System.String Description
		{
			get {return _description;}
			set {_description = value;}
		}
		private System.Boolean _isCreateHtml = false;
		/// <summary>
		/// 是否生成HTML 
		/// </summary>
		public System.Boolean IsCreateHtml
		{
			get {return _isCreateHtml;}
			set {_isCreateHtml = value;}
		}
		private System.String _pagePostfix = string.Empty;
		/// <summary>
		/// 生成专题列表页扩展名 
		/// </summary>
		public System.String PagePostfix
		{
			get {return _pagePostfix;}
			set {_pagePostfix = value;}
		}
		private System.String _searchTemplatePath = string.Empty;
		/// <summary>
		/// 专题搜索页模板路径 
		/// </summary>
		public System.String SearchTemplatePath
		{
			get {return _searchTemplatePath;}
			set {_searchTemplatePath = value;}
		}
		private System.Boolean _isNeedCreateHtml = false;
		/// <summary>
		/// 是否有需要生成HTML的专题内容 
		/// </summary>
		public System.Boolean IsNeedCreateHtml
		{
			get {return _isNeedCreateHtml;}
			set {_isNeedCreateHtml = value;}
		}
		#endregion
	}
}
