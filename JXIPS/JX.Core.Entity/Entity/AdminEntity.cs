// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: AdminEntity.cs
// 修改时间：2019/4/9 17:45:02
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Admin 的实体类.
	/// </summary>
	public partial class AdminEntity
	{
		#region Properties
		private System.Int32 _adminID = 0;
		/// <summary>
		/// 管理员ID (主键)
		/// </summary>
		public System.Int32 AdminID
		{
			get {return _adminID;}
			set {_adminID = value;}
		}
		private System.String _adminName = string.Empty;
		/// <summary>
		/// 管理员名称 
		/// </summary>
		public System.String AdminName
		{
			get {return _adminName;}
			set {_adminName = value;}
		}
		private System.String _adminPassword = string.Empty;
		/// <summary>
		/// 管理员密码 
		/// </summary>
		public System.String AdminPassword
		{
			get {return _adminPassword;}
			set {_adminPassword = value;}
		}
		private System.String _userName = string.Empty;
		/// <summary>
		/// 前台用户名称 
		/// </summary>
		public System.String UserName
		{
			get {return _userName;}
			set {_userName = value;}
		}
		private System.Boolean _isMultiLogin = false;
		/// <summary>
		/// 是否允许多人登录 
		/// </summary>
		public System.Boolean IsMultiLogin
		{
			get {return _isMultiLogin;}
			set {_isMultiLogin = value;}
		}
		private System.String _rndPassword = string.Empty;
		/// <summary>
		/// 随机密码 
		/// </summary>
		public System.String RndPassword
		{
			get {return _rndPassword;}
			set {_rndPassword = value;}
		}
		private System.Int32 _loginTimes = 0;
		/// <summary>
		/// 登录次数 
		/// </summary>
		public System.Int32 LoginTimes
		{
			get {return _loginTimes;}
			set {_loginTimes = value;}
		}
		private System.String _loginIP = string.Empty;
		/// <summary>
		/// 最近登录IP 
		/// </summary>
		public System.String LoginIP
		{
			get {return _loginIP;}
			set {_loginIP = value;}
		}
		private DateTime? _loginTime = DateTime.MaxValue;
		/// <summary>
		/// 最近登录时间 
		/// </summary>
		public DateTime? LoginTime
		{
			get {return _loginTime;}
			set {_loginTime = value;}
		}
		private DateTime? _logoutTime = DateTime.MaxValue;
		/// <summary>
		/// 最近退出管理后台时间 
		/// </summary>
		public DateTime? LogoutTime
		{
			get {return _logoutTime;}
			set {_logoutTime = value;}
		}
		private DateTime? _modifyPasswordTime = DateTime.MaxValue;
		/// <summary>
		/// 最近修改密码时间 
		/// </summary>
		public DateTime? ModifyPasswordTime
		{
			get {return _modifyPasswordTime;}
			set {_modifyPasswordTime = value;}
		}
		private System.Boolean _isLock = false;
		/// <summary>
		/// 是否锁定 
		/// </summary>
		public System.Boolean IsLock
		{
			get {return _isLock;}
			set {_isLock = value;}
		}
		private System.Boolean _isModifyPassword = false;
		/// <summary>
		/// 是否允许修改密码 
		/// </summary>
		public System.Boolean IsModifyPassword
		{
			get {return _isModifyPassword;}
			set {_isModifyPassword = value;}
		}
		private System.String _hash = string.Empty;
		/// <summary>
		/// Hash值 
		/// </summary>
		public System.String Hash
		{
			get {return _hash;}
			set {_hash = value;}
		}
		private System.Int32 _loginErrorTimes = 0;
		/// <summary>
		/// 登录错误次数 
		/// </summary>
		public System.Int32 LoginErrorTimes
		{
			get {return _loginErrorTimes;}
			set {_loginErrorTimes = value;}
		}
		#endregion
	}
}
