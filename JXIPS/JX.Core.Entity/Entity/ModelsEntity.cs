// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: ModelsEntity.cs
// 修改时间：2019/4/9 17:45:10
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Models 的实体类.
	/// </summary>
	public partial class ModelsEntity
	{
		#region Properties
		private System.Int32 _modelID = 0;
		/// <summary>
		/// 模型ID (主键)
		/// </summary>
		public System.Int32 ModelID
		{
			get {return _modelID;}
			set {_modelID = value;}
		}
		private System.String _modelName = string.Empty;
		/// <summary>
		/// 模型名称 
		/// </summary>
		public System.String ModelName
		{
			get {return _modelName;}
			set {_modelName = value;}
		}
		private System.Int32 _modelType = 0;
		/// <summary>
		/// 模型类型 
		/// </summary>
		public System.Int32 ModelType
		{
			get {return _modelType;}
			set {_modelType = value;}
		}
		private System.String _description = string.Empty;
		/// <summary>
		/// 模型描述 
		/// </summary>
		public System.String Description
		{
			get {return _description;}
			set {_description = value;}
		}
		private System.String _tableName = string.Empty;
		/// <summary>
		/// 模型关联的表名 
		/// </summary>
		public System.String TableName
		{
			get {return _tableName;}
			set {_tableName = value;}
		}
		private System.String _itemName = string.Empty;
		/// <summary>
		/// 项目名称：如文章、新闻、日志、信息 
		/// </summary>
		public System.String ItemName
		{
			get {return _itemName;}
			set {_itemName = value;}
		}
		private System.String _itemUnit = string.Empty;
		/// <summary>
		/// 项目单位：如篇、条、个 
		/// </summary>
		public System.String ItemUnit
		{
			get {return _itemUnit;}
			set {_itemUnit = value;}
		}
		private System.String _itemIcon = string.Empty;
		/// <summary>
		/// 模型图标 
		/// </summary>
		public System.String ItemIcon
		{
			get {return _itemIcon;}
			set {_itemIcon = value;}
		}
		private System.Boolean _isCountHits = false;
		/// <summary>
		/// 是否统计点击数 
		/// </summary>
		public System.Boolean IsCountHits
		{
			get {return _isCountHits;}
			set {_isCountHits = value;}
		}
		private System.Boolean _isDisabled = false;
		/// <summary>
		/// 是否禁用 
		/// </summary>
		public System.Boolean IsDisabled
		{
			get {return _isDisabled;}
			set {_isDisabled = value;}
		}
		private System.String _field = string.Empty;
		/// <summary>
		/// 字段对象 
		/// </summary>
		public System.String Field
		{
			get {return _field;}
			set {_field = value;}
		}
		private System.String _defaultTemplateFile = string.Empty;
		/// <summary>
		/// 内容页模板路径 
		/// </summary>
		public System.String DefaultTemplateFile
		{
			get {return _defaultTemplateFile;}
			set {_defaultTemplateFile = value;}
		}
		private System.Boolean _isEnableCharge = false;
		/// <summary>
		/// 是否启用收费功能 
		/// </summary>
		public System.Boolean IsEnableCharge
		{
			get {return _isEnableCharge;}
			set {_isEnableCharge = value;}
		}
		private System.Boolean _isEnableSignin = false;
		/// <summary>
		/// 是否启用签收功能 
		/// </summary>
		public System.Boolean IsEnableSignin
		{
			get {return _isEnableSignin;}
			set {_isEnableSignin = value;}
		}
		private System.String _addInfoFilePath = string.Empty;
		/// <summary>
		/// 添加程序页面路径 
		/// </summary>
		public System.String AddInfoFilePath
		{
			get {return _addInfoFilePath;}
			set {_addInfoFilePath = value;}
		}
		private System.String _manageInfoFilePath = string.Empty;
		/// <summary>
		/// 管理程序页面路径 
		/// </summary>
		public System.String ManageInfoFilePath
		{
			get {return _manageInfoFilePath;}
			set {_manageInfoFilePath = value;}
		}
		private System.String _previewInfoFilePath = string.Empty;
		/// <summary>
		/// 预览程序页面路径 
		/// </summary>
		public System.String PreviewInfoFilePath
		{
			get {return _previewInfoFilePath;}
			set {_previewInfoFilePath = value;}
		}
		private System.String _batchInfoFilePath = string.Empty;
		/// <summary>
		/// 批量程序页面路径 
		/// </summary>
		public System.String BatchInfoFilePath
		{
			get {return _batchInfoFilePath;}
			set {_batchInfoFilePath = value;}
		}
		private System.Int32 _character = 0;
		/// <summary>
		/// 商品性质 
		/// </summary>
		public System.Int32 Character
		{
			get {return _character;}
			set {_character = value;}
		}
		private System.Int32 _maxPerUser = 0;
		/// <summary>
		/// 每个用户可以在此内容模型下发表多少篇内容 
		/// </summary>
		public System.Int32 MaxPerUser
		{
			get {return _maxPerUser;}
			set {_maxPerUser = value;}
		}
		private System.String _printTemplate = string.Empty;
		/// <summary>
		/// 打印页模板 
		/// </summary>
		public System.String PrintTemplate
		{
			get {return _printTemplate;}
			set {_printTemplate = value;}
		}
		private System.Boolean _isEnableVote = false;
		/// <summary>
		/// 是否允许投票 
		/// </summary>
		public System.Boolean IsEnableVote
		{
			get {return _isEnableVote;}
			set {_isEnableVote = value;}
		}
		private System.String _searchTemplate = string.Empty;
		/// <summary>
		/// 搜索页模板 
		/// </summary>
		public System.String SearchTemplate
		{
			get {return _searchTemplate;}
			set {_searchTemplate = value;}
		}
		private System.String _advanceSearchFormTemplate = string.Empty;
		/// <summary>
		/// 高级搜索表单模板 
		/// </summary>
		public System.String AdvanceSearchFormTemplate
		{
			get {return _advanceSearchFormTemplate;}
			set {_advanceSearchFormTemplate = value;}
		}
		private System.String _advanceSearchTemplate = string.Empty;
		/// <summary>
		/// 高级搜索结果模板 
		/// </summary>
		public System.String AdvanceSearchTemplate
		{
			get {return _advanceSearchTemplate;}
			set {_advanceSearchTemplate = value;}
		}
		private System.String _chargeTips = string.Empty;
		/// <summary>
		/// 生成静态页时模型收费提示 
		/// </summary>
		public System.String ChargeTips
		{
			get {return _chargeTips;}
			set {_chargeTips = value;}
		}
		private System.String _needPointChargeTips = string.Empty;
		/// <summary>
		/// 模型收费提示 
		/// </summary>
		public System.String NeedPointChargeTips
		{
			get {return _needPointChargeTips;}
			set {_needPointChargeTips = value;}
		}
		private System.String _outTimeChargeTips = string.Empty;
		/// <summary>
		/// 模型收费提示 
		/// </summary>
		public System.String OutTimeChargeTips
		{
			get {return _outTimeChargeTips;}
			set {_outTimeChargeTips = value;}
		}
		private System.String _usePointChargeTips = string.Empty;
		/// <summary>
		/// 模型收费提示 
		/// </summary>
		public System.String UsePointChargeTips
		{
			get {return _usePointChargeTips;}
			set {_usePointChargeTips = value;}
		}
		private System.String _commentManageTemplate = string.Empty;
		/// <summary>
		/// 评论页模板 
		/// </summary>
		public System.String CommentManageTemplate
		{
			get {return _commentManageTemplate;}
			set {_commentManageTemplate = value;}
		}
		private System.String _anonymouseTemplate = string.Empty;
		/// <summary>
		/// 匿名投稿模板 
		/// </summary>
		public System.String AnonymouseTemplate
		{
			get {return _anonymouseTemplate;}
			set {_anonymouseTemplate = value;}
		}
		private System.String _userAddContentTemplate = string.Empty;
		/// <summary>
		/// 用户添加信息模板 
		/// </summary>
		public System.String UserAddContentTemplate
		{
			get {return _userAddContentTemplate;}
			set {_userAddContentTemplate = value;}
		}
		private System.Boolean _isVerificationCode = false;
		/// <summary>
		/// 验证码 
		/// </summary>
		public System.Boolean IsVerificationCode
		{
			get {return _isVerificationCode;}
			set {_isVerificationCode = value;}
		}
		private System.Boolean _isParentChild = false;
		/// <summary>
		/// 是否子母表模型 
		/// </summary>
		public System.Boolean IsParentChild
		{
			get {return _isParentChild;}
			set {_isParentChild = value;}
		}
		#endregion
	}
}
