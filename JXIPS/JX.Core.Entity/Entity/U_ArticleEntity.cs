// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: U_ArticleEntity.cs
// 修改时间：2019/4/9 17:45:14
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：U_Article 的实体类.
	/// </summary>
	public partial class U_ArticleEntity
	{
		#region Properties
		private System.Int32 _id = 0;
		/// <summary>
		///  (主键)
		/// </summary>
		public System.Int32 ID
		{
			get {return _id;}
			set {_id = value;}
		}
		private System.String _intro = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String Intro
		{
			get {return _intro;}
			set {_intro = value;}
		}
		private System.String _paginationType = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String PaginationType
		{
			get {return _paginationType;}
			set {_paginationType = value;}
		}
		private System.Double _maxCharPerPage = 0.0f;
		/// <summary>
		///  
		/// </summary>
		public System.Double MaxCharPerPage
		{
			get {return _maxCharPerPage;}
			set {_maxCharPerPage = value;}
		}
		private System.String _content = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String Content
		{
			get {return _content;}
			set {_content = value;}
		}
		private System.String _sEO_Keyword = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String SEO_Keyword
		{
			get {return _sEO_Keyword;}
			set {_sEO_Keyword = value;}
		}
		private System.String _sEO_Desc = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String SEO_Desc
		{
			get {return _sEO_Desc;}
			set {_sEO_Desc = value;}
		}
		private System.String _sEO_Title = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String SEO_Title
		{
			get {return _sEO_Title;}
			set {_sEO_Title = value;}
		}
		#endregion
	}
}
