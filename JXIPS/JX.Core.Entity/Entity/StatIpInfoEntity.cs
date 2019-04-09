// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: StatIpInfoEntity.cs
// 修改时间：2019/4/9 17:45:13
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：StatIpInfo 的实体类.
	/// </summary>
	public partial class StatIpInfoEntity
	{
		#region Properties
		private System.Int32 _id = 0;
		/// <summary>
		/// (null) (主键)(自增长)
		/// </summary>
		public System.Int32 ID
		{
			get {return _id;}
			set {_id = value;}
		}
		private System.Double _startIp = 0.0f;
		/// <summary>
		/// 起始IP 
		/// </summary>
		public System.Double StartIp
		{
			get {return _startIp;}
			set {_startIp = value;}
		}
		private System.Double _endIp = 0.0f;
		/// <summary>
		/// 结束IP 
		/// </summary>
		public System.Double EndIp
		{
			get {return _endIp;}
			set {_endIp = value;}
		}
		private System.String _address = string.Empty;
		/// <summary>
		/// 来源详细地址 
		/// </summary>
		public System.String Address
		{
			get {return _address;}
			set {_address = value;}
		}
		#endregion
	}
}
