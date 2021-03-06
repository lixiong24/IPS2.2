﻿using JX.Core.Entity;
using JX.Infrastructure.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JXWebHost.Areas.Admin.Models.UserViewModels
{
	public class UserGroupPermissionsViewModels
	{
		/// <summary>
		/// 权限类型：0：会员；1：会员组；
		/// </summary>
		public int IdType { set; get; }
		/// <summary>
		/// 菜单列表
		/// </summary>
		public IList<MenuEntity> MenuEntityList { get; set; }
		/// <summary>
		/// 菜单权限码
		/// </summary>
		public string GroupPermissionsList { get; set; }
		/// <summary>
		/// 会员组－字段权限视图类列表
		/// </summary>
		public List<GroupFieldPermissionsViewModels> GroupFieldPermissionsViewModelsList { get; set; }
		/// <summary>
		/// 权限对象
		/// </summary>
		public UserPurviewEntity PurviewEntity { get; set; }
	}
}
