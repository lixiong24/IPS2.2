// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: FavoriteEntity.cs
// 修改时间：2019/4/9 17:45:08
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Favorite 的实体类.
	/// </summary>
	public partial class FavoriteEntity
	{
		#region Properties
		private System.Int32 _favoriteID = 0;
		/// <summary>
		/// 收藏ID (主键)
		/// </summary>
		public System.Int32 FavoriteID
		{
			get {return _favoriteID;}
			set {_favoriteID = value;}
		}
		private System.Int32 _userID = 0;
		/// <summary>
		/// 用户ID 
		/// </summary>
		public System.Int32 UserID
		{
			get {return _userID;}
			set {_userID = value;}
		}
		private System.Int32 _infoID = 0;
		/// <summary>
		/// 内容信息ID 
		/// </summary>
		public System.Int32 InfoID
		{
			get {return _infoID;}
			set {_infoID = value;}
		}
		private DateTime? _favoriteTime = DateTime.MaxValue;
		/// <summary>
		/// 收藏时间 
		/// </summary>
		public DateTime? FavoriteTime
		{
			get {return _favoriteTime;}
			set {_favoriteTime = value;}
		}
		#endregion
	}
}
