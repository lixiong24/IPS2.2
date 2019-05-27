using System.ComponentModel.DataAnnotations;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// B2C商店配置文件类
	/// </summary>
	public class ShopConfig
    {
		/// <summary>
		/// 继续购买URL
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string AgainBuyUrl { get; set; }
		/// <summary>
		/// 是否在线支付成功后以邮件发送卡号和密码
		/// </summary>
		public bool CardOnlinePayMail { get; set; }
		/// <summary>
		/// 是否在线支付成功后以站内信发送卡号和密码
		/// </summary>
		public bool CardOnlinePayMessage { get; set; }
		/// <summary>
		/// 是否在线支付成功后以手机短信发送卡号和密码
		/// </summary>
		public bool CardOnlinePayMobilePhone { get; set; }
		/// <summary>
		/// 所在的城市
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string City { get; set; }
		
		
		/// <summary>
		/// 继续购买
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string ContinueBuy { get; set; }
		/// <summary>
		/// 所在国家
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string Country { get; set; }
		/// <summary>
		/// 使用优惠券时是否允许优惠券抵消运费部分
		/// </summary>
		public bool CouponDeliverPay { get; set; }
		
		
		
		
		
		
		
		/// <summary>
		/// 是否启用优惠券功能
		/// </summary>
		public bool EnableCoupon { get; set; }
		/// <summary>
		/// 是否允许游客购买商品
		/// </summary>
		public bool EnableGuestBuy { get; set; }
		/// <summary>
		/// 是否允许会员自主对订单只支付部分金额
		/// </summary>
		public bool EnablePartPay { get; set; }
		
		/// <summary>
		/// 购物车缩略图高度
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		[RegularExpression(RegexHelper.NumberSignPattern, ErrorMessage = "只能输入数字")]
		public int GwcThumbsHeight { get; set; }
		/// <summary>
		/// 购物车缩略图宽度
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		[RegularExpression(RegexHelper.NumberSignPattern, ErrorMessage = "只能输入数字")]
		public int GwcThumbsWidth { get; set; }
		/// <summary>
		/// 是否在购物车显示商品缩略图
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public bool IsGwcShowProducdtThumb { get; set; }
		/// <summary>
		/// 是否在订单信息页的商品列表中显示商品缩略图
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public bool IsOrderProductListShowThumb { get; set; }
		/// <summary>
		/// 是否在收银台显示商品缩略图
		/// </summary>
		public bool IsPaymentShowProducdtThumb { get; set; }
		/// <summary>
		/// 是否开启预付款支付密码功能
		/// </summary>
		public bool IsPayPassword { get; set; }
		/// <summary>
		/// 是否在预览页页面显示商品缩略图
		/// </summary>
		public bool IsPreviewShowProducdtThumb { get; set; }
		/// <summary>
		/// 是否在商品管理页的商品列表中显示商品缩略图
		/// </summary>
		public bool IsProductListThumb { get; set; }
		/// <summary>
		/// 是否启用自动指派跟单员功能
		/// </summary>
		public bool IsSetFunctionary { get; set; }
		/// <summary>
		/// 是否在购物车页面的商品列表显示市场价
		/// </summary>
		public bool IsShowGwcMarkPrice { get; set; }
		/// <summary>
		/// 是否在购物车页面的商品列表中显示商品类别
		/// </summary>
		public bool IsShowGwcProductType { get; set; }
		/// <summary>
		/// 是否在购物车页面的商品列表中显示销售类型
		/// </summary>
		public bool IsShowGwcSaleType { get; set; }
		/// <summary>
		/// 是否在收银台页的商品列表中显示市场价
		/// </summary>
		public bool IsShowPaymentMarkPrice { get; set; }
		/// <summary>
		/// 是否在收银台页的商品列表中显示商品类别
		/// </summary>
		public bool IsShowPaymentProductType { get; set; }
		/// <summary>
		/// 是否在收银台页的商品列表中显示销售类型
		/// </summary>
		public bool IsShowPaymentSaleType { get; set; }
		/// <summary>
		/// 是否在订单预览页的商品列表中显示市场价
		/// </summary>
		public bool IsShowPreviewMarkPrice { get; set; }
		/// <summary>
		/// 是否在订单预览页的商品列表中显示商品类别
		/// </summary>
		public bool IsShowPreviewProductType { get; set; }
		/// <summary>
		/// 是否在订单预览页的商品列表中显示销售类型
		/// </summary>
		public bool IsShowPreviewSaleType { get; set; }
		/// <summary>
		/// 是否自动生成缩略图
		/// </summary>
		public bool IsThumb { get; set; }
		/// <summary>
		/// 是否给商品图片添加水印
		/// </summary>
		public bool IsWatermark { get; set; }
		/// <summary>
		/// 添加银行汇款时资金与赠送金币的比率
		/// </summary>
		[RegularExpression(RegexHelper.PositiveNumSignPattern, ErrorMessage = "只能输入数字")]
		public decimal MoneyPresentPoint { get; set; }
		
		/// <summary>
		/// 订单信息页的商品缩略图高度
		/// </summary>
		[RegularExpression(RegexHelper.NumberSignPattern, ErrorMessage = "只能输入数字")]
		public int OrderProductListThumbsHeight { get; set; }
		/// <summary>
		/// 订单信息页的商品缩略图宽度
		/// </summary>
		[RegularExpression(RegexHelper.NumberSignPattern, ErrorMessage = "只能输入数字")]
		public int OrderProductListThumbsWidth { get; set; }
		/// <summary>
		/// 订单商品种类的数量限制,当设置为＂0＂时，代表不限制.
		/// </summary>
		[RegularExpression(RegexHelper.NumberSignPattern, ErrorMessage = "只能输入数字")]
		public int OrderProductNumber { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[RegularExpression(RegexHelper.NumberSignPattern, ErrorMessage = "只能输入数字")]
		public int PartPayAge { get; set; }
		/// <summary>
		/// 收银台显示商品缩略图高度
		/// </summary>
		[RegularExpression(RegexHelper.NumberSignPattern, ErrorMessage = "只能输入数字")]
		public int PaymentThumbsHeight { get; set; }
		/// <summary>
		/// 收银台显示商品缩略图宽度
		/// </summary>
		[RegularExpression(RegexHelper.NumberSignPattern, ErrorMessage = "只能输入数字")]
		public int PaymentThumbsWidth { get; set; }
		/// <summary>
		/// 邮政编码
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		[RegularExpression(RegexHelper.ZipCodePattern, ErrorMessage = "请输入正确的邮政编号")]
		public string PostCode { get; set; }
		/// <summary>
		/// 订单编号前缀
		/// </summary>
		[RegularExpression(RegexHelper.PrefixPattern, ErrorMessage = "只能输入2-6位的字母和数字")]
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string PrefixOrderFormNum { get; set; }
		/// <summary>
		/// 在线支付单编号前缀
		/// </summary>
		[RegularExpression(RegexHelper.PrefixPattern, ErrorMessage = "只能输入2-6位的字母和数字")]
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string PrefixPaymentNum { get; set; }
		/// <summary>
		/// 预览页面显示商品缩略图高度
		/// </summary>
		[RegularExpression(RegexHelper.NumberSignPattern, ErrorMessage = "只能输入数字")]
		public int PreviewThumbsHeight { get; set; }
		/// <summary>
		/// 预览页面显示商品缩略图宽度
		/// </summary>
		[RegularExpression(RegexHelper.NumberSignPattern, ErrorMessage = "只能输入数字")]
		public int PreviewThumbsWidth { get; set; }
		/// <summary>
		/// 产品列表页面显示商品缩略图高度
		/// </summary>
		[RegularExpression(RegexHelper.NumberSignPattern, ErrorMessage = "只能输入数字")]
		public int ProductListThumbsHeight { get; set; }
		/// <summary>
		/// 产品列表页面显示商品缩略图宽度
		/// </summary>
		[RegularExpression(RegexHelper.NumberSignPattern, ErrorMessage = "只能输入数字")]
		public int ProductListThumbsWidth { get; set; }
		/// <summary>
		/// 所在省份
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string Province { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public bool ShoppingCartSendPresent { get; set; }
		/// <summary>
		/// 默认税率设置
		/// </summary>
		[RegularExpression(RegexHelper.PositiveNumSignPattern, ErrorMessage = "只能输入数字")]
		public double TaxRate { get; set; }
		/// <summary>
		/// 默认商品税率优惠类型
		/// </summary>
		[RegularExpression(RegexHelper.NumberSignPattern, ErrorMessage = "只能输入数字")]
		public int TaxRateType { get; set; }
		
		/// <summary>
		/// 是否启用商品分期模块
		/// </summary>
		public bool IsEnableHP { get; set; }
		/// <summary>
		/// 逾期滞纳金费率（%）
		/// </summary>
		[RegularExpression(RegexHelper.PositiveNumSignPattern, ErrorMessage = "只能输入数字")]
		public double OverdueHP { get; set; }
		/// <summary>
		/// 最低逾期滞纳金（元）
		/// </summary>
		[RegularExpression(RegexHelper.PositiveNumSignPattern, ErrorMessage = "只能输入数字")]
		public double MinOverdueHP { get; set; }
		/// <summary>
		/// 最高逾期滞纳金（元）
		/// </summary>
		[RegularExpression(RegexHelper.PositiveNumSignPattern, ErrorMessage = "只能输入数字")]
		public double MaxOverdueHP { get; set; }
		/// <summary>
		/// 是否购买商品后才能添加评论
		/// </summary>
		public bool IsCommentByBuy { get; set; } = false;
		/// <summary>
		/// 评论成功后，添加的积分
		/// </summary>
		[RegularExpression(RegexHelper.NumberSignPattern, ErrorMessage = "只能输入数字")]
		public int CommentExp { get; set; } = 0;
		/// <summary>
		/// 首单的折扣比例，默认100，表示不打折。
		/// </summary>
		[RegularExpression(RegexHelper.NumberSignPattern, ErrorMessage = "只能输入数字")]
		public int FirstOrderDiscount { get; set; } = 100;
		/// <summary>
		/// 是否启用分销功能
		/// </summary>
		public bool EnableDistributor { get; set; } = false;
		/// <summary>
		/// 一级分销提成比例(%)
		/// </summary>
		[RegularExpression(RegexHelper.PositiveNumSignPattern, ErrorMessage = "只能输入数字")]
		public double DistributorRate1 { get; set; } = 0;
		/// <summary>
		/// 二级分销提成比例(%)
		/// </summary>
		[RegularExpression(RegexHelper.PositiveNumSignPattern, ErrorMessage = "只能输入数字")]
		public double DistributorRate2 { get; set; } = 0;
		/// <summary>
		/// 三级分销提成比例(%)
		/// </summary>
		[RegularExpression(RegexHelper.PositiveNumSignPattern, ErrorMessage = "只能输入数字")]
		public double DistributorRate3 { get; set; } = 0;
		/// <summary>
		/// 是否启用经销商功能
		/// </summary>
		public bool EnableDealer { get; set; } = false;
	}
}
