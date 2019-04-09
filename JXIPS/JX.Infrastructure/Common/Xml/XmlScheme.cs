namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 自定义xml节点元信息类
	/// </summary>
	public class XmlScheme
	{
		private int m_Level;
		/// <summary>
		/// 节点层次深度
		/// </summary>
		public int Level
		{
			get
			{
				return this.m_Level;
			}
			set
			{
				this.m_Level = value;
			}
		}

		private string m_Name = string.Empty;
		/// <summary>
		/// 节点的名字
		/// </summary>
		public string Name
		{
			get
			{
				return this.m_Name;
			}
			set
			{
				this.m_Name = value;
			}
		}

		private string m_Path = string.Empty;
		/// <summary>
		/// 节点路径
		/// </summary>
		public string Path
		{
			get
			{
				return this.m_Path;
			}
			set
			{
				this.m_Path = value;
			}
		}

		private int m_Repnum = 1;
		/// <summary>
		/// 
		/// </summary>
		public int Repnum
		{
			get
			{
				return this.m_Repnum;
			}
			set
			{
				this.m_Repnum = value;
			}
		}

		private int m_Station;
		/// <summary>
		/// 节点符号
		/// </summary>
		public int Station
		{
			get
			{
				return this.m_Station;
			}
			set
			{
				this.m_Station = value;
			}
		}

		private string m_Text = string.Empty;
		/// <summary>
		/// 节点的文本
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

		private string m_Type = string.Empty;
		/// <summary>
		/// 节点类型
		/// </summary>
		public string Type
		{
			get
			{
				return this.m_Type;
			}
			set
			{
				this.m_Type = value;
			}
		}
	}
}
