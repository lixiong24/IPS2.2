// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: SigninLogEntity.cs
// 修改时间：2019/4/9 17:45:12
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：SigninLog 的实体类.
	/// </summary>
	public partial class SigninLogEntity
	{
		#region Properties
		private System.Int32 _generalID = 0;
		/// <summary>
		/// 内容ID (主键)
		/// </summary>
		public System.Int32 GeneralID
		{
			get {return _generalID;}
			set {_generalID = value;}
		}
		private System.String _userName = string.Empty;
		/// <summary>
		/// 签收用户 (主键)
		/// </summary>
		public System.String UserName
		{
			get {return _userName;}
			set {_userName = value;}
		}
		private System.Boolean _isSignin = false;
		/// <summary>
		/// 是否签收 
		/// </summary>
		public System.Boolean IsSignin
		{
			get {return _isSignin;}
			set {_isSignin = value;}
		}
		private DateTime? _signinTime = DateTime.MaxValue;
		/// <summary>
		/// 签收时间 
		/// </summary>
		public DateTime? SigninTime
		{
			get {return _signinTime;}
			set {_signinTime = value;}
		}
		private System.String _ip = string.Empty;
		/// <summary>
		/// 签收IP 
		/// </summary>
		public System.String IP
		{
			get {return _ip;}
			set {_ip = value;}
		}
		#endregion
	}
}
