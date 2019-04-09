// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: WorkFlowsEntity.cs
// 修改时间：2019/4/9 17:45:16
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：WorkFlows 的实体类.
	/// </summary>
	public partial class WorkFlowsEntity
	{
		#region Properties
		private System.Int32 _flowID = 0;
		/// <summary>
		/// 流程ID (主键)
		/// </summary>
		public System.Int32 FlowID
		{
			get {return _flowID;}
			set {_flowID = value;}
		}
		private System.String _flowName = string.Empty;
		/// <summary>
		/// 流程名称 
		/// </summary>
		public System.String FlowName
		{
			get {return _flowName;}
			set {_flowName = value;}
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
		#endregion
	}
}
