// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: StockOutEntity.cs
// 修改时间：2019/4/9 17:45:14
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：StockOut 的实体类.
	/// </summary>
	public partial class StockOutEntity
	{
		#region Properties
		private System.Int32 _id = 0;
		/// <summary>
		/// ID (主键)(自增长)
		/// </summary>
		public System.Int32 ID
		{
			get {return _id;}
			set {_id = value;}
		}
		private System.String _email = string.Empty;
		/// <summary>
		/// Email地址 
		/// </summary>
		public System.String Email
		{
			get {return _email;}
			set {_email = value;}
		}
		private System.Int32 _userId = 0;
		/// <summary>
		/// 用户编号 
		/// </summary>
		public System.Int32 UserId
		{
			get {return _userId;}
			set {_userId = value;}
		}
		private System.String _mobile = string.Empty;
		/// <summary>
		/// 手机 
		/// </summary>
		public System.String Mobile
		{
			get {return _mobile;}
			set {_mobile = value;}
		}
		private System.Int32 _productId = 0;
		/// <summary>
		/// 产品编号 
		/// </summary>
		public System.Int32 ProductId
		{
			get {return _productId;}
			set {_productId = value;}
		}
		private System.Int32 _orderNum = 0;
		/// <summary>
		/// 订购数量 
		/// </summary>
		public System.Int32 OrderNum
		{
			get {return _orderNum;}
			set {_orderNum = value;}
		}
		private DateTime? _inputTime = DateTime.MaxValue;
		/// <summary>
		/// 登记时间 
		/// </summary>
		public DateTime? InputTime
		{
			get {return _inputTime;}
			set {_inputTime = value;}
		}
		private System.String _ip = string.Empty;
		/// <summary>
		/// IP地址 
		/// </summary>
		public System.String IP
		{
			get {return _ip;}
			set {_ip = value;}
		}
		private System.Int32 _emailStatus = 0;
		/// <summary>
		/// 邮件发送状态 
		/// </summary>
		public System.Int32 EmailStatus
		{
			get {return _emailStatus;}
			set {_emailStatus = value;}
		}
		private System.Int32 _mobileStatus = 0;
		/// <summary>
		/// 短信发送状态 
		/// </summary>
		public System.Int32 MobileStatus
		{
			get {return _mobileStatus;}
			set {_mobileStatus = value;}
		}
		private System.String _property = string.Empty;
		/// <summary>
		/// 规格 
		/// </summary>
		public System.String Property
		{
			get {return _property;}
			set {_property = value;}
		}
		#endregion
	}
}
