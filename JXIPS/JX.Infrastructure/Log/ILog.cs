using System;
using System.Collections.Generic;

namespace JX.Infrastructure.Log
{
	/// <summary>
	/// 日志接口，只定义了添加、修改、删除日志信息和得到日志信息列表。
	/// </summary>
	public interface ILog
    {
		/// <summary>
		/// 添加日志信息
		/// </summary>
		/// <param name="logInfo">日志信息类</param>
		void Add(LogInfo logInfo);
		/// <summary>
		/// 根据记录时间删除日志信息
		/// </summary>
		/// <param name="time">记录时间</param>
		/// <returns>true/false</returns>
		bool Delete(DateTime time);
		/// <summary>
		/// 根据日志ID删除日志信息，但保留最近两天之内的数据
		/// </summary>
		/// <param name="id">日志ID</param>
		/// <returns>TRUE/FALSE</returns>
		bool Delete(string id);
		/// <summary>
		/// 删除最后范围的日志信息，但保留最近两天之内的数据。如：最后一万条
		/// </summary>
		/// <param name="offset">删除数量</param>
		/// <returns>TRUE/FALSE</returns>
		bool DeleteLastRange(int offset);
		/// <summary>
		/// 得到日志列表，用于分页
		/// </summary>
		/// <param name="startRowIndexId">开始行索引</param>
		/// <param name="maxNumberRows">最大行数</param>
		/// <returns>日志列表对象</returns>
		IList<LogInfo> GetList(int startRowIndexId, int maxNumberRows);
		/// <summary>
		/// 得到日志列表，用于分页
		/// </summary>
		/// <param name="startRowIndexId">开始行索引</param>
		/// <param name="maxNumberRows">最大行数</param>
		/// <param name="category">日志类别</param>
		/// <returns>日志列表对象</returns>
		IList<LogInfo> GetList(int startRowIndexId, int maxNumberRows, LogCategory category);
		/// <summary>
		/// 得到日志列表，用于分页
		/// </summary>
		/// <param name="startRowIndexId">开始行索引</param>
		/// <param name="maxNumberRows">最大行数</param>
		/// <param name="searchType">搜索类型</param>
		/// <param name="keyword">关键字</param>
		/// <returns>日志列表对象</returns>
		IList<LogInfo> GetList(int startRowIndexId, int maxNumberRows, string searchType, string keyword);
		/// <summary>
		/// 通过日志ID得到日志信息对象
		/// </summary>
		/// <param name="id">日志ID</param>
		/// <returns>日志信息对象</returns>
		LogInfo GetLogById(int id);
		/// <summary>
		/// 得到用于分页查询时的总记录数
		/// </summary>
		/// <returns>合计数</returns>
		int GetTotalOfLog();
		/// <summary>
		/// 更新日志信息
		/// </summary>
		/// <param name="logInfo">日志信息对象</param>
		/// <returns>TRUE/FALSE</returns>
		bool Update(LogInfo logInfo);
    }
}
