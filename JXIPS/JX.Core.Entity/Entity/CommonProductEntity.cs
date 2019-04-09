// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: CommonProductEntity.cs
// 修改时间：2019/4/9 17:45:05
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：CommonProduct 的实体类.
	/// </summary>
	public partial class CommonProductEntity
	{
		#region Properties
		private System.Int32 _productID = 0;
		/// <summary>
		/// 商品ID (主键)
		/// </summary>
		public System.Int32 ProductID
		{
			get {return _productID;}
			set {_productID = value;}
		}
		private System.String _tableName = string.Empty;
		/// <summary>
		/// 商品模型表名 
		/// </summary>
		public System.String TableName
		{
			get {return _tableName;}
			set {_tableName = value;}
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
		private System.String _productNum = string.Empty;
		/// <summary>
		/// 商品编号 
		/// </summary>
		public System.String ProductNum
		{
			get {return _productNum;}
			set {_productNum = value;}
		}
		private System.Int32 _productType = 0;
		/// <summary>
		/// 商品状态 0--正常  3--特价　4--促销 
		/// </summary>
		public System.Int32 ProductType
		{
			get {return _productType;}
			set {_productType = value;}
		}
		private System.String _unit = string.Empty;
		/// <summary>
		/// 商品单位 
		/// </summary>
		public System.String Unit
		{
			get {return _unit;}
			set {_unit = value;}
		}
		private System.String _productThumb = string.Empty;
		/// <summary>
		/// 商品缩略图 
		/// </summary>
		public System.String ProductThumb
		{
			get {return _productThumb;}
			set {_productThumb = value;}
		}
		private System.String _productPic = string.Empty;
		/// <summary>
		/// 商品大图 
		/// </summary>
		public System.String ProductPic
		{
			get {return _productPic;}
			set {_productPic = value;}
		}
		private System.Int32 _serviceTermUnit = 0;
		/// <summary>
		/// 服务期限单位 0表示年，1表示月，2 表示日 
		/// </summary>
		public System.Int32 ServiceTermUnit
		{
			get {return _serviceTermUnit;}
			set {_serviceTermUnit = value;}
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
		private System.Boolean _isStockOutBuy = false;
		/// <summary>
		/// 缺货时是否允许购买 
		/// </summary>
		public System.Boolean IsStockOutBuy
		{
			get {return _isStockOutBuy;}
			set {_isStockOutBuy = value;}
		}
		private System.Boolean _isWholesale = false;
		/// <summary>
		/// 是否允许批发 
		/// </summary>
		public System.Boolean IsWholesale
		{
			get {return _isWholesale;}
			set {_isWholesale = value;}
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
		private System.Int32 _presentID = 0;
		/// <summary>
		/// 赠品ID 
		/// </summary>
		public System.Int32 PresentID
		{
			get {return _presentID;}
			set {_presentID = value;}
		}
		private System.Int32 _presentNumber = 0;
		/// <summary>
		/// 促销赠送数量 
		/// </summary>
		public System.Int32 PresentNumber
		{
			get {return _presentNumber;}
			set {_presentNumber = value;}
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
		/// 购物积分 
		/// </summary>
		public System.Int32 PresentExp
		{
			get {return _presentExp;}
			set {_presentExp = value;}
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
		private System.Int32 _stocksProject = 0;
		/// <summary>
		/// 库存报警方案 
		/// </summary>
		public System.Int32 StocksProject
		{
			get {return _stocksProject;}
			set {_stocksProject = value;}
		}
		private System.Int32 _salePromotionType = 0;
		/// <summary>
		/// 促销设置 
		/// </summary>
		public System.Int32 SalePromotionType
		{
			get {return _salePromotionType;}
			set {_salePromotionType = value;}
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
		private System.Int32 _minNumber = 0;
		/// <summary>
		/// 促销购买商品最小值 
		/// </summary>
		public System.Int32 MinNumber
		{
			get {return _minNumber;}
			set {_minNumber = value;}
		}
		private System.Double _discount = 0.0f;
		/// <summary>
		/// 折扣率 
		/// </summary>
		public System.Double Discount
		{
			get {return _discount;}
			set {_discount = value;}
		}
		private System.Int32 _includeTax = 0;
		/// <summary>
		/// 是否包括税率 
		/// </summary>
		public System.Int32 IncludeTax
		{
			get {return _includeTax;}
			set {_includeTax = value;}
		}
		private System.Double _taxRate = 0.0f;
		/// <summary>
		/// 税率 
		/// </summary>
		public System.Double TaxRate
		{
			get {return _taxRate;}
			set {_taxRate = value;}
		}
		private System.String _properties = string.Empty;
		/// <summary>
		/// 商品多属性字段，以“\n”分割多个属性。以“*”+字段别名开头的字段为ProductStyle类型，以“$$$”分割每个属性中的名称和值，值后面会加上“$$”，以“|”分割多个值；以字段别名开头的字段为Property类型，以“$$$”分割每个属性中的名称和值，以“|”分割多个值。例：尺码$$$S|M|L*颜色款式$$$黑色$$|白色$$|红色$$ 
		/// </summary>
		public System.String Properties
		{
			get {return _properties;}
			set {_properties = value;}
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
		private System.Int32 _limitNum = 0;
		/// <summary>
		/// 限购数量 
		/// </summary>
		public System.Int32 LimitNum
		{
			get {return _limitNum;}
			set {_limitNum = value;}
		}
		private System.Boolean _isEnableSale = false;
		/// <summary>
		/// 是否销售 
		/// </summary>
		public System.Boolean IsEnableSale
		{
			get {return _isEnableSale;}
			set {_isEnableSale = value;}
		}
		private System.Boolean _isSingleSell = false;
		/// <summary>
		/// 是否允许单独销售 
		/// </summary>
		public System.Boolean IsSingleSell
		{
			get {return _isSingleSell;}
			set {_isSingleSell = value;}
		}
		private System.Int32 _productKind = 0;
		/// <summary>
		/// 商品类别 
		/// </summary>
		public System.Int32 ProductKind
		{
			get {return _productKind;}
			set {_productKind = value;}
		}
		private System.String _dependentProducts = string.Empty;
		/// <summary>
		/// 从属商品 
		/// </summary>
		public System.String DependentProducts
		{
			get {return _dependentProducts;}
			set {_dependentProducts = value;}
		}
		private System.Int32 _stocks = 0;
		/// <summary>
		/// 库存 
		/// </summary>
		public System.Int32 Stocks
		{
			get {return _stocks;}
			set {_stocks = value;}
		}
		private System.Int32 _orderNum = 0;
		/// <summary>
		/// 订购数量 
		/// </summary>
		public System.Int32 OrderNum
		{
			get {return _orderNum;}
			set {_orderNum = value;}
		}
		private System.String _downloadUrl = string.Empty;
		/// <summary>
		/// 下载地址 
		/// </summary>
		public System.String DownloadUrl
		{
			get {return _downloadUrl;}
			set {_downloadUrl = value;}
		}
		private System.String _remark = string.Empty;
		/// <summary>
		/// 下载说明 
		/// </summary>
		public System.String Remark
		{
			get {return _remark;}
			set {_remark = value;}
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
		private System.String _keyword = string.Empty;
		/// <summary>
		/// 关键字，多个关键字以“|”分割 
		/// </summary>
		public System.String Keyword
		{
			get {return _keyword;}
			set {_keyword = value;}
		}
		private System.String _producerName = string.Empty;
		/// <summary>
		/// 厂商 
		/// </summary>
		public System.String ProducerName
		{
			get {return _producerName;}
			set {_producerName = value;}
		}
		private System.String _trademarkName = string.Empty;
		/// <summary>
		/// 品牌 
		/// </summary>
		public System.String TrademarkName
		{
			get {return _trademarkName;}
			set {_trademarkName = value;}
		}
		private System.String _barCode = string.Empty;
		/// <summary>
		/// 条形码 
		/// </summary>
		public System.String BarCode
		{
			get {return _barCode;}
			set {_barCode = value;}
		}
		private System.String _productIntro = string.Empty;
		/// <summary>
		/// 商品简单介绍 
		/// </summary>
		public System.String ProductIntro
		{
			get {return _productIntro;}
			set {_productIntro = value;}
		}
		private System.String _productExplain = string.Empty;
		/// <summary>
		/// 商品详细介绍 
		/// </summary>
		public System.String ProductExplain
		{
			get {return _productExplain;}
			set {_productExplain = value;}
		}
		private System.Boolean _isNew = false;
		/// <summary>
		/// 是否最新 
		/// </summary>
		public System.Boolean IsNew
		{
			get {return _isNew;}
			set {_isNew = value;}
		}
		private System.Boolean _isHot = false;
		/// <summary>
		/// 是否热卖 
		/// </summary>
		public System.Boolean IsHot
		{
			get {return _isHot;}
			set {_isHot = value;}
		}
		private System.Boolean _isBest = false;
		/// <summary>
		/// 是否精品 
		/// </summary>
		public System.Boolean IsBest
		{
			get {return _isBest;}
			set {_isBest = value;}
		}
		private System.Int32 _stars = 0;
		/// <summary>
		/// 商品推荐等级(1-5) 
		/// </summary>
		public System.Int32 Stars
		{
			get {return _stars;}
			set {_stars = value;}
		}
		private System.Int32 _minimum = 0;
		/// <summary>
		/// 最低购买数量 
		/// </summary>
		public System.Int32 Minimum
		{
			get {return _minimum;}
			set {_minimum = value;}
		}
		private System.String _multiplePhoto = string.Empty;
		/// <summary>
		/// 商品多图地址，多个地址以“$$$”分割 
		/// </summary>
		public System.String MultiplePhoto
		{
			get {return _multiplePhoto;}
			set {_multiplePhoto = value;}
		}
		private System.Boolean _isEnableHP = false;
		/// <summary>
		/// 是否启用分期付款 
		/// </summary>
		public System.Boolean IsEnableHP
		{
			get {return _isEnableHP;}
			set {_isEnableHP = value;}
		}
		#endregion
	}
}
