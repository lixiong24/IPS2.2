// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: CollectionFilterRulesEntity.cs
// 修改时间：2019/4/9 17:45:04
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：CollectionFilterRules 的实体类.
	/// </summary>
	public partial class CollectionFilterRulesEntity
	{
		#region Properties
		private System.Int32 _filterRuleID = 0;
		/// <summary>
		/// 过滤规则ID (主键)
		/// </summary>
		public System.Int32 FilterRuleID
		{
			get {return _filterRuleID;}
			set {_filterRuleID = value;}
		}
		private System.String _filterName = string.Empty;
		/// <summary>
		/// 过滤规则名称 
		/// </summary>
		public System.String FilterName
		{
			get {return _filterName;}
			set {_filterName = value;}
		}
		private System.Int32 _filterType = 0;
		/// <summary>
		/// 过滤类型(1:普通替换　2:截取替换  3:正则过滤) 
		/// </summary>
		public System.Int32 FilterType
		{
			get {return _filterType;}
			set {_filterType = value;}
		}
		private System.String _beginCode = string.Empty;
		/// <summary>
		/// 过滤开始代码 
		/// </summary>
		public System.String BeginCode
		{
			get {return _beginCode;}
			set {_beginCode = value;}
		}
		private System.String _endCode = string.Empty;
		/// <summary>
		/// 过滤结束代码 
		/// </summary>
		public System.String EndCode
		{
			get {return _endCode;}
			set {_endCode = value;}
		}
		private System.String _replace = string.Empty;
		/// <summary>
		/// 替换值 
		/// </summary>
		public System.String Replace
		{
			get {return _replace;}
			set {_replace = value;}
		}
		#endregion
	}
}
