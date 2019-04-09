namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 上传文件配置类
	/// </summary>
	public class UploadFilesConfig
    {
		private bool m_EnableUploadFiles=false;
		/// <summary>
		/// 是否允许上传文件
		/// </summary>
		public bool EnableUploadFiles
		{
			get
			{
				return this.m_EnableUploadFiles;
			}
			set
			{
				this.m_EnableUploadFiles = value;
			}
		}

		private string m_UploadDir = "UploadFiles";
		/// <summary>
		/// 网站上传目录名（不带静态文件目录，如果想得到完整目录路径，请使用Utility.UploadDirPath()方法）
		/// </summary>
		public string UploadDir
		{
			get
			{
				return this.m_UploadDir;
			}
			set
			{
				this.m_UploadDir = value;
			}
		}

		private int m_UploadFileMaxSize=1024;
		/// <summary>
		/// 允许上传的最大文件大小
		/// 单位：KB    提示：1 KB = 1024 Byte，1 MB = 1024 KB
		/// </summary>
		public int UploadFileMaxSize
		{
			get
			{
				return this.m_UploadFileMaxSize;
			}
			set
			{
				this.m_UploadFileMaxSize = value;
			}
		}

		private string m_UploadFileExts = "gif,jpg,jpeg,jpe,bmp,png,rar,zip,xls,xlsx,doc,docx,ppt,pptx,txt";
		/// <summary>
		/// 允许上传文件的后缀名。如：gif,jpg,jpeg,jpe,bmp,png
		/// </summary>
		public string UploadFileExts
		{
			get
			{
				return this.m_UploadFileExts;
			}
			set
			{
				this.m_UploadFileExts = value;
			}
		}

		private string m_UploadFilePathRule = "{$RootDir}/{$Year}/{$Month}";
		/// <summary>
		/// 上传文件的保存目录规则
		/// 可用变量：{$RootDir}：一级栏目目录、{$NodeDir}：当前栏目目录、
		/// {$NodeIdentifier}：栏目标识符、{$ParentDir}：当前栏目的父目录
		/// {$Year}：年份、{$Month}：月份、{$Day}：日期、{$FileType}：文件类型
		/// </summary>
		public string UploadFilePathRule
		{
			get
			{
				return this.m_UploadFilePathRule;
			}
			set
			{
				this.m_UploadFilePathRule = value;
			}
		}

		private string m_UploadFileName= "{$Random}";
		/// <summary>
		/// 上传文件名保存规则
		/// 可用变量：{$Year}：年份、{$Month}：月份、{$Day}：日期、
		/// {$Hour}：小时、{$Minute}：分钟、{$Second}：秒、
		/// {$Origin}：原文件名、{$Random}：随机数
		/// </summary>
		public string UploadFileName
		{
			get
			{
				return this.m_UploadFileName;
			}
			set
			{
				this.m_UploadFileName = value;
			}
		}

		private string m_AdzoneFilePath= "UploadRSPPic";
		/// <summary>
		/// 广告上传目录
		/// </summary>
		public string AdzoneFilePath
		{
			get
			{
				return this.m_AdzoneFilePath;
			}
			set
			{
				this.m_AdzoneFilePath = value;
			}
		}

		private string m_AdzoneFileType= "gif,jpg,jpeg,jpe,bmp,png,fla,swf";
		/// <summary>
		/// 广告上传类型。如：gif,jpg,jpeg,jpe,bmp,png
		/// </summary>
		public string AdzoneFileType
		{
			get
			{
				return this.m_AdzoneFileType;
			}
			set
			{
				this.m_AdzoneFileType = value;
			}
		}

		private string m_OrganizationFilePath = "OrganizationPic";
		/// <summary>
		/// 公司上传目录
		/// </summary>
		public string OrganizationFilePath
		{
			get
			{
				return this.m_OrganizationFilePath;
			}
			set
			{
				this.m_OrganizationFilePath = value;
			}
		}

		private string m_OrganizationFileType = "gif,jpg,jpeg,jpe,bmp,png,fla,swf";
		/// <summary>
		/// 公司上传类型。如：gif,jpg,jpeg,jpe,bmp,png
		/// </summary>
		public string OrganizationFileType
		{
			get
			{
				return this.m_OrganizationFileType;
			}
			set
			{
				this.m_OrganizationFileType = value;
			}
		}

		private string m_ProductmultiplephotoFilePath = "Productmultiplephoto";
		/// <summary>
		/// 多图商品上传目录
		/// </summary>
		public string ProductmultiplephotoFilePath
		{
			get
			{
				return this.m_ProductmultiplephotoFilePath;
			}
			set
			{
				this.m_ProductmultiplephotoFilePath = value;
			}
		}

		private string m_ProductmultiplephotoFileType = "gif,jpg,jpeg,jpe,bmp,png";
		/// <summary>
		/// 多图商品上传类型。如：gif,jpg,jpeg,jpe,bmp,png
		/// </summary>
		public string ProductmultiplephotoFileType
		{
			get
			{
				return this.m_ProductmultiplephotoFileType;
			}
			set
			{
				this.m_ProductmultiplephotoFileType = value;
			}
		}

		private string m_ProductstyleFilePath = "Productstyle";
		/// <summary>
		/// 商品样式上传目录
		/// </summary>
		public string ProductstyleFilePath
		{
			get
			{
				return this.m_ProductstyleFilePath;
			}
			set
			{
				this.m_ProductstyleFilePath = value;
			}
		}

		private string m_ProductstyleFileType = "gif,jpg,jpeg,jpe,bmp,png";
		/// <summary>
		/// 商品样式上传类型。如：gif,jpg,jpeg,jpe,bmp,png
		/// </summary>
		public string ProductstyleFileType
		{
			get
			{
				return this.m_ProductstyleFileType;
			}
			set
			{
				this.m_ProductstyleFileType = value;
			}
		}

		private string m_ShopFilePath = "Shop";
		/// <summary>
		/// 商品缩略图和清晰图上传目录
		/// </summary>
		public string ShopFilePath
		{
			get
			{
				return this.m_ShopFilePath;
			}
			set
			{
				this.m_ShopFilePath = value;
			}
		}

		private string m_ShopFileType = "gif,jpg,jpeg,jpe,bmp,png";
		/// <summary>
		/// 商品缩略图和清晰图上传类型。如：gif,jpg,jpeg,jpe,bmp,png
		/// </summary>
		public string ShopFileType
		{
			get
			{
				return this.m_ShopFileType;
			}
			set
			{
				this.m_ShopFileType = value;
			}
		}

		private string m_TrademarkFilePath = "TrademarkPic";
		/// <summary>
		/// 品牌上传目录
		/// </summary>
		public string TrademarkFilePath
		{
			get
			{
				return this.m_TrademarkFilePath;
			}
			set
			{
				this.m_TrademarkFilePath = value;
			}
		}

		private string m_TrademarkFileType = "gif,jpg,jpeg,jpe,bmp,png";
		/// <summary>
		/// 品牌上传类型。如：gif,jpg,jpeg,jpe,bmp,png
		/// </summary>
		public string TrademarkFileType
		{
			get
			{
				return this.m_TrademarkFileType;
			}
			set
			{
				this.m_TrademarkFileType = value;
			}
		}

		private string m_UserFilePath = "UserPic";
		/// <summary>
		/// 用户上传目录
		/// </summary>
		public string UserFilePath
		{
			get
			{
				return this.m_UserFilePath;
			}
			set
			{
				this.m_UserFilePath = value;
			}
		}

		private string m_UserFileType = "gif,jpg,jpeg,jpe,bmp,png";
		/// <summary>
		/// 用户上传类型。如：gif,jpg,jpeg,jpe,bmp,png
		/// </summary>
		public string UserFileType
		{
			get
			{
				return this.m_UserFileType;
			}
			set
			{
				this.m_UserFileType = value;
			}
		}

		private string m_AuthorFilePath = "AuthorPic";
		/// <summary>
		/// 作者上传目录
		/// </summary>
		public string AuthorFilePath
		{
			get
			{
				return this.m_AuthorFilePath;
			}
			set
			{
				this.m_AuthorFilePath = value;
			}
		}

		private string m_AuthorFileType = "gif,jpg,jpeg,jpe,bmp,png";
		/// <summary>
		/// 作者上传类型。如：gif,jpg,jpeg,jpe,bmp,png
		/// </summary>
		public string AuthorFileType
		{
			get
			{
				return this.m_AuthorFileType;
			}
			set
			{
				this.m_AuthorFileType = value;
			}
		}

		private string m_SourceFilePath = "CopyFromPic";
		/// <summary>
		/// 来源上传目录
		/// </summary>
		public string SourceFilePath
		{
			get
			{
				return this.m_SourceFilePath;
			}
			set
			{
				this.m_SourceFilePath = value;
			}
		}

		private string m_SourceFileType = "gif,jpg,jpeg,jpe,bmp,png";
		/// <summary>
		/// 来源上传类型。如：gif,jpg,jpeg,jpe,bmp,png
		/// </summary>
		public string SourceFileType
		{
			get
			{
				return this.m_SourceFileType;
			}
			set
			{
				this.m_SourceFileType = value;
			}
		}
		
	}
}
