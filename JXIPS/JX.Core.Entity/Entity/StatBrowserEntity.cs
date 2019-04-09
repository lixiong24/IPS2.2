// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: StatBrowserEntity.cs
// 修改时间：2019/4/9 17:45:13
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：StatBrowser 的实体类.
	/// </summary>
	public partial class StatBrowserEntity
	{
		#region Properties
		private System.String _tBrowser = string.Empty;
		/// <summary>
		/// 浏览器 (主键)
		/// </summary>
		public System.String TBrowser
		{
			get {return _tBrowser;}
			set {_tBrowser = value;}
		}
		private System.Int32 _tBrwNum = 0;
		/// <summary>
		/// 数量 
		/// </summary>
		public System.Int32 TBrwNum
		{
			get {return _tBrwNum;}
			set {_tBrwNum = value;}
		}
		#endregion
	}
}
