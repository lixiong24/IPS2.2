// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: ShoppingCartsEntity.cs
// 修改时间：2019/4/9 17:45:12
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：ShoppingCarts 的实体类.
	/// </summary>
	public partial class ShoppingCartsEntity
	{
		#region Properties
		private System.Int32 _cartItemID = 0;
		/// <summary>
		/// 项目ID (主键)(自增长)
		/// </summary>
		public System.Int32 CartItemID
		{
			get {return _cartItemID;}
			set {_cartItemID = value;}
		}
		private System.String _userName = string.Empty;
		/// <summary>
		/// 用户名 
		/// </summary>
		public System.String UserName
		{
			get {return _userName;}
			set {_userName = value;}
		}
		private System.String _cartID = string.Empty;
		/// <summary>
		/// 购物车ID 
		/// </summary>
		public System.String CartID
		{
			get {return _cartID;}
			set {_cartID = value;}
		}
		private System.Int32 _productID = 0;
		/// <summary>
		/// 商品ID 
		/// </summary>
		public System.Int32 ProductID
		{
			get {return _productID;}
			set {_productID = value;}
		}
		private System.Int32 _quantity = 0;
		/// <summary>
		/// 订购数量 
		/// </summary>
		public System.Int32 Quantity
		{
			get {return _quantity;}
			set {_quantity = value;}
		}
		private System.Boolean _isPresent = false;
		/// <summary>
		/// 赠品ID 
		/// </summary>
		public System.Boolean IsPresent
		{
			get {return _isPresent;}
			set {_isPresent = value;}
		}
		private DateTime? _updateTime = DateTime.MaxValue;
		/// <summary>
		/// 更新时间 
		/// </summary>
		public DateTime? UpdateTime
		{
			get {return _updateTime;}
			set {_updateTime = value;}
		}
		private System.String _tableName = string.Empty;
		/// <summary>
		/// 商品表名 
		/// </summary>
		public System.String TableName
		{
			get {return _tableName;}
			set {_tableName = value;}
		}
		private System.String _property = string.Empty;
		/// <summary>
		/// 商品属性 
		/// </summary>
		public System.String Property
		{
			get {return _property;}
			set {_property = value;}
		}
		private System.Int32 _informResult = 0;
		/// <summary>
		/// 短信通知结果 
		/// </summary>
		public System.Int32 InformResult
		{
			get {return _informResult;}
			set {_informResult = value;}
		}
		private System.Int32 _belongsToProductID = 0;
		/// <summary>
		/// 关联商品编号 
		/// </summary>
		public System.Int32 BelongsToProductID
		{
			get {return _belongsToProductID;}
			set {_belongsToProductID = value;}
		}
		private System.String _remark = string.Empty;
		/// <summary>
		/// 备注 
		/// </summary>
		public System.String Remark
		{
			get {return _remark;}
			set {_remark = value;}
		}
		private System.Int32 _deadline = 0;
		/// <summary>
		/// 分期期限 
		/// </summary>
		public System.Int32 Deadline
		{
			get {return _deadline;}
			set {_deadline = value;}
		}
		private System.Decimal _downPayment = 0;
		/// <summary>
		/// 首付金额 
		/// </summary>
		public System.Decimal DownPayment
		{
			get {return _downPayment;}
			set {_downPayment = value;}
		}
		#endregion
	}
}
