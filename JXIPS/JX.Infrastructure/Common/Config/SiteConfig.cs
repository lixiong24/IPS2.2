using System.ComponentModel.DataAnnotations;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 网站信息配置类
	/// </summary>
	public class SiteConfig
    {
		private string m_VirtualPath = "";
		/// <summary>
		/// 得到或设置网站的虚拟路径： / 或者 /shop/
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string VirtualPath
		{
			//TODO:VirtualPath
			get
			{
				if (string.IsNullOrEmpty(m_VirtualPath))
				{
					m_VirtualPath = "/";
				}
				return  (m_VirtualPath.EndsWith("/")) ? m_VirtualPath : m_VirtualPath + "/";
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					m_VirtualPath = "/";
				}
				else
				{
					m_VirtualPath = value;
				}
			}
		}

		/// <summary>
		/// 网站名称
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string SiteName { get; set; } = "";

		/// <summary>
		/// 网站地址
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string SiteUrl { get; set; } = "";

		/// <summary>
		/// 版权信息
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string Copyright { get; set; } = "";

		/// <summary>
		/// 网站Title
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string SiteTitle { get; set; } = "";

		/// <summary>
		/// 网站META网页描述
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string MetaDescription { get; set; } = "";

		/// <summary>
		/// 网站META关键词
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string MetaKeywords { get; set; } = "";

		/// <summary>
		/// 站长姓名
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string Webmaster { get; set; } = "";

		/// <summary>
		/// 站长邮箱
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		[RegularExpression(RegexHelper.EmailPattern, ErrorMessage = "请输入正确的Email.")]
		[DataType(DataType.EmailAddress)]
		public string WebmasterEmail { get; set; } = "";

		/// <summary>
		/// 公司名称
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string Company { get; set; } = "";

		/// <summary>
		/// 公司地址
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string Address { get; set; } = "";

		/// <summary>
		/// 联系电话
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string SiteTel { get; set; } = "";

		/// <summary>
		/// 联系电话1
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string SiteTel1 { get; set; } = "";

		/// <summary>
		/// 联系电话2
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string SiteTel2 { get; set; } = "";

		/// <summary>
		/// 网站QQ
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string SiteQQ { get; set; } = "";

		/// <summary>
		/// 网站QQ1
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string SiteQQ1 { get; set; } = "";

		/// <summary>
		/// 网站QQ2
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string SiteQQ2 { get; set; } = "";

		/// <summary>
		/// 网站ICP备案号
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string ICPNO { get; set; } = "";
	}
}
