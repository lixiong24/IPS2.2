using System;
using System.Collections.Generic;
using System.Text;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 分页数据模型
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class PagerModel<T> where T : class
	{
		/// <summary>
		/// 第几页（索引从0开始）
		/// </summary>
		public Int32 PageNum { get; set; }
		/// <summary>
		/// 每页大小
		/// </summary>
		public Int32 PageSize { get; set; }
		/// <summary>
		/// 总记录数
		/// </summary>
		public Int32 RecordTotal { get; set; }
		/// <summary>
		/// 总页数
		/// </summary>
		public Int32 PageCount
		{
			get
			{
				if(RecordTotal <= 0)
				{
					return 0;
				}
				int pageCount = RecordTotal / PageSize;
				if ((RecordTotal % PageSize) > 0)
				{
					pageCount += 1;
				}
				return pageCount;
			}
		}
		/// <summary>
		/// 返回的所有数据
		/// </summary>
		public IList<T> RowList { get; set; }

		/// <summary>
		/// 默认初始化
		/// </summary>
		public PagerModel(int pageNum=0,int pageSize=10,int recordTotal=0, IList<T> rowList=null)
		{
			PageNum = pageNum;
			PageSize = pageSize;
			RecordTotal = recordTotal;
			RowList = rowList;
			if (rowList == null)
			{
				RowList = new List<T>();
			}
		}

	}
}
