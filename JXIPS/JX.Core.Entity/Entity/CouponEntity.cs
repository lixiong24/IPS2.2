// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: CouponEntity.cs
// 修改时间：2019/4/9 17:45:07
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Coupon 的实体类.
	/// </summary>
	public partial class CouponEntity
	{
		#region Properties
		private System.Int32 _couponID = 0;
		/// <summary>
		/// 优惠券ID (主键)
		/// </summary>
		public System.Int32 CouponID
		{
			get {return _couponID;}
			set {_couponID = value;}
		}
		private System.String _couponName = string.Empty;
		/// <summary>
		/// 优惠券名称 
		/// </summary>
		public System.String CouponName
		{
			get {return _couponName;}
			set {_couponName = value;}
		}
		private System.String _couponNumPattern = string.Empty;
		/// <summary>
		/// 优惠券号码生成格式 
		/// </summary>
		public System.String CouponNumPattern
		{
			get {return _couponNumPattern;}
			set {_couponNumPattern = value;}
		}
		private System.Decimal _money = 0;
		/// <summary>
		/// 面值 
		/// </summary>
		public System.Decimal Money
		{
			get {return _money;}
			set {_money = value;}
		}
		private System.Int32 _state = 0;
		/// <summary>
		/// 状态 
		/// </summary>
		public System.Int32 State
		{
			get {return _state;}
			set {_state = value;}
		}
		private System.String _userGroup = string.Empty;
		/// <summary>
		/// 适用会员组 
		/// </summary>
		public System.String UserGroup
		{
			get {return _userGroup;}
			set {_userGroup = value;}
		}
		private DateTime? _beginDate = DateTime.MaxValue;
		/// <summary>
		/// 开始时间 
		/// </summary>
		public DateTime? BeginDate
		{
			get {return _beginDate;}
			set {_beginDate = value;}
		}
		private DateTime? _endDate = DateTime.MaxValue;
		/// <summary>
		/// 截止时间 
		/// </summary>
		public DateTime? EndDate
		{
			get {return _endDate;}
			set {_endDate = value;}
		}
		private System.Int32 _limitNum = 0;
		/// <summary>
		/// 限用次数 
		/// </summary>
		public System.Int32 LimitNum
		{
			get {return _limitNum;}
			set {_limitNum = value;}
		}
		private System.Int32 _productLimitType = 0;
		/// <summary>
		/// 限用商品类型 
		/// </summary>
		public System.Int32 ProductLimitType
		{
			get {return _productLimitType;}
			set {_productLimitType = value;}
		}
		private System.String _productLimitContent = string.Empty;
		/// <summary>
		/// 限用商品 
		/// </summary>
		public System.String ProductLimitContent
		{
			get {return _productLimitContent;}
			set {_productLimitContent = value;}
		}
		private System.Int32 _couponCreateType = 0;
		/// <summary>
		/// 优惠券生成方式 
		/// </summary>
		public System.Int32 CouponCreateType
		{
			get {return _couponCreateType;}
			set {_couponCreateType = value;}
		}
		private System.String _couponCreateContent = string.Empty;
		/// <summary>
		/// 优惠券生成条件内容 
		/// </summary>
		public System.String CouponCreateContent
		{
			get {return _couponCreateContent;}
			set {_couponCreateContent = value;}
		}
		private System.Decimal _orderTotalMoney = 0;
		/// <summary>
		/// 使用该优惠券需要的订单满足金额 
		/// </summary>
		public System.Decimal OrderTotalMoney
		{
			get {return _orderTotalMoney;}
			set {_orderTotalMoney = value;}
		}
		private DateTime? _useBeginDate = DateTime.MaxValue;
		/// <summary>
		/// 使用开始时间 
		/// </summary>
		public DateTime? UseBeginDate
		{
			get {return _useBeginDate;}
			set {_useBeginDate = value;}
		}
		private DateTime? _useEndDate = DateTime.MaxValue;
		/// <summary>
		/// 使用截止时间 
		/// </summary>
		public DateTime? UseEndDate
		{
			get {return _useEndDate;}
			set {_useEndDate = value;}
		}
		private System.Int32 _couponItemNum = 0;
		/// <summary>
		/// 优惠卷张数 
		/// </summary>
		public System.Int32 CouponItemNum
		{
			get {return _couponItemNum;}
			set {_couponItemNum = value;}
		}
		#endregion
	}
}
