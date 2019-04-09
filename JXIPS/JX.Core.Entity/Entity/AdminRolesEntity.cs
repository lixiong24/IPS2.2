// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: AdminRolesEntity.cs
// 修改时间：2019/4/9 17:45:02
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：AdminRoles 的实体类.
	/// </summary>
	public partial class AdminRolesEntity
	{
		#region Properties
		private System.Int32 _adminID = 0;
		/// <summary>
		/// 管理员ID (主键)
		/// </summary>
		public System.Int32 AdminID
		{
			get {return _adminID;}
			set {_adminID = value;}
		}
		private System.Int32 _roleID = 0;
		/// <summary>
		/// 角色ID (主键)
		/// </summary>
		public System.Int32 RoleID
		{
			get {return _roleID;}
			set {_roleID = value;}
		}
		#endregion
	}
}
