// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: MerchantEntity.cs
// 修改时间：2019/4/9 17:45:09
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Merchant 的实体类.
	/// </summary>
	public partial class MerchantEntity
	{
		#region Properties
		private System.Int32 _id = 0;
		/// <summary>
		///  (主键)(自增长)
		/// </summary>
		public System.Int32 ID
		{
			get {return _id;}
			set {_id = value;}
		}
		private System.String _loginName = string.Empty;
		/// <summary>
		/// 登录用户名 
		/// </summary>
		public System.String LoginName
		{
			get {return _loginName;}
			set {_loginName = value;}
		}
		private System.String _loginPwd = string.Empty;
		/// <summary>
		/// 登录密码 
		/// </summary>
		public System.String LoginPwd
		{
			get {return _loginPwd;}
			set {_loginPwd = value;}
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
		private System.String _loginIP = string.Empty;
		/// <summary>
		/// 最后登录IP 
		/// </summary>
		public System.String LoginIP
		{
			get {return _loginIP;}
			set {_loginIP = value;}
		}
		private System.Int32 _status = 0;
		/// <summary>
		/// 商户状态（0：正常；1：锁定；） 
		/// </summary>
		public System.Int32 Status
		{
			get {return _status;}
			set {_status = value;}
		}
		private System.Int32 _merchantStatus = 0;
		/// <summary>
		/// 商户状态（0：未认证；1：已认证；2：未通过；3：已提交；4：待完善；） 
		/// </summary>
		public System.Int32 MerchantStatus
		{
			get {return _merchantStatus;}
			set {_merchantStatus = value;}
		}
		private System.String _merchantRemark = string.Empty;
		/// <summary>
		/// 备注 
		/// </summary>
		public System.String MerchantRemark
		{
			get {return _merchantRemark;}
			set {_merchantRemark = value;}
		}
		private System.String _merchantType = string.Empty;
		/// <summary>
		/// 商户类型 
		/// </summary>
		public System.String MerchantType
		{
			get {return _merchantType;}
			set {_merchantType = value;}
		}
		private System.String _merchantNO = string.Empty;
		/// <summary>
		/// 商户编号 
		/// </summary>
		public System.String MerchantNO
		{
			get {return _merchantNO;}
			set {_merchantNO = value;}
		}
		private System.String _merchantName = string.Empty;
		/// <summary>
		/// 商户名称 
		/// </summary>
		public System.String MerchantName
		{
			get {return _merchantName;}
			set {_merchantName = value;}
		}
		private System.String _businessLicense = string.Empty;
		/// <summary>
		/// 营业执照 
		/// </summary>
		public System.String BusinessLicense
		{
			get {return _businessLicense;}
			set {_businessLicense = value;}
		}
		private System.String _businessLicensePic = string.Empty;
		/// <summary>
		/// 营业执照图片(多个图片之间用“$$$”分开) 
		/// </summary>
		public System.String BusinessLicensePic
		{
			get {return _businessLicensePic;}
			set {_businessLicensePic = value;}
		}
		private System.String _merchantLinkman = string.Empty;
		/// <summary>
		/// 联系人姓名 
		/// </summary>
		public System.String MerchantLinkman
		{
			get {return _merchantLinkman;}
			set {_merchantLinkman = value;}
		}
		private System.String _merchantLinkmanPosition = string.Empty;
		/// <summary>
		/// 联系人职位 
		/// </summary>
		public System.String MerchantLinkmanPosition
		{
			get {return _merchantLinkmanPosition;}
			set {_merchantLinkmanPosition = value;}
		}
		private System.String _merchantLinkmanTel = string.Empty;
		/// <summary>
		/// 联系人固话 
		/// </summary>
		public System.String MerchantLinkmanTel
		{
			get {return _merchantLinkmanTel;}
			set {_merchantLinkmanTel = value;}
		}
		private System.Int32 _branchNum = 0;
		/// <summary>
		/// 分店数量 
		/// </summary>
		public System.Int32 BranchNum
		{
			get {return _branchNum;}
			set {_branchNum = value;}
		}
		private System.String _legalPersonName = string.Empty;
		/// <summary>
		/// 法人姓名 
		/// </summary>
		public System.String LegalPersonName
		{
			get {return _legalPersonName;}
			set {_legalPersonName = value;}
		}
		private System.String _legalPersonMobile = string.Empty;
		/// <summary>
		/// 法人手机号 
		/// </summary>
		public System.String LegalPersonMobile
		{
			get {return _legalPersonMobile;}
			set {_legalPersonMobile = value;}
		}
		private System.String _legalPersonIDCard = string.Empty;
		/// <summary>
		/// 法人身份证 
		/// </summary>
		public System.String LegalPersonIDCard
		{
			get {return _legalPersonIDCard;}
			set {_legalPersonIDCard = value;}
		}
		private System.String _legalPersonIDCardPic = string.Empty;
		/// <summary>
		/// 法人身份证图片（多个图片之间用“$$$”分开） 
		/// </summary>
		public System.String LegalPersonIDCardPic
		{
			get {return _legalPersonIDCardPic;}
			set {_legalPersonIDCardPic = value;}
		}
		private System.String _accountingName = string.Empty;
		/// <summary>
		/// 会计名称 
		/// </summary>
		public System.String AccountingName
		{
			get {return _accountingName;}
			set {_accountingName = value;}
		}
		private System.String _accountingMobile = string.Empty;
		/// <summary>
		/// 会计手机号 
		/// </summary>
		public System.String AccountingMobile
		{
			get {return _accountingMobile;}
			set {_accountingMobile = value;}
		}
		private System.String _accountingTel = string.Empty;
		/// <summary>
		/// 会计固话 
		/// </summary>
		public System.String AccountingTel
		{
			get {return _accountingTel;}
			set {_accountingTel = value;}
		}
		private System.String _accountName = string.Empty;
		/// <summary>
		/// 收款开户名 
		/// </summary>
		public System.String AccountName
		{
			get {return _accountName;}
			set {_accountName = value;}
		}
		private System.String _bankHeadOffice = string.Empty;
		/// <summary>
		/// 银行总行名称 
		/// </summary>
		public System.String BankHeadOffice
		{
			get {return _bankHeadOffice;}
			set {_bankHeadOffice = value;}
		}
		private System.String _bankHeadOfficeOther = string.Empty;
		/// <summary>
		/// 银行总行其他 
		/// </summary>
		public System.String BankHeadOfficeOther
		{
			get {return _bankHeadOfficeOther;}
			set {_bankHeadOfficeOther = value;}
		}
		private System.String _bankBranch = string.Empty;
		/// <summary>
		/// 开户行支行 
		/// </summary>
		public System.String BankBranch
		{
			get {return _bankBranch;}
			set {_bankBranch = value;}
		}
		private System.String _bankBranchProvince = string.Empty;
		/// <summary>
		/// 银行支行省份 
		/// </summary>
		public System.String BankBranchProvince
		{
			get {return _bankBranchProvince;}
			set {_bankBranchProvince = value;}
		}
		private System.String _bankBranchCity = string.Empty;
		/// <summary>
		/// 银行支行城市 
		/// </summary>
		public System.String BankBranchCity
		{
			get {return _bankBranchCity;}
			set {_bankBranchCity = value;}
		}
		private System.String _bankBranchArea = string.Empty;
		/// <summary>
		/// 银行支行区域 
		/// </summary>
		public System.String BankBranchArea
		{
			get {return _bankBranchArea;}
			set {_bankBranchArea = value;}
		}
		private System.String _bankAccount = string.Empty;
		/// <summary>
		/// 银行账号 
		/// </summary>
		public System.String BankAccount
		{
			get {return _bankAccount;}
			set {_bankAccount = value;}
		}
		private System.String _zipCode = string.Empty;
		/// <summary>
		/// 邮编 
		/// </summary>
		public System.String ZipCode
		{
			get {return _zipCode;}
			set {_zipCode = value;}
		}
		private System.String _merchantProvince = string.Empty;
		/// <summary>
		/// 商户地址省份 
		/// </summary>
		public System.String MerchantProvince
		{
			get {return _merchantProvince;}
			set {_merchantProvince = value;}
		}
		private System.String _merchantCity = string.Empty;
		/// <summary>
		/// 商户地址城市 
		/// </summary>
		public System.String MerchantCity
		{
			get {return _merchantCity;}
			set {_merchantCity = value;}
		}
		private System.String _merchantArea = string.Empty;
		/// <summary>
		/// 商户地址区域 
		/// </summary>
		public System.String MerchantArea
		{
			get {return _merchantArea;}
			set {_merchantArea = value;}
		}
		private System.String _merchantAddress = string.Empty;
		/// <summary>
		/// 商户地址详细 
		/// </summary>
		public System.String MerchantAddress
		{
			get {return _merchantAddress;}
			set {_merchantAddress = value;}
		}
		private System.String _openingLicense = string.Empty;
		/// <summary>
		/// 开户许可证 
		/// </summary>
		public System.String OpeningLicense
		{
			get {return _openingLicense;}
			set {_openingLicense = value;}
		}
		private System.String _agreement = string.Empty;
		/// <summary>
		/// 合作协议 
		/// </summary>
		public System.String Agreement
		{
			get {return _agreement;}
			set {_agreement = value;}
		}
		private System.String _inputer = string.Empty;
		/// <summary>
		/// 录入者 
		/// </summary>
		public System.String Inputer
		{
			get {return _inputer;}
			set {_inputer = value;}
		}
		private DateTime? _inputerTime = DateTime.MaxValue;
		/// <summary>
		/// 录入时间 
		/// </summary>
		public DateTime? InputerTime
		{
			get {return _inputerTime;}
			set {_inputerTime = value;}
		}
		#endregion
	}
}
