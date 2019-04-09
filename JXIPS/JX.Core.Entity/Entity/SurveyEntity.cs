// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: SurveyEntity.cs
// 修改时间：2019/4/9 17:45:14
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：Survey 的实体类.
	/// </summary>
	public partial class SurveyEntity
	{
		#region Properties
		private System.Int32 _surveyID = 0;
		/// <summary>
		/// 调查问卷ID (主键)
		/// </summary>
		public System.Int32 SurveyID
		{
			get {return _surveyID;}
			set {_surveyID = value;}
		}
		private System.String _surveyName = string.Empty;
		/// <summary>
		/// 调查问卷名称 
		/// </summary>
		public System.String SurveyName
		{
			get {return _surveyName;}
			set {_surveyName = value;}
		}
		private System.String _description = string.Empty;
		/// <summary>
		/// 调查问卷描述 
		/// </summary>
		public System.String Description
		{
			get {return _description;}
			set {_description = value;}
		}
		private System.String _fileName = string.Empty;
		/// <summary>
		/// 文件名 
		/// </summary>
		public System.String FileName
		{
			get {return _fileName;}
			set {_fileName = value;}
		}
		private System.Int32 _iPRepeat = 0;
		/// <summary>
		/// 同一IP允许重复提交次数 
		/// </summary>
		public System.Int32 IPRepeat
		{
			get {return _iPRepeat;}
			set {_iPRepeat = value;}
		}
		private DateTime? _createDate = DateTime.MaxValue;
		/// <summary>
		/// 创建日期 
		/// </summary>
		public DateTime? CreateDate
		{
			get {return _createDate;}
			set {_createDate = value;}
		}
		private DateTime? _endTime = DateTime.MaxValue;
		/// <summary>
		/// 结束日期 
		/// </summary>
		public DateTime? EndTime
		{
			get {return _endTime;}
			set {_endTime = value;}
		}
		private System.Int32 _isOpen = 0;
		/// <summary>
		/// 1--启用，0---没起用 
		/// </summary>
		public System.Int32 IsOpen
		{
			get {return _isOpen;}
			set {_isOpen = value;}
		}
		private System.Int32 _needLogin = 0;
		/// <summary>
		/// 登录后才能投票 (1--需要，0---不需要) 
		/// </summary>
		public System.Int32 NeedLogin
		{
			get {return _needLogin;}
			set {_needLogin = value;}
		}
		private System.Int32 _presentPoint = 0;
		/// <summary>
		/// 注册会员参与者奖励点数 
		/// </summary>
		public System.Int32 PresentPoint
		{
			get {return _presentPoint;}
			set {_presentPoint = value;}
		}
		private System.Int32 _lockIPType = 0;
		/// <summary>
		/// 限定IP段类型 
		/// </summary>
		public System.Int32 LockIPType
		{
			get {return _lockIPType;}
			set {_lockIPType = value;}
		}
		private System.String _setIPLock = string.Empty;
		/// <summary>
		/// 设置IP限制,为空时，表示不启用 
		/// </summary>
		public System.String SetIPLock
		{
			get {return _setIPLock;}
			set {_setIPLock = value;}
		}
		private System.String _lockUrl = string.Empty;
		/// <summary>
		/// 限定地址 
		/// </summary>
		public System.String LockUrl
		{
			get {return _lockUrl;}
			set {_lockUrl = value;}
		}
		private System.String _setPassword = string.Empty;
		/// <summary>
		/// 设置密码限制，为空时，表示不启用 
		/// </summary>
		public System.String SetPassword
		{
			get {return _setPassword;}
			set {_setPassword = value;}
		}
		private System.String _template = string.Empty;
		/// <summary>
		/// 问卷模板 
		/// </summary>
		public System.String Template
		{
			get {return _template;}
			set {_template = value;}
		}
		private System.String _questionField = string.Empty;
		/// <summary>
		/// 题目字段 
		/// </summary>
		public System.String QuestionField
		{
			get {return _questionField;}
			set {_questionField = value;}
		}
		private System.Int32 _questionMaxID = 0;
		/// <summary>
		/// 题目最大ID 
		/// </summary>
		public System.Int32 QuestionMaxID
		{
			get {return _questionMaxID;}
			set {_questionMaxID = value;}
		}
		#endregion
	}
}
