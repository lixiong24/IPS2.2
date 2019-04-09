// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: CommentPKEntity.cs
// 修改时间：2019/4/9 17:45:05
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：CommentPK 的实体类.
	/// </summary>
	public partial class CommentPKEntity
	{
		#region Properties
		private System.Int32 _pkid = 0;
		/// <summary>
		/// 辩论ID (主键)
		/// </summary>
		public System.Int32 PKID
		{
			get {return _pkid;}
			set {_pkid = value;}
		}
		private System.Int32 _commentID = 0;
		/// <summary>
		///  评论ID 
		/// </summary>
		public System.Int32 CommentID
		{
			get {return _commentID;}
			set {_commentID = value;}
		}
		private System.String _title = string.Empty;
		/// <summary>
		///  评论标题 
		/// </summary>
		public System.String Title
		{
			get {return _title;}
			set {_title = value;}
		}
		private System.String _content = string.Empty;
		/// <summary>
		/// 内容 
		/// </summary>
		public System.String Content
		{
			get {return _content;}
			set {_content = value;}
		}
		private System.String _ip = string.Empty;
		/// <summary>
		/// IP 
		/// </summary>
		public System.String IP
		{
			get {return _ip;}
			set {_ip = value;}
		}
		private DateTime? _updateTime = DateTime.MaxValue;
		/// <summary>
		/// 时间 
		/// </summary>
		public DateTime? UpdateTime
		{
			get {return _updateTime;}
			set {_updateTime = value;}
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
		private System.Int32 _position = 0;
		/// <summary>
		/// 观点(0:中立，1:赞同，-1:反对) 
		/// </summary>
		public System.Int32 Position
		{
			get {return _position;}
			set {_position = value;}
		}
		#endregion
	}
}
