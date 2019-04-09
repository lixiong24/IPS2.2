// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: StatVisitorEntity.cs
// 修改时间：2019/4/9 17:45:13
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：StatVisitor 的实体类.
	/// </summary>
	public partial class StatVisitorEntity
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
		private DateTime? _vTime = DateTime.MaxValue;
		/// <summary>
		/// 访问时间 
		/// </summary>
		public DateTime? VTime
		{
			get {return _vTime;}
			set {_vTime = value;}
		}
		private System.String _ip = string.Empty;
		/// <summary>
		/// Ip地址 
		/// </summary>
		public System.String Ip
		{
			get {return _ip;}
			set {_ip = value;}
		}
		private System.String _address = string.Empty;
		/// <summary>
		/// 地理位置 
		/// </summary>
		public System.String Address
		{
			get {return _address;}
			set {_address = value;}
		}
		private System.String _system = string.Empty;
		/// <summary>
		/// 操作系统 
		/// </summary>
		public System.String System
		{
			get {return _system;}
			set {_system = value;}
		}
		private System.String _browser = string.Empty;
		/// <summary>
		/// 浏览器 
		/// </summary>
		public System.String Browser
		{
			get {return _browser;}
			set {_browser = value;}
		}
		private System.String _screen = string.Empty;
		/// <summary>
		/// 显示器分辨率 
		/// </summary>
		public System.String Screen
		{
			get {return _screen;}
			set {_screen = value;}
		}
		private System.String _color = string.Empty;
		/// <summary>
		/// 显示器色彩 
		/// </summary>
		public System.String Color
		{
			get {return _color;}
			set {_color = value;}
		}
		private System.String _referer = string.Empty;
		/// <summary>
		/// 来路 
		/// </summary>
		public System.String Referer
		{
			get {return _referer;}
			set {_referer = value;}
		}
		private System.Int32 _timezone = 0;
		/// <summary>
		/// 时区 
		/// </summary>
		public System.Int32 Timezone
		{
			get {return _timezone;}
			set {_timezone = value;}
		}
		#endregion
	}
}
