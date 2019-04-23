using System.ComponentModel.DataAnnotations;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 网站操作参数配置文件类
	/// </summary>
	public class SiteOptionConfig
    {
		/// <summary>
		/// 后台管理目录
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string ManageDir { get; set; } = string.Empty;

		/// <summary>
		/// 管理员身份验证票过期时间 单位：分钟
		/// </summary>
		[Required(ErrorMessage = "管理员身份验证票过期时间不得为空")]
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int TicketTime { get; set; }

		/// <summary>
		/// 是否启用后台管理认证码
		/// </summary>
		public bool EnableSiteManageCode { get; set; } = false;

		/// <summary>
		/// 后台管理认证码
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string SiteManageCode { get; set; } = string.Empty;

		/// <summary>
		/// 管理员密码哈希值
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		[Required(ErrorMessage = "管理员密码哈希值不得为空")]
		[RegularExpression(RegexHelper.PasswordPattern, ErrorMessage = "只能输入字母、数字、下划线，长度在6－20之间")]
		public string SiteHashCode { get; set; } = "JieXiang";

		/// <summary>
		/// 网站根域名
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string MainDomain { get; set; } = string.Empty;
		/// <summary>
		/// 网站广告目录
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string AdvertisementDir { get; set; } = string.Empty;
		/// <summary>
		/// 网站生成目录，用于在生成静态页时存放静态页面。如果生成在根目录下，请保留为空！
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		[RegularExpression(RegexHelper.UserNamePattern, ErrorMessage = "只能输入字母、数字、下划线和汉字，长度在2－20之间")]
		public string CreateHtmlPath { get; set; } = string.Empty;
		/// <summary>
		/// 网站模板根目录
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string TemplateDir { get; set; } = "Template";
		/// <summary>
		/// 标签库目录
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string LabelDirConfig { get; set; } = "标签库";

		/// <summary>
		/// 标签库完整目录（模板库目录+标签库目录）
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string LabelDir
		{
			get
			{
				return (this.TemplateDir + "/" + this.LabelDirConfig);
			}
		}
		/// <summary>
		/// 分页标签库
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string PagerLabelDirConfig { get; set; } = "分页标签库";

		/// <summary>
		/// 分页标签库完整目录（模板库目录+分页标签库目录）
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string PagerLabelDir
		{
			get
			{
				return (this.TemplateDir + "/" + this.PagerLabelDirConfig);
			}
		}
		/// <summary>
		/// 是否启用内容自动签收
		/// </summary>
		public bool IsAutoSignIn { get; set; } = false;
		/// <summary>
		/// 自动签收内容时间.单位：秒
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int AutoSignInTime { get; set; }
		/// <summary>
		/// 防刷新队列长度。队列长度越长，防止用户恶意刷新提交重复表单越有效。
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int RefreshQueueSize { get; set; }
		/// <summary>
		/// 采集休眠时间.单位：秒
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int CollectionSleep { get; set; }
		/// <summary>
		/// 是否启用防恶意刷新点击数功能
		/// 启用此功能后同一用户每刷新一次并不会增加点击数，只有重新打开浏览器才会被统计到。 
		/// </summary>
		public bool EnableRefreshHits { get; set; } = false;
		/// <summary>
		/// 点击数最小值
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int HitsOfHot { get; set; }
		/// <summary>
		/// 推荐级最小值
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int LeastOfEliteLevel { get; set; }
		/// <summary>
		/// 内嵌代码生成路径
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string IncludeFilePath { get; set; } = string.Empty;
	}
}
