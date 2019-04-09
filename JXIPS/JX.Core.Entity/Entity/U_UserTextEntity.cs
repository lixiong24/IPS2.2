// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: U_UserTextEntity.cs
// 修改时间：2019/4/9 17:45:15
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：U_UserText 的实体类.
	/// </summary>
	public partial class U_UserTextEntity
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
		private System.String _nominate = string.Empty;
		/// <summary>
		/// 推荐人用户名 
		/// </summary>
		public System.String Nominate
		{
			get {return _nominate;}
			set {_nominate = value;}
		}
		private System.String _regIP = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String RegIP
		{
			get {return _regIP;}
			set {_regIP = value;}
		}
		private System.String _qQOpenID = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String QQOpenID
		{
			get {return _qQOpenID;}
			set {_qQOpenID = value;}
		}
		private System.String _qQWeiboOpenID = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String QQWeiboOpenID
		{
			get {return _qQWeiboOpenID;}
			set {_qQWeiboOpenID = value;}
		}
		private System.String _renrenOpenID = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String RenrenOpenID
		{
			get {return _renrenOpenID;}
			set {_renrenOpenID = value;}
		}
		private System.String _sinaOpenID = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String SinaOpenID
		{
			get {return _sinaOpenID;}
			set {_sinaOpenID = value;}
		}
		private System.Double _sharingRatio = 0.0f;
		/// <summary>
		///  
		/// </summary>
		public System.Double SharingRatio
		{
			get {return _sharingRatio;}
			set {_sharingRatio = value;}
		}
		private System.String _wxOpenID = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String WxOpenID
		{
			get {return _wxOpenID;}
			set {_wxOpenID = value;}
		}
		#endregion
	}
}
