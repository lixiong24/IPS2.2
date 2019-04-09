// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: UserGroupsEntity.cs
// 修改时间：2019/4/9 17:45:15
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：UserGroups 的实体类.
	/// </summary>
	public partial class UserGroupsEntity
	{
		#region Properties
		private System.Int32 _groupID = 0;
		/// <summary>
		/// 用户组ID (主键)
		/// </summary>
		public System.Int32 GroupID
		{
			get {return _groupID;}
			set {_groupID = value;}
		}
		private System.String _groupName = string.Empty;
		/// <summary>
		/// 用户组名 
		/// </summary>
		public System.String GroupName
		{
			get {return _groupName;}
			set {_groupName = value;}
		}
		private System.String _description = string.Empty;
		/// <summary>
		/// 用户组说明 
		/// </summary>
		public System.String Description
		{
			get {return _description;}
			set {_description = value;}
		}
		private System.String _settings = string.Empty;
		/// <summary>
		/// 用户组设置，用XML保存如下配置。 
		/// </summary>
		public System.String Settings
		{
			get {return _settings;}
			set {_settings = value;}
		}
		private System.Int32 _groupType = 0;
		/// <summary>
		/// 用户类型 
		/// </summary>
		public System.Int32 GroupType
		{
			get {return _groupType;}
			set {_groupType = value;}
		}
		private System.String _groupSetting = string.Empty;
		/// <summary>
		/// 用户权限 
		/// </summary>
		public System.String GroupSetting
		{
			get {return _groupSetting;}
			set {_groupSetting = value;}
		}
		private System.String _upgradeSetting = string.Empty;
		/// <summary>
		/// 用户升级参数设置 
		/// </summary>
		public System.String UpgradeSetting
		{
			get {return _upgradeSetting;}
			set {_upgradeSetting = value;}
		}
		#endregion
	}
}
