// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: SortingLogEntity.cs
// 修改时间：2019/4/9 17:45:12
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：SortingLog 的实体类.
	/// </summary>
	public partial class SortingLogEntity
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
		private System.String _payer = string.Empty;
		/// <summary>
		/// 支付人 
		/// </summary>
		public System.String Payer
		{
			get {return _payer;}
			set {_payer = value;}
		}
		private DateTime? _paymentTime = DateTime.MaxValue;
		/// <summary>
		/// 支付时间 
		/// </summary>
		public DateTime? PaymentTime
		{
			get {return _paymentTime;}
			set {_paymentTime = value;}
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
		private System.Int32 _status = 0;
		/// <summary>
		/// 状态（0：未处理；1：已处理；） 
		/// </summary>
		public System.Int32 Status
		{
			get {return _status;}
			set {_status = value;}
		}
		private System.String _operator = string.Empty;
		/// <summary>
		/// 处理人 
		/// </summary>
		public System.String Operator
		{
			get {return _operator;}
			set {_operator = value;}
		}
		private DateTime? _operatingTime = DateTime.MaxValue;
		/// <summary>
		/// 处理时间 
		/// </summary>
		public DateTime? OperatingTime
		{
			get {return _operatingTime;}
			set {_operatingTime = value;}
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
		/// 日志记录时间 
		/// </summary>
		public DateTime? LogTime
		{
			get {return _logTime;}
			set {_logTime = value;}
		}
		#endregion
	}
}
