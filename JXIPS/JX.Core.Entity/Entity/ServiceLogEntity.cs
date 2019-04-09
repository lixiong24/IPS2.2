// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: ServiceLogEntity.cs
// 修改时间：2019/4/9 17:45:12
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：ServiceLog 的实体类.
	/// </summary>
	public partial class ServiceLogEntity
	{
		#region Properties
		private System.Int32 _itemID = 0;
		/// <summary>
		/// 明细ID (主键)(自增长)
		/// </summary>
		public System.Int32 ItemID
		{
			get {return _itemID;}
			set {_itemID = value;}
		}
		private System.Int32 _clientID = 0;
		/// <summary>
		/// 客户ID 
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
		private System.Int32 _orderID = 0;
		/// <summary>
		/// 订单ID 
		/// </summary>
		public System.Int32 OrderID
		{
			get {return _orderID;}
			set {_orderID = value;}
		}
		private DateTime? _serviceTime = DateTime.MaxValue;
		/// <summary>
		/// 服务时间 
		/// </summary>
		public DateTime? ServiceTime
		{
			get {return _serviceTime;}
			set {_serviceTime = value;}
		}
		private System.String _serviceType = string.Empty;
		/// <summary>
		/// 服务类型 
		/// </summary>
		public System.String ServiceType
		{
			get {return _serviceType;}
			set {_serviceType = value;}
		}
		private System.String _serviceMode = string.Empty;
		/// <summary>
		/// 服务方式 
		/// </summary>
		public System.String ServiceMode
		{
			get {return _serviceMode;}
			set {_serviceMode = value;}
		}
		private System.String _serviceTitle = string.Empty;
		/// <summary>
		/// 服务主题 
		/// </summary>
		public System.String ServiceTitle
		{
			get {return _serviceTitle;}
			set {_serviceTitle = value;}
		}
		private System.String _serviceContent = string.Empty;
		/// <summary>
		/// 服务内容 
		/// </summary>
		public System.String ServiceContent
		{
			get {return _serviceContent;}
			set {_serviceContent = value;}
		}
		private System.Int32 _serviceResult = 0;
		/// <summary>
		/// 服务结果，0为未完成，1为完成 
		/// </summary>
		public System.Int32 ServiceResult
		{
			get {return _serviceResult;}
			set {_serviceResult = value;}
		}
		private System.Int32 _takeTime = 0;
		/// <summary>
		/// 花费时间 
		/// </summary>
		public System.Int32 TakeTime
		{
			get {return _takeTime;}
			set {_takeTime = value;}
		}
		private System.Int32 _servicePoint = 0;
		/// <summary>
		/// 服务点数 
		/// </summary>
		public System.Int32 ServicePoint
		{
			get {return _servicePoint;}
			set {_servicePoint = value;}
		}
		private System.String _processor = string.Empty;
		/// <summary>
		/// 执行人 
		/// </summary>
		public System.String Processor
		{
			get {return _processor;}
			set {_processor = value;}
		}
		private System.String _inputer = string.Empty;
		/// <summary>
		/// 录入者 
		/// </summary>
		public System.String Inputer
		{
			get {return _inputer;}
			set {_inputer = value;}
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
		/// 客户评价 
		/// </summary>
		public System.Int32 ConfirmScore
		{
			get {return _confirmScore;}
			set {_confirmScore = value;}
		}
		private System.String _confirmFeedback = string.Empty;
		/// <summary>
		/// 客户反馈 
		/// </summary>
		public System.String ConfirmFeedback
		{
			get {return _confirmFeedback;}
			set {_confirmFeedback = value;}
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
		#endregion
	}
}
