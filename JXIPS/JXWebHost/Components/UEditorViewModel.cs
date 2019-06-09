using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JXWebHost.Components
{
	public class UEditorViewModel
	{
		/// <summary>
		/// 控件ID，同一个页面上，有多个组件时，用于区分相同控件的名称。默认：ctlUEditor
		/// </summary>
		public string ClientID { get; set; } = "ctlUEditor";
		/// <summary>
		/// 编辑器内容
		/// </summary>
		public string Content { get; set; } = string.Empty;
		/// <summary>
		/// 是否必须填写
		/// </summary>
		public bool IsRequired { get; set; } = false;
		/// <summary>
		/// 必须填写的文本
		/// </summary>
		public string RequiredText { get; set; } = "不能为空";

		private string _ToolbarSet = string.Empty;
		/// <summary>
		/// 工具栏（Default：全部；Simple：简单；）
		/// </summary>
		public string ToolbarSet
		{
			get
			{
				switch (_ToolbarSet)
				{
					case "Simple":
						_ToolbarSet = ",toolbars: [['fullscreen', 'source', 'undo', 'redo', 'bold', 'italic', 'underline', 'fontborder', 'strikethrough', 'superscript', 'subscript', 'removeformat', 'formatmatch', 'autotypeset', 'blockquote', 'pasteplain', '|', 'forecolor', 'backcolor', 'insertorderedlist', 'insertunorderedlist', 'selectall', 'cleardoc']]";
						break;
					default:
						_ToolbarSet = string.Empty;
						break;
				}
				return _ToolbarSet;
			}
			set { _ToolbarSet = value; }
		}
	}
}
