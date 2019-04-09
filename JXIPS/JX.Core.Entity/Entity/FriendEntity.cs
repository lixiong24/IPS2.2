// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: FriendEntity.cs
// 修改时间：2019/4/9 17:45:08
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Friend 的实体类.
	/// </summary>
	public partial class FriendEntity
	{
		#region Properties
		private System.Int32 _id = 0;
		/// <summary>
		/// ID (主键)(自增长)
		/// </summary>
		public System.Int32 ID
		{
			get {return _id;}
			set {_id = value;}
		}
		private System.String _userName = string.Empty;
		/// <summary>
		/// 用户名 
		/// </summary>
		public System.String UserName
		{
			get {return _userName;}
			set {_userName = value;}
		}
		private System.String _friendName = string.Empty;
		/// <summary>
		/// 好友名称 
		/// </summary>
		public System.String FriendName
		{
			get {return _friendName;}
			set {_friendName = value;}
		}
		private DateTime? _addTime = DateTime.MaxValue;
		/// <summary>
		/// 添加时间 
		/// </summary>
		public DateTime? AddTime
		{
			get {return _addTime;}
			set {_addTime = value;}
		}
		private System.Int32 _groupID = 0;
		/// <summary>
		/// 好友分组ID 
		/// </summary>
		public System.Int32 GroupID
		{
			get {return _groupID;}
			set {_groupID = value;}
		}
		#endregion
	}
}
