// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: ProducerEntity.cs
// 修改时间：2019/4/9 17:45:11
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Producer 的实体类.
	/// </summary>
	public partial class ProducerEntity
	{
		#region Properties
		private System.Int32 _producerID = 0;
		/// <summary>
		/// 生产商ID (主键)
		/// </summary>
		public System.Int32 ProducerID
		{
			get {return _producerID;}
			set {_producerID = value;}
		}
		private System.Int32 _producerType = 0;
		/// <summary>
		/// 生产商分类 
		/// </summary>
		public System.Int32 ProducerType
		{
			get {return _producerType;}
			set {_producerType = value;}
		}
		private System.String _producerName = string.Empty;
		/// <summary>
		/// 生产商 
		/// </summary>
		public System.String ProducerName
		{
			get {return _producerName;}
			set {_producerName = value;}
		}
		private System.String _producerShortName = string.Empty;
		/// <summary>
		/// 生产商简称 
		/// </summary>
		public System.String ProducerShortName
		{
			get {return _producerShortName;}
			set {_producerShortName = value;}
		}
		private System.String _producerPhoto = string.Empty;
		/// <summary>
		/// 生产商图片 
		/// </summary>
		public System.String ProducerPhoto
		{
			get {return _producerPhoto;}
			set {_producerPhoto = value;}
		}
		private DateTime? _birthDay = DateTime.MaxValue;
		/// <summary>
		/// 创立日期 
		/// </summary>
		public DateTime? BirthDay
		{
			get {return _birthDay;}
			set {_birthDay = value;}
		}
		private System.String _address = string.Empty;
		/// <summary>
		/// 地址 
		/// </summary>
		public System.String Address
		{
			get {return _address;}
			set {_address = value;}
		}
		private System.String _postcode = string.Empty;
		/// <summary>
		/// 邮政编码 
		/// </summary>
		public System.String Postcode
		{
			get {return _postcode;}
			set {_postcode = value;}
		}
		private System.String _phone = string.Empty;
		/// <summary>
		/// 电话 
		/// </summary>
		public System.String Phone
		{
			get {return _phone;}
			set {_phone = value;}
		}
		private System.String _fax = string.Empty;
		/// <summary>
		/// 传真 
		/// </summary>
		public System.String Fax
		{
			get {return _fax;}
			set {_fax = value;}
		}
		private System.String _email = string.Empty;
		/// <summary>
		/// Email 
		/// </summary>
		public System.String Email
		{
			get {return _email;}
			set {_email = value;}
		}
		private System.String _homepage = string.Empty;
		/// <summary>
		/// 主页 
		/// </summary>
		public System.String Homepage
		{
			get {return _homepage;}
			set {_homepage = value;}
		}
		private System.String _producerIntro = string.Empty;
		/// <summary>
		/// 生产商简介 
		/// </summary>
		public System.String ProducerIntro
		{
			get {return _producerIntro;}
			set {_producerIntro = value;}
		}
		private DateTime? _lastUseTime = DateTime.MaxValue;
		/// <summary>
		/// 最后修改时间 
		/// </summary>
		public DateTime? LastUseTime
		{
			get {return _lastUseTime;}
			set {_lastUseTime = value;}
		}
		private System.Boolean _isPassed = false;
		/// <summary>
		/// 是否通过 
		/// </summary>
		public System.Boolean IsPassed
		{
			get {return _isPassed;}
			set {_isPassed = value;}
		}
		private System.Boolean _isTop = false;
		/// <summary>
		/// 是否固顶 
		/// </summary>
		public System.Boolean IsTop
		{
			get {return _isTop;}
			set {_isTop = value;}
		}
		private System.Boolean _isElite = false;
		/// <summary>
		/// 是否推荐 
		/// </summary>
		public System.Boolean IsElite
		{
			get {return _isElite;}
			set {_isElite = value;}
		}
		private System.Int32 _hits = 0;
		/// <summary>
		/// 点击数 
		/// </summary>
		public System.Int32 Hits
		{
			get {return _hits;}
			set {_hits = value;}
		}
		#endregion
	}
}
