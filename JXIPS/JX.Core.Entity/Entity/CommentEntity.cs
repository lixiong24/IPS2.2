// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: CommentEntity.cs
// 修改时间：2019/4/9 17:45:05
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Comment 的实体类.
	/// </summary>
	public partial class CommentEntity
	{
		#region Properties
		private System.Int32 _commentID = 0;
		/// <summary>
		/// 评论ID (主键)
		/// </summary>
		public System.Int32 CommentID
		{
			get {return _commentID;}
			set {_commentID = value;}
		}
		private System.Int32 _generalID = 0;
		/// <summary>
		/// 内容ID 
		/// </summary>
		public System.Int32 GeneralID
		{
			get {return _generalID;}
			set {_generalID = value;}
		}
		private System.Int32 _nodeID = 0;
		/// <summary>
		/// 节点ID 
		/// </summary>
		public System.Int32 NodeID
		{
			get {return _nodeID;}
			set {_nodeID = value;}
		}
		private System.Int32 _topicID = 0;
		/// <summary>
		/// 在评论表中的主题ID 
		/// </summary>
		public System.Int32 TopicID
		{
			get {return _topicID;}
			set {_topicID = value;}
		}
		private System.String _commentTitle = string.Empty;
		/// <summary>
		/// 评论标题 
		/// </summary>
		public System.String CommentTitle
		{
			get {return _commentTitle;}
			set {_commentTitle = value;}
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
		private System.String _content = string.Empty;
		/// <summary>
		/// 评论内容 
		/// </summary>
		public System.String Content
		{
			get {return _content;}
			set {_content = value;}
		}
		private System.String _face = string.Empty;
		/// <summary>
		/// 表情 
		/// </summary>
		public System.String Face
		{
			get {return _face;}
			set {_face = value;}
		}
		private DateTime? _updateDateTime = DateTime.MaxValue;
		/// <summary>
		/// 发表评论时间 
		/// </summary>
		public DateTime? UpdateDateTime
		{
			get {return _updateDateTime;}
			set {_updateDateTime = value;}
		}
		private System.Int32 _position = 0;
		/// <summary>
		/// 发表评论观点(0:中立，1:赞同，-1:反对) 
		/// </summary>
		public System.Int32 Position
		{
			get {return _position;}
			set {_position = value;}
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
		private System.Int32 _agree = 0;
		/// <summary>
		/// 当前评论的支持数 
		/// </summary>
		public System.Int32 Agree
		{
			get {return _agree;}
			set {_agree = value;}
		}
		private System.Int32 _oppose = 0;
		/// <summary>
		/// 当前评论的反对数 
		/// </summary>
		public System.Int32 Oppose
		{
			get {return _oppose;}
			set {_oppose = value;}
		}
		private System.Int32 _neutral = 0;
		/// <summary>
		/// 当前评论的中立数 
		/// </summary>
		public System.Int32 Neutral
		{
			get {return _neutral;}
			set {_neutral = value;}
		}
		private System.Int32 _score = 0;
		/// <summary>
		/// 评分 
		/// </summary>
		public System.Int32 Score
		{
			get {return _score;}
			set {_score = value;}
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
		private System.Boolean _isElite = false;
		/// <summary>
		/// 是否推荐 
		/// </summary>
		public System.Boolean IsElite
		{
			get {return _isElite;}
			set {_isElite = value;}
		}
		private System.Boolean _isPrivate = false;
		/// <summary>
		/// 是否只有自己可见 
		/// </summary>
		public System.Boolean IsPrivate
		{
			get {return _isPrivate;}
			set {_isPrivate = value;}
		}
		private System.String _userName = string.Empty;
		/// <summary>
		/// 会员名 
		/// </summary>
		public System.String UserName
		{
			get {return _userName;}
			set {_userName = value;}
		}
		private System.String _reply = string.Empty;
		/// <summary>
		/// 管理员回复内容 
		/// </summary>
		public System.String Reply
		{
			get {return _reply;}
			set {_reply = value;}
		}
		private System.String _replyAdmin = string.Empty;
		/// <summary>
		/// 回复的管理员名称 
		/// </summary>
		public System.String ReplyAdmin
		{
			get {return _replyAdmin;}
			set {_replyAdmin = value;}
		}
		private DateTime? _replyDatetime = DateTime.MaxValue;
		/// <summary>
		/// 回复时间 
		/// </summary>
		public DateTime? ReplyDatetime
		{
			get {return _replyDatetime;}
			set {_replyDatetime = value;}
		}
		private System.Boolean _replyIsPrivate = false;
		/// <summary>
		/// 回复内容是否隐藏 
		/// </summary>
		public System.Boolean ReplyIsPrivate
		{
			get {return _replyIsPrivate;}
			set {_replyIsPrivate = value;}
		}
		private System.String _replyUserName = string.Empty;
		/// <summary>
		/// 被回复的会员名 
		/// </summary>
		public System.String ReplyUserName
		{
			get {return _replyUserName;}
			set {_replyUserName = value;}
		}
		#endregion
	}
}
