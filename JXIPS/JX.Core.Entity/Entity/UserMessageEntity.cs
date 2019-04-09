// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: UserMessageEntity.cs
// 修改时间：2019/4/9 17:45:15
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：UserMessage 的实体类.
	/// </summary>
	public partial class UserMessageEntity
	{
		#region Properties
		private System.Int32 _messageID = 0;
		/// <summary>
		/// 短消息Id (主键)(自增长)
		/// </summary>
		public System.Int32 MessageID
		{
			get {return _messageID;}
			set {_messageID = value;}
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
		private System.String _content = string.Empty;
		/// <summary>
		/// 内容 
		/// </summary>
		public System.String Content
		{
			get {return _content;}
			set {_content = value;}
		}
		private System.String _sender = string.Empty;
		/// <summary>
		/// 发件人 
		/// </summary>
		public System.String Sender
		{
			get {return _sender;}
			set {_sender = value;}
		}
		private System.String _incept = string.Empty;
		/// <summary>
		/// 收件人 
		/// </summary>
		public System.String Incept
		{
			get {return _incept;}
			set {_incept = value;}
		}
		private DateTime? _sendTime = DateTime.MaxValue;
		/// <summary>
		/// 发送日期 
		/// </summary>
		public DateTime? SendTime
		{
			get {return _sendTime;}
			set {_sendTime = value;}
		}
		private System.Int32 _isSend = 0;
		/// <summary>
		/// 是否被发送，0为没发送，1为被发送 
		/// </summary>
		public System.Int32 IsSend
		{
			get {return _isSend;}
			set {_isSend = value;}
		}
		private System.Int32 _isDelInbox = 0;
		/// <summary>
		/// 收件箱中信息的删除标记，0为未删除，1为已删除 
		/// </summary>
		public System.Int32 IsDelInbox
		{
			get {return _isDelInbox;}
			set {_isDelInbox = value;}
		}
		private System.Int32 _isDelSendbox = 0;
		/// <summary>
		/// 发件箱中信息的删除标记，0为未删除，1为已删除 
		/// </summary>
		public System.Int32 IsDelSendbox
		{
			get {return _isDelSendbox;}
			set {_isDelSendbox = value;}
		}
		private System.Int32 _isRead = 0;
		/// <summary>
		/// 短消息状态，0为未读，1为已读 
		/// </summary>
		public System.Int32 IsRead
		{
			get {return _isRead;}
			set {_isRead = value;}
		}
		#endregion
	}
}
