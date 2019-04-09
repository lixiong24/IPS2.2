// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: U_AwardLogEntity.cs
// 修改时间：2019/4/9 17:45:14
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：U_AwardLog 的实体类.
	/// </summary>
	public partial class U_AwardLogEntity
	{
		#region Properties
		private System.Int32 _id = 0;
		/// <summary>
		///  (主键)
		/// </summary>
		public System.Int32 ID
		{
			get {return _id;}
			set {_id = value;}
		}
		private System.String _guestName = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String GuestName
		{
			get {return _guestName;}
			set {_guestName = value;}
		}
		#endregion
	}
}
