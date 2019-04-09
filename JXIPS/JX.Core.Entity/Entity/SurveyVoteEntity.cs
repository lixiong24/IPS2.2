// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: SurveyVoteEntity.cs
// 修改时间：2019/4/9 17:45:14
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：SurveyVote 的实体类.
	/// </summary>
	public partial class SurveyVoteEntity
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
		private System.Int32 _surveyID = 0;
		/// <summary>
		/// 问卷ID 
		/// </summary>
		public System.Int32 SurveyID
		{
			get {return _surveyID;}
			set {_surveyID = value;}
		}
		private System.Int32 _questionID = 0;
		/// <summary>
		/// 问题ID 
		/// </summary>
		public System.Int32 QuestionID
		{
			get {return _questionID;}
			set {_questionID = value;}
		}
		private System.Int32 _optionID = 0;
		/// <summary>
		/// 选项ID 
		/// </summary>
		public System.Int32 OptionID
		{
			get {return _optionID;}
			set {_optionID = value;}
		}
		private System.Int32 _voteAmount = 0;
		/// <summary>
		/// 投票数目 
		/// </summary>
		public System.Int32 VoteAmount
		{
			get {return _voteAmount;}
			set {_voteAmount = value;}
		}
		#endregion
	}
}
