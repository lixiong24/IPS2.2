// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: IntegralProductEntity.cs
// 修改时间：2019/4/9 17:45:08
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：IntegralProduct 的实体类.
	/// </summary>
	public partial class IntegralProductEntity
	{
		#region Properties
		private System.Int32 _id = 0;
		/// <summary>
		/// 编号 (主键)(自增长)
		/// </summary>
		public System.Int32 ID
		{
			get {return _id;}
			set {_id = value;}
		}
		private System.String _title = string.Empty;
		/// <summary>
		/// 积分商品名称 
		/// </summary>
		public System.String Title
		{
			get {return _title;}
			set {_title = value;}
		}
		private System.Decimal _price = 0;
		/// <summary>
		/// 参考价格 
		/// </summary>
		public System.Decimal Price
		{
			get {return _price;}
			set {_price = value;}
		}
		private System.Int32 _needIntegral = 0;
		/// <summary>
		/// 兑换积分商品所需积分 
		/// </summary>
		public System.Int32 NeedIntegral
		{
			get {return _needIntegral;}
			set {_needIntegral = value;}
		}
		private System.String _picture = string.Empty;
		/// <summary>
		/// 积分商品图片 
		/// </summary>
		public System.String Picture
		{
			get {return _picture;}
			set {_picture = value;}
		}
		private System.Int32 _typeID = 0;
		/// <summary>
		/// 栏目 
		/// </summary>
		public System.Int32 TypeID
		{
			get {return _typeID;}
			set {_typeID = value;}
		}
		private System.Int32 _stocks = 0;
		/// <summary>
		/// 库存 
		/// </summary>
		public System.Int32 Stocks
		{
			get {return _stocks;}
			set {_stocks = value;}
		}
		private DateTime? _updateTime = DateTime.MaxValue;
		/// <summary>
		/// 添加时间 
		/// </summary>
		public DateTime? UpdateTime
		{
			get {return _updateTime;}
			set {_updateTime = value;}
		}
		private System.String _pictureBig = string.Empty;
		/// <summary>
		/// 大图 
		/// </summary>
		public System.String PictureBig
		{
			get {return _pictureBig;}
			set {_pictureBig = value;}
		}
		private System.String _content = string.Empty;
		/// <summary>
		/// 内容 
		/// </summary>
		public System.String Content
		{
			get {return _content;}
			set {_content = value;}
		}
		private System.String _description = string.Empty;
		/// <summary>
		/// 描述 
		/// </summary>
		public System.String Description
		{
			get {return _description;}
			set {_description = value;}
		}
		private System.String _keyword = string.Empty;
		/// <summary>
		/// 关键字 
		/// </summary>
		public System.String Keyword
		{
			get {return _keyword;}
			set {_keyword = value;}
		}
		private System.Int32 _exchangeTimes = 0;
		/// <summary>
		/// 兑换次数 
		/// </summary>
		public System.Int32 ExchangeTimes
		{
			get {return _exchangeTimes;}
			set {_exchangeTimes = value;}
		}
		private System.Int32 _eliteLevel = 0;
		/// <summary>
		/// 推荐级 
		/// </summary>
		public System.Int32 EliteLevel
		{
			get {return _eliteLevel;}
			set {_eliteLevel = value;}
		}
		#endregion
	}
}
