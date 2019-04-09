// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: CollectionItemEntity.cs
// 修改时间：2019/4/9 17:45:04
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：CollectionItem 的实体类.
	/// </summary>
	public partial class CollectionItemEntity
	{
		#region Properties
		private System.Int32 _itemID = 0;
		/// <summary>
		/// 采集项目ID (主键)
		/// </summary>
		public System.Int32 ItemID
		{
			get {return _itemID;}
			set {_itemID = value;}
		}
		private System.String _itemName = string.Empty;
		/// <summary>
		/// 项目名称 
		/// </summary>
		public System.String ItemName
		{
			get {return _itemName;}
			set {_itemName = value;}
		}
		private System.String _urlName = string.Empty;
		/// <summary>
		/// 采集网站名称 
		/// </summary>
		public System.String UrlName
		{
			get {return _urlName;}
			set {_urlName = value;}
		}
		private System.String _codeType = string.Empty;
		/// <summary>
		/// 编码类型 
		/// </summary>
		public System.String CodeType
		{
			get {return _codeType;}
			set {_codeType = value;}
		}
		private System.String _url = string.Empty;
		/// <summary>
		/// 采集地址 
		/// </summary>
		public System.String Url
		{
			get {return _url;}
			set {_url = value;}
		}
		private System.String _intro = string.Empty;
		/// <summary>
		/// 采集简介 
		/// </summary>
		public System.String Intro
		{
			get {return _intro;}
			set {_intro = value;}
		}
		private System.Int32 _nodeID = 0;
		/// <summary>
		/// 栏目ID 
		/// </summary>
		public System.Int32 NodeID
		{
			get {return _nodeID;}
			set {_nodeID = value;}
		}
		private System.String _infoNodeID = string.Empty;
		/// <summary>
		/// 虚栏目ID 
		/// </summary>
		public System.String InfoNodeID
		{
			get {return _infoNodeID;}
			set {_infoNodeID = value;}
		}
		private System.Int32 _modelID = 0;
		/// <summary>
		/// 模型ID 
		/// </summary>
		public System.Int32 ModelID
		{
			get {return _modelID;}
			set {_modelID = value;}
		}
		private System.String _specialID = string.Empty;
		/// <summary>
		/// 专题ID 
		/// </summary>
		public System.String SpecialID
		{
			get {return _specialID;}
			set {_specialID = value;}
		}
		private System.Int32 _orderType = 0;
		/// <summary>
		/// 采集顺序(0:正续　1:倒续) 
		/// </summary>
		public System.Int32 OrderType
		{
			get {return _orderType;}
			set {_orderType = value;}
		}
		private System.Int32 _maxNum = 0;
		/// <summary>
		/// 指定采集数量,不指定为全部 
		/// </summary>
		public System.Int32 MaxNum
		{
			get {return _maxNum;}
			set {_maxNum = value;}
		}
		private DateTime? _newsCollecDate = DateTime.MaxValue;
		/// <summary>
		/// 最后一次采集时间 
		/// </summary>
		public DateTime? NewsCollecDate
		{
			get {return _newsCollecDate;}
			set {_newsCollecDate = value;}
		}
		private System.Boolean _isDetection = false;
		/// <summary>
		/// 是否测试通过 
		/// </summary>
		public System.Boolean IsDetection
		{
			get {return _isDetection;}
			set {_isDetection = value;}
		}
		private System.Boolean _isAutoCreateHtml = false;
		/// <summary>
		/// 是否自动生成HTML 
		/// </summary>
		public System.Boolean IsAutoCreateHtml
		{
			get {return _isAutoCreateHtml;}
			set {_isAutoCreateHtml = value;}
		}
		#endregion
	}
}
