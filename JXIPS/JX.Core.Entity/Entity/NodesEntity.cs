// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: NodesEntity.cs
// 修改时间：2019/4/9 17:45:10
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Nodes 的实体类.
	/// </summary>
	public partial class NodesEntity
	{
		#region Properties
		private System.Int32 _nodeID = 0;
		/// <summary>
		/// 节点ID (主键)
		/// </summary>
		public System.Int32 NodeID
		{
			get {return _nodeID;}
			set {_nodeID = value;}
		}
		private System.String _nodeIdentifier = string.Empty;
		/// <summary>
		/// 节点标识符，用于前台调用时可以直接用标识符取代ID。 
		/// </summary>
		public System.String NodeIdentifier
		{
			get {return _nodeIdentifier;}
			set {_nodeIdentifier = value;}
		}
		private System.Int32 _nodeType = 0;
		/// <summary>
		/// 节点类型。0为容器栏目，1为专题栏目，2为单个页面，3为外部链接 
		/// </summary>
		public System.Int32 NodeType
		{
			get {return _nodeType;}
			set {_nodeType = value;}
		}
		private System.Int32 _parentID = 0;
		/// <summary>
		/// 父节点ID，根节点的值为0 
		/// </summary>
		public System.Int32 ParentID
		{
			get {return _parentID;}
			set {_parentID = value;}
		}
		private System.String _parentPath = string.Empty;
		/// <summary>
		/// 父路径，根节点的值为0，子节点的值为：0,1,6,76 
		/// </summary>
		public System.String ParentPath
		{
			get {return _parentPath;}
			set {_parentPath = value;}
		}
		private System.Int32 _depth = 0;
		/// <summary>
		/// 节点树的深度，根节点的值为0，子节点的值为该节点所在的层数 
		/// </summary>
		public System.Int32 Depth
		{
			get {return _depth;}
			set {_depth = value;}
		}
		private System.Int32 _rootID = 0;
		/// <summary>
		/// 根节点排序ID。根节点使用RootID进行排序，同时子节点与根节点的RootID相等。 
		/// </summary>
		public System.Int32 RootID
		{
			get {return _rootID;}
			set {_rootID = value;}
		}
		private System.Int32 _child = 0;
		/// <summary>
		/// 子节点数 
		/// </summary>
		public System.Int32 Child
		{
			get {return _child;}
			set {_child = value;}
		}
		private System.String _arrChildID = string.Empty;
		/// <summary>
		/// 所有子节点的ID数组 
		/// </summary>
		public System.String ArrChildID
		{
			get {return _arrChildID;}
			set {_arrChildID = value;}
		}
		private System.Int32 _prevID = 0;
		/// <summary>
		/// 同级节点的上一个节点ID 
		/// </summary>
		public System.Int32 PrevID
		{
			get {return _prevID;}
			set {_prevID = value;}
		}
		private System.Int32 _nextID = 0;
		/// <summary>
		/// 同级节点的下一个节点ID 
		/// </summary>
		public System.Int32 NextID
		{
			get {return _nextID;}
			set {_nextID = value;}
		}
		private System.Int32 _orderSort = 0;
		/// <summary>
		/// 排序ID 
		/// </summary>
		public System.Int32 OrderSort
		{
			get {return _orderSort;}
			set {_orderSort = value;}
		}
		private System.String _nodeDir = string.Empty;
		/// <summary>
		/// 节点目录，只能是英文字母和数字，并且要以字母开头。 
		/// </summary>
		public System.String NodeDir
		{
			get {return _nodeDir;}
			set {_nodeDir = value;}
		}
		private System.String _parentDir = string.Empty;
		/// <summary>
		/// 父目录，系统自动根据树形目录算出来的目录路径 
		/// </summary>
		public System.String ParentDir
		{
			get {return _parentDir;}
			set {_parentDir = value;}
		}
		private System.String _nodeName = string.Empty;
		/// <summary>
		/// 节点名称 
		/// </summary>
		public System.String NodeName
		{
			get {return _nodeName;}
			set {_nodeName = value;}
		}
		private System.String _tips = string.Empty;
		/// <summary>
		/// 节点提示，不支持HTML 
		/// </summary>
		public System.String Tips
		{
			get {return _tips;}
			set {_tips = value;}
		}
		private System.String _description = string.Empty;
		/// <summary>
		/// 节点说明，支持HTML 
		/// </summary>
		public System.String Description
		{
			get {return _description;}
			set {_description = value;}
		}
		private System.String _nodePicUrl = string.Empty;
		/// <summary>
		/// 图片地址 
		/// </summary>
		public System.String NodePicUrl
		{
			get {return _nodePicUrl;}
			set {_nodePicUrl = value;}
		}
		private System.String _meta_Keywords = string.Empty;
		/// <summary>
		/// 针对搜索引擎的关键字 
		/// </summary>
		public System.String Meta_Keywords
		{
			get {return _meta_Keywords;}
			set {_meta_Keywords = value;}
		}
		private System.String _meta_Description = string.Empty;
		/// <summary>
		/// 针对搜索引擎的说明 
		/// </summary>
		public System.String Meta_Description
		{
			get {return _meta_Description;}
			set {_meta_Description = value;}
		}
		private System.Boolean _isShowOnMenu = false;
		/// <summary>
		/// 是否在顶部菜单处显示 
		/// </summary>
		public System.Boolean IsShowOnMenu
		{
			get {return _isShowOnMenu;}
			set {_isShowOnMenu = value;}
		}
		private System.Boolean _isShowOnPath = false;
		/// <summary>
		/// 是否位置导航处显示 
		/// </summary>
		public System.Boolean IsShowOnPath
		{
			get {return _isShowOnPath;}
			set {_isShowOnPath = value;}
		}
		private System.Boolean _isShowOnMap = false;
		/// <summary>
		/// 是否在网站地图（栏目导航）处显示 
		/// </summary>
		public System.Boolean IsShowOnMap
		{
			get {return _isShowOnMap;}
			set {_isShowOnMap = value;}
		}
		private System.Boolean _isShowOnList_Index = false;
		/// <summary>
		/// 是否在首页的分类列表处显示 
		/// </summary>
		public System.Boolean IsShowOnList_Index
		{
			get {return _isShowOnList_Index;}
			set {_isShowOnList_Index = value;}
		}
		private System.Boolean _isShowOnList_Parent = false;
		/// <summary>
		/// 是否在父栏目的分类列表处显示 
		/// </summary>
		public System.Boolean IsShowOnList_Parent
		{
			get {return _isShowOnList_Parent;}
			set {_isShowOnList_Parent = value;}
		}
		private System.Int32 _purviewType = 0;
		/// <summary>
		/// 栏目权限。0--开放栏目  1--半开放栏目  2--认证栏目 
		/// </summary>
		public System.Int32 PurviewType
		{
			get {return _purviewType;}
			set {_purviewType = value;}
		}
		private System.String _creater = string.Empty;
		/// <summary>
		/// 栏目创建者 
		/// </summary>
		public System.String Creater
		{
			get {return _creater;}
			set {_creater = value;}
		}
		private System.Int32 _inheritPurviewFromParent = 0;
		/// <summary>
		/// 从父栏目继承权限设置。 
		/// </summary>
		public System.Int32 InheritPurviewFromParent
		{
			get {return _inheritPurviewFromParent;}
			set {_inheritPurviewFromParent = value;}
		}
		private System.Int32 _workFlowID = 0;
		/// <summary>
		/// 工作流程ID 
		/// </summary>
		public System.Int32 WorkFlowID
		{
			get {return _workFlowID;}
			set {_workFlowID = value;}
		}
		private System.Int32 _hitsOfHot = 0;
		/// <summary>
		/// 本栏目热点的点击数最小值 
		/// </summary>
		public System.Int32 HitsOfHot
		{
			get {return _hitsOfHot;}
			set {_hitsOfHot = value;}
		}
		private System.Int32 _leastOfEliteLevel = 0;
		/// <summary>
		/// 本栏目推荐的 
		/// </summary>
		public System.Int32 LeastOfEliteLevel
		{
			get {return _leastOfEliteLevel;}
			set {_leastOfEliteLevel = value;}
		}
		private System.Int32 _openType = 0;
		/// <summary>
		/// 此节点的打开方式( 0--原窗口  1--新窗口) 
		/// </summary>
		public System.Int32 OpenType
		{
			get {return _openType;}
			set {_openType = value;}
		}
		private System.Int32 _itemCount = 0;
		/// <summary>
		/// 项目数 
		/// </summary>
		public System.Int32 ItemCount
		{
			get {return _itemCount;}
			set {_itemCount = value;}
		}
		private System.Int32 _itemChecked = 0;
		/// <summary>
		/// 审核项目数 
		/// </summary>
		public System.Int32 ItemChecked
		{
			get {return _itemChecked;}
			set {_itemChecked = value;}
		}
		private System.Int32 _commentCount = 0;
		/// <summary>
		/// 评论数 
		/// </summary>
		public System.Int32 CommentCount
		{
			get {return _commentCount;}
			set {_commentCount = value;}
		}
		private System.String _custom_Content = string.Empty;
		/// <summary>
		/// 自设内容 
		/// </summary>
		public System.String Custom_Content
		{
			get {return _custom_Content;}
			set {_custom_Content = value;}
		}
		private System.Boolean _isCreateListPage = false;
		/// <summary>
		/// 列表页生成方式 0不生成，1生成 
		/// </summary>
		public System.Boolean IsCreateListPage
		{
			get {return _isCreateListPage;}
			set {_isCreateListPage = value;}
		}
		private System.Boolean _isCreateContentPage = false;
		/// <summary>
		/// 内容页生成方式 0不生成，1生成 
		/// </summary>
		public System.Boolean IsCreateContentPage
		{
			get {return _isCreateContentPage;}
			set {_isCreateContentPage = value;}
		}
		private System.Int32 _autoCreateHtmlType = 0;
		/// <summary>
		/// 自动生成Html类型 
		/// </summary>
		public System.Int32 AutoCreateHtmlType
		{
			get {return _autoCreateHtmlType;}
			set {_autoCreateHtmlType = value;}
		}
		private System.String _contentPageHtmlRule = string.Empty;
		/// <summary>
		/// 内容页的文件名规则 
		/// </summary>
		public System.String ContentPageHtmlRule
		{
			get {return _contentPageHtmlRule;}
			set {_contentPageHtmlRule = value;}
		}
		private System.String _listPageHtmlRule = string.Empty;
		/// <summary>
		/// 列表页的文件名规则 
		/// </summary>
		public System.String ListPageHtmlRule
		{
			get {return _listPageHtmlRule;}
			set {_listPageHtmlRule = value;}
		}
		private System.String _itemAspxFileName = string.Empty;
		/// <summary>
		/// 动态方式的内容页文件名 
		/// </summary>
		public System.String ItemAspxFileName
		{
			get {return _itemAspxFileName;}
			set {_itemAspxFileName = value;}
		}
		private System.String _relateNode = string.Empty;
		/// <summary>
		/// 关联节点 
		/// </summary>
		public System.String RelateNode
		{
			get {return _relateNode;}
			set {_relateNode = value;}
		}
		private System.String _relateSpecial = string.Empty;
		/// <summary>
		/// 关联专题 
		/// </summary>
		public System.String RelateSpecial
		{
			get {return _relateSpecial;}
			set {_relateSpecial = value;}
		}
		private System.String _defaultTemplateFile = string.Empty;
		/// <summary>
		/// 此节点的默认首页模板 
		/// </summary>
		public System.String DefaultTemplateFile
		{
			get {return _defaultTemplateFile;}
			set {_defaultTemplateFile = value;}
		}
		private System.String _containChildTemplateFile = string.Empty;
		/// <summary>
		/// 列表页模板 
		/// </summary>
		public System.String ContainChildTemplateFile
		{
			get {return _containChildTemplateFile;}
			set {_containChildTemplateFile = value;}
		}
		private System.Int32 _itemOpenType = 0;
		/// <summary>
		/// 此节点下项目的打开方式 ( 0--原窗口  1--新窗口) 
		/// </summary>
		public System.Int32 ItemOpenType
		{
			get {return _itemOpenType;}
			set {_itemOpenType = value;}
		}
		private System.Int32 _itemListOrderType = 0;
		/// <summary>
		/// 此节点下项目列表的排序方式 
		/// </summary>
		public System.Int32 ItemListOrderType
		{
			get {return _itemListOrderType;}
			set {_itemListOrderType = value;}
		}
		private System.Int32 _itemPageSize = 0;
		/// <summary>
		/// 节点下内容每页分页数 
		/// </summary>
		public System.Int32 ItemPageSize
		{
			get {return _itemPageSize;}
			set {_itemPageSize = value;}
		}
		private System.String _upLoadDirRule = string.Empty;
		/// <summary>
		/// 上传文件路径规则 
		/// </summary>
		public System.String UpLoadDirRule
		{
			get {return _upLoadDirRule;}
			set {_upLoadDirRule = value;}
		}
		private System.String _linkUrl = string.Empty;
		/// <summary>
		/// 外部链接地址 
		/// </summary>
		public System.String LinkUrl
		{
			get {return _linkUrl;}
			set {_linkUrl = value;}
		}
		private System.String _settings = string.Empty;
		/// <summary>
		/// 节点设置，使用XML保存配置 
		/// </summary>
		public System.String Settings
		{
			get {return _settings;}
			set {_settings = value;}
		}
		private System.String _iPLock = string.Empty;
		/// <summary>
		/// 节点IP设置，使用XML保存配置 
		/// </summary>
		public System.String IPLock
		{
			get {return _iPLock;}
			set {_iPLock = value;}
		}
		private System.String _listPagePostFix = string.Empty;
		/// <summary>
		/// 列表页后缀 
		/// </summary>
		public System.String ListPagePostFix
		{
			get {return _listPagePostFix;}
			set {_listPagePostFix = value;}
		}
		private System.Int32 _listPageSavePathType = 0;
		/// <summary>
		/// 列表页生成类型 
		/// </summary>
		public System.Int32 ListPageSavePathType
		{
			get {return _listPageSavePathType;}
			set {_listPageSavePathType = value;}
		}
		private System.Boolean _isNeedCreateHtml = false;
		/// <summary>
		/// 节点下是否有需要生成HTML的内容 
		/// </summary>
		public System.Boolean IsNeedCreateHtml
		{
			get {return _isNeedCreateHtml;}
			set {_isNeedCreateHtml = value;}
		}
		private System.String _cultureName = string.Empty;
		/// <summary>
		/// 文化名(语言种类) 
		/// </summary>
		public System.String CultureName
		{
			get {return _cultureName;}
			set {_cultureName = value;}
		}
		private System.Boolean _isSubDomain = false;
		/// <summary>
		/// 是否开启子域名 
		/// </summary>
		public System.Boolean IsSubDomain
		{
			get {return _isSubDomain;}
			set {_isSubDomain = value;}
		}
		private System.String _subDomain = string.Empty;
		/// <summary>
		/// 子域名 
		/// </summary>
		public System.String SubDomain
		{
			get {return _subDomain;}
			set {_subDomain = value;}
		}
		#endregion
	}
}
