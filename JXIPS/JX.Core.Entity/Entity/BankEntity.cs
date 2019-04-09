// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: BankEntity.cs
// 修改时间：2019/4/9 17:45:03
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Bank 的实体类.
	/// </summary>
	public partial class BankEntity
	{
		#region Properties
		private System.Int32 _bankID = 0;
		/// <summary>
		/// 银行帐户ID (主键)
		/// </summary>
		public System.Int32 BankID
		{
			get {return _bankID;}
			set {_bankID = value;}
		}
		private System.String _bankShortName = string.Empty;
		/// <summary>
		/// 帐户名称 
		/// </summary>
		public System.String BankShortName
		{
			get {return _bankShortName;}
			set {_bankShortName = value;}
		}
		private System.String _bankName = string.Empty;
		/// <summary>
		/// 开户行 
		/// </summary>
		public System.String BankName
		{
			get {return _bankName;}
			set {_bankName = value;}
		}
		private System.String _accounts = string.Empty;
		/// <summary>
		/// 帐号 
		/// </summary>
		public System.String Accounts
		{
			get {return _accounts;}
			set {_accounts = value;}
		}
		private System.String _cardNum = string.Empty;
		/// <summary>
		/// 卡号 
		/// </summary>
		public System.String CardNum
		{
			get {return _cardNum;}
			set {_cardNum = value;}
		}
		private System.String _holderName = string.Empty;
		/// <summary>
		/// 户名 
		/// </summary>
		public System.String HolderName
		{
			get {return _holderName;}
			set {_holderName = value;}
		}
		private System.String _bankIntro = string.Empty;
		/// <summary>
		/// 帐户说明 
		/// </summary>
		public System.String BankIntro
		{
			get {return _bankIntro;}
			set {_bankIntro = value;}
		}
		private System.String _bankPic = string.Empty;
		/// <summary>
		/// 银行图标 
		/// </summary>
		public System.String BankPic
		{
			get {return _bankPic;}
			set {_bankPic = value;}
		}
		private System.Int32 _orderSort = 0;
		/// <summary>
		/// 排序ID 
		/// </summary>
		public System.Int32 OrderSort
		{
			get {return _orderSort;}
			set {_orderSort = value;}
		}
		private System.Boolean _isDefault = false;
		/// <summary>
		/// 是否为默认银行帐户 
		/// </summary>
		public System.Boolean IsDefault
		{
			get {return _isDefault;}
			set {_isDefault = value;}
		}
		private System.Boolean _isDisabled = false;
		/// <summary>
		/// 是否禁用 
		/// </summary>
		public System.Boolean IsDisabled
		{
			get {return _isDisabled;}
			set {_isDisabled = value;}
		}
		#endregion
	}
}
