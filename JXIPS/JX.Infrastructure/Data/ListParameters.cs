using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace JX.Infrastructure.Data
{
	/// <summary>
	/// 列表查询参数
	/// </summary>
	public class ListParameters : Parameters
	{
		#region 属性
		private int m_StartRows;
		/// <summary>
		/// 开始行数
		/// </summary>
		public int StartRows
		{
			get
			{
				return this.m_StartRows;
			}
			set
			{
				this.m_StartRows = value;
			}
		}

		private int m_PageSize;
		/// <summary>
		/// 每页大小
		/// </summary>
		public int PageSize
		{
			get
			{
				return this.m_PageSize;
			}
			set
			{
				this.m_PageSize = value;
			}
		}

		private string m_SortColumn;
		/// <summary>
		/// 用于排序的列
		/// </summary>
		public string SortColumn
		{
			get
			{
				return this.m_SortColumn;
			}
			set
			{
				this.m_SortColumn = value;
			}
		}

		private SortOption m_SortOption;
		/// <summary>
		/// 排序方式
		/// </summary>
		public SortOption SortOption
		{
			get
			{
				return this.m_SortOption;
			}
			set
			{
				this.m_SortOption = value;
			}
		}

		private string m_StrColumn;
		/// <summary>
		/// 查询结果集中返回的列
		/// </summary>
		public string StrColumn
		{
			get
			{
				return this.m_StrColumn;
			}
			set
			{
				this.m_StrColumn = value;
			}
		}

		private string m_TableName;
		/// <summary>
		/// 要查询的表名
		/// </summary>
		public string TableName
		{
			get
			{
				return this.m_TableName;
			}
			set
			{
				this.m_TableName = value;
			}
		}

		private string m_Filter;
		/// <summary>
		/// 查询时的过滤条件
		/// </summary>
		public string Filter
		{
			get
			{
				return this.m_Filter;
			}
			set
			{
				this.m_Filter = value;
			}
		}

		private int m_Total;
		/// <summary>
		/// 查询的总记录数
		/// </summary>
		public int Total
		{
			get
			{
				return this.m_Total;
			}
			set
			{
				this.m_Total = value;
			}
		}
		#endregion

		/// <summary>
		/// 初始化构造
		/// </summary>
		public ListParameters(): this(1, 20, "", "*", "", SortOption.Desc, "")
		{
		}
		/// <summary>
		/// 初始化构造
		/// </summary>
		/// <param name="startRows">开始行数</param>
		/// <param name="pageSize">每页大小</param>
		public ListParameters(int startRows, int pageSize): this(startRows, pageSize, "", "*", "", SortOption.Desc, "")
		{
		}
		/// <summary>
		/// 初始化构造
		/// </summary>
		/// <param name="startRows">开始行数</param>
		/// <param name="pageSize">每页大小</param>
		/// <param name="tableName">要查询的表名</param>
		/// <param name="strColumn">查询结果集中返回的列</param>
		/// <param name="sortColumn">用于排序的列</param>
		/// <param name="SortOption">排序方式</param>
		/// <param name="filter">查询时的过滤条件</param>
		public ListParameters(int startRows, int pageSize, string tableName, string strColumn, string sortColumn, SortOption SortOption, string filter)
		{
			this.m_StartRows = startRows;
			this.m_PageSize = pageSize;
			this.m_TableName = tableName;
			this.m_StrColumn = strColumn;
			this.m_SortColumn = sortColumn;
			this.m_SortOption = SortOption;
			this.m_Filter = filter;
		}

		/// <summary>
		/// 根据初始化构造时传入的值生成参数列表集合
		/// </summary>
		public void CreateParameter()
		{
			base.Entries.Add(new Parameter("@StartRows", DbType.Int32, this.m_StartRows));
			base.Entries.Add(new Parameter("@PageSize", DbType.Int32, this.m_PageSize));
			base.Entries.Add(new Parameter("@TableName", DbType.String, this.m_TableName));
			base.Entries.Add(new Parameter("@StrColumn", DbType.String, this.m_StrColumn));
			base.Entries.Add(new Parameter("@SortColumn", DbType.String, this.m_SortColumn));
			if (this.m_SortOption == SortOption.Desc)
			{
				base.Entries.Add(new Parameter("@Sorts", DbType.String, "DESC"));
			}
			else
			{
				base.Entries.Add(new Parameter("@Sorts", DbType.String, "ASC"));
			}
			base.Entries.Add(new Parameter("@Filter", DbType.String, this.m_Filter));
			base.Entries.Add(new Parameter(ParameterDirection.Output, "@Total", DbType.Int32, null, 0));
		}

	}
}
