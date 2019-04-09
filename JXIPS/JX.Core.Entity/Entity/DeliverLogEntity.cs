// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: DeliverLogEntity.cs
// 修改时间：2019/4/9 17:45:07
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：DeliverLog 的实体类.
	/// </summary>
	public partial class DeliverLogEntity
	{
		#region Properties
		private System.Int32 _deliverID = 0;
		/// <summary>
		/// 发退货记录ID (主键)(自增长)
		/// </summary>
		public System.Int32 DeliverID
		{
			get {return _deliverID;}
			set {_deliverID = value;}
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
		private DateTime? _deliverDate = DateTime.MaxValue;
		/// <summary>
		/// 发退货日期 
		/// </summary>
		public DateTime? DeliverDate
		{
			get {return _deliverDate;}
			set {_deliverDate = value;}
		}
		private System.Int32 _deliverDirection = 0;
		/// <summary>
		/// 方向  1--发货  2--退货 
		/// </summary>
		public System.Int32 DeliverDirection
		{
			get {return _deliverDirection;}
			set {_deliverDirection = value;}
		}
		private System.String _handlerName = string.Empty;
		/// <summary>
		/// 经手人 
		/// </summary>
		public System.String HandlerName
		{
			get {return _handlerName;}
			set {_handlerName = value;}
		}
		private System.Int32 _courierId = 0;
		/// <summary>
		/// 快递公司ID 
		/// </summary>
		public System.Int32 CourierId
		{
			get {return _courierId;}
			set {_courierId = value;}
		}
		private System.String _expressNumber = string.Empty;
		/// <summary>
		/// 快递单号 
		/// </summary>
		public System.String ExpressNumber
		{
			get {return _expressNumber;}
			set {_expressNumber = value;}
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
		private System.String _remark = string.Empty;
		/// <summary>
		/// 备注 
		/// </summary>
		public System.String Remark
		{
			get {return _remark;}
			set {_remark = value;}
		}
		private System.Boolean _isReceived = false;
		/// <summary>
		/// 是否已签收 
		/// </summary>
		public System.Boolean IsReceived
		{
			get {return _isReceived;}
			set {_isReceived = value;}
		}
		private DateTime? _receivedDate = DateTime.MaxValue;
		/// <summary>
		/// 签收时间 
		/// </summary>
		public DateTime? ReceivedDate
		{
			get {return _receivedDate;}
			set {_receivedDate = value;}
		}
		private System.String _memo = string.Empty;
		/// <summary>
		/// 内部记录 
		/// </summary>
		public System.String Memo
		{
			get {return _memo;}
			set {_memo = value;}
		}
		#endregion
	}
}
