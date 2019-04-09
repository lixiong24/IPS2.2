// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: AdvertisementEntity.cs
// 修改时间：2019/4/9 17:45:02
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Advertisement 的实体类.
	/// </summary>
	public partial class AdvertisementEntity
	{
		#region Properties
		private System.Int32 _adid = 0;
		/// <summary>
		/// 广告ID (主键)
		/// </summary>
		public System.Int32 ADID
		{
			get {return _adid;}
			set {_adid = value;}
		}
		private System.Int32 _userID = 0;
		/// <summary>
		/// 广告客户ID 
		/// </summary>
		public System.Int32 UserID
		{
			get {return _userID;}
			set {_userID = value;}
		}
		private System.Int32 _aDType = 0;
		/// <summary>
		/// 广告类型 图片、动画、文本、代码、页面 
		/// </summary>
		public System.Int32 ADType
		{
			get {return _aDType;}
			set {_aDType = value;}
		}
		private System.String _aDName = string.Empty;
		/// <summary>
		/// 广告名称 
		/// </summary>
		public System.String ADName
		{
			get {return _aDName;}
			set {_aDName = value;}
		}
		private System.String _imgUrl = string.Empty;
		/// <summary>
		/// 图片地址 
		/// </summary>
		public System.String ImgUrl
		{
			get {return _imgUrl;}
			set {_imgUrl = value;}
		}
		private System.Int32 _imgWidth = 0;
		/// <summary>
		/// 图片的宽度 
		/// </summary>
		public System.Int32 ImgWidth
		{
			get {return _imgWidth;}
			set {_imgWidth = value;}
		}
		private System.Int32 _imgHeight = 0;
		/// <summary>
		/// 图片的高度 
		/// </summary>
		public System.Int32 ImgHeight
		{
			get {return _imgHeight;}
			set {_imgHeight = value;}
		}
		private System.Int32 _flashWmode = 0;
		/// <summary>
		/// Flash是否透明 
		/// </summary>
		public System.Int32 FlashWmode
		{
			get {return _flashWmode;}
			set {_flashWmode = value;}
		}
		private System.String _aDIntro = string.Empty;
		/// <summary>
		/// 广告内容 
		/// </summary>
		public System.String ADIntro
		{
			get {return _aDIntro;}
			set {_aDIntro = value;}
		}
		private System.String _linkUrl = string.Empty;
		/// <summary>
		/// 链接网址 
		/// </summary>
		public System.String LinkUrl
		{
			get {return _linkUrl;}
			set {_linkUrl = value;}
		}
		private System.Int32 _linkTarget = 0;
		/// <summary>
		/// 是否在新窗口打开 
		/// </summary>
		public System.Int32 LinkTarget
		{
			get {return _linkTarget;}
			set {_linkTarget = value;}
		}
		private System.String _linkAlt = string.Empty;
		/// <summary>
		/// 链接提示 
		/// </summary>
		public System.String LinkAlt
		{
			get {return _linkAlt;}
			set {_linkAlt = value;}
		}
		private System.Int32 _priority = 0;
		/// <summary>
		/// 广告项目的权重 
		/// </summary>
		public System.Int32 Priority
		{
			get {return _priority;}
			set {_priority = value;}
		}
		private System.String _setting = string.Empty;
		/// <summary>
		/// 其他设定 
		/// </summary>
		public System.String Setting
		{
			get {return _setting;}
			set {_setting = value;}
		}
		private System.Boolean _isCountView = false;
		/// <summary>
		/// 是否统计浏览数 
		/// </summary>
		public System.Boolean IsCountView
		{
			get {return _isCountView;}
			set {_isCountView = value;}
		}
		private System.Int32 _views = 0;
		/// <summary>
		/// 浏览数 
		/// </summary>
		public System.Int32 Views
		{
			get {return _views;}
			set {_views = value;}
		}
		private System.Boolean _isCountClick = false;
		/// <summary>
		/// 是否统计点击数 
		/// </summary>
		public System.Boolean IsCountClick
		{
			get {return _isCountClick;}
			set {_isCountClick = value;}
		}
		private System.Int32 _clicks = 0;
		/// <summary>
		/// 点击数 
		/// </summary>
		public System.Int32 Clicks
		{
			get {return _clicks;}
			set {_clicks = value;}
		}
		private System.Boolean _isAbsolutePath = false;
		/// <summary>
		/// 是否绝对路径 
		/// </summary>
		public System.Boolean IsAbsolutePath
		{
			get {return _isAbsolutePath;}
			set {_isAbsolutePath = value;}
		}
		private System.Boolean _isPassed = false;
		/// <summary>
		/// 是否通过审核 
		/// </summary>
		public System.Boolean IsPassed
		{
			get {return _isPassed;}
			set {_isPassed = value;}
		}
		private DateTime? _overdueDate = DateTime.MaxValue;
		/// <summary>
		/// 广告过期时间 
		/// </summary>
		public DateTime? OverdueDate
		{
			get {return _overdueDate;}
			set {_overdueDate = value;}
		}
		#endregion
	}
}
