using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JXWebHost.Areas.Admin.Components
{
	public class SelectUserViewModel
	{
		/// <summary>
		/// 控件ID前缀，同一个页面上，有多个组件时，用于区分相同控件的名称
		/// </summary>
		public string Prefix { get; set; } = "ctl";

		/// <summary>
		/// 控件的值
		/// </summary>
		public string Value { get; set; } = "";
	}
}
