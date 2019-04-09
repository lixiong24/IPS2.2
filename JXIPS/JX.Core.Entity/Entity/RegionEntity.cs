// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: RegionEntity.cs
// 修改时间：2019/4/9 17:45:12
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Region 的实体类.
	/// </summary>
	public partial class RegionEntity
	{
		#region Properties
		private System.Int32 _regionID = 0;
		/// <summary>
		/// 区域ID (主键)(自增长)
		/// </summary>
		public System.Int32 RegionID
		{
			get {return _regionID;}
			set {_regionID = value;}
		}
		private System.String _country = string.Empty;
		/// <summary>
		/// 国家名称 
		/// </summary>
		public System.String Country
		{
			get {return _country;}
			set {_country = value;}
		}
		private System.String _province = string.Empty;
		/// <summary>
		/// 省份名称	 
		/// </summary>
		public System.String Province
		{
			get {return _province;}
			set {_province = value;}
		}
		private System.String _city = string.Empty;
		/// <summary>
		/// 城市名称	 
		/// </summary>
		public System.String City
		{
			get {return _city;}
			set {_city = value;}
		}
		private System.String _area = string.Empty;
		/// <summary>
		/// 区域名称 
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
		private System.String _postCode = string.Empty;
		/// <summary>
		/// 邮政编码 
		/// </summary>
		public System.String PostCode
		{
			get {return _postCode;}
			set {_postCode = value;}
		}
		private System.String _areaCode = string.Empty;
		/// <summary>
		/// 区号 
		/// </summary>
		public System.String AreaCode
		{
			get {return _areaCode;}
			set {_areaCode = value;}
		}
		#endregion
	}
}
