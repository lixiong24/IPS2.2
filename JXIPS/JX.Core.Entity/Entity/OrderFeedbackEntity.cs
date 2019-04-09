// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: OrderFeedbackEntity.cs
// 修改时间：2019/4/9 17:45:11
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：OrderFeedback 的实体类.
	/// </summary>
	public partial class OrderFeedbackEntity
	{
		#region Properties
		private System.Int32 _id = 0;
		/// <summary>
		/// ID (主键)(自增长)
		/// </summary>
		public System.Int32 ID
		{
			get {return _id;}
			set {_id = value;}
		}
		private System.Int32 _orderID = 0;
		/// <summary>
		/// 订单ID 
		/// </summary>
		public System.Int32 OrderID
		{
			get {return _orderID;}
			set {_orderID = value;}
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
		private System.String _content = string.Empty;
		/// <summary>
		/// 内容 
		/// </summary>
		public System.String Content
		{
			get {return _content;}
			set {_content = value;}
		}
		private DateTime? _writeTime = DateTime.MaxValue;
		/// <summary>
		/// 添加反馈时间 
		/// </summary>
		public DateTime? WriteTime
		{
			get {return _writeTime;}
			set {_writeTime = value;}
		}
		private System.String _replyName = string.Empty;
		/// <summary>
		/// 回复管理员 
		/// </summary>
		public System.String ReplyName
		{
			get {return _replyName;}
			set {_replyName = value;}
		}
		private System.String _replyContent = string.Empty;
		/// <summary>
		/// 回复内容 
		/// </summary>
		public System.String ReplyContent
		{
			get {return _replyContent;}
			set {_replyContent = value;}
		}
		private DateTime? _replyTime = DateTime.MaxValue;
		/// <summary>
		/// 回复时间 
		/// </summary>
		public DateTime? ReplyTime
		{
			get {return _replyTime;}
			set {_replyTime = value;}
		}
		#endregion
	}
}
