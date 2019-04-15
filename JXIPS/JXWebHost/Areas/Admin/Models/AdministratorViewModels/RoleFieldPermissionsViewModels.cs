using JX.Core.Entity;
using JX.Infrastructure.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JXWebHost.Areas.Admin.Models.AdministratorViewModels
{
	public class RoleFieldPermissionsViewModels
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
		/// 角色－模型－字段权限列表
		/// </summary>
		public IList<RoleFieldPermissionsEntity> RoleFieldPermissionsEntityList { get; set; }
	}
}
