// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: WordReplaceItemEntity.cs
// 修改时间：2019/4/9 17:45:15
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：WordReplaceItem 的实体类.
	/// </summary>
	public partial class WordReplaceItemEntity
	{
		#region Properties
		private System.Int32 _itemID = 0;
		/// <summary>
		/// 字符替换Id (主键)
		/// </summary>
		public System.Int32 ItemID
		{
			get {return _itemID;}
			set {_itemID = value;}
		}
		private System.String _sourceWord = string.Empty;
		/// <summary>
		/// 字符替换目标 
		/// </summary>
		public System.String SourceWord
		{
			get {return _sourceWord;}
			set {_sourceWord = value;}
		}
		private System.String _targetWord = string.Empty;
		/// <summary>
		/// 字符替换替换后地址 
		/// </summary>
		public System.String TargetWord
		{
			get {return _targetWord;}
			set {_targetWord = value;}
		}
		private System.Int32 _replaceType = 0;
		/// <summary>
		/// 字符替换类型 
		/// </summary>
		public System.Int32 ReplaceType
		{
			get {return _replaceType;}
			set {_replaceType = value;}
		}
		private System.Int32 _scopesType = 0;
		/// <summary>
		/// 过滤字符替换类型 
		/// </summary>
		public System.Int32 ScopesType
		{
			get {return _scopesType;}
			set {_scopesType = value;}
		}
		private System.Int32 _replaceTimes = 0;
		/// <summary>
		/// 字符替换替换次数 
		/// </summary>
		public System.Int32 ReplaceTimes
		{
			get {return _replaceTimes;}
			set {_replaceTimes = value;}
		}
		private System.Int32 _priority = 0;
		/// <summary>
		/// 字符替换优先级 
		/// </summary>
		public System.Int32 Priority
		{
			get {return _priority;}
			set {_priority = value;}
		}
		private System.Boolean _isNewOpen = false;
		/// <summary>
		/// 字符替换打开模式 
		/// </summary>
		public System.Boolean IsNewOpen
		{
			get {return _isNewOpen;}
			set {_isNewOpen = value;}
		}
		private System.Boolean _isEnabled = false;
		/// <summary>
		/// 字符替换是否启用 
		/// </summary>
		public System.Boolean IsEnabled
		{
			get {return _isEnabled;}
			set {_isEnabled = value;}
		}
		private System.String _title = string.Empty;
		/// <summary>
		/// 字符替换后元素的Title属性 
		/// </summary>
		public System.String Title
		{
			get {return _title;}
			set {_title = value;}
		}
		#endregion
	}
}
