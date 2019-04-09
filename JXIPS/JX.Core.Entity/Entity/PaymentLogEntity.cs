// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: PaymentLogEntity.cs
// 修改时间：2019/4/9 17:45:11
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：PaymentLog 的实体类.
	/// </summary>
	public partial class PaymentLogEntity
	{
		#region Properties
		private System.Int32 _paymentLogID = 0;
		/// <summary>
		/// 支付ID (主键)
		/// </summary>
		public System.Int32 PaymentLogID
		{
			get {return _paymentLogID;}
			set {_paymentLogID = value;}
		}
		private System.String _userName = string.Empty;
		/// <summary>
		/// 会员用户名 
		/// </summary>
		public System.String UserName
		{
			get {return _userName;}
			set {_userName = value;}
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
		private System.String _paymentNum = string.Empty;
		/// <summary>
		/// 支付序号 
		/// </summary>
		public System.String PaymentNum
		{
			get {return _paymentNum;}
			set {_paymentNum = value;}
		}
		private System.Int32 _platformID = 0;
		/// <summary>
		/// 支付平台 
		/// </summary>
		public System.Int32 PlatformID
		{
			get {return _platformID;}
			set {_platformID = value;}
		}
		private System.Decimal _moneyPay = 0;
		/// <summary>
		/// 支付金额 
		/// </summary>
		public System.Decimal MoneyPay
		{
			get {return _moneyPay;}
			set {_moneyPay = value;}
		}
		private System.Decimal _moneyTrue = 0;
		/// <summary>
		/// 实际支付金额 
		/// </summary>
		public System.Decimal MoneyTrue
		{
			get {return _moneyTrue;}
			set {_moneyTrue = value;}
		}
		private DateTime? _payTime = DateTime.MaxValue;
		/// <summary>
		/// 交易时间 
		/// </summary>
		public DateTime? PayTime
		{
			get {return _payTime;}
			set {_payTime = value;}
		}
		private DateTime? _successTime = DateTime.MaxValue;
		/// <summary>
		/// 交易成功时间 
		/// </summary>
		public DateTime? SuccessTime
		{
			get {return _successTime;}
			set {_successTime = value;}
		}
		private System.Int32 _status = 0;
		/// <summary>
		/// 支付状态(1：未提交；2：未成功；3：已成功) 
		/// </summary>
		public System.Int32 Status
		{
			get {return _status;}
			set {_status = value;}
		}
		private System.String _platformInfo = string.Empty;
		/// <summary>
		/// 银行信息 
		/// </summary>
		public System.String PlatformInfo
		{
			get {return _platformInfo;}
			set {_platformInfo = value;}
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
		private System.Int32 _exp = 0;
		/// <summary>
		/// 购买积分数 
		/// </summary>
		public System.Int32 Exp
		{
			get {return _exp;}
			set {_exp = value;}
		}
		private System.Int32 _point = 0;
		/// <summary>
		/// 购买点券数 
		/// </summary>
		public System.Int32 Point
		{
			get {return _point;}
			set {_point = value;}
		}
		private System.Int32 _validDate = 0;
		/// <summary>
		/// 购买有效期天数 
		/// </summary>
		public System.Int32 ValidDate
		{
			get {return _validDate;}
			set {_validDate = value;}
		}
		private System.Int32 _groupID = 0;
		/// <summary>
		/// 要升级到的会员组ID 
		/// </summary>
		public System.Int32 GroupID
		{
			get {return _groupID;}
			set {_groupID = value;}
		}
		#endregion
	}
}
