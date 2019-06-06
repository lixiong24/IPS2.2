using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JXWebHost.Areas.Admin.Models.PlusViewModels
{
	public class MessageViewModel
	{
		public int MessageID { get; set; } = 0;

		[Required(ErrorMessage = "标题不能为空")]
		public string Title { get; set; } = string.Empty;

		[Required(ErrorMessage = "内容不能为空")]
		public string Content { get; set; } = string.Empty;

		[Required(ErrorMessage = "发件人不能为空")]
		public string Sender { get; set; } = string.Empty;

		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string Incept { get; set; } = string.Empty;

		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string InceptGroup { get; set; } = string.Empty;

		public int InceptType { get; set; } = 0;

		/// <summary>
		/// 返回给客户端的标识，用于客户端判断是否提交成功。
		/// </summary>
		public string result { get; set; } = string.Empty;
	}
}
