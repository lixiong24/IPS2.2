// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: CollectionFieldRulesEntity.cs
// 修改时间：2019/4/9 17:45:04
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：CollectionFieldRules 的实体类.
	/// </summary>
	public partial class CollectionFieldRulesEntity
	{
		#region Properties
		private System.Int32 _fieldRuleID = 0;
		/// <summary>
		/// 字段规则ID (主键)
		/// </summary>
		public System.Int32 FieldRuleID
		{
			get {return _fieldRuleID;}
			set {_fieldRuleID = value;}
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
		private System.String _fieldName = string.Empty;
		/// <summary>
		/// 字段名称 
		/// </summary>
		public System.String FieldName
		{
			get {return _fieldName;}
			set {_fieldName = value;}
		}
		private System.String _fieldType = string.Empty;
		/// <summary>
		/// 字段类型 
		/// </summary>
		public System.String FieldType
		{
			get {return _fieldType;}
			set {_fieldType = value;}
		}
		private System.Int32 _ruleType = 0;
		/// <summary>
		/// 0:默认 1:指定 2:从HTML获取 
		/// </summary>
		public System.Int32 RuleType
		{
			get {return _ruleType;}
			set {_ruleType = value;}
		}
		private System.String _beginCode = string.Empty;
		/// <summary>
		/// 开始代码 
		/// </summary>
		public System.String BeginCode
		{
			get {return _beginCode;}
			set {_beginCode = value;}
		}
		private System.String _endCode = string.Empty;
		/// <summary>
		/// 结束代码 
		/// </summary>
		public System.String EndCode
		{
			get {return _endCode;}
			set {_endCode = value;}
		}
		private System.String _privateFilter = string.Empty;
		/// <summary>
		/// 过滤项目 
		/// </summary>
		public System.String PrivateFilter
		{
			get {return _privateFilter;}
			set {_privateFilter = value;}
		}
		private System.String _filterRuleID = string.Empty;
		/// <summary>
		/// 过滤规则ID 
		/// </summary>
		public System.String FilterRuleID
		{
			get {return _filterRuleID;}
			set {_filterRuleID = value;}
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
		private System.String _specialSetting = string.Empty;
		/// <summary>
		/// 特别设置 
		/// </summary>
		public System.String SpecialSetting
		{
			get {return _specialSetting;}
			set {_specialSetting = value;}
		}
		private System.Int32 _exclosionID = 0;
		/// <summary>
		/// 排除关联ID 
		/// </summary>
		public System.Int32 ExclosionID
		{
			get {return _exclosionID;}
			set {_exclosionID = value;}
		}
		#endregion
	}
}
