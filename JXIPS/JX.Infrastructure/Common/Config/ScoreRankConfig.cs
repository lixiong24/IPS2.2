namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 积分等级配置文件类
	/// </summary>
	public class ScoreRankConfig
    {
		/// <summary>
		/// 
		/// </summary>
		public string AchieveColor { get; set; }
		/// <summary>
		/// 不及格
		/// </summary>
		public decimal Flunk { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string FlunkColor { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string FullMarkColor { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal Good { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string GoodColor { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string MissColor { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string OutstandingColor { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public decimal Pass { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string PassColor { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string SkipColor { get; set; }
	}
}
