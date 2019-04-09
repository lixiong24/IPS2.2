// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: U_BuyingEntity.cs
// 修改时间：2019/4/9 17:45:14
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：U_Buying 的实体类.
	/// </summary>
	public partial class U_BuyingEntity
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
		private DateTime? _beginTime = DateTime.MaxValue;
		/// <summary>
		///  
		/// </summary>
		public DateTime? BeginTime
		{
			get {return _beginTime;}
			set {_beginTime = value;}
		}
		private DateTime? _endTime = DateTime.MaxValue;
		/// <summary>
		///  
		/// </summary>
		public DateTime? EndTime
		{
			get {return _endTime;}
			set {_endTime = value;}
		}
		#endregion
	}
}
