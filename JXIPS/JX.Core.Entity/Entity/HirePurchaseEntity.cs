// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: HirePurchaseEntity.cs
// 修改时间：2019/4/9 17:45:08
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：HirePurchase 的实体类.
	/// </summary>
	public partial class HirePurchaseEntity
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
		private System.Int32 _nodeID = 0;
		/// <summary>
		/// 商品类别ID 
		/// </summary>
		public System.Int32 NodeID
		{
			get {return _nodeID;}
			set {_nodeID = value;}
		}
		private System.Int32 _productID = 0;
		/// <summary>
		/// 商品ID 
		/// </summary>
		public System.Int32 ProductID
		{
			get {return _productID;}
			set {_productID = value;}
		}
		private System.Decimal _downPayment = 0;
		/// <summary>
		/// 最低首付比例（%） 
		/// </summary>
		public System.Decimal DownPayment
		{
			get {return _downPayment;}
			set {_downPayment = value;}
		}
		private System.Decimal _downPaymentMax = 0;
		/// <summary>
		/// 最高首付比例（%） 
		/// </summary>
		public System.Decimal DownPaymentMax
		{
			get {return _downPaymentMax;}
			set {_downPaymentMax = value;}
		}
		private System.Decimal _yearRate = 0;
		/// <summary>
		/// 年利率（%） 
		/// </summary>
		public System.Decimal YearRate
		{
			get {return _yearRate;}
			set {_yearRate = value;}
		}
		private System.Decimal _fee = 0;
		/// <summary>
		/// 手续费（%） 
		/// </summary>
		public System.Decimal Fee
		{
			get {return _fee;}
			set {_fee = value;}
		}
		private System.Decimal _merchantRebate = 0;
		/// <summary>
		/// 给商户返点（%） 
		/// </summary>
		public System.Decimal MerchantRebate
		{
			get {return _merchantRebate;}
			set {_merchantRebate = value;}
		}
		private System.Int32 _deadline = 0;
		/// <summary>
		/// 期限 
		/// </summary>
		public System.Int32 Deadline
		{
			get {return _deadline;}
			set {_deadline = value;}
		}
		private System.Decimal _minLoanMoney = 0;
		/// <summary>
		/// 最小贷款金额 
		/// </summary>
		public System.Decimal MinLoanMoney
		{
			get {return _minLoanMoney;}
			set {_minLoanMoney = value;}
		}
		private System.Decimal _maxLoanMoney = 0;
		/// <summary>
		/// 最高贷款金额 
		/// </summary>
		public System.Decimal MaxLoanMoney
		{
			get {return _maxLoanMoney;}
			set {_maxLoanMoney = value;}
		}
		#endregion
	}
}
