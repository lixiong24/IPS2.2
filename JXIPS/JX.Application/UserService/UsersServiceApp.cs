using JX.Core.Entity;
using JX.Infrastructure;
using JX.Infrastructure.Common;
using System;

namespace JX.Application
{
	/// <summary>
	/// 会员模块相关的应用层服务接口实现类.
	/// </summary>
	public partial class UsersServiceApp : IUsersServiceApp
	{
		/// <summary>
		/// 会员登录
		/// </summary>
		/// <param name="userName"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		public UserStatusEnum Login(string userName, string password)
		{
			UserStatusEnum result = UserStatusEnum.NoExist;
			string encryptedValue = StringHelper.MD5(password);
			if (password.Length == 32)
			{
				encryptedValue = password;
			}
			var entity = _repository.Get(p=>p.UserName==userName && p.UserPassword==encryptedValue);
			if (entity == null || entity.UserID <= 0)
			{
				return result;
			}
			switch ((UserStatusEnum)entity.UserStatus)
			{
				case UserStatusEnum.None:
					entity.LoginTimes++;
					entity.LoginTime = new DateTime?(DateTime.Now);
					entity.LoginIP = Utility.GetClientIP();
					entity.LastPassword = DataSecurity.MakeRandomString(10);
					_repository.Update(entity);
					result = UserStatusEnum.None;
					break;
				default:
					result = (UserStatusEnum)entity.UserStatus;
					break;
			}
			return result;
		}

		/// <summary>
		/// 得到会员状态
		/// </summary>
		/// <param name="userID"></param>
		/// <returns></returns>
		public UserStatusEnum GetUserStatus(int userID)
		{
			UserStatusEnum result = UserStatusEnum.NoExist;
			var strResult = _repository.GetScalar<string,int>(p=>p.UserStatus.ToString(),p=>p.UserID==userID);
			if (!string.IsNullOrEmpty(strResult))
			{
				result = (UserStatusEnum)DataConverter.CLng(strResult, 16);
			}
			return result;
		}
		/// <summary>
		/// 得到会员状态
		/// </summary>
		/// <param name="userName"></param>
		/// <returns></returns>
		public UserStatusEnum GetUserStatus(string userName)
		{
			UserStatusEnum result = UserStatusEnum.NoExist;
			string strResult = _repository.GetScalar<string, int>(p => p.UserStatus.ToString(), p => p.UserName == userName);
			if (!string.IsNullOrEmpty(strResult))
			{
				result = (UserStatusEnum)DataConverter.CLng(strResult, 16);
			}
			return result;
		}

		/// <summary>
		/// 通过会员名得到会员的实体类
		/// </summary>
		/// <param name="userName"></param>
		/// <returns></returns>
		public UsersEntity GetByUserName(string userName)
		{
			return Get(p=>p.UserName==userName);
		}
	}
}