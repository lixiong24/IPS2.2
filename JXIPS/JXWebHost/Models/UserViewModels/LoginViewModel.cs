using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JXWebHost.Models.UserViewModels
{
    public class LoginViewModel
    {
        [Display(Name ="用户名")]
		[Required(ErrorMessage = "会员名不能为空")]
		public string UserName { get; set; }

        [Display(Name ="密码")]
		[Required(ErrorMessage = "密码不能为空")]
		[DataType(DataType.Password)]
		public string UserPassword { get; set; }

        [Display(Name = "图形验证码")]
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string ValidateCode { get; set; }

		[Display(Name = "记住我")]
		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public bool IsPersistent { get; set; } = false;
	}
}
