// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: CollectionPagingRulesEntity.cs
// 修改时间：2019/4/9 17:45:04
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：CollectionPagingRules 的实体类.
	/// </summary>
	public partial class CollectionPagingRulesEntity
	{
		#region Properties
		private System.Int32 _pagingRuleID = 0;
		/// <summary>
		/// 采集分页ID (主键)
		/// </summary>
		public System.Int32 PagingRuleID
		{
			get {return _pagingRuleID;}
			set {_pagingRuleID = value;}
		}
		private System.Int32 _itemID = 0;
		/// <summary>
		/// 采集项目ID 
		/// </summary>
		public System.Int32 ItemID
		{
			get {return _itemID;}
			set {_itemID = value;}
		}
		private System.Int32 _ruleType = 0;
		/// <summary>
		/// 规则类型，0为列表页的分页规则，1为字段的分页规则 
		/// </summary>
		public System.Int32 RuleType
		{
			get {return _ruleType;}
			set {_ruleType = value;}
		}
		private System.Int32 _pagingType = 0;
		/// <summary>
		/// 分页类型，1为“下一页”，2从源代码中获取分页URL，3为指定URL，4为手动添加 
		/// </summary>
		public System.Int32 PagingType
		{
			get {return _pagingType;}
			set {_pagingType = value;}
		}
		private System.String _pagingBeginCode = string.Empty;
		/// <summary>
		/// 分页开始代码 
		/// </summary>
		public System.String PagingBeginCode
		{
			get {return _pagingBeginCode;}
			set {_pagingBeginCode = value;}
		}
		private System.String _pagingEndCode = string.Empty;
		/// <summary>
		/// 分页结束代码 
		/// </summary>
		public System.String PagingEndCode
		{
			get {return _pagingEndCode;}
			set {_pagingEndCode = value;}
		}
		private System.String _linkBeginCode = string.Empty;
		/// <summary>
		/// 链接开始代码 
		/// </summary>
		public System.String LinkBeginCode
		{
			get {return _linkBeginCode;}
			set {_linkBeginCode = value;}
		}
		private System.String _linkEndCode = string.Empty;
		/// <summary>
		/// 链接结束代码 
		/// </summary>
		public System.String LinkEndCode
		{
			get {return _linkEndCode;}
			set {_linkEndCode = value;}
		}
		private System.String _designatedUrl = string.Empty;
		/// <summary>
		/// 指定URL地址 
		/// </summary>
		public System.String DesignatedUrl
		{
			get {return _designatedUrl;}
			set {_designatedUrl = value;}
		}
		private System.Int32 _scopeBegin = 0;
		/// <summary>
		/// 范围开始 
		/// </summary>
		public System.Int32 ScopeBegin
		{
			get {return _scopeBegin;}
			set {_scopeBegin = value;}
		}
		private System.Int32 _scopeEnd = 0;
		/// <summary>
		/// 范围结束 
		/// </summary>
		public System.Int32 ScopeEnd
		{
			get {return _scopeEnd;}
			set {_scopeEnd = value;}
		}
		private System.String _pagingUrlList = string.Empty;
		/// <summary>
		/// 手工指定分页URL列表 
		/// </summary>
		public System.String PagingUrlList
		{
			get {return _pagingUrlList;}
			set {_pagingUrlList = value;}
		}
		private System.Int32 _correlationRuleId = 0;
		/// <summary>
		/// 采集类别ID 列表 内容 
		/// </summary>
		public System.Int32 CorrelationRuleId
		{
			get {return _correlationRuleId;}
			set {_correlationRuleId = value;}
		}
		#endregion
	}
}
