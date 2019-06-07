using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JXWebHost.Components
{
	public class RegionViewModel
	{
		/// <summary>
		/// 控件ID前缀，同一个页面上，有多个组件时，用于区分相同控件的名称
		/// </summary>
		public string Prefix { get; set; } = "ctl";
		/// <summary>
		/// 省
		/// </summary>
		public string Province { get; set; } = "";
		/// <summary>
		/// 市
		/// </summary>
		public string City { get; set; } = "";
		/// <summary>
		/// 区
		/// </summary>
		public string Area { get; set; } = "";
		
	}
}
