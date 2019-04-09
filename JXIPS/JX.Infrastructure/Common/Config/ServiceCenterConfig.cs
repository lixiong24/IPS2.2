namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 服务中心配置文件类
	/// </summary>
	public class ServiceCenterConfig
    {
		/// <summary>
		/// 是否扣除点数
		/// </summary>
		public bool IsDeductPoint { get; set; }

		/// <summary>
		/// 回复超时时间参考值
		/// </summary>
		public int ReplyOvertimeReferenceValue { get; set; }

		/// <summary>
		/// 满意度数项
		/// </summary>
		public string SatisfactionDegreeItems { get; set; }
	}
}
