namespace JX.Infrastructure.Common
{
	/// <summary>
	/// Redis使用配置文件
	/// </summary>
	public class RedisConfig
    {
		/// <summary>
		/// 是否使用Redis
		/// </summary>
		public bool IsUseRedis { get; set; }
		/// <summary>
		/// Redis连接
		/// </summary>
		public string ConnectionString { get; set; }
		/// <summary>
		/// Redis实例名称
		/// </summary>
		public string InstanceName { get; set; }
	}
}
