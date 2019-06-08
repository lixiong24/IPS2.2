using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

		/// <summary>
		/// 是否必须填写
		/// </summary>
		public bool IsRequired { get; set; } = false;

		/// <summary>
		/// 必须填写的文本
		/// </summary>
		public string RequiredText { get; set; } = "不能为空";
	}
}
