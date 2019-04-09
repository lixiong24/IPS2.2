// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: PaymentTypeEntity.cs
// 修改时间：2019/4/9 17:45:11
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：PaymentType 的实体类.
	/// </summary>
	public partial class PaymentTypeEntity
	{
		#region Properties
		private System.Int32 _typeID = 0;
		/// <summary>
		/// 付款方式ID (主键)
		/// </summary>
		public System.Int32 TypeID
		{
			get {return _typeID;}
			set {_typeID = value;}
		}
		private System.String _typeName = string.Empty;
		/// <summary>
		/// 付款方式名称 
		/// </summary>
		public System.String TypeName
		{
			get {return _typeName;}
			set {_typeName = value;}
		}
		private System.String _intro = string.Empty;
		/// <summary>
		/// 付款方式简介 
		/// </summary>
		public System.String Intro
		{
			get {return _intro;}
			set {_intro = value;}
		}
		private System.Double _discount = 0.0f;
		/// <summary>
		/// 折扣率 
		/// </summary>
		public System.Double Discount
		{
			get {return _discount;}
			set {_discount = value;}
		}
		private System.Int32 _orderSort = 0;
		/// <summary>
		/// 排序ID 
		/// </summary>
		public System.Int32 OrderSort
		{
			get {return _orderSort;}
			set {_orderSort = value;}
		}
		private System.Boolean _isDefault = false;
		/// <summary>
		/// 是否默认 
		/// </summary>
		public System.Boolean IsDefault
		{
			get {return _isDefault;}
			set {_isDefault = value;}
		}
		private System.Boolean _isDisabled = false;
		/// <summary>
		/// 是否禁用 
		/// </summary>
		public System.Boolean IsDisabled
		{
			get {return _isDisabled;}
			set {_isDisabled = value;}
		}
		private System.Int32 _category = 0;
		/// <summary>
		/// 付款方式类别 0 其它 、1 在线支付 、2 余额支付 
		/// </summary>
		public System.Int32 Category
		{
			get {return _category;}
			set {_category = value;}
		}
		#endregion
	}
}
