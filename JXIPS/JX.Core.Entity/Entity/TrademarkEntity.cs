// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: TrademarkEntity.cs
// 修改时间：2019/4/9 17:45:14
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Trademark 的实体类.
	/// </summary>
	public partial class TrademarkEntity
	{
		#region Properties
		private System.Int32 _trademarkID = 0;
		/// <summary>
		/// 商标ID (主键)(自增长)
		/// </summary>
		public System.Int32 TrademarkID
		{
			get {return _trademarkID;}
			set {_trademarkID = value;}
		}
		private System.Int32 _trademarkType = 0;
		/// <summary>
		/// 商标分类 
		/// </summary>
		public System.Int32 TrademarkType
		{
			get {return _trademarkType;}
			set {_trademarkType = value;}
		}
		private System.Int32 _producerID = 0;
		/// <summary>
		/// 商标持有人 
		/// </summary>
		public System.Int32 ProducerID
		{
			get {return _producerID;}
			set {_producerID = value;}
		}
		private System.String _trademarkName = string.Empty;
		/// <summary>
		/// 品牌或商标 
		/// </summary>
		public System.String TrademarkName
		{
			get {return _trademarkName;}
			set {_trademarkName = value;}
		}
		private System.String _trademarkPhoto = string.Empty;
		/// <summary>
		/// 品牌LOGO 
		/// </summary>
		public System.String TrademarkPhoto
		{
			get {return _trademarkPhoto;}
			set {_trademarkPhoto = value;}
		}
		private System.String _trademarkMorePic = string.Empty;
		/// <summary>
		/// 品牌多图 
		/// </summary>
		public System.String TrademarkMorePic
		{
			get {return _trademarkMorePic;}
			set {_trademarkMorePic = value;}
		}
		private System.String _trademarkIntro = string.Empty;
		/// <summary>
		/// 商标简介 
		/// </summary>
		public System.String TrademarkIntro
		{
			get {return _trademarkIntro;}
			set {_trademarkIntro = value;}
		}
		private System.String _trademarkIntro1 = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String TrademarkIntro1
		{
			get {return _trademarkIntro1;}
			set {_trademarkIntro1 = value;}
		}
		private System.String _trademarkIntro2 = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String TrademarkIntro2
		{
			get {return _trademarkIntro2;}
			set {_trademarkIntro2 = value;}
		}
		private System.String _trademarkIntro3 = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String TrademarkIntro3
		{
			get {return _trademarkIntro3;}
			set {_trademarkIntro3 = value;}
		}
		private System.String _trademarkIntro4 = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String TrademarkIntro4
		{
			get {return _trademarkIntro4;}
			set {_trademarkIntro4 = value;}
		}
		private System.Boolean _isPassed = false;
		/// <summary>
		/// 是否通过 
		/// </summary>
		public System.Boolean IsPassed
		{
			get {return _isPassed;}
			set {_isPassed = value;}
		}
		private System.Boolean _isTop = false;
		/// <summary>
		/// 是否固顶 
		/// </summary>
		public System.Boolean IsTop
		{
			get {return _isTop;}
			set {_isTop = value;}
		}
		private System.Boolean _isElite = false;
		/// <summary>
		/// 是否推荐 
		/// </summary>
		public System.Boolean IsElite
		{
			get {return _isElite;}
			set {_isElite = value;}
		}
		private System.Int32 _hits = 0;
		/// <summary>
		/// 点击数 
		/// </summary>
		public System.Int32 Hits
		{
			get {return _hits;}
			set {_hits = value;}
		}
		#endregion
	}
}
