using JX.Core;
using JX.Core.Entity;
using JX.Infrastructure.Common;
using JX.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace JX.Application
{
	/// <summary>
	/// 数据库表：NodesEntity 的应用层服务接口实现类.
	/// </summary>
	public partial class NodesServiceApp : INodesServiceApp
	{
		#region 仓储接口
		private readonly INodesTemplateRepository _NodesTemplateRepository;
		private readonly ILogRepository _LogRepository;
		/// <summary>
		/// 构造器注入
		/// </summary>
		/// <param name="repository"></param>
		/// <param name="nodesTemplateRepository"></param>
		/// <param name="logRepository"></param>
		public NodesServiceApp(INodesRepository repository,
			INodesTemplateRepository nodesTemplateRepository,
			ILogRepository logRepository)
		{
			_repository = repository;
			_NodesTemplateRepository = nodesTemplateRepository;
			_LogRepository = logRepository;
		}
		#endregion

		#region 得到实体类
		/// <summary>
		/// 获取节点信息，不包含扩展信息
		/// </summary>
		/// <param name="nodeId"></param>
		/// <returns></returns>
		public NodesEntity GetNodeById(int nodeId)
		{
			if ((nodeId != -2) && (nodeId <= 0))
			{
				return new NodesEntity();
			}
			var entity = _repository.Get(p=>p.NodeID==nodeId);
			return entity;
		}
		/// <summary>
		/// 从缓存中得到节点信息，不包含扩展信息
		/// </summary>
		/// <param name="nodeId"></param>
		/// <returns></returns>
		public NodesEntity GetCacheNodeById(int nodeId)
		{
			if ((nodeId != -2) && (nodeId <= 0))
			{
				return new NodesEntity();
			}
			string key = "CK_Content_NodeInfo_NodeId_" + nodeId.ToString();
			var nodeById = CacheHelper.CacheServiceProvider.Get<NodesEntity>(key);
			if (nodeById == null)
			{
				nodeById = GetNodeById(nodeId);
				CacheHelper.CacheServiceProvider.AddOrUpdate(key, nodeById);
			}
			return nodeById;
		}
		/// <summary>
		/// 按标识符获取节点，不包含扩展信息
		/// </summary>
		/// <param name="identifier"></param>
		/// <returns></returns>
		public NodesEntity GetNodeByIdentifier(string identifier)
		{
			if (string.IsNullOrEmpty(identifier))
			{
				return new NodesEntity();
			}
			var entity = _repository.Get(p => p.NodeIdentifier == identifier);
			return entity;
		}
		/// <summary>
		/// 按子域名获取节点，不包含扩展信息
		/// </summary>
		/// <param name="subDomain"></param>
		/// <returns></returns>
		public NodesEntity GetNodeBySubDomain(string subDomain)
		{
			if (string.IsNullOrEmpty(subDomain))
			{
				return new NodesEntity();
			}
			var entity = _repository.Get(p => p.SubDomain == subDomain);
			return entity;
		}
		/// <summary>
		/// 通过指定ParentID下的，指定NodeID的对应节点信息
		/// </summary>
		/// <param name="parentId"></param>
		/// <param name="nodeId"></param>
		/// <returns></returns>
		public NodesEntity GetParentNodeByNodeId(int parentId, int nodeId)
		{
			var entity = _repository.Get(p => p.ParentID == parentId && p.NodeID==nodeId);
			return entity;
		}
		/// <summary>
		/// 获取根节点信息，不包含扩展信息
		/// </summary>
		/// <param name="parentPath">父节点路径(0,1,2,3)</param>
		/// <returns></returns>
		public NodesEntity GetRootNodeByParentPath(string parentPath)
		{
			if (!string.IsNullOrEmpty(parentPath))
			{
				string[] strArray = parentPath.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < strArray.Length; i++)
				{
					int nodeId = DataConverter.CLng(strArray[i]);
					if (nodeId > 0)
					{
						NodesEntity cacheNodeById = GetCacheNodeById(nodeId);
						if (cacheNodeById.ParentID == 0)
						{
							return cacheNodeById;
						}
					}
				}
			}
			return new NodesEntity();
		}
		#endregion

		#region 得到实体类列表
		/// <summary>
		/// 获取所有的节点列表（包含容器栏目、专题栏目、单页节点和外链），并添加 '所有栏目'为根节点
		/// </summary>
		/// <param name="nodeType">节点类型</param>
		/// <param name="isShowArchiving">是否显示归档类型的节点</param>
		/// <param name="isAddAll">是否添加'所有栏目'为根节点</param>
		/// <returns></returns>
		public IList<NodesEntity> GetNodeList(NodeType nodeType = NodeType.None, bool isShowArchiving = false, bool isAddAll = false)
		{
			Expression<Func<NodesEntity, bool>> predicate = p => true;
			if (nodeType != NodeType.None)
			{
				predicate = predicate.And(p => p.NodeType == (int)nodeType);
			}
			if (!isShowArchiving)
			{
				predicate = predicate.And(p => p.PurviewType != 3);
			}
			SortModelField sortModelField1 = new SortModelField() { SortName = "RootID", IsDESC = false };
			SortModelField sortModelField2 = new SortModelField() { SortName = "OrderSort", IsDESC = false };
			SortModelField[] orderByExpression = new SortModelField[2];
			orderByExpression[0] = sortModelField1;
			orderByExpression[1] = sortModelField2;
			IList<NodesEntity> nodesList = LoadListAll(predicate, orderByExpression);
			if (isAddAll)
			{
				NodesEntity item = new NodesEntity();
				item.NodeName = "所有栏目";
				item.NodeID = -1;
				item.Depth = 0;
				item.ParentPath = "0";
				item.NextID = 0;
				item.Child = 0;
				item.NodeType = (int)(NodeType.Container);
				item.NodeDir = "";
				nodesList.Insert(0, item);
			}
			return nodesList;
		}
		/// <summary>
		/// 获取节点列表包括归档节点
		/// </summary>
		/// <param name="nodesId">多个ID用“,”分割</param>
		/// <param name="isShowArchiving">是否显示归档节点</param>
		/// <returns></returns>
		public IList<NodesEntity> GetNodeList(string nodesId, bool isShowArchiving = false)
		{
			if (!DataValidator.IsValidId(nodesId))
			{
				return new List<NodesEntity>();
			}
			Expression<Func<NodesEntity, bool>> predicate = p => true;
			if (!string.IsNullOrEmpty(nodesId))
			{
				var arrNodeID = nodesId.Split(',');
				predicate = predicate.And(p => arrNodeID.Contains(p.NodeID.ToString()));
			}
			if (!isShowArchiving)
			{
				predicate = predicate.And(p => p.PurviewType != 3);
			}
			SortModelField sortModelField1 = new SortModelField() { SortName = "RootID", IsDESC = false };
			SortModelField sortModelField2 = new SortModelField() { SortName = "OrderSort", IsDESC = false };
			SortModelField[] orderByExpression = new SortModelField[2];
			orderByExpression[0] = sortModelField1;
			orderByExpression[1] = sortModelField2;
			IList<NodesEntity> nodesList = LoadListAll(predicate, orderByExpression);
			return nodesList;
		}

		/// <summary>
		///  获取存档内容节点列表
		/// </summary>
		/// <param name="isShowArchiving"></param>
		/// <returns></returns>
		public IList<NodesEntity> GetNodesListByArchiving(bool isShowArchiving)
		{
			return GetNodeList(NodeType.None, isShowArchiving, false);
		}
		/// <summary>
		/// 获取所有节点类型为容器栏目的节点列表，并添加 '所有栏目'为根节点。
		/// </summary>
		/// <returns></returns>
		public IList<NodesEntity> GetNodeListByContainer()
		{
			return GetNodeList(NodeType.Container, true, true);
		}
		/// <summary>
		/// 按父节点ID获取子节点列表
		/// </summary>
		/// <param name="parentId"></param>
		/// <returns></returns>
		public IList<NodesEntity> GetNodesListByParentId(int parentId)
		{
			Expression<Func<NodesEntity, bool>> predicate = p => p.ParentID==parentId;
			SortModelField sortModelField1 = new SortModelField() { SortName = "RootID", IsDESC = false };
			SortModelField sortModelField2 = new SortModelField() { SortName = "OrderSort", IsDESC = false };
			SortModelField[] orderByExpression = new SortModelField[2];
			orderByExpression[0] = sortModelField1;
			orderByExpression[1] = sortModelField2;
			IList<NodesEntity> nodesList = LoadListAll(predicate, orderByExpression);
			return nodesList;
		}
		/// <summary>
		/// 按根节点获取第一级子节点列表
		/// </summary>
		/// <param name="rootId"></param>
		/// <returns></returns>
		public IList<NodesEntity> GetNodesListByRootId(int rootId)
		{
			Expression<Func<NodesEntity, bool>> predicate = p => p.RootID==rootId && p.ParentID > 0;
			SortModelField sortModelField = new SortModelField() { SortName = "OrderSort", IsDESC = false };
			SortModelField[] orderByExpression = new SortModelField[1];
			orderByExpression[0] = sortModelField;
			IList<NodesEntity> nodesList = LoadListAll(predicate, orderByExpression);
			return nodesList;
		}
		/// <summary>
		/// 获取指定节点ID集的节点列表
		/// </summary>
		/// <param name="arrChildId">多个ID用“,”分割</param>
		/// <returns></returns>
		public IList<NodesEntity> GetNodesListInArrChildId(string arrChildId)
		{
			if (!DataValidator.IsValidId(arrChildId))
			{
				return new List<NodesEntity>();
			}
			return GetNodeList(arrChildId,true);
		}
		/// <summary>
		/// 按父节点路径获取子节点列表，按Depth排序。
		/// </summary>
		/// <param name="parentPath">多个ID用“,”分割</param>
		/// <returns></returns>
		public IList<NodesEntity> GetNodesListInParentPath(string parentPath)
		{
			if (!DataValidator.IsValidId(parentPath))
			{
				return new List<NodesEntity>();
			}
			Expression<Func<NodesEntity, bool>> predicate = p => true;
			if (!string.IsNullOrEmpty(parentPath))
			{
				var arrNodeID = parentPath.Split(',');
				predicate = predicate.And(p => arrNodeID.Contains(p.NodeID.ToString()));
			}
			SortModelField sortModelField = new SortModelField() { SortName = "Depth", IsDESC = false };
			SortModelField[] orderByExpression = new SortModelField[2];
			orderByExpression[0] = sortModelField;
			IList<NodesEntity> nodesList = LoadListAll(predicate, orderByExpression);
			return nodesList;
		}
		/// <summary>
		/// 获取指定用户组、指定权限码、可匿名访问的节点列表。
		/// 栏目权限。0--开放栏目  1--半开放栏目  2--认证栏目
		/// </summary>
		/// <param name="groupId">会员组ID</param>
		/// <param name="operateCode"></param>
		/// <returns></returns>
		public IList<NodesEntity> GetAnonymousNodeId(int groupId, string operateCode)
		{
			SqlParameter parmGroupId = new SqlParameter("GroupId", groupId);
			SqlParameter parmOperateCode = new SqlParameter("OperateCode", operateCode);
			DbParameter[] parameterArray = new DbParameter[2];
			parameterArray[0] = parmGroupId;
			parameterArray[1] = parmOperateCode;
			string strCommand = "SELECT * FROM NodesEntity WHERE NodeId IN (SELECT DISTINCT NodeId FROM GroupNodePermissions WHERE GroupId = @GroupId AND OperateCode = @OperateCode) AND PurviewType <> 3  ORDER BY NodeId";
			return LoadListAllBySql(strCommand, parameterArray);
		}
		/// <summary>
		/// 获取所有绑定了内容模型的节点列表
		/// </summary>
		/// <returns></returns>
		public IList<NodesEntity> GetContentNodeList()
		{
			SqlParameter parmNodeType = new SqlParameter("NodeType", NodeType.Container);
			string strSql = "SELECT * FROM NodesEntity WHERE Nodetype = @NodeType AND NodeID IN (SELECT NodeID FROM NodesModelTemplate WHERE modelID IN (select ModelID FROM Model WHERE ModelType = 1)) ORDER BY RootID, OrderSort ASC";
			return LoadListAllBySql(strSql, parmNodeType);
		}
		/// <summary>
		/// 获取所有绑定了商品模型的节点列表
		/// </summary>
		/// <returns></returns>
		public IList<NodesEntity> GetShopNodeList()
		{
			SqlParameter parmNodeType = new SqlParameter("NodeType", NodeType.Container);
			string strSql = "SELECT * FROM NodesEntity WHERE Nodetype = @NodeType AND NodeID IN (SELECT NodeID FROM NodesModelTemplate WHERE modelID IN (select ModelID FROM Model WHERE ModelType = 2)) ORDER BY RootID, OrderSort ASC";
			return LoadListAllBySql(strSql, parmNodeType);
		}
		/// <summary>
		/// 按父节点获取商城节点列表
		/// </summary>
		/// <param name="parentId"></param>
		/// <returns></returns>
		public IList<NodesEntity> GetShopNodeListByParentId(int parentId)
		{
			SqlParameter parmParentID = new SqlParameter("ParentID", parentId);
			SqlParameter parmNodeType = new SqlParameter("NodeType", NodeType.Container);
			DbParameter[] parameterArray = new DbParameter[2];
			parameterArray[0] = parmParentID;
			parameterArray[1] = parmNodeType;
			string strSql = "SELECT * FROM NodesEntity WHERE ParentID = @ParentID and Nodetype = @NodeType AND NodeID IN (SELECT NodeID FROM NodesModelTemplate WHERE modelID IN (select ModelID FROM Model WHERE ModelType = 2)) ORDER BY RootID, OrderSort ASC";
			return LoadListAllBySql(strSql, parameterArray);
		}

		/// <summary>
		/// 获取父节点下所有节点的下拉选择树
		/// </summary>
		/// <param name="parentID"></param>
		/// <returns></returns>
		public IList<NodesEntity> GetNodeNameByParentID(int parentID)
		{
			return NodeTreeItems(GetNodeList(GetNodeById(parentID).ArrChildID,true));
		}
		/// <summary>
		/// 获取节点类型为容器节点的下拉选择树
		/// </summary>
		/// <param name="isShowArchiving">是否显示归档节点</param>
		/// <returns></returns>
		public IList<NodesEntity> GetNodeNameForContainerItems(bool isShowArchiving=false)
		{
			return NodeTreeItems(GetNodeList(NodeType.Container, isShowArchiving, false));
		}
		/// <summary>
		/// 获取所有节点的下拉选择树（包含容器栏目、专题栏目、单页节点和外链）
		/// </summary>
		/// <returns></returns>
		public IList<NodesEntity> GetNodeNameForItems()
		{
			return NodeTreeItems(GetNodeList());
		}
		/// <summary>
		/// 获取所有节点的下拉选择树（不包含外链节点）
		/// </summary>
		/// <returns></returns>
		public IList<NodesEntity> GetNodeNameForItemsExceptOutLinks()
		{
			IList<NodesEntity> nodesList = GetNodeList();
			IList<NodesEntity> nodeList = new List<NodesEntity>();
			foreach (NodesEntity info in nodesList)
			{
				if (info.NodeType != (int)(NodeType.Link))
				{
					nodeList.Add(info);
				}
			}
			return NodeTreeItems(nodeList);
		}
		/// <summary>
		/// 获取内容节点下拉选择树
		/// </summary>
		/// <returns></returns>
		public IList<NodesEntity> GetNodeNameForContent()
		{
			IList<NodesEntity> nodesList = GetContentNodeList();
			return NodeTreeItems(nodesList);
		}
		/// <summary>
		/// 获取商城节点下拉选择树
		/// </summary>
		/// <returns></returns>
		public IList<NodesEntity> GetNodeNameForShop()
		{
			IList<NodesEntity> nodesList = GetShopNodeList();
			return NodeTreeItems(nodesList);
		}
		
		/// <summary> 
		/// 生成节点下拉选择树  ├ └
		/// </summary>
		/// <param name="nodeList"></param>
		/// <returns></returns>
		private IList<NodesEntity> NodeTreeItems(IList<NodesEntity> nodeList)
		{
			int index = 0;
			char ch = '\x00a0';
			bool[] flagArray = new bool[50];
			foreach (NodesEntity info in nodeList)
			{
				index = info.Depth;
				if (info.NextID > 0)
				{
					flagArray[index] = true;
				}
				else
				{
					flagArray[index] = false;
				}
				StringBuilder builder = new StringBuilder();
				if (index > 0)
				{
					for (int i = 1; i <= index; i++)
					{
						builder.Append(ch);
						builder.Append(ch);
						if (i == index)
						{
							if (info.NextID > 0)
							{
								builder.Append("├");
								builder.Append(ch);
							}
							else
							{
								builder.Append("└");
								builder.Append(ch);
							}
						}
						else if (flagArray[i])
						{
							builder.Append("│");
						}
						else
						{
							builder.Append(ch);
						}
					}
				}
				builder.Append(info.NodeName);
				if (info.NodeType == (int)(NodeType.Link))
				{
					builder.Append("(外)");
				}
				info.NodeName = builder.ToString();
			}
			return nodeList;
		}
		#endregion

		#region 是否存在数据
		/// <summary>
		///  判断同级节点下是否存在同名的节点目录
		/// </summary>
		/// <param name="parentId">父节点ID</param>
		/// <param name="nodeDir">目录名称</param>
		/// <returns></returns>
		public bool ExistsNodeDir(int parentId, string nodeDir)
		{
			if (string.IsNullOrEmpty(nodeDir))
			{
				return false;
			}
			return IsExist(p=>p.ParentID==parentId && p.NodeDir==nodeDir);
		}
		/// <summary>
		///  判断同级节点下是否存在同名的节点标识
		/// </summary>
		/// <param name="parentId">父节点ID</param>
		/// <param name="nodeIdentifier">节点标识</param>
		/// <returns></returns>
		public bool ExistsNodeIdentifier(int parentId, string nodeIdentifier)
		{
			if (string.IsNullOrEmpty(nodeIdentifier))
			{
				return false;
			}
			return IsExist(p => p.ParentID == parentId && p.NodeIdentifier == nodeIdentifier);
		}
		/// <summary>
		///  判断同级节点下是否存在同名的节点名称
		/// </summary>
		/// <param name="parentId">父节点ID</param>
		/// <param name="nodeName">节点名称</param>
		/// <returns></returns>
		public bool ExistsNodeName(int parentId, string nodeName)
		{
			if (string.IsNullOrEmpty(nodeName))
			{
				return false;
			}
			return IsExist(p => p.ParentID == parentId && p.NodeName == nodeName);
		}
		/// <summary>
		/// 判断移动的节点是否包含目标节点
		/// </summary>
		/// <param name="targetNodeId">目标节点</param>
		/// <param name="arrChildId">子节点ID，多个ID用“,”分割</param>
		/// <returns></returns>
		public bool ExistsTargetNodeIdInArrChildId(int targetNodeId, string arrChildId)
		{
			if (!DataValidator.IsValidId(arrChildId))
			{
				return false;
			}
			Expression<Func<NodesEntity, bool>> predicate = p => p.NodeID == targetNodeId;
			var arrNodeID = arrChildId.Split(',');
			predicate = predicate.And(p => arrNodeID.Contains(p.NodeID.ToString()));
			return IsExist(predicate);
		}
		#endregion

		#region 判断数据是否正确
		/// <summary>
		/// 判断指定的模板ID，是否为指定节点的默认模板ID
		/// </summary>
		/// <param name="nodeId"></param>
		/// <param name="templateId"></param>
		/// <returns></returns>
		public bool GetDefaultTemplate(int nodeId, int templateId)
		{
			return _NodesTemplateRepository.Get(p=>p.NodeID==nodeId && p.TemplateID==templateId).IsDefault;
		}
		#endregion

		#region 删除缓存
		/// <summary>
		/// 删除指定节点的缓存信息
		/// </summary>
		/// <param name="nodeId"></param>
		public void RemoveCacheByNodeId(int nodeId)
		{
			CacheHelper.CacheServiceProvider.Remove("CK_Content_NodeInfo_NodeId_" + nodeId.ToString());
		}
		#endregion

	}
}