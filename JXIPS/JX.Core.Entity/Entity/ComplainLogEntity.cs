// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: ComplainLogEntity.cs
// 修改时间：2019/4/9 17:45:06
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：ComplainLog 的实体类.
	/// </summary>
	public partial class ComplainLogEntity
	{
		#region Properties
		private System.Int32 _itemID = 0;
		/// <summary>
		/// 明细ID (主键)
		/// </summary>
		public System.Int32 ItemID
		{
			get {return _itemID;}
			set {_itemID = value;}
		}
		private System.Int32 _clientID = 0;
		/// <summary>
		/// 用户ID 
		/// </summary>
		public System.Int32 ClientID
		{
			get {return _clientID;}
			set {_clientID = value;}
		}
		private System.Int32 _contacterID = 0;
		/// <summary>
		/// 联系人ID 
		/// </summary>
		public System.Int32 ContacterID
		{
			get {return _contacterID;}
			set {_contacterID = value;}
		}
		private System.Int32 _complainType = 0;
		/// <summary>
		/// 投诉类型 
		/// </summary>
		public System.Int32 ComplainType
		{
			get {return _complainType;}
			set {_complainType = value;}
		}
		private System.Int32 _complainMode = 0;
		/// <summary>
		/// 投诉方式 
		/// </summary>
		public System.Int32 ComplainMode
		{
			get {return _complainMode;}
			set {_complainMode = value;}
		}
		private System.String _title = string.Empty;
		/// <summary>
		/// 投诉主题 
		/// </summary>
		public System.String Title
		{
			get {return _title;}
			set {_title = value;}
		}
		private System.String _content = string.Empty;
		/// <summary>
		/// 投诉内容 
		/// </summary>
		public System.String Content
		{
			get {return _content;}
			set {_content = value;}
		}
		private System.String _firstReceiver = string.Empty;
		/// <summary>
		/// 首问接待人 
		/// </summary>
		public System.String FirstReceiver
		{
			get {return _firstReceiver;}
			set {_firstReceiver = value;}
		}
		private DateTime? _dateAndTime = DateTime.MaxValue;
		/// <summary>
		/// 投诉时间 
		/// </summary>
		public DateTime? DateAndTime
		{
			get {return _dateAndTime;}
			set {_dateAndTime = value;}
		}
		private System.Int32 _exigenceLevel = 0;
		/// <summary>
		/// 紧急程度 
		/// </summary>
		public System.Int32 ExigenceLevel
		{
			get {return _exigenceLevel;}
			set {_exigenceLevel = value;}
		}
		private System.String _process = string.Empty;
		/// <summary>
		/// 处理过程 
		/// </summary>
		public System.String Process
		{
			get {return _process;}
			set {_process = value;}
		}
		private System.String _processor = string.Empty;
		/// <summary>
		/// 处理人 
		/// </summary>
		public System.String Processor
		{
			get {return _processor;}
			set {_processor = value;}
		}
		private System.String _result = string.Empty;
		/// <summary>
		/// 处理结果 
		/// </summary>
		public System.String Result
		{
			get {return _result;}
			set {_result = value;}
		}
		private DateTime? _endTime = DateTime.MaxValue;
		/// <summary>
		/// 处理结束时间 
		/// </summary>
		public DateTime? EndTime
		{
			get {return _endTime;}
			set {_endTime = value;}
		}
		private System.String _feedback = string.Empty;
		/// <summary>
		/// 客户反馈 
		/// </summary>
		public System.String Feedback
		{
			get {return _feedback;}
			set {_feedback = value;}
		}
		private DateTime? _confirmTime = DateTime.MaxValue;
		/// <summary>
		/// 回访时间 
		/// </summary>
		public DateTime? ConfirmTime
		{
			get {return _confirmTime;}
			set {_confirmTime = value;}
		}
		private System.String _confirmCaller = string.Empty;
		/// <summary>
		/// 回访人 
		/// </summary>
		public System.String ConfirmCaller
		{
			get {return _confirmCaller;}
			set {_confirmCaller = value;}
		}
		private System.Int32 _confirmScore = 0;
		/// <summary>
		/// 客户评定服务星级 
		/// </summary>
		public System.Int32 ConfirmScore
		{
			get {return _confirmScore;}
			set {_confirmScore = value;}
		}
		private System.String _confirmFeedback = string.Empty;
		/// <summary>
		/// 客户评定反馈 
		/// </summary>
		public System.String ConfirmFeedback
		{
			get {return _confirmFeedback;}
			set {_confirmFeedback = value;}
		}
		private System.Int32 _status = 0;
		/// <summary>
		/// 记录状态，0为未处理，1为处理中，2为已处理，3为已回访 
		/// </summary>
		public System.Int32 Status
		{
			get {return _status;}
			set {_status = value;}
		}
		private System.String _currentOwner = string.Empty;
		/// <summary>
		/// 当前责任人 
		/// </summary>
		public System.String CurrentOwner
		{
			get {return _currentOwner;}
			set {_currentOwner = value;}
		}
		private System.String _remark = string.Empty;
		/// <summary>
		/// 备注 
		/// </summary>
		public System.String Remark
		{
			get {return _remark;}
			set {_remark = value;}
		}
		private System.String _defendant = string.Empty;
		/// <summary>
		/// 被投诉人 
		/// </summary>
		public System.String Defendant
		{
			get {return _defendant;}
			set {_defendant = value;}
		}
		#endregion
	}
}
