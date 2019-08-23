using JX.Core.Entity;
using JX.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JX.Application
{
	/// <summary>
	/// 数据库表：UserGroups 的应用层服务接口.
	/// </summary>
	public partial interface IUserGroupsServiceApp : IServiceApp<UserGroupsEntity>
	{
		#region 删除会员组和相关权限
		/// <summary>
		/// 通过主键删除会员组。
		/// 1、删除字段的权限设置。
		/// 2、删除节点的权限设置。
		/// 3、删除专题的权限设置。
		/// 4、删除会员组的权限设置。
		/// </summary>
		/// <param name="groupID"></param>
		/// <returns></returns>
		Task<bool> DeleteFullAsync(int groupID);

		/// <summary>
		/// 移除指定会员组的所有模型字段权限
		/// </summary>
		/// <param name="groupID">会员组ID，小于等于0表示所有会员组，-2表示匿名会员组</param>
		/// <param name="idType">权限类型 0：单独设置会员权限；1：继承自会员组权限；</param>
		/// <returns></returns>
		Task<bool> DeleteFieldPermissionFromGroup(int groupID=0,int idType=1);

		/// <summary>
		/// 移除指定会员组的所有节点权限
		/// </summary>
		/// <param name="groupID">会员组ID，小于等于0表示所有会员组，-2表示匿名会员组</param>
		/// <param name="nodeId">节点ID，小于等于-3表示所有节点</param>
		/// <param name="operateCode">权限码</param>
		/// <param name="idType">权限类型 0：单独设置会员权限；1：继承自会员组权限；</param>
		/// <returns></returns>
		Task<bool> DeleteNodePermissionFromGroup(int groupID = 0, int nodeId = -3, OperateCode operateCode = OperateCode.None, int idType = 1);

		/// <summary>
		/// 移除指定会员组的所有专题权限
		/// </summary>
		/// <param name="groupID">会员组ID，小于等于0表示所有会员组，-2表示匿名会员组</param>
		/// <param name="specialId">专题ID，小于等于0表示所有专题</param>
		/// <param name="operateCode">权限码</param>
		/// <param name="idType">权限类型 0：单独设置会员权限；1：继承自会员组权限；</param>
		/// <returns></returns>
		Task<bool> DeleteSpecialPermissionFromGroup(int groupID = 0, int specialId = 0, OperateCode operateCode = OperateCode.None, int idType = 1);
		#endregion

		#region 会员组－节点权限管理
		/// <summary>
		/// 添加节点权限到会员组
		/// </summary>
		/// <param name="groupId"></param>
		/// <param name="nodeIdAndOperateCode">节点ID与权限码的集合体，多个内容用“,”分隔（例：-2:101005001,-2:101005002）</param>
		/// <param name="idType">权限类型 0：单独设置会员权限；1：继承自会员组权限；</param>
		/// <returns></returns>
		Task<bool> AddNodePermissionToUserGroup(int groupId, string nodeIdAndOperateCode, int idType = 1);
		/// <summary>
		/// 获取指定会员组、指定节点的权限列表
		/// </summary>
		/// <param name="groupId">会员组ID，小于等于0表示所有会员组，-2表示匿名会员组</param>
		/// <param name="nodeId">节点ID，小于等于-3表示所有节点，-2表示首页节点</param>
		/// <param name="operateCode">权限码</param>
		/// <param name="idType">权限类型 0：单独设置会员权限；1：继承自会员组权限；</param>
		/// <returns></returns>
		Task<IList<GroupNodePermissionsEntity>> GetNodePermissionsById(int groupId = 0, int nodeId = -3, OperateCode operateCode = OperateCode.None, int idType=1);
		#endregion

		#region 会员组－专题权限管理
		#endregion

		#region 会员组－模型字段权限管理
		/// <summary>
		/// 添加模型字段权限到会员组
		/// </summary>
		/// <param name="groupId"></param>
		/// <param name="operateCodes">权限码</param>
		/// <param name="modelIdAndFieldName">模型ID与字段名的集合体，多个内容用“,”分隔（例：11:FieldName,11:FieldName1）</param>
		/// <param name="idType">权限类型 0：单独设置会员权限；1：继承自会员组权限；</param>
		/// <returns></returns>
		Task<bool> AddFieldPermissionToUserGroup(int groupId, OperateCode operateCodes, string modelIdAndFieldName, int idType = 1);
		/// <summary>
		/// 获取指定会员组、指定模型的字段权限列表
		/// </summary>
		/// <param name="groupId">会员组ID，小于等于0表示所有会员组，-2表示匿名会员组</param>
		/// <param name="modelId">模型ID，小于等于0表示所有模型</param>
		/// <param name="idType">权限类型 0：单独设置会员权限；1：继承自会员组权限；</param>
		/// <returns></returns>
		Task<IList<GroupFieldPermissionsEntity>> GetFieldPermissionsById(int groupId = 0, int modelId = 0, int idType = 1);
		#endregion

		/// <summary>
		/// 计算会员组集合里的会员总数
		/// </summary>
		/// <param name="userGroupsList"></param>
		void CountUserNumber(IList<UserGroupsEntity> userGroupsList);
		/// <summary>
		/// 判断会员组是否存在
		/// </summary>
		/// <param name="groupName">会员组名称</param>
		/// <returns></returns>
		bool UserGroupIsExist(string groupName);
	}
}