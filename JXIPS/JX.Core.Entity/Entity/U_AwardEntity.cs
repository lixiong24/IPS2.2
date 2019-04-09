// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: U_AwardEntity.cs
// 修改时间：2019/4/9 17:45:14
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：U_Award 的实体类.
	/// </summary>
	public partial class U_AwardEntity
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
		private System.Double _weight = 0.0f;
		/// <summary>
		///  
		/// </summary>
		public System.Double Weight
		{
			get {return _weight;}
			set {_weight = value;}
		}
		private System.String _number = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String Number
		{
			get {return _number;}
			set {_number = value;}
		}
		#endregion
	}
}
