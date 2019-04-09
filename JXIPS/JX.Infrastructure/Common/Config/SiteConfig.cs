namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 网站信息配置类
	/// </summary>
	public class SiteConfig
    {
		private string m_VirtualPath;
		/// <summary>
		/// 得到或设置网站的虚拟路径： / 或者 /shop/
		/// </summary>
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

		private string m_SiteName;
		/// <summary>
		/// 网站名称
		/// </summary>
		public string SiteName
		{
			get
			{
				return this.m_SiteName;
			}
			set
			{
				this.m_SiteName = value;
			}
		}

		private string m_SiteUrl;
		/// <summary>
		/// 网站地址
		/// </summary>
		public string SiteUrl
		{
			get
			{
				return this.m_SiteUrl;
			}
			set
			{
				this.m_SiteUrl = value;
			}
		}

		private string m_Copyright;
		/// <summary>
		/// 版权信息
		/// </summary>
		public string Copyright
		{
			get
			{
				return this.m_Copyright;
			}
			set
			{
				this.m_Copyright = value;
			}
		}

		private string m_SiteTitle;
		/// <summary>
		/// 网站Title
		/// </summary>
		public string SiteTitle
		{
			get
			{
				return this.m_SiteTitle;
			}
			set
			{
				this.m_SiteTitle = value;
			}
		}

		private string m_MetaDescription;
		/// <summary>
		/// 网站META网页描述
		/// </summary>
		public string MetaDescription
		{
			get
			{
				return this.m_MetaDescription;
			}
			set
			{
				this.m_MetaDescription = value;
			}
		}

		private string m_MetaKeywords;
		/// <summary>
		/// 网站META关键词
		/// </summary>
		public string MetaKeywords
		{
			get
			{
				return this.m_MetaKeywords;
			}
			set
			{
				this.m_MetaKeywords = value;
			}
		}

		private string m_Webmaster;
		/// <summary>
		/// 站长姓名
		/// </summary>
		public string Webmaster
		{
			get
			{
				return this.m_Webmaster;
			}
			set
			{
				this.m_Webmaster = value;
			}
		}

		private string m_WebmasterEmail;
		/// <summary>
		/// 站长邮箱
		/// </summary>
		public string WebmasterEmail
		{
			get
			{
				return this.m_WebmasterEmail;
			}
			set
			{
				this.m_WebmasterEmail = value;
			}
		}

		private string m_Company = "";
		/// <summary>
		/// 公司名称
		/// </summary>
		public virtual string Company
		{
			get { return m_Company; }
			set { m_Company = value; }
		}

		private string m_Address = "";
		/// <summary>
		/// 公司地址
		/// </summary>
		public virtual string Address
		{
			get { return m_Address; }
			set { m_Address = value; }
		}

		private string m_SiteTel = "";
		/// <summary>
		/// 联系电话
		/// </summary>
		public virtual string SiteTel
		{
			get { return m_SiteTel; }
			set { m_SiteTel = value; }
		}

		private string m_SiteTel1 = "";
		/// <summary>
		/// 联系电话1
		/// </summary>
		public virtual string SiteTel1
		{
			get { return m_SiteTel1; }
			set { m_SiteTel1 = value; }
		}

		private string m_SiteTel2 = "";
		/// <summary>
		/// 联系电话2
		/// </summary>
		public virtual string SiteTel2
		{
			get { return m_SiteTel2; }
			set { m_SiteTel2 = value; }
		}

		private string m_SiteQQ;
		/// <summary>
		/// 网站QQ
		/// </summary>
		public string SiteQQ
		{
			get
			{
				return this.m_SiteQQ;
			}
			set
			{
				this.m_SiteQQ = value;
			}
		}

		private string m_SiteQQ1;
		/// <summary>
		/// 网站QQ1
		/// </summary>
		public string SiteQQ1
		{
			get
			{
				return this.m_SiteQQ1;
			}
			set
			{
				this.m_SiteQQ1 = value;
			}
		}

		private string m_SiteQQ2;
		/// <summary>
		/// 网站QQ2
		/// </summary>
		public string SiteQQ2
		{
			get
			{
				return this.m_SiteQQ2;
			}
			set
			{
				this.m_SiteQQ2 = value;
			}
		}

		private string m_ICPNO = "";
		/// <summary>
		/// 网站ICP备案号
		/// </summary>
		public virtual string ICPNO
		{
			get { return m_ICPNO; }
			set { m_ICPNO = value; }
		}
	}
}
