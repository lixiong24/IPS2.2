// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: RolesEntity.cs
// 修改时间：2019/4/9 17:45:12
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Roles 的实体类.
	/// </summary>
	public partial class RolesEntity
	{
		#region Properties
		private System.Int32 _roleID = 0;
		/// <summary>
		/// 角色ID (主键)
		/// </summary>
		public System.Int32 RoleID
		{
			get {return _roleID;}
			set {_roleID = value;}
		}
		private System.String _roleName = string.Empty;
		/// <summary>
		/// 角色名 
		/// </summary>
		public System.String RoleName
		{
			get {return _roleName;}
			set {_roleName = value;}
		}
		private System.String _description = string.Empty;
		/// <summary>
		/// 角色说明 
		/// </summary>
		public System.String Description
		{
			get {return _description;}
			set {_description = value;}
		}
		#endregion
	}
}
