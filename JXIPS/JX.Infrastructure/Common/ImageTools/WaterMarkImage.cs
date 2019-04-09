namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 水印图片的配置文件类
	/// </summary>
	public class WaterMarkImage
    {
		private string m_ImagePath;
		private int m_Transparence;
		private int m_WaterMarkPercent;
		private string m_WaterMarkPercentType;
		private string m_WaterMarkPosition;
		private int m_WaterMarkPositionX;
		private int m_WaterMarkPositionY;
		private int m_WaterMarkThumbPercent;

		/// <summary>
		/// 
		/// </summary>
		public WaterMarkImage()
		{
		}

		/// <summary>
		/// 图片相对路径，相对于站点根目录
		/// </summary>
		public string ImagePath
		{
			get
			{
				return this.m_ImagePath;
			}
			set
			{
				this.m_ImagePath = value;
			}
		}
		
		/// <summary>
		/// 水印图片透明度
		/// </summary>
		public int Transparence
		{
			get
			{
				return this.m_Transparence;
			}
			set
			{
				this.m_Transparence = value;
			}
		}

		/// <summary>
		/// 水印图片缩小比例
		/// </summary>
		public int WaterMarkPercent
		{
			get
			{
				return this.m_WaterMarkPercent;
			}
			set
			{
				this.m_WaterMarkPercent = value;
			}
		}

		/// <summary>
		/// 水印图片缩小比例类型(自动计算值/手动设置值)
		/// AutoSet：自动计算值；ManualSet：手动设置值
		/// </summary>
		public string WaterMarkPercentType
		{
			get
			{
				return this.m_WaterMarkPercentType;
			}
			set
			{
				this.m_WaterMarkPercentType = value;
			}
		}

		/// <summary>
		/// 坐标起点位置
		/// WM_TOP_LEFT：左上
		/// WM_TOP_RIGHT：右上
		/// WM_BOTTOM_RIGHT：右下
		/// WM_BOTTOM_LEFT：左下
		/// WM_SetByManual：手动设置
		/// </summary>
		public string WaterMarkPosition
		{
			get
			{
				return this.m_WaterMarkPosition;
			}
			set
			{
				this.m_WaterMarkPosition = value;
			}
		}

		/// <summary>
		/// 坐标位置X
		/// WaterMarkPosition属性设置为WM_SetByManual（手动设置）时起效
		/// </summary>
		public int WaterMarkPositionX
		{
			get
			{
				return this.m_WaterMarkPositionX;
			}
			set
			{
				this.m_WaterMarkPositionX = value;
			}
		}

		/// <summary>
		/// 坐标位置Y 
		/// WaterMarkPosition属性设置为WM_SetByManual（手动设置）时起效
		/// </summary>
		public int WaterMarkPositionY
		{
			get
			{
				return this.m_WaterMarkPositionY;
			}
			set
			{
				this.m_WaterMarkPositionY = value;
			}
		}

		/// <summary>
		/// 水印缩略图片百分比
		/// </summary>
		public int WaterMarkThumbPercent
		{
			get
			{
				return this.m_WaterMarkThumbPercent;
			}
			set
			{
				this.m_WaterMarkThumbPercent = value;
			}
		}
	}
}
