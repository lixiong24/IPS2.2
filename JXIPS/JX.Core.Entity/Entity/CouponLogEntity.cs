// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: CouponLogEntity.cs
// 修改时间：2019/4/9 17:45:07
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：CouponLog 的实体类.
	/// </summary>
	public partial class CouponLogEntity
	{
		#region Properties
		private System.Int32 _id = 0;
		/// <summary>
		/// ID (主键)(自增长)
		/// </summary>
		public System.Int32 ID
		{
			get {return _id;}
			set {_id = value;}
		}
		private System.Int32 _couponID = 0;
		/// <summary>
		/// 优惠券ID 
		/// </summary>
		public System.Int32 CouponID
		{
			get {return _couponID;}
			set {_couponID = value;}
		}
		private System.String _couponNum = string.Empty;
		/// <summary>
		/// 优惠券号码 
		/// </summary>
		public System.String CouponNum
		{
			get {return _couponNum;}
			set {_couponNum = value;}
		}
		private System.Int32 _userID = 0;
		/// <summary>
		/// 用户ID 
		/// </summary>
		public System.Int32 UserID
		{
			get {return _userID;}
			set {_userID = value;}
		}
		private System.Int32 _orderID = 0;
		/// <summary>
		/// 订单ID 
		/// </summary>
		public System.Int32 OrderID
		{
			get {return _orderID;}
			set {_orderID = value;}
		}
		private System.Int32 _usetimes = 0;
		/// <summary>
		/// 使用次数 
		/// </summary>
		public System.Int32 Usetimes
		{
			get {return _usetimes;}
			set {_usetimes = value;}
		}
		#endregion
	}
}
