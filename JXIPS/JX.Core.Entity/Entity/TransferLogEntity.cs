// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: TransferLogEntity.cs
// 修改时间：2019/4/9 17:45:14
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：TransferLog 的实体类.
	/// </summary>
	public partial class TransferLogEntity
	{
		#region Properties
		private System.Int32 _transferLogID = 0;
		/// <summary>
		/// 订单过户记录ID (主键)(自增长)
		/// </summary>
		public System.Int32 TransferLogID
		{
			get {return _transferLogID;}
			set {_transferLogID = value;}
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
		private DateTime? _transferTime = DateTime.MaxValue;
		/// <summary>
		/// 过户时间 
		/// </summary>
		public DateTime? TransferTime
		{
			get {return _transferTime;}
			set {_transferTime = value;}
		}
		private System.String _ownerUserName = string.Empty;
		/// <summary>
		/// 过户人 
		/// </summary>
		public System.String OwnerUserName
		{
			get {return _ownerUserName;}
			set {_ownerUserName = value;}
		}
		private System.String _payerUserName = string.Empty;
		/// <summary>
		/// 付款人 
		/// </summary>
		public System.String PayerUserName
		{
			get {return _payerUserName;}
			set {_payerUserName = value;}
		}
		private System.String _targetUserName = string.Empty;
		/// <summary>
		/// 过户给 
		/// </summary>
		public System.String TargetUserName
		{
			get {return _targetUserName;}
			set {_targetUserName = value;}
		}
		private System.Decimal _poundage = 0;
		/// <summary>
		/// 过户费 
		/// </summary>
		public System.Decimal Poundage
		{
			get {return _poundage;}
			set {_poundage = value;}
		}
		private System.String _inputer = string.Empty;
		/// <summary>
		/// 经手人 
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
		#endregion
	}
}
