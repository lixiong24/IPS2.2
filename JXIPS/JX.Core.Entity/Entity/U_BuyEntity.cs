// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: U_BuyEntity.cs
// 修改时间：2019/4/9 17:45:14
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：U_Buy 的实体类.
	/// </summary>
	public partial class U_BuyEntity
	{
		#region Properties
		private System.Int32 _id = 0;
		/// <summary>
		///  (主键)
		/// </summary>
		public System.Int32 ID
		{
			get {return _id;}
			set {_id = value;}
		}
		private System.String _buyAmount = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String BuyAmount
		{
			get {return _buyAmount;}
			set {_buyAmount = value;}
		}
		private System.String _oENumber = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String OENumber
		{
			get {return _oENumber;}
			set {_oENumber = value;}
		}
		private System.String _consultNumber = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String ConsultNumber
		{
			get {return _consultNumber;}
			set {_consultNumber = value;}
		}
		private System.String _applyType = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String ApplyType
		{
			get {return _applyType;}
			set {_applyType = value;}
		}
		private System.String _agoraType = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String AgoraType
		{
			get {return _agoraType;}
			set {_agoraType = value;}
		}
		private System.String _periodOfValidity = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String PeriodOfValidity
		{
			get {return _periodOfValidity;}
			set {_periodOfValidity = value;}
		}
		private System.String _content = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String Content
		{
			get {return _content;}
			set {_content = value;}
		}
		private System.String _intro = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String Intro
		{
			get {return _intro;}
			set {_intro = value;}
		}
		private System.String _pCategory = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String PCategory
		{
			get {return _pCategory;}
			set {_pCategory = value;}
		}
		#endregion
	}
}
