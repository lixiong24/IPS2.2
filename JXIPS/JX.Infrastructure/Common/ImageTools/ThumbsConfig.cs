namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 缩略图参数配置文件类
	/// </summary>
	public class ThumbsConfig
    {
		private string m_AddBackColor;
		/// <summary>
		/// 使用补充算法时需要添加的背景色
		/// </summary>
		public string AddBackColor
		{
			get
			{
				return this.m_AddBackColor;
			}
			set
			{
				this.m_AddBackColor = value;
			}
		}

		private int m_ThumbsWidth;
		/// <summary>
		/// 缩略图默认宽度
		/// </summary>
		public int ThumbsWidth
		{
			get
			{
				return this.m_ThumbsWidth;
			}
			set
			{
				this.m_ThumbsWidth = value;
			}
		}

		private int m_ThumbsHeight;
		/// <summary>
		/// 缩略图默认高度
		/// </summary>
		public int ThumbsHeight
		{
			get
			{
				return this.m_ThumbsHeight;
			}
			set
			{
				this.m_ThumbsHeight = value;
			}
		}

		private int m_ThumbsMode;
        /// <summary>
        /// 缩略图算法。
        /// 0：常规算法：宽度和高度都大于0时，直接缩小成指定大小，其中一个为0时，按比例缩小。
        /// 1：裁剪法：宽度和高度都大于0时，先按最佳比例缩小再裁剪成指定大小，其中一个为0时，按比例缩小。
        /// 2：补充法：在指定大小的背景图上附加上按最佳比例缩小的图片。 
        /// </summary>
        public int ThumbsMode
		{
			get
			{
				return this.m_ThumbsMode;
			}
			set
			{
				this.m_ThumbsMode = value;
			}
		}
	}
}
