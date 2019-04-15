using JX.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JX.Application
{
	/// <summary>
	/// 数据库表：Roles 的应用层服务接口.
	/// </summary>
	public partial interface IRolesServiceApp : IServiceApp<RolesEntity>
	{
		#region 删除角色和相关权限
		/// <summary>
		/// 通过主键删除角色。
		/// 1、删除字段的权限设置。
		/// 2、删除节点的权限设置。
		/// 3、删除专题的权限设置。
		/// 4、删除角色的权限设置。
		/// 5、删除角色和与管理员的关系。
		/// </summary>
		/// <returns></returns>
		bool DeleteFull(System.Int32 roleID);
		/// <summary>
		/// 通过主键删除角色。
		/// 1、删除字段的权限设置。
		/// 2、删除节点的权限设置。
		/// 3、删除专题的权限设置。
		/// 4、删除角色的权限设置。
		/// 5、删除角色和与管理员的关系。
		/// </summary>
		/// <returns></returns>
		Task<bool> DeleteFullAsync(System.Int32 roleID);

		/// <summary>
		/// 移除指定角色的所有常规权限
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		Task<bool> DeletePermissionFromRoles(int roleID);

		/// <summary>
		/// 移除指定角色的所有模型字段权限
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		Task<bool> DeleteFieldPermissionFromRoles(int roleID);

		/// <summary>
		/// 移除指定角色的所有节点权限
		/// </summary>
		/// <param name="roleID">角色ID，小于等于-1表示所有角色</param>
		/// <param name="nodeId">节点ID，小于等于-3表示所有节点</param>
		/// <param name="operateCode">权限码</param>
		/// <returns></returns>
		Task<bool> DeleteNodePermissionFromRoles(int roleID = -1, int nodeId = -3, OperateCode operateCode=OperateCode.None);

		/// <summary>
		/// 移除指定角色的所有专题权限
		/// </summary>
		/// <param name="roleID">角色ID，小于等于-1表示所有角色</param>
		/// <param name="specialId">专题ID，小于等于0表示所有专题</param>
		/// <param name="operateCode">权限码</param>
		/// <returns></returns>
		Task<bool> DeleteSpecialPermissionFromRoles(int roleID = -1, int specialId = 0, OperateCode operateCode = OperateCode.None);
		#endregion

		#region 角色成员管理
		/// <summary>
		/// 得到属于指定角色的管理员列表，管理员不包括扩展属性
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		Task<IList<AdminEntity>> GetMemberListByRoleID(int roleID);

		/// <summary>
		/// 得到不属于指定角色的管理员列表，管理员不包括扩展属性
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		Task<IList<AdminEntity>> GetMemberListNotInRole(int roleID);

		/// <summary>
		/// 添加管理员到角色
		/// </summary>
		/// <param name="admins">管理员ID，多个ID用“,”分隔</param>
		/// <param name="roleId"></param>
		/// <returns></returns>
		Task<bool> AddMembersToRole(string admins, int roleId);
		#endregion

		#region 角色－菜单权限管理
		/// <summary>
		/// 添加常规权限到角色
		/// </summary>
		/// <param name="roleID"></param>
		/// <param name="operateCodes">多个权限码用“,”分隔</param>
		/// <returns></returns>
		Task<bool> AddPermissionToRoles(int roleID, string operateCodes);

		/// <summary>
		/// 得到指定角色的所有权限码
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		Task<IList<RolesPermissionsEntity>> GetRolesPermissionsByRoleID(int roleID);

		/// <summary>
		/// 得到指定权限码的所有角色
		/// </summary>
		/// <param name="operateCode"></param>
		/// <returns></returns>
		Task<IList<RolesPermissionsEntity>> GetRolesPermissionsByOperateCode(string operateCode);
		#endregion

		#region 角色－节点权限管理
		/// <summary>
		/// 添加模型字段权限到角色
		/// </summary>
		/// <param name="roleID"></param>
		/// <param name="nodeIdAndOperateCode">节点ID与权限码的集合体，多个内容用“,”分隔（例：-2:101005001,-2:101005002）</param>
		/// <returns></returns>
		Task<bool> AddNodePermissionToRoles(int roleID, string nodeIdAndOperateCode);
		/// <summary>
		/// 获取指定角色、指定节点的权限列表
		/// </summary>
		/// <param name="roleId">角色ID，小于等于-1表示所有角色</param>
		/// <param name="nodeId">节点ID，小于等于-3表示所有节点</param>
		/// <returns></returns>
		Task<IList<RoleNodePermissionsEntity>> GetNodePermissionsById(int roleId=-1, int nodeId=-3);
		#endregion

		#region 角色－模型字段权限管理
		/// <summary>
		/// 添加模型字段权限到角色
		/// </summary>
		/// <param name="roleID"></param>
		/// <param name="operateCodes">权限码</param>
		/// <param name="modelIdAndFieldName">模型ID与字段名的集合体，多个内容用“,”分隔（例：11:FieldName,11:FieldName1）</param>
		/// <returns></returns>
		Task<bool> AddFieldPermissionToRoles(int roleID, OperateCode operateCodes,string modelIdAndFieldName);

		/// <summary>
		/// 获取指定角色、指定模型的字段权限列表
		/// </summary>
		/// <param name="roleId">角色ID，小于等于-1表示所有角色</param>
		/// <param name="modelId">模型ID，小于等于0表示所有模型</param>
		/// <returns></returns>
		Task<IList<RoleFieldPermissionsEntity>> GetFieldPermissionsById(int roleId=-1,int modelId=0);
		#endregion
	}
}