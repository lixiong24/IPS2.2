using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JXWebHost.Areas.Admin.Models.PlusViewModels
{
	public class MailViewModel
	{
		[Required(ErrorMessage = "标题不能为空")]
		public string Title { get; set; } = string.Empty;

		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string Content { get; set; } = string.Empty;

		[Required(ErrorMessage = "发件人不能为空")]
		public string Sender { get; set; } = "站长";

		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string Incept { get; set; } = string.Empty;

		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string InceptGroup { get; set; } = string.Empty;

		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string InceptEmail { get; set; } = string.Empty;

		public int InceptType { get; set; } = 0;

	}
}
