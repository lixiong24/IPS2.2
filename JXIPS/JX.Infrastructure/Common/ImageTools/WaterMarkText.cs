namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 水印文字的配置文件类
	/// </summary>
	public class WaterMarkText
    {
		private int m_FoneBorder;
		/// <summary>
		/// 文字边框大小
		/// </summary>
		public int FoneBorder
		{
			get
			{
				return this.m_FoneBorder;
			}
			set
			{
				this.m_FoneBorder = value;
			}
		}

		private string m_FoneBorderColor;
		/// <summary>
		/// 文字边框颜色
		/// </summary>
		public string FoneBorderColor
		{
			get
			{
				return this.m_FoneBorderColor;
			}
			set
			{
				this.m_FoneBorderColor = value;
			}
		}

		private string m_FoneColor;
		/// <summary>
		/// 文字颜色
		/// </summary>
		public string FoneColor
		{
			get
			{
				return this.m_FoneColor;
			}
			set
			{
				this.m_FoneColor = value;
			}
		}

		private int m_FoneSize;
		/// <summary>
		/// 文字大小
		/// </summary>
		public int FoneSize
		{
			get
			{
				return this.m_FoneSize;
			}
			set
			{
				this.m_FoneSize = value;
			}
		}

		private string m_FoneStyle;
		/// <summary>
		/// 字体样式
		/// </summary>
		public string FoneStyle
		{
			get
			{
				return this.m_FoneStyle;
			}
			set
			{
				this.m_FoneStyle = value;
			}
		}

		private string m_FoneType;
		/// <summary>
		/// 文字字体
		/// </summary>
		public string FoneType
		{
			get
			{
				return this.m_FoneType;
			}
			set
			{
				this.m_FoneType = value;
			}
		}

		private string m_Text;
		/// <summary>
		/// 文字
		/// </summary>
		public string Text
		{
			get
			{
				return this.m_Text;
			}
			set
			{
				this.m_Text = value;
			}
		}

		private string m_WaterMarkPosition;
		/// <summary>
		/// 坐标起点位置
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

		private int m_WaterMarkPositionX;
		/// <summary>
		/// 坐标位置X
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

		private int m_WaterMarkPositionY;
		/// <summary>
		/// 坐标位置Y
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
	}
}
