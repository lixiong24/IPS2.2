// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: RepaymentEntity.cs
// 修改时间：2019/4/9 17:45:12
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Repayment 的实体类.
	/// </summary>
	public partial class RepaymentEntity
	{
		#region Properties
		private System.Int32 _id = 0;
		/// <summary>
		///  (主键)(自增长)
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
		private System.Int32 _orderItemID = 0;
		/// <summary>
		/// 订单明细ID 
		/// </summary>
		public System.Int32 OrderItemID
		{
			get {return _orderItemID;}
			set {_orderItemID = value;}
		}
		private System.Int32 _userID = 0;
		/// <summary>
		/// 会员ID 
		/// </summary>
		public System.Int32 UserID
		{
			get {return _userID;}
			set {_userID = value;}
		}
		private System.Int32 _deadline = 0;
		/// <summary>
		/// 总期限 
		/// </summary>
		public System.Int32 Deadline
		{
			get {return _deadline;}
			set {_deadline = value;}
		}
		private System.Int32 _currentDeadline = 0;
		/// <summary>
		/// 当前期限 
		/// </summary>
		public System.Int32 CurrentDeadline
		{
			get {return _currentDeadline;}
			set {_currentDeadline = value;}
		}
		private DateTime? _rePayDate = DateTime.MaxValue;
		/// <summary>
		/// 应还日期 
		/// </summary>
		public DateTime? RePayDate
		{
			get {return _rePayDate;}
			set {_rePayDate = value;}
		}
		private System.Decimal _rePayMoney = 0;
		/// <summary>
		/// 应还金额(本金+利息) 
		/// </summary>
		public System.Decimal RePayMoney
		{
			get {return _rePayMoney;}
			set {_rePayMoney = value;}
		}
		private System.Decimal _principal = 0;
		/// <summary>
		/// 应还本金 
		/// </summary>
		public System.Decimal Principal
		{
			get {return _principal;}
			set {_principal = value;}
		}
		private System.Decimal _interest = 0;
		/// <summary>
		/// 应还利息 
		/// </summary>
		public System.Decimal Interest
		{
			get {return _interest;}
			set {_interest = value;}
		}
		private System.Decimal _monthFeeMoney = 0;
		/// <summary>
		/// 月服务费 
		/// </summary>
		public System.Decimal MonthFeeMoney
		{
			get {return _monthFeeMoney;}
			set {_monthFeeMoney = value;}
		}
		private System.Decimal _vIPMoney = 0;
		/// <summary>
		/// VIP服务费 
		/// </summary>
		public System.Decimal VIPMoney
		{
			get {return _vIPMoney;}
			set {_vIPMoney = value;}
		}
		private System.Decimal _insuranceMoney = 0;
		/// <summary>
		/// 保险费用 
		/// </summary>
		public System.Decimal InsuranceMoney
		{
			get {return _insuranceMoney;}
			set {_insuranceMoney = value;}
		}
		private System.Decimal _rePayMoneySub = 0;
		/// <summary>
		/// 应还总金额（本金+利息+服务费+VIP服务费用+保险） 
		/// </summary>
		public System.Decimal RePayMoneySub
		{
			get {return _rePayMoneySub;}
			set {_rePayMoneySub = value;}
		}
		private System.Int32 _repaymentType = 0;
		/// <summary>
		/// 还款类型 
		/// </summary>
		public System.Int32 RepaymentType
		{
			get {return _repaymentType;}
			set {_repaymentType = value;}
		}
		private System.Int32 _repaymentStatus = 0;
		/// <summary>
		/// 还款状态（0：未还款；1：已还款；2：逾期；） 
		/// </summary>
		public System.Int32 RepaymentStatus
		{
			get {return _repaymentStatus;}
			set {_repaymentStatus = value;}
		}
		private DateTime? _trueRePayDate = DateTime.MaxValue;
		/// <summary>
		/// 实际还款日期 
		/// </summary>
		public DateTime? TrueRePayDate
		{
			get {return _trueRePayDate;}
			set {_trueRePayDate = value;}
		}
		private System.Decimal _trueRePayMoney = 0;
		/// <summary>
		/// 实际还款金额 
		/// </summary>
		public System.Decimal TrueRePayMoney
		{
			get {return _trueRePayMoney;}
			set {_trueRePayMoney = value;}
		}
		private System.Int32 _overdueDays = 0;
		/// <summary>
		/// 逾期天数 
		/// </summary>
		public System.Int32 OverdueDays
		{
			get {return _overdueDays;}
			set {_overdueDays = value;}
		}
		private System.Decimal _lateFee = 0;
		/// <summary>
		/// 滞纳金 
		/// </summary>
		public System.Decimal LateFee
		{
			get {return _lateFee;}
			set {_lateFee = value;}
		}
		private System.Int32 _pressMoneyStatus = 0;
		/// <summary>
		/// 催收状态（0：待还款；1：同意还款；2：催收失败；） 
		/// </summary>
		public System.Int32 PressMoneyStatus
		{
			get {return _pressMoneyStatus;}
			set {_pressMoneyStatus = value;}
		}
		private System.String _pressMoneyStaff = string.Empty;
		/// <summary>
		/// 催收员 
		/// </summary>
		public System.String PressMoneyStaff
		{
			get {return _pressMoneyStaff;}
			set {_pressMoneyStaff = value;}
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
		private System.String _remark1 = string.Empty;
		/// <summary>
		/// 催收记录 
		/// </summary>
		public System.String Remark1
		{
			get {return _remark1;}
			set {_remark1 = value;}
		}
		private System.String _remark2 = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String Remark2
		{
			get {return _remark2;}
			set {_remark2 = value;}
		}
		#endregion
	}
}
