// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: PresentEntity.cs
// 修改时间：2019/4/9 17:45:11
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Present 的实体类.
	/// </summary>
	public partial class PresentEntity
	{
		#region Properties
		private System.Int32 _presentID = 0;
		/// <summary>
		/// 礼品编号 (主键)
		/// </summary>
		public System.Int32 PresentID
		{
			get {return _presentID;}
			set {_presentID = value;}
		}
		private System.String _presentName = string.Empty;
		/// <summary>
		/// 礼品名称 
		/// </summary>
		public System.String PresentName
		{
			get {return _presentName;}
			set {_presentName = value;}
		}
		private System.String _presentPic = string.Empty;
		/// <summary>
		/// 礼品图片 
		/// </summary>
		public System.String PresentPic
		{
			get {return _presentPic;}
			set {_presentPic = value;}
		}
		private System.String _unit = string.Empty;
		/// <summary>
		/// 礼品单位 
		/// </summary>
		public System.String Unit
		{
			get {return _unit;}
			set {_unit = value;}
		}
		private System.String _presentNum = string.Empty;
		/// <summary>
		/// 礼品数量 
		/// </summary>
		public System.String PresentNum
		{
			get {return _presentNum;}
			set {_presentNum = value;}
		}
		private System.Int32 _serviceTermUnit = 0;
		/// <summary>
		/// 单位 
		/// </summary>
		public System.Int32 ServiceTermUnit
		{
			get {return _serviceTermUnit;}
			set {_serviceTermUnit = value;}
		}
		private System.Int32 _serviceTerm = 0;
		/// <summary>
		/// 服务期限 
		/// </summary>
		public System.Int32 ServiceTerm
		{
			get {return _serviceTerm;}
			set {_serviceTerm = value;}
		}
		private System.Decimal _price = 0;
		/// <summary>
		/// 价格 
		/// </summary>
		public System.Decimal Price
		{
			get {return _price;}
			set {_price = value;}
		}
		private System.Decimal _price_Market = 0;
		/// <summary>
		/// 市场价 
		/// </summary>
		public System.Decimal Price_Market
		{
			get {return _price_Market;}
			set {_price_Market = value;}
		}
		private System.Double _weight = 0.0f;
		/// <summary>
		/// 重量 
		/// </summary>
		public System.Double Weight
		{
			get {return _weight;}
			set {_weight = value;}
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
		private System.Int32 _stocksProject = 0;
		/// <summary>
		/// 库存计算方式 
		/// </summary>
		public System.Int32 StocksProject
		{
			get {return _stocksProject;}
			set {_stocksProject = value;}
		}
		private System.Int32 _orderNum = 0;
		/// <summary>
		/// 订购数量 
		/// </summary>
		public System.Int32 OrderNum
		{
			get {return _orderNum;}
			set {_orderNum = value;}
		}
		private System.Int32 _alarmNum = 0;
		/// <summary>
		/// 警报数量 
		/// </summary>
		public System.Int32 AlarmNum
		{
			get {return _alarmNum;}
			set {_alarmNum = value;}
		}
		private System.Int32 _productCharacter = 0;
		/// <summary>
		/// 礼品类型 
		/// </summary>
		public System.Int32 ProductCharacter
		{
			get {return _productCharacter;}
			set {_productCharacter = value;}
		}
		private System.String _downloadUrl = string.Empty;
		/// <summary>
		/// 下载地址 
		/// </summary>
		public System.String DownloadUrl
		{
			get {return _downloadUrl;}
			set {_downloadUrl = value;}
		}
		private System.String _remark = string.Empty;
		/// <summary>
		/// 下载说明 
		/// </summary>
		public System.String Remark
		{
			get {return _remark;}
			set {_remark = value;}
		}
		private System.String _presentThumb = string.Empty;
		/// <summary>
		/// 缩略图 
		/// </summary>
		public System.String PresentThumb
		{
			get {return _presentThumb;}
			set {_presentThumb = value;}
		}
		private System.String _presentIntro = string.Empty;
		/// <summary>
		/// 简单介绍 
		/// </summary>
		public System.String PresentIntro
		{
			get {return _presentIntro;}
			set {_presentIntro = value;}
		}
		private System.String _presentExplain = string.Empty;
		/// <summary>
		/// 详细介绍 
		/// </summary>
		public System.String PresentExplain
		{
			get {return _presentExplain;}
			set {_presentExplain = value;}
		}
		#endregion
	}
}
