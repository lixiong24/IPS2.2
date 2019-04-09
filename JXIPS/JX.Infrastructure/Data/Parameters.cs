using System.Collections.Generic;
using System.Data;

namespace JX.Infrastructure.Data
{
	/// <summary>
	/// 通用数据访问参数对象集合:已经包含了常规列表参数集合
	/// </summary>
	public class Parameters
	{
		private IList<Parameter> m_Entries;
		/// <summary>
		/// 参数列表
		/// </summary>
		public IList<Parameter> Entries
		{
			get
			{
				return this.m_Entries;
			}
			set
			{
				this.m_Entries = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public Parameters()
		{
			this.m_Entries = new List<Parameter>();
		}
		/// <summary>
		/// 构造函数。根据传入的值，向参数列表中，添加一个参数项目。
		/// </summary>
		/// <param name="name">参数名</param>
		/// <param name="type">参数类型</param>
		/// <param name="value">参数值</param>
		public Parameters(string name, DbType type, object value)
		{
			this.m_Entries = new List<Parameter>();
			this.m_Entries.Add(new Parameter(name, type, value));
		}

		/// <summary>
		/// 向参数列表中，添加一个输入方向的参数项
		/// </summary>
		/// <param name="name">参数名</param>
		/// <param name="type">参数类型</param>
		/// <param name="value">参数值</param>
		public void AddInParameter(string name, DbType type, object value)
		{
			this.m_Entries.Add(new Parameter(name, type, value));
		}

		/// <summary>
		/// 向参数列表中，添加一个输出方向的参数项
		/// </summary>
		/// <param name="name">参数名</param>
		/// <param name="type">参数类型</param>
		/// <param name="size">参数大小</param>
		public void AddOutParameter(string name, DbType type, int size)
		{
			this.m_Entries.Add(new Parameter(ParameterDirection.Output, name, type, null, size));
		}
	}
}
