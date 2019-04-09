using System;
using System.ComponentModel.DataAnnotations;

namespace JXWebHost.Areas.Admin.Models.AdministratorViewModels
{
	public class AdminViewModel
    {
		public int AdminID { get; set; } = 0;

		[Required(ErrorMessage = "管理员名不能为空")]
		public string AdminName { get; set; } = string.Empty;

		
		[DataType(DataType.Password)]
		public string AdminPassword { get; set; } = string.Empty;

		[DisplayFormat(ConvertEmptyStringToNull = false)]
		public string UserName { get; set; } = string.Empty;

		[Required(ErrorMessage = "所属角色不能为空")]
		public string RoleIDs { get; set; } = string.Empty;

		public Boolean IsMultiLogin { get; set; } = false;

		public Boolean IsLock { get; set; } = false;

		public Boolean IsModifyPassword { get; set; } = false;

		/// <summary>
		/// 返回给客户端的标识，用于客户端判断是否提交成功。
		/// </summary>
		public string result { get; set; } = string.Empty;
	}
}
