using System.ComponentModel.DataAnnotations;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// B2C商店站内信/Email模板配置类
	/// </summary>
	public class ShopTemplateConfig
	{
		/// <summary>
		/// 确认订单时站内短信/Email通知内容
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string EmailOfOrderConfirm { get; set; }
		/// <summary>
		/// 收到银行汇款后站内短信/Email通知内容
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string EmailOfReceiptMoney { get; set; }
		/// <summary>
		/// 退款后站内短信/Email通知内容
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string EmailOfRefund { get; set; }
		/// <summary>
		/// 开发票后站内短信/Email通知内容
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string EmailOfInvoice { get; set; }
		/// <summary>
		/// 发出货物后站内短信/Email通知内容
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string EmailOfDeliver { get; set; }
		/// <summary>
		/// 发送卡号后站内短信/Email通知内容
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string EmailOfSendCard { get; set; }
		/// <summary>
		/// 订单打印模板
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string OrderFormat { get; set; }
		/// <summary>
		/// 发货单打印内容模板
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string ConsignmentFormat { get; set; }
		/// <summary>
		/// 发送缺货登记补货邮件通知模板
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string EmailOfSendOutOfStockLog { get; set; }
		/// <summary>
		/// 通知确认订阅的邮件内容模板
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string ConfirmSubscribeEmail { get; set; }
		/// <summary>
		/// 邮件退订模板
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string UnsubscribeEmail { get; set; }
		/// <summary>
		/// 补货单打印模板
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string FillProductFormat { get; set; }
	}
}
