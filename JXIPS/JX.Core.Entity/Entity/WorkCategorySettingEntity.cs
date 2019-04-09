// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: WorkCategorySettingEntity.cs
// 修改时间：2019/4/9 17:45:15
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：WorkCategorySetting 的实体类.
	/// </summary>
	public partial class WorkCategorySettingEntity
	{
		#region Properties
		private System.Int32 _id = 0;
		/// <summary>
		/// ID (主键)
		/// </summary>
		public System.Int32 ID
		{
			get {return _id;}
			set {_id = value;}
		}
		private System.Int32 _workCategoryID = 0;
		/// <summary>
		/// 类别ID 
		/// </summary>
		public System.Int32 WorkCategoryID
		{
			get {return _workCategoryID;}
			set {_workCategoryID = value;}
		}
		private System.Int32 _customFormID = 0;
		/// <summary>
		/// 自定义表单ID 
		/// </summary>
		public System.Int32 CustomFormID
		{
			get {return _customFormID;}
			set {_customFormID = value;}
		}
		private System.String _templateOfAdmin = string.Empty;
		/// <summary>
		/// 后台表单提交页布局模板 
		/// </summary>
		public System.String TemplateOfAdmin
		{
			get {return _templateOfAdmin;}
			set {_templateOfAdmin = value;}
		}
		private System.String _templateOfUser = string.Empty;
		/// <summary>
		/// 前台表单提交页布局模板 
		/// </summary>
		public System.String TemplateOfUser
		{
			get {return _templateOfUser;}
			set {_templateOfUser = value;}
		}
		#endregion
	}
}
