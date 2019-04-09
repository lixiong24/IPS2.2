namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 会员参数配置文件类
	/// </summary>
	public class UserConfig
    {
		#region 注册相关
		private bool m_EnableUserReg;
		/// <summary>
		/// 是否开启会员注册功能
		/// </summary>
		public bool EnableUserReg
		{
			get
			{
				return this.m_EnableUserReg;
			}
			set
			{
				this.m_EnableUserReg = value;
			}
		}

		private bool m_EnableMultiRegPerEmail;
		/// <summary>
		/// 是否允许一个Email注册多个会员
		/// </summary>
		public bool EnableMultiRegPerEmail
		{
			get
			{
				return this.m_EnableMultiRegPerEmail;
			}
			set
			{
				this.m_EnableMultiRegPerEmail = value;
			}
		}

		private int m_UserNameLimit;
		/// <summary>
		/// 新会员注册时用户名最少字符数
		/// </summary>
		public int UserNameLimit
		{
			get
			{
				return this.m_UserNameLimit;
			}
			set
			{
				this.m_UserNameLimit = value;
			}
		}

		private int m_UserNameMax;
		/// <summary>
		/// 新会员注册时用户名最大字符数
		/// </summary>
		public int UserNameMax
		{
			get
			{
				return this.m_UserNameMax;
			}
			set
			{
				this.m_UserNameMax = value;
			}
		}

		private string m_UserName_RegDisabled;
		/// <summary>
		/// 禁止注册的用户名
		/// </summary>
		public string UserNameRegDisabled
		{
			get
			{
				return this.m_UserName_RegDisabled;
			}
			set
			{
				this.m_UserName_RegDisabled = value;
			}
		}

		private bool m_EnableRegCompany;
		/// <summary>
		/// 是否启用注册企业功能
		/// </summary>
		public bool EnableRegCompany
		{
			get
			{
				return this.m_EnableRegCompany;
			}
			set
			{
				this.m_EnableRegCompany = value;
			}
		}

		private bool m_EnableCheckCodeOfReg;
		/// <summary>
		/// 会员注册时是否启用验证码功能
		/// </summary>
		public bool EnableCheckCodeOfReg
		{
			get
			{
				return this.m_EnableCheckCodeOfReg;
			}
			set
			{
				this.m_EnableCheckCodeOfReg = value;
			}
		}

		private bool m_AdminCheckReg;
		/// <summary>
		/// 新会员注册是否需要管理员认证
		/// </summary>
		public bool AdminCheckReg
		{
			get
			{
				return this.m_AdminCheckReg;
			}
			set
			{
				this.m_AdminCheckReg = value;
			}
		}

		private bool m_EmailCheckReg;
		/// <summary>
		/// 新会员注册是否需要邮件验证
		/// </summary>
		public bool EmailCheckReg
		{
			get
			{
				return this.m_EmailCheckReg;
			}
			set
			{
				this.m_EmailCheckReg = value;
			}
		}

		private string m_EmailOfRegCheck;
		/// <summary>
		/// 新会员注册时发送的验证邮件内容
		/// </summary>
		public string EmailOfRegCheck
		{
			get
			{
				return this.m_EmailOfRegCheck;
			}
			set
			{
				this.m_EmailOfRegCheck = value;
			}
		}
		
		private int m_GroupID;
		/// <summary>
		/// 新会员注册成功后所属会员组
		/// </summary>
		public int GroupID
		{
			get
			{
				return this.m_GroupID;
			}
			set
			{
				this.m_GroupID = value;
			}
		}
		#endregion

		#region 登录相关
		private bool m_EnableCheckCodeOfLogOn;
		/// <summary>
		/// 会员登录时是否启用验证码功能
		/// </summary>
		public bool EnableCheckCodeOfLogOn
		{
			get
			{
				return this.m_EnableCheckCodeOfLogOn;
			}
			set
			{
				this.m_EnableCheckCodeOfLogOn = value;
			}
		}

		private bool m_EnableMultiLogOn;
		/// <summary>
		/// 会员登录时是否允许多人同时使用同一会员帐号
		/// </summary>
		public bool EnableMultiLogOn
		{
			get
			{
				return this.m_EnableMultiLogOn;
			}
			set
			{
				this.m_EnableMultiLogOn = value;
			}
		}
		#endregion

		#region 注册赠送
		private double m_PresentExp;
		/// <summary>
		/// 新会员注册时赠送的积分
		/// </summary>
		public double PresentExp
		{
			get
			{
				return this.m_PresentExp;
			}
			set
			{
				this.m_PresentExp = value;
			}
		}

		private double m_PresentMoney;
		/// <summary>
		/// 新会员注册时赠送的金钱
		/// </summary>
		public double PresentMoney
		{
			get
			{
				return this.m_PresentMoney;
			}
			set
			{
				this.m_PresentMoney = value;
			}
		}

		private int m_PresentPoint;
		/// <summary>
		/// 新会员注册时赠送的点券
		/// </summary>
		public int PresentPoint
		{
			get
			{
				return this.m_PresentPoint;
			}
			set
			{
				this.m_PresentPoint = value;
			}
		}

		private int m_PresentValidNum;
		/// <summary>
		/// 新会员注册时赠送的有效期
		/// </summary>
		public int PresentValidNum
		{
			get
			{
				return this.m_PresentValidNum;
			}
			set
			{
				this.m_PresentValidNum = value;
			}
		}

		private int m_PresentValidUnit;
		/// <summary>
		/// 新会员注册时赠送的有效期单位
		/// </summary>
		public int PresentValidUnit
		{
			get
			{
				return this.m_PresentValidUnit;
			}
			set
			{
				this.m_PresentValidUnit = value;
			}
		}
		#endregion

		#region 登录赠送
		private double m_PresentExpPerLogOn;
		/// <summary>
		/// 会员每登录一次奖励的积分
		/// </summary>
		public double PresentExpPerLogOn
		{
			get
			{
				return this.m_PresentExpPerLogOn;
			}
			set
			{
				this.m_PresentExpPerLogOn = value;
			}
		}

		private double m_AddPointPerLogOn;
		/// <summary>
		/// 会员每登录一次奖励的点券
		/// </summary>
		public double AddPointPerLogOn
		{
			get
			{
				return this.m_AddPointPerLogOn;
			}
			set
			{
				this.m_AddPointPerLogOn = value;
			}
		}
		#endregion

		#region 是否启用点券、金额、积分、有效期功能
		private bool m_EnablePointMoneyExp;
		/// <summary>
		/// 是否启用点券、金额、积分、有效期功能
		/// </summary>
		public bool EnablePointMoneyExp
		{
			get
			{
				return this.m_EnablePointMoneyExp;
			}
			set
			{
				this.m_EnablePointMoneyExp = value;
			}
		}

		private bool m_EnablePoint = true;
		/// <summary>
		/// 是否启用会员的点券功能
		/// </summary>
		public bool EnablePoint
		{
			get
			{
				return this.m_EnablePoint;
			}
			set
			{
				this.m_EnablePoint = value;
			}
		}

		private bool m_EnableMoney = true;
		/// <summary>
		/// 是否启用会员的资金功能
		/// </summary>
		public bool EnableMoney
		{
			get
			{
				return this.m_EnableMoney;
			}
			set
			{
				this.m_EnableMoney = value;
			}
		}

		private bool m_EnableExp = true;
		/// <summary>
		/// 是否启用会员的积分功能
		/// </summary>
		public bool EnableExp
		{
			get
			{
				return this.m_EnableExp;
			}
			set
			{
				this.m_EnableExp = value;
			}
		}

		private bool m_EnableValidNum = true;
		/// <summary>
		/// 是否启用会员的有效期功能
		/// </summary>
		public bool EnableValidNum
		{
			get
			{
				return this.m_EnableValidNum;
			}
			set
			{
				this.m_EnableValidNum = value;
			}
		}
		#endregion

		#region 资金与积分兑换比率
		private double m_MoneyExchangeExpByMoney;
		/// <summary>
		/// 会员的资金与积分的兑换比率(资金)
		/// </summary>
		public double MoneyExchangeExpByMoney
		{
			get
			{
				return this.m_MoneyExchangeExpByMoney;
			}
			set
			{
				this.m_MoneyExchangeExpByMoney = value;
			}
		}

		private double m_MoneyExchangeExpByExp;
		/// <summary>
		/// 会员的资金与积分的兑换比率（积分）
		/// </summary>
		public double MoneyExchangeExpByExp
		{
			get
			{
				return this.m_MoneyExchangeExpByExp;
			}
			set
			{
				this.m_MoneyExchangeExpByExp = value;
			}
		}

		private double m_MoneyExchangeExpRatio;
		/// <summary>
		/// 会员的资金与积分的兑换比率
		/// </summary>
		public double MoneyExchangeExpRatio
		{
			get
			{
				return this.m_MoneyExchangeExpRatio;
			}
			set
			{
				this.m_MoneyExchangeExpRatio = value;
			}
		}
		#endregion

		#region 资金与点卷兑换比率
		private double m_MoneyExchangePointByMoney;
		/// <summary>
		/// 会员的资金与点券的兑换比率(资金)
		/// </summary>
		public double MoneyExchangePointByMoney
		{
			get
			{
				return this.m_MoneyExchangePointByMoney;
			}
			set
			{
				this.m_MoneyExchangePointByMoney = value;
			}
		}

		private double m_MoneyExchangePointByPoint;
		/// <summary>
		/// 会员的资金与点券的兑换比率（点券）
		/// </summary>
		public double MoneyExchangePointByPoint
		{
			get
			{
				return this.m_MoneyExchangePointByPoint;
			}
			set
			{
				this.m_MoneyExchangePointByPoint = value;
			}
		}

		private double m_MoneyExchangePointRatio;
		/// <summary>
		/// 会员的资金与点券的兑换比率
		/// </summary>
		public double MoneyExchangePointRatio
		{
			get
			{
				return this.m_MoneyExchangePointRatio;
			}
			set
			{
				this.m_MoneyExchangePointRatio = value;
			}
		}
		#endregion

		#region 资金与有效期兑换比率
		private double m_MoneyExchangeValidDayRatio;
		/// <summary>
		/// 会员的资金与有效期的兑换比率
		/// </summary>
		public double MoneyExchangeValidDayRatio
		{
			get
			{
				return this.m_MoneyExchangeValidDayRatio;
			}
			set
			{
				this.m_MoneyExchangeValidDayRatio = value;
			}
		}

		private double m_MoneyExchangeValidDayByMoney;
		/// <summary>
		/// 会员的资金与有效期的兑换比率(资金)
		/// </summary>
		public double MoneyExchangeValidDayByMoney
		{
			get
			{
				return this.m_MoneyExchangeValidDayByMoney;
			}
			set
			{
				this.m_MoneyExchangeValidDayByMoney = value;
			}
		}

		private double m_MoneyExchangeValidDayByValidDay;
		/// <summary>
		/// 会员的资金与有效期的兑换比率(有效期)
		/// </summary>
		public double MoneyExchangeValidDayByValidDay
		{
			get
			{
				return this.m_MoneyExchangeValidDayByValidDay;
			}
			set
			{
				this.m_MoneyExchangeValidDayByValidDay = value;
			}
		}
		#endregion

		#region 积分与点卷兑换比率
		private double m_UserExpExchangePointRatio;
		/// <summary>
		/// 会员的积分与点券的兑换比率
		/// </summary>
		public double UserExpExchangePointRatio
		{
			get
			{
				return this.m_UserExpExchangePointRatio;
			}
			set
			{
				this.m_UserExpExchangePointRatio = value;
			}
		}

		private double m_UserExpExchangePointByExp;
		/// <summary>
		/// 会员的积分与点券的兑换比率(积分)
		/// </summary>
		public double UserExpExchangePointByExp
		{
			get
			{
				return this.m_UserExpExchangePointByExp;
			}
			set
			{
				this.m_UserExpExchangePointByExp = value;
			}
		}

		private double m_UserExpExchangePointByPoint;
		/// <summary>
		/// 会员的积分与点券的兑换比率(点券)
		/// </summary>
		public double UserExpExchangePointByPoint
		{
			get
			{
				return this.m_UserExpExchangePointByPoint;
			}
			set
			{
				this.m_UserExpExchangePointByPoint = value;
			}
		}
		#endregion

		#region 积分与有效期兑换比率
		private double m_UserExpExchangeValidDayRatio;
		/// <summary>
		/// 会员的积分与有效期的兑换比率
		/// </summary>
		public double UserExpExchangeValidDayRatio
		{
			get
			{
				return this.m_UserExpExchangeValidDayRatio;
			}
			set
			{
				this.m_UserExpExchangeValidDayRatio = value;
			}
		}

		private double m_UserExpExchangeValidDayByExp;
		/// <summary>
		/// 会员的积分与有效期的兑换比率(积分)
		/// </summary>
		public double UserExpExchangeValidDayByExp
		{
			get
			{
				return this.m_UserExpExchangeValidDayByExp;
			}
			set
			{
				this.m_UserExpExchangeValidDayByExp = value;
			}
		}

		private double m_UserExpExchangeValidDayByValidDay;
		/// <summary>
		/// 会员的积分与有效期的兑换比率(有效期)
		/// </summary>
		public double UserExpExchangeValidDayByValidDay
		{
			get
			{
				return this.m_UserExpExchangeValidDayByValidDay;
			}
			set
			{
				this.m_UserExpExchangeValidDayByValidDay = value;
			}
		}
		#endregion

		#region 积分名称
		private string m_ExpName;
		/// <summary>
		/// 积分的名称
		/// </summary>
		public string ExpName
		{
			get
			{
				return this.m_ExpName;
			}
			set
			{
				this.m_ExpName = value;
			}
		}

		private string m_ExpUnit;
		/// <summary>
		/// 积分的单位
		/// </summary>
		public string ExpUnit
		{
			get
			{
				return this.m_ExpUnit;
			}
			set
			{
				this.m_ExpUnit = value;
			}
		}
		#endregion

		#region 点卷名称
		private string m_PointName;
		/// <summary>
		/// 点券的名称
		/// </summary>
		public string PointName
		{
			get
			{
				return this.m_PointName;
			}
			set
			{
				this.m_PointName = value;
			}
		}

		private string m_PointUnit;
		/// <summary>
		/// 点券的单位
		/// </summary>
		public string PointUnit
		{
			get
			{
				return this.m_PointUnit;
			}
			set
			{
				this.m_PointUnit = value;
			}
		}
		#endregion

		#region 提现相关
		/// <summary>
		/// 提现起始金额
		/// </summary>
		public int MentionMoneyBegin { set; get; }
		/// <summary>
		/// 提现起始费用
		/// </summary>
		public double MentionFeeBegin { set; get; }
		/// <summary>
		/// 提现第一档金额
		/// </summary>
		public int MentionMoneyBegin1 { set; get; }
		/// <summary>
		/// 提现第一档费用
		/// </summary>
		public double MentionFeeBegin1 { set; get; }
		#endregion

		private string m_EmailOfUpgrade;
		/// <summary>
		/// 会员升级成功时发送的邮件内容
		/// </summary>
		public string EmailOfUpgrade
		{
			get
			{
				return this.m_EmailOfUpgrade;
			}
			set
			{
				this.m_EmailOfUpgrade = value;
			}
		}
	}
}
