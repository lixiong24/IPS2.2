// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: ContacterEntity.cs
// 修改时间：2019/4/9 17:45:06
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Contacter 的实体类.
	/// </summary>
	public partial class ContacterEntity
	{
		#region Properties
		private System.Int32 _contacterID = 0;
		/// <summary>
		/// 联系人ID (主键)
		/// </summary>
		public System.Int32 ContacterID
		{
			get {return _contacterID;}
			set {_contacterID = value;}
		}
		private System.Int32 _clientID = 0;
		/// <summary>
		/// 对应的客户ID 
		/// </summary>
		public System.Int32 ClientID
		{
			get {return _clientID;}
			set {_clientID = value;}
		}
		private System.Int32 _parentID = 0;
		/// <summary>
		/// 上级联系人ID 
		/// </summary>
		public System.Int32 ParentID
		{
			get {return _parentID;}
			set {_parentID = value;}
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
		private System.Int32 _userType = 0;
		/// <summary>
		/// 会员类别(0--个人会员；1--主联系人；2--第二联系人；) 
		/// </summary>
		public System.Int32 UserType
		{
			get {return _userType;}
			set {_userType = value;}
		}
		private System.String _trueName = string.Empty;
		/// <summary>
		/// 真实姓名 
		/// </summary>
		public System.String TrueName
		{
			get {return _trueName;}
			set {_trueName = value;}
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
		private System.String _title = string.Empty;
		/// <summary>
		/// 称谓，如王总，张老师，田部长 
		/// </summary>
		public System.String Title
		{
			get {return _title;}
			set {_title = value;}
		}
		private System.String _company = string.Empty;
		/// <summary>
		/// 单位名称 
		/// </summary>
		public System.String Company
		{
			get {return _company;}
			set {_company = value;}
		}
		private System.String _department = string.Empty;
		/// <summary>
		/// 所属部门 
		/// </summary>
		public System.String Department
		{
			get {return _department;}
			set {_department = value;}
		}
		private System.String _position = string.Empty;
		/// <summary>
		/// 职务 
		/// </summary>
		public System.String Position
		{
			get {return _position;}
			set {_position = value;}
		}
		private System.String _operation = string.Empty;
		/// <summary>
		/// 负责业务 
		/// </summary>
		public System.String Operation
		{
			get {return _operation;}
			set {_operation = value;}
		}
		private System.String _companyAddress = string.Empty;
		/// <summary>
		/// 单位地址 
		/// </summary>
		public System.String CompanyAddress
		{
			get {return _companyAddress;}
			set {_companyAddress = value;}
		}
		private System.String _companySize = string.Empty;
		/// <summary>
		/// 单位规模 
		/// </summary>
		public System.String CompanySize
		{
			get {return _companySize;}
			set {_companySize = value;}
		}
		private System.String _companyType = string.Empty;
		/// <summary>
		/// 单位类型 
		/// </summary>
		public System.String CompanyType
		{
			get {return _companyType;}
			set {_companyType = value;}
		}
		private System.String _companyIndustry = string.Empty;
		/// <summary>
		/// 单位行业 
		/// </summary>
		public System.String CompanyIndustry
		{
			get {return _companyIndustry;}
			set {_companyIndustry = value;}
		}
		private System.String _email = string.Empty;
		/// <summary>
		/// 备用邮箱 
		/// </summary>
		public System.String Email
		{
			get {return _email;}
			set {_email = value;}
		}
		private System.String _homepage = string.Empty;
		/// <summary>
		/// 相关网址 
		/// </summary>
		public System.String Homepage
		{
			get {return _homepage;}
			set {_homepage = value;}
		}
		private System.String _qq = string.Empty;
		/// <summary>
		/// QQ号码 
		/// </summary>
		public System.String QQ
		{
			get {return _qq;}
			set {_qq = value;}
		}
		private System.String _icq = string.Empty;
		/// <summary>
		/// ICQ号码 
		/// </summary>
		public System.String ICQ
		{
			get {return _icq;}
			set {_icq = value;}
		}
		private System.String _msn = string.Empty;
		/// <summary>
		/// MSN号码 
		/// </summary>
		public System.String MSN
		{
			get {return _msn;}
			set {_msn = value;}
		}
		private System.String _yahoo = string.Empty;
		/// <summary>
		/// 雅虎通帐号 
		/// </summary>
		public System.String Yahoo
		{
			get {return _yahoo;}
			set {_yahoo = value;}
		}
		private System.String _uc = string.Empty;
		/// <summary>
		/// UC帐号 
		/// </summary>
		public System.String UC
		{
			get {return _uc;}
			set {_uc = value;}
		}
		private System.String _aim = string.Empty;
		/// <summary>
		/// Aim帐号 
		/// </summary>
		public System.String Aim
		{
			get {return _aim;}
			set {_aim = value;}
		}
		private System.String _officePhone = string.Empty;
		/// <summary>
		/// 办公电话 
		/// </summary>
		public System.String OfficePhone
		{
			get {return _officePhone;}
			set {_officePhone = value;}
		}
		private System.String _homePhone = string.Empty;
		/// <summary>
		/// 住宅电话 
		/// </summary>
		public System.String HomePhone
		{
			get {return _homePhone;}
			set {_homePhone = value;}
		}
		private System.String _phs = string.Empty;
		/// <summary>
		/// 小灵通 
		/// </summary>
		public System.String PHS
		{
			get {return _phs;}
			set {_phs = value;}
		}
		private System.String _fax = string.Empty;
		/// <summary>
		/// 传真号码 
		/// </summary>
		public System.String Fax
		{
			get {return _fax;}
			set {_fax = value;}
		}
		private System.String _mobile = string.Empty;
		/// <summary>
		/// 移动电话 
		/// </summary>
		public System.String Mobile
		{
			get {return _mobile;}
			set {_mobile = value;}
		}
		private System.String _country = string.Empty;
		/// <summary>
		/// 国家/地区 
		/// </summary>
		public System.String Country
		{
			get {return _country;}
			set {_country = value;}
		}
		private System.String _province = string.Empty;
		/// <summary>
		/// 省市/州郡 
		/// </summary>
		public System.String Province
		{
			get {return _province;}
			set {_province = value;}
		}
		private System.String _city = string.Empty;
		/// <summary>
		/// 城市 
		/// </summary>
		public System.String City
		{
			get {return _city;}
			set {_city = value;}
		}
		private System.String _area = string.Empty;
		/// <summary>
		/// 区域 
		/// </summary>
		public System.String Area
		{
			get {return _area;}
			set {_area = value;}
		}
		private System.String _address = string.Empty;
		/// <summary>
		/// 联系地址 
		/// </summary>
		public System.String Address
		{
			get {return _address;}
			set {_address = value;}
		}
		private System.String _zipCode = string.Empty;
		/// <summary>
		/// 邮政编码 
		/// </summary>
		public System.String ZipCode
		{
			get {return _zipCode;}
			set {_zipCode = value;}
		}
		private System.String _nativePlace = string.Empty;
		/// <summary>
		/// 籍贯 
		/// </summary>
		public System.String NativePlace
		{
			get {return _nativePlace;}
			set {_nativePlace = value;}
		}
		private System.String _nation = string.Empty;
		/// <summary>
		/// 民族 
		/// </summary>
		public System.String Nation
		{
			get {return _nation;}
			set {_nation = value;}
		}
		private DateTime? _birthday = DateTime.MaxValue;
		/// <summary>
		/// 出生日期 
		/// </summary>
		public DateTime? Birthday
		{
			get {return _birthday;}
			set {_birthday = value;}
		}
		private System.String _iDCard = string.Empty;
		/// <summary>
		/// 证件号码 
		/// </summary>
		public System.String IDCard
		{
			get {return _iDCard;}
			set {_iDCard = value;}
		}
		private System.String _iDCardPic = string.Empty;
		/// <summary>
		/// 证件图片（多个图片之间用“$$$”分开） 
		/// </summary>
		public System.String IDCardPic
		{
			get {return _iDCardPic;}
			set {_iDCardPic = value;}
		}
		private System.Int32 _isPassIDCard = 0;
		/// <summary>
		/// 身份认证标识（0：未认证；1：已认证；2：未通过；） 
		/// </summary>
		public System.Int32 IsPassIDCard
		{
			get {return _isPassIDCard;}
			set {_isPassIDCard = value;}
		}
		private System.String _iDCardProvince = string.Empty;
		/// <summary>
		/// 户籍省份 
		/// </summary>
		public System.String IDCardProvince
		{
			get {return _iDCardProvince;}
			set {_iDCardProvince = value;}
		}
		private System.String _iDCardCity = string.Empty;
		/// <summary>
		/// 户籍城市 
		/// </summary>
		public System.String IDCardCity
		{
			get {return _iDCardCity;}
			set {_iDCardCity = value;}
		}
		private System.String _iDCardArea = string.Empty;
		/// <summary>
		/// 户籍区域 
		/// </summary>
		public System.String IDCardArea
		{
			get {return _iDCardArea;}
			set {_iDCardArea = value;}
		}
		private System.String _iDCardAddress = string.Empty;
		/// <summary>
		/// 户籍地址详情 
		/// </summary>
		public System.String IDCardAddress
		{
			get {return _iDCardAddress;}
			set {_iDCardAddress = value;}
		}
		private System.String _bankName = string.Empty;
		/// <summary>
		/// 银行名称 
		/// </summary>
		public System.String BankName
		{
			get {return _bankName;}
			set {_bankName = value;}
		}
		private System.String _bankAccount = string.Empty;
		/// <summary>
		/// 银行账户名称 
		/// </summary>
		public System.String BankAccount
		{
			get {return _bankAccount;}
			set {_bankAccount = value;}
		}
		private System.String _bankCard = string.Empty;
		/// <summary>
		/// 银行卡号 
		/// </summary>
		public System.String BankCard
		{
			get {return _bankCard;}
			set {_bankCard = value;}
		}
		private System.String _bankCardPic = string.Empty;
		/// <summary>
		/// 银行卡图片 
		/// </summary>
		public System.String BankCardPic
		{
			get {return _bankCardPic;}
			set {_bankCardPic = value;}
		}
		private System.Int32 _isPassBankCard = 0;
		/// <summary>
		/// 银行认证标识（0：未认证；1：已认证；2：未通过；） 
		/// </summary>
		public System.Int32 IsPassBankCard
		{
			get {return _isPassBankCard;}
			set {_isPassBankCard = value;}
		}
		private System.Int32 _marriage = 0;
		/// <summary>
		/// 婚姻状况 
		/// </summary>
		public System.Int32 Marriage
		{
			get {return _marriage;}
			set {_marriage = value;}
		}
		private System.String _family = string.Empty;
		/// <summary>
		/// 家庭情况 
		/// </summary>
		public System.String Family
		{
			get {return _family;}
			set {_family = value;}
		}
		private System.Int32 _income = 0;
		/// <summary>
		/// 月收入 
		/// </summary>
		public System.Int32 Income
		{
			get {return _income;}
			set {_income = value;}
		}
		private System.Int32 _education = 0;
		/// <summary>
		/// 学历 
		/// </summary>
		public System.Int32 Education
		{
			get {return _education;}
			set {_education = value;}
		}
		private System.String _graduateFrom = string.Empty;
		/// <summary>
		/// 毕业学校 
		/// </summary>
		public System.String GraduateFrom
		{
			get {return _graduateFrom;}
			set {_graduateFrom = value;}
		}
		private System.String _interestsOfLife = string.Empty;
		/// <summary>
		/// 生活爱好 
		/// </summary>
		public System.String InterestsOfLife
		{
			get {return _interestsOfLife;}
			set {_interestsOfLife = value;}
		}
		private System.String _interestsOfCulture = string.Empty;
		/// <summary>
		/// 文化爱好 
		/// </summary>
		public System.String InterestsOfCulture
		{
			get {return _interestsOfCulture;}
			set {_interestsOfCulture = value;}
		}
		private System.String _interestsOfAmusement = string.Empty;
		/// <summary>
		/// 娱乐休闲爱好 
		/// </summary>
		public System.String InterestsOfAmusement
		{
			get {return _interestsOfAmusement;}
			set {_interestsOfAmusement = value;}
		}
		private System.String _interestsOfSport = string.Empty;
		/// <summary>
		/// 体育爱好 
		/// </summary>
		public System.String InterestsOfSport
		{
			get {return _interestsOfSport;}
			set {_interestsOfSport = value;}
		}
		private System.String _interestsOfOther = string.Empty;
		/// <summary>
		/// 其他爱好 
		/// </summary>
		public System.String InterestsOfOther
		{
			get {return _interestsOfOther;}
			set {_interestsOfOther = value;}
		}
		private DateTime? _createTime = DateTime.MaxValue;
		/// <summary>
		/// 创建时间 
		/// </summary>
		public DateTime? CreateTime
		{
			get {return _createTime;}
			set {_createTime = value;}
		}
		private DateTime? _updateTime = DateTime.MaxValue;
		/// <summary>
		/// 更新时间 
		/// </summary>
		public DateTime? UpdateTime
		{
			get {return _updateTime;}
			set {_updateTime = value;}
		}
		private System.String _owner = string.Empty;
		/// <summary>
		/// 所有者 
		/// </summary>
		public System.String Owner
		{
			get {return _owner;}
			set {_owner = value;}
		}
		private System.String _emergencyContact = string.Empty;
		/// <summary>
		/// 紧急联系人（例：姓名*年龄*电话*身份证*职业*情况*与本人关系$$$姓名*年龄*电话*身份证*职业*情况*与本人关系） 
		/// </summary>
		public System.String EmergencyContact
		{
			get {return _emergencyContact;}
			set {_emergencyContact = value;}
		}
		#endregion
	}
}
