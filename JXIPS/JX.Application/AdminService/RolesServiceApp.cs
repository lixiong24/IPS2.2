using AutoMapper;
using JX.Core;
using JX.Core.Entity;
using JX.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JX.Application
{
	/// <summary>
	/// 数据库表：Roles 的应用层服务接口实现类.
	/// </summary>
	public partial class RolesServiceApp : IRolesServiceApp
	{
		private char[] split = new char[] { ',' };
		
		#region 仓储接口
		private readonly IAdminRepository _AdminRepository;
		private readonly IAdminRolesRepository _AdminRolesRepository;
		private readonly IRolesPermissionsRepository _RolesPermissionsRepository;
		private readonly IRoleFieldPermissionsRepository _RoleFieldPermissionsRepository;
		private readonly IRoleNodePermissionsRepository _RoleNodePermissionsRepository;
		private readonly IRoleSpecialPermissionsRepository _RoleSpecialPermissionsRepository;
		private readonly ILogRepository _LogRepository;
		/// <summary>
		/// 构造器注入
		/// </summary>
		/// <param name="repository"></param>
		/// <param name="adminRepository"></param>
		/// <param name="adminRolesRepository"></param>
		/// <param name="rolesPermissionsRepository"></param>
		/// <param name="roleFieldPermissionsRepository"></param>
		/// <param name="roleNodePermissionsRepository"></param>
		/// <param name="roleSpecialPermissionsRepository"></param>
		/// <param name="logRepository"></param>
		public RolesServiceApp(IRolesRepository repository,
			IAdminRepository adminRepository,
			IAdminRolesRepository adminRolesRepository,
			IRolesPermissionsRepository rolesPermissionsRepository,
			IRoleFieldPermissionsRepository roleFieldPermissionsRepository,
			IRoleNodePermissionsRepository roleNodePermissionsRepository,
			IRoleSpecialPermissionsRepository roleSpecialPermissionsRepository,
			ILogRepository logRepository)
		{
			_repository = repository;
			_AdminRepository = adminRepository;
			_AdminRolesRepository = adminRolesRepository;
			_RolesPermissionsRepository = rolesPermissionsRepository;
			_RoleFieldPermissionsRepository = roleFieldPermissionsRepository;
			_RoleNodePermissionsRepository = roleNodePermissionsRepository;
			_RoleSpecialPermissionsRepository = roleSpecialPermissionsRepository;
			_LogRepository = logRepository;
		}
		#endregion

		#region 删除角色和相关权限
		/// <summary>
		/// 通过主键删除角色。
		/// 1、删除字段的权限设置。
		/// 2、删除节点的权限设置。
		/// 3、删除专题的权限设置。
		/// 4、删除角色的权限设置。
		/// </summary>
		/// <returns></returns>
		public bool DeleteFull(System.Int32 roleID)
		{
			if (roleID <= 0)
			{
				return false;
			}
			DeleteRoleRelation(roleID);
			return Delete(p=>p.RoleID== roleID);
		}
		/// <summary>
		/// 通过主键删除角色。
		/// 1、删除字段的权限设置。
		/// 2、删除节点的权限设置。
		/// 3、删除专题的权限设置。
		/// 4、删除角色的权限设置。
		/// </summary>
		/// <returns></returns>
		public async Task<bool> DeleteFullAsync(System.Int32 roleID)
		{
			if (roleID <= 0)
			{
				return false;
			}
			DeleteRoleRelation(roleID);
			return await DeleteAsync(p => p.RoleID == roleID);
		}

		/// <summary>
		/// 移除指定角色的所有常规权限
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		public async Task<bool> DeletePermissionFromRoles(int roleID)
		{
			return await _RolesPermissionsRepository.DeletePermissionFromRolesAsync(roleID);
		}

		/// <summary>
		/// 移除指定角色的所有模型字段权限
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		public async Task<bool> DeleteFieldPermissionFromRoles(int roleID)
		{
			return await _RoleFieldPermissionsRepository.DeleteFieldPermissionFromRolesAsync(roleID);
		}

		/// <summary>
		/// 移除指定角色的所有节点权限
		/// </summary>
		/// <param name="roleID">角色ID，小于等于-1表示所有角色</param>
		/// <param name="nodeId">节点ID，小于等于-3表示所有节点</param>
		/// <param name="operateCode">权限码</param>
		/// <returns></returns>
		public async Task<bool> DeleteNodePermissionFromRoles(int roleID = -1, int nodeId = -3, OperateCode operateCode = OperateCode.None)
		{
			string strCode = "";
			if(operateCode != OperateCode.None)
			{
				strCode = ((int)operateCode).ToString();
			}
			string strNodeID = "";
			if(nodeId > -3)
			{
				strNodeID = nodeId.ToString();
			}
			return await _RoleNodePermissionsRepository.DeleteNodePermissionFromRolesAsync(roleID, strNodeID, strCode);
		}

		/// <summary>
		/// 移除指定角色的所有专题权限
		/// </summary>
		/// <param name="roleID">角色ID，小于等于-1表示所有角色</param>
		/// <param name="specialId">专题ID，小于等于0表示所有专题</param>
		/// <param name="operateCode">权限码</param>
		/// <returns></returns>
		public async Task<bool> DeleteSpecialPermissionFromRoles(int roleID = -1, int specialId = 0, OperateCode operateCode = OperateCode.None)
		{
			string strCode = "";
			if (operateCode != OperateCode.None)
			{
				strCode = ((int)operateCode).ToString();
			}
			string strSpecialID = "";
			if (specialId > 0)
			{
				strSpecialID = specialId.ToString();
			}
			return await _RoleSpecialPermissionsRepository.DeleteSpecialPermissionFromRolesAsync(roleID, strSpecialID, strCode);
		}

		/// <summary>
		/// 删除角色相关的所有权限
		/// </summary>
		/// <param name="roleId"></param>
		private void DeleteRoleRelation(int roleId)
		{
			_RolesPermissionsRepository.DeletePermissionFromRoles(roleId);
			_RoleFieldPermissionsRepository.DeleteFieldPermissionFromRoles(roleId);
			_RoleNodePermissionsRepository.DeleteNodePermissionFromRoles(roleId);
			_RoleSpecialPermissionsRepository.DeleteSpecialPermissionFromRoles(roleId);
			_AdminRolesRepository.RemoveAdminFromRolesByRoleId(roleId);
		}
		#endregion

		#region 角色成员管理
		/// <summary>
		/// 得到属于指定角色的管理员列表，管理员不包括扩展属性
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		public async Task<IList<AdminEntity>> GetMemberListByRoleID(int roleID)
		{
			var entityList = await _AdminRepository.LoadListAllBySqlAsync("select * from Admin where AdminID IN (SELECT AdminID FROM AdminRoles WHERE (RoleID = @RoleID))", new SqlParameter("RoleID", roleID));
			return entityList;
		}

		/// <summary>
		/// 得到不属于指定角色的管理员列表，管理员不包括扩展属性
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		public async Task<IList<AdminEntity>> GetMemberListNotInRole(int roleID)
		{
			var entityList = await _AdminRepository.LoadListAllBySqlAsync("select * from Admin where AdminID NOT IN (SELECT AdminID FROM AdminRoles WHERE (RoleID = @RoleID))", new SqlParameter("RoleID", roleID));
			return entityList;
		}

		/// <summary>
		/// 添加管理员到角色
		/// </summary>
		/// <param name="admins">管理员ID，多个ID用“,”分隔</param>
		/// <param name="roleId"></param>
		/// <returns></returns>
		public async Task<bool> AddMembersToRole(string admins, int roleId)
		{
			_AdminRolesRepository.RemoveAdminFromRolesByRoleId(roleId);
			if (!string.IsNullOrEmpty(admins))
			{
				foreach (string str in admins.Split(split, StringSplitOptions.RemoveEmptyEntries))
				{
					await _AdminRolesRepository.AddAsync(new AdminRolesEntity() { AdminID = DataConverter.CLng(str), RoleID = roleId });
				}
			}
			return true;
		}
		#endregion

		#region 角色－菜单权限管理
		/// <summary>
		/// 添加权限到角色，并清除对应权限的缓存数据
		/// </summary>
		/// <param name="roleID"></param>
		/// <param name="operateCodes">多个权限码用“,”分隔</param>
		/// <returns></returns>
		public async Task<bool> AddPermissionToRoles(int roleID, string operateCodes)
		{
			if (roleID <= 0 || string.IsNullOrEmpty(operateCodes))
				return false;
			//List<string> listCacheKey = new List<string>();
			var arrOperateCodes = operateCodes.Split(split, StringSplitOptions.RemoveEmptyEntries);
			arrOperateCodes = StringHelper.RemoveRepeatItem(arrOperateCodes);
			foreach (string str in arrOperateCodes)
			{
				if (!string.IsNullOrEmpty(str) && (str != "None"))
				{
					//listCacheKey.Add(CK_RolePermission_OperatorCode_Pre + str);
					await _RolesPermissionsRepository.AddAsync(new RolesPermissionsEntity() { RoleID = roleID, OperateCode = str });
				}
			}
			//CacheHelper.CacheServiceProvider.RemoveAll(listCacheKey);
			return true;
		}

		/// <summary>
		/// 得到指定角色的所有权限码
		/// </summary>
		/// <param name="roleID"></param>
		/// <returns></returns>
		public async Task<IList<RolesPermissionsEntity>> GetRolesPermissionsByRoleID(int roleID)
		{
			var entityList = await _RolesPermissionsRepository.LoadListAllAsync(p=>p.RoleID==roleID);
			return entityList;
		}

		/// <summary>
		/// 得到指定权限码的所有角色
		/// </summary>
		/// <param name="operateCode"></param>
		/// <returns></returns>
		public async Task<IList<RolesPermissionsEntity>> GetRolesPermissionsByOperateCode(string operateCode)
		{
			var entityList = await _RolesPermissionsRepository.LoadListAllAsync(p => p.OperateCode == operateCode);
			return entityList;
		}
		#endregion

		#region 角色－节点权限管理
		/// <summary>
		/// 添加模型字段权限到角色
		/// </summary>
		/// <param name="roleID"></param>
		/// <param name="nodeIdAndOperateCode">节点ID与权限码的集合体，多个内容用“,”分隔（例：-2:101005001,-2:101005002）</param>
		/// <returns></returns>
		public async Task<bool> AddNodePermissionToRoles(int roleID, string nodeIdAndOperateCode)
		{
			if (roleID <= 0 || string.IsNullOrEmpty(nodeIdAndOperateCode))
				return false;

			var arrNodeIdAndOperateCode = nodeIdAndOperateCode.Split(split, StringSplitOptions.RemoveEmptyEntries);
			arrNodeIdAndOperateCode = StringHelper.RemoveRepeatItem(arrNodeIdAndOperateCode);
			foreach (string strItem in arrNodeIdAndOperateCode)
			{
				if (!string.IsNullOrEmpty(strItem))
				{
					var arrItem = strItem.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
					var nodeID = DataConverter.CLng(arrItem[0]);
					var operateCodes = arrItem[1];

					await _RoleNodePermissionsRepository.AddAsync(new RoleNodePermissionsEntity() { RoleID = roleID, OperateCode = operateCodes,NodeID=nodeID});
				}
			}
			return true;
		}
		/// <summary>
		/// 获取指定角色、指定节点的权限列表
		/// </summary>
		/// <param name="roleId">角色ID，小于等于-1表示所有角色</param>
		/// <param name="nodeId">节点ID，小于等于-3表示所有节点，-2表示首页节点</param>
		/// <returns></returns>
		public async Task<IList<RoleNodePermissionsEntity>> GetNodePermissionsById(int roleId = -1, int nodeId = -3)
		{
			Expression<Func<RoleNodePermissionsEntity, bool>> predicate = p => true;
			if (roleId >= 0)
			{
				predicate = predicate.And(p => p.RoleID==roleId);
			}
			if (nodeId >= -2)
			{
				predicate = predicate.And(p => p.NodeID == nodeId);
			}
			var entityList = await _RoleNodePermissionsRepository.LoadListAllAsync(predicate);
			return entityList;
		}
		#endregion

		#region 角色－模型字段权限管理
		/// <summary>
		/// 添加模型字段权限到角色
		/// </summary>
		/// <param name="roleID"></param>
		/// <param name="operateCodes">权限码</param>
		/// <param name="modelIdAndFieldName">模型ID与字段名的集合体，多个内容用“,”分隔（例：11:FieldName,11:FieldName1）</param>
		/// <returns></returns>
		public async Task<bool> AddFieldPermissionToRoles(int roleID, OperateCode operateCodes, string modelIdAndFieldName)
		{
			if (roleID <= 0 || string.IsNullOrEmpty(modelIdAndFieldName))
				return false;

			var arrModelIdAndFieldName = modelIdAndFieldName.Split(split, StringSplitOptions.RemoveEmptyEntries);
			arrModelIdAndFieldName = StringHelper.RemoveRepeatItem(arrModelIdAndFieldName);
			foreach (string strItem in arrModelIdAndFieldName)
			{
				if (!string.IsNullOrEmpty(strItem))
				{
					var arrItem = strItem.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
					var modelID = DataConverter.CLng(arrItem[0]);
					var fieldName = arrItem[1];

					await _RoleFieldPermissionsRepository.AddAsync(new RoleFieldPermissionsEntity() { RoleID = roleID, OperateCode = ((int)operateCodes).ToString(), ModelID = modelID, FieldName = fieldName });
				}
			}
			return true;
		}
		/// <summary>
		/// 获取指定角色、指定模型的字段权限列表
		/// </summary>
		/// <param name="roleId">角色ID，小于等于-1表示所有角色</param>
		/// <param name="modelId">模型ID，小于等于0表示所有模型</param>
		/// <returns></returns>
		public async Task<IList<RoleFieldPermissionsEntity>> GetFieldPermissionsById(int roleId = -1, int modelId = 0)
		{
			Expression<Func<RoleFieldPermissionsEntity, bool>> predicate = p => true;
			if (roleId >= 0)
			{
				predicate = predicate.And(p => p.RoleID == roleId);
			}
			if (modelId > 0)
			{
				predicate = predicate.And(p => p.ModelID == modelId);
			}
			var entityList = await _RoleFieldPermissionsRepository.LoadListAllAsync(predicate);
			return entityList;
		}
		#endregion
	}
}