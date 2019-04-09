// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: StatTimezoneEntity.cs
// 修改时间：2019/4/9 17:45:13
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：StatTimezone 的实体类.
	/// </summary>
	public partial class StatTimezoneEntity
	{
		#region Properties
		private System.String _tTimezone = string.Empty;
		/// <summary>
		/// 时区 (主键)
		/// </summary>
		public System.String TTimezone
		{
			get {return _tTimezone;}
			set {_tTimezone = value;}
		}
		private System.Int32 _tTimNum = 0;
		/// <summary>
		/// 数量 
		/// </summary>
		public System.Int32 TTimNum
		{
			get {return _tTimNum;}
			set {_tTimNum = value;}
		}
		#endregion
	}
}
