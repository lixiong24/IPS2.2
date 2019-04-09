// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: StatWeburlEntity.cs
// 修改时间：2019/4/9 17:45:13
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：StatWeburl 的实体类.
	/// </summary>
	public partial class StatWeburlEntity
	{
		#region Properties
		private System.String _tWeburl = string.Empty;
		/// <summary>
		/// 用户来自何网址 (主键)
		/// </summary>
		public System.String TWeburl
		{
			get {return _tWeburl;}
			set {_tWeburl = value;}
		}
		private System.Int32 _tWebNum = 0;
		/// <summary>
		/// 数量 
		/// </summary>
		public System.Int32 TWebNum
		{
			get {return _tWebNum;}
			set {_tWebNum = value;}
		}
		#endregion
	}
}
