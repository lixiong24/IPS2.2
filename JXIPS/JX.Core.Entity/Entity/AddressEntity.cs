// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: AddressEntity.cs
// 修改时间：2019/4/9 17:44:50
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Address 的实体类.
	/// </summary>
	public partial class AddressEntity
	{
		#region Properties
		private System.Int32 _addressID = 0;
		/// <summary>
		/// 地址ID (主键)
		/// </summary>
		public System.Int32 AddressID
		{
			get {return _addressID;}
			set {_addressID = value;}
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
		private System.String _consigneeName = string.Empty;
		/// <summary>
		/// 收货人姓名 
		/// </summary>
		public System.String ConsigneeName
		{
			get {return _consigneeName;}
			set {_consigneeName = value;}
		}
		private System.String _homePhone = string.Empty;
		/// <summary>
		/// 固定电话 
		/// </summary>
		public System.String HomePhone
		{
			get {return _homePhone;}
			set {_homePhone = value;}
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
		/// 国家 
		/// </summary>
		public System.String Country
		{
			get {return _country;}
			set {_country = value;}
		}
		private System.String _province = string.Empty;
		/// <summary>
		/// 省份 
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
		/// 地区 
		/// </summary>
		public System.String Area
		{
			get {return _area;}
			set {_area = value;}
		}
		private System.String _area1 = string.Empty;
		/// <summary>
		/// 街道 
		/// </summary>
		public System.String Area1
		{
			get {return _area1;}
			set {_area1 = value;}
		}
		private System.String _area2 = string.Empty;
		/// <summary>
		/// 小区 
		/// </summary>
		public System.String Area2
		{
			get {return _area2;}
			set {_area2 = value;}
		}
		private System.String _addresses = string.Empty;
		/// <summary>
		/// 详细地址 
		/// </summary>
		public System.String Addresses
		{
			get {return _addresses;}
			set {_addresses = value;}
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
