using System.ComponentModel.DataAnnotations;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 水印图片的配置文件类
	/// </summary>
	public class WaterMarkImage
    {
		/// <summary>
		/// 
		/// </summary>
		public WaterMarkImage()
		{
		}

		/// <summary>
		/// 图片相对路径，相对于站点根目录
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string ImagePath { get; set; }

		/// <summary>
		/// 水印图片透明度
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int Transparence { get; set; }

		/// <summary>
		/// 水印图片缩小比例
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int WaterMarkPercent { get; set; }

		/// <summary>
		/// 水印图片缩小比例类型(自动计算值/手动设置值)
		/// AutoSet：自动计算值；ManualSet：手动设置值
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string WaterMarkPercentType { get; set; } = "AutoSet";

		/// <summary>
		/// 坐标起点位置
		/// WM_TOP_LEFT：左上
		/// WM_TOP_RIGHT：右上
		/// WM_BOTTOM_RIGHT：右下
		/// WM_BOTTOM_LEFT：左下
		/// WM_SetByManual：手动设置
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string WaterMarkPosition { get; set; }

		/// <summary>
		/// 坐标位置X
		/// WaterMarkPosition属性设置为WM_SetByManual（手动设置）时起效
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int WaterMarkPositionX { get; set; }

		/// <summary>
		/// 坐标位置Y 
		/// WaterMarkPosition属性设置为WM_SetByManual（手动设置）时起效
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int WaterMarkPositionY { get; set; }

		/// <summary>
		/// 水印缩略图片百分比
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int WaterMarkThumbPercent { get; set; }
	}
}
