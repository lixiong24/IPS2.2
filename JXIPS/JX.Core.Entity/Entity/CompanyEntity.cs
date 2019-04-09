// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: CompanyEntity.cs
// 修改时间：2019/4/9 17:45:05
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Company 的实体类.
	/// </summary>
	public partial class CompanyEntity
	{
		#region Properties
		private System.Int32 _companyID = 0;
		/// <summary>
		/// 企业ID (主键)
		/// </summary>
		public System.Int32 CompanyID
		{
			get {return _companyID;}
			set {_companyID = value;}
		}
		private System.Int32 _clientID = 0;
		/// <summary>
		/// 对应客户ID 
		/// </summary>
		public System.Int32 ClientID
		{
			get {return _clientID;}
			set {_clientID = value;}
		}
		private System.String _companyName = string.Empty;
		/// <summary>
		/// 企业名称 
		/// </summary>
		public System.String CompanyName
		{
			get {return _companyName;}
			set {_companyName = value;}
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
		private System.String _phone = string.Empty;
		/// <summary>
		/// 电话 
		/// </summary>
		public System.String Phone
		{
			get {return _phone;}
			set {_phone = value;}
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
		private System.String _homepage = string.Empty;
		/// <summary>
		/// 相关网址 
		/// </summary>
		public System.String Homepage
		{
			get {return _homepage;}
			set {_homepage = value;}
		}
		private System.String _bankOfDeposit = string.Empty;
		/// <summary>
		/// 开户银行 
		/// </summary>
		public System.String BankOfDeposit
		{
			get {return _bankOfDeposit;}
			set {_bankOfDeposit = value;}
		}
		private System.String _bankAccount = string.Empty;
		/// <summary>
		/// 银行帐号 
		/// </summary>
		public System.String BankAccount
		{
			get {return _bankAccount;}
			set {_bankAccount = value;}
		}
		private System.String _taxNum = string.Empty;
		/// <summary>
		/// 税号 
		/// </summary>
		public System.String TaxNum
		{
			get {return _taxNum;}
			set {_taxNum = value;}
		}
		private System.Int32 _statusInField = 0;
		/// <summary>
		/// 行业地位 
		/// </summary>
		public System.Int32 StatusInField
		{
			get {return _statusInField;}
			set {_statusInField = value;}
		}
		private System.Int32 _companySize = 0;
		/// <summary>
		/// 公司规模 
		/// </summary>
		public System.Int32 CompanySize
		{
			get {return _companySize;}
			set {_companySize = value;}
		}
		private System.String _businessScope = string.Empty;
		/// <summary>
		/// 业务范围 
		/// </summary>
		public System.String BusinessScope
		{
			get {return _businessScope;}
			set {_businessScope = value;}
		}
		private System.String _annualSales = string.Empty;
		/// <summary>
		/// 年销售额（万元） 
		/// </summary>
		public System.String AnnualSales
		{
			get {return _annualSales;}
			set {_annualSales = value;}
		}
		private System.Int32 _managementForms = 0;
		/// <summary>
		/// 经营状态 
		/// </summary>
		public System.Int32 ManagementForms
		{
			get {return _managementForms;}
			set {_managementForms = value;}
		}
		private System.String _registeredCapital = string.Empty;
		/// <summary>
		/// 注册资本 
		/// </summary>
		public System.String RegisteredCapital
		{
			get {return _registeredCapital;}
			set {_registeredCapital = value;}
		}
		private System.String _companyIntro = string.Empty;
		/// <summary>
		/// 公司简介 
		/// </summary>
		public System.String CompanyIntro
		{
			get {return _companyIntro;}
			set {_companyIntro = value;}
		}
		private System.String _companyPic = string.Empty;
		/// <summary>
		/// 公司照片 
		/// </summary>
		public System.String CompanyPic
		{
			get {return _companyPic;}
			set {_companyPic = value;}
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
		private System.String _organizationCode = string.Empty;
		/// <summary>
		/// 组织机构代码 
		/// </summary>
		public System.String OrganizationCode
		{
			get {return _organizationCode;}
			set {_organizationCode = value;}
		}
		private System.String _taxpayerNumber = string.Empty;
		/// <summary>
		/// 纳税人识别号 
		/// </summary>
		public System.String TaxpayerNumber
		{
			get {return _taxpayerNumber;}
			set {_taxpayerNumber = value;}
		}
		private System.String _creditCode = string.Empty;
		/// <summary>
		/// 统一社会信用代码 
		/// </summary>
		public System.String CreditCode
		{
			get {return _creditCode;}
			set {_creditCode = value;}
		}
		private System.String _openingLicense = string.Empty;
		/// <summary>
		/// 开户许可证（多个图片之间用“$$$”分开） 
		/// </summary>
		public System.String OpeningLicense
		{
			get {return _openingLicense;}
			set {_openingLicense = value;}
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
		private System.String _qualityPic = string.Empty;
		/// <summary>
		/// 质检报告图片（多个图片之间用“$$$”分开） 
		/// </summary>
		public System.String QualityPic
		{
			get {return _qualityPic;}
			set {_qualityPic = value;}
		}
		private System.Int32 _companyStatus = 0;
		/// <summary>
		/// 企业状态（0：待审核；1：已通过；2：已驳回；） 
		/// </summary>
		public System.Int32 CompanyStatus
		{
			get {return _companyStatus;}
			set {_companyStatus = value;}
		}
		private System.String _remark = string.Empty;
		/// <summary>
		/// 备注 
		/// </summary>
		public System.String Remark
		{
			get {return _remark;}
			set {_remark = value;}
		}
		#endregion
	}
}
