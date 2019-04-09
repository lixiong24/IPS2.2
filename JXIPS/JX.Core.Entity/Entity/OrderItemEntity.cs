// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: OrderItemEntity.cs
// 修改时间：2019/4/9 17:45:11
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：OrderItem 的实体类.
	/// </summary>
	public partial class OrderItemEntity
	{
		#region Properties
		private System.Int32 _itemID = 0;
		/// <summary>
		/// ID (主键)
		/// </summary>
		public System.Int32 ItemID
		{
			get {return _itemID;}
			set {_itemID = value;}
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
		private System.Int32 _productID = 0;
		/// <summary>
		/// 产品ID 
		/// </summary>
		public System.Int32 ProductID
		{
			get {return _productID;}
			set {_productID = value;}
		}
		private System.String _tableName = string.Empty;
		/// <summary>
		/// 表名 
		/// </summary>
		public System.String TableName
		{
			get {return _tableName;}
			set {_tableName = value;}
		}
		private System.String _property = string.Empty;
		/// <summary>
		/// 属性，如果是单一商品这属性为空 
		/// </summary>
		public System.String Property
		{
			get {return _property;}
			set {_property = value;}
		}
		private System.Int32 _saleType = 0;
		/// <summary>
		/// 销售类型  1--正常销售  2--换购  3--赠送  4--批发 
		/// </summary>
		public System.Int32 SaleType
		{
			get {return _saleType;}
			set {_saleType = value;}
		}
		private System.Decimal _price_Market = 0;
		/// <summary>
		/// 原价 
		/// </summary>
		public System.Decimal Price_Market
		{
			get {return _price_Market;}
			set {_price_Market = value;}
		}
		private System.Decimal _price = 0;
		/// <summary>
		/// 系统计算出的销售价 
		/// </summary>
		public System.Decimal Price
		{
			get {return _price;}
			set {_price = value;}
		}
		private System.Decimal _price_Activity = 0;
		/// <summary>
		/// 活动价 
		/// </summary>
		public System.Decimal Price_Activity
		{
			get {return _price_Activity;}
			set {_price_Activity = value;}
		}
		private System.Decimal _price_Settlement = 0;
		/// <summary>
		/// 结算价 
		/// </summary>
		public System.Decimal Price_Settlement
		{
			get {return _price_Settlement;}
			set {_price_Settlement = value;}
		}
		private System.Decimal _truePrice = 0;
		/// <summary>
		/// 实际销售价 
		/// </summary>
		public System.Decimal TruePrice
		{
			get {return _truePrice;}
			set {_truePrice = value;}
		}
		private System.Int32 _amount = 0;
		/// <summary>
		/// 订购数量 
		/// </summary>
		public System.Int32 Amount
		{
			get {return _amount;}
			set {_amount = value;}
		}
		private System.Decimal _subTotal = 0;
		/// <summary>
		/// 订购金额 
		/// </summary>
		public System.Decimal SubTotal
		{
			get {return _subTotal;}
			set {_subTotal = value;}
		}
		private DateTime? _beginDate = DateTime.MaxValue;
		/// <summary>
		/// 开始计算服务期限日期 
		/// </summary>
		public DateTime? BeginDate
		{
			get {return _beginDate;}
			set {_beginDate = value;}
		}
		private System.Double _serviceTerm = 0.0f;
		/// <summary>
		/// 服务期限 
		/// </summary>
		public System.Double ServiceTerm
		{
			get {return _serviceTerm;}
			set {_serviceTerm = value;}
		}
		private System.Int32 _serviceTermUnit = 0;
		/// <summary>
		/// 服务年限单位　0－年，1－月，2－日 
		/// </summary>
		public System.Int32 ServiceTermUnit
		{
			get {return _serviceTermUnit;}
			set {_serviceTermUnit = value;}
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
		private System.Decimal _presentMoney = 0;
		/// <summary>
		/// 返还的现金券 
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
		private System.Int32 _productCharacter = 0;
		/// <summary>
		/// 商品性质 
		/// </summary>
		public System.Int32 ProductCharacter
		{
			get {return _productCharacter;}
			set {_productCharacter = value;}
		}
		private System.String _productName = string.Empty;
		/// <summary>
		/// 商品名称 
		/// </summary>
		public System.String ProductName
		{
			get {return _productName;}
			set {_productName = value;}
		}
		private System.String _unit = string.Empty;
		/// <summary>
		/// 单位 
		/// </summary>
		public System.String Unit
		{
			get {return _unit;}
			set {_unit = value;}
		}
		private System.Double _weight = 0.0f;
		/// <summary>
		/// 重量 
		/// </summary>
		public System.Double Weight
		{
			get {return _weight;}
			set {_weight = value;}
		}
		private System.Decimal _chargeDeliverItem = 0;
		/// <summary>
		/// 运费 
		/// </summary>
		public System.Decimal ChargeDeliverItem
		{
			get {return _chargeDeliverItem;}
			set {_chargeDeliverItem = value;}
		}
		private System.Int32 _deliverStatusItem = 0;
		/// <summary>
		/// 物流状态 
		/// </summary>
		public System.Int32 DeliverStatusItem
		{
			get {return _deliverStatusItem;}
			set {_deliverStatusItem = value;}
		}
		private System.Int32 _payStatusItem = 0;
		/// <summary>
		/// 付款状态（0：未付款；1：已付款；2：已退款；） 
		/// </summary>
		public System.Int32 PayStatusItem
		{
			get {return _payStatusItem;}
			set {_payStatusItem = value;}
		}
		private System.Decimal _downPayment = 0;
		/// <summary>
		/// 首付（元） 
		/// </summary>
		public System.Decimal DownPayment
		{
			get {return _downPayment;}
			set {_downPayment = value;}
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
		private System.Decimal _subTotalHP = 0;
		/// <summary>
		/// 贷款金额（小计） 
		/// </summary>
		public System.Decimal SubTotalHP
		{
			get {return _subTotalHP;}
			set {_subTotalHP = value;}
		}
		#endregion
	}
}
