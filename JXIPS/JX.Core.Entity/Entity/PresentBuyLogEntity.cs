// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: PresentBuyLogEntity.cs
// 修改时间：2019/4/9 17:45:11
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：PresentBuyLog 的实体类.
	/// </summary>
	public partial class PresentBuyLogEntity
	{
		#region Properties
		private System.Int32 _logID = 0;
		/// <summary>
		/// 编号 (主键)(自增长)
		/// </summary>
		public System.Int32 LogID
		{
			get {return _logID;}
			set {_logID = value;}
		}
		private System.Int32 _productID = 0;
		/// <summary>
		/// 积分商品编号 
		/// </summary>
		public System.Int32 ProductID
		{
			get {return _productID;}
			set {_productID = value;}
		}
		private System.Int32 _userID = 0;
		/// <summary>
		/// 兑换用户编号 
		/// </summary>
		public System.Int32 UserID
		{
			get {return _userID;}
			set {_userID = value;}
		}
		private System.String _msg = string.Empty;
		/// <summary>
		/// 备注 
		/// </summary>
		public System.String Msg
		{
			get {return _msg;}
			set {_msg = value;}
		}
		private System.Boolean _isSuccess = false;
		/// <summary>
		/// 兑换状态 
		/// </summary>
		public System.Boolean IsSuccess
		{
			get {return _isSuccess;}
			set {_isSuccess = value;}
		}
		private System.Int32 _needS = 0;
		/// <summary>
		/// 所需积分 
		/// </summary>
		public System.Int32 NeedS
		{
			get {return _needS;}
			set {_needS = value;}
		}
		private DateTime? _updateTime = DateTime.MaxValue;
		/// <summary>
		/// 兑换时间 
		/// </summary>
		public DateTime? UpdateTime
		{
			get {return _updateTime;}
			set {_updateTime = value;}
		}
		private System.Int32 _buyCounts = 0;
		/// <summary>
		/// 兑换数量 
		/// </summary>
		public System.Int32 BuyCounts
		{
			get {return _buyCounts;}
			set {_buyCounts = value;}
		}
		#endregion
	}
}
