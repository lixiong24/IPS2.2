using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Admin 的实体类.
	/// </summary>
	public partial class AdminEntity
	{
		#region Properties
		/// <summary>
		/// 所属角色ID集合，多个ID用“,”分隔
		/// </summary>
		[NotMapped]
		public string RoleIDs { get; set; } = string.Empty;
		/// <summary>
		/// 所属角色名称集合，多个名称用“,”分隔
		/// </summary>
		[NotMapped]
		public string RoleNames {get;set;} = string.Empty;
		#endregion
	}
}
