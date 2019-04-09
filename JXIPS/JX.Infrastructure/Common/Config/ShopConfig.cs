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
		public string City { get; set; }
		/// <summary>
		/// 通知确认订阅的邮件内容模板
		/// </summary>
		public string ConfirmSubscribeEmail { get; set; }
		/// <summary>
		/// 发货单打印内容模板
		/// </summary>
		public string ConsignmentFormat { get; set; }
		/// <summary>
		/// 继续购买
		/// </summary>
		public string ContinueBuy { get; set; }
		/// <summary>
		/// 所在国家
		/// </summary>
		public string Country { get; set; }
		/// <summary>
		/// 使用优惠券时是否允许优惠券抵消运费部分
		/// </summary>
		public bool CouponDeliverPay { get; set; }
		/// <summary>
		/// 发出货物后站内短信/Email通知内容
		/// </summary>
		public string EmailOfDeliver { get; set; }
		/// <summary>
		/// 开发票后站内短信/Email通知内容
		/// </summary>
		public string EmailOfInvoice { get; set; }
		/// <summary>
		/// 确认订单时站内短信/Email通知内容
		/// </summary>
		public string EmailOfOrderConfirm { get; set; }
		/// <summary>
		/// 收到银行汇款后站内短信/Email通知内容
		/// </summary>
		public string EmailOfReceiptMoney { get; set; }
		/// <summary>
		/// 退款后站内短信/Email通知内容
		/// </summary>
		public string EmailOfRefund { get; set; }
		/// <summary>
		/// 发送卡号后站内短信/Email通知内容
		/// </summary>
		public string EmailOfSendCard { get; set; }
		/// <summary>
		/// 发送缺货登记补货邮件通知模板
		/// </summary>
		public string EmailOfSendOutOfStockLog { get; set; }
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
		/// 补货单打印模板
		/// </summary>
		public string FillProductFormat { get; set; }
		/// <summary>
		/// 购物车缩略图高度
		/// </summary>
		public int GwcThumbsHeight { get; set; }
		/// <summary>
		/// 购物车缩略图宽度
		/// </summary>
		public int GwcThumbsWidth { get; set; }
		/// <summary>
		/// 是否在购物车显示商品缩略图
		/// </summary>
		public bool IsGwcShowProducdtThumb { get; set; }
		/// <summary>
		/// 是否在订单信息页的商品列表中显示商品缩略图
		/// </summary>
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
		public decimal MoneyPresentPoint { get; set; }
		/// <summary>
		/// 订单打印模板
		/// </summary>
		public string OrderFormat { get; set; }
		/// <summary>
		/// 订单信息页的商品缩略图高度
		/// </summary>
		public int OrderProductListThumbsHeight { get; set; }
		/// <summary>
		/// 订单信息页的商品缩略图宽度
		/// </summary>
		public int OrderProductListThumbsWidth { get; set; }
		/// <summary>
		/// 订单商品种类的数量限制,当设置为＂0＂时，代表不限制.
		/// </summary>
		public int OrderProductNumber { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public int PartPayAge { get; set; }
		/// <summary>
		/// 收银台显示商品缩略图高度
		/// </summary>
		public int PaymentThumbsHeight { get; set; }
		/// <summary>
		/// 收银台显示商品缩略图宽度
		/// </summary>
		public int PaymentThumbsWidth { get; set; }
		/// <summary>
		/// 邮政编码
		/// </summary>
		public string PostCode { get; set; }
		/// <summary>
		/// 订单编号前缀
		/// </summary>
		public string PrefixOrderFormNum { get; set; }
		/// <summary>
		/// 在线支付单编号前缀
		/// </summary>
		public string PrefixPaymentNum { get; set; }
		/// <summary>
		/// 预览页面显示商品缩略图高度
		/// </summary>
		public int PreviewThumbsHeight { get; set; }
		/// <summary>
		/// 预览页面显示商品缩略图宽度
		/// </summary>
		public int PreviewThumbsWidth { get; set; }
		/// <summary>
		/// 产品列表页面显示商品缩略图高度
		/// </summary>
		public int ProductListThumbsHeight { get; set; }
		/// <summary>
		/// 产品列表页面显示商品缩略图宽度
		/// </summary>
		public int ProductListThumbsWidth { get; set; }
		/// <summary>
		/// 所在省份
		/// </summary>
		public string Province { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public bool ShoppingCartSendPresent { get; set; }
		/// <summary>
		/// 默认税率设置
		/// </summary>
		public float TaxRate { get; set; }
		/// <summary>
		/// 默认商品税率优惠类型
		/// </summary>
		public int TaxRateType { get; set; }
		/// <summary>
		/// 邮件退订模板
		/// </summary>
		public string UnsubscribeEmail { get; set; }

		private bool m_IsEnableHP;
		/// <summary>
		/// 是否启用商品分期模块
		/// </summary>
		public bool IsEnableHP
		{
			get
			{
				return m_IsEnableHP;
			}
			set
			{
				m_IsEnableHP = value;
			}
		}

		private float m_OverdueHP;
		/// <summary>
		/// 逾期滞纳金费率（%）
		/// </summary>
		public float OverdueHP
		{
			get
			{
				return m_OverdueHP;
			}
			set
			{
				m_OverdueHP = value;
			}
		}

		private float m_MinOverdueHP;
		/// <summary>
		/// 最低逾期滞纳金（元）
		/// </summary>
		public float MinOverdueHP
		{
			get
			{
				return m_MinOverdueHP;
			}
			set
			{
				m_MinOverdueHP = value;
			}
		}

		private float m_MaxOverdueHP;
		/// <summary>
		/// 最高逾期滞纳金（元）
		/// </summary>
		public float MaxOverdueHP
		{
			get
			{
				return m_MaxOverdueHP;
			}
			set
			{
				m_MaxOverdueHP = value;
			}
		}

		private bool m_IsCommentByBuy = false;
		/// <summary>
		/// 是否购买商品后才能添加评论
		/// </summary>
		public bool IsCommentByBuy
		{
			get
			{
				return m_IsCommentByBuy;
			}
			set
			{
				m_IsCommentByBuy = value;
			}
		}

		private int m_CommentExp = 0;
		/// <summary>
		/// 评论成功后，添加的积分
		/// </summary>
		public int CommentExp
		{
			get
			{
				return m_CommentExp;
			}
			set
			{
				m_CommentExp = value;
			}
		}

		private int m_FirstOrderDiscount = 100;
		/// <summary>
		/// 首单的折扣比例，默认100，表示不打折。
		/// </summary>
		public int FirstOrderDiscount
		{
			get
			{
				return m_FirstOrderDiscount;
			}
			set
			{
				m_FirstOrderDiscount = value;
			}
		}
	}
}
