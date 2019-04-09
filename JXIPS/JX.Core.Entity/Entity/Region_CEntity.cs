// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: Region_CEntity.cs
// 修改时间：2019/4/9 17:45:12
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Region_C 的实体类.
	/// </summary>
	public partial class Region_CEntity
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
		/// 区域 
		/// </summary>
		public System.String Area
		{
			get {return _area;}
			set {_area = value;}
		}
		private System.String _name = string.Empty;
		/// <summary>
		/// 自定义关联内容 
		/// </summary>
		public System.String Name
		{
			get {return _name;}
			set {_name = value;}
		}
		#endregion
	}
}
