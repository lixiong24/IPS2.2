// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: KeywordsEntity.cs
// 修改时间：2019/4/9 17:45:09
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Keywords 的实体类.
	/// </summary>
	public partial class KeywordsEntity
	{
		#region Properties
		private System.Int32 _keywordID = 0;
		/// <summary>
		/// 关键字ID (主键)(自增长)
		/// </summary>
		public System.Int32 KeywordID
		{
			get {return _keywordID;}
			set {_keywordID = value;}
		}
		private System.String _keywordText = string.Empty;
		/// <summary>
		/// 关键字名称 
		/// </summary>
		public System.String KeywordText
		{
			get {return _keywordText;}
			set {_keywordText = value;}
		}
		private System.Int32 _keywordType = 0;
		/// <summary>
		/// 关键字类别 
		/// </summary>
		public System.Int32 KeywordType
		{
			get {return _keywordType;}
			set {_keywordType = value;}
		}
		private System.Int32 _priority = 0;
		/// <summary>
		/// 关键字优先级 
		/// </summary>
		public System.Int32 Priority
		{
			get {return _priority;}
			set {_priority = value;}
		}
		private System.Int32 _hits = 0;
		/// <summary>
		/// 关键字使用量 
		/// </summary>
		public System.Int32 Hits
		{
			get {return _hits;}
			set {_hits = value;}
		}
		private DateTime? _lastUseTime = DateTime.MaxValue;
		/// <summary>
		/// 关键字最后使用时间 
		/// </summary>
		public DateTime? LastUseTime
		{
			get {return _lastUseTime;}
			set {_lastUseTime = value;}
		}
		private System.Int32 _generalID = 0;
		/// <summary>
		/// 关键字对应的内容ID 
		/// </summary>
		public System.Int32 GeneralID
		{
			get {return _generalID;}
			set {_generalID = value;}
		}
		private System.Int32 _quoteTimes = 0;
		/// <summary>
		/// 关键字被引用的次数 
		/// </summary>
		public System.Int32 QuoteTimes
		{
			get {return _quoteTimes;}
			set {_quoteTimes = value;}
		}
		#endregion
	}
}
