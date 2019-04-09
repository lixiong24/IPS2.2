namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 网站操作参数配置文件类
	/// </summary>
	public class SiteOptionConfig
    {
		private string m_ManageDir = string.Empty;
		/// <summary>
		/// 后台管理目录
		/// </summary>
		public string ManageDir
		{
			get
			{
				return this.m_ManageDir;
			}
			set
			{
				this.m_ManageDir = value;
			}
		}

		private int m_TicketTime;
		/// <summary>
		/// 管理员身份验证票过期时间 单位：分钟
		/// </summary>
		public int TicketTime
		{
			get
			{
				return this.m_TicketTime;
			}
			set
			{
				this.m_TicketTime = value;
			}
		}

		private bool m_EnableSiteManageCode;
		/// <summary>
		/// 是否启用后台管理认证码
		/// </summary>
		public bool EnableSiteManageCode
		{
			get
			{
				return this.m_EnableSiteManageCode;
			}
			set
			{
				this.m_EnableSiteManageCode = value;
			}
		}

		private string m_SiteManageCode = string.Empty;
		/// <summary>
		/// 后台管理认证码
		/// </summary>
		public string SiteManageCode
		{
			get
			{
				return this.m_SiteManageCode;
			}
			set
			{
				this.m_SiteManageCode = value;
			}
		}

		private string m_SiteHashCode = string.Empty;
		/// <summary>
		/// 管理员密码哈希值
		/// </summary>
		public string SiteHashCode
		{
			get
			{
				return this.m_SiteHashCode;
			}
			set
			{
				this.m_SiteHashCode = value;
			}
		}

		private string m_MainDomain = string.Empty;
		/// <summary>
		/// 网站根域名
		/// </summary>
		public string MainDomain
		{
			get
			{
				return this.m_MainDomain;
			}
			set
			{
				this.m_MainDomain = value;
			}
		}

		private string m_AdvertisementDir = string.Empty;
		/// <summary>
		/// 网站广告目录
		/// </summary>
		public string AdvertisementDir
		{
			get
			{
				return this.m_AdvertisementDir;
			}
			set
			{
				this.m_AdvertisementDir = value;
			}
		}

		private string m_CreateHtmlPath = string.Empty;
		/// <summary>
		/// 网站生成目录，用于在生成静态页时存放静态页面。如果生成在根目录下，请保留为空！
		/// </summary>
		public string CreateHtmlPath
		{
			get
			{
				return this.m_CreateHtmlPath;
			}
			set
			{
				this.m_CreateHtmlPath = value;
			}
		}

		private string m_TemplateDir = string.Empty;
		/// <summary>
		/// 网站模板根目录
		/// </summary>
		public string TemplateDir
		{
			get
			{
				return this.m_TemplateDir;
			}
			set
			{
				this.m_TemplateDir = value;
			}
		}

		private string m_LabelDirConfig = "标签库";
		/// <summary>
		/// 标签库目录
		/// </summary>
		public string LabelDirConfig
		{
			get
			{
				return this.m_LabelDirConfig;
			}
			set
			{
				this.m_LabelDirConfig = value;
			}
		}

		/// <summary>
		/// 标签库完整目录（模板库目录+标签库目录）
		/// </summary>
		public string LabelDir
		{
			get
			{
				return (this.m_TemplateDir + "/" + this.m_LabelDirConfig);
			}
		}

		private string m_PagerLabelDirConfig = "分页标签库";
		/// <summary>
		/// 分页标签库
		/// </summary>
		public string PagerLabelDirConfig
		{
			get
			{
				return this.m_PagerLabelDirConfig;
			}
			set
			{
				this.m_PagerLabelDirConfig = value;
			}
		}

		/// <summary>
		/// 分页标签库完整目录（模板库目录+分页标签库目录）
		/// </summary>
		public string PagerLabelDir
		{
			get
			{
				return (this.m_TemplateDir + "/" + this.m_PagerLabelDirConfig);
			}
		}

		private bool m_IsAutoSignin;
		/// <summary>
		/// 是否启用内容自动签收
		/// </summary>
		public bool IsAutoSignIn
		{
			get
			{
				return this.m_IsAutoSignin;
			}
			set
			{
				this.m_IsAutoSignin = value;
			}
		}

		private int m_AutoSignInTime;
		/// <summary>
		/// 自动签收内容时间.单位：秒
		/// </summary>
		public int AutoSignInTime
		{
			get
			{
				return this.m_AutoSignInTime;
			}
			set
			{
				this.m_AutoSignInTime = value;
			}
		}

		private int m_RefreshQueueSize;
		/// <summary>
		/// 防刷新队列长度。队列长度越长，防止用户恶意刷新提交重复表单越有效。
		/// </summary>
		public int RefreshQueueSize
		{
			get
			{
				return this.m_RefreshQueueSize;
			}
			set
			{
				this.m_RefreshQueueSize = value;
			}
		}

		private int m_CollectionSleep;
		/// <summary>
		/// 采集休眠时间.单位：秒
		/// </summary>
		public int CollectionSleep
		{
			get
			{
				return this.m_CollectionSleep;
			}
			set
			{
				this.m_CollectionSleep = value;
			}
		}

		private bool m_EnableRefreshHits;
		/// <summary>
		/// 是否启用防恶意刷新点击数功能
		/// 启用此功能后同一用户每刷新一次并不会增加点击数，只有重新打开浏览器才会被统计到。 
		/// </summary>
		public bool EnableRefreshHits
		{
			get
			{
				return this.m_EnableRefreshHits;
			}
			set
			{
				this.m_EnableRefreshHits = value;
			}
		}

		private int m_HitsOfHot;
		/// <summary>
		/// 点击数最小值
		/// </summary>
		public int HitsOfHot
		{
			get
			{
				return this.m_HitsOfHot;
			}
			set
			{
				this.m_HitsOfHot = value;
			}
		}

		private int m_LeastOfEliteLevel;
		/// <summary>
		/// 推荐级最小值
		/// </summary>
		public int LeastOfEliteLevel
		{
			get
			{
				return this.m_LeastOfEliteLevel;
			}
			set
			{
				this.m_LeastOfEliteLevel = value;
			}
		}

		private string m_IncludeFilePath = string.Empty;
		/// <summary>
		/// 内嵌代码生成路径
		/// </summary>
		public string IncludeFilePath
		{
			get
			{
				return this.m_IncludeFilePath;
			}
			set
			{
				this.m_IncludeFilePath = value;
			}
		}
	}
}
