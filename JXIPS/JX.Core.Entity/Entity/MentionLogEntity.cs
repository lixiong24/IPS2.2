// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: MentionLogEntity.cs
// 修改时间：2019/4/9 17:45:09
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：MentionLog 的实体类.
	/// </summary>
	public partial class MentionLogEntity
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
		private System.String _applicant = string.Empty;
		/// <summary>
		/// 申请人 
		/// </summary>
		public System.String Applicant
		{
			get {return _applicant;}
			set {_applicant = value;}
		}
		private DateTime? _applicationTime = DateTime.MaxValue;
		/// <summary>
		/// 申请时间 
		/// </summary>
		public DateTime? ApplicationTime
		{
			get {return _applicationTime;}
			set {_applicationTime = value;}
		}
		private System.Decimal _applicationAmount = 0;
		/// <summary>
		/// 申请金额 
		/// </summary>
		public System.Decimal ApplicationAmount
		{
			get {return _applicationAmount;}
			set {_applicationAmount = value;}
		}
		private System.Decimal _handlingCharge = 0;
		/// <summary>
		/// 手续费 
		/// </summary>
		public System.Decimal HandlingCharge
		{
			get {return _handlingCharge;}
			set {_handlingCharge = value;}
		}
		private System.String _bankAccount = string.Empty;
		/// <summary>
		/// 提现账号 
		/// </summary>
		public System.String BankAccount
		{
			get {return _bankAccount;}
			set {_bankAccount = value;}
		}
		private System.Int32 _mentionStatus = 0;
		/// <summary>
		/// 状态（0：已申请，未处理；1：提现成功；2：提现失败；） 
		/// </summary>
		public System.Int32 MentionStatus
		{
			get {return _mentionStatus;}
			set {_mentionStatus = value;}
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
