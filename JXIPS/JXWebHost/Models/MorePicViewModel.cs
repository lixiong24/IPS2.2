using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JXWebHost.Models
{
	public class MorePicViewModel
	{
		/// <summary>
		/// 控件ID前缀，同一个页面上，有多个视力组件时，用于区分相同控件的名称
		/// </summary>
		public string Prefix { get; set; } = "ctl";
		/// <summary>
		/// 上传按纽显示的名称
		/// </summary>
		public string ShowName { get; set; } = "上传图片";
		/// <summary>
		/// 上传文件总数量，默认100个
		/// </summary>
		public int FileNumLimit { get; set; } = 100;
		/// <summary>
		/// 上传文件总大小，单位为B。默认500M。例：“500 * 1024 * 1024”
		/// </summary>
		public string FileSizeLimit { get; set; } = "500 * 1024 * 1024";
		/// <summary>
		/// 单个上传文件大小，单位为B。默认1M。例：“1 * 1024 * 1024”
		/// </summary>
		public string FileSingleSizeLimit { get; set; } = "1 * 1024 * 1024";
		/// <summary>
		/// 允许上传的文件类型。例："gif,jpg,jpeg,bmp,png"
		/// </summary>
		public string FileTypes { get; set; } = "gif,jpg,jpeg,bmp,png";
		/// <summary>
		/// 允许上传的文件mime类型。多个用逗号分割。例："image/*"
		/// </summary>
		public string FileMimeTypes { get; set; } = "image/*";
		/// <summary>
		/// 得到或设置上传图片的路径
		/// </summary>
		public string PhotoPathList { get; set; } = "";
		/// <summary>
		/// 是否生成缩略图
		/// </summary>
		public bool IsThumb { get; set; } = false;
		/// <summary>
		/// 是否添加水印
		/// </summary>
		public bool IsWaterMark { get; set; } = false;
		/// <summary>
		/// 是否显示文本区域
		/// </summary>
		public bool IsShowText { get; set; } = false;
	}
}
