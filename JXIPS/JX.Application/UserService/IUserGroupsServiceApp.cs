using JX.Core.Entity;
using System.Collections.Generic;

namespace JX.Application
{
	/// <summary>
	/// 数据库表：UserGroups 的应用层服务接口.
	/// </summary>
	public partial interface IUserGroupsServiceApp : IServiceApp<UserGroupsEntity>
	{
		/// <summary>
		/// 计算会员组集合里的会员总数
		/// </summary>
		/// <param name="userGroupsList"></param>
		void CountUserNumber(IList<UserGroupsEntity> userGroupsList);
	}
}