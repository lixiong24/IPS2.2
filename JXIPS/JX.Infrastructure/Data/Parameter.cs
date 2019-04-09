using System.Data;

namespace JX.Infrastructure.Data
{
	/// <summary>
	/// 通用数据访问参数对象。
	/// </summary>
	public class Parameter
    {
		#region 属性
		private DbType m_DBType;
		/// <summary>
		/// 参数类型
		/// </summary>
		public DbType DBType
		{
			get
			{
				return this.m_DBType;
			}
			set
			{
				this.m_DBType = value;
			}
		}

		private ParameterDirection m_Direction;
		/// <summary>
		/// 参数的输入/输出方向
		/// </summary>
		public ParameterDirection Direction
		{
			get
			{
				return this.m_Direction;
			}
			set
			{
				this.m_Direction = value;
			}
		}

		private string m_Name;
		/// <summary>
		/// 参数名
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

		private int m_Size;
		/// <summary>
		/// 参数大小
		/// </summary>
		public int Size
		{
			get
			{
				return this.m_Size;
			}
			set
			{
				this.m_Size = value;
			}
		}

		private object m_Value;
		/// <summary>
		/// 参数值
		/// </summary>
		public object Value
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				this.m_Value = value;
			}
		}
		#endregion

		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public Parameter()
		{
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="name">参数名</param>
		/// <param name="type">参数类型</param>
		/// <param name="value">参数值</param>
		public Parameter(string name, DbType type, object value): this(ParameterDirection.Input, name, type, value, 0)
		{
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="direction">参数输入/输出方向</param>
		/// <param name="name">参数名</param>
		/// <param name="type">参数类型</param>
		/// <param name="value">参数值</param>
		/// <param name="size">参数大小</param>
		public Parameter(ParameterDirection direction, string name, DbType type, object value, int size)
		{
			this.m_Direction = direction;
			this.m_Name = name;
			this.m_DBType = type;
			this.m_Value = value;
			this.m_Size = size;
		}
		#endregion
	}
}
