// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: U_AnswerEntity.cs
// 修改时间：2019/4/9 17:45:14
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：U_Answer 的实体类.
	/// </summary>
	public partial class U_AnswerEntity
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
		private System.String _answerContent = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String AnswerContent
		{
			get {return _answerContent;}
			set {_answerContent = value;}
		}
		private System.Boolean _isBestAnswer = false;
		/// <summary>
		///  
		/// </summary>
		public System.Boolean IsBestAnswer
		{
			get {return _isBestAnswer;}
			set {_isBestAnswer = value;}
		}
		private System.String _problemID = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String ProblemID
		{
			get {return _problemID;}
			set {_problemID = value;}
		}
		private DateTime? _answerTime = DateTime.MaxValue;
		/// <summary>
		///  
		/// </summary>
		public DateTime? AnswerTime
		{
			get {return _answerTime;}
			set {_answerTime = value;}
		}
		private System.String _aUser = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String AUser
		{
			get {return _aUser;}
			set {_aUser = value;}
		}
		#endregion
	}
}
