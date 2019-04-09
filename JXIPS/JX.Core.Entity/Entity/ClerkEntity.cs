// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: ClerkEntity.cs
// 修改时间：2019/4/9 17:45:03
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Clerk 的实体类.
	/// </summary>
	public partial class ClerkEntity
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
		private System.String _clerkType = string.Empty;
		/// <summary>
		/// 店员类型 
		/// </summary>
		public System.String ClerkType
		{
			get {return _clerkType;}
			set {_clerkType = value;}
		}
		private System.String _clerkName = string.Empty;
		/// <summary>
		/// 店员姓名 
		/// </summary>
		public System.String ClerkName
		{
			get {return _clerkName;}
			set {_clerkName = value;}
		}
		private DateTime? _entryTime = DateTime.MaxValue;
		/// <summary>
		/// 入职时间 
		/// </summary>
		public DateTime? EntryTime
		{
			get {return _entryTime;}
			set {_entryTime = value;}
		}
		private System.String _clerkEmail = string.Empty;
		/// <summary>
		/// 邮箱 
		/// </summary>
		public System.String ClerkEmail
		{
			get {return _clerkEmail;}
			set {_clerkEmail = value;}
		}
		private System.String _clerkMobile = string.Empty;
		/// <summary>
		/// 手机号 
		/// </summary>
		public System.String ClerkMobile
		{
			get {return _clerkMobile;}
			set {_clerkMobile = value;}
		}
		private System.String _clerkWX = string.Empty;
		/// <summary>
		/// 微信 
		/// </summary>
		public System.String ClerkWX
		{
			get {return _clerkWX;}
			set {_clerkWX = value;}
		}
		private System.String _clerkQQ = string.Empty;
		/// <summary>
		/// QQ 
		/// </summary>
		public System.String ClerkQQ
		{
			get {return _clerkQQ;}
			set {_clerkQQ = value;}
		}
		private System.String _clerkIDCard = string.Empty;
		/// <summary>
		/// 身份证号码 
		/// </summary>
		public System.String ClerkIDCard
		{
			get {return _clerkIDCard;}
			set {_clerkIDCard = value;}
		}
		private System.String _clerkIDCardPic = string.Empty;
		/// <summary>
		/// 身份证图片 
		/// </summary>
		public System.String ClerkIDCardPic
		{
			get {return _clerkIDCardPic;}
			set {_clerkIDCardPic = value;}
		}
		private System.String _clerkPic = string.Empty;
		/// <summary>
		/// 本人手持身份证图片 
		/// </summary>
		public System.String ClerkPic
		{
			get {return _clerkPic;}
			set {_clerkPic = value;}
		}
		private System.String _clerkBankBranch = string.Empty;
		/// <summary>
		/// 开户银行 
		/// </summary>
		public System.String ClerkBankBranch
		{
			get {return _clerkBankBranch;}
			set {_clerkBankBranch = value;}
		}
		private System.String _clerkAccountName = string.Empty;
		/// <summary>
		/// 收款开户名 
		/// </summary>
		public System.String ClerkAccountName
		{
			get {return _clerkAccountName;}
			set {_clerkAccountName = value;}
		}
		private System.String _clerkBankAccount = string.Empty;
		/// <summary>
		/// 银行账号 
		/// </summary>
		public System.String ClerkBankAccount
		{
			get {return _clerkBankAccount;}
			set {_clerkBankAccount = value;}
		}
		private System.String _clerkBankPic = string.Empty;
		/// <summary>
		/// 银行卡照片 
		/// </summary>
		public System.String ClerkBankPic
		{
			get {return _clerkBankPic;}
			set {_clerkBankPic = value;}
		}
		private System.Int32 _clerkStatus = 0;
		/// <summary>
		/// 店员状态（0：未认证；1：已认证；2：未通过；3：已提交；4：待完善；） 
		/// </summary>
		public System.Int32 ClerkStatus
		{
			get {return _clerkStatus;}
			set {_clerkStatus = value;}
		}
		private System.String _linkman = string.Empty;
		/// <summary>
		/// 联系人 
		/// </summary>
		public System.String Linkman
		{
			get {return _linkman;}
			set {_linkman = value;}
		}
		private System.String _linkmanTel = string.Empty;
		/// <summary>
		/// 联系人电话 
		/// </summary>
		public System.String LinkmanTel
		{
			get {return _linkmanTel;}
			set {_linkmanTel = value;}
		}
		private System.String _linkmanClose = string.Empty;
		/// <summary>
		/// 与店员的关系 
		/// </summary>
		public System.String LinkmanClose
		{
			get {return _linkmanClose;}
			set {_linkmanClose = value;}
		}
		private System.Int32 _storeID = 0;
		/// <summary>
		/// 所属店铺ID 
		/// </summary>
		public System.Int32 StoreID
		{
			get {return _storeID;}
			set {_storeID = value;}
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
		/// 登录时间 
		/// </summary>
		public DateTime? LoginTime
		{
			get {return _loginTime;}
			set {_loginTime = value;}
		}
		private System.String _loginIP = string.Empty;
		/// <summary>
		/// 登录IP 
		/// </summary>
		public System.String LoginIP
		{
			get {return _loginIP;}
			set {_loginIP = value;}
		}
		private System.Int32 _loginStatus = 0;
		/// <summary>
		/// 登录状态（0：正常；1：锁定；） 
		/// </summary>
		public System.Int32 LoginStatus
		{
			get {return _loginStatus;}
			set {_loginStatus = value;}
		}
		private System.String _clerkRemark = string.Empty;
		/// <summary>
		/// 备注 
		/// </summary>
		public System.String ClerkRemark
		{
			get {return _clerkRemark;}
			set {_clerkRemark = value;}
		}
		private System.String _remarkPic1 = string.Empty;
		/// <summary>
		/// 店面试题图片 
		/// </summary>
		public System.String RemarkPic1
		{
			get {return _remarkPic1;}
			set {_remarkPic1 = value;}
		}
		private System.String _remarkPic2 = string.Empty;
		/// <summary>
		/// 行为规范图片 
		/// </summary>
		public System.String RemarkPic2
		{
			get {return _remarkPic2;}
			set {_remarkPic2 = value;}
		}
		private System.String _remarkPic3 = string.Empty;
		/// <summary>
		/// 商户出具图片 
		/// </summary>
		public System.String RemarkPic3
		{
			get {return _remarkPic3;}
			set {_remarkPic3 = value;}
		}
		#endregion
	}
}
