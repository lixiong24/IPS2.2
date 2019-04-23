using System.ComponentModel.DataAnnotations;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 水印配置文件类
	/// </summary>
	public class WaterMarkConfig
    {
		/// <summary>
		/// 水印的类型
		/// 0：文字水印；1：图片水印
		/// </summary>
		[Required(ErrorMessage = "水印类型不能为空")]
		[RegularExpression(RegexHelper.NumberPattern, ErrorMessage = "只能输入数字")]
		public int WaterMarkType { get; set; } = 0;
		/// <summary>
		/// 获取或设置水印图片的配置文件类
		/// </summary>
		public WaterMarkImage WaterMarkImageInfo { get; set; }
		/// <summary>
		/// 获取或设置水印文字的配置文件类
		/// </summary>
		public WaterMarkText WaterMarkTextInfo { get; set; }

		/// <summary>
		/// 初始化水印的文字和图片信息
		/// </summary>
		public WaterMarkConfig()
		{
			if (this.WaterMarkTextInfo == null)
			{
				this.WaterMarkTextInfo = new WaterMarkText();
			}
			if (this.WaterMarkImageInfo == null)
			{
				this.WaterMarkImageInfo = new WaterMarkImage();
			}
		}
	}
}
