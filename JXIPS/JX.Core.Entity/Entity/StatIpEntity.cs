// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: StatIpEntity.cs
// 修改时间：2019/4/9 17:45:13
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：StatIp 的实体类.
	/// </summary>
	public partial class StatIpEntity
	{
		#region Properties
		private System.String _tIp = string.Empty;
		/// <summary>
		/// Ip地址 (主键)
		/// </summary>
		public System.String TIp
		{
			get {return _tIp;}
			set {_tIp = value;}
		}
		private System.Int32 _tIpNum = 0;
		/// <summary>
		/// 数量 
		/// </summary>
		public System.Int32 TIpNum
		{
			get {return _tIpNum;}
			set {_tIpNum = value;}
		}
		#endregion
	}
}
