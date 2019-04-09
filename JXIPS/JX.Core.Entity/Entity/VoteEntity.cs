// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: VoteEntity.cs
// 修改时间：2019/4/9 17:45:15
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Vote 的实体类.
	/// </summary>
	public partial class VoteEntity
	{
		#region Properties
		private System.String _voteTitle = string.Empty;
		/// <summary>
		/// 投票的标题 
		/// </summary>
		public System.String VoteTitle
		{
			get {return _voteTitle;}
			set {_voteTitle = value;}
		}
		private System.Int32 _generalId = 0;
		/// <summary>
		/// 信息ID (主键)
		/// </summary>
		public System.Int32 GeneralId
		{
			get {return _generalId;}
			set {_generalId = value;}
		}
		private System.Boolean _isAlive = false;
		/// <summary>
		/// 是否启用投票 
		/// </summary>
		public System.Boolean IsAlive
		{
			get {return _isAlive;}
			set {_isAlive = value;}
		}
		private System.String _voteItem = string.Empty;
		/// <summary>
		/// 调查选项 
		/// </summary>
		public System.String VoteItem
		{
			get {return _voteItem;}
			set {_voteItem = value;}
		}
		private DateTime? _startTime = DateTime.MaxValue;
		/// <summary>
		/// 投票开始时间 
		/// </summary>
		public DateTime? StartTime
		{
			get {return _startTime;}
			set {_startTime = value;}
		}
		private DateTime? _endTime = DateTime.MaxValue;
		/// <summary>
		/// 投票结束时间 
		/// </summary>
		public DateTime? EndTime
		{
			get {return _endTime;}
			set {_endTime = value;}
		}
		private System.Int32 _voteTotal = 0;
		/// <summary>
		/// 投票总数 
		/// </summary>
		public System.Int32 VoteTotal
		{
			get {return _voteTotal;}
			set {_voteTotal = value;}
		}
		private System.Int32 _itemType = 0;
		/// <summary>
		/// 投票选项类型 
		/// </summary>
		public System.Int32 ItemType
		{
			get {return _itemType;}
			set {_itemType = value;}
		}
		#endregion
	}
}
