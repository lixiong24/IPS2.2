// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: SpecialsEntity.cs
// 修改时间：2019/4/9 17:45:13
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Specials 的实体类.
	/// </summary>
	public partial class SpecialsEntity
	{
		#region Properties
		private System.Int32 _specialID = 0;
		/// <summary>
		/// 专题ID (主键)
		/// </summary>
		public System.Int32 SpecialID
		{
			get {return _specialID;}
			set {_specialID = value;}
		}
		private System.String _specialName = string.Empty;
		/// <summary>
		/// 专题名称 
		/// </summary>
		public System.String SpecialName
		{
			get {return _specialName;}
			set {_specialName = value;}
		}
		private System.Int32 _specialCategoryID = 0;
		/// <summary>
		/// 所属专题类别ID 
		/// </summary>
		public System.Int32 SpecialCategoryID
		{
			get {return _specialCategoryID;}
			set {_specialCategoryID = value;}
		}
		private System.String _specialDir = string.Empty;
		/// <summary>
		/// 专题目录 
		/// </summary>
		public System.String SpecialDir
		{
			get {return _specialDir;}
			set {_specialDir = value;}
		}
		private System.String _specialIdentifier = string.Empty;
		/// <summary>
		/// 专题标识符 
		/// </summary>
		public System.String SpecialIdentifier
		{
			get {return _specialIdentifier;}
			set {_specialIdentifier = value;}
		}
		private System.String _specialPic = string.Empty;
		/// <summary>
		/// 专题图片地址 
		/// </summary>
		public System.String SpecialPic
		{
			get {return _specialPic;}
			set {_specialPic = value;}
		}
		private System.String _specialTips = string.Empty;
		/// <summary>
		/// 专题提示 
		/// </summary>
		public System.String SpecialTips
		{
			get {return _specialTips;}
			set {_specialTips = value;}
		}
		private System.String _specialTemplatePath = string.Empty;
		/// <summary>
		/// 专题页模板路径 
		/// </summary>
		public System.String SpecialTemplatePath
		{
			get {return _specialTemplatePath;}
			set {_specialTemplatePath = value;}
		}
		private System.Boolean _isElite = false;
		/// <summary>
		/// 是否推荐 
		/// </summary>
		public System.Boolean IsElite
		{
			get {return _isElite;}
			set {_isElite = value;}
		}
		private System.Int32 _orderSort = 0;
		/// <summary>
		/// 专题排序ID 
		/// </summary>
		public System.Int32 OrderSort
		{
			get {return _orderSort;}
			set {_orderSort = value;}
		}
		private System.Int32 _openType = 0;
		/// <summary>
		/// 专题打开方式 0-原窗口 1-新窗口 
		/// </summary>
		public System.Int32 OpenType
		{
			get {return _openType;}
			set {_openType = value;}
		}
		private System.String _description = string.Empty;
		/// <summary>
		/// 专题描述 
		/// </summary>
		public System.String Description
		{
			get {return _description;}
			set {_description = value;}
		}
		private System.Boolean _isCreateListPage = false;
		/// <summary>
		/// 列表页是否生成HTML 
		/// </summary>
		public System.Boolean IsCreateListPage
		{
			get {return _isCreateListPage;}
			set {_isCreateListPage = value;}
		}
		private System.Int32 _listPageSavePathType = 0;
		/// <summary>
		/// 列表页生成规则 
		/// </summary>
		public System.Int32 ListPageSavePathType
		{
			get {return _listPageSavePathType;}
			set {_listPageSavePathType = value;}
		}
		private System.String _listPagePostfix = string.Empty;
		/// <summary>
		/// 列表页生成HTML后缀 
		/// </summary>
		public System.String ListPagePostfix
		{
			get {return _listPagePostfix;}
			set {_listPagePostfix = value;}
		}
		private System.String _custom_Content = string.Empty;
		/// <summary>
		/// 自设内容 
		/// </summary>
		public System.String Custom_Content
		{
			get {return _custom_Content;}
			set {_custom_Content = value;}
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
