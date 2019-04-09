// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: UsersEntity.cs
// 修改时间：2019/4/9 17:45:15
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Users 的实体类.
	/// </summary>
	public partial class UsersEntity
	{
		#region Properties
		private System.Int32 _userID = 0;
		/// <summary>
		/// 用户ID (主键)
		/// </summary>
		public System.Int32 UserID
		{
			get {return _userID;}
			set {_userID = value;}
		}
		private System.Int32 _groupID = 0;
		/// <summary>
		/// 用户组ID 
		/// </summary>
		public System.Int32 GroupID
		{
			get {return _groupID;}
			set {_groupID = value;}
		}
		private System.Int32 _companyID = 0;
		/// <summary>
		/// 对应企业ID 
		/// </summary>
		public System.Int32 CompanyID
		{
			get {return _companyID;}
			set {_companyID = value;}
		}
		private System.Int32 _clientID = 0;
		/// <summary>
		/// 客户信息Id 
		/// </summary>
		public System.Int32 ClientID
		{
			get {return _clientID;}
			set {_clientID = value;}
		}
		private System.Int32 _userType = 0;
		/// <summary>
		/// 会员类别，0－个人会员 1企业会员(创建者) 2企业会员(管理员) 3企业会员(普通成员) 4 企业会员(待审核成员) 
		/// </summary>
		public System.Int32 UserType
		{
			get {return _userType;}
			set {_userType = value;}
		}
		private System.String _userName = string.Empty;
		/// <summary>
		/// 用户名 
		/// </summary>
		public System.String UserName
		{
			get {return _userName;}
			set {_userName = value;}
		}
		private System.String _trueName = string.Empty;
		/// <summary>
		/// 用户真实姓名 
		/// </summary>
		public System.String TrueName
		{
			get {return _trueName;}
			set {_trueName = value;}
		}
		private System.String _userPassword = string.Empty;
		/// <summary>
		/// 密码 
		/// </summary>
		public System.String UserPassword
		{
			get {return _userPassword;}
			set {_userPassword = value;}
		}
		private System.String _lastPassword = string.Empty;
		/// <summary>
		/// 随机密码 
		/// </summary>
		public System.String LastPassword
		{
			get {return _lastPassword;}
			set {_lastPassword = value;}
		}
		private System.String _question = string.Empty;
		/// <summary>
		/// 提示问题 
		/// </summary>
		public System.String Question
		{
			get {return _question;}
			set {_question = value;}
		}
		private System.String _answer = string.Empty;
		/// <summary>
		/// 提示答案 
		/// </summary>
		public System.String Answer
		{
			get {return _answer;}
			set {_answer = value;}
		}
		private System.String _email = string.Empty;
		/// <summary>
		/// Email 
		/// </summary>
		public System.String Email
		{
			get {return _email;}
			set {_email = value;}
		}
		private System.String _mobile = string.Empty;
		/// <summary>
		/// 手机号 
		/// </summary>
		public System.String Mobile
		{
			get {return _mobile;}
			set {_mobile = value;}
		}
		private System.Int32 _sex = 0;
		/// <summary>
		/// 性别 
		/// </summary>
		public System.Int32 Sex
		{
			get {return _sex;}
			set {_sex = value;}
		}
		private DateTime? _regTime = DateTime.MaxValue;
		/// <summary>
		/// 注册时间 
		/// </summary>
		public DateTime? RegTime
		{
			get {return _regTime;}
			set {_regTime = value;}
		}
		private DateTime? _joinTime = DateTime.MaxValue;
		/// <summary>
		/// 加入某用户组的时间 
		/// </summary>
		public DateTime? JoinTime
		{
			get {return _joinTime;}
			set {_joinTime = value;}
		}
		private System.Int32 _loginTimes = 0;
		/// <summary>
		/// 登录次数 
		/// </summary>
		public System.Int32 LoginTimes
		{
			get {return _loginTimes;}
			set {_loginTimes = value;}
		}
		private DateTime? _loginTime = DateTime.MaxValue;
		/// <summary>
		/// 最后登录时间 
		/// </summary>
		public DateTime? LoginTime
		{
			get {return _loginTime;}
			set {_loginTime = value;}
		}
		private DateTime? _presentTime = DateTime.MaxValue;
		/// <summary>
		/// 最后赠送积分时间，用于每次登录赠送积分的设置 
		/// </summary>
		public DateTime? PresentTime
		{
			get {return _presentTime;}
			set {_presentTime = value;}
		}
		private System.String _loginIP = string.Empty;
		/// <summary>
		/// 最后登录IP 
		/// </summary>
		public System.String LoginIP
		{
			get {return _loginIP;}
			set {_loginIP = value;}
		}
		private DateTime? _passwordChangedTime = DateTime.MaxValue;
		/// <summary>
		/// 上次修改密码的时间 
		/// </summary>
		public DateTime? PasswordChangedTime
		{
			get {return _passwordChangedTime;}
			set {_passwordChangedTime = value;}
		}
		private DateTime? _lockoutTime = DateTime.MaxValue;
		/// <summary>
		/// 上次被锁定的时间 
		/// </summary>
		public DateTime? LockoutTime
		{
			get {return _lockoutTime;}
			set {_lockoutTime = value;}
		}
		private System.Int32 _loginFailedCount = 0;
		/// <summary>
		/// 使用无效密码登录的次数，正确登录后置为0 
		/// </summary>
		public System.Int32 LoginFailedCount
		{
			get {return _loginFailedCount;}
			set {_loginFailedCount = value;}
		}
		private DateTime? _firstFailedTime = DateTime.MaxValue;
		/// <summary>
		/// 第一次使用无效密码登录的时间 
		/// </summary>
		public DateTime? FirstFailedTime
		{
			get {return _firstFailedTime;}
			set {_firstFailedTime = value;}
		}
		private System.Int32 _failedAnswerCount = 0;
		/// <summary>
		/// 使用无效答案找回密码的次数 
		/// </summary>
		public System.Int32 FailedAnswerCount
		{
			get {return _failedAnswerCount;}
			set {_failedAnswerCount = value;}
		}
		private DateTime? _firstFailedAnswerTime = DateTime.MaxValue;
		/// <summary>
		/// 第一次使用无效答案找回密码的时间 
		/// </summary>
		public DateTime? FirstFailedAnswerTime
		{
			get {return _firstFailedAnswerTime;}
			set {_firstFailedAnswerTime = value;}
		}
		private System.Int32 _userStatus = 0;
		/// <summary>
		/// 用户状态。0－－正常，1－－锁定，2－－未通过邮件验证，4－－未通过管理员认证 8－－未通过手机验证 
		/// </summary>
		public System.Int32 UserStatus
		{
			get {return _userStatus;}
			set {_userStatus = value;}
		}
		private System.String _checkNum = string.Empty;
		/// <summary>
		/// 验证码。用于邮件验证 
		/// </summary>
		public System.String CheckNum
		{
			get {return _checkNum;}
			set {_checkNum = value;}
		}
		private System.Boolean _isResetPassword = false;
		/// <summary>
		/// 是否允许用户修改密码 
		/// </summary>
		public System.Boolean IsResetPassword
		{
			get {return _isResetPassword;}
			set {_isResetPassword = value;}
		}
		private System.String _userCultureName = string.Empty;
		/// <summary>
		/// 用户语言 
		/// </summary>
		public System.String UserCultureName
		{
			get {return _userCultureName;}
			set {_userCultureName = value;}
		}
		private System.String _userFace = string.Empty;
		/// <summary>
		/// 用户头像 
		/// </summary>
		public System.String UserFace
		{
			get {return _userFace;}
			set {_userFace = value;}
		}
		private System.Int32 _faceWidth = 0;
		/// <summary>
		/// 头像宽度 
		/// </summary>
		public System.Int32 FaceWidth
		{
			get {return _faceWidth;}
			set {_faceWidth = value;}
		}
		private System.Int32 _faceHeight = 0;
		/// <summary>
		/// 头像高度 
		/// </summary>
		public System.Int32 FaceHeight
		{
			get {return _faceHeight;}
			set {_faceHeight = value;}
		}
		private System.String _sign = string.Empty;
		/// <summary>
		/// 用户签名 
		/// </summary>
		public System.String Sign
		{
			get {return _sign;}
			set {_sign = value;}
		}
		private System.Int32 _privacySetting = 0;
		/// <summary>
		/// 隐私设置 
		/// </summary>
		public System.Int32 PrivacySetting
		{
			get {return _privacySetting;}
			set {_privacySetting = value;}
		}
		private System.Decimal _balance = 0;
		/// <summary>
		/// 资金余额 
		/// </summary>
		public System.Decimal Balance
		{
			get {return _balance;}
			set {_balance = value;}
		}
		private System.Int32 _userPoint = 0;
		/// <summary>
		/// 用户点券数 
		/// </summary>
		public System.Int32 UserPoint
		{
			get {return _userPoint;}
			set {_userPoint = value;}
		}
		private System.Int32 _userExp = 0;
		/// <summary>
		/// 用户积分 
		/// </summary>
		public System.Int32 UserExp
		{
			get {return _userExp;}
			set {_userExp = value;}
		}
		private System.Int32 _consumeMoney = 0;
		/// <summary>
		/// 消费的金额 
		/// </summary>
		public System.Int32 ConsumeMoney
		{
			get {return _consumeMoney;}
			set {_consumeMoney = value;}
		}
		private System.Int32 _consumePoint = 0;
		/// <summary>
		/// 消费的点券数 
		/// </summary>
		public System.Int32 ConsumePoint
		{
			get {return _consumePoint;}
			set {_consumePoint = value;}
		}
		private System.Int32 _consumeExp = 0;
		/// <summary>
		/// 消费的积分数 
		/// </summary>
		public System.Int32 ConsumeExp
		{
			get {return _consumeExp;}
			set {_consumeExp = value;}
		}
		private System.Int32 _postItems = 0;
		/// <summary>
		/// 添加的信息数 
		/// </summary>
		public System.Int32 PostItems
		{
			get {return _postItems;}
			set {_postItems = value;}
		}
		private System.Int32 _passedItems = 0;
		/// <summary>
		/// 审核通过的信息数 
		/// </summary>
		public System.Int32 PassedItems
		{
			get {return _passedItems;}
			set {_passedItems = value;}
		}
		private System.Int32 _rejectItems = 0;
		/// <summary>
		/// 被退稿的信息数 
		/// </summary>
		public System.Int32 RejectItems
		{
			get {return _rejectItems;}
			set {_rejectItems = value;}
		}
		private System.Int32 _deleteItems = 0;
		/// <summary>
		/// 被删除的信息数 
		/// </summary>
		public System.Int32 DeleteItems
		{
			get {return _deleteItems;}
			set {_deleteItems = value;}
		}
		private DateTime? _endTime = DateTime.MaxValue;
		/// <summary>
		/// 有效期开始计算时间 
		/// </summary>
		public DateTime? EndTime
		{
			get {return _endTime;}
			set {_endTime = value;}
		}
		private System.Boolean _isInheritGroupRole = false;
		/// <summary>
		/// 是否继承用户组权限，默认为true 
		/// </summary>
		public System.Boolean IsInheritGroupRole
		{
			get {return _isInheritGroupRole;}
			set {_isInheritGroupRole = value;}
		}
		private System.String _userSetting = string.Empty;
		/// <summary>
		/// 用户权限 
		/// </summary>
		public System.String UserSetting
		{
			get {return _userSetting;}
			set {_userSetting = value;}
		}
		private System.String _userFriendGroup = string.Empty;
		/// <summary>
		/// 用户好友组 
		/// </summary>
		public System.String UserFriendGroup
		{
			get {return _userFriendGroup;}
			set {_userFriendGroup = value;}
		}
		private System.String _payPassword = string.Empty;
		/// <summary>
		/// 支付密码 
		/// </summary>
		public System.String PayPassword
		{
			get {return _payPassword;}
			set {_payPassword = value;}
		}
		private System.Boolean _isShowUpgradeTipsFalse = false;
		/// <summary>
		/// 是否不再显示用户升级提示信息，默认为false 
		/// </summary>
		public System.Boolean IsShowUpgradeTipsFalse
		{
			get {return _isShowUpgradeTipsFalse;}
			set {_isShowUpgradeTipsFalse = value;}
		}
		private DateTime? _lastAddPointTime = DateTime.MaxValue;
		/// <summary>
		/// 上次添加点券的时间 
		/// </summary>
		public DateTime? LastAddPointTime
		{
			get {return _lastAddPointTime;}
			set {_lastAddPointTime = value;}
		}
		private System.Int32 _qAPoint = 0;
		/// <summary>
		/// 问答积分 
		/// </summary>
		public System.Int32 QAPoint
		{
			get {return _qAPoint;}
			set {_qAPoint = value;}
		}
		private System.String _getPasswordSid = string.Empty;
		/// <summary>
		/// 取回密码随机串 
		/// </summary>
		public System.String GetPasswordSid
		{
			get {return _getPasswordSid;}
			set {_getPasswordSid = value;}
		}
		private DateTime? _getPasswordTime = DateTime.MaxValue;
		/// <summary>
		/// 上次取回密码时间 
		/// </summary>
		public DateTime? GetPasswordTime
		{
			get {return _getPasswordTime;}
			set {_getPasswordTime = value;}
		}
		private System.Int32 _honorType = 0;
		/// <summary>
		/// 用户问答头衔 
		/// </summary>
		public System.Int32 HonorType
		{
			get {return _honorType;}
			set {_honorType = value;}
		}
		private System.Decimal _frozenBalance = 0;
		/// <summary>
		/// 冻结金额 
		/// </summary>
		public System.Decimal FrozenBalance
		{
			get {return _frozenBalance;}
			set {_frozenBalance = value;}
		}
		private System.Decimal _creditLines = 0;
		/// <summary>
		/// 授信额度 
		/// </summary>
		public System.Decimal CreditLines
		{
			get {return _creditLines;}
			set {_creditLines = value;}
		}
		#endregion
	}
}
