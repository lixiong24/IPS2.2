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

		#region 常规权限管理
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
			List<string> listCacheKey = new List<string>();
			var arrOperateCodes = operateCodes.Split(split, StringSplitOptions.RemoveEmptyEntries);
			arrOperateCodes = StringHelper.RemoveRepeatItem(arrOperateCodes);
			foreach (string str in arrOperateCodes)
			{
				if (!string.IsNullOrEmpty(str) && (str != "None"))
				{
					listCacheKey.Add("CK_OperatorCode_" + str);
					await _RolesPermissionsRepository.AddAsync(new RolesPermissionsEntity() { RoleID = roleID, OperateCode = str });
				}
			}
			CacheHelper.CacheServiceProvider.RemoveAll(listCacheKey);
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

		#region 节点权限管理
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
	}
}