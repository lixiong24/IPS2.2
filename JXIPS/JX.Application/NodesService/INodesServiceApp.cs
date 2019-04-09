using JX.Core;
using JX.Core.Entity;
using System.Collections.Generic;

namespace JX.Application
{
	/// <summary>
	/// 数据库表：NodesEntity 的应用层服务接口.
	/// </summary>
	public partial interface INodesServiceApp : IServiceApp<NodesEntity>
	{
		#region 得到实体类
		/// <summary>
		/// 获取节点信息，不包含扩展信息
		/// </summary>
		/// <param name="nodeId"></param>
		/// <returns></returns>
		NodesEntity GetNodeById(int nodeId);

		/// <summary>
		/// 从缓存中得到节点信息，不包含扩展信息
		/// </summary>
		/// <param name="nodeId"></param>
		/// <returns></returns>
		NodesEntity GetCacheNodeById(int nodeId);
		/// <summary>
		/// 按标识符获取节点，不包含扩展信息
		/// </summary>
		/// <param name="identifier"></param>
		/// <returns></returns>
		NodesEntity GetNodeByIdentifier(string identifier);
		/// <summary>
		/// 按子域名获取节点，不包含扩展信息
		/// </summary>
		/// <param name="subDomain"></param>
		/// <returns></returns>
		NodesEntity GetNodeBySubDomain(string subDomain);
		/// <summary>
		/// 通过指定ParentID下的，指定NodeID的对应节点信息
		/// </summary>
		/// <param name="parentId"></param>
		/// <param name="nodeId"></param>
		/// <returns></returns>
		NodesEntity GetParentNodeByNodeId(int parentId, int nodeId);
		/// <summary>
		/// 获取根节点信息，不包含扩展信息
		/// </summary>
		/// <param name="parentPath">父节点路径(0,1,2,3)</param>
		/// <returns></returns>
		NodesEntity GetRootNodeByParentPath(string parentPath);
		#endregion

		#region 得到实体类列表
		/// <summary>
		/// 获取所有的节点列表（包含容器栏目、专题栏目、单页节点和外链），并添加 '所有栏目'为根节点
		/// </summary>
		/// <param name="nodeType">节点类型</param>
		/// <param name="isShowArchiving">是否显示归档类型的节点</param>
		/// <param name="isAddAll">是否添加'所有栏目'为根节点</param>
		/// <returns></returns>
		IList<NodesEntity> GetNodeList(NodeType nodeType = NodeType.None, bool isShowArchiving = false, bool isAddAll = false);
		/// <summary>
		/// 获取节点列表包括归档节点
		/// </summary>
		/// <param name="nodesId">多个ID用“,”分割</param>
		/// <param name="isShowArchiving">是否显示归档节点</param>
		/// <returns></returns>
		IList<NodesEntity> GetNodeList(string nodesId, bool isShowArchiving = false);

		/// <summary>
		///  获取存档内容节点列表
		/// </summary>
		/// <param name="isShowArchiving"></param>
		/// <returns></returns>
		IList<NodesEntity> GetNodesListByArchiving(bool isShowArchiving);
		/// <summary>
		/// 获取所有节点类型为容器栏目的节点列表，并添加 '所有栏目'为根节点。
		/// </summary>
		/// <returns></returns>
		IList<NodesEntity> GetNodeListByContainer();
		/// <summary>
		/// 按父节点ID获取子节点列表
		/// </summary>
		/// <param name="parentId"></param>
		/// <returns></returns>
		IList<NodesEntity> GetNodesListByParentId(int parentId);
		/// <summary>
		/// 按根节点获取第一级子节点列表
		/// </summary>
		/// <param name="rootId"></param>
		/// <returns></returns>
		IList<NodesEntity> GetNodesListByRootId(int rootId);
		/// <summary>
		/// 获取指定节点ID集的节点列表
		/// </summary>
		/// <param name="arrChildId">多个ID用“,”分割</param>
		/// <returns></returns>
		IList<NodesEntity> GetNodesListInArrChildId(string arrChildId);
		/// <summary>
		/// 按父节点路径获取子节点列表，按Depth排序。
		/// </summary>
		/// <param name="parentPath">多个ID用“,”分割</param>
		/// <returns></returns>
		IList<NodesEntity> GetNodesListInParentPath(string parentPath);
		/// <summary>
		/// 获取指定用户组、指定权限码、可匿名访问的节点列表。
		/// 栏目权限。0--开放栏目  1--半开放栏目  2--认证栏目
		/// </summary>
		/// <param name="groupId">会员组ID</param>
		/// <param name="operateCode"></param>
		/// <returns></returns>
		IList<NodesEntity> GetAnonymousNodeId(int groupId, string operateCode);
		/// <summary>
		/// 获取所有绑定了内容模型的节点列表
		/// </summary>
		/// <returns></returns>
		IList<NodesEntity> GetContentNodeList();
		/// <summary>
		/// 获取所有绑定了商品模型的节点列表
		/// </summary>
		/// <returns></returns>
		IList<NodesEntity> GetShopNodeList();
		/// <summary>
		/// 按父节点获取商城节点列表
		/// </summary>
		/// <param name="parentId"></param>
		/// <returns></returns>
		IList<NodesEntity> GetShopNodeListByParentId(int parentId);

