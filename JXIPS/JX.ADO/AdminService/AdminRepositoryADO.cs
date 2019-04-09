using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;
using JX.Infrastructure.Common;
using MyADO;
using System.Text;

namespace JX.ADO
{
	/// <summary>
	/// 数据库表：Admin 的仓储实现类.
	/// </summary>
	public partial class AdminRepositoryADO : IAdminRepositoryADO
	{
		#region 是否存在
		/// <summary>
		/// 检查用户名是否存在
		/// </summary>
		/// <param name="adminName"></param>
		/// <returns></returns>
		public async Task<bool> IsExistAsync(string adminName)
		{
			string strWhere = " and AdminName=@AdminName ";
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("AdminName", adminName);
			return await IsExistAsync(strWhere, dict);
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
			string strColumns = "LoginErrorTimes = @LoginErrorTimes";
			Dictionary<string, object> dictColumns = new Dictionary<string, object>();
			dictColumns.Add("LoginErrorTimes", times);
			string strWhere = " and AdminName=@AdminName ";
			Dictionary<string, object> dictWhere = new Dictionary<string, object>();
			dictWhere.Add("AdminName", adminName);
			return await UpdateAsync(strColumns, dictColumns, strWhere, dictWhere);
		}
		/// <summary>
		/// 累积登录错误次数，每次都加1
		/// </summary>
		/// <param name="adminName">用户名</param>
		/// <returns></returns>
		public async Task<bool> CumulativeLoginErrTimes(string adminName)
		{
			string strColumns = "LoginErrorTimes = ISNULL(LoginErrorTimes,0)+1";
			Dictionary<string, object> dictColumns = new Dictionary<string, object>();
			string strWhere = " and AdminName=@AdminName ";
			Dictionary<string, object> dictWhere = new Dictionary<string, object>();
			dictWhere.Add("AdminName", adminName);
			return await UpdateAsync(strColumns, dictColumns, strWhere, dictWhere);
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
			string strWhere = " and AdminName=@AdminName ";
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("AdminName", adminName);
			return await GetEntityAsync(strWhere, dict);
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
			string strWhere = " and AdminName=@AdminName and AdminPassword=@AdminPassword";
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("AdminName", adminName);
			dict.Add("AdminPassword", adminPassword);
			return await GetEntityAsync(strWhere, dict);
		}
		#endregion

		#region 得到实体，包括扩展属性
		/// <summary>
		/// 通过主键返回第一条信息的实体类，包括扩展属性。
		/// </summary>
		/// <returns></returns>
		public AdminEntity GetEntityFull(System.Int32 adminID)
		{
			string strCondition = string.Empty;
			strCondition += " and AdminID = @AdminID";

			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("AdminID", adminID);

			return GetEntityFull(strCondition, dict);
		}
		/// <summary>
		/// 通过主键返回第一条信息的实体类，包括扩展属性。
		/// </summary>
		/// <returns></returns>
		public async Task<AdminEntity> GetEntityFullAsync(System.Int32 adminID)
		{
			string strCondition = string.Empty;
			strCondition += " and AdminID = @AdminID";

			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("AdminID", adminID);

			return await GetEntityFullAsync(strCondition, dict);
		}

		/// <summary>
		/// 获取实体，包括扩展属性
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual AdminEntity GetEntityFull(string strWhere, Dictionary<string, object> dict = null)
		{
			AdminEntity obj = null;
			string strSQL = "select top 1 * from Admin where 1=1 " + strWhere;
			using (NullableDataReader reader = _DB.GetDataReader(strSQL, dict))
			{
				if (reader.Read())
				{
					obj = GetEntityFromrdr(reader);
					obj = GetAdminFull(obj);
				}
			}
			return obj;
		}
		/// <summary>
		/// 获取实体，包括扩展属性（异步方式）
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual async Task<AdminEntity> GetEntityFullAsync(string strWhere, Dictionary<string, object> dict = null)
		{
			AdminEntity obj = null;
			string strSQL = "select top 1 * from Admin where 1=1 " + strWhere;
			using (NullableDataReader reader = await Task.Run(() => _DB.GetDataReader(strSQL, dict)))
			{
				if (reader.Read())
				{
					obj = GetEntityFromrdr(reader);
					obj = GetAdminFull(obj);
				}
			}
			return obj;
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
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("AdminID", admin.AdminID);
			if (_DB.ExistData(strSQL, dict))
			{
				admin.RoleIDs = "0";
				admin.RoleNames = "超级管理员";
				return admin;
			}
			strSQL = "SELECT RoleID,RoleName FROM Roles WHERE RoleId IN(SELECT RoleId FROM AdminRoles WHERE AdminID = @AdminID)";
			using (NullableDataReader reader = _DB.GetDataReader(strSQL, dict))
			{
				while (reader.Read())
				{
					StringHelper.AppendString(sbRoleID, reader.GetInt32("RoleID").ToString());
					StringHelper.AppendString(sbRoleName, reader.GetString("RoleName"));
				}
			}
			admin.RoleIDs = sbRoleID.ToString();
			admin.RoleNames = sbRoleName.ToString();
			return admin;
		}
		#endregion

		#region 得到实体列表，包括扩展属性
		/// <summary>
		/// 得到实体列表，包括扩展属性
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual IList<AdminEntity> GetEntityFullList(string strWhere = "", Dictionary<string, object> dict = null)
		{
			IList<AdminEntity> list = new List<AdminEntity>();
			string strSQL = "select * from Admin where 1=1 ";
			if (!string.IsNullOrEmpty(strWhere))
			{
				strSQL += strWhere;
			}
			using (NullableDataReader reader = _DB.GetDataReader(strSQL, dict))
			{
				while (reader.Read())
				{
					AdminEntity obj = GetEntityFromrdr(reader);
					obj = GetAdminFull(obj);
					list.Add(obj);
				}
			}
			return list;
		}
		/// <summary>
		/// 得到实体列表，包括扩展属性（异步方式）
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual async Task<IList<AdminEntity>> GetEntityFullListAsync(string strWhere = "", Dictionary<string, object> dict = null)
		{
			IList<AdminEntity> list = new List<AdminEntity>();
			string strSQL = "select * from Admin where 1=1 ";
			if (!string.IsNullOrEmpty(strWhere))
			{
				strSQL += strWhere;
			}
			using (NullableDataReader reader = await Task.Run(() => _DB.GetDataReader(strSQL, dict)))
			{
				while (reader.Read())
				{
					AdminEntity obj = GetEntityFromrdr(reader);
					obj = GetAdminFull(obj);
					list.Add(obj);
				}
			}
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
			if(admin==null) return false;
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
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("AdminID", adminID);
			if (_DB.ExistData(strSQL, dict))
			{
				return "0";
			}
			strSQL = "SELECT RoleId FROM AdminRoles WHERE AdminID=@AdminID";
			StringBuilder sb = new StringBuilder();
			using (NullableDataReader reader = _DB.GetDataReader(strSQL, dict))
			{
				while (reader.Read())
				{
					StringHelper.AppendString(sb, reader.GetInt32("RoleId").ToString());
				}
			}
			return sb.ToString(); 
		}

		#region 辅助方法
		
		#endregion
	}
}