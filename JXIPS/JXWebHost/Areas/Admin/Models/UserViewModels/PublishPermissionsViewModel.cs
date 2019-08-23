using JX.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JXWebHost.Areas.Admin.Models.UserViewModels
{
	public class PublishPermissionsViewModel
	{
		/// <summary>
		/// 权限类型：0：会员；1：会员组；
		/// </summary>
		public int IdType { set; get; }
		/// <summary>
		/// 栏目节点列表
		/// </summary>
		public IList<NodesEntity> NodeList { set; get; }
		/// <summary>
		/// 会员组(会员)-节点权限列表
		/// </summary>
		public IList<GroupNodePermissionsEntity> GroupNodePermissionsList { get; set; }
		/// <summary>
		/// 权限对象
		/// </summary>
		public UserPurviewEntity PurviewEntity { get; set; }
	}
}
