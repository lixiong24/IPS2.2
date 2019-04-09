// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: DeliverTypeEntity.cs
// 修改时间：2019/4/9 17:45:07
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：DeliverType 的实体类.
	/// </summary>
	public partial class DeliverTypeEntity
	{
		#region Properties
		private System.Int32 _typeID = 0;
		/// <summary>
		/// 送货方式ID (主键)
		/// </summary>
		public System.Int32 TypeID
		{
			get {return _typeID;}
			set {_typeID = value;}
		}
		private System.String _typeName = string.Empty;
		/// <summary>
		/// 送货方式名称 
		/// </summary>
		public System.String TypeName
		{
			get {return _typeName;}
			set {_typeName = value;}
		}
		private System.String _intro = string.Empty;
		/// <summary>
		/// 送货方式简介 
		/// </summary>
		public System.String Intro
		{
			get {return _intro;}
			set {_intro = value;}
		}
		private System.Int32 _chargeType = 0;
		/// <summary>
		/// 运费类型 0为免费； 1为按重量计算运费； 2为按订单金额的百分比 
		/// </summary>
		public System.Int32 ChargeType
		{
			get {return _chargeType;}
			set {_chargeType = value;}
		}
		private System.Boolean _isDefault = false;
		/// <summary>
		/// 是否默认 
		/// </summary>
		public System.Boolean IsDefault
		{
			get {return _isDefault;}
			set {_isDefault = value;}
		}
		private System.Boolean _isDisabled = false;
		/// <summary>
		/// 是否禁用 
		/// </summary>
		public System.Boolean IsDisabled
		{
			get {return _isDisabled;}
			set {_isDisabled = value;}
		}
		private System.Int32 _orderSort = 0;
		/// <summary>
		/// 排序ID 
		/// </summary>
		public System.Int32 OrderSort
		{
			get {return _orderSort;}
			set {_orderSort = value;}
		}
		private System.Int32 _releaseType = 0;
		/// <summary>
		/// 运费优惠方式， 0 为不优惠；　1 为优惠 
		/// </summary>
		public System.Int32 ReleaseType
		{
			get {return _releaseType;}
			set {_releaseType = value;}
		}
		private System.Decimal _minMoney1 = 0;
		/// <summary>
		/// 优惠要求达到的订单总金额1 
		/// </summary>
		public System.Decimal MinMoney1
		{
			get {return _minMoney1;}
			set {_minMoney1 = value;}
		}
		private System.Decimal _releaseCharge = 0;
		/// <summary>
		/// 达到总金额1时免除的运费数 
		/// </summary>
		public System.Decimal ReleaseCharge
		{
			get {return _releaseCharge;}
			set {_releaseCharge = value;}
		}
		private System.Decimal _minmoney2 = 0;
		/// <summary>
		/// 优惠要求达到的 订单总金额2 
		/// </summary>
		public System.Decimal Minmoney2
		{
			get {return _minmoney2;}
			set {_minmoney2 = value;}
		}
		private System.Decimal _maxCharge = 0;
		/// <summary>
		/// 运费总额上限条件数目 
		/// </summary>
		public System.Decimal MaxCharge
		{
			get {return _maxCharge;}
			set {_maxCharge = value;}
		}
		private System.Decimal _minMoney3 = 0;
		/// <summary>
		/// 优惠要求达到的 订单总金额3 
		/// </summary>
		public System.Decimal MinMoney3
		{
			get {return _minMoney3;}
			set {_minMoney3 = value;}
		}
		private System.Decimal _charge_Min = 0;
		/// <summary>
		/// 运费类型 = 为按订单金额的百分比 —— 基本运费 
		/// </summary>
		public System.Decimal Charge_Min
		{
			get {return _charge_Min;}
			set {_charge_Min = value;}
		}
		private System.Decimal _charge_Max = 0;
		/// <summary>
		/// 运费类型 = 为按订单金额的百分比 ——最高运费 
		/// </summary>
		public System.Decimal Charge_Max
		{
			get {return _charge_Max;}
			set {_charge_Max = value;}
		}
		private System.Int16 _charge_Percent = 0;
		/// <summary>
		/// 运费类型 = 为按订单金额的百分比 ——百分比率 
		/// </summary>
		public System.Int16 Charge_Percent
		{
			get {return _charge_Percent;}
			set {_charge_Percent = value;}
		}
		private System.Int32 _includeTax = 0;
		/// <summary>
		/// 是否含税 
		/// </summary>
		public System.Int32 IncludeTax
		{
			get {return _includeTax;}
			set {_includeTax = value;}
		}
		private System.Double _taxRate = 0.0f;
		/// <summary>
		/// 税率 
		/// </summary>
		public System.Double TaxRate
		{
			get {return _taxRate;}
			set {_taxRate = value;}
		}
		private System.Int32 _storeID = 0;
		/// <summary>
		/// 店铺ID 
		/// </summary>
		public System.Int32 StoreID
		{
			get {return _storeID;}
			set {_storeID = value;}
		}
		#endregion
	}
}
