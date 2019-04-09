using System.Collections.Generic;

namespace JXWebHost.Areas.Admin.Models.AdministratorViewModels
{
	public class RoleMemberViewModel
    {
		public IList<JX.Core.Entity.AdminEntity> MemberByRole { set; get; }
		public IList<JX.Core.Entity.AdminEntity> MemberByNotRole { set; get; }
	}
}
