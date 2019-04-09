// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: LogEntity.cs
// 修改时间：2019/4/9 17:45:09
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Log 的实体类.
	/// </summary>
	public partial class LogEntity
	{
		#region Properties
		private System.Int32 _logID = 0;
		/// <summary>
		/// 日志记录ID (主键)(自增长)
		/// </summary>
		public System.Int32 LogID
		{
			get {return _logID;}
			set {_logID = value;}
		}
		private System.Int32 _category = 0;
		/// <summary>
		/// 分类 
		/// </summary>
		public System.Int32 Category
		{
			get {return _category;}
			set {_category = value;}
		}
		private System.Int32 _priority = 0;
		/// <summary>
		/// 优先级别 
		/// </summary>
		public System.Int32 Priority
		{
			get {return _priority;}
			set {_priority = value;}
		}
		private System.String _title = string.Empty;
		/// <summary>
		/// 标题 
		/// </summary>
		public System.String Title
		{
			get {return _title;}
			set {_title = value;}
		}
		private System.String _message = string.Empty;
		/// <summary>
		/// 内容 
		/// </summary>
		public System.String Message
		{
			get {return _message;}
			set {_message = value;}
		}
		private DateTime? _timestamp = DateTime.MaxValue;
		/// <summary>
		/// 记录日期 
		/// </summary>
		public DateTime? Timestamp
		{
			get {return _timestamp;}
			set {_timestamp = value;}
		}
		private System.String _userName = string.Empty;
		/// <summary>
		/// 用户名 
		/// </summary>
		public System.String UserName
		{
			get {return _userName;}
			set {_userName = value;}
		}
		private System.String _userIP = string.Empty;
		/// <summary>
		/// 用户IP 
		/// </summary>
		public System.String UserIP
		{
			get {return _userIP;}
			set {_userIP = value;}
		}
		private System.String _source = string.Empty;
		/// <summary>
		/// StackTrace，TargetSite：异常源，堆栈跟踪，等异常信息 
		/// </summary>
		public System.String Source
		{
			get {return _source;}
			set {_source = value;}
		}
		private System.String _scriptName = string.Empty;
		/// <summary>
		/// 页面 
		/// </summary>
		public System.String ScriptName
		{
			get {return _scriptName;}
			set {_scriptName = value;}
		}
		private System.String _postString = string.Empty;
		/// <summary>
		/// 提交信息 
		/// </summary>
		public System.String PostString
		{
			get {return _postString;}
			set {_postString = value;}
		}
		#endregion
	}
}
