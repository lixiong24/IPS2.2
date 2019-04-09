// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: PointLogEntity.cs
// 修改时间：2019/4/9 17:45:11
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：PointLog 的实体类.
	/// </summary>
	public partial class PointLogEntity
	{
		#region Properties
		private System.Int32 _logID = 0;
		/// <summary>
		/// 消费点券记录ID (主键)(自增长)
		/// </summary>
		public System.Int32 LogID
		{
			get {return _logID;}
			set {_logID = value;}
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
		private System.Int32 _moduleType = 0;
		/// <summary>
		/// 信息所属功能模块 
		/// </summary>
		public System.Int32 ModuleType
		{
			get {return _moduleType;}
			set {_moduleType = value;}
		}
		private System.Int32 _infoID = 0;
		/// <summary>
		/// 信息ID 
		/// </summary>
		public System.Int32 InfoID
		{
			get {return _infoID;}
			set {_infoID = value;}
		}
		private System.Int32 _point = 0;
		/// <summary>
		/// 点数 
		/// </summary>
		public System.Int32 Point
		{
			get {return _point;}
			set {_point = value;}
		}
		private DateTime? _logTime = DateTime.MaxValue;
		/// <summary>
		/// 消费时间 
		/// </summary>
		public DateTime? LogTime
		{
			get {return _logTime;}
			set {_logTime = value;}
		}
		private System.Int32 _times = 0;
		/// <summary>
		/// 次数 
		/// </summary>
		public System.Int32 Times
		{
			get {return _times;}
			set {_times = value;}
		}
		private System.Int32 _incomePayOut = 0;
		/// <summary>
		/// 消费明细类型  1--收入  2--支出 
		/// </summary>
		public System.Int32 IncomePayOut
		{
			get {return _incomePayOut;}
			set {_incomePayOut = value;}
		}
		private System.String _remark = string.Empty;
		/// <summary>
		/// 备注 
		/// </summary>
		public System.String Remark
		{
			get {return _remark;}
			set {_remark = value;}
		}
		private System.String _ip = string.Empty;
		/// <summary>
		/// IP地址 
		/// </summary>
		public System.String IP
		{
			get {return _ip;}
			set {_ip = value;}
		}
		private System.String _inputer = string.Empty;
		/// <summary>
		/// 录入者 
		/// </summary>
		public System.String Inputer
		{
			get {return _inputer;}
			set {_inputer = value;}
		}
		private System.String _memo = string.Empty;
		/// <summary>
		/// 内部记录 
		/// </summary>
		public System.String Memo
		{
			get {return _memo;}
			set {_memo = value;}
		}
		#endregion
	}
}
