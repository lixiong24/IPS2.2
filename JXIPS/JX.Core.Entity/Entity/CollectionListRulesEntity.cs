// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: CollectionListRulesEntity.cs
// 修改时间：2019/4/9 17:45:04
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：CollectionListRules 的实体类.
	/// </summary>
	public partial class CollectionListRulesEntity
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
		private System.String _listBeginCode = string.Empty;
		/// <summary>
		/// 列表开始代码 
		/// </summary>
		public System.String ListBeginCode
		{
			get {return _listBeginCode;}
			set {_listBeginCode = value;}
		}
		private System.String _listEndCode = string.Empty;
		/// <summary>
		/// 列表结束代码 
		/// </summary>
		public System.String ListEndCode
		{
			get {return _listEndCode;}
			set {_listEndCode = value;}
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
		private System.Boolean _isLinkSpecialSolution = false;
		/// <summary>
		/// 是否链接特殊处理 
		/// </summary>
		public System.Boolean IsLinkSpecialSolution
		{
			get {return _isLinkSpecialSolution;}
			set {_isLinkSpecialSolution = value;}
		}
		private System.String _redirectUrl = string.Empty;
		/// <summary>
		/// 重定向URL 
		/// </summary>
		public System.String RedirectUrl
		{
			get {return _redirectUrl;}
			set {_redirectUrl = value;}
		}
		private System.Boolean _isUsePaging = false;
		/// <summary>
		/// 是否采集分页 
		/// </summary>
		public System.Boolean IsUsePaging
		{
			get {return _isUsePaging;}
			set {_isUsePaging = value;}
		}
		#endregion
	}
}
