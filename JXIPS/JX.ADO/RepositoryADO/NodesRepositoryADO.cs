using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;
using JX.Infrastructure.Common;
using MyADO;

namespace JX.ADO
{
	/// <summary>
	/// 数据库表：Nodes 的仓储实现类.
	/// </summary>
	public partial class NodesRepositoryADO : INodesRepositoryADO
	{
		#region 数据上下文
		/// <summary>
		/// 数据上下文
		/// </summary>
		private IDBOperator _DB;

		/// <summary>
		/// 构造器注入
		/// </summary>
		/// <param name="DB"></param>
		public NodesRepositoryADO(IDBOperator DB)
		{
			_DB = DB;
		}
		#endregion
		
		#region 得到第一行第一列的值
		/// <summary>
		/// 得到第一行第一列的值
		/// </summary>
		/// <param name="statistic">要返回的字段（如：count(*) 或者 UserName）</param>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual string GetScalar(string statistic, string strWhere = "", Dictionary<string, object> dict = null)
		{
			string strSQL = "select " + statistic + " from Nodes where 1=1 ";
			if (!string.IsNullOrEmpty(strWhere))
			{
				strSQL += strWhere;
			}
			return _DB.ExeSQLScalar(strSQL, dict);
		}
		/// <summary>
		/// 得到第一行第一列的值（异步方式）
		/// </summary>
		/// <param name="statistic">要返回的字段（如：count(*) 或者 UserName）</param>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual async Task<string> GetScalarAsync(string statistic, string strWhere = "", Dictionary<string, object> dict = null)
		{
			string strSQL = "select " + statistic + " from Nodes where 1=1 ";
			if (!string.IsNullOrEmpty(strWhere))
			{
				strSQL += strWhere;
			}
			return await Task.Run(() => _DB.ExeSQLScalar(strSQL, dict));
		}
		#endregion
		
		#region 得到所有行数
		/// <summary>
		/// 得到所有行数
		/// </summary>
		/// <returns></returns>
		public virtual int GetCount()
		{
			return DataConverter.CLng(GetScalar("count(*)"), 0);
		}
		/// <summary>
		/// 得到所有行数（异步方式）
		/// </summary>
		/// <returns></returns>
		public virtual async Task<int> GetCountAsync()
		{
			return DataConverter.CLng(await GetScalarAsync("count(*)"), 0);
		}

		/// <summary>
		/// 得到所有行数
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual int GetCount(string strWhere, Dictionary<string, object> dict = null)
		{
			return DataConverter.CLng(GetScalar("count(*)", strWhere, dict), 0);
		}
		/// <summary>
		/// 得到所有行数（异步方式）
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual async Task<int> GetCountAsync(string strWhere, Dictionary<string, object> dict = null)
		{
			return DataConverter.CLng(await GetScalarAsync("count(*)", strWhere, dict), 0);
		}
		#endregion
		
		#region 得到最大ID、最新ID
		/// <summary>
		/// 得到数据表中第一个主键的最大数值
		/// </summary>
		/// <returns></returns>
		public virtual int GetMaxID()
		{
			return _DB.GetMaxID("Nodes", "NodeID");
		}
		/// <summary>
		/// 得到数据表中第一个主键的最大数值（异步方式）
		/// </summary>
		/// <returns></returns>
		public virtual async Task<int> GetMaxIDAsync()
		{
			return await Task.Run(() => _DB.GetMaxID("Nodes", "NodeID"));
		}

		/// <summary>
		/// 得到数据表中第一个主键的最大数值加1
		/// </summary>
		/// <returns></returns>
		public virtual int GetNewID()
		{
			return GetMaxID() + 1;
		}
		/// <summary>
		/// 得到数据表中第一个主键的最大数值加1（异步方式）
		/// </summary>
		/// <returns></returns>
		public virtual async Task<int> GetNewIDAsync()
		{
			return await GetMaxIDAsync() + 1;
		}
		#endregion
		
