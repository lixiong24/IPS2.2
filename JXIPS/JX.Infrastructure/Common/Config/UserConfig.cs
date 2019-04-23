using System.ComponentModel.DataAnnotations;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 会员参数配置文件类
	/// </summary>
	public class UserConfig
    {
		#region 会员注册
		/// <summary>
		/// 是否开启会员注册功能
		/// </summary>
		public bool EnableUserReg { get; set; } = true;
		/// <summary>
		/// 是否允许一个Email注册多个会员
		/// </summary>
		public bool EnableMultiRegPerEmail { get; set; } = true;
		/// <summary>
		/// 新会员注册时用户名最少字符数
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int UserNameLimit { get; set; } = 3;
		/// <summary>
		/// 新会员注册时用户名最大字符数
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int UserNameMax { get; set; } = 20;
		/// <summary>
		/// 禁止注册的用户名
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string UserNameRegDisabled { get; set; }
		/// <summary>
		/// 是否启用注册企业功能
		/// </summary>
		public bool EnableRegCompany { get; set; } = false;
		/// <summary>
		/// 会员注册时是否启用验证码功能
		/// </summary>
		public bool EnableCheckCodeOfReg { get; set; } = false;
		/// <summary>
		/// 新会员注册是否需要管理员认证
		/// </summary>
		public bool AdminCheckReg { get; set; } = false;
		/// <summary>
		/// 新会员注册是否需要邮件验证
		/// </summary>
		public bool EmailCheckReg { get; set; } = false;
		/// <summary>
		/// 新会员注册时发送的验证邮件内容
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string EmailOfRegCheck { get; set; } = "";
		/// <summary>
		/// 新会员注册成功后所属会员组
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int GroupID { get; set; } = 1;
		#endregion

		#region 登录相关
		/// <summary>
		/// 会员登录时是否启用验证码功能
		/// </summary>
		public bool EnableCheckCodeOfLogOn { get; set; } = false;
		/// <summary>
		/// 会员登录时是否允许多人同时使用同一会员帐号
		/// </summary>
		public bool EnableMultiLogOn { get; set; } = true;
		#endregion

		#region 注册赠送
		/// <summary>
		/// 新会员注册时赠送的积分
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public double PresentExp { get; set; } = 0;
		/// <summary>
		/// 新会员注册时赠送的金钱
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public double PresentMoney { get; set; } = 0;
		/// <summary>
		/// 新会员注册时赠送的点券
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int PresentPoint { get; set; } = 0;
		/// <summary>
		/// 新会员注册时赠送的有效期
		/// </summary>
		[RegularExpression(RegexHelper.NumberSignPattern, ErrorMessage = "只能输入数字")]
		public int PresentValidNum { get; set; } = 0;
		/// <summary>
		/// 新会员注册时赠送的有效期单位
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int PresentValidUnit { get; set; } = 1;
		#endregion

		#region 登录赠送
		/// <summary>
		/// 会员每登录一次奖励的积分
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public double PresentExpPerLogOn { get; set; } = 0;
		/// <summary>
		/// 会员每登录一次奖励的点券
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public double AddPointPerLogOn { get; set; } = 0;
		#endregion

		#region 是否启用点券、金额、积分、有效期功能
		/// <summary>
		/// 是否启用点券、金额、积分、有效期功能
		/// </summary>
		public bool EnablePointMoneyExp { get; set; } = true;
		/// <summary>
		/// 是否启用会员的点券功能
		/// </summary>
		public bool EnablePoint { get; set; } = true;
		/// <summary>
		/// 是否启用会员的资金功能
		/// </summary>
		public bool EnableMoney { get; set; } = true;
		/// <summary>
		/// 是否启用会员的积分功能
		/// </summary>
		public bool EnableExp { get; set; } = true;
		/// <summary>
		/// 是否启用会员的有效期功能
		/// </summary>
		public bool EnableValidNum { get; set; } = true;
		#endregion

		#region 资金与积分兑换比率
		/// <summary>
		/// 会员的资金与积分的兑换比率(资金)
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public double MoneyExchangeExpByMoney { get; set; }
		/// <summary>
		/// 会员的资金与积分的兑换比率（积分）
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public double MoneyExchangeExpByExp { get; set; }
		/// <summary>
		/// 会员的资金与积分的兑换比率
		/// </summary>
		[RegularExpression(RegexHelper.PositiveNumPattern, ErrorMessage = "只能输入数字")]
		public double MoneyExchangeExpRatio { get; set; }
		#endregion

		#region 资金与点卷兑换比率
		/// <summary>
		/// 会员的资金与点券的兑换比率(资金)
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public double MoneyExchangePointByMoney { get; set; }
		/// <summary>
		/// 会员的资金与点券的兑换比率（点券）
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public double MoneyExchangePointByPoint { get; set; }
		/// <summary>
		/// 会员的资金与点券的兑换比率
		/// </summary>
		[RegularExpression(RegexHelper.PositiveNumPattern, ErrorMessage = "只能输入数字")]
		public double MoneyExchangePointRatio { get; set; }
		#endregion

		#region 资金与有效期兑换比率
		/// <summary>
		/// 会员的资金与有效期的兑换比率
		/// </summary>
		[RegularExpression(RegexHelper.PositiveNumPattern, ErrorMessage = "只能输入数字")]
		public double MoneyExchangeValidDayRatio { get; set; }
		/// <summary>
		/// 会员的资金与有效期的兑换比率(资金)
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public double MoneyExchangeValidDayByMoney { get; set; }
		/// <summary>
		/// 会员的资金与有效期的兑换比率(有效期)
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public double MoneyExchangeValidDayByValidDay { get; set; }
		#endregion

		#region 积分与点卷兑换比率
		/// <summary>
		/// 会员的积分与点券的兑换比率
		/// </summary>
		[RegularExpression(RegexHelper.PositiveNumPattern, ErrorMessage = "只能输入数字")]
		public double UserExpExchangePointRatio { get; set; }
		/// <summary>
		/// 会员的积分与点券的兑换比率(积分)
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public double UserExpExchangePointByExp { get; set; }
		/// <summary>
		/// 会员的积分与点券的兑换比率(点券)
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public double UserExpExchangePointByPoint { get; set; }
		#endregion

		#region 积分与有效期兑换比率
		/// <summary>
		/// 会员的积分与有效期的兑换比率
		/// </summary>
		[RegularExpression(RegexHelper.PositiveNumPattern, ErrorMessage = "只能输入数字")]
		public double UserExpExchangeValidDayRatio { get; set; }
		/// <summary>
		/// 会员的积分与有效期的兑换比率(积分)
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public double UserExpExchangeValidDayByExp { get; set; }
		/// <summary>
		/// 会员的积分与有效期的兑换比率(有效期)
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public double UserExpExchangeValidDayByValidDay { get; set; }
		#endregion

		#region 积分名称
		/// <summary>
		/// 积分的名称
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string ExpName { get; set; } = "";
		/// <summary>
		/// 积分的单位
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string ExpUnit { get; set; } = "";
		#endregion

		#region 点卷名称
		/// <summary>
		/// 点券的名称
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string PointName { get; set; } = "金币";
		/// <summary>
		/// 点券的单位
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string PointUnit { get; set; } = "个";
		#endregion

		#region 提现相关
		/// <summary>
		/// 提现起始金额
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int MentionMoneyBegin { set; get; }
		/// <summary>
		/// 提现起始费用
		/// </summary>
		[RegularExpression(RegexHelper.PositiveNumPattern, ErrorMessage = "只能输入数字")]
		public double MentionFeeBegin { set; get; }
		/// <summary>
		/// 提现第一档金额
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int MentionMoneyBegin1 { set; get; }
		/// <summary>
		/// 提现第一档费用
		/// </summary>
		[RegularExpression(RegexHelper.PositiveNumPattern, ErrorMessage = "只能输入数字")]
		public double MentionFeeBegin1 { set; get; }
		#endregion

		/// <summary>
		/// 会员升级成功时发送的邮件内容
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string EmailOfUpgrade { get; set; } = "";

		
	}
}
