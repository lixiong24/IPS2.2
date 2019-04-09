// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: InvoiceLogEntity.cs
// 修改时间：2019/4/9 17:45:09
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：InvoiceLog 的实体类.
	/// </summary>
	public partial class InvoiceLogEntity
	{
		#region Properties
		private System.Int32 _invoiceID = 0;
		/// <summary>
		/// 发票记录ID (主键)(自增长)
		/// </summary>
		public System.Int32 InvoiceID
		{
			get {return _invoiceID;}
			set {_invoiceID = value;}
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
		private System.Int32 _invoiceType = 0;
		/// <summary>
		/// 发票类型 
		/// </summary>
		public System.Int32 InvoiceType
		{
			get {return _invoiceType;}
			set {_invoiceType = value;}
		}
		private System.String _invoiceNum = string.Empty;
		/// <summary>
		/// 发票号码 
		/// </summary>
		public System.String InvoiceNum
		{
			get {return _invoiceNum;}
			set {_invoiceNum = value;}
		}
		private System.String _invoiceTitle = string.Empty;
		/// <summary>
		/// 发票抬头 
		/// </summary>
		public System.String InvoiceTitle
		{
			get {return _invoiceTitle;}
			set {_invoiceTitle = value;}
		}
		private System.String _invoiceContent = string.Empty;
		/// <summary>
		/// 发票内容 
		/// </summary>
		public System.String InvoiceContent
		{
			get {return _invoiceContent;}
			set {_invoiceContent = value;}
		}
		private DateTime? _invoiceDate = DateTime.MaxValue;
		/// <summary>
		/// 发票日期 
		/// </summary>
		public DateTime? InvoiceDate
		{
			get {return _invoiceDate;}
			set {_invoiceDate = value;}
		}
		private System.Decimal _totalMoney = 0;
		/// <summary>
		/// 发票金额 
		/// </summary>
		public System.Decimal TotalMoney
		{
			get {return _totalMoney;}
			set {_totalMoney = value;}
		}
		private System.String _drawer = string.Empty;
		/// <summary>
		/// 开票人 
		/// </summary>
		public System.String Drawer
		{
			get {return _drawer;}
			set {_drawer = value;}
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
		private DateTime? _inputTime = DateTime.MaxValue;
		/// <summary>
		/// 录入时间 
		/// </summary>
		public DateTime? InputTime
		{
			get {return _inputTime;}
			set {_inputTime = value;}
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
