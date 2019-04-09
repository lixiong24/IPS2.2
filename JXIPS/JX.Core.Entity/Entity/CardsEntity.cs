// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: CardsEntity.cs
// 修改时间：2019/4/9 17:45:03
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Cards 的实体类.
	/// </summary>
	public partial class CardsEntity
	{
		#region Properties
		private System.Int32 _cardID = 0;
		/// <summary>
		/// 充值卡ID (主键)(自增长)
		/// </summary>
		public System.Int32 CardID
		{
			get {return _cardID;}
			set {_cardID = value;}
		}
		private System.Int32 _cardType = 0;
		/// <summary>
		/// 充值卡类型 
		/// </summary>
		public System.Int32 CardType
		{
			get {return _cardType;}
			set {_cardType = value;}
		}
		private System.Int32 _productID = 0;
		/// <summary>
		/// 充值卡所属商品 
		/// </summary>
		public System.Int32 ProductID
		{
			get {return _productID;}
			set {_productID = value;}
		}
		private System.String _tableName = string.Empty;
		/// <summary>
		/// 表名 
		/// </summary>
		public System.String TableName
		{
			get {return _tableName;}
			set {_tableName = value;}
		}
		private System.String _cardNum = string.Empty;
		/// <summary>
		/// 卡号 
		/// </summary>
		public System.String CardNum
		{
			get {return _cardNum;}
			set {_cardNum = value;}
		}
		private System.String _password = string.Empty;
		/// <summary>
		/// 密码 
		/// </summary>
		public System.String Password
		{
			get {return _password;}
			set {_password = value;}
		}
		private System.String _agentName = string.Empty;
		/// <summary>
		/// 代理商 
		/// </summary>
		public System.String AgentName
		{
			get {return _agentName;}
			set {_agentName = value;}
		}
		private System.Decimal _money = 0;
		/// <summary>
		/// 面值 
		/// </summary>
		public System.Decimal Money
		{
			get {return _money;}
			set {_money = value;}
		}
		private System.Int32 _validNum = 0;
		/// <summary>
		/// 点数 
		/// </summary>
		public System.Int32 ValidNum
		{
			get {return _validNum;}
			set {_validNum = value;}
		}
		private System.Int32 _validUnit = 0;
		/// <summary>
		/// 点数单位 
		/// </summary>
		public System.Int32 ValidUnit
		{
			get {return _validUnit;}
			set {_validUnit = value;}
		}
		private DateTime? _endDate = DateTime.MaxValue;
		/// <summary>
		/// 截止日期 
		/// </summary>
		public DateTime? EndDate
		{
			get {return _endDate;}
			set {_endDate = value;}
		}
		private System.String _userName = string.Empty;
		/// <summary>
		/// 使用者 
		/// </summary>
		public System.String UserName
		{
			get {return _userName;}
			set {_userName = value;}
		}
		private DateTime? _useTime = DateTime.MaxValue;
		/// <summary>
		/// 充值时间 
		/// </summary>
		public DateTime? UseTime
		{
			get {return _useTime;}
			set {_useTime = value;}
		}
		private DateTime? _createTime = DateTime.MaxValue;
		/// <summary>
		/// 生成时间 
		/// </summary>
		public DateTime? CreateTime
		{
			get {return _createTime;}
			set {_createTime = value;}
		}
		private System.Int32 _orderItemID = 0;
		/// <summary>
		/// 售出 
		/// </summary>
		public System.Int32 OrderItemID
		{
			get {return _orderItemID;}
			set {_orderItemID = value;}
		}
		private System.String _productName = string.Empty;
		/// <summary>
		/// 所属商品名称 
		/// </summary>
		public System.String ProductName
		{
			get {return _productName;}
			set {_productName = value;}
		}
		#endregion
	}
}
