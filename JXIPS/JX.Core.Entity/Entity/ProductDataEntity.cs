// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: ProductDataEntity.cs
// 修改时间：2019/4/9 17:45:11
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：ProductData 的实体类.
	/// </summary>
	public partial class ProductDataEntity
	{
		#region Properties
		private System.Int32 _id = 0;
		/// <summary>
		/// ID (主键)(自增长)
		/// </summary>
		public System.Int32 ID
		{
			get {return _id;}
			set {_id = value;}
		}
		private System.Int32 _productID = 0;
		/// <summary>
		/// 所属商品ID 对应GeneralID为实连接 
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
		private System.String _propertyValue = string.Empty;
		/// <summary>
		/// 属性值。如：红色|加大码，用|分隔几个属性的组合查询 
		/// </summary>
		public System.String PropertyValue
		{
			get {return _propertyValue;}
			set {_propertyValue = value;}
		}
		private System.Int32 _stocks = 0;
		/// <summary>
		/// 库存数量 
		/// </summary>
		public System.Int32 Stocks
		{
			get {return _stocks;}
			set {_stocks = value;}
		}
		private System.Int32 _orderNum = 0;
		/// <summary>
		/// 订货数量 
		/// </summary>
		public System.Int32 OrderNum
		{
			get {return _orderNum;}
			set {_orderNum = value;}
		}
		private System.Int32 _alarmNum = 0;
		/// <summary>
		/// 库存报警下限 
		/// </summary>
		public System.Int32 AlarmNum
		{
			get {return _alarmNum;}
			set {_alarmNum = value;}
		}
		private System.Int32 _buyTimes = 0;
		/// <summary>
		/// 购买次数 
		/// </summary>
		public System.Int32 BuyTimes
		{
			get {return _buyTimes;}
			set {_buyTimes = value;}
		}
		private System.Double _weight = 0.0f;
		/// <summary>
		/// 商品重量 
		/// </summary>
		public System.Double Weight
		{
			get {return _weight;}
			set {_weight = value;}
		}
		private System.Double _volume = 0.0f;
		/// <summary>
		/// 商品体积 
		/// </summary>
		public System.Double Volume
		{
			get {return _volume;}
			set {_volume = value;}
		}
		private System.Decimal _price = 0;
		/// <summary>
		/// 零售价 
		/// </summary>
		public System.Decimal Price
		{
			get {return _price;}
			set {_price = value;}
		}
		private System.Decimal _price_Market = 0;
		/// <summary>
		/// 市场参考价 
		/// </summary>
		public System.Decimal Price_Market
		{
			get {return _price_Market;}
			set {_price_Market = value;}
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
		private System.Decimal _price_Member = 0;
		/// <summary>
		/// 会员零售价 
		/// </summary>
		public System.Decimal Price_Member
		{
			get {return _price_Member;}
			set {_price_Member = value;}
		}
		private System.Decimal _price_Agent = 0;
		/// <summary>
		/// 代理零售价 
		/// </summary>
		public System.Decimal Price_Agent
		{
			get {return _price_Agent;}
			set {_price_Agent = value;}
		}
		private System.Decimal _price_Wholesale1 = 0;
		/// <summary>
		/// 批发价1 
		/// </summary>
		public System.Decimal Price_Wholesale1
		{
			get {return _price_Wholesale1;}
			set {_price_Wholesale1 = value;}
		}
		private System.Decimal _price_Wholesale2 = 0;
		/// <summary>
		/// 批发价2 
		/// </summary>
		public System.Decimal Price_Wholesale2
		{
			get {return _price_Wholesale2;}
			set {_price_Wholesale2 = value;}
		}
		private System.Decimal _price_Wholesale3 = 0;
		/// <summary>
		/// 批发价3 
		/// </summary>
		public System.Decimal Price_Wholesale3
		{
			get {return _price_Wholesale3;}
			set {_price_Wholesale3 = value;}
		}
		private System.Int32 _number_Wholesale1 = 0;
		/// <summary>
		/// 一次性购买此商品数量1 
		/// </summary>
		public System.Int32 Number_Wholesale1
		{
			get {return _number_Wholesale1;}
			set {_number_Wholesale1 = value;}
		}
		private System.Int32 _number_Wholesale2 = 0;
		/// <summary>
		/// 一次性购买此商品数量2 
		/// </summary>
		public System.Int32 Number_Wholesale2
		{
			get {return _number_Wholesale2;}
			set {_number_Wholesale2 = value;}
		}
		private System.Int32 _number_Wholesale3 = 0;
		/// <summary>
		/// 一次性购买此商品数量3 
		/// </summary>
		public System.Int32 Number_Wholesale3
		{
			get {return _number_Wholesale3;}
			set {_number_Wholesale3 = value;}
		}
		private System.Boolean _isValid = false;
		/// <summary>
		/// 是否有效 
		/// </summary>
		public System.Boolean IsValid
		{
			get {return _isValid;}
			set {_isValid = value;}
		}
		#endregion
	}
}
