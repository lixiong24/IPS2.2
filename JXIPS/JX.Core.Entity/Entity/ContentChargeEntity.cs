// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: ContentChargeEntity.cs
// 修改时间：2019/4/9 17:45:06
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：ContentCharge 的实体类.
	/// </summary>
	public partial class ContentChargeEntity
	{
		#region Properties
		private System.Int32 _generalID = 0;
		/// <summary>
		/// 内容ID (主键)
		/// </summary>
		public System.Int32 GeneralID
		{
			get {return _generalID;}
			set {_generalID = value;}
		}
		private System.Int32 _chargeType = 0;
		/// <summary>
		/// 重复收费方式 
		/// </summary>
		public System.Int32 ChargeType
		{
			get {return _chargeType;}
			set {_chargeType = value;}
		}
		private System.Int32 _infoPoint = 0;
		/// <summary>
		/// 阅读点数 
		/// </summary>
		public System.Int32 InfoPoint
		{
			get {return _infoPoint;}
			set {_infoPoint = value;}
		}
		private System.Int32 _pitchTime = 0;
		/// <summary>
		/// 重复收费小时数 
		/// </summary>
		public System.Int32 PitchTime
		{
			get {return _pitchTime;}
			set {_pitchTime = value;}
		}
		private System.Int32 _readTimes = 0;
		/// <summary>
		/// 重复收费查看次数 
		/// </summary>
		public System.Int32 ReadTimes
		{
			get {return _readTimes;}
			set {_readTimes = value;}
		}
		private System.Int32 _dividePercent = 0;
		/// <summary>
		/// 分成比例 
		/// </summary>
		public System.Int32 DividePercent
		{
			get {return _dividePercent;}
			set {_dividePercent = value;}
		}
		#endregion
	}
}
