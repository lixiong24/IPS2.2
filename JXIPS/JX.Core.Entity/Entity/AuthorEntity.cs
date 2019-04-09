// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: AuthorEntity.cs
// 修改时间：2019/4/9 17:45:02
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Author 的实体类.
	/// </summary>
	public partial class AuthorEntity
	{
		#region Properties
		private System.Int32 _id = 0;
		/// <summary>
		/// 作者ID (主键)(自增长)
		/// </summary>
		public System.Int32 ID
		{
			get {return _id;}
			set {_id = value;}
		}
		private System.Int32 _userID = 0;
		/// <summary>
		/// 用户ID 
		/// </summary>
		public System.Int32 UserID
		{
			get {return _userID;}
			set {_userID = value;}
		}
		private System.String _type = string.Empty;
		/// <summary>
		/// 作者类型 
		/// </summary>
		public System.String Type
		{
			get {return _type;}
			set {_type = value;}
		}
		private System.String _name = string.Empty;
		/// <summary>
		/// 作者名 
		/// </summary>
		public System.String Name
		{
			get {return _name;}
			set {_name = value;}
		}
		private System.Boolean _isPassed = false;
		/// <summary>
		/// 是否通过审核 
		/// </summary>
		public System.Boolean IsPassed
		{
			get {return _isPassed;}
			set {_isPassed = value;}
		}
		private System.Boolean _isTop = false;
		/// <summary>
		/// 是否置顶 
		/// </summary>
		public System.Boolean IsTop
		{
			get {return _isTop;}
			set {_isTop = value;}
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
		private System.Int32 _hits = 0;
		/// <summary>
		/// 点击数 
		/// </summary>
		public System.Int32 Hits
		{
			get {return _hits;}
			set {_hits = value;}
		}
		private DateTime? _lastUseTime = DateTime.MaxValue;
		/// <summary>
		/// 最近登录时间 
		/// </summary>
		public DateTime? LastUseTime
		{
			get {return _lastUseTime;}
			set {_lastUseTime = value;}
		}
		private System.Int32 _templateID = 0;
		/// <summary>
		/// 作者模板 
		/// </summary>
		public System.Int32 TemplateID
		{
			get {return _templateID;}
			set {_templateID = value;}
		}
		private System.String _authorPic = string.Empty;
		/// <summary>
		/// 作者头像 
		/// </summary>
		public System.String AuthorPic
		{
			get {return _authorPic;}
			set {_authorPic = value;}
		}
		private System.String _authorIntro = string.Empty;
		/// <summary>
		/// 作者简介 
		/// </summary>
		public System.String AuthorIntro
		{
			get {return _authorIntro;}
			set {_authorIntro = value;}
		}
		private System.String _address = string.Empty;
		/// <summary>
		/// 作者地址 
		/// </summary>
		public System.String Address
		{
			get {return _address;}
			set {_address = value;}
		}
		private System.String _tel = string.Empty;
		/// <summary>
		/// 电话 
		/// </summary>
		public System.String Tel
		{
			get {return _tel;}
			set {_tel = value;}
		}
		private System.String _fax = string.Empty;
		/// <summary>
		/// 传真 
		/// </summary>
		public System.String Fax
		{
			get {return _fax;}
			set {_fax = value;}
		}
		private System.String _mail = string.Empty;
		/// <summary>
		/// 通信地址 
		/// </summary>
		public System.String Mail
		{
			get {return _mail;}
			set {_mail = value;}
		}
		private System.String _email = string.Empty;
		/// <summary>
		/// 电子邮件 
		/// </summary>
		public System.String Email
		{
			get {return _email;}
			set {_email = value;}
		}
		private System.Int32 _zipCode = 0;
		/// <summary>
		/// 邮政编码 
		/// </summary>
		public System.Int32 ZipCode
		{
			get {return _zipCode;}
			set {_zipCode = value;}
		}
		private System.String _homePage = string.Empty;
		/// <summary>
		/// 个人网站 
		/// </summary>
		public System.String HomePage
		{
			get {return _homePage;}
			set {_homePage = value;}
		}
		private System.String _im = string.Empty;
		/// <summary>
		/// Imeeting 
		/// </summary>
		public System.String Im
		{
			get {return _im;}
			set {_im = value;}
		}
		private System.Int16 _sex = 0;
		/// <summary>
		/// 性别 
		/// </summary>
		public System.Int16 Sex
		{
			get {return _sex;}
			set {_sex = value;}
		}
		private DateTime? _birthDay = DateTime.MaxValue;
		/// <summary>
		/// 生日 
		/// </summary>
		public DateTime? BirthDay
		{
			get {return _birthDay;}
			set {_birthDay = value;}
		}
		private System.String _company = string.Empty;
		/// <summary>
		/// 公司名 
		/// </summary>
		public System.String Company
		{
			get {return _company;}
			set {_company = value;}
		}
		private System.String _department = string.Empty;
		/// <summary>
		/// 部门 
		/// </summary>
		public System.String Department
		{
			get {return _department;}
			set {_department = value;}
		}
		#endregion
	}
}
