// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: StatOnlineEntity.cs
// 修改时间：2019/4/9 17:45:13
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：StatOnline 的实体类.
	/// </summary>
	public partial class StatOnlineEntity
	{
		#region Properties
		private System.Int32 _id = 0;
		/// <summary>
		/// (null) (主键)(自增长)
		/// </summary>
		public System.Int32 ID
		{
			get {return _id;}
			set {_id = value;}
		}
		private System.String _userIP = string.Empty;
		/// <summary>
		/// 访问者IP 
		/// </summary>
		public System.String UserIP
		{
			get {return _userIP;}
			set {_userIP = value;}
		}
		private System.String _userAgent = string.Empty;
		/// <summary>
		/// 客户端信息 
		/// </summary>
		public System.String UserAgent
		{
			get {return _userAgent;}
			set {_userAgent = value;}
		}
		private System.String _userPage = string.Empty;
		/// <summary>
		/// 所在页面 
		/// </summary>
		public System.String UserPage
		{
			get {return _userPage;}
			set {_userPage = value;}
		}
		private DateTime? _onTime = DateTime.MaxValue;
		/// <summary>
		/// 上站时间 
		/// </summary>
		public DateTime? OnTime
		{
			get {return _onTime;}
			set {_onTime = value;}
		}
		private DateTime? _lastTime = DateTime.MaxValue;
		/// <summary>
		/// 最后刷新时间 
		/// </summary>
		public DateTime? LastTime
		{
			get {return _lastTime;}
			set {_lastTime = value;}
		}
		#endregion
	}
}
