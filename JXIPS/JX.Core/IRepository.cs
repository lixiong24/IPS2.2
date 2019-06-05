using JX.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JX.Core
{
	/// <summary>
	/// 仓储接口
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IRepository<T> where T : class, new()
	{
		#region 获取特定字段的值、最大值、最小值、平均值、求和、总数
		/// <summary>
		/// 直接获取特定一个或者多个字段的值,多个字段需要声明Model。
		/// 例：var s = testDal.GetScalar《string,int》(m=>m.Name,m=>m.Code==1);
		/// var s = testDal.GetScalar《StoreM,int》(m=>new StoreM { Name1= m.Name, Code=m.Code },m=>m.Code==2);
		/// var s = testDal.GetScalar《dynamic,int》(m=>new { m.Name,m.Code },m=>m.Code==3);
		/// </summary>
		/// <typeparam name="TResult">数据结果</typeparam>
		/// <typeparam name="TOrderBy">排序字段</typeparam>
		/// <param name="scalar">要返回的结果，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <param name="orderby">排序字段</param>
		/// <param name="IsAsc">排序方向，true为正序false为倒序</param>
		/// <returns></returns>
		TResult GetScalar<TResult, TOrderBy>(Expression<Func<T, TResult>> scalar, Expression<Func<T, bool>> predicate = null, Expression<Func<T, TOrderBy>> orderby = null, bool IsAsc = true);
		/// <summary>
		/// 直接获取特定一个或者多个字段的值,多个字段需要声明Model。
		/// 例：var s = testDal.GetScalar《string,int》(m=>m.Name,m=>m.Code==1);
		/// var s = testDal.GetScalar《StoreM,int》(m=>new StoreM { Name1= m.Name, Code=m.Code },m=>m.Code==2);
		/// var s = testDal.GetScalar《dynamic,int》(m=>new { m.Name,m.Code },m=>m.Code==3);
		/// </summary>
		/// <typeparam name="TResult">数据结果</typeparam>
		/// <typeparam name="TOrderBy">排序字段</typeparam>
		/// <param name="scalar">要返回的结果，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <param name="orderby">排序字段</param>
		/// <param name="IsAsc">排序方向，true为正序false为倒序</param>
		/// <returns></returns>
		Task<TResult> GetScalarAsync<TResult, TOrderBy>(Expression<Func<T, TResult>> scalar, Expression<Func<T, bool>> predicate = null, Expression<Func<T, TOrderBy>> orderby = null, bool IsAsc = true);

		/// <summary>
		/// 得到最大值
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="max">最大值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		TResult GetMax<TResult>(Expression<Func<T, TResult>> max, Expression<Func<T, bool>> predicate = null);
		/// <summary>
		/// 得到最大值
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="max">最大值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		Task<TResult> GetMaxAsync<TResult>(Expression<Func<T, TResult>> max, Expression<Func<T, bool>> predicate = null);
		
		/// <summary>
		/// 得到最小值
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="min">最小值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		TResult GetMin<TResult>(Expression<Func<T, TResult>> min, Expression<Func<T, bool>> predicate = null);
		/// <summary>
		/// 得到最小值
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="min">最小值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		Task<TResult> GetMinAsync<TResult>(Expression<Func<T, TResult>> min, Expression<Func<T, bool>> predicate = null);
		
		/// <summary>
		/// 得到平均值
		/// </summary>
		/// <param name="avg">平均值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		decimal GetAvg(Expression<Func<T, decimal>> avg, Expression<Func<T, bool>> predicate = null);
		/// <summary>
		/// 得到平均值
		/// </summary>
		/// <param name="avg">平均值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		Task<decimal> GetAvgAsync(Expression<Func<T, decimal>> avg, Expression<Func<T, bool>> predicate = null);
		
		/// <summary>
		/// 得到求和值
		/// </summary>
		/// <param name="sum">求和值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		decimal GetSum(Expression<Func<T, decimal>> sum, Expression<Func<T, bool>> predicate = null);
		/// <summary>
		/// 得到求和值
		/// </summary>
		/// <param name="sum">求和值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		Task<decimal> GetSumAsync(Expression<Func<T, decimal>> sum, Expression<Func<T, bool>> predicate = null);
		
		/// <summary>
		/// 得到总数值
		/// </summary>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		int GetCount(Expression<Func<T, bool>> predicate = null);
		/// <summary>
		/// 得到总数值
		/// </summary>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		Task<int> GetCountAsync(Expression<Func<T, bool>> predicate = null);
		#endregion

		#region 验证是否存在

		/// <summary>
		/// 验证当前条件是否存在相同项
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		bool IsExist(Expression<Func<T, bool>> predicate);
		/// <summary>
		/// 验证当前条件是否存在相同项（异步方式）
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate);
		#endregion

		#region 添加
		/// <summary>
		/// 增加一条记录
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		bool Add(T entity, bool IsCommit = true);
		/// <summary>
		/// 增加一条记录（异步方式）
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		Task<bool> AddAsync(T entity, bool IsCommit = true);

		/// <summary>
		/// 增加多条记录，同一模型
		/// </summary>
		/// <param name="entityList">实体模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		bool AddList(IList<T> entityList, bool IsCommit = true);
		/// <summary>
		/// 增加多条记录，同一模型（异步方式）
		/// </summary>
		/// <param name="entityList">实体模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		Task<bool> AddListAsync(IList<T> entityList, bool IsCommit = true);

		/// <summary>
		/// 增加多条记录，独立模型
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="entityList"></param>
		/// <param name="IsCommit"></param>
		/// <returns></returns>
		bool AddList<TEntity>(IList<TEntity> entityList, bool IsCommit = true) where TEntity : class;
		/// <summary>
		/// 增加多条记录，独立模型（异步方式）
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="entityList"></param>
		/// <param name="IsCommit"></param>
		/// <returns></returns>
		Task<bool> AddListAsync<TEntity>(IList<TEntity> entityList, bool IsCommit = true) where TEntity : class;

		/// <summary>
		/// 增加或更新一条记录
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsSave">是否增加</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		bool AddOrUpdate(T entity, bool IsSave, bool IsCommit = true);
		/// <summary>
		/// 增加或更新一条记录（异步方式）
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsSave">是否增加</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		Task<bool> AddOrUpdateAsync(T entity, bool IsSave, bool IsCommit = true);
		#endregion

		#region 删除
		/// <summary>
		/// 删除一条记录
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		bool Delete(T entity, bool IsCommit = true);
		/// <summary>
		/// 删除一条记录（异步方式）
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		Task<bool> DeleteAsync(T entity, bool IsCommit = true);

		/// <summary>
		/// 删除多条记录，同一模型
		/// </summary>
		/// <param name="entityList">实体模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		bool DeleteList(IList<T> entityList, bool IsCommit = true);
		/// <summary>
		/// 删除多条记录，同一模型（异步方式）
		/// </summary>
		/// <param name="entityList">实体模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		Task<bool> DeleteListAsync(IList<T> entityList, bool IsCommit = true);

		/// <summary>
		/// 删除多条记录，独立模型
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="entityList"></param>
		/// <param name="IsCommit"></param>
		/// <returns></returns>
		bool DeleteList<TEntity>(IList<TEntity> entityList, bool IsCommit = true) where TEntity : class;
		/// <summary>
		/// 删除多条记录，独立模型（异步方式）
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="entityList"></param>
		/// <param name="IsCommit"></param>
		/// <returns></returns>
		Task<bool> DeleteListAsync<TEntity>(IList<TEntity> entityList, bool IsCommit = true) where TEntity : class;

		/// <summary>
		/// 通过Lamda表达式，删除一条或多条记录
		/// </summary>
		/// <param name="predicate">Lamda表达式（p=>p.Id==Id）</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		bool Delete(Expression<Func<T, bool>> predicate, bool IsCommit = true);
		/// <summary>
		/// 通过Lamda表达式，删除一条或多条记录（异步方式）
		/// </summary>
		/// <param name="predicate">Lamda表达式（p=>p.Id==Id）</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate, bool IsCommit = true);

		/// <summary>
		/// 删除一条或多条记录
		/// </summary>
		/// <param name="strWhere">参数化删除条件，为空代表全部删除(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		bool Delete(string strWhere, Dictionary<string, object> dict = null);
		/// <summary>
		/// 删除一条或多条记录（异步方式）
		/// </summary>
		/// <param name="strWhere">参数化删除条件，为空代表全部删除(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		Task<bool> DeleteAsync(string strWhere, Dictionary<string, object> dict = null);

		/// <summary>
		/// 根据SQL删除一条或多条记录
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		bool Delete(string sql, params IDataParameter[] para);
		/// <summary>
		/// 根据SQL删除一条或多条记录（异步方式）
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		Task<bool> DeleteAsync(string sql, params IDataParameter[] para);
		#endregion

		#region 修改
		/// <summary>
		/// 更新一条记录
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		bool Update(T entity, bool IsCommit = true);
		/// <summary>
		/// 更新一条记录（异步方式）
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		Task<bool> UpdateAsync(T entity, bool IsCommit = true);

		/// <summary>
		/// 更新多条记录，同一模型
		/// </summary>
		/// <param name="entityList">实体模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		bool UpdateList(IList<T> entityList, bool IsCommit = true);
		/// <summary>
		/// 更新多条记录，同一模型（异步方式）
		/// </summary>
		/// <param name="entityList">实体模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		Task<bool> UpdateListAsync(IList<T> entityList, bool IsCommit = true);

		/// <summary>
		/// 更新多条记录，独立模型
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="entityList"></param>
		/// <param name="IsCommit"></param>
		/// <returns></returns>
		bool UpdateList<TEntity>(IList<TEntity> entityList, bool IsCommit = true) where TEntity : class;
		/// <summary>
		/// 更新多条记录，独立模型（异步方式）
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="entityList"></param>
		/// <param name="IsCommit"></param>
		/// <returns></returns>
		Task<bool> UpdateListAsync<TEntity>(IList<TEntity> entityList, bool IsCommit = true) where TEntity : class;

		/// <summary>
		/// 根据SQL修改一条或多条记录
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		bool Update(string sql, params IDataParameter[] para);
		/// <summary>
		/// 根据SQL修改一条或多条记录（异步方式）
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		Task<bool> UpdateAsync(string sql, params IDataParameter[] para);
		#endregion

		#region 得到实体
		/// <summary>
		/// 通过Lamda表达式获取实体
		/// </summary>
		/// <param name="predicate">Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		T Get(Expression<Func<T, bool>> predicate);
		/// <summary>
		/// 通过Lamda表达式获取实体（异步方式）
		/// </summary>
		/// <param name="predicate">Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		Task<T> GetAsync(Expression<Func<T, bool>> predicate);
		#endregion

		#region 得到实体列表

		/// <summary>
		/// 返回IQueryable集合，延时加载数据
		/// </summary>
		/// <param name="predicate">Lamda表达式（p=>p.Id==Id）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		IQueryable<T> LoadAll(Expression<Func<T, bool>> predicate, params SortModelField[] orderByExpression);
		/// <summary>
		/// 返回IQueryable集合，延时加载数据（异步方式）
		/// </summary>
		/// <param name="predicate">Lamda表达式（p=>p.Id==Id）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		Task<IQueryable<T>> LoadAllAsync(Expression<Func<T, bool>> predicate, params SortModelField[] orderByExpression);

		/// <summary>
		/// 返回集合,不采用延时加载
		/// </summary>
		/// <param name="predicate">Lamda表达式（p=>p.Id==Id）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		List<T> LoadListAll(Expression<Func<T, bool>> predicate, params SortModelField[] orderByExpression);
		/// <summary>
		/// 返回集合,不采用延时加载（异步方式）
		/// </summary>
		/// <param name="predicate">Lamda表达式（p=>p.Id==Id）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		Task<List<T>> LoadListAllAsync(Expression<Func<T, bool>> predicate, params SortModelField[] orderByExpression);

		/// <summary>
		/// T-Sql方式：返回IQueryable集合
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="para">Parameters参数</param>
		/// <returns></returns>
		IQueryable<T> LoadAllBySql(string sql, params IDataParameter[] para);
		/// <summary>
		/// T-Sql方式：返回IQueryable集合（异步方式）
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="para">Parameters参数</param>
		/// <returns></returns>
		Task<IQueryable<T>> LoadAllBySqlAsync(string sql, params IDataParameter[] para);

		/// <summary>
		/// T-Sql方式：返回List集合
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="para">Parameters参数</param>
		/// <returns></returns>
		List<T> LoadListAllBySql(string sql, params IDataParameter[] para);
		/// <summary>
		/// T-Sql方式：返回List集合（异步方式）
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="para">Parameters参数</param>
		/// <returns></returns>
		Task<List<T>> LoadListAllBySqlAsync(string sql, params IDataParameter[] para);
		#endregion

		#region 得到数据列表
		/// <summary>
		/// 可指定返回结果、排序、查询条件的通用查询方法，返回实体对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <typeparam name="TOrderBy">排序字段类型</typeparam>
		/// <typeparam name="TResult">数据结果，与TEntity一致</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="orderby">排序字段</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="IsAsc">排序方向，true为正序false为倒序</param>
		/// <returns>实体集合</returns>
		List<TResult> QueryEntity<TEntity, TOrderBy, TResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Expression<Func<TEntity, TResult>> selector, bool IsAsc= true)
			where TEntity : class
			where TResult : class;
		/// <summary>
		/// 可指定返回结果、排序、查询条件的通用查询方法，返回实体对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <typeparam name="TResult">数据结果，与TEntity一致</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		List<TResult> QueryEntity<TEntity, TResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TResult>> selector, params SortModelField[] orderByExpression)
			where TEntity : class
			where TResult : class;
		/// <summary>
		/// 可指定返回结果、排序、查询条件的通用查询方法，返回实体对象集合（异步方式）
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <typeparam name="TOrderBy">排序字段类型</typeparam>
		/// <typeparam name="TResult">数据结果，与TEntity一致</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="orderby">排序字段</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="IsAsc">排序方向，true为正序false为倒序</param>
		/// <returns>实体集合</returns>
		Task<List<TResult>> QueryEntityAsync<TEntity, TOrderBy, TResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Expression<Func<TEntity, TResult>> selector, bool IsAsc= true)
			where TEntity : class
			where TResult : class;
		/// <summary>
		/// 可指定返回结果、排序、查询条件的通用查询方法，返回实体对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <typeparam name="TResult">数据结果，与TEntity一致</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		Task<List<TResult>> QueryEntityAsync<TEntity, TResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TResult>> selector, params SortModelField[] orderByExpression)
			where TEntity : class
			where TResult : class;

		/// <summary>
		/// 可指定返回结果、排序、查询条件的通用查询方法，返回Object对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <typeparam name="TOrderBy">排序字段类型</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="orderby">排序字段</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="IsAsc">排序方向，true为正序false为倒序</param>
		/// <returns>自定义实体集合</returns>
		List<object> QueryObject<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Func<IQueryable<TEntity>, List<object>> selector, bool IsAsc = true)
			where TEntity : class;
		/// <summary>
		/// 可指定返回结果、排序、查询条件的通用查询方法，返回Object对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		List<object> QueryObject<TEntity>(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, List<object>> selector, params SortModelField[] orderByExpression)
			where TEntity : class;
		/// <summary>
		/// 可指定返回结果、排序、查询条件的通用查询方法，返回Object对象集合（异步方式）
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <typeparam name="TOrderBy">排序字段类型</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="orderby">排序字段</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="IsAsc">排序方向，true为正序false为倒序</param>
		/// <returns>自定义实体集合</returns>
		Task<List<object>> QueryObjectAsync<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Func<IQueryable<TEntity>, List<object>> selector, bool IsAsc = true)
			where TEntity : class;
		/// <summary>
		/// 可指定返回结果、排序、查询条件的通用查询方法，返回Object对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		Task<List<object>> QueryObjectAsync<TEntity>(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, List<object>> selector, params SortModelField[] orderByExpression)
			where TEntity : class;

		/// <summary>
		/// 可指定返回结果、排序、查询条件的通用查询方法，返回dynamic对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <typeparam name="TOrderBy">排序字段类型</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="orderby">排序字段</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="IsAsc">排序方向，true为正序false为倒序</param>
		/// <returns></returns>
		List<dynamic> QueryDynamic<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Expression<Func<TEntity, dynamic>> selector, bool IsAsc = true) 
			where TEntity : class;
		/// <summary>
		/// 可指定返回结果、排序、查询条件的通用查询方法，返回dynamic对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		List<dynamic> QueryDynamic<TEntity>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, dynamic>> selector, params SortModelField[] orderByExpression)
			where TEntity : class;
		/// <summary>
		/// 可指定返回结果、排序、查询条件的通用查询方法，返回dynamic对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <typeparam name="TOrderBy">排序字段类型</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="orderby">排序字段</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="IsAsc">排序方向，true为正序false为倒序</param>
		/// <returns></returns>
		Task<List<dynamic>> QueryDynamicAsync<TEntity, TOrderBy>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderBy>> orderby, Expression<Func<TEntity, dynamic>> selector, bool IsAsc = true)
			where TEntity : class;
		/// <summary>
		/// 可指定返回结果、排序、查询条件的通用查询方法，返回dynamic对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		Task<List<dynamic>> QueryDynamicAsync<TEntity>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, dynamic>> selector, params SortModelField[] orderByExpression)
			where TEntity : class;
		#endregion

		#region 分页
		/// <summary>
		/// 分页查询，可指定返回结果、排序、查询条件的通用分页查询方法，返回实体对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <typeparam name="TOrderBy">排序字段类型</typeparam>
		/// <typeparam name="TResult">数据结果，与TEntity一致</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="orderby">排序字段</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="IsAsc">排序方向，true为正序false为倒序</param>
		/// <param name="pageIndex">分页索引，从1开始</param>
		/// <param name="pageSize">每页数量</param>
		/// <param name="Total">查询总数</param>
		/// <returns></returns>
		IList<TResult> QueryEntity<TEntity, TOrderBy, TResult>
			(Expression<Func<TEntity, bool>> where, 
			Expression<Func<TEntity, TOrderBy>> orderby, 
			Expression<Func<TEntity, TResult>> selector, 
			bool IsAsc, int pageIndex, int pageSize, out int Total)
			where TEntity : class
			where TResult : class;
		/// <summary>
		/// 分页查询，可指定返回结果、排序、查询条件的通用分页查询方法，返回实体对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <typeparam name="TResult">数据结果，与TEntity一致</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="pageIndex">分页索引，从1开始</param>
		/// <param name="pageSize">每页数量</param>
		/// <param name="Total">查询总数</param>
		/// <returns></returns>
		IList<TResult> QueryEntity<TEntity, TResult>
			(Expression<Func<TEntity, bool>> where,
			SortModelField[] orderByExpression,
			Expression<Func<TEntity, TResult>> selector,
			int pageIndex, int pageSize, out int Total)
			where TEntity : class
			where TResult : class;

		/// <summary>
		/// 分页查询，可指定返回结果、排序、查询条件的通用分页查询方法，返回dynamic对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <typeparam name="TOrderBy">排序字段类型</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="orderby">排序字段</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="IsAsc">排序方向，true为正序false为倒序</param>
		/// <param name="pageIndex">分页索引，从1开始</param>
		/// <param name="pageSize">每页数量</param>
		/// <param name="Total">查询总数</param>
		/// <returns></returns>
		IList<dynamic> QueryDynamic<TEntity, TOrderBy>
			(Expression<Func<TEntity, bool>> where,
			Expression<Func<TEntity, TOrderBy>> orderby,
			Expression<Func<TEntity, dynamic>> selector,
			bool IsAsc, int pageIndex, int pageSize, out int Total)
			where TEntity : class;
		/// <summary>
		/// 分页查询，可指定返回结果、排序、查询条件的通用分页查询方法，返回dynamic对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="pageIndex">分页索引，从1开始</param>
		/// <param name="pageSize">每页数量</param>
		/// <param name="Total">查询总数</param>
		/// <returns></returns>
		IList<dynamic> QueryDynamic<TEntity>
			(Expression<Func<TEntity, bool>> where,
			SortModelField[] orderByExpression,
			Expression<Func<TEntity, dynamic>> selector,
			int pageIndex, int pageSize, out int Total)
			where TEntity : class;

		/// <summary>
		/// 分页查询，可指定返回结果、排序、查询条件的通用查询方法，返回Object对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <typeparam name="TOrderBy">排序字段类型</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="orderby">排序字段</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="IsAsc">排序方向，true为正序false为倒序</param>
		/// <param name="pageIndex">分页索引，从1开始</param>
		/// <param name="pageSize">每页数量</param>
		/// <param name="Total">查询总数</param>
		/// <returns>自定义实体集合</returns>
		IList<object> QueryObject<TEntity, TOrderBy>
			(Expression<Func<TEntity, bool>> where, 
			Expression<Func<TEntity, TOrderBy>> orderby, 
			Func<IQueryable<TEntity>, List<object>> selector, 
			bool IsAsc, int pageIndex, int pageSize, out int Total)
			where TEntity : class;
		/// <summary>
		/// 分页查询，可指定返回结果、排序、查询条件的通用查询方法，返回Object对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="pageIndex">分页索引，从1开始</param>
		/// <param name="pageSize">每页数量</param>
		/// <param name="Total">查询总数</param>
		/// <returns>自定义实体集合</returns>
		IList<object> QueryObject<TEntity>
			(Expression<Func<TEntity, bool>> where,
			SortModelField[] orderByExpression,
			Func<IQueryable<TEntity>, List<object>> selector,
			int pageIndex, int pageSize, out int Total)
			where TEntity : class;

		/// <summary>
		/// 通过存储过程“Common_GetList”，得到分页后的数据
		/// </summary>
		/// <param name="startRowIndexId">开始行索引，从0开始</param>
		/// <param name="maxNumberRows">每页最大显示数量</param>
		/// <param name="SortColumn">排序字段名，只能指定一个字段</param>
		/// <param name="StrColumn">返回列名</param>
		/// <param name="Sorts">排序方式（DESC,ASC）</param>
		/// <param name="Filter">查询条件(例如: Name = 'name' and id=1 )</param>
		/// <param name="TableName">查询表名，可以指定联合查询的SQL语句(例如: Comment LEFT JOIN Users ON Comment.UserName = Users.UserName)</param>
		/// <param name="Total">输出参数：查询总数</param>
		/// <returns></returns>
		IList<T> GetList(int startRowIndexId, int maxNumberRows, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total);
		/// <summary>
		/// 通过存储过程“Common_GetList”，得到分页后的数据
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="startRowIndexId">开始行索引，从0开始</param>
		/// <param name="maxNumberRows">每页最大显示数量</param>
		/// <param name="SortColumn">排序字段名，只能指定一个字段</param>
		/// <param name="StrColumn">返回列名</param>
		/// <param name="Sorts">排序方式（DESC,ASC）</param>
		/// <param name="Filter">查询条件(例如: Name = 'name' and id=1 )</param>
		/// <param name="TableName">查询表名，可以指定联合查询的SQL语句(例如: Comment LEFT JOIN Users ON Comment.UserName = Users.UserName)</param>
		/// <param name="Total">输出参数：查询总数</param>
		/// <returns></returns>
		IList<TResult> GetList<TResult>(int startRowIndexId, int maxNumberRows, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total) where TResult : new();

		/// <summary>
		/// 通过存储过程“Common_GetListBySortColumn”，得到分页后的数据
		/// </summary>
		/// <param name="startRowIndexId">开始行索引，从0开始</param>
		/// <param name="maxNumberRows">每页最大显示数量</param>
		/// <param name="PrimaryColumn">主键字段名</param>
		/// <param name="SortColumnDbType">排序字段的数据类型(如：int)</param>
		/// <param name="SortColumn">排序字段名，只能指定一个字段</param>
		/// <param name="StrColumn">返回列名</param>
		/// <param name="Sorts">排序方式（DESC,ASC）</param>
		/// <param name="Filter">查询条件(例如: Name = 'name' and id=1 )</param>
		/// <param name="TableName">查询表名，可以指定联合查询的SQL语句(例如: Comment LEFT JOIN Users ON Comment.UserName = Users.UserName)</param>
		/// <param name="Total">输出参数：查询总数</param>
		/// <returns></returns>
		IList<T> GetListBySortColumn(int startRowIndexId, int maxNumberRows, string PrimaryColumn, string SortColumnDbType, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total);
		/// <summary>
		/// 通过存储过程“Common_GetListBySortColumn”，得到分页后的数据
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="startRowIndexId">开始行索引，从0开始</param>
		/// <param name="maxNumberRows">每页最大显示数量</param>
		/// <param name="PrimaryColumn">主键字段名</param>
		/// <param name="SortColumnDbType">排序字段的数据类型(如：int)</param>
		/// <param name="SortColumn">排序字段名，只能指定一个字段</param>
		/// <param name="StrColumn">返回列名</param>
		/// <param name="Sorts">排序方式（DESC,ASC）</param>
		/// <param name="Filter">查询条件(例如: Name = 'name' and id=1 )</param>
		/// <param name="TableName">查询表名，可以指定联合查询的SQL语句(例如: Comment LEFT JOIN Users ON Comment.UserName = Users.UserName)</param>
		/// <param name="Total">输出参数：查询总数</param>
		/// <returns></returns>
		IList<TResult> GetListBySortColumn<TResult>(int startRowIndexId, int maxNumberRows, string PrimaryColumn, string SortColumnDbType, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total) where TResult : new();

		/// <summary>
		/// 通过存储过程“Common_GetList”，得到分页后的数据
		/// </summary>
		/// <param name="startRowIndexId">开始行索引，从0开始</param>
		/// <param name="maxNumberRows">每页最大显示数量</param>
		/// <param name="SortColumn">排序字段名，只能指定一个字段</param>
		/// <param name="StrColumn">返回列名</param>
		/// <param name="Sorts">排序方式（DESC,ASC）</param>
		/// <param name="Filter">查询条件(例如: Name = 'name' and id=1 )</param>
		/// <param name="TableName">查询表名，可以指定联合查询的SQL语句(例如: Comment LEFT JOIN Users ON Comment.UserName = Users.UserName)</param>
		/// <param name="Total">输出参数：查询总数</param>
		/// <returns></returns>
		DataTable GetDataTable(int startRowIndexId, int maxNumberRows, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total);
		
		/// <summary>
		/// 通过存储过程“Common_GetListBySortColumn”，得到分页后的数据
		/// </summary>
		/// <param name="startRowIndexId">开始行索引，从0开始</param>
		/// <param name="maxNumberRows">每页最大显示数量</param>
		/// <param name="PrimaryColumn">主键字段名</param>
		/// <param name="SortColumnDbType">排序字段的数据类型(如：int)</param>
		/// <param name="SortColumn">排序字段名，只能指定一个字段</param>
		/// <param name="StrColumn">返回列名</param>
		/// <param name="Sorts">排序方式（DESC,ASC）</param>
		/// <param name="Filter">查询条件(例如: Name = 'name' and id=1 )</param>
		/// <param name="TableName">查询表名，可以指定联合查询的SQL语句(例如: Comment LEFT JOIN Users ON Comment.UserName = Users.UserName)</param>
		/// <param name="Total">输出参数：查询总数</param>
		/// <returns></returns>
		DataTable GetDataTableBySortColumn(int startRowIndexId, int maxNumberRows, string PrimaryColumn, string SortColumnDbType, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total);
		#endregion

		#region 执行SQL，检验是否存在数据
		/// <summary>
		/// 执行SQL，检验是否存在数据
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		bool IsExistBySql(string sql, params IDataParameter[] para);
		/// <summary>
		/// 执行SQL，检验是否存在数据
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		Task<bool> IsExistBySqlAsync(string sql, params IDataParameter[] para);

		/// <summary>
		/// 执行SQL，检验是否存在数据
		/// </summary>
		/// <param name="sql">带参数的SQL语句</param>
		/// <param name="paraName">参数名数组</param>
		/// <param name="paraValue">参数值数组</param>
		/// <returns>有返回true,没有返回false</returns>
		bool IsExistBySql(string sql, string[] paraName, object[] paraValue);
		/// <summary>
		/// 执行SQL，检验是否存在数据
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="paraName"></param>
		/// <param name="paraValue"></param>
		/// <returns></returns>
		Task<bool> IsExistBySqlAsync(string sql, string[] paraName, object[] paraValue);

		/// <summary>
		/// 执行SQL，检验是否存在数据
		/// </summary>
		/// <param name="sql">带参数的SQL语句</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		bool IsExistBySql(string sql, Dictionary<string, object> dict);
		/// <summary>
		/// 执行SQL，检验是否存在数据
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		Task<bool> IsExistBySqlAsync(string sql, Dictionary<string, object> dict);
		#endregion

		#region 执行SQL，返回受影响的行数
		/// <summary>
		/// 执行SQL语句，返回受影响的行数(select语句只返回－1)
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		int ExeSQL(string sql, params IDataParameter[] para);
		/// <summary>
		/// 执行SQL语句，返回受影响的行数(select语句只返回－1)
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		Task<int> ExeSQLAsync(string sql, params IDataParameter[] para);

		/// <summary>
		/// 执行SQL语句，返回受影响的行数(select语句只返回－1)
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="paraName"></param>
		/// <param name="paraValue"></param>
		/// <returns></returns>
		int ExeSQL(string sql, string[] paraName, object[] paraValue);
		/// <summary>
		/// 执行SQL语句，返回受影响的行数(select语句只返回－1)
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="paraName"></param>
		/// <param name="paraValue"></param>
		/// <returns></returns>
		Task<int> ExeSQLAsync(string sql, string[] paraName, object[] paraValue);

		/// <summary>
		/// 执行SQL语句，返回受影响的行数(select语句只返回－1)
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		int ExeSQL(string sql, Dictionary<string, object> dict);
		/// <summary>
		/// 执行SQL语句，返回受影响的行数(select语句只返回－1)
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		Task<int> ExeSQLAsync(string sql, Dictionary<string, object> dict);
		#endregion

		#region 执行SQL，返回结果，返回值必须在实体类中
		/// <summary>
		/// 执行SQL，返回结果，返回值必须在实体类中。
		/// 例：var s = testDal.GetBySQL《string》("select name from tablename",m=>m.Name);
		/// var s = testDal.GetBySQL《StoreM》("select * from tablename where name=@name",m=>m,new SqlParameter("name", "1"));
		/// var s = testDal.GetBySQL《dynamic》("select name,Code from tablename",m=>new { m.Name,m.Code });
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="scalar"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		TResult GetBySQL<TResult>(string sql, Expression<Func<T, TResult>> scalar, params IDataParameter[] para);
		/// <summary>
		/// 执行SQL，返回结果，返回值必须在实体类中。
		/// 例：var s = testDal.GetBySQL《string》("select name from tablename",m=>m.Name);
		/// var s = testDal.GetBySQL《StoreM》("select * from tablename where name=@name",m=>m,new SqlParameter("name", "1"));
		/// var s = testDal.GetBySQL《dynamic》("select name,Code from tablename",m=>new { m.Name,m.Code });
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="scalar"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		Task<TResult> GetBySQLAsync<TResult>(string sql, Expression<Func<T, TResult>> scalar, params IDataParameter[] para);

		/// <summary>
		/// 执行SQL，返回结果，返回值必须在实体类中。
		/// 例：var s = testDal.GetBySQL《StoreM》("select * from tablename where name=@name",m=>m,new string[]{"name"},new string[]{"1"});
		/// var s = testDal.GetBySQL《dynamic》("select name,Code from tablename where name=@name",m=>new { m.Name,m.Code },new string[]{"name"},new string[]{"1"});
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="scalar"></param>
		/// <param name="paraName"></param>
		/// <param name="paraValue"></param>
		/// <returns></returns>
		TResult GetBySQL<TResult>(string sql, Expression<Func<T, TResult>> scalar, string[] paraName, object[] paraValue);
		/// <summary>
		/// 执行SQL，返回结果，返回值必须在实体类中。
		/// 例：var s = testDal.GetBySQL《StoreM》("select * from tablename where name=@name",m=>m,new string[]{"name"},new string[]{"1"});
		/// var s = testDal.GetBySQL《dynamic》("select name,Code from tablename where name=@name",m=>new { m.Name,m.Code },new string[]{"name"},new string[]{"1"});
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="scalar"></param>
		/// <param name="paraName"></param>
		/// <param name="paraValue"></param>
		/// <returns></returns>
		Task<TResult> GetBySQLAsync<TResult>(string sql, Expression<Func<T, TResult>> scalar, string[] paraName, object[] paraValue);

		/// <summary>
		/// 执行SQL，返回结果，返回值必须在实体类中。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="scalar"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		TResult GetBySQL<TResult>(string sql, Expression<Func<T, TResult>> scalar, Dictionary<string, object> dict);
		/// <summary>
		/// 执行SQL，返回结果，返回值必须在实体类中。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="scalar"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		Task<TResult> GetBySQLAsync<TResult>(string sql, Expression<Func<T, TResult>> scalar, Dictionary<string, object> dict);
		#endregion

		#region 执行SQL，返回查询结果。主要用于返回实体类或者值类型
		/// <summary>
		/// 执行SQL，返回查询结果。主要用于返回实体类或者值类型，返回参数需要带有空白构造函数。
		/// 例：var s = testDal.SqlQuery《StoreM》("select * from tablename where name=@name",new SqlParameter("name", "1"));
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		IList<TResult> SqlQuery<TResult>(string sql, params IDataParameter[] parameters) where TResult : new();
		/// <summary>
		/// 执行SQL，返回查询结果。主要用于返回实体类或者值类型，返回参数需要带有空白构造函数。
		/// 例：var s = testDal.SqlQuery《StoreM》("select * from tablename where name=@name",new SqlParameter("name", "1"));
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		Task<IList<TResult>> SqlQueryAsync<TResult>(string sql, params IDataParameter[] parameters) where TResult : new();

		/// <summary>
		/// 执行SQL，返回查询结果。主要用于返回实体类或者值类型，返回参数需要带有空白构造函数。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="paraName"></param>
		/// <param name="paraValue"></param>
		/// <returns></returns>
		IList<TResult> SqlQuery<TResult>(string sql, string[] paraName, object[] paraValue) where TResult : new();
		/// <summary>
		/// 执行SQL，返回查询结果。主要用于返回实体类或者值类型，返回参数需要带有空白构造函数。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="paraName"></param>
		/// <param name="paraValue"></param>
		/// <returns></returns>
		Task<IList<TResult>> SqlQueryAsync<TResult>(string sql, string[] paraName, object[] paraValue) where TResult : new();

		/// <summary>
		/// 执行SQL，返回查询结果。主要用于返回实体类或者值类型，返回参数需要带有空白构造函数。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		IList<TResult> SqlQuery<TResult>(string sql, Dictionary<string, object> dict) where TResult : new();
		/// <summary>
		/// 执行SQL，返回查询结果。主要用于返回实体类或者值类型，返回参数需要带有空白构造函数。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		Task<IList<TResult>> SqlQueryAsync<TResult>(string sql, Dictionary<string, object> dict) where TResult : new();
		#endregion

		#region 执行SQL，返回第一列的数据列表。主要用于返回IList《string》
		/// <summary>
		/// 执行SQL，返回第一列的数据列表。主要用于返回IList《string》。
		/// 例：var s = testDal.SqlQueryOne《string》("select name from tablename where name=@name",new SqlParameter("name", "1"));
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		IList<TResult> SqlQueryOne<TResult>(string sql, params IDataParameter[] parameters);
		/// <summary>
		/// 执行SQL，返回第一列的数据列表。主要用于返回IList《string》。
		/// 例：var s = testDal.SqlQueryOne《string》("select name from tablename where name=@name",new SqlParameter("name", "1"));
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		Task<IList<TResult>> SqlQueryOneAsync<TResult>(string sql, params IDataParameter[] parameters);

		/// <summary>
		/// 执行SQL，返回第一列的数据列表。主要用于返回IList《string》。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="paraName"></param>
		/// <param name="paraValue"></param>
		/// <returns></returns>
		IList<TResult> SqlQueryOne<TResult>(string sql, string[] paraName, object[] paraValue);
		/// <summary>
		/// 执行SQL，返回第一列的数据列表。主要用于返回IList《string》。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="paraName"></param>
		/// <param name="paraValue"></param>
		/// <returns></returns>
		Task<IList<TResult>> SqlQueryOneAsync<TResult>(string sql, string[] paraName, object[] paraValue);

		/// <summary>
		/// 执行SQL，返回第一列的数据列表。主要用于返回IList《string》。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		IList<TResult> SqlQueryOne<TResult>(string sql, Dictionary<string, object> dict);
		/// <summary>
		/// 执行SQL，返回第一列的数据列表。主要用于返回IList《string》。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		Task<IList<TResult>> SqlQueryOneAsync<TResult>(string sql, Dictionary<string, object> dict);
		#endregion

		#region 执行SQL，返回DataTable
		/// <summary>
		/// 执行SQL，返回DataTable
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		DataTable GetDataTableBySql(string sql, params IDataParameter[] parameters);
		/// <summary>
		/// 执行SQL，返回DataTable
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		Task<DataTable> GetDataTableBySqlAsync(string sql, params IDataParameter[] parameters);

		/// <summary>
		/// 执行SQL，返回DataTable
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="paraName"></param>
		/// <param name="paraValue"></param>
		/// <returns></returns>
		DataTable GetDataTableBySql(string sql, string[] paraName, object[] paraValue);
		/// <summary>
		/// 执行SQL，返回DataTable
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="paraName"></param>
		/// <param name="paraValue"></param>
		/// <returns></returns>
		Task<DataTable> GetDataTableBySqlAsync(string sql, string[] paraName, object[] paraValue);

		/// <summary>
		/// 执行SQL，返回DataTable
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		DataTable GetDataTableBySql(string sql, Dictionary<string, object> dict);
		/// <summary>
		/// 执行SQL，返回DataTable
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		Task<DataTable> GetDataTableBySqlAsync(string sql, Dictionary<string, object> dict);
		#endregion
	}
}
