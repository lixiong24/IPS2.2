// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: NodesTemplateEntity.cs
// 修改时间：2019/4/9 17:45:10
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：NodesTemplate 的实体类.
	/// </summary>
	public partial class NodesTemplateEntity
	{
		#region Properties
		private System.Int32 _nodeID = 0;
		/// <summary>
		/// 节点ID (主键)
		/// </summary>
		public System.Int32 NodeID
		{
			get {return _nodeID;}
			set {_nodeID = value;}
		}
		private System.Int32 _templateID = 0;
		/// <summary>
		/// 列表模板ID (主键)
		/// </summary>
		public System.Int32 TemplateID
		{
			get {return _templateID;}
			set {_templateID = value;}
		}
		private System.Boolean _isDefault = false;
		/// <summary>
		/// 是否默认 
		/// </summary>
		public System.Boolean IsDefault
		{
			get {return _isDefault;}
			set {_isDefault = value;}
		}
		#endregion
	}
}
