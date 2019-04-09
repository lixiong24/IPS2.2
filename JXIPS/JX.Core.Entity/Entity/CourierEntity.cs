// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: CourierEntity.cs
// 修改时间：2019/4/9 17:45:07
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Courier 的实体类.
	/// </summary>
	public partial class CourierEntity
	{
		#region Properties
		private System.Int32 _courierID = 0;
		/// <summary>
		/// 快递公司ID (主键)(自增长)
		/// </summary>
		public System.Int32 CourierID
		{
			get {return _courierID;}
			set {_courierID = value;}
		}
		private System.String _shortName = string.Empty;
		/// <summary>
		/// 快递公司缩写名称 
		/// </summary>
		public System.String ShortName
		{
			get {return _shortName;}
			set {_shortName = value;}
		}
		private System.String _fullName = string.Empty;
		/// <summary>
		/// 全称 
		/// </summary>
		public System.String FullName
		{
			get {return _fullName;}
			set {_fullName = value;}
		}
		private System.String _address = string.Empty;
		/// <summary>
		/// 地址 
		/// </summary>
		public System.String Address
		{
			get {return _address;}
			set {_address = value;}
		}
		private System.String _telephone = string.Empty;
		/// <summary>
		/// 电话 
		/// </summary>
		public System.String Telephone
		{
			get {return _telephone;}
			set {_telephone = value;}
		}
		private System.String _contacter = string.Empty;
		/// <summary>
		/// 联系人 
		/// </summary>
		public System.String Contacter
		{
			get {return _contacter;}
			set {_contacter = value;}
		}
		private System.String _searchUrl = string.Empty;
		/// <summary>
		/// 快递查询接口 
		/// </summary>
		public System.String SearchUrl
		{
			get {return _searchUrl;}
			set {_searchUrl = value;}
		}
		private System.String _searchUrlMobile = string.Empty;
		/// <summary>
		/// 快递查询接口(手机) 
		/// </summary>
		public System.String SearchUrlMobile
		{
			get {return _searchUrlMobile;}
			set {_searchUrlMobile = value;}
		}
		#endregion
	}
}
