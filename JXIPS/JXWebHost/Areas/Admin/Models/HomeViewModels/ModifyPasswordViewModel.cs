using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JXWebHost.Areas.Admin.Models.HomeViewModels
{
    public class ModifyPasswordViewModel
    {
		[Required(ErrorMessage = "旧密码不能为空")]
		[DataType(DataType.Password)]
		public string OldPwd { get; set; }

		[Required(ErrorMessage = "新密码不能为空")]
		[MinLength(6,ErrorMessage ="密码最少6位")]
		[DataType(DataType.Password)]
		public string NewPwd { get; set; }

		[Required(ErrorMessage = "确认密码不能为空")]
		[DataType(DataType.Password)]
		[Compare("NewPwd",ErrorMessage ="两次输入的密码不对")]
		public string ConfirmPwd { get; set; }
	}
}
