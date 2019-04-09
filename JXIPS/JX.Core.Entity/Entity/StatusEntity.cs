// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: StatusEntity.cs
// 修改时间：2019/4/9 17:45:13
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Status 的实体类.
	/// </summary>
	public partial class StatusEntity
	{
		#region Properties
		private System.Int32 _statusID = 0;
		/// <summary>
		/// 状态码ID (主键)
		/// </summary>
		public System.Int32 StatusID
		{
			get {return _statusID;}
			set {_statusID = value;}
		}
		private System.Int32 _statusCode = 0;
		/// <summary>
		/// 状态码 
		/// </summary>
		public System.Int32 StatusCode
		{
			get {return _statusCode;}
			set {_statusCode = value;}
		}
		private System.String _statusName = string.Empty;
		/// <summary>
		/// 状态码名 
		/// </summary>
		public System.String StatusName
		{
			get {return _statusName;}
			set {_statusName = value;}
		}
		private System.Int32 _statusType = 0;
		/// <summary>
		/// 系统状态码 
		/// </summary>
		public System.Int32 StatusType
		{
			get {return _statusType;}
			set {_statusType = value;}
		}
		#endregion
	}
}
