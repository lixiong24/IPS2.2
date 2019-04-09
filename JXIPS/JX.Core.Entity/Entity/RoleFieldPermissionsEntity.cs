// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: RoleFieldPermissionsEntity.cs
// 修改时间：2019/4/9 17:45:12
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：RoleFieldPermissions 的实体类.
	/// </summary>
	public partial class RoleFieldPermissionsEntity
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
		private System.Int32 _modelID = 0;
		/// <summary>
		/// 模型ID (主键)
		/// </summary>
		public System.Int32 ModelID
		{
			get {return _modelID;}
			set {_modelID = value;}
		}
		private System.String _fieldName = string.Empty;
		/// <summary>
		/// 模型字段名 (主键)
		/// </summary>
		public System.String FieldName
		{
			get {return _fieldName;}
			set {_fieldName = value;}
		}
		private System.String _operateCode = string.Empty;
		/// <summary>
		/// 权限操作码值 (主键)
		/// </summary>
		public System.String OperateCode
		{
			get {return _operateCode;}
			set {_operateCode = value;}
		}
		#endregion
	}
}
