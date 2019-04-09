// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: U_QuestionEntity.cs
// 修改时间：2019/4/9 17:45:15
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：U_Question 的实体类.
	/// </summary>
	public partial class U_QuestionEntity
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
		private System.String _problemState = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String ProblemState
		{
			get {return _problemState;}
			set {_problemState = value;}
		}
		private DateTime? _solveProblemTime = DateTime.MaxValue;
		/// <summary>
		///  
		/// </summary>
		public DateTime? SolveProblemTime
		{
			get {return _solveProblemTime;}
			set {_solveProblemTime = value;}
		}
		private System.String _problemDesc = string.Empty;
		/// <summary>
		///  
		/// </summary>
		public System.String ProblemDesc
		{
			get {return _problemDesc;}
			set {_problemDesc = value;}
		}
		#endregion
	}
}
