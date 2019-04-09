// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: ClientLogEntity.cs
// 修改时间：2019/4/9 17:45:03
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：ClientLog 的实体类.
	/// </summary>
	public partial class ClientLogEntity
	{
		#region Properties
		private System.Int32 _clientLogID = 0;
		/// <summary>
		/// 客户历史记录ID (主键)
		/// </summary>
		public System.Int32 ClientLogID
		{
			get {return _clientLogID;}
			set {_clientLogID = value;}
		}
		private System.Int32 _clientID = 0;
		/// <summary>
		/// 客户ID 
		/// </summary>
		public System.Int32 ClientID
		{
			get {return _clientID;}
			set {_clientID = value;}
		}
		private System.String _relationType = string.Empty;
		/// <summary>
		/// 联系类型 
		/// </summary>
		public System.String RelationType
		{
			get {return _relationType;}
			set {_relationType = value;}
		}
		private DateTime? _relationTime = DateTime.MaxValue;
		/// <summary>
		/// 联系时间 
		/// </summary>
		public DateTime? RelationTime
		{
			get {return _relationTime;}
			set {_relationTime = value;}
		}
		private System.String _contacter = string.Empty;
		/// <summary>
		/// 联系人 
		/// </summary>
		public System.String Contacter
		{
			get {return _contacter;}
			set {_contacter = value;}
		}
		private System.String _annalContent = string.Empty;
		/// <summary>
		/// 记录内容 
		/// </summary>
		public System.String AnnalContent
		{
			get {return _annalContent;}
			set {_annalContent = value;}
		}
		private DateTime? _annalTime = DateTime.MaxValue;
		/// <summary>
		/// 记录时间 
		/// </summary>
		public DateTime? AnnalTime
		{
			get {return _annalTime;}
			set {_annalTime = value;}
		}
		private System.String _inputer = string.Empty;
		/// <summary>
		/// 记录人 
		/// </summary>
		public System.String Inputer
		{
			get {return _inputer;}
			set {_inputer = value;}
		}
		#endregion
	}
}
