namespace JX.Infrastructure.Common
{
	/// <summary>
	/// IP锁定配置类
	/// </summary>
	public class IPLockConfig
    {
		/// <summary>
		/// 后台IP黑名单
		/// </summary>
		public string AdminLockIPBlack{ get; set; }

		/// <summary>
		/// 后台来访限定方式：
		/// 0：不启用来访限定功能，任何IP都可以访问后台。
		/// 1：仅仅启用白名单，只允许白名单中的IP访问后台。
		/// 2：仅仅启用黑名单，只禁止黑名单中的IP访问后台。 
		/// 3：同时启用白名单与黑名单，先判断IP是否在白名单中，如果不在，则禁止访问；如果在则再判断是否在黑名单中，如果IP在黑名单中则禁止访问，否则允许访问。
		/// 4：同时启用白名单与黑名单，先判断IP是否在黑名单中，如果不在，则允许访问；如果在则再判断是否在白名单中，如果IP在白名单中则允许访问，否则禁止访问。 
		/// </summary>
		public string AdminLockIPType { get; set; }

		/// <summary>
		/// 后台IP白名单
		/// </summary>
		public string AdminLockIPWhite { get; set; }

		/// <summary>
		/// 全站来访限定方式
		/// 0：不启用来访限定功能，任何IP都可以访问本站。
		/// 1：仅仅启用白名单，只允许白名单中的IP访问本站。
		/// 2：仅仅启用黑名单，只禁止黑名单中的IP访问本站。 
		/// 3：同时启用白名单与黑名单，先判断IP是否在白名单中，如果不在，则禁止访问；如果在则再判断是否在黑名单中，如果IP在黑名单中则禁止访问，否则允许访问。
		/// 4：同时启用白名单与黑名单，先判断IP是否在黑名单中，如果不在，则允许访问；如果在则再判断是否在白名单中，如果IP在白名单中则允许访问，否则禁止访问。 
		/// </summary>
		public string LockIPType { get; set; }

		/// <summary>
		/// 全站IP黑名单
		/// </summary>
		public string LockIPBlack { get; set; }

		/// <summary>
		/// 全站IP白名单
		/// </summary>
		public string LockIPWhite { get; set; }
	}
}
