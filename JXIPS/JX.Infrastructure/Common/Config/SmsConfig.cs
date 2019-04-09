namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 手机短信配置文件类
	/// </summary>
	public class SmsConfig
    {
		/// <summary>
		/// 管理员的手机号码
		/// </summary>
		public string AdminPhoneNumber { get; set; }

		/// <summary>
		/// 给会员添加银行汇款记录时发送的手机短信内容
		/// </summary>
		public string BankLogMessage { get; set; }

		/// <summary>
		/// 购物车管理手机催单短信通知内容
		/// </summary>
		public string CartInformMessage { get; set; }

		/// <summary>
		/// 确认审核时发送的手机短信内容
		/// </summary>
		public string ChangeStateMessage { get; set; }

		/// <summary>
		/// 确认订单时手机短信通知内容
		/// </summary>
		public string ConfirmOrderMessage { get; set; }

		/// <summary>
		/// 发出货物后手机短信通知内容
		/// </summary>
		public string ConsignmentMessage { get; set; }

		/// <summary>
		/// 给会员奖励有效期时发送的手机短信内容
		/// </summary>
		public string EncouragePeriodMessage { get; set; }

		/// <summary>
		/// 给会员奖励点券时发送的手机短信内容
		/// </summary>
		public string EncouragePointMessage { get; set; }

		/// <summary>
		/// 给会员兑换有效期时发送的手机短信内容
		/// </summary>
		public string ExchangePeriodMessage { get; set; }

		/// <summary>
		/// 给会员兑换点券时发送的手机短信内容
		/// </summary>
		public string ExchangePointMessage { get; set; }

		/// <summary>
		/// 给会员添加其他收入记录时发送的手机短信内容
		/// </summary>
		public string IncomeLogMessage { get; set; }

		/// <summary>
		/// 开发票后手机短信通知内容
		/// </summary>
		public string InvoiceMessage { get; set; }

		/// <summary>
		/// 客户在线支付成功后是否给客户发送手机短信，告知其卡号和密码
		/// </summary>
		public bool IsAutoSendCardNumber { get; set; }

		/// <summary>
		/// 客户提交订单时，系统是否自动发送手机短信通知管理员
		/// </summary>
		public bool IsAutoSendMessage { get; set; }

		/// <summary>
		/// 管理员审核信息后是否发送手机短信告知会员
		/// </summary>
		public bool IsAutoSendStateMessage { get; set; }

		/// <summary>
		/// 客户下订单时系统给管理员发送短信的内容
		/// </summary>
		public string OrderMessage { get; set; }

		/// <summary>
		/// 缺货登记补货手机短信内容
		/// </summary>
		public string OutOfStockMessage { get; set; }

		/// <summary>
		/// 给会员添加支出记录时发送的手机短信内容
		/// </summary>
		public string PayoutLogMessage { get; set; }

		/// <summary>
		/// 给会员扣除有效期时发送的手机短信内容
		/// </summary>
		public string PayoutPeriodMessage { get; set; }

		/// <summary>
		/// 给会员扣除点券时发送的手机短信内容
		/// </summary>
		public string PayoutPointMessage { get; set; }

		/// <summary>
		/// 退款后手机短信通知内容
		/// </summary>
		public string RefundmentMessage { get; set; }

		/// <summary>
		/// 收到银行汇款后手机短信通知内容
		/// </summary>
		public string RemitMessage { get; set; }

		/// <summary>
		/// 发送卡号后手机短信通知内容
		/// </summary>
		public string SendCardNumberMessage { get; set; }

		/// <summary>
		/// 通知内容中的可用标签及含义
		/// </summary>
		public string UseLabel { get; set; }

		/// <summary>
		/// 短信通的用户名
		/// </summary>
		public string UserName { get; set; }

		/// <summary>
		/// MD5密钥
		/// </summary>
		public string MD5Key { get; set; }
	}
}
