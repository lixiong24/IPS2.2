// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: CommonInfoEntity.cs
// 修改时间：2019/4/9 17:45:05
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：CommonInfo 的实体类.
	/// </summary>
	public partial class CommonInfoEntity
	{
		#region Properties
		private System.Int32 _generalID = 0;
		/// <summary>
		/// 内容全局ID (主键)
		/// </summary>
		public System.Int32 GeneralID
		{
			get {return _generalID;}
			set {_generalID = value;}
		}
		private System.Int32 _nodeID = 0;
		/// <summary>
		/// 节点ID 
		/// </summary>
		public System.Int32 NodeID
		{
			get {return _nodeID;}
			set {_nodeID = value;}
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
		private System.Int32 _itemID = 0;
		/// <summary>
		/// 与相应模型表中的ID相对应的记录ID 
		/// </summary>
		public System.Int32 ItemID
		{
			get {return _itemID;}
			set {_itemID = value;}
		}
		private System.String _tableName = string.Empty;
		/// <summary>
		/// 模型表名 
		/// </summary>
		public System.String TableName
		{
			get {return _tableName;}
			set {_tableName = value;}
		}
		private System.String _title = string.Empty;
		/// <summary>
		/// 标题 
		/// </summary>
		public System.String Title
		{
			get {return _title;}
			set {_title = value;}
		}
		private System.String _inputer = string.Empty;
		/// <summary>
		/// 录入者 
		/// </summary>
		public System.String Inputer
		{
			get {return _inputer;}
			set {_inputer = value;}
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
		private System.Int32 _dayHits = 0;
		/// <summary>
		/// 日点击数 
		/// </summary>
		public System.Int32 DayHits
		{
			get {return _dayHits;}
			set {_dayHits = value;}
		}
		private System.Int32 _weekHits = 0;
		/// <summary>
		/// 周点击数 
		/// </summary>
		public System.Int32 WeekHits
		{
			get {return _weekHits;}
			set {_weekHits = value;}
		}
		private System.Int32 _monthHits = 0;
		/// <summary>
		/// 月点击数 
		/// </summary>
		public System.Int32 MonthHits
		{
			get {return _monthHits;}
			set {_monthHits = value;}
		}
		private System.Int32 _linkType = 0;
		/// <summary>
		/// 链接类型（0：实链接，1：虚链接） 
		/// </summary>
		public System.Int32 LinkType
		{
			get {return _linkType;}
			set {_linkType = value;}
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
		private DateTime? _createTime = DateTime.MaxValue;
		/// <summary>
		/// 生成HTML页面时间 
		/// </summary>
		public DateTime? CreateTime
		{
			get {return _createTime;}
			set {_createTime = value;}
		}
		private System.String _templateFile = string.Empty;
		/// <summary>
		/// 该文章所使用的模板路径 
		/// </summary>
		public System.String TemplateFile
		{
			get {return _templateFile;}
			set {_templateFile = value;}
		}
		private System.Int32 _infoStatus = 0;
		/// <summary>
		/// 信息状态（-3：删除，-2：退稿，-1：草稿，0：待审核，99：终审通过，其它为自定义） 
		/// </summary>
		public System.Int32 InfoStatus
		{
			get {return _infoStatus;}
			set {_infoStatus = value;}
		}
		private System.Int32 _elite = 0;
		/// <summary>
		/// 推荐级别 
		/// </summary>
		public System.Int32 Elite
		{
			get {return _elite;}
			set {_elite = value;}
		}
		private System.Int32 _priority = 0;
		/// <summary>
		/// 优先级别 
		/// </summary>
		public System.Int32 Priority
		{
			get {return _priority;}
			set {_priority = value;}
		}
		private System.Int32 _commentAudited = 0;
		/// <summary>
		/// 通过审核的评论总数 
		/// </summary>
		public System.Int32 CommentAudited
		{
			get {return _commentAudited;}
			set {_commentAudited = value;}
		}
		private System.Int32 _commentUnAudited = 0;
		/// <summary>
		/// 未通过审核的评论总数 
		/// </summary>
		public System.Int32 CommentUnAudited
		{
			get {return _commentUnAudited;}
			set {_commentUnAudited = value;}
		}
		private System.Int32 _signinType = 0;
		/// <summary>
		/// 签收类型 
		/// </summary>
		public System.Int32 SigninType
		{
			get {return _signinType;}
			set {_signinType = value;}
		}
		private DateTime? _inputTime = DateTime.MaxValue;
		/// <summary>
		/// 文章录入时间 
		/// </summary>
		public DateTime? InputTime
		{
			get {return _inputTime;}
			set {_inputTime = value;}
		}
		private DateTime? _passedTime = DateTime.MaxValue;
		/// <summary>
		/// 审核通过时间 
		/// </summary>
		public DateTime? PassedTime
		{
			get {return _passedTime;}
			set {_passedTime = value;}
		}
		private System.String _editor = string.Empty;
		/// <summary>
		/// 编辑 
		/// </summary>
		public System.String Editor
		{
			get {return _editor;}
			set {_editor = value;}
		}
		private DateTime? _lastHitTime = DateTime.MaxValue;
		/// <summary>
		/// 上次点击时间 
		/// </summary>
		public DateTime? LastHitTime
		{
			get {return _lastHitTime;}
			set {_lastHitTime = value;}
		}
		private System.String _defaultPicUrl = string.Empty;
		/// <summary>
		/// 默认首页图片 
		/// </summary>
		public System.String DefaultPicUrl
		{
			get {return _defaultPicUrl;}
			set {_defaultPicUrl = value;}
		}
		private System.String _pinyinTitle = string.Empty;
		/// <summary>
		/// 拼音标题 
		/// </summary>
		public System.String PinyinTitle
		{
			get {return _pinyinTitle;}
			set {_pinyinTitle = value;}
		}
		private System.String _titleFontColor = string.Empty;
		/// <summary>
		/// 标题字体颜色 
		/// </summary>
		public System.String TitleFontColor
		{
			get {return _titleFontColor;}
			set {_titleFontColor = value;}
		}
		private System.String _titleFontType = string.Empty;
		/// <summary>
		/// 标题字型 
		/// </summary>
		public System.String TitleFontType
		{
			get {return _titleFontType;}
			set {_titleFontType = value;}
		}
		private System.String _includePic = string.Empty;
		/// <summary>
		/// 标题前缀（1：[图文]，2：[组图]，3：[推荐]，4：[注意]） 
		/// </summary>
		public System.String IncludePic
		{
			get {return _includePic;}
			set {_includePic = value;}
		}
		private System.Boolean _isShowCommentLink = false;
		/// <summary>
		/// 列表显示时是否在标题旁显示“评论”链接 
		/// </summary>
		public System.Boolean IsShowCommentLink
		{
			get {return _isShowCommentLink;}
			set {_isShowCommentLink = value;}
		}
		private System.Decimal _titleHashKey = 0.0m;
		/// <summary>
		/// 标题的HASH值 
		/// </summary>
		public System.Decimal TitleHashKey
		{
			get {return _titleHashKey;}
			set {_titleHashKey = value;}
		}
		private System.String _seoTitle = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String SeoTitle
		{
			get {return _seoTitle;}
			set {_seoTitle = value;}
		}
		private System.String _seoKeyword = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String SeoKeyword
		{
			get {return _seoKeyword;}
			set {_seoKeyword = value;}
		}
		private System.String _seoDesc = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String SeoDesc
		{
			get {return _seoDesc;}
			set {_seoDesc = value;}
		}
		#endregion
	}
}
