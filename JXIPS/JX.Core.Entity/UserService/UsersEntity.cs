using JX.Infrastructure.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Users 的实体类.
	/// </summary>
	public partial class UsersEntity
	{
		#region Properties
		/// <summary>
		/// 距离有效期结束的剩余天数，负数为已过期
		/// </summary>
		[NotMapped]
		public int EndDays
		{
			get
			{
				int days = 0;
				if (this.EndTime.HasValue)
				{
					TimeSpan span = this.EndTime.Value - DateTime.Now;
					days = span.Days;
				}
				return days;
			}
		}

		/// <summary>
		/// 用户权限信息
		/// </summary>
		[NotMapped]
		public UserPurviewEntity UserPurview
		{
			get
			{
				if (!string.IsNullOrEmpty(UserSetting))
				{
					return UserSetting.ToXmlObject<UserPurviewEntity>();
				}
				return null;
			}
		}
		
		#endregion
	}
}
