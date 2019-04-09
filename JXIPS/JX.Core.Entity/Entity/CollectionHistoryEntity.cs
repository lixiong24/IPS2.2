// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: CollectionHistoryEntity.cs
// 修改时间：2019/4/9 17:45:04
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：CollectionHistory 的实体类.
	/// </summary>
	public partial class CollectionHistoryEntity
	{
		#region Properties
		private System.Int32 _historyID = 0;
		/// <summary>
		/// 采集历史记录ID (主键)
		/// </summary>
		public System.Int32 HistoryID
		{
			get {return _historyID;}
			set {_historyID = value;}
		}
		private System.Int32 _itemID = 0;
		/// <summary>
		/// 项目ID 
		/// </summary>
		public System.Int32 ItemID
		{
			get {return _itemID;}
			set {_itemID = value;}
		}
		private System.Int32 _modelID = 0;
		/// <summary>
		/// 模型ID 
		/// </summary>
		public System.Int32 ModelID
		{
			get {return _modelID;}
			set {_modelID = value;}
		}
		private System.Int32 _nodeID = 0;
		/// <summary>
		/// 栏目ID 
		/// </summary>
		public System.Int32 NodeID
		{
			get {return _nodeID;}
			set {_nodeID = value;}
		}
		private System.Int32 _generalID = 0;
		/// <summary>
		/// 文章ID 
		/// </summary>
		public System.Int32 GeneralID
		{
			get {return _generalID;}
			set {_generalID = value;}
		}
		private System.String _title = string.Empty;
		/// <summary>
		/// 信息标题 
		/// </summary>
		public System.String Title
		{
			get {return _title;}
			set {_title = value;}
		}
		private DateTime? _collectionTime = DateTime.MaxValue;
		/// <summary>
		/// 采集时间 
		/// </summary>
		public DateTime? CollectionTime
		{
			get {return _collectionTime;}
			set {_collectionTime = value;}
		}
		private System.Int32 _result = 0;
		/// <summary>
		/// 采集状态（成功，失败） 
		/// </summary>
		public System.Int32 Result
		{
			get {return _result;}
			set {_result = value;}
		}
		private System.String _newsUrl = string.Empty;
		/// <summary>
		/// 采集URL 
		/// </summary>
		public System.String NewsUrl
		{
			get {return _newsUrl;}
			set {_newsUrl = value;}
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
		#endregion
	}
}
