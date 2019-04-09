using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace JX.Core.Entity
{
	/// <summary>
	/// 栏目节点类型 枚举
	/// </summary>
	[Flags]
	public enum NodeType
	{
		/// <summary>
		/// 所有栏目
		/// </summary>
		[Description("所有栏目")]
		None,
		/// <summary>
		/// 容器栏目
		/// </summary>
		[Description("容器栏目")]
		Container,
		/// <summary>
		/// 专题栏目
		/// </summary>
		[Description("专题栏目")]
		Special,
		/// <summary>
		/// 单页栏目
		/// </summary>
		[Description("单页栏目")]
		Single,
		/// <summary>
		/// 链接栏目
		/// </summary>
		[Description("链接栏目")]
		Link
	}
}
