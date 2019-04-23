using System.ComponentModel.DataAnnotations;

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
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public bool IsUseRedis { get; set; }
		/// <summary>
		/// Redis连接
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string ConnectionString { get; set; }
		/// <summary>
		/// Redis实例名称
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string InstanceName { get; set; }
	}
}
