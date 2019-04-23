using System.ComponentModel.DataAnnotations;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 水印文字的配置文件类
	/// </summary>
	public class WaterMarkText
    {
		/// <summary>
		/// 文字边框大小
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int FoneBorder { get; set; } = 1;
		/// <summary>
		/// 文字边框颜色
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string FoneBorderColor { get; set; } = "#000000";
		/// <summary>
		/// 文字颜色
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string FoneColor { get; set; } = "#000000";
		/// <summary>
		/// 文字大小
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int FoneSize { get; set; } = 12;
		/// <summary>
		/// 字体样式
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string FoneStyle { get; set; } = "Bold";
		/// <summary>
		/// 文字字体
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string FoneType { get; set; } = "宋体";
		/// <summary>
		/// 文字
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string Text { get; set; } = string.Empty;
		/// <summary>
		/// 坐标起点位置
		/// </summary>
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string WaterMarkPosition { get; set; } = "WM_TOP_LEFT";
		/// <summary>
		/// 坐标位置X
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int WaterMarkPositionX { get; set; } = 0;
		/// <summary>
		/// 坐标位置Y
		/// </summary>
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int WaterMarkPositionY { get; set; } = 0;
	}
}
