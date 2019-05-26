using JX.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JXWebHost.Areas.Admin.Models.SiteConfigViewModels
{
	public class SiteConfigViewModel
	{
		public SiteConfig SiteConfigEntity { get; set; }

		public SiteOptionConfig SiteOptionConfigEntity { get; set; }

		public UserConfig UserConfigEntity { get; set; }

		public UploadFilesConfig UploadFilesConfigEntity { get; set; }

		public MailConfig MailConfigEntity { get; set; }

		public ThumbsConfig ThumbsConfigEntity { get; set; }

		public WaterMarkConfig WaterMarkConfigEntity { get; set; }

		public IPLockConfig IPLockConfigEntity { get; set; }

		public ShopConfig ShopConfigEntity { get; set; }
	}
}
