// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: StatAddressEntity.cs
// 修改时间：2019/4/9 17:45:13
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：StatAddress 的实体类.
	/// </summary>
	public partial class StatAddressEntity
	{
		#region Properties
		private System.String _tAddress = string.Empty;
		/// <summary>
		/// 地区名称 (主键)
		/// </summary>
		public System.String TAddress
		{
			get {return _tAddress;}
			set {_tAddress = value;}
		}
		private System.Int32 _tAddNum = 0;
		/// <summary>
		/// 数量 
		/// </summary>
		public System.Int32 TAddNum
		{
			get {return _tAddNum;}
			set {_tAddNum = value;}
		}
		#endregion
	}
}
