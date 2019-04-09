using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.Core
{
	/// <summary>
	/// 数据库表：Admin 的仓储接口.
	/// </summary>
	public partial interface IAdminRepositoryADO : IRepositoryADO<AdminEntity>
	{
		#region 是否存在
		/// <summary>
		/// 检查用户名是否存在
		/// </summary>
		/// <param name="adminName">用户名</param>
		/// <returns></returns>
		Task<bool> IsExistAsync(string adminName);
		#endregion

		#region 更新登录错误次数
		/// <summary>
		/// 更新登录错误次数
		/// </summary>
		/// <param name="times">错误次数</param>
		/// <param name="adminName">用户名</param>
		/// <returns></returns>
		Task<bool> UpdateLoginErrTimes(int times, string adminName);
		/// <summary>
		/// 累积登录错误次数，每次都加1
		/// </summary>
		/// <param name="adminName">用户名</param>
		/// <returns></returns>
		Task<bool> CumulativeLoginErrTimes(string adminName);
		#endregion

		#region 得到实体
		/// <summary>
		/// 通过用户名得到实体
		/// </summary>
		/// <param name="adminName"></param>
		/// <returns></returns>
		Task<AdminEntity> GetEntityByAdminNameAsync(string adminName);
		/// <summary>
		/// 通过用户名和密码返回第一条信息的实体类。
		/// </summary>
		/// <param name="adminName">用户名</param>
		/// <param name="adminPassword">密码（明文密码）</param>
		/// <returns></returns>
		Task<AdminEntity> GetEntityAsync(string adminName, string adminPassword);
		#endregion

		#region 得到实体，包括扩展属性
		/// <summary>
		/// 通过主键返回第一条信息的实体类，包括扩展属性。
		/// </summary>
		/// <returns></returns>
		AdminEntity GetEntityFull(System.Int32 adminID);
		/// <summary>
		/// 通过主键返回第一条信息的实体类，包括扩展属性。
		/// </summary>
		/// <returns></returns>
		Task<AdminEntity> GetEntityFullAsync(System.Int32 adminID);
		/// <summary>
		/// 获取实体，包括扩展属性
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		AdminEntity GetEntityFull(string strWhere, Dictionary<string, object> dict = null);
		/// <summary>
		/// 获取实体，包括扩展属性（异步方式）
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		Task<AdminEntity> GetEntityFullAsync(string strWhere, Dictionary<string, object> dict = null);
		/// <summary>
		/// 为实体添加RoleIDs和RoleNames两个属性的值
		/// </summary>
		/// <param name="admin"></param>
		/// <returns></returns>
		AdminEntity GetAdminFull(AdminEntity admin);
		#endregion

		#region 得到实体列表，包括扩展属性
		/// <summary>
		/// 得到实体列表，包括扩展属性
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		IList<AdminEntity> GetEntityFullList(string strWhere = "", Dictionary<string, object> dict = null);
		/// <summary>
		/// 得到实体列表，包括扩展属性（异步方式）
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		Task<IList<AdminEntity>> GetEntityFullListAsync(string strWhere = "", Dictionary<string, object> dict = null);
		#endregion

		#region 验证管理员
		/// <summary>
		/// 验证指定管理员名称的管理员密码的HASH值是否正确
		/// </summary>
		/// <param name="adminName"></param>
		/// <returns></returns>
		Task<bool> AuthenticatePassHash(string adminName);
		/// <summary>
		/// 使用sha1方式对字符串进行加密，主要用于对登录密码的再次加密，以防止破解。
		/// 1、在密码后加入SiteOption.SiteHashCode字符串。
		/// 2、使用 sha1 加密。
		/// </summary>
		/// <param name="adminPassword">管理员密码（已经被MD5加密）</param>
		/// <returns></returns>
		Task<string> GetAuthenticatePassHash(string adminPassword);
		/// <summary>
		/// 验证两个密码是否相等
		/// </summary>
		/// <param name="adminPassword">管理员密码（已经被MD5加密）</param>
		/// <param name="inputPassword">明文密码</param>
		/// <returns></returns>
		Task<bool> AuthenticatePassword(string adminPassword, string inputPassword);
		#endregion

		/// <summary>
		/// 得到指定管理员的所有角色ID，用“,”分隔
		/// </summary>
		/// <param name="adminID">管理员ID</param>
		/// <returns></returns>
		string GetRoleIDs(int adminID);

	}
}