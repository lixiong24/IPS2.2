// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: SiteLinkEntity.cs
// 修改时间：2019/4/9 17:45:12
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：SiteLink 的实体类.
	/// </summary>
	public partial class SiteLinkEntity
	{
		#region Properties
		private System.Int32 _insideLinkID = 0;
		/// <summary>
		/// 站内连接ID (主键)(自增长)
		/// </summary>
		public System.Int32 InsideLinkID
		{
			get {return _insideLinkID;}
			set {_insideLinkID = value;}
		}
		private System.String _source = string.Empty;
		/// <summary>
		/// 替换目标 
		/// </summary>
		public System.String Source
		{
			get {return _source;}
			set {_source = value;}
		}
		private System.String _replaceUrl = string.Empty;
		/// <summary>
		/// 替换后地址 
		/// </summary>
		public System.String ReplaceUrl
		{
			get {return _replaceUrl;}
			set {_replaceUrl = value;}
		}
		private System.Int32 _priority = 0;
		/// <summary>
		/// 优先级 
		/// </summary>
		public System.Int32 Priority
		{
			get {return _priority;}
			set {_priority = value;}
		}
		private System.Int32 _replaceTimes = 0;
		/// <summary>
		/// 替换次数 
		/// </summary>
		public System.Int32 ReplaceTimes
		{
			get {return _replaceTimes;}
			set {_replaceTimes = value;}
		}
		private System.Boolean _isNewOpen = false;
		/// <summary>
		/// 打开模式 
		/// </summary>
		public System.Boolean IsNewOpen
		{
			get {return _isNewOpen;}
			set {_isNewOpen = value;}
		}
		private System.Boolean _isEnabled = false;
		/// <summary>
		/// 是否启用 
		/// </summary>
		public System.Boolean IsEnabled
		{
			get {return _isEnabled;}
			set {_isEnabled = value;}
		}
		#endregion
	}
}
