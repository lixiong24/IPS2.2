// =================================================================== 
// 项目说明,功能实体类,用CodeSmith自动生成。
// =================================================================== 
// 文件名: CorrelativeInfoEntity.cs
// 修改时间：2019/4/9 17:45:07
// 修改人: lixiong
// =================================================================== 
using System;

namespace JX.Core.Entity
{
	/// <summary>
	/// 数据库表：CorrelativeInfo 的实体类.
	/// </summary>
	public partial class CorrelativeInfoEntity
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
		private System.Int32 _generalId = 0;
		/// <summary>
		/// 要关联的内容ID 
		/// </summary>
		public System.Int32 GeneralId
		{
			get {return _generalId;}
			set {_generalId = value;}
		}
		private System.Int32 _correlativeGeneralId = 0;
		/// <summary>
		/// 关联对象的编号 
		/// </summary>
		public System.Int32 CorrelativeGeneralId
		{
			get {return _correlativeGeneralId;}
			set {_correlativeGeneralId = value;}
		}
		private System.Int32 _modelId = 0;
		/// <summary>
		/// 模型ID 
		/// </summary>
		public System.Int32 ModelId
		{
			get {return _modelId;}
			set {_modelId = value;}
		}
		private System.Int32 _orderSort = 0;
		/// <summary>
		/// 排序 
		/// </summary>
		public System.Int32 OrderSort
		{
			get {return _orderSort;}
			set {_orderSort = value;}
		}
		#endregion
	}
}
