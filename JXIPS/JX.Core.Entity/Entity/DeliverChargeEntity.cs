// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: DeliverChargeEntity.cs
// 修改时间：2019/4/9 17:45:07
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：DeliverCharge 的实体类.
	/// </summary>
	public partial class DeliverChargeEntity
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
		private System.Int32 _deliverTypeID = 0;
		/// <summary>
		/// 送货方式ID 
		/// </summary>
		public System.Int32 DeliverTypeID
		{
			get {return _deliverTypeID;}
			set {_deliverTypeID = value;}
		}
		private System.Int32 _areaType = 0;
		/// <summary>
		/// 1为同城，2为同一区域，3为同省，4为指定省份，5为国际 
		/// </summary>
		public System.Int32 AreaType
		{
			get {return _areaType;}
			set {_areaType = value;}
		}
		private System.String _arrArea = string.Empty;
		/// <summary>
		/// 指定的区域或省份 
		/// </summary>
		public System.String ArrArea
		{
			get {return _arrArea;}
			set {_arrArea = value;}
		}
		private System.Decimal _charge_Min = 0;
		/// <summary>
		/// 基础运费 
		/// </summary>
		public System.Decimal Charge_Min
		{
			get {return _charge_Min;}
			set {_charge_Min = value;}
		}
		private System.Double _weight_Min = 0.0f;
		/// <summary>
		/// 基础运费的起算重量 
		/// </summary>
		public System.Double Weight_Min
		{
			get {return _weight_Min;}
			set {_weight_Min = value;}
		}
		private System.Decimal _chargePerUnit = 0;
		/// <summary>
		/// 单位运费 
		/// </summary>
		public System.Decimal ChargePerUnit
		{
			get {return _chargePerUnit;}
			set {_chargePerUnit = value;}
		}
		private System.Double _weightPerUnit = 0.0f;
		/// <summary>
		/// 单位重量 
		/// </summary>
		public System.Double WeightPerUnit
		{
			get {return _weightPerUnit;}
			set {_weightPerUnit = value;}
		}
		private System.Decimal _charge_Max = 0;
		/// <summary>
		/// 最高运费 
		/// </summary>
		public System.Decimal Charge_Max
		{
			get {return _charge_Max;}
			set {_charge_Max = value;}
		}
		#endregion
	}
}
