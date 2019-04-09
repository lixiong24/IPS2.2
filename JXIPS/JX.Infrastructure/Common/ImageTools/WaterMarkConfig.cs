namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 水印配置文件类
	/// </summary>
	public class WaterMarkConfig
    {
		private int m_WaterMarkType;
		/// <summary>
		/// 水印的类型
		/// 0：文字水印；1：图片水印
		/// </summary>
		public int WaterMarkType
		{
			get
			{
				return this.m_WaterMarkType;
			}
			set
			{
				this.m_WaterMarkType = value;
			}
		}

		private WaterMarkImage waterMarkImageInfo;
		/// <summary>
		/// 获取或设置水印图片的配置文件类
		/// </summary>
		public WaterMarkImage WaterMarkImageInfo
		{
			get
			{
				return this.waterMarkImageInfo;
			}
			set
			{
				this.waterMarkImageInfo = value;
			}
		}

		private WaterMarkText waterMarkTextInfo;
		/// <summary>
		/// 获取或设置水印文字的配置文件类
		/// </summary>
		public WaterMarkText WaterMarkTextInfo
		{
			get
			{
				return this.waterMarkTextInfo;
			}
			set
			{
				this.waterMarkTextInfo = value;
			}
		}
		
		/// <summary>
		/// 初始化水印的文字和图片信息
		/// </summary>
		public WaterMarkConfig()
		{
			if (this.waterMarkTextInfo == null)
			{
				this.waterMarkTextInfo = new WaterMarkText();
			}
			if (this.waterMarkImageInfo == null)
			{
				this.waterMarkImageInfo = new WaterMarkImage();
			}
		}
	}
}
