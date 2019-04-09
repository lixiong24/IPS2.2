// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: ClientEntity.cs
// 修改时间：2019/4/9 17:45:03
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Client 的实体类.
	/// </summary>
	public partial class ClientEntity
	{
		#region Properties
		private System.Int32 _clientID = 0;
		/// <summary>
		/// 客户ID (主键)
		/// </summary>
		public System.Int32 ClientID
		{
			get {return _clientID;}
			set {_clientID = value;}
		}
		private System.Int32 _parentID = 0;
		/// <summary>
		/// 上级客户ID 
		/// </summary>
		public System.Int32 ParentID
		{
			get {return _parentID;}
			set {_parentID = value;}
		}
		private System.String _clientNum = string.Empty;
		/// <summary>
		/// 客户编号 
		/// </summary>
		public System.String ClientNum
		{
			get {return _clientNum;}
			set {_clientNum = value;}
		}
		private System.Int32 _clientType = 0;
		/// <summary>
		/// 客户类别，0--企业客户，1--个人客户 
		/// </summary>
		public System.Int32 ClientType
		{
			get {return _clientType;}
			set {_clientType = value;}
		}
		private System.String _clientName = string.Empty;
		/// <summary>
		/// 客户名称（姓名） 
		/// </summary>
		public System.String ClientName
		{
			get {return _clientName;}
			set {_clientName = value;}
		}
		private System.String _shortedForm = string.Empty;
		/// <summary>
		/// 助记名称（简称） 
		/// </summary>
		public System.String ShortedForm
		{
			get {return _shortedForm;}
			set {_shortedForm = value;}
		}
		private System.Int32 _area = 0;
		/// <summary>
		/// 区域 
		/// </summary>
		public System.Int32 Area
		{
			get {return _area;}
			set {_area = value;}
		}
		private System.Int32 _clientField = 0;
		/// <summary>
		/// 行业 
		/// </summary>
		public System.Int32 ClientField
		{
			get {return _clientField;}
			set {_clientField = value;}
		}
		private System.Int32 _valueLevel = 0;
		/// <summary>
		/// 价值评估 
		/// </summary>
		public System.Int32 ValueLevel
		{
			get {return _valueLevel;}
			set {_valueLevel = value;}
		}
		private System.Int32 _creditLevel = 0;
		/// <summary>
		/// 信用等级 
		/// </summary>
		public System.Int32 CreditLevel
		{
			get {return _creditLevel;}
			set {_creditLevel = value;}
		}
		private System.Int32 _importance = 0;
		/// <summary>
		/// 重要程度 
		/// </summary>
		public System.Int32 Importance
		{
			get {return _importance;}
			set {_importance = value;}
		}
		private System.Int32 _connectionLevel = 0;
		/// <summary>
		/// 关系等级 
		/// </summary>
		public System.Int32 ConnectionLevel
		{
			get {return _connectionLevel;}
			set {_connectionLevel = value;}
		}
		private System.Int32 _groupID = 0;
		/// <summary>
		/// 客户组别 
		/// </summary>
		public System.Int32 GroupID
		{
			get {return _groupID;}
			set {_groupID = value;}
		}
		private System.Int32 _sourceType = 0;
		/// <summary>
		/// 客户来源 
		/// </summary>
		public System.Int32 SourceType
		{
			get {return _sourceType;}
			set {_sourceType = value;}
		}
		private System.Int32 _phaseType = 0;
		/// <summary>
		/// 阶段 
		/// </summary>
		public System.Int32 PhaseType
		{
			get {return _phaseType;}
			set {_phaseType = value;}
		}
		private System.String _description = string.Empty;
		/// <summary>
		/// 备注 
		/// </summary>
		public System.String Description
		{
			get {return _description;}
			set {_description = value;}
		}
		private System.Int32 _visitTimes = 0;
		/// <summary>
		/// 回访次数 
		/// </summary>
		public System.Int32 VisitTimes
		{
			get {return _visitTimes;}
			set {_visitTimes = value;}
		}
		private System.Int32 _serviceTimes = 0;
		/// <summary>
		/// 服务次数 
		/// </summary>
		public System.Int32 ServiceTimes
		{
			get {return _serviceTimes;}
			set {_serviceTimes = value;}
		}
		private System.Int32 _complainTimes = 0;
		/// <summary>
		/// 投诉次数 
		/// </summary>
		public System.Int32 ComplainTimes
		{
			get {return _complainTimes;}
			set {_complainTimes = value;}
		}
		private DateTime? _lastVisitTime = DateTime.MaxValue;
		/// <summary>
		/// 上次回访时间 
		/// </summary>
		public DateTime? LastVisitTime
		{
			get {return _lastVisitTime;}
			set {_lastVisitTime = value;}
		}
		private DateTime? _lastServiceTime = DateTime.MaxValue;
		/// <summary>
		/// 上次服务时间 
		/// </summary>
		public DateTime? LastServiceTime
		{
			get {return _lastServiceTime;}
			set {_lastServiceTime = value;}
		}
		private DateTime? _lastComplainTime = DateTime.MaxValue;
		/// <summary>
		/// 上次投诉时间 
		/// </summary>
		public DateTime? LastComplainTime
		{
			get {return _lastComplainTime;}
			set {_lastComplainTime = value;}
		}
		private DateTime? _createTime = DateTime.MaxValue;
		/// <summary>
		/// 创建时间 
		/// </summary>
		public DateTime? CreateTime
		{
			get {return _createTime;}
			set {_createTime = value;}
		}
		private DateTime? _updateTime = DateTime.MaxValue;
		/// <summary>
		/// 更新时间 
		/// </summary>
		public DateTime? UpdateTime
		{
			get {return _updateTime;}
			set {_updateTime = value;}
		}
		private System.String _owner = string.Empty;
		/// <summary>
		/// 所有者 
		/// </summary>
		public System.String Owner
		{
			get {return _owner;}
			set {_owner = value;}
		}
		private System.Decimal _balance = 0;
		/// <summary>
		/// 资金余额 
		/// </summary>
		public System.Decimal Balance
		{
			get {return _balance;}
			set {_balance = value;}
		}
		private DateTime? _lastContactedTime = DateTime.MaxValue;
		/// <summary>
		/// 最近联系时间 
		/// </summary>
		public DateTime? LastContactedTime
		{
			get {return _lastContactedTime;}
			set {_lastContactedTime = value;}
		}
		private System.String _remark = string.Empty;
		/// <summary>
		/// 备注 
		/// </summary>
		public System.String Remark
		{
			get {return _remark;}
			set {_remark = value;}
		}
		#endregion
	}
}
