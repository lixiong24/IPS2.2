using System;
using System.Collections.Generic;
using System.Text;

namespace JX.Infrastructure
{
	/// <summary>
	/// 返回结果状态类
	/// </summary>
	public class ResultInfo
	{
		/// <summary>
		/// 状态：0：失败；1：成功；
		/// </summary>
		public int Status { set; get; } = 0;
		/// <summary>
		/// 消息
		/// </summary>
		public string Msg { set; get; } = "";
		/// <summary>
		/// 结果数据
		/// </summary>
		public string Data { set; get; } = "";
	}
}
