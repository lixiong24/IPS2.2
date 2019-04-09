// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: FlowProcessEntity.cs
// 修改时间：2019/4/9 17:45:08
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：FlowProcess 的实体类.
	/// </summary>
	public partial class FlowProcessEntity
	{
		#region Properties
		private System.Int32 _processID = 0;
		/// <summary>
		/// 步骤ID (主键)
		/// </summary>
		public System.Int32 ProcessID
		{
			get {return _processID;}
			set {_processID = value;}
		}
		private System.Int32 _flowID = 0;
		/// <summary>
		/// 流程ID 
		/// </summary>
		public System.Int32 FlowID
		{
			get {return _flowID;}
			set {_flowID = value;}
		}
		private System.String _processName = string.Empty;
		/// <summary>
		/// 步骤名称 
		/// </summary>
		public System.String ProcessName
		{
			get {return _processName;}
			set {_processName = value;}
		}
		private System.String _description = string.Empty;
		/// <summary>
		/// 步骤说明 
		/// </summary>
		public System.String Description
		{
			get {return _description;}
			set {_description = value;}
		}
		private System.String _passActionName = string.Empty;
		/// <summary>
		/// 通过操作的操作名，例如：一审通过 
		/// </summary>
		public System.String PassActionName
		{
			get {return _passActionName;}
			set {_passActionName = value;}
		}
		private System.Int32 _passActionStatus = 0;
		/// <summary>
		/// 通过后的状态码 
		/// </summary>
		public System.Int32 PassActionStatus
		{
			get {return _passActionStatus;}
			set {_passActionStatus = value;}
		}
		private System.String _rejectActionName = string.Empty;
		/// <summary>
		/// 打回操作的操作名 
		/// </summary>
		public System.String RejectActionName
		{
			get {return _rejectActionName;}
			set {_rejectActionName = value;}
		}
		private System.Int32 _rejectActionStatus = 0;
		/// <summary>
		/// 打回后的状态码 
		/// </summary>
		public System.Int32 RejectActionStatus
		{
			get {return _rejectActionStatus;}
			set {_rejectActionStatus = value;}
		}
		#endregion
	}
}