		/// <summary>
		/// 获取父节点下所有节点的下拉选择树
		/// </summary>
		/// <param name="parentID"></param>
		/// <returns></returns>
		IList<NodesEntity> GetNodeNameByParentID(int parentID);
		/// <summary>
		/// 获取节点类型为容器节点的下拉选择树
		/// </summary>
		/// <param name="isShowArchiving">是否显示归档节点</param>
		/// <returns></returns>
		IList<NodesEntity> GetNodeNameForContainerItems(bool isShowArchiving = false);
		/// <summary>
		/// 获取所有节点的下拉选择树（包含容器栏目、专题栏目、单页节点和外链）
		/// </summary>
		/// <returns></returns>
		IList<NodesEntity> GetNodeNameForItems();
		/// <summary>
		/// 获取所有节点的下拉选择树（不包含外链节点）
		/// </summary>
		/// <returns></returns>
		IList<NodesEntity> GetNodeNameForItemsExceptOutLinks();
		/// <summary>
		/// 获取内容节点下拉选择树
		/// </summary>
		/// <returns></returns>
		IList<NodesEntity> GetNodeNameForContent();
		/// <summary>
		/// 获取商城节点下拉选择树
		/// </summary>
		/// <returns></returns>
		IList<NodesEntity> GetNodeNameForShop();
		#endregion

		#region 是否存在数据
		/// <summary>
		///  判断同级节点下是否存在同名的节点目录
		/// </summary>
		/// <param name="parentId">父节点ID</param>
		/// <param name="nodeDir">目录名称</param>
		/// <returns></returns>
		bool ExistsNodeDir(int parentId, string nodeDir);
		/// <summary>
		///  判断同级节点下是否存在同名的节点标识
		/// </summary>
		/// <param name="parentId">父节点ID</param>
		/// <param name="nodeIdentifier">节点标识</param>
		/// <returns></returns>
		bool ExistsNodeIdentifier(int parentId, string nodeIdentifier);
		/// <summary>
		///  判断同级节点下是否存在同名的节点名称
		/// </summary>
		/// <param name="parentId">父节点ID</param>
		/// <param name="nodeName">节点名称</param>
		/// <returns></returns>
		bool ExistsNodeName(int parentId, string nodeName);
		/// <summary>
		/// 判断移动的节点是否包含目标节点
		/// </summary>
		/// <param name="targetNodeId">目标节点</param>
		/// <param name="arrChildId">子节点ID，多个ID用“,”分割</param>
		/// <returns></returns>
		bool ExistsTargetNodeIdInArrChildId(int targetNodeId, string arrChildId);
		#endregion

		#region 判断数据是否正确
		/// <summary>
		/// 判断指定的模板ID，是否为指定节点的默认模板ID
		/// </summary>
		/// <param name="nodeId"></param>
		/// <param name="templateId"></param>
		/// <returns></returns>
		bool GetDefaultTemplate(int nodeId, int templateId);
		#endregion

		#region 删除缓存
		/// <summary>
		/// 删除指定节点的缓存信息
		/// </summary>
		/// <param name="nodeId"></param>
		void RemoveCacheByNodeId(int nodeId);
		#endregion
	}
}