// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: RemindItemEntity.cs
// 修改时间：2019/4/9 17:45:12
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：RemindItem 的实体类.
	/// </summary>
	public partial class RemindItemEntity
	{
		#region Properties
		private System.Int32 _remindID = 0;
		/// <summary>
		/// 提醒ID (主键)
		/// </summary>
		public System.Int32 RemindID
		{
			get {return _remindID;}
			set {_remindID = value;}
		}
		private System.String _creater = string.Empty;
		/// <summary>
		/// 创建提醒的人 
		/// </summary>
		public System.String Creater
		{
			get {return _creater;}
			set {_creater = value;}
		}
		private DateTime? _createTime = DateTime.MaxValue;
		/// <summary>
		/// 创建提醒的时间 
		/// </summary>
		public DateTime? CreateTime
		{
			get {return _createTime;}
			set {_createTime = value;}
		}
		private DateTime? _remindTime = DateTime.MaxValue;
		/// <summary>
		/// 提醒时间 
		/// </summary>
		public DateTime? RemindTime
		{
			get {return _remindTime;}
			set {_remindTime = value;}
		}
		private System.String _relationType = string.Empty;
		/// <summary>
		/// 预约联系方式 
		/// </summary>
		public System.String RelationType
		{
			get {return _relationType;}
			set {_relationType = value;}
		}
		private System.String _remindContent = string.Empty;
		/// <summary>
		/// 提醒内容（备注型字段，不支持HTML） 
		/// </summary>
		public System.String RemindContent
		{
			get {return _remindContent;}
			set {_remindContent = value;}
		}
		private System.Int32 _correlativeClient = 0;
		/// <summary>
		/// 关联客户（记录客户ID） 
		/// </summary>
		public System.Int32 CorrelativeClient
		{
			get {return _correlativeClient;}
			set {_correlativeClient = value;}
		}
		private System.String _correlativeContacter = string.Empty;
		/// <summary>
		/// 关联客户的联系人 
		/// </summary>
		public System.String CorrelativeContacter
		{
			get {return _correlativeContacter;}
			set {_correlativeContacter = value;}
		}
		private System.Boolean _isRemindByTips = false;
		/// <summary>
		/// 是否冒泡提示主动提醒 
		/// </summary>
		public System.Boolean IsRemindByTips
		{
			get {return _isRemindByTips;}
			set {_isRemindByTips = value;}
		}
		private System.Boolean _isRemindByEmail = false;
		/// <summary>
		/// 是否发送邮件主动提醒 
		/// </summary>
		public System.Boolean IsRemindByEmail
		{
			get {return _isRemindByEmail;}
			set {_isRemindByEmail = value;}
		}
		private System.Boolean _isRemindBySms = false;
		/// <summary>
		/// 是否发送手机短信主动提醒 
		/// </summary>
		public System.Boolean IsRemindBySms
		{
			get {return _isRemindBySms;}
			set {_isRemindBySms = value;}
		}
		private System.Boolean _isFinish = false;
		/// <summary>
		/// 状态。0表示未处理，1表示已经处理 
		/// </summary>
		public System.Boolean IsFinish
		{
			get {return _isFinish;}
			set {_isFinish = value;}
		}
		#endregion
	}
}
