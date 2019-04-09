using System;
using System.Collections.Generic;
using System.Text;

namespace JX.Infrastructure.Data
{
	/// <summary>
	/// 多字段排序
	/// </summary>
	public class SortModelField
    {
		/// <summary>
		/// 排序字段名
		/// </summary>
		public string SortName { get; set; } = "";

		/// <summary>
		/// 是否倒序
		/// </summary>
		public bool IsDESC { get; set; } = true;
	}
}