		#region 验证是否存在
		/// <summary>
		/// 检查数据是否存在
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual bool IsExist(string strWhere, Dictionary<string, object> dict = null)
		{
			if (GetCount(strWhere, dict) == 0)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// 检查数据是否存在（异步方式）
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual async Task<bool> IsExistAsync(string strWhere, Dictionary<string, object> dict = null)
		{
			int count = await GetCountAsync(strWhere, dict);
			if (count == 0)
			{
				return false;
			}
			return true;
		}
		#endregion
		
		#region 添加
		/// <summary>
		/// 增加一条记录
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <returns></returns>
		public virtual bool Add(NodesEntity entity)
		{
			if(entity.NodeID <= 0) entity.NodeID=GetNewID();
			Dictionary<string, object> dict = new Dictionary<string, object>();
			GetParameters(entity,dict);

			string strSQL = "insert into Nodes ("+
							"NodeID,"+
							"NodeIdentifier,"+
							"NodeType,"+
							"ParentID,"+
							"ParentPath,"+
							"Depth,"+
							"RootID,"+
							"Child,"+
							"arrChildID,"+
							"PrevID,"+
							"NextID,"+
							"OrderSort,"+
							"NodeDir,"+
							"ParentDir,"+
							"NodeName,"+
							"Tips,"+
							"Description,"+
							"NodePicUrl,"+
							"Meta_Keywords,"+
							"Meta_Description,"+
							"IsShowOnMenu,"+
							"IsShowOnPath,"+
							"IsShowOnMap,"+
							"IsShowOnList_Index,"+
							"IsShowOnList_Parent,"+
							"PurviewType,"+
							"Creater,"+
							"InheritPurviewFromParent,"+
							"WorkFlowID,"+
							"HitsOfHot,"+
							"LeastOfEliteLevel,"+
							"OpenType,"+
							"ItemCount,"+
							"ItemChecked,"+
							"CommentCount,"+
							"Custom_Content,"+
							"IsCreateListPage,"+
							"IsCreateContentPage,"+
							"AutoCreateHtmlType,"+
							"ContentPageHtmlRule,"+
							"ListPageHtmlRule,"+
							"ItemAspxFileName,"+
							"RelateNode,"+
							"RelateSpecial,"+
							"DefaultTemplateFile,"+
							"ContainChildTemplateFile,"+
							"ItemOpenType,"+
							"ItemListOrderType,"+
							"ItemPageSize,"+
							"UpLoadDirRule,"+
							"LinkUrl,"+
							"Settings,"+
							"IPLock,"+
							"ListPagePostFix,"+
							"ListPageSavePathType,"+
							"IsNeedCreateHtml,"+
							"CultureName,"+
							"IsSubDomain,"+
							"SubDomain) "+
							"values("+
							"@NodeID,"+
							"@NodeIdentifier,"+
							"@NodeType,"+
							"@ParentID,"+
							"@ParentPath,"+
							"@Depth,"+
							"@RootID,"+
							"@Child,"+
							"@arrChildID,"+
							"@PrevID,"+
							"@NextID,"+
							"@OrderSort,"+
							"@NodeDir,"+
							"@ParentDir,"+
							"@NodeName,"+
							"@Tips,"+
							"@Description,"+
							"@NodePicUrl,"+
							"@Meta_Keywords,"+
							"@Meta_Description,"+
							"@IsShowOnMenu,"+
							"@IsShowOnPath,"+
							"@IsShowOnMap,"+
							"@IsShowOnList_Index,"+
							"@IsShowOnList_Parent,"+
							"@PurviewType,"+
							"@Creater,"+
							"@InheritPurviewFromParent,"+
							"@WorkFlowID,"+
							"@HitsOfHot,"+
							"@LeastOfEliteLevel,"+
							"@OpenType,"+
							"@ItemCount,"+
							"@ItemChecked,"+
							"@CommentCount,"+
							"@Custom_Content,"+
							"@IsCreateListPage,"+
							"@IsCreateContentPage,"+
							"@AutoCreateHtmlType,"+
							"@ContentPageHtmlRule,"+
							"@ListPageHtmlRule,"+
							"@ItemAspxFileName,"+
							"@RelateNode,"+
							"@RelateSpecial,"+
							"@DefaultTemplateFile,"+
							"@ContainChildTemplateFile,"+
							"@ItemOpenType,"+
							"@ItemListOrderType,"+
							"@ItemPageSize,"+
							"@UpLoadDirRule,"+
							"@LinkUrl,"+
							"@Settings,"+
							"@IPLock,"+
							"@ListPagePostFix,"+
							"@ListPageSavePathType,"+
							"@IsNeedCreateHtml,"+
							"@CultureName,"+
							"@IsSubDomain,"+
							"@SubDomain)";
			
			return _DB.ExeSQLResult(strSQL,dict);
		}
		/// <summary>
		/// 增加一条记录（异步方式）
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <returns></returns>
		public virtual async Task<bool> AddAsync(NodesEntity entity)
		{
			if(entity.NodeID <= 0) entity.NodeID=GetNewID();
			Dictionary<string, object> dict = new Dictionary<string, object>();
			GetParameters(entity, dict);

			string strSQL = "insert into Nodes ("+
							"NodeID,"+
							"NodeIdentifier,"+
							"NodeType,"+
							"ParentID,"+
							"ParentPath,"+
							"Depth,"+
							"RootID,"+
							"Child,"+
							"arrChildID,"+
							"PrevID,"+
							"NextID,"+
							"OrderSort,"+
							"NodeDir,"+
							"ParentDir,"+
							"NodeName,"+
							"Tips,"+
							"Description,"+
							"NodePicUrl,"+
							"Meta_Keywords,"+
							"Meta_Description,"+
							"IsShowOnMenu,"+
							"IsShowOnPath,"+
							"IsShowOnMap,"+
							"IsShowOnList_Index,"+
							"IsShowOnList_Parent,"+
							"PurviewType,"+
							"Creater,"+
							"InheritPurviewFromParent,"+
							"WorkFlowID,"+
							"HitsOfHot,"+
							"LeastOfEliteLevel,"+
							"OpenType,"+
							"ItemCount,"+
							"ItemChecked,"+
							"CommentCount,"+
							"Custom_Content,"+
							"IsCreateListPage,"+
							"IsCreateContentPage,"+
							"AutoCreateHtmlType,"+
							"ContentPageHtmlRule,"+
							"ListPageHtmlRule,"+
							"ItemAspxFileName,"+
							"RelateNode,"+
							"RelateSpecial,"+
							"DefaultTemplateFile,"+
							"ContainChildTemplateFile,"+
							"ItemOpenType,"+
							"ItemListOrderType,"+
							"ItemPageSize,"+
							"UpLoadDirRule,"+
							"LinkUrl,"+
							"Settings,"+
							"IPLock,"+
							"ListPagePostFix,"+
							"ListPageSavePathType,"+
							"IsNeedCreateHtml,"+
							"CultureName,"+
							"IsSubDomain,"+
							"SubDomain) "+
							"values("+
							"@NodeID,"+
							"@NodeIdentifier,"+
							"@NodeType,"+
							"@ParentID,"+
							"@ParentPath,"+
							"@Depth,"+
							"@RootID,"+
							"@Child,"+
							"@arrChildID,"+
							"@PrevID,"+
							"@NextID,"+
							"@OrderSort,"+
							"@NodeDir,"+
							"@ParentDir,"+
							"@NodeName,"+
							"@Tips,"+
							"@Description,"+
							"@NodePicUrl,"+
							"@Meta_Keywords,"+
							"@Meta_Description,"+
							"@IsShowOnMenu,"+
							"@IsShowOnPath,"+
							"@IsShowOnMap,"+
							"@IsShowOnList_Index,"+
							"@IsShowOnList_Parent,"+
							"@PurviewType,"+
							"@Creater,"+
							"@InheritPurviewFromParent,"+
							"@WorkFlowID,"+
							"@HitsOfHot,"+
							"@LeastOfEliteLevel,"+
							"@OpenType,"+
							"@ItemCount,"+
							"@ItemChecked,"+
							"@CommentCount,"+
							"@Custom_Content,"+
							"@IsCreateListPage,"+
							"@IsCreateContentPage,"+
							"@AutoCreateHtmlType,"+
							"@ContentPageHtmlRule,"+
							"@ListPageHtmlRule,"+
							"@ItemAspxFileName,"+
							"@RelateNode,"+
							"@RelateSpecial,"+
							"@DefaultTemplateFile,"+
							"@ContainChildTemplateFile,"+
							"@ItemOpenType,"+
							"@ItemListOrderType,"+
							"@ItemPageSize,"+
							"@UpLoadDirRule,"+
							"@LinkUrl,"+
							"@Settings,"+
							"@IPLock,"+
							"@ListPagePostFix,"+
							"@ListPageSavePathType,"+
							"@IsNeedCreateHtml,"+
							"@CultureName,"+
							"@IsSubDomain,"+
							"@SubDomain)";
			
			return await Task.Run(() => _DB.ExeSQLResult(strSQL, dict));
		}

		/// <summary>
		/// 增加一条记录，返回新的ID号。需要有一个单一主键，并且开启有标识符属性
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <returns></returns>
		public virtual int Insert(NodesEntity entity)
		{
			if(entity.NodeID <= 0) entity.NodeID=GetNewID();			
			Dictionary<string, object> dict = new Dictionary<string, object>();
			GetParameters(entity,dict);

			string strSQL = "insert into Nodes ("+
							"NodeID,"+
							"NodeIdentifier,"+
							"NodeType,"+
							"ParentID,"+
							"ParentPath,"+
							"Depth,"+
							"RootID,"+
							"Child,"+
							"arrChildID,"+
							"PrevID,"+
							"NextID,"+
							"OrderSort,"+
							"NodeDir,"+
							"ParentDir,"+
							"NodeName,"+
							"Tips,"+
							"Description,"+
							"NodePicUrl,"+
							"Meta_Keywords,"+
							"Meta_Description,"+
							"IsShowOnMenu,"+
							"IsShowOnPath,"+
							"IsShowOnMap,"+
							"IsShowOnList_Index,"+
							"IsShowOnList_Parent,"+
							"PurviewType,"+
							"Creater,"+
							"InheritPurviewFromParent,"+
							"WorkFlowID,"+
							"HitsOfHot,"+
							"LeastOfEliteLevel,"+
							"OpenType,"+
							"ItemCount,"+
							"ItemChecked,"+
							"CommentCount,"+
							"Custom_Content,"+
							"IsCreateListPage,"+
							"IsCreateContentPage,"+
							"AutoCreateHtmlType,"+
							"ContentPageHtmlRule,"+
							"ListPageHtmlRule,"+
							"ItemAspxFileName,"+
							"RelateNode,"+
							"RelateSpecial,"+
							"DefaultTemplateFile,"+
							"ContainChildTemplateFile,"+
							"ItemOpenType,"+
							"ItemListOrderType,"+
							"ItemPageSize,"+
							"UpLoadDirRule,"+
							"LinkUrl,"+
							"Settings,"+
							"IPLock,"+
							"ListPagePostFix,"+
							"ListPageSavePathType,"+
							"IsNeedCreateHtml,"+
							"CultureName,"+
							"IsSubDomain,"+
							"SubDomain) "+
							"values("+
							"@NodeID,"+
							"@NodeIdentifier,"+
							"@NodeType,"+
							"@ParentID,"+
							"@ParentPath,"+
							"@Depth,"+
							"@RootID,"+
							"@Child,"+
							"@arrChildID,"+
							"@PrevID,"+
							"@NextID,"+
							"@OrderSort,"+
							"@NodeDir,"+
							"@ParentDir,"+
							"@NodeName,"+
							"@Tips,"+
							"@Description,"+
							"@NodePicUrl,"+
							"@Meta_Keywords,"+
							"@Meta_Description,"+
							"@IsShowOnMenu,"+
							"@IsShowOnPath,"+
							"@IsShowOnMap,"+
							"@IsShowOnList_Index,"+
							"@IsShowOnList_Parent,"+
							"@PurviewType,"+
							"@Creater,"+
							"@InheritPurviewFromParent,"+
							"@WorkFlowID,"+
							"@HitsOfHot,"+
							"@LeastOfEliteLevel,"+
							"@OpenType,"+
							"@ItemCount,"+
							"@ItemChecked,"+
							"@CommentCount,"+
							"@Custom_Content,"+
							"@IsCreateListPage,"+
							"@IsCreateContentPage,"+
							"@AutoCreateHtmlType,"+
							"@ContentPageHtmlRule,"+
							"@ListPageHtmlRule,"+
							"@ItemAspxFileName,"+
							"@RelateNode,"+
							"@RelateSpecial,"+
							"@DefaultTemplateFile,"+
							"@ContainChildTemplateFile,"+
							"@ItemOpenType,"+
							"@ItemListOrderType,"+
							"@ItemPageSize,"+
							"@UpLoadDirRule,"+
							"@LinkUrl,"+
							"@Settings,"+
							"@IPLock,"+
							"@ListPagePostFix,"+
							"@ListPageSavePathType,"+
							"@IsNeedCreateHtml,"+
							"@CultureName,"+
							"@IsSubDomain,"+
							"@SubDomain)";
			if(_DB.ExeSQLResult(strSQL,dict))
			{
				return DataConverter.CLng(entity.NodeID);
			}
			return -1;
		}
		/// <summary>
		/// 增加一条记录，返回新的ID号。需要有一个单一主键，并且开启有标识符属性（异步方式）
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <returns></returns>
		public virtual async Task<int> InsertAsync(NodesEntity entity)
		{
			if(entity.NodeID <= 0) entity.NodeID=GetNewID();			
			Dictionary<string, object> dict = new Dictionary<string, object>();
			GetParameters(entity,dict);

			string strSQL = "insert into Nodes ("+
							"NodeID,"+
							"NodeIdentifier,"+
							"NodeType,"+
							"ParentID,"+
							"ParentPath,"+
							"Depth,"+
							"RootID,"+
							"Child,"+
							"arrChildID,"+
							"PrevID,"+
							"NextID,"+
							"OrderSort,"+
							"NodeDir,"+
							"ParentDir,"+
							"NodeName,"+
							"Tips,"+
							"Description,"+
							"NodePicUrl,"+
							"Meta_Keywords,"+
							"Meta_Description,"+
							"IsShowOnMenu,"+
							"IsShowOnPath,"+
							"IsShowOnMap,"+
							"IsShowOnList_Index,"+
							"IsShowOnList_Parent,"+
							"PurviewType,"+
							"Creater,"+
							"InheritPurviewFromParent,"+
							"WorkFlowID,"+
							"HitsOfHot,"+
							"LeastOfEliteLevel,"+
							"OpenType,"+
							"ItemCount,"+
							"ItemChecked,"+
							"CommentCount,"+
							"Custom_Content,"+
							"IsCreateListPage,"+
							"IsCreateContentPage,"+
							"AutoCreateHtmlType,"+
							"ContentPageHtmlRule,"+
							"ListPageHtmlRule,"+
							"ItemAspxFileName,"+
							"RelateNode,"+
							"RelateSpecial,"+
							"DefaultTemplateFile,"+
							"ContainChildTemplateFile,"+
							"ItemOpenType,"+
							"ItemListOrderType,"+
							"ItemPageSize,"+
							"UpLoadDirRule,"+
							"LinkUrl,"+
							"Settings,"+
							"IPLock,"+
							"ListPagePostFix,"+
							"ListPageSavePathType,"+
							"IsNeedCreateHtml,"+
							"CultureName,"+
							"IsSubDomain,"+
							"SubDomain) "+
							"values("+
							"@NodeID,"+
							"@NodeIdentifier,"+
							"@NodeType,"+
							"@ParentID,"+
							"@ParentPath,"+
							"@Depth,"+
							"@RootID,"+
							"@Child,"+
							"@arrChildID,"+
							"@PrevID,"+
							"@NextID,"+
							"@OrderSort,"+
							"@NodeDir,"+
							"@ParentDir,"+
							"@NodeName,"+
							"@Tips,"+
							"@Description,"+
							"@NodePicUrl,"+
							"@Meta_Keywords,"+
							"@Meta_Description,"+
							"@IsShowOnMenu,"+
							"@IsShowOnPath,"+
							"@IsShowOnMap,"+
							"@IsShowOnList_Index,"+
							"@IsShowOnList_Parent,"+
							"@PurviewType,"+
							"@Creater,"+
							"@InheritPurviewFromParent,"+
							"@WorkFlowID,"+
							"@HitsOfHot,"+
							"@LeastOfEliteLevel,"+
							"@OpenType,"+
							"@ItemCount,"+
							"@ItemChecked,"+
							"@CommentCount,"+
							"@Custom_Content,"+
							"@IsCreateListPage,"+
							"@IsCreateContentPage,"+
							"@AutoCreateHtmlType,"+
							"@ContentPageHtmlRule,"+
							"@ListPageHtmlRule,"+
							"@ItemAspxFileName,"+
							"@RelateNode,"+
							"@RelateSpecial,"+
							"@DefaultTemplateFile,"+
							"@ContainChildTemplateFile,"+
							"@ItemOpenType,"+
							"@ItemListOrderType,"+
							"@ItemPageSize,"+
							"@UpLoadDirRule,"+
							"@LinkUrl,"+
							"@Settings,"+
							"@IPLock,"+
							"@ListPagePostFix,"+
							"@ListPageSavePathType,"+
							"@IsNeedCreateHtml,"+
							"@CultureName,"+
							"@IsSubDomain,"+
							"@SubDomain)";
			if(await Task.Run(() => _DB.ExeSQLResult(strSQL, dict)))
			{
				return DataConverter.CLng(entity.NodeID);
			}
			return -1;
		}

		/// <summary>
		/// 增加或更新一条记录
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsSave">是否增加</param>
		/// <returns></returns>
		public virtual bool AddOrUpdate(NodesEntity entity, bool IsSave)
		{
			return IsSave ? Add(entity) : Update(entity);
		}
		/// <summary>
		/// 增加或更新一条记录（异步方式）
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsSave">是否增加</param>
		/// <returns></returns>
		public virtual async Task<bool> AddOrUpdateAsync(NodesEntity entity, bool IsSave)
		{
			return IsSave ? await AddAsync(entity) : await UpdateAsync(entity);
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 通过主键删除
		/// </summary>
		/// <returns></returns>
		public bool Delete(System.Int32 nodeID)
		{
			string strSQL = "delete from Nodes where " +
			
			"NodeID = @NodeID"; 
			
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("NodeID", nodeID);
			
			return _DB.ExeSQLResult(strSQL, dict);
		}
		/// <summary>
		/// 通过主键删除
		/// </summary>
		/// <returns></returns>
		public async Task<bool> DeleteAsync(System.Int32 nodeID)
		{
			string strSQL = "delete from Nodes where " +
			
			"NodeID = @NodeID"; 
			
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("NodeID", nodeID);
			
			return await Task.Run(() => _DB.ExeSQLResult(strSQL, dict));
		}
		
		/// <summary>
		/// 删除一条或多条记录
		/// </summary>
		/// <param name="strWhere">参数化删除条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual bool Delete(string strWhere, Dictionary<string, object> dict = null)
		{
			string strSQL = "delete from Nodes where 1=1 " + strWhere;
			return _DB.ExeSQLResult(strSQL, dict);
		}
		/// <summary>
		/// 删除一条或多条记录（异步方式）
		/// </summary>
		/// <param name="strWhere">参数化删除条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual async Task<bool> DeleteAsync(string strWhere, Dictionary<string, object> dict = null)
		{
			string strSQL = "delete from Nodes where 1=1 " + strWhere;
			return await Task.Run(() => _DB.ExeSQLResult(strSQL, dict));
		}
		#endregion
		
		#region 修改
		/// <summary>
		/// 更新一条记录
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <returns></returns>
		public virtual bool Update(NodesEntity entity)
		{
			Dictionary<string, object> dict = new Dictionary<string, object>();
			GetParameters(entity, dict);
			string strSQL = "Update Nodes SET "+
			"NodeIdentifier = @NodeIdentifier,"+
			"NodeType = @NodeType,"+
			"ParentID = @ParentID,"+
			"ParentPath = @ParentPath,"+
			"Depth = @Depth,"+
			"RootID = @RootID,"+
			"Child = @Child,"+
			"arrChildID = @arrChildID,"+
			"PrevID = @PrevID,"+
			"NextID = @NextID,"+
			"OrderSort = @OrderSort,"+
			"NodeDir = @NodeDir,"+
			"ParentDir = @ParentDir,"+
			"NodeName = @NodeName,"+
			"Tips = @Tips,"+
			"Description = @Description,"+
			"NodePicUrl = @NodePicUrl,"+
			"Meta_Keywords = @Meta_Keywords,"+
			"Meta_Description = @Meta_Description,"+
			"IsShowOnMenu = @IsShowOnMenu,"+
			"IsShowOnPath = @IsShowOnPath,"+
			"IsShowOnMap = @IsShowOnMap,"+
			"IsShowOnList_Index = @IsShowOnList_Index,"+
			"IsShowOnList_Parent = @IsShowOnList_Parent,"+
			"PurviewType = @PurviewType,"+
			"Creater = @Creater,"+
			"InheritPurviewFromParent = @InheritPurviewFromParent,"+
			"WorkFlowID = @WorkFlowID,"+
			"HitsOfHot = @HitsOfHot,"+
			"LeastOfEliteLevel = @LeastOfEliteLevel,"+
			"OpenType = @OpenType,"+
			"ItemCount = @ItemCount,"+
			"ItemChecked = @ItemChecked,"+
			"CommentCount = @CommentCount,"+
			"Custom_Content = @Custom_Content,"+
			"IsCreateListPage = @IsCreateListPage,"+
			"IsCreateContentPage = @IsCreateContentPage,"+
			"AutoCreateHtmlType = @AutoCreateHtmlType,"+
			"ContentPageHtmlRule = @ContentPageHtmlRule,"+
			"ListPageHtmlRule = @ListPageHtmlRule,"+
			"ItemAspxFileName = @ItemAspxFileName,"+
			"RelateNode = @RelateNode,"+
			"RelateSpecial = @RelateSpecial,"+
			"DefaultTemplateFile = @DefaultTemplateFile,"+
			"ContainChildTemplateFile = @ContainChildTemplateFile,"+
			"ItemOpenType = @ItemOpenType,"+
			"ItemListOrderType = @ItemListOrderType,"+
			"ItemPageSize = @ItemPageSize,"+
			"UpLoadDirRule = @UpLoadDirRule,"+
			"LinkUrl = @LinkUrl,"+
			"Settings = @Settings,"+
			"IPLock = @IPLock,"+
			"ListPagePostFix = @ListPagePostFix,"+
			"ListPageSavePathType = @ListPageSavePathType,"+
			"IsNeedCreateHtml = @IsNeedCreateHtml,"+
			"CultureName = @CultureName,"+
			"IsSubDomain = @IsSubDomain,"+
			"SubDomain = @SubDomain"+
			" WHERE "+
			
			"NodeID = @NodeID"; 
			
			return _DB.ExeSQLResult(strSQL, dict);
		}
		/// <summary>
		/// 更新一条记录（异步方式）
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <returns></returns>
		public virtual async Task<bool> UpdateAsync(NodesEntity entity)
		{
			Dictionary<string, object> dict = new Dictionary<string, object>();
			GetParameters(entity, dict);
			string strSQL = "Update Nodes SET "+
			"NodeIdentifier = @NodeIdentifier,"+
			"NodeType = @NodeType,"+
			"ParentID = @ParentID,"+
			"ParentPath = @ParentPath,"+
			"Depth = @Depth,"+
			"RootID = @RootID,"+
			"Child = @Child,"+
			"arrChildID = @arrChildID,"+
			"PrevID = @PrevID,"+
			"NextID = @NextID,"+
			"OrderSort = @OrderSort,"+
			"NodeDir = @NodeDir,"+
			"ParentDir = @ParentDir,"+
			"NodeName = @NodeName,"+
			"Tips = @Tips,"+
			"Description = @Description,"+
			"NodePicUrl = @NodePicUrl,"+
			"Meta_Keywords = @Meta_Keywords,"+
			"Meta_Description = @Meta_Description,"+
			"IsShowOnMenu = @IsShowOnMenu,"+
			"IsShowOnPath = @IsShowOnPath,"+
			"IsShowOnMap = @IsShowOnMap,"+
			"IsShowOnList_Index = @IsShowOnList_Index,"+
			"IsShowOnList_Parent = @IsShowOnList_Parent,"+
			"PurviewType = @PurviewType,"+
			"Creater = @Creater,"+
			"InheritPurviewFromParent = @InheritPurviewFromParent,"+
			"WorkFlowID = @WorkFlowID,"+
			"HitsOfHot = @HitsOfHot,"+
			"LeastOfEliteLevel = @LeastOfEliteLevel,"+
			"OpenType = @OpenType,"+
			"ItemCount = @ItemCount,"+
			"ItemChecked = @ItemChecked,"+
			"CommentCount = @CommentCount,"+
			"Custom_Content = @Custom_Content,"+
			"IsCreateListPage = @IsCreateListPage,"+
			"IsCreateContentPage = @IsCreateContentPage,"+
			"AutoCreateHtmlType = @AutoCreateHtmlType,"+
			"ContentPageHtmlRule = @ContentPageHtmlRule,"+
			"ListPageHtmlRule = @ListPageHtmlRule,"+
			"ItemAspxFileName = @ItemAspxFileName,"+
			"RelateNode = @RelateNode,"+
			"RelateSpecial = @RelateSpecial,"+
			"DefaultTemplateFile = @DefaultTemplateFile,"+
			"ContainChildTemplateFile = @ContainChildTemplateFile,"+
			"ItemOpenType = @ItemOpenType,"+
			"ItemListOrderType = @ItemListOrderType,"+
			"ItemPageSize = @ItemPageSize,"+
			"UpLoadDirRule = @UpLoadDirRule,"+
			"LinkUrl = @LinkUrl,"+
			"Settings = @Settings,"+
			"IPLock = @IPLock,"+
			"ListPagePostFix = @ListPagePostFix,"+
			"ListPageSavePathType = @ListPageSavePathType,"+
			"IsNeedCreateHtml = @IsNeedCreateHtml,"+
			"CultureName = @CultureName,"+
			"IsSubDomain = @IsSubDomain,"+
			"SubDomain = @SubDomain"+
			" WHERE "+
			
			"NodeID = @NodeID"; 
			return await Task.Run(() => _DB.ExeSQLResult(strSQL, dict));
		}

		/// <summary>
		/// 修改一条或多条记录
		/// </summary>
		/// <param name="strColumns">参数化要修改的列（如：ID = @ID,Name = @Name）</param>
		/// <param name="dictColumns">包含要修改的名称和值的集合,对应strColumns参数中要修改列的值</param>
		/// <param name="strWhere">参数化修改条件(例如: and ID = @ID)</param>
		/// <param name="dictWhere">包含查询名称和值的集合,对应strWhere参数中的值</param>
		/// <returns></returns>
		public virtual bool Update(string strColumns, Dictionary<string, object> dictColumns = null, string strWhere = "", Dictionary<string, object> dictWhere = null)
		{
			if (string.IsNullOrEmpty(strColumns))
				return false;

			strColumns = StringHelper.ReplaceIgnoreCase(strColumns, "@", "@UP_");
			string strSQL = "Update Nodes SET " + strColumns + " where 1=1 " + strWhere;

			Dictionary<string, object> dict = new Dictionary<string, object>();
			//生成要修改列的参数
			foreach (KeyValuePair<string, object> kvp in dictColumns)
			{
				dict.Add("@UP_" + kvp.Key,kvp.Value);
			}
			//生成查询条件的参数
			foreach (KeyValuePair<string, object> kvp in dictWhere)
			{
				dict.Add(kvp.Key, kvp.Value);
			}

			return _DB.ExeSQLResult(strSQL, dict);
		}
		/// <summary>
		/// 修改一条或多条记录（异步方式）
		/// </summary>
		/// <param name="strColumns">参数化要修改的列（如：ID = @ID,Name = @Name）</param>
		/// <param name="dictColumns">包含要修改的名称和值的集合,对应strColumns参数中要修改列的值</param>
		/// <param name="strWhere">参数化修改条件(例如: and ID = @ID)</param>
		/// <param name="dictWhere">包含查询名称和值的集合,对应strWhere参数中的值</param>
		/// <returns></returns>
		public virtual async Task<bool> UpdateAsync(string strColumns, Dictionary<string, object> dictColumns = null, string strWhere = "", Dictionary<string, object> dictWhere = null)
		{
			if (string.IsNullOrEmpty(strColumns))
				return false;

			strColumns = StringHelper.ReplaceIgnoreCase(strColumns, "@", "@UP_");
			string strSQL = "Update Nodes SET " + strColumns + " where 1=1 " + strWhere;

			Dictionary<string, object> dict = new Dictionary<string, object>();
			//生成要修改列的参数
			foreach (KeyValuePair<string, object> kvp in dictColumns)
			{
				dict.Add("@UP_" + kvp.Key, kvp.Value);
			}
			//生成查询条件的参数
			foreach (KeyValuePair<string, object> kvp in dictWhere)
			{
				dict.Add(kvp.Key, kvp.Value);
			}
			return await Task.Run(() => _DB.ExeSQLResult(strSQL, dict));
		}
		#endregion
		
		#region 得到实体
		/// <summary>
		/// 通过主键返回第一条信息的实体类。
		/// </summary>
		/// <returns></returns>
		public NodesEntity GetEntity(System.Int32 nodeID)
		{
			string strCondition = string.Empty;
			strCondition += " and NodeID = @NodeID";
			
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("NodeID", nodeID);
			
			return GetEntity(strCondition,dict);
		}
		/// <summary>
		/// 通过主键返回第一条信息的实体类。
		/// </summary>
		/// <returns></returns>
		public async Task<NodesEntity> GetEntityAsync(System.Int32 nodeID)
		{
			string strCondition = string.Empty;
			strCondition += " and NodeID = @NodeID";
			
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("NodeID", nodeID);
			
			return await GetEntityAsync(strCondition,dict);
		}
		
		/// <summary>
		/// 获取实体
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual NodesEntity GetEntity(string strWhere, Dictionary<string, object> dict = null)
		{
			NodesEntity obj = null;
			string strSQL = "select top 1 * from Nodes where 1=1 " + strWhere;
			using (NullableDataReader reader = _DB.GetDataReader(strSQL, dict))
			{
				if (reader.Read())
				{
					obj = GetEntityFromrdr(reader);
				}
			}
			return obj;
		}
		/// <summary>
		/// 获取实体（异步方式）
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual async Task<NodesEntity> GetEntityAsync(string strWhere, Dictionary<string, object> dict = null)
		{
			NodesEntity obj = null;
			string strSQL = "select top 1 * from Nodes where 1=1 " + strWhere;
			using (NullableDataReader reader = await Task.Run(() => _DB.GetDataReader(strSQL, dict)))
			{
				if (reader.Read())
				{
					obj = GetEntityFromrdr(reader);
				}
			}
			return obj;
		}
		#endregion
		
		#region 得到实体列表
		/// <summary>
		/// 得到实体列表
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual IList<NodesEntity> GetEntityList(string strWhere="", Dictionary<string, object> dict = null)
		{
			IList<NodesEntity> list = new List<NodesEntity>();
			string strSQL = "select * from Nodes where 1=1 ";
			if(!string.IsNullOrEmpty(strWhere))
			{
				strSQL += strWhere;
			}
			using (NullableDataReader reader = _DB.GetDataReader(strSQL, dict))
			{
				while (reader.Read())
				{
					list.Add(GetEntityFromrdr(reader));
				}
			}
			return list;
		}
		/// <summary>
		/// 得到实体列表（异步方式）
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual async Task<IList<NodesEntity>> GetEntityListAsync(string strWhere = "", Dictionary<string, object> dict = null)
		{
			IList<NodesEntity> list = new List<NodesEntity>();
			string strSQL = "select * from Nodes where 1=1 ";
			if (!string.IsNullOrEmpty(strWhere))
			{
				strSQL += strWhere;
			}
			using (NullableDataReader reader = await Task.Run(() => _DB.GetDataReader(strSQL, dict)))
			{
				while (reader.Read())
				{
					list.Add(GetEntityFromrdr(reader));
				}
			}
			return list;
		}
		#endregion
		
		#region 得到数据列表
		/// <summary>
		/// 返回所有信息
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual DataTable GetAllData(string strWhere = "", Dictionary<string, object> dict = null)
		{
			string strSQL = "select * from Nodes where 1=1 ";
			if(!string.IsNullOrEmpty(strWhere))
			{
				strSQL += strWhere;
			}
			return _DB.GetDataTable(strSQL, dict);
		}
		/// <summary>
		/// 返回所有信息（异步方式）
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual async Task<DataTable> GetAllDataAsync(string strWhere = "", Dictionary<string, object> dict = null)
		{
			string strSQL = "select * from Nodes where 1=1 ";
			if(!string.IsNullOrEmpty(strWhere))
			{
				strSQL += strWhere;
			}
			return await Task.Run(() => _DB.GetDataTable(strSQL, dict));
		}

		/// <summary>
		/// 返回所有信息
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <param name="strExtended">返回的指定列(例如: extended = id + name 或 distinct name)</param>
		/// <returns></returns>
		public virtual DataTable GetAllData(string strWhere = "", Dictionary<string, object> dict = null, string strExtended="*")
		{
			string strSQL = "select " + strExtended + " from Nodes where 1=1 ";
			if(!string.IsNullOrEmpty(strWhere))
			{
				strSQL += strWhere;
			}
			return _DB.GetDataTable(strSQL, dict);
		}
		/// <summary>
		/// 返回所有信息（异步方式）
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <param name="strExtended">返回的指定列(例如: extended = id + name 或 distinct name)</param>
		/// <returns></returns>
		public virtual async Task<DataTable> GetAllDataAsync(string strWhere = "", Dictionary<string, object> dict = null, string strExtended = "*")
		{
			string strSQL = "select " + strExtended + " from Nodes where 1=1 ";
			if(!string.IsNullOrEmpty(strWhere))
			{
				strSQL += strWhere;
			}
			return await Task.Run(() => _DB.GetDataTable(strSQL, dict));
		}
		#endregion
		
		#region 分页
		/// <summary>
		/// 通过存储过程"Common_GetList"，得到分页后的数据
		/// </summary>
		/// <param name="startRowIndexId">开始行索引</param>
        /// <param name="maxNumberRows">每页最大显示数量</param>
        /// <param name="Filter">查询条件(例如: Name = 'name' and id=1 )</param>
		/// <param name="Total">输出参数：查询总数</param>
		/// <returns></returns>
		public IList<NodesEntity> GetList(int startRowIndexId, int maxNumberRows,string Filter, out int Total)
		{
			Total = 0;
			return GetList(startRowIndexId,maxNumberRows,"","","",Filter,"",out Total);
		}
		/// <summary>
		/// 通过存储过程“Common_GetList”，得到分页后的数据
		/// </summary>
		/// <param name="startRowIndexId">开始行索引</param>
		/// <param name="maxNumberRows">每页最大显示数量</param>
		/// <param name="SortColumn">排序字段名，只能指定一个字段</param>
		/// <param name="StrColumn">返回列名</param>
		/// <param name="Sorts">排序方式（DESC,ASC）</param>
		/// <param name="Filter">查询条件(例如: Name = 'name' and id=1 )</param>
		/// <param name="TableName">查询表名，可以指定联合查询的SQL语句(例如: Comment LEFT JOIN Users ON Comment.UserName = Users.UserName)</param>
		/// <param name="Total">输出参数：查询总数</param>
		/// <returns></returns>
		public virtual IList<NodesEntity> GetList(int startRowIndexId, int maxNumberRows, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total)
		{
			IList<NodesEntity> list = new List<NodesEntity>();
			if (string.IsNullOrEmpty(SortColumn))
			{
				SortColumn = "NodeID";
			}
			if (string.IsNullOrEmpty(StrColumn))
			{
				StrColumn = "*";
			}
			if (string.IsNullOrEmpty(Sorts))
			{
				Sorts = "DESC";
			}
			if (string.IsNullOrEmpty(TableName))
			{
				TableName = "Nodes";
			}
			string storedProcedureName = "Common_GetList";
			SqlParameter parmStartRows = new SqlParameter("StartRows", startRowIndexId);
			SqlParameter parmPageSize = new SqlParameter("PageSize", maxNumberRows);
			SqlParameter parmSortColumn = new SqlParameter("SortColumn", SortColumn);
			SqlParameter parmStrColumn = new SqlParameter("StrColumn", StrColumn);
			SqlParameter parmSorts = new SqlParameter("Sorts", Sorts);
			SqlParameter parmTableName = new SqlParameter("TableName", TableName);
			SqlParameter parmFilter = new SqlParameter("Filter", Filter);
			SqlParameter parmTotal = new SqlParameter("Total", SqlDbType.Int);
			parmTotal.Direction = ParameterDirection.Output;
			IDataParameter[] parameterArray = new IDataParameter[8];
			parameterArray[0] = parmStartRows;
			parameterArray[1] = parmPageSize;
			parameterArray[2] = parmSortColumn;
			parameterArray[3] = parmStrColumn;
			parameterArray[4] = parmSorts;
			parameterArray[5] = parmTableName;
			parameterArray[6] = parmFilter;
			parameterArray[7] = parmTotal;
			using (NullableDataReader reader = _DB.GetDataReaderByProc(storedProcedureName, parameterArray))
			{
				while (reader.Read())
				{
					list.Add(GetEntityFromrdr(reader));
				}
			}
			Total = (int)parmTotal.Value;
			return list;
		}

		/// <summary>
		/// 通过存储过程"Common_GetListBySortColumn"，得到分页后的数据
		/// </summary>
		/// <param name="startRowIndexId">开始行索引</param>
        /// <param name="maxNumberRows">每页最大显示数量</param>
        /// <param name="Filter">查询条件(例如: Name = 'name' and id=1 )</param>
		/// <param name="Total">输出参数：查询总数</param>
		/// <returns></returns>
		public IList<NodesEntity> GetListBySortColumn(int startRowIndexId, int maxNumberRows,string Filter, out int Total)
		{
			Total = 0;
			return GetListBySortColumn(startRowIndexId,maxNumberRows,"","","","","",Filter,"",out Total);
		}
		/// <summary>
		/// 通过存储过程"Common_GetListBySortColumn"，得到分页后的数据
		/// </summary>
		/// <param name="startRowIndexId">开始行索引</param>
        /// <param name="maxNumberRows">每页最大显示数量</param>
		/// <param name="Sorts">排序方式（DESC,ASC）</param>
        /// <param name="Filter">查询条件(例如: Name = 'name' and id=1 )</param>
		/// <param name="Total">输出参数：查询总数</param>
		/// <returns></returns>
		public IList<NodesEntity> GetListBySortColumn(int startRowIndexId, int maxNumberRows,string Sorts,string Filter, out int Total)
		{
			Total = 0;
			return GetListBySortColumn(startRowIndexId,maxNumberRows,"","","","",Sorts,Filter,"",out Total);
		}
		/// <summary>
		/// 通过存储过程“Common_GetListBySortColumn”，得到分页后的数据
		/// </summary>
		/// <param name="startRowIndexId">开始行索引</param>
		/// <param name="maxNumberRows">每页最大显示数量</param>
		/// <param name="PrimaryColumn">主键字段名</param>
		/// <param name="SortColumnDbType">排序字段的数据类型(如：int)</param>
		/// <param name="SortColumn">排序字段名，只能指定一个字段</param>
		/// <param name="StrColumn">返回列名</param>
		/// <param name="Sorts">排序方式（DESC,ASC）</param>
		/// <param name="Filter">查询条件(例如: Name = 'name' and id=1 )</param>
		/// <param name="TableName">查询表名，可以指定联合查询的SQL语句(例如: Comment LEFT JOIN Users ON Comment.UserName = Users.UserName)</param>
		/// <param name="Total">输出参数：查询总数</param>
		/// <returns></returns>
		public virtual IList<NodesEntity> GetListBySortColumn(int startRowIndexId, int maxNumberRows, string PrimaryColumn, string SortColumnDbType, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total)
		{
			IList<NodesEntity> list = new List<NodesEntity>();
			if (string.IsNullOrEmpty(PrimaryColumn))
			{
				PrimaryColumn = "NodeID";
			}
			if (string.IsNullOrEmpty(SortColumnDbType))
			{
				SortColumnDbType = "int";
			}
			if (string.IsNullOrEmpty(SortColumn))
			{
				SortColumn = "NodeID";
			}
			if (string.IsNullOrEmpty(StrColumn))
			{
				StrColumn = "*";
			}
			if (string.IsNullOrEmpty(Sorts))
			{
				Sorts = "DESC";
			}
			if (string.IsNullOrEmpty(TableName))
			{
				TableName = "Nodes";
			}
			string storedProcedureName = "Common_GetListBySortColumn";
			SqlParameter parmStartRows = new SqlParameter("StartRows", startRowIndexId);
			SqlParameter parmPageSize = new SqlParameter("PageSize", maxNumberRows);
			SqlParameter parmPrimaryColumn = new SqlParameter("PrimaryColumn", PrimaryColumn);
			SqlParameter parmSortColumnDbType = new SqlParameter("SortColumnDbType", SortColumnDbType);
			SqlParameter parmSortColumn = new SqlParameter("SortColumn", SortColumn);
			SqlParameter parmStrColumn = new SqlParameter("StrColumn", StrColumn);
			SqlParameter parmSorts = new SqlParameter("Sorts", Sorts);
			SqlParameter parmTableName = new SqlParameter("TableName", TableName);
			SqlParameter parmFilter = new SqlParameter("Filter", Filter);
			SqlParameter parmTotal = new SqlParameter("Total", SqlDbType.Int);
			parmTotal.Direction = ParameterDirection.Output;
			IDataParameter[] parameterArray = new IDataParameter[10];
			parameterArray[0] = parmStartRows;
			parameterArray[1] = parmPageSize;
			parameterArray[2] = parmPrimaryColumn;
			parameterArray[3] = parmSortColumnDbType;
			parameterArray[4] = parmSortColumn;
			parameterArray[5] = parmStrColumn;
			parameterArray[6] = parmSorts;
			parameterArray[7] = parmTableName;
			parameterArray[8] = parmFilter;
			parameterArray[9] = parmTotal;
			using (NullableDataReader reader = _DB.GetDataReaderByProc(storedProcedureName, parameterArray))
			{
				while (reader.Read())
				{
					list.Add(GetEntityFromrdr(reader));
				}
			}
			Total = (int)parmTotal.Value;
			return list;
		}
		#endregion
		
		#region 辅助方法
		/// <summary>
		/// 把实体类转换成键/值对集合
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="dict"></param>
		private static void GetParameters(NodesEntity entity, Dictionary<string, object> dict)
		{
			dict.Add("NodeID", entity.NodeID);
			dict.Add("NodeIdentifier", entity.NodeIdentifier);
			dict.Add("NodeType", entity.NodeType);
			dict.Add("ParentID", entity.ParentID);
			dict.Add("ParentPath", entity.ParentPath);
			dict.Add("Depth", entity.Depth);
			dict.Add("RootID", entity.RootID);
			dict.Add("Child", entity.Child);
			dict.Add("arrChildID", entity.ArrChildID);
			dict.Add("PrevID", entity.PrevID);
			dict.Add("NextID", entity.NextID);
			dict.Add("OrderSort", entity.OrderSort);
			dict.Add("NodeDir", entity.NodeDir);
			dict.Add("ParentDir", entity.ParentDir);
			dict.Add("NodeName", entity.NodeName);
			dict.Add("Tips", entity.Tips);
			dict.Add("Description", entity.Description);
			dict.Add("NodePicUrl", entity.NodePicUrl);
			dict.Add("Meta_Keywords", entity.Meta_Keywords);
			dict.Add("Meta_Description", entity.Meta_Description);
			dict.Add("IsShowOnMenu", entity.IsShowOnMenu);
			dict.Add("IsShowOnPath", entity.IsShowOnPath);
			dict.Add("IsShowOnMap", entity.IsShowOnMap);
			dict.Add("IsShowOnList_Index", entity.IsShowOnList_Index);
			dict.Add("IsShowOnList_Parent", entity.IsShowOnList_Parent);
			dict.Add("PurviewType", entity.PurviewType);
			dict.Add("Creater", entity.Creater);
			dict.Add("InheritPurviewFromParent", entity.InheritPurviewFromParent);
			dict.Add("WorkFlowID", entity.WorkFlowID);
			dict.Add("HitsOfHot", entity.HitsOfHot);
			dict.Add("LeastOfEliteLevel", entity.LeastOfEliteLevel);
			dict.Add("OpenType", entity.OpenType);
			dict.Add("ItemCount", entity.ItemCount);
			dict.Add("ItemChecked", entity.ItemChecked);
			dict.Add("CommentCount", entity.CommentCount);
			dict.Add("Custom_Content", entity.Custom_Content);
			dict.Add("IsCreateListPage", entity.IsCreateListPage);
			dict.Add("IsCreateContentPage", entity.IsCreateContentPage);
			dict.Add("AutoCreateHtmlType", entity.AutoCreateHtmlType);
			dict.Add("ContentPageHtmlRule", entity.ContentPageHtmlRule);
			dict.Add("ListPageHtmlRule", entity.ListPageHtmlRule);
			dict.Add("ItemAspxFileName", entity.ItemAspxFileName);
			dict.Add("RelateNode", entity.RelateNode);
			dict.Add("RelateSpecial", entity.RelateSpecial);
			dict.Add("DefaultTemplateFile", entity.DefaultTemplateFile);
			dict.Add("ContainChildTemplateFile", entity.ContainChildTemplateFile);
			dict.Add("ItemOpenType", entity.ItemOpenType);
			dict.Add("ItemListOrderType", entity.ItemListOrderType);
			dict.Add("ItemPageSize", entity.ItemPageSize);
			dict.Add("UpLoadDirRule", entity.UpLoadDirRule);
			dict.Add("LinkUrl", entity.LinkUrl);
			dict.Add("Settings", entity.Settings);
			dict.Add("IPLock", entity.IPLock);
			dict.Add("ListPagePostFix", entity.ListPagePostFix);
			dict.Add("ListPageSavePathType", entity.ListPageSavePathType);
			dict.Add("IsNeedCreateHtml", entity.IsNeedCreateHtml);
			dict.Add("CultureName", entity.CultureName);
			dict.Add("IsSubDomain", entity.IsSubDomain);
			dict.Add("SubDomain", entity.SubDomain);
		}
		/// <summary>
		/// 通过数据读取器生成实体类
		/// </summary>
		/// <param name="rdr"></param>
		/// <returns></returns>
		private static NodesEntity GetEntityFromrdr(NullableDataReader rdr)
		{
			NodesEntity info = new NodesEntity();
			info.NodeID = rdr.GetInt32("NodeID");
			info.NodeIdentifier = rdr.GetString("NodeIdentifier");
			info.NodeType = rdr.GetInt32("NodeType");
			info.ParentID = rdr.GetInt32("ParentID");
			info.ParentPath = rdr.GetString("ParentPath");
			info.Depth = rdr.GetInt32("Depth");
			info.RootID = rdr.GetInt32("RootID");
			info.Child = rdr.GetInt32("Child");
			info.ArrChildID = rdr.GetString("arrChildID");
			info.PrevID = rdr.GetInt32("PrevID");
			info.NextID = rdr.GetInt32("NextID");
			info.OrderSort = rdr.GetInt32("OrderSort");
			info.NodeDir = rdr.GetString("NodeDir");
			info.ParentDir = rdr.GetString("ParentDir");
			info.NodeName = rdr.GetString("NodeName");
			info.Tips = rdr.GetString("Tips");
			info.Description = rdr.GetString("Description");
			info.NodePicUrl = rdr.GetString("NodePicUrl");
			info.Meta_Keywords = rdr.GetString("Meta_Keywords");
			info.Meta_Description = rdr.GetString("Meta_Description");
			info.IsShowOnMenu = rdr.GetBoolean("IsShowOnMenu");
			info.IsShowOnPath = rdr.GetBoolean("IsShowOnPath");
			info.IsShowOnMap = rdr.GetBoolean("IsShowOnMap");
			info.IsShowOnList_Index = rdr.GetBoolean("IsShowOnList_Index");
			info.IsShowOnList_Parent = rdr.GetBoolean("IsShowOnList_Parent");
			info.PurviewType = rdr.GetInt32("PurviewType");
			info.Creater = rdr.GetString("Creater");
			info.InheritPurviewFromParent = rdr.GetInt32("InheritPurviewFromParent");
			info.WorkFlowID = rdr.GetInt32("WorkFlowID");
			info.HitsOfHot = rdr.GetInt32("HitsOfHot");
			info.LeastOfEliteLevel = rdr.GetInt32("LeastOfEliteLevel");
			info.OpenType = rdr.GetInt32("OpenType");
			info.ItemCount = rdr.GetInt32("ItemCount");
			info.ItemChecked = rdr.GetInt32("ItemChecked");
			info.CommentCount = rdr.GetInt32("CommentCount");
			info.Custom_Content = rdr.GetString("Custom_Content");
			info.IsCreateListPage = rdr.GetBoolean("IsCreateListPage");
			info.IsCreateContentPage = rdr.GetBoolean("IsCreateContentPage");
			info.AutoCreateHtmlType = rdr.GetInt32("AutoCreateHtmlType");
			info.ContentPageHtmlRule = rdr.GetString("ContentPageHtmlRule");
			info.ListPageHtmlRule = rdr.GetString("ListPageHtmlRule");
			info.ItemAspxFileName = rdr.GetString("ItemAspxFileName");
			info.RelateNode = rdr.GetString("RelateNode");
			info.RelateSpecial = rdr.GetString("RelateSpecial");
			info.DefaultTemplateFile = rdr.GetString("DefaultTemplateFile");
			info.ContainChildTemplateFile = rdr.GetString("ContainChildTemplateFile");
			info.ItemOpenType = rdr.GetInt32("ItemOpenType");
			info.ItemListOrderType = rdr.GetInt32("ItemListOrderType");
			info.ItemPageSize = rdr.GetInt32("ItemPageSize");
			info.UpLoadDirRule = rdr.GetString("UpLoadDirRule");
			info.LinkUrl = rdr.GetString("LinkUrl");
			info.Settings = rdr.GetString("Settings");
			info.IPLock = rdr.GetString("IPLock");
			info.ListPagePostFix = rdr.GetString("ListPagePostFix");
			info.ListPageSavePathType = rdr.GetInt32("ListPageSavePathType");
			info.IsNeedCreateHtml = rdr.GetBoolean("IsNeedCreateHtml");
			info.CultureName = rdr.GetString("CultureName");
			info.IsSubDomain = rdr.GetBoolean("IsSubDomain");
			info.SubDomain = rdr.GetString("SubDomain");
			return info;
		}
		#endregion
	}
}