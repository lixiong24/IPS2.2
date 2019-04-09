using AutoMapper;
using JX.Core;
using JX.Core.Entity;
using JX.Infrastructure.Common;
using JX.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JX.Application
{
	/// <summary>
	/// 数据库表：Models 的应用层服务接口实现类.
	/// </summary>
	public partial class ModelsServiceApp : IModelsServiceApp
	{
		#region 仓储接口
		private readonly IModelsRepository _repository;
		/// <summary>
		/// 构造器注入
		/// </summary>
		/// <param name="repository"></param>
		public ModelsServiceApp(IModelsRepository repository)
		{
			_repository = repository;
		}
		#endregion
		
		#region 获取特定字段的值
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
		public virtual TResult GetScalar<TResult, TOrderBy>(Expression<Func<ModelsEntity, TResult>> scalar, Expression<Func<ModelsEntity, bool>> predicate = null, Expression<Func<ModelsEntity, TOrderBy>> orderby = null, bool IsAsc = true)
		{
			return _repository.GetScalar<TResult, TOrderBy>(scalar,predicate,orderby,IsAsc);
		}
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
		public virtual async Task<TResult> GetScalarAsync<TResult, TOrderBy>(Expression<Func<ModelsEntity, TResult>> scalar, Expression<Func<ModelsEntity, bool>> predicate = null, Expression<Func<ModelsEntity, TOrderBy>> orderby = null, bool IsAsc = true)
		{
			return await _repository.GetScalarAsync<TResult, TOrderBy>(scalar,predicate,orderby,IsAsc);
		}

		/// <summary>
		/// 得到最大值
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="max">最大值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual TResult GetMax<TResult>(Expression<Func<ModelsEntity, TResult>> max, Expression<Func<ModelsEntity, bool>> predicate = null)
		{
			return _repository.GetMax<TResult>(max,predicate);
		}
		/// <summary>
		/// 得到最大值
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="max">最大值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual async Task<TResult> GetMaxAsync<TResult>(Expression<Func<ModelsEntity, TResult>> max, Expression<Func<ModelsEntity, bool>> predicate = null)
		{
			return await _repository.GetMaxAsync<TResult>(max,predicate);
		}
		
		/// <summary>
		/// 得到最小值
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="min">最小值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual TResult GetMin<TResult>(Expression<Func<ModelsEntity, TResult>> min, Expression<Func<ModelsEntity, bool>> predicate = null)
		{
			return _repository.GetMin<TResult>(min,predicate);
		}
		/// <summary>
		/// 得到最小值
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="min">最小值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual async Task<TResult> GetMinAsync<TResult>(Expression<Func<ModelsEntity, TResult>> min, Expression<Func<ModelsEntity, bool>> predicate = null)
		{
			return await _repository.GetMinAsync<TResult>(min,predicate);
		}
		
		/// <summary>
		/// 得到平均值
		/// </summary>
		/// <param name="avg">平均值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual decimal GetAvg(Expression<Func<ModelsEntity, decimal>> avg, Expression<Func<ModelsEntity, bool>> predicate = null)
		{
			return _repository.GetAvg(avg,predicate);
		}
		/// <summary>
		/// 得到平均值
		/// </summary>
		/// <param name="avg">平均值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual async Task<decimal> GetAvgAsync(Expression<Func<ModelsEntity, decimal>> avg, Expression<Func<ModelsEntity, bool>> predicate = null)
		{
			return await _repository.GetAvgAsync(avg,predicate);
		}
		
		/// <summary>
		/// 得到求和值
		/// </summary>
		/// <param name="sum">求和值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual decimal GetSum(Expression<Func<ModelsEntity, decimal>> sum, Expression<Func<ModelsEntity, bool>> predicate = null)
		{
			return _repository.GetSum(sum,predicate);
		}
		/// <summary>
		/// 得到求和值
		/// </summary>
		/// <param name="sum">求和值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual async Task<decimal> GetSumAsync(Expression<Func<ModelsEntity, decimal>> sum, Expression<Func<ModelsEntity, bool>> predicate = null)
		{
			return await _repository.GetSumAsync(sum,predicate);
		}
		
		/// <summary>
		/// 得到总数值
		/// </summary>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual int GetCount(Expression<Func<ModelsEntity, bool>> predicate = null)
		{
			return _repository.GetCount(predicate);
		}
		/// <summary>
		/// 得到总数值
		/// </summary>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual async Task<int> GetCountAsync(Expression<Func<ModelsEntity, bool>> predicate = null)
		{
			return await _repository.GetCountAsync(predicate);
		}
		#endregion
		
		#region 验证是否存在
		/// <summary>
		/// 验证当前条件是否存在相同项
		/// </summary>
		public virtual bool IsExist(Expression<Func<ModelsEntity, bool>> predicate)
		{
			return _repository.IsExist(predicate);
		}
		/// <summary>
		/// 验证当前条件是否存在相同项（异步方式）
		/// </summary>
		public virtual async Task<bool> IsExistAsync(Expression<Func<ModelsEntity, bool>> predicate)
		{
			return await _repository.IsExistAsync(predicate);
		}
		#endregion
		
		#region 添加
		/// <summary>
		/// 增加一条记录
		/// </summary>
		/// <param name="entity">entity模型</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual bool Add(ModelsEntity entity, bool IsCommit = true)
		{
			if(entity.ModelID <= 0) entity.ModelID=GetMax<int>(p=>p.ModelID)+1;
			return _repository.Add(entity, IsCommit);
		}
		/// <summary>
		/// 增加一条记录(异步方式)
		/// </summary>
		/// <param name="entity">entity模型</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual async Task<bool> AddAsync(ModelsEntity entity, bool IsCommit = true)
		{
			if(entity.ModelID <= 0) entity.ModelID=GetMax<int>(p=>p.ModelID)+1;
			return await _repository.AddAsync(entity, IsCommit);
		}

		/// <summary>
		/// 增加多条记录，同一模型
		/// </summary>
		/// <param name="entityList">entity模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual bool AddList(IList<ModelsEntity> entityList, bool IsCommit = true)
		{
			if (entityList == null || entityList.Count == 0) return false;
			entityList.ToList().ForEach(item =>
			{
				Add(item);
			});
			return true;
		}
		/// <summary>
		/// 增加多条记录，同一模型（异步方式）
		/// </summary>
		/// <param name="entityList">entity模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual async Task<bool> AddListAsync(IList<ModelsEntity> entityList, bool IsCommit = true)
		{
			if (entityList == null || entityList.Count == 0) return await Task.Run(() => false);
			entityList.ToList().ForEach(async item =>
			{
				await AddAsync(item);
			});
			return true;
		}

		/// <summary>
		/// 增加或更新一条记录
		/// </summary>
		/// <param name="entity">entity模型</param>
		/// <param name="IsSave">是否增加</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual bool AddOrUpdate(ModelsEntity entity, bool IsSave, bool IsCommit = true)
		{
			return IsSave ? Add(entity, IsCommit) : Update(entity, IsCommit);
		}
		/// <summary>
		/// 增加或更新一条记录（异步方式）
		/// </summary>
		/// <param name="entity">entity模型</param>
		/// <param name="IsSave">是否增加</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual async Task<bool> AddOrUpdateAsync(ModelsEntity entity, bool IsSave, bool IsCommit = true)
		{
			return IsSave ? await AddAsync(entity, IsCommit) : await UpdateAsync(entity, IsCommit);
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 删除一条记录
		/// </summary>
		/// <param name="entity">entity模型</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual bool Delete(ModelsEntity entity, bool IsCommit = true)
		{
			if (entity == null) return false;
			return _repository.Delete(entity, IsCommit);
		}
		/// <summary>
		/// 删除一条记录（异步方式）
		/// </summary>
		/// <param name="entity">entity模型</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual async Task<bool> DeleteAsync(ModelsEntity entity, bool IsCommit = true)
		{
			if (entity == null) return await Task.Run(() => false);

			return await _repository.DeleteAsync(entity, IsCommit);
		}

		/// <summary>
		/// 删除多条记录，同一模型
		/// </summary>
		/// <param name="entityList">entity模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual bool DeleteList(IList<ModelsEntity> entityList, bool IsCommit = true)
		{
			if (entityList == null || entityList.Count == 0) return false;

			return _repository.DeleteList(entityList, IsCommit);
		}
		/// <summary>
		/// 删除多条记录，同一模型（异步方式）
		/// </summary>
		/// <param name="entityList">entity模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual async Task<bool> DeleteListAsync(IList<ModelsEntity> entityList, bool IsCommit = true)
		{
			if (entityList == null || entityList.Count == 0) return await Task.Run(() => false);

			return await _repository.DeleteListAsync(entityList, IsCommit);
		}

		/// <summary>
		/// 通过Lamda表达式，删除一条或多条记录
		/// </summary>
		/// <param name="predicate"></param>
		/// <param name="IsCommit"></param>
		/// <returns></returns>
		public virtual bool Delete(Expression<Func<ModelsEntity, bool>> predicate, bool IsCommit = true)
		{
			return _repository.Delete(predicate, IsCommit);
		}
		/// <summary>
		/// 通过Lamda表达式，删除一条或多条记录（异步方式）
		/// </summary>
		/// <param name="predicate"></param>
		/// <param name="IsCommit"></param>
		/// <returns></returns>
		public virtual async Task<bool> DeleteAsync(Expression<Func<ModelsEntity, bool>> predicate, bool IsCommit = true)
		{
			return await _repository.DeleteAsync(predicate, IsCommit);
		}

		/// <summary>
		/// 根据SQL删除一条或多条记录
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		public virtual bool Delete(string sql, params DbParameter[] para)
		{
			return _repository.Delete(sql, para);
		}
		/// <summary>
		/// 根据SQL删除一条或多条记录（异步方式）
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		public virtual async Task<bool> DeleteAsync(string sql, params DbParameter[] para)
		{
			return await _repository.DeleteAsync(sql, para);
		}
		#endregion
		
		#region 修改
		/// <summary>
		/// 更新一条记录
		/// </summary>
		/// <param name="entity">entity模型</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual bool Update(ModelsEntity entity, bool IsCommit = true)
		{
			return _repository.Update(entity, IsCommit);
		}
		/// <summary>
		/// 更新一条记录（异步方式）
		/// </summary>
		/// <param name="entity">entity模型</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual async Task<bool> UpdateAsync(ModelsEntity entity, bool IsCommit = true)
		{
			return await _repository.UpdateAsync(entity, IsCommit);
		}

		/// <summary>
		/// 更新多条记录，同一模型
		/// </summary>
		/// <param name="entityList">entity模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual bool UpdateList(IList<ModelsEntity> entityList, bool IsCommit = true)
		{
			if (entityList == null || entityList.Count == 0) return false;

			return _repository.UpdateList(entityList, IsCommit);
		}
		/// <summary>
		/// 更新多条记录，同一模型（异步方式）
		/// </summary>
		/// <param name="entityList">entity模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual async Task<bool> UpdateListAsync(IList<ModelsEntity> entityList, bool IsCommit = true)
		{
			if (entityList == null || entityList.Count == 0) return await Task.Run(() => false);

			return await _repository.UpdateListAsync(entityList, IsCommit);
		}

		/// <summary>
		/// 根据SQL修改一条或多条记录
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		public virtual bool Update(string sql, params DbParameter[] para)
		{
			return _repository.Update(sql, para);
		}
		/// <summary>
		/// 根据SQL修改一条或多条记录（异步方式）
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		public virtual async Task<bool> UpdateAsync(string sql, params DbParameter[] para)
		{
			return await _repository.UpdateAsync(sql, para);
		}
		#endregion
		
		#region 得到entity
		/// <summary>
		/// 通过Lamda表达式获取entity
		/// </summary>
		/// <param name="predicate">Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual ModelsEntity Get(Expression<Func<ModelsEntity, bool>> predicate)
		{
			return _repository.Get(predicate);
		}
		/// <summary>
		/// 通过Lamda表达式获取entity（异步方式）
		/// </summary>
		/// <param name="predicate">Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual async Task<ModelsEntity> GetAsync(Expression<Func<ModelsEntity, bool>> predicate)
		{
			return await _repository.GetAsync(predicate);
		}
		#endregion
		
		#region 得到entity列表

		/// <summary>
		/// 返回IQueryable集合，延时加载数据
		/// </summary>
		/// <param name="predicate">Lamda表达式（p=>p.Id==Id）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		public virtual IQueryable<ModelsEntity> LoadAll(Expression<Func<ModelsEntity, bool>> predicate, params SortModelField[] orderByExpression)
		{
			return _repository.LoadAll(predicate,orderByExpression);
		}
		/// <summary>
		/// 返回IQueryable集合，延时加载数据（异步方式）
		/// </summary>
		/// <param name="predicate">Lamda表达式（p=>p.Id==Id）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		public virtual async Task<IQueryable<ModelsEntity>> LoadAllAsync(Expression<Func<ModelsEntity, bool>> predicate, params SortModelField[] orderByExpression)
		{
			return await _repository.LoadAllAsync(predicate,orderByExpression);
		}

		/// <summary>
		/// 返回集合,不采用延时加载
		/// </summary>
		/// <param name="predicate">Lamda表达式（p=>p.Id==Id）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		public virtual List<ModelsEntity> LoadListAll(Expression<Func<ModelsEntity, bool>> predicate, params SortModelField[] orderByExpression)
		{
			return _repository.LoadListAll(predicate,orderByExpression);
		}
		/// <summary>
		/// 返回集合,不采用延时加载（异步方式）
		/// </summary>
		/// <param name="predicate">Lamda表达式（p=>p.Id==Id）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		public virtual async Task<List<ModelsEntity>> LoadListAllAsync(Expression<Func<ModelsEntity, bool>> predicate, params SortModelField[] orderByExpression)
		{
			return await _repository.LoadListAllAsync(predicate,orderByExpression);
		}
		
		/// <summary>
		/// T-Sql方式：返回IQueryable集合
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="para">Parameters参数</param>
		/// <returns></returns>
		public virtual IQueryable<ModelsEntity> LoadAllBySql(string sql, params DbParameter[] para)
		{
			return _repository.LoadAllBySql(sql,para);
		}
		/// <summary>
		/// T-Sql方式：返回IQueryable集合（异步方式）
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="para">Parameters参数</param>
		/// <returns></returns>
		public virtual async Task<IQueryable<ModelsEntity>> LoadAllBySqlAsync(string sql, params DbParameter[] para)
		{
			return await _repository.LoadAllBySqlAsync(sql,para);
		}

		/// <summary>
		/// Sql方式：返回List集合
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="para">Parameters参数</param>
		/// <returns></returns>
		public virtual List<ModelsEntity> LoadListAllBySql(string sql, params DbParameter[] para)
		{
			return _repository.LoadListAllBySql(sql, para);
		}
		/// <summary>
		/// Sql方式：返回List集合（异步方式）
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="para">Parameters参数</param>
		/// <returns></returns>
		public virtual async Task<List<ModelsEntity>> LoadListAllBySqlAsync(string sql, params DbParameter[] para)
		{
			return await _repository.LoadListAllBySqlAsync(sql, para);
		}
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
		public virtual List<TResult> QueryEntity<TEntity, TOrderBy, TResult>
			(Expression<Func<TEntity, bool>> where,
			Expression<Func<TEntity, TOrderBy>> orderby,
			Expression<Func<TEntity, TResult>> selector,
			bool IsAsc=true)
			where TEntity : class
			where TResult : class
		{
			return _repository.QueryEntity<TEntity, TOrderBy, TResult>(where,orderby,selector,IsAsc);
		}
		/// <summary>
		/// 可指定返回结果、排序、查询条件的通用查询方法，返回实体对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <typeparam name="TResult">数据结果，与TEntity一致</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		public virtual List<TResult> QueryEntity<TEntity, TResult>
			(Expression<Func<TEntity, bool>> where,
			Expression<Func<TEntity, TResult>> selector,
			params SortModelField[] orderByExpression)
			where TEntity : class
			where TResult : class
		{
			return _repository.QueryEntity<TEntity, TResult>(where, selector, orderByExpression);
		}
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
		public virtual async Task<List<TResult>> QueryEntityAsync<TEntity, TOrderBy, TResult>
			(Expression<Func<TEntity, bool>> where,
			Expression<Func<TEntity, TOrderBy>> orderby,
			Expression<Func<TEntity, TResult>> selector,
			bool IsAsc = true)
			where TEntity : class
			where TResult : class
		{
			return await _repository.QueryEntityAsync<TEntity, TOrderBy, TResult>(where,orderby,selector,IsAsc);
		}
		/// <summary>
		/// 可指定返回结果、排序、查询条件的通用查询方法，返回实体对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <typeparam name="TResult">数据结果，与TEntity一致</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		public virtual async Task<List<TResult>> QueryEntityAsync<TEntity, TResult>
			(Expression<Func<TEntity, bool>> where,
			Expression<Func<TEntity, TResult>> selector,
			params SortModelField[] orderByExpression)
			where TEntity : class
			where TResult : class
		{
			return await _repository.QueryEntityAsync<TEntity, TResult>(where,selector,orderByExpression);
		}

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
		public virtual List<object> QueryObject<TEntity, TOrderBy>
			(Expression<Func<TEntity, bool>> where,
			Expression<Func<TEntity, TOrderBy>> orderby,
			Func<IQueryable<TEntity>,List<object>> selector,
			bool IsAsc = true)
			where TEntity : class
		{
			return _repository.QueryObject<TEntity, TOrderBy>(where,orderby,selector,IsAsc);
		}
		/// <summary>
		/// 可指定返回结果、排序、查询条件的通用查询方法，返回Object对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		public virtual List<object> QueryObject<TEntity>
			(Expression<Func<TEntity, bool>> where, 
			Func<IQueryable<TEntity>, List<object>> selector, 
			params SortModelField[] orderByExpression)
			where TEntity : class
		{
			return _repository.QueryObject<TEntity>(where,selector,orderByExpression);
		}
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
		public virtual async Task<List<object>> QueryObjectAsync<TEntity, TOrderBy>
			(Expression<Func<TEntity, bool>> where,
			Expression<Func<TEntity, TOrderBy>> orderby,
			Func<IQueryable<TEntity>,List<object>> selector,
			bool IsAsc = true)
			where TEntity : class
		{
			return await _repository.QueryObjectAsync<TEntity, TOrderBy>(where,orderby,selector,IsAsc);
		}
		/// <summary>
		/// 可指定返回结果、排序、查询条件的通用查询方法，返回Object对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		public virtual async Task<List<object>> QueryObjectAsync<TEntity>
			(Expression<Func<TEntity, bool>> where,
			Func<IQueryable<TEntity>, List<object>> selector,
			params SortModelField[] orderByExpression)
			where TEntity : class
		{
			return await _repository.QueryObjectAsync<TEntity>(where,selector,orderByExpression);
		}

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
		public virtual List<dynamic> QueryDynamic<TEntity, TOrderBy>
			(Expression<Func<TEntity, bool>> where, 
			Expression<Func<TEntity, TOrderBy>> orderby, 
			Expression<Func<TEntity, dynamic>> selector, 
			bool IsAsc = true)
			where TEntity : class
		{
			return _repository.QueryDynamic<TEntity, TOrderBy>(where,orderby,selector,IsAsc);
		}
		/// <summary>
		/// 可指定返回结果、排序、查询条件的通用查询方法，返回dynamic对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		public virtual List<dynamic> QueryDynamic<TEntity>
			(Expression<Func<TEntity, bool>> where,
			Expression<Func<TEntity, dynamic>> selector,
			params SortModelField[] orderByExpression)
			where TEntity : class
		{
			return _repository.QueryDynamic<TEntity>(where,selector,orderByExpression);
		}
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
		public virtual async Task<List<dynamic>> QueryDynamicAsync<TEntity, TOrderBy>
			(Expression<Func<TEntity, bool>> where, 
			Expression<Func<TEntity, TOrderBy>> orderby, 
			Expression<Func<TEntity, dynamic>> selector, 
			bool IsAsc = true)
			where TEntity : class
		{
			return await _repository.QueryDynamicAsync<TEntity, TOrderBy>(where,orderby,selector,IsAsc);
		}
		/// <summary>
		/// 可指定返回结果、排序、查询条件的通用查询方法，返回dynamic对象集合
		/// </summary>
		/// <typeparam name="TEntity">实体对象</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		public virtual async Task<List<dynamic>> QueryDynamicAsync<TEntity>
			(Expression<Func<TEntity, bool>> where,
			Expression<Func<TEntity, dynamic>> selector,
			params SortModelField[] orderByExpression)
			where TEntity : class
		{
			return await _repository.QueryDynamicAsync<TEntity>(where,selector,orderByExpression);
		}
		#endregion
		
		#region 分页
		/// <summary>
		/// 分页查询，可指定返回结果、排序、查询条件的通用分页查询方法，返回dto对象集合
		/// </summary>
		/// <typeparam name="TEntity">dto对象</typeparam>
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
		public virtual IList<TResult> QueryEntity<TEntity, TOrderBy, TResult>
			(Expression<Func<TEntity, bool>> where,
			Expression<Func<TEntity, TOrderBy>> orderby,
			Expression<Func<TEntity, TResult>> selector,
			bool IsAsc, int pageIndex, int pageSize, out int Total)
			where TEntity : class
			where TResult : class
		{
			Total = 0;
			return _repository.QueryEntity<TEntity, TOrderBy, TResult>(where, orderby, selector, IsAsc, pageIndex, pageSize,out Total);
		}
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
		public virtual IList<TResult> QueryEntity<TEntity, TResult>
			(Expression<Func<TEntity, bool>> where,
			SortModelField[] orderByExpression,
			Expression<Func<TEntity, TResult>> selector,
			int pageIndex, int pageSize, out int Total)
			where TEntity : class
			where TResult : class
		{
			Total = 0;
			return _repository.QueryEntity<TEntity, TResult>(where, orderByExpression, selector, pageIndex, pageSize,out Total);
		}

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
		public virtual IList<dynamic> QueryDynamic<TEntity, TOrderBy>
			(Expression<Func<TEntity, bool>> where,
			Expression<Func<TEntity, TOrderBy>> orderby,
			Expression<Func<TEntity, dynamic>> selector,
			bool IsAsc, int pageIndex, int pageSize, out int Total)
			where TEntity : class
		{
			Total = 0;
			return _repository.QueryDynamic<TEntity, TOrderBy>(where, orderby, selector, IsAsc, pageIndex, pageSize,out Total);	
		}
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
		public virtual IList<dynamic> QueryDynamic<TEntity>
			(Expression<Func<TEntity, bool>> where,
			SortModelField[] orderByExpression,
			Expression<Func<TEntity, dynamic>> selector,
			int pageIndex, int pageSize, out int Total)
			where TEntity : class
		{
			Total = 0;
			return _repository.QueryDynamic<TEntity>(where, orderByExpression, selector, pageIndex, pageSize,out Total);	
		}
			
		/// <summary>
		/// 分页查询，可指定返回结果、排序、查询条件的通用查询方法，返回Object对象集合
		/// </summary>
		/// <typeparam name="TEntity">dto对象</typeparam>
		/// <typeparam name="TOrderBy">排序字段类型</typeparam>
		/// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
		/// <param name="orderby">排序字段</param>
		/// <param name="selector">返回结果（必须是模型中存在的字段）</param>
		/// <param name="IsAsc">排序方向，true为正序false为倒序</param>
		/// <param name="pageIndex">分页索引，从1开始</param>
		/// <param name="pageSize">每页数量</param>
		/// <param name="Total">查询总数</param>
		/// <returns>自定义dto集合</returns>
		public virtual IList<object> QueryObject<TEntity, TOrderBy>
			(Expression<Func<TEntity, bool>> where,
			Expression<Func<TEntity, TOrderBy>> orderby,
			Func<IQueryable<TEntity>, List<object>> selector,
			bool IsAsc, int pageIndex, int pageSize, out int Total)
			where TEntity : class
		{
			Total = 0;
			return _repository.QueryObject<TEntity, TOrderBy>(where, orderby, selector, IsAsc, pageIndex, pageSize, out Total);
		}
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
		public virtual IList<object> QueryObject<TEntity>
			(Expression<Func<TEntity, bool>> where,
			SortModelField[] orderByExpression,
			Func<IQueryable<TEntity>, List<object>> selector,
			int pageIndex, int pageSize, out int Total)
			where TEntity : class
		{
			Total = 0;
			return _repository.QueryObject<TEntity>(where, orderByExpression, selector, pageIndex, pageSize, out Total);
		}
		
		/// <summary>
		/// 通过存储过程“Common_GetList”，得到分页后的数据
		/// </summary>
		/// <param name="startRowIndexId">开始行索引</param>
		/// <param name="maxNumberRows">每页最大显示数量</param>
		/// <param name="SortColumn">排序字段名，只能指定一个字段</param>
		/// <param name="StrColumn">返回列名</param>
		/// <param name="Sorts">排序方式（DESC,ASC）</param>
		/// <param name="Filter">查询条件(例如: Name = 'name' and id=1 )</param>
		/// <param name="TableName">查询表名，可以指定联合查询的SQL语句(例如: Comment LEFT JOIN Users ON Comment.UserName = Users.UserName)</param>
		/// <param name="Total">输出参数：查询总数</param>
		/// <returns></returns>
		public virtual IList<ModelsEntity> GetList(int startRowIndexId, int maxNumberRows, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total)
		{
			Total=0;
			var entity = _repository.GetList(startRowIndexId,maxNumberRows,SortColumn,StrColumn,Sorts,Filter,TableName,out Total);
			return entity;
		}
		/// <summary>
		/// 通过存储过程“Common_GetList”，得到分页后的数据
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="startRowIndexId">开始行索引</param>
		/// <param name="maxNumberRows">每页最大显示数量</param>
		/// <param name="SortColumn">排序字段名，只能指定一个字段</param>
		/// <param name="StrColumn">返回列名</param>
		/// <param name="Sorts">排序方式（DESC,ASC）</param>
		/// <param name="Filter">查询条件(例如: Name = 'name' and id=1 )</param>
		/// <param name="TableName">查询表名，可以指定联合查询的SQL语句(例如: Comment LEFT JOIN Users ON Comment.UserName = Users.UserName)</param>
		/// <param name="Total">输出参数：查询总数</param>
		/// <returns></returns>
		public virtual IList<TResult> GetList<TResult>(int startRowIndexId, int maxNumberRows, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total) where TResult : new()
		{
			Total=0;
			return _repository.GetList<TResult>(startRowIndexId,maxNumberRows,SortColumn,StrColumn,Sorts,Filter,TableName,out Total);
		}

		/// <summary>
		/// 通过存储过程“Common_GetListBySortColumn”，得到分页后的数据
		/// </summary>
		/// <param name="startRowIndexId">开始行索引</param>
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
		public virtual IList<ModelsEntity> GetListBySortColumn(int startRowIndexId, int maxNumberRows, string PrimaryColumn, string SortColumnDbType, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total)
		{
			Total=0;
			var entity = _repository.GetListBySortColumn(startRowIndexId, maxNumberRows, PrimaryColumn, SortColumnDbType,SortColumn, StrColumn, Sorts, Filter, TableName,out Total);
			return entity;
		}
		/// <summary>
		/// 通过存储过程“Common_GetListBySortColumn”，得到分页后的数据
		/// </summary>
		/// <param name="startRowIndexId">开始行索引</param>
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
		public virtual IList<TResult> GetListBySortColumn<TResult>(int startRowIndexId, int maxNumberRows, string PrimaryColumn, string SortColumnDbType, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total) where TResult : new()
		{
			Total=0;
			return _repository.GetListBySortColumn<TResult>(startRowIndexId, maxNumberRows, PrimaryColumn, SortColumnDbType,SortColumn, StrColumn, Sorts, Filter, TableName,out Total);
		}
		
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
		public virtual DataTable GetDataTable(int startRowIndexId, int maxNumberRows, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total)
		{
			Total=0;
			return _repository.GetDataTable(startRowIndexId,maxNumberRows,SortColumn,StrColumn,Sorts,Filter,TableName,out Total);
		}
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
		public virtual DataTable GetDataTableBySortColumn(int startRowIndexId, int maxNumberRows, string PrimaryColumn, string SortColumnDbType, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total)
		{
			Total=0;
			return _repository.GetDataTableBySortColumn(startRowIndexId,maxNumberRows,PrimaryColumn,SortColumnDbType,SortColumn,StrColumn,Sorts,Filter,TableName,out Total);
		}
		#endregion
		
		#region 直接执行SQL语句
		/// <summary>
		/// 执行SQL语句，返回受影响的行数
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		public virtual int ExeSQL(string sql, params DbParameter[] para)
		{
			return _repository.ExeSQL(sql, para);
		}
		/// <summary>
		/// 执行SQL语句，返回受影响的行数
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		public virtual async Task<int> ExeSQLAsync(string sql, params DbParameter[] para)
		{
			return await _repository.ExeSQLAsync(sql, para);
		}
		
		/// <summary>
		/// 执行SQL语句，返回受影响的行数
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="paraName"></param>
		/// <param name="paraValue"></param>
		/// <returns></returns>
		public virtual int ExeSQL(string sql, string[] paraName, object[] paraValue)
		{
			return _repository.ExeSQL(sql, paraName,paraValue);
		}
		/// <summary>
		/// 执行SQL语句，返回受影响的行数
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="paraName"></param>
		/// <param name="paraValue"></param>
		/// <returns></returns>
		public virtual async Task<int> ExeSQLAsync(string sql, string[] paraName, object[] paraValue)
		{
			return await _repository.ExeSQLAsync(sql, paraName,paraValue);
		}
		
		/// <summary>
		/// 执行SQL语句，返回受影响的行数
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		public virtual int ExeSQL(string sql, Dictionary<string, object> dict)
		{
			return _repository.ExeSQL(sql, dict);
		}
		/// <summary>
		/// 执行SQL语句，返回受影响的行数
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		public virtual async Task<int> ExeSQLAsync(string sql, Dictionary<string, object> dict)
		{
			return await _repository.ExeSQLAsync(sql, dict);
		}
		#endregion
		
		#region 执行SQL，返回结果
		/// <summary>
		/// 执行SQL，返回结果。
		/// 例：var s = testDal.GetBySQL《string》("select name from tablename",m=>m.Name);
		/// var s = testDal.GetBySQL《StoreM》("select * from tablename where name=@name",m=>m,new SqlParameter("name", "1"));
		/// var s = testDal.GetBySQL《dynamic》("select name,Code from tablename",m=>new { m.Name,m.Code });
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="scalar"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		public virtual TResult GetBySQL<TResult>(string sql, Expression<Func<ModelsEntity, TResult>> scalar, params DbParameter[] para)
		{
			return _repository.GetBySQL<TResult>(sql, scalar,para);
		}
		/// <summary>
		/// 执行SQL，返回结果。
		/// 例：var s = testDal.GetBySQL《string》("select name from tablename",m=>m.Name);
		/// var s = testDal.GetBySQL《StoreM》("select * from tablename where name=@name",m=>m,new SqlParameter("name", "1"));
		/// var s = testDal.GetBySQL《dynamic》("select name,Code from tablename",m=>new { m.Name,m.Code });
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="scalar"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		public virtual async Task<TResult> GetBySQLAsync<TResult>(string sql, Expression<Func<ModelsEntity, TResult>> scalar, params DbParameter[] para)
		{
			return await _repository.GetBySQLAsync<TResult>(sql, scalar,para);
		}
		#endregion
		
	}
}