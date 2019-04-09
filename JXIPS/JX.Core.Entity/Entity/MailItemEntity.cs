// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: MailItemEntity.cs
// 修改时间：2019/4/9 17:45:09
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：MailItem 的实体类.
	/// </summary>
	public partial class MailItemEntity
	{
		#region Properties
		private System.Int32 _mailListId = 0;
		/// <summary>
		/// 邮件ID (主键)
		/// </summary>
		public System.Int32 MailListId
		{
			get {return _mailListId;}
			set {_mailListId = value;}
		}
		private System.Int32 _subscriptionItemId = 0;
		/// <summary>
		/// 订阅项ID (主键)
		/// </summary>
		public System.Int32 SubscriptionItemId
		{
			get {return _subscriptionItemId;}
			set {_subscriptionItemId = value;}
		}
		#endregion
	}
}
