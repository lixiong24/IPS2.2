// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: U_GuestBookEntity.cs
// 修改时间：2019/4/9 17:45:14
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：U_GuestBook 的实体类.
	/// </summary>
	public partial class U_GuestBookEntity
	{
		#region Properties
		private System.Int32 _id = 0;
		/// <summary>
		///  (主键)
		/// </summary>
		public System.Int32 ID
		{
			get {return _id;}
			set {_id = value;}
		}
		private System.String _guestName = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String GuestName
		{
			get {return _guestName;}
			set {_guestName = value;}
		}
		private System.String _guestOicq = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String GuestOicq
		{
			get {return _guestOicq;}
			set {_guestOicq = value;}
		}
		private System.String _guestMsn = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String GuestMsn
		{
			get {return _guestMsn;}
			set {_guestMsn = value;}
		}
		private System.String _guestEmail = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String GuestEmail
		{
			get {return _guestEmail;}
			set {_guestEmail = value;}
		}
		private System.String _guestContent = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String GuestContent
		{
			get {return _guestContent;}
			set {_guestContent = value;}
		}
		private System.Boolean _guestIsPrivate = false;
		/// <summary>
		///  
		/// </summary>
		public System.Boolean GuestIsPrivate
		{
			get {return _guestIsPrivate;}
			set {_guestIsPrivate = value;}
		}
		private System.String _guestFace = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String GuestFace
		{
			get {return _guestFace;}
			set {_guestFace = value;}
		}
		private System.String _guestHomepage = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String GuestHomepage
		{
			get {return _guestHomepage;}
			set {_guestHomepage = value;}
		}
		private System.String _guestImages = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String GuestImages
		{
			get {return _guestImages;}
			set {_guestImages = value;}
		}
		private System.String _adminReply = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String AdminReply
		{
			get {return _adminReply;}
			set {_adminReply = value;}
		}
		private DateTime? _adminReplyTime = DateTime.MaxValue;
		/// <summary>
		///  
		/// </summary>
		public DateTime? AdminReplyTime
		{
			get {return _adminReplyTime;}
			set {_adminReplyTime = value;}
		}
		#endregion
	}
}
