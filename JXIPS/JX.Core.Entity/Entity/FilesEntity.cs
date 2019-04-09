// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: FilesEntity.cs
// 修改时间：2019/4/9 17:45:08
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Files 的实体类.
	/// </summary>
	public partial class FilesEntity
	{
		#region Properties
		private System.Int32 _id = 0;
		/// <summary>
		/// 文件ID (主键)
		/// </summary>
		public System.Int32 ID
		{
			get {return _id;}
			set {_id = value;}
		}
		private System.String _name = string.Empty;
		/// <summary>
		/// 文件名 
		/// </summary>
		public System.String Name
		{
			get {return _name;}
			set {_name = value;}
		}
		private System.Int32 _size = 0;
		/// <summary>
		/// 文件大小 
		/// </summary>
		public System.Int32 Size
		{
			get {return _size;}
			set {_size = value;}
		}
		private System.String _path = string.Empty;
		/// <summary>
		/// 文件存放路径 
		/// </summary>
		public System.String Path
		{
			get {return _path;}
			set {_path = value;}
		}
		private System.String _userName = string.Empty;
		/// <summary>
		/// 用户名称 
		/// </summary>
		public System.String UserName
		{
			get {return _userName;}
			set {_userName = value;}
		}
		private System.String _fileType = string.Empty;
		/// <summary>
		/// 文件类型 
		/// </summary>
		public System.String FileType
		{
			get {return _fileType;}
			set {_fileType = value;}
		}
		#endregion
	}
}
