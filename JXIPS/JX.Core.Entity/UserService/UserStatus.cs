using System;
using System.ComponentModel;

namespace JX.Core.Entity
{
	/// <summary>
	/// 会员状态 枚举
	/// </summary>
	[Flags]
	public enum UserStatusEnum
	{
		/// <summary>
		/// 正常
		/// </summary>
		[Description("正常")]
		None = 0,
		/// <summary>
		/// 锁定
		/// </summary>
		[Description("锁定")]
		Locked = 1,
		/// <summary>
		/// 等待邮件认证
		/// </summary>
		[Description("等待邮件认证")]
		WaitValidateByEmail = 2,
		/// <summary>
		/// 等待管理员认证
		/// </summary>
		[Description("等待管理员认证")]
		WaitValidateByAdmin = 4,
		/// <summary>
		/// 等待手机短信认证
		/// </summary>
		[Description("等待手机短信认证")]
		WaitValidateByMobile = 8,
		/// <summary>
		/// 不存在
		/// </summary>
		[Description("不存在")]
		NoExist = 16
	}
}
