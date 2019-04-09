// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: NodesModelTemplateEntity.cs
// 修改时间：2019/4/9 17:45:10
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：NodesModelTemplate 的实体类.
	/// </summary>
	public partial class NodesModelTemplateEntity
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
		private System.Int32 _modelID = 0;
		/// <summary>
		/// 模型ID (主键)
		/// </summary>
		public System.Int32 ModelID
		{
			get {return _modelID;}
			set {_modelID = value;}
		}
		private System.String _defaultTemplateFile = string.Empty;
		/// <summary>
		/// 内容模板ID 
		/// </summary>
		public System.String DefaultTemplateFile
		{
			get {return _defaultTemplateFile;}
			set {_defaultTemplateFile = value;}
		}
		#endregion
	}
}
