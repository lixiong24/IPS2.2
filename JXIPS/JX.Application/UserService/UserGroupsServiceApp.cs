using JX.Core;
using JX.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace JX.Application
{
	public partial class UserGroupsServiceApp: IUserGroupsServiceApp
	{
		#region 仓储接口
		private readonly IUsersRepository _UsersRepository;
		private readonly ILogRepository _LogRepository;
		/// <summary>
		/// 构造器注入
		/// </summary>
		/// <param name="repository"></param>
		/// <param name="usersRepository"></param>
		/// <param name="logRepository"></param>
		public UserGroupsServiceApp(IUserGroupsRepository repository,
			IUsersRepository usersRepository,
			ILogRepository logRepository)
		{
			_repository = repository;
			_UsersRepository = usersRepository;
			_LogRepository = logRepository;
		}
		#endregion

		/// <summary>
		/// 计算会员组集合里的会员总数
		/// </summary>
		/// <param name="userGroupsList"></param>
		public void CountUserNumber(IList<UserGroupsEntity> userGroupsList)
		{
			for (int i = 0; i < userGroupsList.Count; i++)
			{
				userGroupsList[i].UserInGroupNumber = _UsersRepository.GetCount(p=>p.GroupID == userGroupsList[i].GroupID);
			}
		}
	}
}
