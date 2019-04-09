// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: StatInfoListEntity.cs
// 修改时间：2019/4/9 17:45:13
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：StatInfoList 的实体类.
	/// </summary>
	public partial class StatInfoListEntity
	{
		#region Properties
		private System.Int32 _id = 0;
		/// <summary>
		/// (null) (主键)(自增长)
		/// </summary>
		public System.Int32 ID
		{
			get {return _id;}
			set {_id = value;}
		}
		private System.String _startDate = string.Empty;
		/// <summary>
		/// 开始统计日期 
		/// </summary>
		public System.String StartDate
		{
			get {return _startDate;}
			set {_startDate = value;}
		}
		private System.Int32 _totalNum = 0;
		/// <summary>
		/// 总访问量 
		/// </summary>
		public System.Int32 TotalNum
		{
			get {return _totalNum;}
			set {_totalNum = value;}
		}
		private System.Int32 _totalView = 0;
		/// <summary>
		/// 总浏览量 
		/// </summary>
		public System.Int32 TotalView
		{
			get {return _totalView;}
			set {_totalView = value;}
		}
		private System.Int32 _monthNum = 0;
		/// <summary>
		/// 月访量 
		/// </summary>
		public System.Int32 MonthNum
		{
			get {return _monthNum;}
			set {_monthNum = value;}
		}
		private System.Int32 _monthMaxNum = 0;
		/// <summary>
		/// 最高月访量 
		/// </summary>
		public System.Int32 MonthMaxNum
		{
			get {return _monthMaxNum;}
			set {_monthMaxNum = value;}
		}
		private System.String _oldMonth = string.Empty;
		/// <summary>
		/// 使用系统前的月访量 
		/// </summary>
		public System.String OldMonth
		{
			get {return _oldMonth;}
			set {_oldMonth = value;}
		}
		private System.String _monthMaxDate = string.Empty;
		/// <summary>
		/// 最高月访量月份 
		/// </summary>
		public System.String MonthMaxDate
		{
			get {return _monthMaxDate;}
			set {_monthMaxDate = value;}
		}
		private System.Int32 _dayNum = 0;
		/// <summary>
		/// 今日访问量 
		/// </summary>
		public System.Int32 DayNum
		{
			get {return _dayNum;}
			set {_dayNum = value;}
		}
		private System.Int32 _dayMaxNum = 0;
		/// <summary>
		/// 最高日访量 
		/// </summary>
		public System.Int32 DayMaxNum
		{
			get {return _dayMaxNum;}
			set {_dayMaxNum = value;}
		}
		private System.String _oldDay = string.Empty;
		/// <summary>
		/// 使用系统前的日访量 
		/// </summary>
		public System.String OldDay
		{
			get {return _oldDay;}
			set {_oldDay = value;}
		}
		private System.String _dayMaxDate = string.Empty;
		/// <summary>
		/// 最高日访量日期 
		/// </summary>
		public System.String DayMaxDate
		{
			get {return _dayMaxDate;}
			set {_dayMaxDate = value;}
		}
		private System.Int32 _hourNum = 0;
		/// <summary>
		/// 时访量 
		/// </summary>
		public System.Int32 HourNum
		{
			get {return _hourNum;}
			set {_hourNum = value;}
		}
		private System.Int32 _hourMaxNum = 0;
		/// <summary>
		/// 最高时访量 
		/// </summary>
		public System.Int32 HourMaxNum
		{
			get {return _hourMaxNum;}
			set {_hourMaxNum = value;}
		}
		private System.String _oldHour = string.Empty;
		/// <summary>
		/// 使用系统前的时访问量 
		/// </summary>
		public System.String OldHour
		{
			get {return _oldHour;}
			set {_oldHour = value;}
		}
		private System.String _hourMaxTime = string.Empty;
		/// <summary>
		/// 最高时访量时间 
		/// </summary>
		public System.String HourMaxTime
		{
			get {return _hourMaxTime;}
			set {_hourMaxTime = value;}
		}
		private System.Int32 _chinaNum = 0;
		/// <summary>
		/// 国内访问人数 
		/// </summary>
		public System.Int32 ChinaNum
		{
			get {return _chinaNum;}
			set {_chinaNum = value;}
		}
		private System.Int32 _otherNum = 0;
		/// <summary>
		/// 国外访问人数 
		/// </summary>
		public System.Int32 OtherNum
		{
			get {return _otherNum;}
			set {_otherNum = value;}
		}
		private System.Int32 _masterTimeZone = 0;
		/// <summary>
		/// 服务器所在时区 
		/// </summary>
		public System.Int32 MasterTimeZone
		{
			get {return _masterTimeZone;}
			set {_masterTimeZone = value;}
		}
		private System.Int32 _interval = 0;
		/// <summary>
		/// 自动标记在线间隔 
		/// </summary>
		public System.Int32 Interval
		{
			get {return _interval;}
			set {_interval = value;}
		}
		private System.Int32 _intervalNum = 0;
		/// <summary>
		/// 自动标记在线间隔循环次数 
		/// </summary>
		public System.Int32 IntervalNum
		{
			get {return _intervalNum;}
			set {_intervalNum = value;}
		}
		private System.Int32 _onlineTime = 0;
		/// <summary>
		/// 在线用户的保留时间 
		/// </summary>
		public System.Int32 OnlineTime
		{
			get {return _onlineTime;}
			set {_onlineTime = value;}
		}
		private System.Int32 _visitRecord = 0;
		/// <summary>
		/// 保留访问记录数 
		/// </summary>
		public System.Int32 VisitRecord
		{
			get {return _visitRecord;}
			set {_visitRecord = value;}
		}
		private System.Int32 _killRefresh = 0;
		/// <summary>
		/// 保留访问IP数(大于20小于800的数字) 
		/// </summary>
		public System.Int32 KillRefresh
		{
			get {return _killRefresh;}
			set {_killRefresh = value;}
		}
		private System.String _regFields_Fill = string.Empty;
		/// <summary>
		/// 启用的要进行统计的功能项目 
		/// </summary>
		public System.String RegFields_Fill
		{
			get {return _regFields_Fill;}
			set {_regFields_Fill = value;}
		}
		private System.Int32 _oldTotalNum = 0;
		/// <summary>
		/// 使用本系统前的访问量 
		/// </summary>
		public System.Int32 OldTotalNum
		{
			get {return _oldTotalNum;}
			set {_oldTotalNum = value;}
		}
		private System.Int32 _oldTotalView = 0;
		/// <summary>
		/// 使用本系统前的浏览量 
		/// </summary>
		public System.Int32 OldTotalView
		{
			get {return _oldTotalView;}
			set {_oldTotalView = value;}
		}
		#endregion
	}
}
