using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;
using JX.Infrastructure.Common;
using System.Text;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：Admin 的仓储实现类.
	/// </summary>
	public partial class AdminRepository : Repository<AdminEntity>, IAdminRepository
	{
		#region 是否存在
		/// <summary>
		/// 检查用户名是否存在
		/// </summary>
		/// <param name="adminName"></param>
		/// <returns></returns>
		public async Task<bool> IsExistAsync(string adminName)
		{
			return await IsExistAsync(p=>p.AdminName==adminName);
		}
		#endregion

		#region 更新登录错误次数
		/// <summary>
		/// 更新登录错误次数
		/// </summary>
		/// <param name="times">错误次数</param>
		/// <param name="adminName">用户名</param>
		/// <returns></returns>
		public async Task<bool> UpdateLoginErrTimes(int times, string adminName)
		{
			var entity = Get(p => p.AdminName == adminName);
			entity.LoginErrorTimes = times;
			return await UpdateAsync(entity);
		}
		/// <summary>
		/// 累积登录错误次数，每次都加1
		/// </summary>
		/// <param name="adminName">用户名</param>
		/// <returns></returns>
		public async Task<bool> CumulativeLoginErrTimes(string adminName)
		{
			var entity = Get(p => p.AdminName == adminName);
			entity.LoginErrorTimes += 1;
			return await UpdateAsync(entity);
		}
		#endregion

		#region 得到实体
		/// <summary>
		/// 通过用户名得到实体
		/// </summary>
		/// <param name="adminName"></param>
		/// <returns></returns>
		public async Task<AdminEntity> GetEntityByAdminNameAsync(string adminName)
		{
			if (string.IsNullOrEmpty(adminName))
				return null;
			return await GetAsync(p=>p.AdminName==adminName);
		}
		/// <summary>
		/// 通过用户名和密码返回第一条信息的实体类。
		/// </summary>
		/// <param name="adminName">用户名</param>
		/// <param name="adminPassword">密码（明文密码）</param>
		/// <returns></returns>
		public async Task<AdminEntity> GetEntityAsync(string adminName, string adminPassword)
		{
			if (string.IsNullOrEmpty(adminName) || string.IsNullOrEmpty(adminPassword))
				return null;
			adminPassword = StringHelper.MD5(adminPassword);
			return await GetAsync(p => p.AdminName == adminName && p.AdminPassword==adminPassword);
		}
		#endregion

		#region 得到实体，包括扩展属性
		/// <summary>
		/// 通过主键返回第一条信息的实体类，包括扩展属性。
		/// </summary>
		/// <returns></returns>
		public AdminEntity GetEntityFull(System.Int32 adminID)
		{
			if (adminID <= 0)
				return null;
			return GetEntityFull(p => p.AdminID == adminID);
		}
		/// <summary>
		/// 通过主键返回第一条信息的实体类，包括扩展属性。
		/// </summary>
		/// <returns></returns>
		public async Task<AdminEntity> GetEntityFullAsync(System.Int32 adminID)
		{
			if (adminID <= 0)
				return null;
			return await GetEntityFullAsync(p => p.AdminID == adminID);
		}

		/// <summary>
		/// 获取实体，包括扩展属性
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public virtual AdminEntity GetEntityFull(Expression<Func<AdminEntity, bool>> predicate)
		{
			var entity = Get(predicate);
			entity = GetAdminFull(entity);
			return entity;
		}
		/// <summary>
		/// 获取实体，包括扩展属性（异步方式）
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public virtual async Task<AdminEntity> GetEntityFullAsync(Expression<Func<AdminEntity, bool>> predicate)
		{
			var entity = await GetAsync(predicate);
			entity = GetAdminFull(entity);
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
			StringBuilder sbRoleID = new StringBuilder();
			StringBuilder sbRoleName = new StringBuilder();
			string strSQL = "SELECT AdminID FROM AdminRoles WHERE AdminID = @AdminID AND RoleId = 0";
			var result = GetBySQL<int>(strSQL,p=>p.AdminID,new SqlParameter("AdminID", admin.AdminID));
			if (result > 0)
			{
				admin.RoleIDs = "0";
				admin.RoleNames = "超级管理员";
				return admin;
			}
			strSQL = "SELECT * FROM Roles WHERE RoleId IN(SELECT RoleId FROM AdminRoles WHERE AdminID = @AdminID)";
			var queryResult = SqlQuery<RolesEntity>(strSQL, new SqlParameter("AdminID", admin.AdminID));
			queryResult.ToList().ForEach(item=> {
				StringHelper.AppendString(sbRoleID, item.RoleID.ToString());
				StringHelper.AppendString(sbRoleName, item.RoleName.ToString());
			});
			admin.RoleIDs = sbRoleID.ToString();
			admin.RoleNames = sbRoleName.ToString();
			return admin;
		}
		#endregion

		#region 得到实体列表，包括扩展属性
		/// <summary>
		/// 得到实体列表，包括扩展属性
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public virtual IList<AdminEntity> GetEntityFullList(Expression<Func<AdminEntity, bool>> predicate)
		{
			IList<AdminEntity> list = LoadListAll(predicate);
			list.ToList().ForEach(item=> {
				GetAdminFull(item);
			});
			return list;
		}
		/// <summary>
		/// 得到实体列表，包括扩展属性（异步方式）
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public virtual async Task<IList<AdminEntity>> GetEntityFullListAsync(Expression<Func<AdminEntity, bool>> predicate)
		{
			IList<AdminEntity> list = await LoadListAllAsync(predicate);
			list.ToList().ForEach(item => {
				GetAdminFull(item);
			});
			return list;
		}
		#endregion

		#region 验证管理员
		/// <summary>
		/// 验证指定管理员名称的管理员密码的HASH值是否正确
		/// </summary>
		/// <param name="adminName"></param>
		/// <returns></returns>
		public async Task<bool> AuthenticatePassHash(string adminName)
		{
			AdminEntity admin = await GetEntityByAdminNameAsync(adminName);
			if (admin == null) return false;
			string adminHash = await GetAuthenticatePassHash(admin.AdminPassword);
			bool result = (string.Compare(adminHash.Trim(), admin.Hash.Trim(), true) == 0);
			return result;
		}
		/// <summary>
		/// 使用sha1方式对字符串进行加密，主要用于对登录密码的再次加密，以防止破解。
		/// 1、在密码后加入SiteOption.SiteHashCode字符串。
		/// 2、使用 sha1 加密。
		/// </summary>
		/// <param name="adminPassword">管理员密码（已经被MD5加密）</param>
		/// <returns></returns>
		public async Task<string> GetAuthenticatePassHash(string adminPassword)
		{
			SiteOptionConfig siteOptionConfig = ConfigHelper.Get<SiteOptionConfig>();
			return await Task.Run(() => Sha1.Encrypt(adminPassword + siteOptionConfig.SiteHashCode));
		}
		/// <summary>
		/// 验证两个密码是否相等
		/// </summary>
		/// <param name="adminPassword">管理员密码（已经被MD5加密）</param>
		/// <param name="inputPassword">明文密码</param>
		/// <returns></returns>
		public async Task<bool> AuthenticatePassword(string adminPassword, string inputPassword)
		{
			string encryptedValue = StringHelper.MD5(inputPassword);
			return await Task.Run(() => StringHelper.ValidateMD5(adminPassword, encryptedValue));
		}
		#endregion

		/// <summary>
		/// 得到指定管理员的所有角色ID，用“,”分隔。超级管理员直接返回“0”。
		/// </summary>
		/// <param name="adminID">管理员ID</param>
		/// <returns></returns>
		public string GetRoleIDs(int adminID)
		{
			string strSQL = "SELECT AdminID FROM AdminRoles WHERE AdminID = @AdminID AND RoleId = 0";
			var result = GetBySQL<int>(strSQL, p => p.AdminID, new SqlParameter("AdminID", adminID));
			if (result > 0)
			{
				return "0";
			}
			strSQL = "SELECT RoleId FROM AdminRoles WHERE AdminID=@AdminID";
			StringBuilder sb = new StringBuilder();
			var queryResult = SqlQuery<int>(strSQL, new SqlParameter("AdminID", adminID));
			queryResult.ToList().ForEach(item => {
				StringHelper.AppendString(sb, item.ToString());
			});
			return sb.ToString();
		}
	}
}