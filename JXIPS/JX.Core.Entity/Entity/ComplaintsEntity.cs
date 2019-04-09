// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: ComplaintsEntity.cs
// 修改时间：2019/4/9 17:45:06
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Complaints 的实体类.
	/// </summary>
	public partial class ComplaintsEntity
	{
		#region Properties
		private System.Int32 _cid = 0;
		/// <summary>
		/// 投诉ID/举报ID (主键)
		/// </summary>
		public System.Int32 CID
		{
			get {return _cid;}
			set {_cid = value;}
		}
		private System.String _cno = string.Empty;
		/// <summary>
		/// 查询号码 
		/// </summary>
		public System.String CNO
		{
			get {return _cno;}
			set {_cno = value;}
		}
		private System.String _cName = string.Empty;
		/// <summary>
		/// 投诉谁/举报谁 
		/// </summary>
		public System.String CName
		{
			get {return _cName;}
			set {_cName = value;}
		}
		private System.Int32 _cType = 0;
		/// <summary>
		/// 投诉类型/举报类弄 
		/// </summary>
		public System.Int32 CType
		{
			get {return _cType;}
			set {_cType = value;}
		}
		private System.Int32 _cDType = 0;
		/// <summary>
		/// 区分投诉/举报 
		/// </summary>
		public System.Int32 CDType
		{
			get {return _cDType;}
			set {_cDType = value;}
		}
		private System.String _cContent = string.Empty;
		/// <summary>
		/// 投诉内容 
		/// </summary>
		public System.String CContent
		{
			get {return _cContent;}
			set {_cContent = value;}
		}
		private System.String _cContact = string.Empty;
		/// <summary>
		/// 联系人 
		/// </summary>
		public System.String CContact
		{
			get {return _cContact;}
			set {_cContact = value;}
		}
		private DateTime? _cTime = DateTime.MaxValue;
		/// <summary>
		/// 添加时间 
		/// </summary>
		public DateTime? CTime
		{
			get {return _cTime;}
			set {_cTime = value;}
		}
		private System.String _cip = string.Empty;
		/// <summary>
		/// 投诉人/举报人IP 
		/// </summary>
		public System.String CIP
		{
			get {return _cip;}
			set {_cip = value;}
		}
		private System.Int32 _cState = 0;
		/// <summary>
		/// 状态 0 为未查看,1 已查看,2处理中,3已处理 
		/// </summary>
		public System.Int32 CState
		{
			get {return _cState;}
			set {_cState = value;}
		}
		private System.Int32 _cAdminID = 0;
		/// <summary>
		/// 最后操作人ID 
		/// </summary>
		public System.Int32 CAdminID
		{
			get {return _cAdminID;}
			set {_cAdminID = value;}
		}
		#endregion
	}
}
