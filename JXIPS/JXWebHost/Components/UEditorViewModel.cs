using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JXWebHost.Components
{
	public class UEditorViewModel
	{
		/// <summary>
		/// 控件ID，同一个页面上，有多个组件时，用于区分相同控件的名称
		/// </summary>
		public string ClientID { get; set; } = "ctlUEditor";
		/// <summary>
		/// 编辑器内容
		/// </summary>
		public string Content { get; set; } = "";
		
	}
}
