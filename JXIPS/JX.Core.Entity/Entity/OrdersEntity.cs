// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: OrdersEntity.cs
// 修改时间：2019/4/9 17:45:11
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Orders 的实体类.
	/// </summary>
	public partial class OrdersEntity
	{
		#region Properties
		private System.Int32 _orderID = 0;
		/// <summary>
		/// 订单ID (主键)
		/// </summary>
		public System.Int32 OrderID
		{
			get {return _orderID;}
			set {_orderID = value;}
		}
		private System.String _orderNum = string.Empty;
		/// <summary>
		/// 订单编号 
		/// </summary>
		public System.String OrderNum
		{
			get {return _orderNum;}
			set {_orderNum = value;}
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
		private System.String _agentName = string.Empty;
		/// <summary>
		/// 代理商名 
		/// </summary>
		public System.String AgentName
		{
			get {return _agentName;}
			set {_agentName = value;}
		}
		private System.String _functionary = string.Empty;
		/// <summary>
		/// 跟单员 
		/// </summary>
		public System.String Functionary
		{
			get {return _functionary;}
			set {_functionary = value;}
		}
		private System.String _functionaryManage = string.Empty;
		/// <summary>
		/// 跟单员经理 
		/// </summary>
		public System.String FunctionaryManage
		{
			get {return _functionaryManage;}
			set {_functionaryManage = value;}
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
		private System.Decimal _moneyTotal = 0;
		/// <summary>
		/// 订单总金额(商品总金额+运费) 
		/// </summary>
		public System.Decimal MoneyTotal
		{
			get {return _moneyTotal;}
			set {_moneyTotal = value;}
		}
		private System.Decimal _moneyGoods = 0;
		/// <summary>
		/// 购买商品合计金额 
		/// </summary>
		public System.Decimal MoneyGoods
		{
			get {return _moneyGoods;}
			set {_moneyGoods = value;}
		}
		private System.Boolean _isNeedInvoice = false;
		/// <summary>
		/// 是否需要开发票 
		/// </summary>
		public System.Boolean IsNeedInvoice
		{
			get {return _isNeedInvoice;}
			set {_isNeedInvoice = value;}
		}
		private System.String _invoiceContent = string.Empty;
		/// <summary>
		/// 发票内容，包括抬头、商品名称、金额等 
		/// </summary>
		public System.String InvoiceContent
		{
			get {return _invoiceContent;}
			set {_invoiceContent = value;}
		}
		private System.Boolean _isInvoiced = false;
		/// <summary>
		/// 是否已开发票 
		/// </summary>
		public System.Boolean IsInvoiced
		{
			get {return _isInvoiced;}
			set {_isInvoiced = value;}
		}
		private System.Decimal _moneyReceipt = 0;
		/// <summary>
		/// 已收款金额 
		/// </summary>
		public System.Decimal MoneyReceipt
		{
			get {return _moneyReceipt;}
			set {_moneyReceipt = value;}
		}
		private DateTime? _beginDate = DateTime.MaxValue;
		/// <summary>
		/// 开始服务日期 
		/// </summary>
		public DateTime? BeginDate
		{
			get {return _beginDate;}
			set {_beginDate = value;}
		}
		private DateTime? _inputTime = DateTime.MaxValue;
		/// <summary>
		/// 录入时间 
		/// </summary>
		public DateTime? InputTime
		{
			get {return _inputTime;}
			set {_inputTime = value;}
		}
		private System.String _contacterName = string.Empty;
		/// <summary>
		/// 收货人姓名 
		/// </summary>
		public System.String ContacterName
		{
			get {return _contacterName;}
			set {_contacterName = value;}
		}
		private System.String _country = string.Empty;
		/// <summary>
		/// 收货人国家 
		/// </summary>
		public System.String Country
		{
			get {return _country;}
			set {_country = value;}
		}
		private System.String _province = string.Empty;
		/// <summary>
		/// 收货人省份 
		/// </summary>
		public System.String Province
		{
			get {return _province;}
			set {_province = value;}
		}
		private System.String _city = string.Empty;
		/// <summary>
		/// 收货人城市 
		/// </summary>
		public System.String City
		{
			get {return _city;}
			set {_city = value;}
		}
		private System.String _area = string.Empty;
		/// <summary>
		/// 收货人区县 
		/// </summary>
		public System.String Area
		{
			get {return _area;}
			set {_area = value;}
		}
		private System.String _address = string.Empty;
		/// <summary>
		/// 收货人地址 
		/// </summary>
		public System.String Address
		{
			get {return _address;}
			set {_address = value;}
		}
		private System.String _zipCode = string.Empty;
		/// <summary>
		/// 邮编 
		/// </summary>
		public System.String ZipCode
		{
			get {return _zipCode;}
			set {_zipCode = value;}
		}
		private System.String _mobile = string.Empty;
		/// <summary>
		/// 手机 
		/// </summary>
		public System.String Mobile
		{
			get {return _mobile;}
			set {_mobile = value;}
		}
		private System.String _phone = string.Empty;
		/// <summary>
		/// 联系电话 
		/// </summary>
		public System.String Phone
		{
			get {return _phone;}
			set {_phone = value;}
		}
		private System.String _email = string.Empty;
		/// <summary>
		/// Email 
		/// </summary>
		public System.String Email
		{
			get {return _email;}
			set {_email = value;}
		}
		private System.Int32 _paymentType = 0;
		/// <summary>
		/// 付款方式 
		/// </summary>
		public System.Int32 PaymentType
		{
			get {return _paymentType;}
			set {_paymentType = value;}
		}
		private System.Int32 _deliverType = 0;
		/// <summary>
		/// 送货方式 
		/// </summary>
		public System.Int32 DeliverType
		{
			get {return _deliverType;}
			set {_deliverType = value;}
		}
		private System.Int32 _orderStatus = 0;
		/// <summary>
		/// 订单状态(0:待确认;1:已确认;2:已结清;3:已作废;4:已暂停;5:未提交;6:待完善;7:申请退款;) 
		/// </summary>
		public System.Int32 OrderStatus
		{
			get {return _orderStatus;}
			set {_orderStatus = value;}
		}
		private System.Int32 _deliverStatus = 0;
		/// <summary>
		/// 物流状态(0:准备;1:寄送;2:签收;) 
		/// </summary>
		public System.Int32 DeliverStatus
		{
			get {return _deliverStatus;}
			set {_deliverStatus = value;}
		}
		private System.Boolean _isEnableDownload = false;
		/// <summary>
		/// 是否开通下载 
		/// </summary>
		public System.Boolean IsEnableDownload
		{
			get {return _isEnableDownload;}
			set {_isEnableDownload = value;}
		}
		private System.Decimal _presentMoney = 0;
		/// <summary>
		/// 赠送的现金券 
		/// </summary>
		public System.Decimal PresentMoney
		{
			get {return _presentMoney;}
			set {_presentMoney = value;}
		}
		private System.Int32 _presentPoint = 0;
		/// <summary>
		/// 赠送点券 
		/// </summary>
		public System.Int32 PresentPoint
		{
			get {return _presentPoint;}
			set {_presentPoint = value;}
		}
		private System.Int32 _presentExp = 0;
		/// <summary>
		/// 赠送的积分 
		/// </summary>
		public System.Int32 PresentExp
		{
			get {return _presentExp;}
			set {_presentExp = value;}
		}
		private System.Double _discount_Payment = 0.0f;
		/// <summary>
		/// 付款方式的折扣 
		/// </summary>
		public System.Double Discount_Payment
		{
			get {return _discount_Payment;}
			set {_discount_Payment = value;}
		}
		private System.Decimal _charge_Deliver = 0;
		/// <summary>
		/// 运费 
		/// </summary>
		public System.Decimal Charge_Deliver
		{
			get {return _charge_Deliver;}
			set {_charge_Deliver = value;}
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
		private System.Int32 _orderType = 0;
		/// <summary>
		/// 订单类型(0:正常订单;1:缺货的订单;2:有问题订单;) 
		/// </summary>
		public System.Int32 OrderType
		{
			get {return _orderType;}
			set {_orderType = value;}
		}
		private System.Int32 _couponID = 0;
		/// <summary>
		/// 优惠券ID 
		/// </summary>
		public System.Int32 CouponID
		{
			get {return _couponID;}
			set {_couponID = value;}
		}
		private System.Decimal _moneyGoodsHP = 0;
		/// <summary>
		/// 贷款金额合计 
		/// </summary>
		public System.Decimal MoneyGoodsHP
		{
			get {return _moneyGoodsHP;}
			set {_moneyGoodsHP = value;}
		}
		private System.Int32 _storeID = 0;
		/// <summary>
		/// 店铺ID 
		/// </summary>
		public System.Int32 StoreID
		{
			get {return _storeID;}
			set {_storeID = value;}
		}
		private System.Boolean _isVip = false;
		/// <summary>
		/// 是否VIP 
		/// </summary>
		public System.Boolean IsVip
		{
			get {return _isVip;}
			set {_isVip = value;}
		}
		private System.Boolean _isInsurance = false;
		/// <summary>
		/// 是否购买保险 
		/// </summary>
		public System.Boolean IsInsurance
		{
			get {return _isInsurance;}
			set {_isInsurance = value;}
		}
		private System.Int32 _earlyRepaymentStatus = 0;
		/// <summary>
		/// 提前还款状态（0：未申请；1：已申请；2：已确认；3：已还款；） 
		/// </summary>
		public System.Int32 EarlyRepaymentStatus
		{
			get {return _earlyRepaymentStatus;}
			set {_earlyRepaymentStatus = value;}
		}
		private System.Decimal _earlyRepaymentMoney = 0;
		/// <summary>
		/// 提前还款总金额（本金+违约金） 
		/// </summary>
		public System.Decimal EarlyRepaymentMoney
		{
			get {return _earlyRepaymentMoney;}
			set {_earlyRepaymentMoney = value;}
		}
		private System.String _auditor = string.Empty;
		/// <summary>
		/// 审核员 
		/// </summary>
		public System.String Auditor
		{
			get {return _auditor;}
			set {_auditor = value;}
		}
		private DateTime? _auditTime = DateTime.MaxValue;
		/// <summary>
		/// 审核时间 
		/// </summary>
		public DateTime? AuditTime
		{
			get {return _auditTime;}
			set {_auditTime = value;}
		}
		#endregion
	}
}
