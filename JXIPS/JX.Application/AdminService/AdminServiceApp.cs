using AutoMapper;
using JX.Core;
using JX.Core.Entity;
using JX.Infrastructure;
using JX.Infrastructure.Common;
using JX.Infrastructure.Framework;
using JX.Infrastructure.Framework.Authorize;
using JX.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JX.Application
{
	/// <summary>
	/// 数据库表：AdminEntity 的应用层服务接口实现类.
	/// </summary>
	public partial class AdminServiceApp : IAdminServiceApp
	{
		#region 仓储接口
		private readonly IRolesRepository _RolesRepository;
		private readonly IAdminRolesRepository _AdminRolesRepository;
		private readonly IRolesPermissionsRepository _RolesPermissionsRepository;
		private readonly ILogRepository _LogRepository;
		/// <summary>
		/// 构造器注入
		/// </summary>
		/// <param name="repository"></param>
		/// <param name="rolesRepository"></param>
		/// <param name="adminRolesRepository"></param>
		/// <param name="rolesPermissionsRepository"></param>
		/// <param name="logRepository"></param>
		public AdminServiceApp(IAdminRepository repository,
			IRolesRepository rolesRepository,
			IAdminRolesRepository adminRolesRepository,
			IRolesPermissionsRepository rolesPermissionsRepository,
			ILogRepository logRepository)
		{
			_repository = repository;
			_RolesRepository = rolesRepository;
			_AdminRolesRepository = adminRolesRepository;
			_RolesPermissionsRepository = rolesPermissionsRepository;
			_LogRepository = logRepository;
		}
		#endregion

		#region 得到实体，包括扩展属性
		/// <summary>
		/// 通过主键返回第一条信息的实体类，包括扩展属性。
		/// </summary>
		/// <returns></returns>
		public AdminEntity GetFull(System.Int32 adminID)
		{
			var entity = _repository.GetEntityFull(adminID);
			return entity;
		}
		/// <summary>
		/// 通过主键返回第一条信息的实体类，包括扩展属性。
		/// </summary>
		/// <returns></returns>
		public async Task<AdminEntity> GetFullAsync(System.Int32 adminID)
		{
			var entity = await _repository.GetEntityFullAsync(adminID);
			return entity;
		}

		/// <summary>
		/// 获取实体，包括扩展属性
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public virtual AdminEntity GetFull(Expression<Func<AdminEntity, bool>> predicate)
		{
			var entity = _repository.GetEntityFull(predicate);
			return entity;
		}
		/// <summary>
		/// 获取实体，包括扩展属性（异步方式）
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public virtual async Task<AdminEntity> GetFullAsync(Expression<Func<AdminEntity, bool>> predicate)
		{
			var entity = await _repository.GetEntityFullAsync(predicate);
			return entity;
		}

		/// <summary>
		/// 为实体添加RoleIDs和RoleNames两个属性的值
		/// </summary>
		/// <param name="admin"></param>
		/// <returns></returns>
		public AdminEntity GetAdminFull(AdminEntity admin)
		{
			if (admin == null)
				return admin;
			var entity = _repository.GetAdminFull(admin);
			return entity;
		}
		#endregion

		#region 得到实体列表，包括扩展属性
		/// <summary>
		/// 得到实体列表，包括扩展属性
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public virtual IList<AdminEntity> GetFullList(Expression<Func<AdminEntity, bool>> predicate)
		{
			var entity = _repository.GetEntityFullList(predicate);
			return entity;
		}
		/// <summary>
		/// 得到实体列表，包括扩展属性（异步方式）
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public virtual async Task<IList<AdminEntity>> GetFullListAsync(Expression<Func<AdminEntity, bool>> predicate)
		{
			var entity = await _repository.GetEntityFullListAsync(predicate);
			return entity;
		}
		#endregion

		#region 得到分页，包括扩展属性
		/// <summary>
		/// 通过存储过程“Common_GetList”，得到管理员分页后的数据，包括扩展属性
		/// </summary>
		/// <param name="startRowIndexId">开始行索引</param>
		/// <param name="maxNumberRows">每页最大显示数量</param>
		/// <param name="Filter">查询条件(例如: Name = 'name' and id=1 )</param>
		/// <param name="Total">输出参数：查询总数</param>
		/// <returns></returns>
		public IList<AdminEntity> GetListFull(int startRowIndexId, int maxNumberRows, string Filter, out int Total)
		{
			Total = 0;
			var entityList = _repository.GetList(startRowIndexId, maxNumberRows,"AdminID"," * ", "DESC", Filter,"AdminEntity", out Total);
			foreach (var entity in entityList)
			{
				_repository.GetAdminFull(entity);
			}
			return entityList;
		}
		#endregion

		#region 登录、退出、修改密码
		/// <summary>
		/// 管理员登录。
		/// 1、登录失败，记录登录错误次数，记录登录日志。
		/// 2、登录成功，清空登录错误次数，记录登录日志。
		/// </summary>
		/// <param name="adminName"></param>
		/// <param name="adminPassword">明文密码</param>
		/// <param name="manageCode">管理认证码</param>
		/// <param name="isCheckManageCode">是否启用管理认证码检查</param>
		/// <returns></returns>
		public async Task<IdentityResult> Login(string adminName, string adminPassword, string manageCode = "", bool isCheckManageCode = true)
		{
			//检查管理认证码
			if(isCheckManageCode)
			{
				SiteOptionConfig siteOptionConfig = ConfigHelper.Get<SiteOptionConfig>();
				if (siteOptionConfig.EnableSiteManageCode && (manageCode.Trim() != siteOptionConfig.SiteManageCode))
				{
					await _repository.CumulativeLoginErrTimes(adminName);
					return new IdentityResult("您输入的管理认证码不正确，请重新输入。");
				}
			}
			
			//得到实体
			AdminEntity admin = await _repository.GetEntityAsync(adminName, adminPassword);
			if (admin == null || admin.AdminID <= 0)
			{
				await _repository.CumulativeLoginErrTimes(adminName);
				_LogRepository.SaveLog("管理员登录失败！用户名：" + adminName, "输入的用户名或密码不正确", adminName, LogCategory.LogOnFailure, LogPriority.Highest);
				return new IdentityResult("您输入的用户名或密码不正确，请重新输入。");
			}
			//检查是否锁定
			if (admin.IsLock)
			{
				_LogRepository.SaveLog("管理员登录失败！用户名：" + adminName, "账号已锁定", adminName, LogCategory.LogOnFailure, LogPriority.Highest);
				return new IdentityResult("账号已锁定。");
			}
			//检查密码的HASH值
			bool isHash = await _repository.AuthenticatePassHash(adminName);
			if (!isHash)
			{
				await _repository.CumulativeLoginErrTimes(adminName);
				_LogRepository.SaveLog("管理员登录失败！用户名：" + adminName, "登录失败,数据被非法修改,请检查数据的有效性!", adminName, LogCategory.LogOnFailure, LogPriority.Highest);
				return new IdentityResult("数据被非法修改,请检查数据的有效性!");
			}
			//重置登录错误次数、记录登录成功日志、创建返回类
			admin.LoginErrorTimes = 0;
			admin.LoginTimes += 1;
			admin.LoginTime = DateTime.Now;
			admin.LoginIP = Utility.GetClientIP();
			admin.RndPassword = DataSecurity.MakeRandomString(16);
			await _repository.UpdateAsync(admin);
			_LogRepository.SaveLog("管理员登录成功！用户名：" + adminName, "管理员登录成功", adminName, LogCategory.LogOnOk);
			return new IdentityResult(CreateClaimsIdentity(admin));
		}

		/// <summary>
		/// 管理员退出。
		/// </summary>
		/// <param name="claimsPrincipal"></param>
		/// <returns></returns>
		public async Task<bool> Logout(ClaimsPrincipal claimsPrincipal)
		{
			var adminID = (from c in claimsPrincipal.Claims
						   where c.Type == ClaimTypes.Sid
						   select c.Value).FirstOrDefault();
			//得到实体
			AdminEntity admin = await _repository.GetAsync(p=>p.AdminID== DataConverter.CLng(adminID));
			if (admin != null && admin.AdminID > 0)
			{
				admin.LogoutTime = DateTime.Now;
				await _repository.UpdateAsync(admin);
				_LogRepository.SaveLog("管理员退出成功！用户名：" + admin.AdminName, "管理员退出成功", admin.AdminName, LogCategory.LogOff);
			}
			return true;
		}

		/// <summary>
		/// 修改管理员密码。成功返回“ok”，失败返回错误原因。
		/// </summary>
		/// <param name="claimsPrincipal">当前登录管理员</param>
		/// <param name="oldPwd">旧密码</param>
		/// <param name="newPwd">新密码</param>
		/// <returns></returns>
		public async Task<string> ModifyPassword(ClaimsPrincipal claimsPrincipal, string oldPwd, string newPwd)
		{
			if (claimsPrincipal == null)
				return "管理员不存在";
			if (string.IsNullOrEmpty(oldPwd))
				return "旧密码不能为空";
			if (string.IsNullOrEmpty(newPwd))
				return "新密码不能为空";
			AdminEntity admin = await _repository.GetEntityByAdminNameAsync(claimsPrincipal.FindFirst(ClaimTypes.Name).Value);
			if (admin == null || admin.AdminID <= 0)
				return "管理员不存在";
			if (admin.IsLock || !admin.IsModifyPassword)
			{
				return "您没有修改自己密码的权限，请与超级管理员联系！";
			}
			if (StringHelper.ValidateMD5(StringHelper.MD5(oldPwd), admin.AdminPassword))
			{
				admin.AdminPassword = StringHelper.MD5(newPwd);
				admin.ModifyPasswordTime = new DateTime?(DateTime.Now);
				admin.Hash = await _repository.GetAuthenticatePassHash(admin.AdminPassword);
				if (_repository.Update(admin))
				{
					return "ok";
				}
				else
				{
					return "修改密码失败！";
				}
			}
			else
			{
				return "您的旧密码不对，请与超级管理员联系！";
			}
		}
		#endregion

		#region 添加、修改、删除管理员
		/// <summary>
		/// 添加管理员，并设置所属角色。成功返回“ok”，失败返回错误消息。
		/// </summary>
		/// <param name="AdminEntity"></param>
		/// <returns></returns>
		public async Task<string> AddAdminFull(AdminEntity AdminEntity)
		{
			if (AdminEntity == null)
				return "没有指定管理员信息，添加失败";
			if (string.IsNullOrEmpty(AdminEntity.AdminName))
				return "管理员名称不能为空";
			if (string.IsNullOrEmpty(AdminEntity.AdminPassword))
				return "管理员密码不能为空";
			if (await _repository.IsExistAsync(AdminEntity.AdminName))
			{
				return "已经存在同样的管理员名！";
			}
			AdminEntity.AdminPassword = StringHelper.MD5(AdminEntity.AdminPassword);
			AdminEntity.Hash = await _repository.GetAuthenticatePassHash(AdminEntity.AdminPassword);
			if(AdminEntity.AdminID <= 0)
			{
				AdminEntity.AdminID = GetMax(p=>p.AdminID)+1;
			}
			if (!Add(AdminEntity))
			{
				return "添加管理员失败";
			}
			bool result = false;
			if (StringHelper.FoundCharInArr(AdminEntity.RoleIDs, "0"))
			{
				result = await _AdminRolesRepository.AddMemberToRolesAsync(AdminEntity.AdminID, "0");
			}
			else
			{
				result = await _AdminRolesRepository.AddMemberToRolesAsync(AdminEntity.AdminID, AdminEntity.RoleIDs);
			}
			if (result)
			{
				return "ok";
			}
			else
			{
				return "添加管理员失败";
			}
		}

		/// <summary>
		/// 修改管理员，并设置所属角色
		/// </summary>
		/// <param name="AdminEntity"></param>
		/// <returns></returns>
		public async Task<string> UpdateAdminFull(AdminEntity AdminEntity)
		{
			if (AdminEntity == null)
				return "没有指定管理员信息，修改失败";
			if (string.IsNullOrEmpty(AdminEntity.AdminName))
				return "管理员名称不能为空";
			if (string.IsNullOrEmpty(AdminEntity.AdminPassword))
				return "管理员密码不能为空";
			AdminEntity.Hash = await _repository.GetAuthenticatePassHash(AdminEntity.AdminPassword);
			if (!Update(AdminEntity))
			{
				return "修改管理员失败";
			}
			bool result = false;
			if (StringHelper.FoundCharInArr(AdminEntity.RoleIDs, "0"))
			{
				result = await _AdminRolesRepository.AddMemberToRolesAsync(AdminEntity.AdminID, "0");
			}
			else
			{
				result = await _AdminRolesRepository.AddMemberToRolesAsync(AdminEntity.AdminID, AdminEntity.RoleIDs);
			}
			if (result)
			{
				return "ok";
			}
			else
			{
				return "修改管理员失败";
			}
		}

		/// <summary>
		/// 删除管理员。
		/// 1 当前登录管理员不能删除。
		/// 2 同时要删除角色关系。
		/// </summary>
		/// <param name="claimsPrincipal"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool DelAdminFull(ClaimsPrincipal claimsPrincipal, int id)
		{
			string currentID = claimsPrincipal.FindFirst(ClaimTypes.Sid).Value;
			if (DataConverter.CLng(currentID) == id)
			{
				return false;
			}
			_AdminRolesRepository.RemoveMemberFromAllRoles(id);
			return Delete(p=>p.AdminID==id);
		}
		/// <summary>
		/// 通过管理员ID，批量删除。
		/// 1 当前登录管理员不能删除。
		/// 2 同时要删除角色关系。
		/// </summary>
		/// <param name="claimsPrincipal"></param>
		/// <param name="ids"></param>
		public void BatchDel(ClaimsPrincipal claimsPrincipal, string ids)
		{
			if (string.IsNullOrEmpty(ids))
			{
				return;
			}
			string[] arrID = ids.Split(',');
			foreach (string strID in arrID)
			{
				DelAdminFull(claimsPrincipal, DataConverter.CLng(strID));
			}
		}
		#endregion

		/// <summary>
		/// 设置管理员的锁定/启用状态
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool SetAdminStatus(int id)
		{
			if (id <= 0)
				return false;
			var admin = _repository.Get(p=>p.AdminID==id);
			admin.IsLock = !admin.IsLock;
			return _repository.Update(admin);
		}

		#region 辅助方法
		private ClaimsPrincipal CreateClaimsIdentity(AdminEntity admin)
		{
			var claims = new List<Claim>()
			{
				new Claim(ClaimTypes.Sid,admin.AdminID.ToString())
				,new Claim(ClaimTypes.Name,admin.AdminName)
				,new Claim("UserName",admin.UserName)
				,new Claim("IsMultiLogin",admin.IsMultiLogin.ToString())
				,new Claim("LoginTimes",admin.LoginTimes.ToString())
				,new Claim("LoginIP",admin.LoginIP)
				,new Claim("LoginTime",(admin.LoginTime.HasValue)?admin.LoginTime.Value.ToString("yyyy-MM-dd HH:mm:ss"):"")
				,new Claim("LogoutTime",(admin.LogoutTime.HasValue)? admin.LogoutTime.Value.ToString("yyyy-MM-dd HH:mm:ss"):"")
				,new Claim("ModifyPasswordTime",(admin.ModifyPasswordTime.HasValue)? admin.ModifyPasswordTime.Value.ToString("yyyy-MM-dd HH:mm:ss"):"")
				,new Claim("IsLock",admin.IsLock.ToString())
				,new Claim("IsModifyPassword",admin.IsModifyPassword.ToString())
				,new Claim("RndPassword",admin.RndPassword)
			};
			if (string.IsNullOrEmpty(admin.RoleIDs))
			{
				admin.RoleIDs = _repository.GetRoleIDs(admin.AdminID);
			}
			if (admin.RoleIDs == "0")
			{
				claims.Add(new Claim(ClaimTypes.Role, "SuperAdmin"));
			}
			else
			{
				IList<string> OperateCodeList = _RolesPermissionsRepository.GetOperateCodeByRoleID(admin.RoleIDs);
				foreach (string OperateCode in OperateCodeList)
				{
					claims.Add(new Claim(ClaimTypes.Role, OperateCode));
				}
			}
			var adminClaimsIdentity = new ClaimsIdentity(claims, AdminAuthorizeAttribute.AdminAuthenticationScheme);
			return new ClaimsPrincipal(adminClaimsIdentity);
		}
		#endregion
	}
}