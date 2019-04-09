// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: CreditLinesLogEntity.cs
// 修改时间：2019/4/9 17:45:07
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：CreditLinesLog 的实体类.
	/// </summary>
	public partial class CreditLinesLogEntity
	{
		#region Properties
		private System.Int32 _logID = 0;
		/// <summary>
		///  (主键)(自增长)
		/// </summary>
		public System.Int32 LogID
		{
			get {return _logID;}
			set {_logID = value;}
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
		private System.Decimal _creditLines = 0;
		/// <summary>
		/// 授信额度 
		/// </summary>
		public System.Decimal CreditLines
		{
			get {return _creditLines;}
			set {_creditLines = value;}
		}
		private System.Int32 _incomePayout = 0;
		/// <summary>
		/// 类型  1--收入  2--支出  3--替换 
		/// </summary>
		public System.Int32 IncomePayout
		{
			get {return _incomePayout;}
			set {_incomePayout = value;}
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
		private System.String _remark = string.Empty;
		/// <summary>
		/// 备注/说明 
		/// </summary>
		public System.String Remark
		{
			get {return _remark;}
			set {_remark = value;}
		}
		private System.String _ip = string.Empty;
		/// <summary>
		/// IP地址 
		/// </summary>
		public System.String IP
		{
			get {return _ip;}
			set {_ip = value;}
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
		#endregion
	}
}
