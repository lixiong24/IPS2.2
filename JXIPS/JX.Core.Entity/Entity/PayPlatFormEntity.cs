// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: PayPlatFormEntity.cs
// 修改时间：2019/4/9 17:45:11
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：PayPlatForm 的实体类.
	/// </summary>
	public partial class PayPlatFormEntity
	{
		#region Properties
		private System.Int32 _payPlatformID = 0;
		/// <summary>
		/// 平台ID (主键)
		/// </summary>
		public System.Int32 PayPlatformID
		{
			get {return _payPlatformID;}
			set {_payPlatformID = value;}
		}
		private System.String _payPlatformName = string.Empty;
		/// <summary>
		/// 平台名称 
		/// </summary>
		public System.String PayPlatformName
		{
			get {return _payPlatformName;}
			set {_payPlatformName = value;}
		}
		private System.String _accountsID = string.Empty;
		/// <summary>
		/// 帐号 
		/// </summary>
		public System.String AccountsID
		{
			get {return _accountsID;}
			set {_accountsID = value;}
		}
		private System.String _md5 = string.Empty;
		/// <summary>
		/// MD5密钥 
		/// </summary>
		public System.String MD5
		{
			get {return _md5;}
			set {_md5 = value;}
		}
		private System.Double _rate = 0.0f;
		/// <summary>
		/// 手续费 
		/// </summary>
		public System.Double Rate
		{
			get {return _rate;}
			set {_rate = value;}
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
		private System.Boolean _isDisabled = false;
		/// <summary>
		/// 是否启用 
		/// </summary>
		public System.Boolean IsDisabled
		{
			get {return _isDisabled;}
			set {_isDisabled = value;}
		}
		private System.Boolean _isDefault = false;
		/// <summary>
		/// 是否默认 
		/// </summary>
		public System.Boolean IsDefault
		{
			get {return _isDefault;}
			set {_isDefault = value;}
		}
		#endregion
	}
}
