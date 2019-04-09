// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: StockItemEntity.cs
// 修改时间：2019/4/9 17:45:14
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：StockItem 的实体类.
	/// </summary>
	public partial class StockItemEntity
	{
		#region Properties
		private System.Int32 _itemID = 0;
		/// <summary>
		/// 项目ID (主键)
		/// </summary>
		public System.Int32 ItemID
		{
			get {return _itemID;}
			set {_itemID = value;}
		}
		private System.Int32 _stockID = 0;
		/// <summary>
		/// 库存记录ID 
		/// </summary>
		public System.Int32 StockID
		{
			get {return _stockID;}
			set {_stockID = value;}
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
		private System.String _property = string.Empty;
		/// <summary>
		/// 商品属性 
		/// </summary>
		public System.String Property
		{
			get {return _property;}
			set {_property = value;}
		}
		private System.Int32 _amount = 0;
		/// <summary>
		/// 数量 
		/// </summary>
		public System.Int32 Amount
		{
			get {return _amount;}
			set {_amount = value;}
		}
		private System.Decimal _price = 0;
		/// <summary>
		/// 价钱(成本价/售货价) 
		/// </summary>
		public System.Decimal Price
		{
			get {return _price;}
			set {_price = value;}
		}
		private System.String _tableName = string.Empty;
		/// <summary>
		/// 表名 
		/// </summary>
		public System.String TableName
		{
			get {return _tableName;}
			set {_tableName = value;}
		}
		#endregion
	}
}
