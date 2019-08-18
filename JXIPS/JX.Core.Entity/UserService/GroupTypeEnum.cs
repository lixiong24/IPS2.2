using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JX.Core.Entity
{
	/// <summary>
	/// 会员组类型 枚举
	/// </summary>
	[Flags]
	public enum GroupTypeEnum
	{
		/// <summary>
		/// 会员组
		/// </summary>
		[Description("会员组")]
		Register,
		/// <summary>
		/// 代理商组
		/// </summary>
		[Description("代理商组")]
		Agent,
		/// <summary>
		/// 加盟商组
		/// </summary>
		[Description("加盟商组")]
		Affiliate,
		/// <summary>
		/// 分销商组
		/// </summary>
		[Description("分销商组")]
		Distributor
	}
}
