using System.ComponentModel.DataAnnotations;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 上传文件配置类
	/// </summary>
	public class UploadFilesConfig
    {
		/// <summary>
		/// 是否允许上传文件
		/// </summary>
		public bool EnableUploadFiles { get; set; } = false;
		/// <summary>
		/// 网站上传目录名（不带静态文件目录，如果想得到完整目录路径，请使用Utility.UploadDirPath()方法）
		/// </summary>
		[Required(ErrorMessage = "上传目录名不能为空")]
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string UploadDir { get; set; } = "UploadFiles";
		/// <summary>
		/// 允许上传的最大文件大小
		/// 单位：KB    提示：1 KB = 1024 Byte，1 MB = 1024 KB
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int UploadFileMaxSize { get; set; } = 1024;
		/// <summary>
		/// 允许上传文件的后缀名。如：gif,jpg,jpeg,jpe,bmp,png
		/// </summary>
		[Required(ErrorMessage = "允许上传文件的后缀名不能为空")]
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string UploadFileExts { get; set; } = "gif,jpg,jpeg,jpe,bmp,png,rar,zip,xls,xlsx,doc,docx,ppt,pptx,txt";
		/// <summary>
		/// 上传文件的保存目录规则
		/// 可用变量：{$RootDir}：一级栏目目录、{$NodeDir}：当前栏目目录、
		/// {$NodeIdentifier}：栏目标识符、{$ParentDir}：当前栏目的父目录
		/// {$Year}：年份、{$Month}：月份、{$Day}：日期、{$FileType}：文件类型
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string UploadFilePathRule { get; set; } = "{$RootDir}/{$Year}/{$Month}";
		/// <summary>
		/// 上传文件名保存规则
		/// 可用变量：{$Year}：年份、{$Month}：月份、{$Day}：日期、
		/// {$Hour}：小时、{$Minute}：分钟、{$Second}：秒、
		/// {$Origin}：原文件名、{$Random}：随机数
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string UploadFileName { get; set; } = "{$Random}";
		/// <summary>
		/// 广告上传目录
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string AdzoneFilePath { get; set; } = "UploadRSPPic";
		/// <summary>
		/// 广告上传类型。如：gif,jpg,jpeg,jpe,bmp,png
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string AdzoneFileType { get; set; } = "gif,jpg,jpeg,jpe,bmp,png,fla,swf";
		/// <summary>
		/// 公司上传目录
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string OrganizationFilePath { get; set; } = "OrganizationPic";
		/// <summary>
		/// 公司上传类型。如：gif,jpg,jpeg,jpe,bmp,png
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string OrganizationFileType { get; set; } = "gif,jpg,jpeg,jpe,bmp,png,fla,swf";
		/// <summary>
		/// 多图商品上传目录
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string ProductmultiplephotoFilePath { get; set; } = "Productmultiplephoto";
		/// <summary>
		/// 多图商品上传类型。如：gif,jpg,jpeg,jpe,bmp,png
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string ProductmultiplephotoFileType { get; set; } = "gif,jpg,jpeg,jpe,bmp,png";
		/// <summary>
		/// 商品样式上传目录
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string ProductstyleFilePath { get; set; } = "Productstyle";
		/// <summary>
		/// 商品样式上传类型。如：gif,jpg,jpeg,jpe,bmp,png
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string ProductstyleFileType { get; set; } = "gif,jpg,jpeg,jpe,bmp,png";
		/// <summary>
		/// 商品缩略图和清晰图上传目录
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string ShopFilePath { get; set; } = "Shop";
		/// <summary>
		/// 商品缩略图和清晰图上传类型。如：gif,jpg,jpeg,jpe,bmp,png
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string ShopFileType { get; set; } = "gif,jpg,jpeg,jpe,bmp,png";
		/// <summary>
		/// 品牌上传目录
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string TrademarkFilePath { get; set; } = "TrademarkPic";
		/// <summary>
		/// 品牌上传类型。如：gif,jpg,jpeg,jpe,bmp,png
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string TrademarkFileType { get; set; } = "gif,jpg,jpeg,jpe,bmp,png";
		/// <summary>
		/// 用户上传目录
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string UserFilePath { get; set; } = "UserPic";
		/// <summary>
		/// 用户上传类型。如：gif,jpg,jpeg,jpe,bmp,png
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string UserFileType { get; set; } = "gif,jpg,jpeg,jpe,bmp,png";
		/// <summary>
		/// 作者上传目录
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string AuthorFilePath { get; set; } = "AuthorPic";
		/// <summary>
		/// 作者上传类型。如：gif,jpg,jpeg,jpe,bmp,png
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string AuthorFileType { get; set; } = "gif,jpg,jpeg,jpe,bmp,png";
		/// <summary>
		/// 来源上传目录
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string SourceFilePath { get; set; } = "CopyFromPic";
		/// <summary>
		/// 来源上传类型。如：gif,jpg,jpeg,jpe,bmp,png
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string SourceFileType { get; set; } = "gif,jpg,jpeg,jpe,bmp,png";

	}
}
