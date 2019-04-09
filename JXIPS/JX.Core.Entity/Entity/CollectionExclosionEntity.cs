// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: CollectionExclosionEntity.cs
// 修改时间：2019/4/9 17:45:03
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：CollectionExclosion 的实体类.
	/// </summary>
	public partial class CollectionExclosionEntity
	{
		#region Properties
		private System.Int32 _exclosionID = 0;
		/// <summary>
		/// 排除ID (主键)
		/// </summary>
		public System.Int32 ExclosionID
		{
			get {return _exclosionID;}
			set {_exclosionID = value;}
		}
		private System.String _exclosionName = string.Empty;
		/// <summary>
		/// 排除名称 
		/// </summary>
		public System.String ExclosionName
		{
			get {return _exclosionName;}
			set {_exclosionName = value;}
		}
		private System.Int32 _exclosionType = 0;
		/// <summary>
		/// 排除类型 
		/// </summary>
		public System.Int32 ExclosionType
		{
			get {return _exclosionType;}
			set {_exclosionType = value;}
		}
		private System.Int32 _exclosionStringType = 0;
		/// <summary>
		/// 排除字符类别 
		/// </summary>
		public System.Int32 ExclosionStringType
		{
			get {return _exclosionStringType;}
			set {_exclosionStringType = value;}
		}
		private System.String _exclosionString = string.Empty;
		/// <summary>
		/// 排除字符 
		/// </summary>
		public System.String ExclosionString
		{
			get {return _exclosionString;}
			set {_exclosionString = value;}
		}
		private System.Boolean _isExclosionDesignatedNumber = false;
		/// <summary>
		/// 是否排除指定数字 
		/// </summary>
		public System.Boolean IsExclosionDesignatedNumber
		{
			get {return _isExclosionDesignatedNumber;}
			set {_isExclosionDesignatedNumber = value;}
		}
		private System.Int32 _exclosionDesignatedNumber = 0;
		/// <summary>
		/// 排除指定数字 
		/// </summary>
		public System.Int32 ExclosionDesignatedNumber
		{
			get {return _exclosionDesignatedNumber;}
			set {_exclosionDesignatedNumber = value;}
		}
		private System.Boolean _isExclosionMaxNumber = false;
		/// <summary>
		/// 是否排除大于数字 
		/// </summary>
		public System.Boolean IsExclosionMaxNumber
		{
			get {return _isExclosionMaxNumber;}
			set {_isExclosionMaxNumber = value;}
		}
		private System.Int32 _exclosionMaxNumber = 0;
		/// <summary>
		/// 排除大于数字 
		/// </summary>
		public System.Int32 ExclosionMaxNumber
		{
			get {return _exclosionMaxNumber;}
			set {_exclosionMaxNumber = value;}
		}
		private System.Boolean _isExclosionMinNumber = false;
		/// <summary>
		/// 是否排除小于数字 
		/// </summary>
		public System.Boolean IsExclosionMinNumber
		{
			get {return _isExclosionMinNumber;}
			set {_isExclosionMinNumber = value;}
		}
		private System.Int32 _exclosionMinNumber = 0;
		/// <summary>
		/// 排除小于数字 
		/// </summary>
		public System.Int32 ExclosionMinNumber
		{
			get {return _exclosionMinNumber;}
			set {_exclosionMinNumber = value;}
		}
		private System.Boolean _isExclosionDesignatedDateTime = false;
		/// <summary>
		/// 是否排除指定时间 
		/// </summary>
		public System.Boolean IsExclosionDesignatedDateTime
		{
			get {return _isExclosionDesignatedDateTime;}
			set {_isExclosionDesignatedDateTime = value;}
		}
		private DateTime? _exclosionDesignatedDateTime = DateTime.MaxValue;
		/// <summary>
		/// 排除指定时间 
		/// </summary>
		public DateTime? ExclosionDesignatedDateTime
		{
			get {return _exclosionDesignatedDateTime;}
			set {_exclosionDesignatedDateTime = value;}
		}
		private System.Boolean _isExclosionMaxDateTime = false;
		/// <summary>
		/// 是否排除大于时间 
		/// </summary>
		public System.Boolean IsExclosionMaxDateTime
		{
			get {return _isExclosionMaxDateTime;}
			set {_isExclosionMaxDateTime = value;}
		}
		private DateTime? _exclosionMaxDateTime = DateTime.MaxValue;
		/// <summary>
		/// 排除大于时间 
		/// </summary>
		public DateTime? ExclosionMaxDateTime
		{
			get {return _exclosionMaxDateTime;}
			set {_exclosionMaxDateTime = value;}
		}
		private System.Boolean _isExclosionMinDateTime = false;
		/// <summary>
		/// 是否排除小于时间 
		/// </summary>
		public System.Boolean IsExclosionMinDateTime
		{
			get {return _isExclosionMinDateTime;}
			set {_isExclosionMinDateTime = value;}
		}
		private DateTime? _exclosionMinDateTime = DateTime.MaxValue;
		/// <summary>
		/// 排除小于时间 
		/// </summary>
		public DateTime? ExclosionMinDateTime
		{
			get {return _exclosionMinDateTime;}
			set {_exclosionMinDateTime = value;}
		}
		#endregion
	}
}
