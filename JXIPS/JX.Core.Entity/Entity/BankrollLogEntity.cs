// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: BankrollLogEntity.cs
// 修改时间：2019/4/9 17:45:03
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：BankrollLog 的实体类.
	/// </summary>
	public partial class BankrollLogEntity
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
		private System.String _userName = string.Empty;
		/// <summary>
		/// 会员名 
		/// </summary>
		public System.String UserName
		{
			get {return _userName;}
			set {_userName = value;}
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
		private DateTime? _dateAndTime = DateTime.MaxValue;
		/// <summary>
		/// 发生时间 
		/// </summary>
		public DateTime? DateAndTime
		{
			get {return _dateAndTime;}
			set {_dateAndTime = value;}
		}
		private System.Decimal _money = 0;
		/// <summary>
		/// 金额 
		/// </summary>
		public System.Decimal Money
		{
			get {return _money;}
			set {_money = value;}
		}
		private System.Int32 _moneyType = 0;
		/// <summary>
		/// 类型(1:现金 2:汇款 3:在线支付  4:虚拟货币) 
		/// </summary>
		public System.Int32 MoneyType
		{
			get {return _moneyType;}
			set {_moneyType = value;}
		}
		private System.Int32 _currencyType = 0;
		/// <summary>
		/// 币种(1:人民币 2:美元 3:其他) 
		/// </summary>
		public System.Int32 CurrencyType
		{
			get {return _currencyType;}
			set {_currencyType = value;}
		}
		private System.Int32 _eBankID = 0;
		/// <summary>
		/// 网上支付平台ID 
		/// </summary>
		public System.Int32 EBankID
		{
			get {return _eBankID;}
			set {_eBankID = value;}
		}
		private System.String _bank = string.Empty;
		/// <summary>
		/// 银行名称 
		/// </summary>
		public System.String Bank
		{
			get {return _bank;}
			set {_bank = value;}
		}
		private System.Int32 _orderID = 0;
		/// <summary>
		/// 支出时的订单ID 
		/// </summary>
		public System.Int32 OrderID
		{
			get {return _orderID;}
			set {_orderID = value;}
		}
		private System.Int32 _paymentID = 0;
		/// <summary>
		/// 在线支付的支付单ID 
		/// </summary>
		public System.Int32 PaymentID
		{
			get {return _paymentID;}
			set {_paymentID = value;}
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
		private DateTime? _logTime = DateTime.MaxValue;
		/// <summary>
		/// 记录时间 
		/// </summary>
		public DateTime? LogTime
		{
			get {return _logTime;}
			set {_logTime = value;}
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
		private System.String _ip = string.Empty;
		/// <summary>
		/// IP 
		/// </summary>
		public System.String IP
		{
			get {return _ip;}
			set {_ip = value;}
		}
		private System.Int32 _status = 0;
		/// <summary>
		/// 资金状态 
		/// </summary>
		public System.Int32 Status
		{
			get {return _status;}
			set {_status = value;}
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
