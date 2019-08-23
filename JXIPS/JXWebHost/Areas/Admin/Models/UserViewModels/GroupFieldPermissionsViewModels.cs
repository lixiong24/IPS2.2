using JX.Core.Entity;
using JX.Infrastructure.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JXWebHost.Areas.Admin.Models.UserViewModels
{
	public class GroupFieldPermissionsViewModels
	{
		/// <summary>
		/// 模型
		/// </summary>
		public ModelsEntity ModelsEntity { get; set; }
		/// <summary>
		/// 模型对应的字段列表
		/// </summary>
		public List<FieldInfo> FieldInfoList { get; set; }
		/// <summary>
		/// 会员组－模型－字段权限列表
		/// </summary>
		public IList<GroupFieldPermissionsEntity> GroupFieldPermissionsEntityList { get; set; }
	}
}
