// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: PresentProjectEntity.cs
// 修改时间：2019/4/9 17:45:11
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：PresentProject 的实体类.
	/// </summary>
	public partial class PresentProjectEntity
	{
		#region Properties
		private System.Int32 _projectID = 0;
		/// <summary>
		/// 促销方案ID (主键)(自增长)
		/// </summary>
		public System.Int32 ProjectID
		{
			get {return _projectID;}
			set {_projectID = value;}
		}
		private System.String _projectName = string.Empty;
		/// <summary>
		/// 方案名称 
		/// </summary>
		public System.String ProjectName
		{
			get {return _projectName;}
			set {_projectName = value;}
		}
		private DateTime? _beginDate = DateTime.MaxValue;
		/// <summary>
		/// 有效期开启 
		/// </summary>
		public DateTime? BeginDate
		{
			get {return _beginDate;}
			set {_beginDate = value;}
		}
		private DateTime? _endDate = DateTime.MaxValue;
		/// <summary>
		/// 有效期结束 
		/// </summary>
		public DateTime? EndDate
		{
			get {return _endDate;}
			set {_endDate = value;}
		}
		private System.Decimal _minMoney = 0;
		/// <summary>
		/// 价格区间最小数 
		/// </summary>
		public System.Decimal MinMoney
		{
			get {return _minMoney;}
			set {_minMoney = value;}
		}
		private System.Decimal _maxMoney = 0;
		/// <summary>
		/// 价格区间最大数 
		/// </summary>
		public System.Decimal MaxMoney
		{
			get {return _maxMoney;}
			set {_maxMoney = value;}
		}
		private System.String _presentContent = string.Empty;
		/// <summary>
		/// 可以超值换购商品 
		/// </summary>
		public System.String PresentContent
		{
			get {return _presentContent;}
			set {_presentContent = value;}
		}
		private System.Decimal _price = 0;
		/// <summary>
		/// 可以超值换购商品 
		/// </summary>
		public System.Decimal Price
		{
			get {return _price;}
			set {_price = value;}
		}
		private System.String _presentID = string.Empty;
		/// <summary>
		/// 促销品ID 
		/// </summary>
		public System.String PresentID
		{
			get {return _presentID;}
			set {_presentID = value;}
		}
		private System.Decimal _cash = 0;
		/// <summary>
		/// 返还的现金券 
		/// </summary>
		public System.Decimal Cash
		{
			get {return _cash;}
			set {_cash = value;}
		}
		private System.Int32 _presentExp = 0;
		/// <summary>
		/// 可以得到的积分 
		/// </summary>
		public System.Int32 PresentExp
		{
			get {return _presentExp;}
			set {_presentExp = value;}
		}
		private System.Int32 _presentPoint = 0;
		/// <summary>
		/// 赠送点券 
		/// </summary>
		public System.Int32 PresentPoint
		{
			get {return _presentPoint;}
			set {_presentPoint = value;}
		}
		private System.Boolean _isDisabled = false;
		/// <summary>
		/// 是否启用 
		/// </summary>
		public System.Boolean IsDisabled
		{
			get {return _isDisabled;}
			set {_isDisabled = value;}
		}
		#endregion
	}
}
