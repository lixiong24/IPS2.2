using System.Collections.Generic;

namespace JX.Infrastructure.Field
{
	/// <summary>
	/// 字段信息比较器:用于泛型集合排序
	/// </summary>
	public class FieldInfoComparer : IComparer<FieldInfo>
	{
		/// <summary>
		/// 比较两个字段信息大小：OrderId的大小
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int Compare(FieldInfo x, FieldInfo y)
		{
			return x.OrderId.CompareTo(y.OrderId);
		}
	}
}
