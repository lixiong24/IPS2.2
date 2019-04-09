using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JXWebHost.Areas.Admin.Models.HomeViewModels
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "用户名不能为空")]
		public string AdminName { get; set; }

		[Required(ErrorMessage = "密码不能为空")]
		[DataType(DataType.Password)]
		public string AdminPassword { get; set; }

		[Required(ErrorMessage = "验证码不能为空")]
		public string ValidateCode { get; set; }
	}
}
