using JX.Core;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Data.SqlClient;
using System.Data;
using JX.Infrastructure.Data;

namespace JX.EF
{
	/// <summary>
	/// 仓储实现类
	/// </summary>
	public abstract class Repository<T> : IRepository<T> where T : class,new()
	{
		#region 数据上下文

		/// <summary>
		/// 数据上下文
		/// </summary>
		private ApplicationDbContext _Context;

		/// <summary>
		/// 构造器注入ApplicationDbContext
		/// </summary>
		/// <param name="Context"></param>
		public Repository(ApplicationDbContext Context)
		{
			_Context = Context;
			_Context.Database.SetCommandTimeout(90);
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
		public virtual TResult GetScalar<TResult, TOrderBy>(Expression<Func<T, TResult>> scalar, Expression<Func<T, bool>> predicate = null, Expression<Func<T, TOrderBy>> orderby = null, bool IsAsc = true)
		{
			IQueryable<T> query = _Context.Set<T>();
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			if (orderby != null)
			{
				query = IsAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
			}
			return query.AsNoTracking().Select(scalar).FirstOrDefault();
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
		public virtual async Task<TResult> GetScalarAsync<TResult, TOrderBy>(Expression<Func<T, TResult>> scalar, Expression<Func<T, bool>> predicate = null, Expression<Func<T, TOrderBy>> orderby = null, bool IsAsc = true)
		{
			IQueryable<T> query = _Context.Set<T>();
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			if (orderby != null)
			{
				query = IsAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
			}
			return await query.AsNoTracking().Select(scalar).FirstOrDefaultAsync();
		}

		/// <summary>
		/// 得到最大值
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="max">最大值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual TResult GetMax<TResult>(Expression<Func<T, TResult>> max, Expression<Func<T, bool>> predicate = null)
		{
			IQueryable<T> query = _Context.Set<T>();
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			try
			{
				return query.AsNoTracking().Max(max);
			}
			catch
			{
				return default(TResult);
			}
		}
		/// <summary>
		/// 得到最大值
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="max">最大值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual async Task<TResult> GetMaxAsync<TResult>(Expression<Func<T, TResult>> max, Expression<Func<T, bool>> predicate = null)
		{
			IQueryable<T> query = _Context.Set<T>();
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			try
			{
				return await query.AsNoTracking().MaxAsync(max);
			}
			catch
			{
				return default(TResult);
			}			
		}
		
		/// <summary>
		/// 得到最小值
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="min">最小值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual TResult GetMin<TResult>(Expression<Func<T, TResult>> min, Expression<Func<T, bool>> predicate = null)
		{
			IQueryable<T> query = _Context.Set<T>();
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			try
			{
				return query.AsNoTracking().Min(min);
			}
			catch
			{
				return default(TResult);
			}
			
		}
		/// <summary>
		/// 得到最小值
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="min">最小值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual async Task<TResult> GetMinAsync<TResult>(Expression<Func<T, TResult>> min, Expression<Func<T, bool>> predicate = null)
		{
			IQueryable<T> query = _Context.Set<T>();
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			try
			{
				return await query.AsNoTracking().MinAsync(min);
			}
			catch
			{
				return default(TResult);
			}
			
		}
		
		/// <summary>
		/// 得到平均值
		/// </summary>
		/// <param name="avg">平均值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual decimal GetAvg(Expression<Func<T, decimal>> avg, Expression<Func<T, bool>> predicate = null)
		{
			IQueryable<T> query = _Context.Set<T>();
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			try
			{
				return query.AsNoTracking().Average(avg);
			}
			catch
			{
				return 0;
			}
			
		}
		/// <summary>
		/// 得到平均值
		/// </summary>
		/// <param name="avg">平均值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual async Task<decimal> GetAvgAsync(Expression<Func<T, decimal>> avg, Expression<Func<T, bool>> predicate = null)
		{
			IQueryable<T> query = _Context.Set<T>();
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			try
			{
				return await query.AsNoTracking().AverageAsync(avg);
			}
			catch
			{
				return 0;
			}
			
		}
		
		/// <summary>
		/// 得到求和值
		/// </summary>
		/// <param name="sum">求和值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual decimal GetSum(Expression<Func<T, decimal>> sum, Expression<Func<T, bool>> predicate = null)
		{
			IQueryable<T> query = _Context.Set<T>();
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			try
			{
				return query.AsNoTracking().Sum(sum);
			}
			catch
			{
				return 0;
			}
			
		}
		/// <summary>
		/// 得到求和值
		/// </summary>
		/// <param name="sum">求和值字段，Lamda表达式（p=>p.Id）</param>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual async Task<decimal> GetSumAsync(Expression<Func<T, decimal>> sum, Expression<Func<T, bool>> predicate = null)
		{
			IQueryable<T> query = _Context.Set<T>();
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			try
			{
				return await query.AsNoTracking().SumAsync(sum);
			}
			catch
			{
				return 0;
			}
			
		}
		
		/// <summary>
		/// 得到总数值
		/// </summary>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual int GetCount(Expression<Func<T, bool>> predicate = null)
		{
			IQueryable<T> query = _Context.Set<T>();
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			try
			{
				return query.AsNoTracking().Count();
			}
			catch
			{
				return 0;
			}
			
		}
		/// <summary>
		/// 得到总数值
		/// </summary>
		/// <param name="predicate">查询条件，Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual async Task<int> GetCountAsync(Expression<Func<T, bool>> predicate = null)
		{
			IQueryable<T> query = _Context.Set<T>();
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			try
			{
				return await query.AsNoTracking().CountAsync();
			}
			catch
			{
				return 0;
			}
			
		}
		#endregion

		#region 验证是否存在
		/// <summary>
		/// 验证当前条件是否存在相同项
		/// </summary>
		public virtual bool IsExist(Expression<Func<T, bool>> predicate)
		{
			var entry = _Context.Set<T>().Where(predicate);
			return (entry.Any());
		}
		/// <summary>
		/// 验证当前条件是否存在相同项（异步方式）
		/// </summary>
		public virtual async Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate)
		{
			var entry = _Context.Set<T>().Where(predicate);
			return await entry.AnyAsync();
		}
		#endregion

		#region 添加
		/// <summary>
		/// 增加一条记录
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual bool Add(T entity, bool IsCommit = true)
		{
			_Context.Set<T>().Add(entity);
			if (IsCommit)
				return _Context.SaveChanges() > 0;
			else
				return false;
		}
		/// <summary>
		/// 增加一条记录(异步方式)
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual async Task<bool> AddAsync(T entity, bool IsCommit = true)
		{
			_Context.Set<T>().Add(entity);
			if (IsCommit)
				return await _Context.SaveChangesAsync() > 0;
			else
				return false;
		}

		/// <summary>
		/// 增加多条记录，同一模型
		/// </summary>
		/// <param name="entityList">实体模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual bool AddList(IList<T> entityList, bool IsCommit = true)
		{
			if (entityList == null || entityList.Count == 0) return false;

			entityList.ToList().ForEach(item =>
			{
				_Context.Set<T>().Add(item);
			});

			if (IsCommit)
				return _Context.SaveChanges() > 0;
			else
				return false;
		}
		/// <summary>
		/// 增加多条记录，同一模型（异步方式）
		/// </summary>
		/// <param name="entityList">实体模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual async Task<bool> AddListAsync(IList<T> entityList, bool IsCommit = true)
		{
			if (entityList == null || entityList.Count == 0) return false;

			entityList.ToList().ForEach(item =>
			{
				_Context.Set<T>().Add(item);
			});

			if (IsCommit)
				return await _Context.SaveChangesAsync() > 0;
			else
				return false;
		}

		/// <summary>
		/// 增加多条记录，独立模型
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="entityList">实体模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual bool AddList<TEntity>(IList<TEntity> entityList, bool IsCommit = true) where TEntity : class
		{
			if (entityList == null || entityList.Count == 0) return false;
			var tmp = _Context.ChangeTracker.Entries<T>().ToList();
			foreach (var x in tmp)
			{
				var properties = typeof(T).GetTypeInfo().GetProperties();
				foreach (var y in properties)
				{
					var entry = x.Property(y.Name);
					entry.CurrentValue = entry.OriginalValue;
					entry.IsModified = false;
					y.SetValue(x.Entity, entry.OriginalValue);
				}
				x.State = EntityState.Unchanged;
			}
			entityList.ToList().ForEach(item =>
			{
				_Context.Set<TEntity>().Add(item);
			});
			if (IsCommit)
				return _Context.SaveChanges() > 0;
			else
				return false;
		}
		/// <summary>
		/// 增加多条记录，独立模型（异步方式）
		/// </summary>
		/// <typeparam name="TEntity"></typeparam>
		/// <param name="entityList">实体模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual async Task<bool> AddListAsync<TEntity>(IList<TEntity> entityList, bool IsCommit = true) where TEntity : class
		{
			if (entityList == null || entityList.Count == 0) return false;
			var tmp = _Context.ChangeTracker.Entries<T>().ToList();
			foreach (var x in tmp)
			{
				var properties = typeof(T).GetTypeInfo().GetProperties();
				foreach (var y in properties)
				{
					var entry = x.Property(y.Name);
					entry.CurrentValue = entry.OriginalValue;
					entry.IsModified = false;
					y.SetValue(x.Entity, entry.OriginalValue);
				}
				x.State = EntityState.Unchanged;
			}
			entityList.ToList().ForEach(item =>
			{
				_Context.Set<TEntity>().Add(item);
			});
			if (IsCommit)
				return await _Context.SaveChangesAsync() > 0;
			else
				return false;
		}

		/// <summary>
		/// 增加或更新一条记录
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsSave">是否增加</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual bool AddOrUpdate(T entity, bool IsSave, bool IsCommit = true)
		{
			return IsSave ? Add(entity, IsCommit) : Update(entity, IsCommit);
		}
		/// <summary>
		/// 增加或更新一条记录（异步方式）
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsSave">是否增加</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual async Task<bool> AddOrUpdateAsync(T entity, bool IsSave, bool IsCommit = true)
		{
			return IsSave ? await AddAsync(entity, IsCommit) : await UpdateAsync(entity, IsCommit);
		}
		#endregion

		#region 删除
		/// <summary>
		/// 删除一条记录
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual bool Delete(T entity, bool IsCommit = true)
		{
			if (entity == null) return false;
			_Context.Set<T>().Attach(entity);
			_Context.Set<T>().Remove(entity);

			if (IsCommit)
				return _Context.SaveChanges() > 0;
			else
				return false;
		}
		/// <summary>
		/// 删除一条记录（异步方式）
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual async Task<bool> DeleteAsync(T entity, bool IsCommit = true)
		{
			if (entity == null) return false;
			_Context.Set<T>().Attach(entity);
			_Context.Set<T>().Remove(entity);
			if (IsCommit)
				return await _Context.SaveChangesAsync() > 0;
			else
				return false;
		}

		/// <summary>
		/// 删除多条记录，同一模型
		/// </summary>
		/// <param name="entityList">实体模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual bool DeleteList(IList<T> entityList, bool IsCommit = true)
		{
			if (entityList == null || entityList.Count == 0) return false;

			entityList.ToList().ForEach(item =>
			{
				_Context.Set<T>().Attach(item);
				_Context.Set<T>().Remove(item);
			});

			if (IsCommit)
				return _Context.SaveChanges() > 0;
			else
				return false;
		}
		/// <summary>
		/// 删除多条记录，同一模型（异步方式）
		/// </summary>
		/// <param name="entityList">实体模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual async Task<bool> DeleteListAsync(IList<T> entityList, bool IsCommit = true)
		{
			if (entityList == null || entityList.Count == 0) return false;

			entityList.ToList().ForEach(item =>
			{
				_Context.Set<T>().Attach(item);
				_Context.Set<T>().Remove(item);
			});

			if (IsCommit)
				return await _Context.SaveChangesAsync() > 0;
			else
				return false;
		}

		/// <summary>
		/// 删除多条记录，独立模型
		/// </summary>
		/// <typeparam name="TEntity">实体模型集合</typeparam>
		/// <param name="entityList">实体模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual bool DeleteList<TEntity>(IList<TEntity> entityList, bool IsCommit = true) where TEntity : class
		{
			if (entityList == null || entityList.Count == 0) return false;

			entityList.ToList().ForEach(item =>
			{
				_Context.Set<TEntity>().Attach(item);
				_Context.Set<TEntity>().Remove(item);
			});

			if (IsCommit)
				return _Context.SaveChanges() > 0;
			else
				return false;
		}
		/// <summary>
		/// 删除多条记录，独立模型（异步方式）
		/// </summary>
		/// <typeparam name="TEntity">实体模型集合</typeparam>
		/// <param name="entityList">实体模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual async Task<bool> DeleteListAsync<TEntity>(IList<TEntity> entityList, bool IsCommit = true) where TEntity : class
		{
			if (entityList == null || entityList.Count == 0) return false;

			entityList.ToList().ForEach(item =>
			{
				_Context.Set<TEntity>().Attach(item);
				_Context.Set<TEntity>().Remove(item);
			});

			if (IsCommit)
				return await _Context.SaveChangesAsync() > 0;
			else
				return false;
		}

		/// <summary>
		/// 通过Lamda表达式，删除一条或多条记录
		/// </summary>
		/// <param name="predicate"></param>
		/// <param name="IsCommit"></param>
		/// <returns></returns>
		public virtual bool Delete(Expression<Func<T, bool>> predicate, bool IsCommit = true)
		{
			IQueryable<T> entry = (predicate == null) ? _Context.Set<T>().AsQueryable() : _Context.Set<T>().Where(predicate);
			List<T> list = entry.AsNoTracking().ToList();

			if (list != null && list.Count == 0) return false;
			list.ForEach(item => {
				_Context.Set<T>().Attach(item);
				_Context.Set<T>().Remove(item);
			});

			if (IsCommit)
				return _Context.SaveChanges() > 0;
			else
				return false;
		}
		/// <summary>
		/// 通过Lamda表达式，删除一条或多条记录（异步方式）
		/// </summary>
		/// <param name="predicate"></param>
		/// <param name="IsCommit"></param>
		/// <returns></returns>
		public virtual async Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate, bool IsCommit = true)
		{
			IQueryable<T> entry = (predicate == null) ? _Context.Set<T>().AsQueryable() : _Context.Set<T>().Where(predicate);
			List<T> list = entry.AsNoTracking().ToList();

			if (list != null && list.Count == 0) return false;
			list.ForEach(item => {
				_Context.Set<T>().Attach(item);
				_Context.Set<T>().Remove(item);
			});

			if (IsCommit)
				return await _Context.SaveChangesAsync() > 0;
			else
				return false;
		}

		/// <summary>
		/// 删除一条或多条记录
		/// </summary>
		/// <param name="strWhere">参数化删除条件，为空代表全部删除(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual bool Delete(string strWhere, Dictionary<string, object> dict = null)
		{
			string strSQL = "delete from "+ GetTableName() + " where 1=1 "+ strWhere;
			return ExeSQL(strSQL, dict) > 0;
		}
		/// <summary>
		/// 删除一条或多条记录（异步方式）
		/// </summary>
		/// <param name="strWhere">参数化删除条件，为空代表全部删除(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual async Task<bool> DeleteAsync(string strWhere, Dictionary<string, object> dict = null)
		{
			string strSQL = "delete from " + GetTableName() + " where 1=1 " + strWhere;
			return await ExeSQLAsync(strSQL, dict) > 0;
		}

		/// <summary>
		/// 根据SQL删除一条或多条记录
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		public virtual bool Delete(string sql, params IDataParameter[] para)
		{
			return ExeSQL(sql, para) > 0;
		}
		/// <summary>
		/// 根据SQL删除一条或多条记录（异步方式）
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		public virtual async Task<bool> DeleteAsync(string sql, params IDataParameter[] para)
		{
			return await ExeSQLAsync(sql, para) > 0;
		}
		#endregion

		#region 修改
		/// <summary>
		/// 更新一条记录
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual bool Update(T entity, bool IsCommit = true)
		{
			_Context.Set<T>().Attach(entity);
			_Context.Entry<T>(entity).State = EntityState.Modified;
			if (IsCommit)
				return _Context.SaveChanges() > 0;
			else
				return false;
		}
		/// <summary>
		/// 更新一条记录（异步方式）
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual async Task<bool> UpdateAsync(T entity, bool IsCommit = true)
		{
			_Context.Set<T>().Attach(entity);
			_Context.Entry<T>(entity).State = EntityState.Modified;
			if (IsCommit)
				return await _Context.SaveChangesAsync() > 0;
			else
				return false;
		}

		/// <summary>
		/// 更新多条记录，同一模型
		/// </summary>
		/// <param name="entityList">实体模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual bool UpdateList(IList<T> entityList, bool IsCommit = true)
		{
			if (entityList == null || entityList.Count == 0) return false;

			entityList.ToList().ForEach(item =>
			{
				_Context.Set<T>().Attach(item);
				_Context.Entry<T>(item).State = EntityState.Modified;
			});

			if (IsCommit)
				return _Context.SaveChanges() > 0;
			else
				return false;
		}
		/// <summary>
		/// 更新多条记录，同一模型（异步方式）
		/// </summary>
		/// <param name="entityList">实体模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual async Task<bool> UpdateListAsync(IList<T> entityList, bool IsCommit = true)
		{
			if (entityList == null || entityList.Count == 0) return false;

			entityList.ToList().ForEach(item =>
			{
				_Context.Set<T>().Attach(item);
				_Context.Entry<T>(item).State = EntityState.Modified;
			});

			if (IsCommit)
				return await _Context.SaveChangesAsync() > 0;
			else
				return false;
		}

		/// <summary>
		/// 更新多条记录，独立模型
		/// </summary>
		/// <typeparam name="TEntity">实体模型集合</typeparam>
		/// <param name="entityList">实体模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual bool UpdateList<TEntity>(IList<TEntity> entityList, bool IsCommit = true) where TEntity : class
		{
			if (entityList == null || entityList.Count == 0) return false;

			entityList.ToList().ForEach(item =>
			{
				_Context.Set<TEntity>().Attach(item);
				_Context.Entry<TEntity>(item).State = EntityState.Modified;
			});

			if (IsCommit)
				return _Context.SaveChanges() > 0;
			else
				return false;
		}
		/// <summary>
		/// 更新多条记录，独立模型（异步方式）
		/// </summary>
		/// <typeparam name="TEntity">实体模型集合</typeparam>
		/// <param name="entityList">实体模型集合</param>
		/// <param name="IsCommit">是否提交（默认提交）</param>
		/// <returns></returns>
		public virtual async Task<bool> UpdateListAsync<TEntity>(IList<TEntity> entityList, bool IsCommit = true) where TEntity : class
		{
			if (entityList == null || entityList.Count == 0) return false;

			entityList.ToList().ForEach(item =>
			{
				_Context.Set<TEntity>().Attach(item);
				_Context.Entry<TEntity>(item).State = EntityState.Modified;
			});

			if (IsCommit)
				return await _Context.SaveChangesAsync() > 0;
			else
				return false;
		}

		/// <summary>
		/// 根据SQL修改一条或多条记录
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		public virtual bool Update(string sql, params IDataParameter[] para)
		{
			return ExeSQL(sql, para) > 0;
		}
		/// <summary>
		/// 根据SQL修改一条或多条记录（异步方式）
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		public virtual async Task<bool> UpdateAsync(string sql, params IDataParameter[] para)
		{
			return await ExeSQLAsync(sql, para) > 0;
		}
		#endregion

		#region 得到实体
		/// <summary>
		/// 通过Lamda表达式获取实体
		/// </summary>
		/// <param name="predicate">Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual T Get(Expression<Func<T, bool>> predicate)
		{
			return _Context.Set<T>().AsNoTracking().FirstOrDefault(predicate);
		}
		/// <summary>
		/// 通过Lamda表达式获取实体（异步方式）
		/// </summary>
		/// <param name="predicate">Lamda表达式（p=>p.Id==Id）</param>
		/// <returns></returns>
		public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
		{
			return await Task.Run(() => _Context.Set<T>().AsNoTracking().FirstOrDefault(predicate));
		}
		#endregion

		#region 得到实体列表
		/// <summary>
		/// Lamda返回IQueryable集合，延时加载数据
		/// </summary>
		/// <param name="predicate">Lamda表达式（p=>p.Id==Id）</param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		public virtual IQueryable<T> LoadAll(Expression<Func<T, bool>> predicate, params SortModelField[] orderByExpression)
		{
			IQueryable<T> query = _Context.Set<T>();
			query = GetQueryableBySortModelField<T>(orderByExpression);
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			return query.AsNoTracking<T>();
		}
		/// <summary>
		/// 返回IQueryable集合，延时加载数据（异步方式）
		/// </summary>
		/// <param name="predicate"></param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		public virtual async Task<IQueryable<T>> LoadAllAsync(Expression<Func<T, bool>> predicate, params SortModelField[] orderByExpression)
		{
			IQueryable<T> query = _Context.Set<T>();
			query = GetQueryableBySortModelField<T>(orderByExpression);
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			return await Task.Run(() => query.AsNoTracking<T>());
		}

		/// <summary>
		/// 返回集合,不采用延时加载
		/// </summary>
		/// <param name="predicate"></param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		public virtual List<T> LoadListAll(Expression<Func<T, bool>> predicate, params SortModelField[] orderByExpression)
		{
			IQueryable<T> query = _Context.Set<T>();
			query = GetQueryableBySortModelField<T>(orderByExpression);
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			return query.ToList();
		}
		/// <summary>
		/// 返回集合,不采用延时加载（异步方式）
		/// </summary>
		/// <param name="predicate"></param>
		/// <param name="orderByExpression">多字段排序</param>
		/// <returns></returns>
		public virtual async Task<List<T>> LoadListAllAsync(Expression<Func<T, bool>> predicate, params SortModelField[] orderByExpression)
		{
			IQueryable<T> query = _Context.Set<T>();
			query = GetQueryableBySortModelField<T>(orderByExpression);
			if (predicate != null)
			{
				query = query.Where(predicate);
			}
			return await Task.Run(() => query.ToList());
		}

		/// <summary>
		/// T-Sql方式：返回IQueryable《T》集合
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="para">Parameters参数</param>
		/// <returns></returns>
		public virtual IQueryable<T> LoadAllBySql(string sql, params IDataParameter[] para)
		{
			var parameter = CheckParamDBNull(para);
			return _Context.Set<T>().AsNoTracking().FromSql(sql, parameter);
		}
		/// <summary>
		/// T-Sql方式：返回IQueryable《T》集合（异步方式）
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="para">Parameters参数</param>
		/// <returns></returns>
		public virtual async Task<IQueryable<T>> LoadAllBySqlAsync(string sql, params IDataParameter[] para)
		{
			var parameter = CheckParamDBNull(para);
			return await Task.Run(() => _Context.Set<T>().AsNoTracking().FromSql(sql, parameter));
		}

		/// <summary>
		/// T-Sql方式：返回List《T》集合
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="para">Parameters参数</param>
		/// <returns></returns>
		public virtual List<T> LoadListAllBySql(string sql, params IDataParameter[] para)
		{
			var parameter = CheckParamDBNull(para);
			return _Context.Set<T>().AsNoTracking().FromSql(sql, parameter).Cast<T>().ToList();
		}
		/// <summary>
		/// T-Sql方式：返回List《T》集合（异步方式）
		/// </summary>
		/// <param name="sql">SQL语句</param>
		/// <param name="para">Parameters参数</param>
		/// <returns></returns>
		public virtual async Task<List<T>> LoadListAllBySqlAsync(string sql, params IDataParameter[] para)
		{
			var parameter = CheckParamDBNull(para);
			return await Task.Run(() => _Context.Set<T>().AsNoTracking().FromSql(sql, parameter).Cast<T>().ToList());
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
			IQueryable<TEntity> query = _Context.Set<TEntity>();
			if (where != null)
			{
				query = query.Where(where);
			}

			if (orderby != null)
			{
				query = IsAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
			}
			if (selector == null)
			{
				return query.Cast<TResult>().AsNoTracking().ToList();
			}
			return query.Select(selector).AsNoTracking().ToList();
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
			IQueryable<TEntity> query = _Context.Set<TEntity>();
			query = GetQueryableBySortModelField<TEntity>(orderByExpression);
			if (where != null)
			{
				query = query.Where(where);
			}

			if (selector == null)
			{
				return query.Cast<TResult>().AsNoTracking().ToList();
			}
			return query.Select(selector).AsNoTracking().ToList();
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
			IQueryable<TEntity> query = _Context.Set<TEntity>();
			if (where != null)
			{
				query = query.Where(where);
			}

			if (orderby != null)
			{
				query = IsAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
			}
			if (selector == null)
			{
				return await Task.Run(() => query.Cast<TResult>().AsNoTracking().ToList());
			}
			return await Task.Run(() => query.Select(selector).AsNoTracking().ToList());
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
			IQueryable<TEntity> query = _Context.Set<TEntity>();
			query = GetQueryableBySortModelField<TEntity>(orderByExpression);
			if (where != null)
			{
				query = query.Where(where);
			}

			if (selector == null)
			{
				return await Task.Run(() => query.Cast<TResult>().AsNoTracking().ToList());
			}
			return await Task.Run(() => query.Select(selector).AsNoTracking().ToList());
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
			IQueryable<TEntity> query = _Context.Set<TEntity>();
			if (where != null)
			{
				query = query.Where(where);
			}
			if (orderby != null)
			{
				query = IsAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
			}
			if (selector == null)
			{
				return query.AsNoTracking().ToList<object>();
			}
			return selector(query);
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
			IQueryable<TEntity> query = _Context.Set<TEntity>();
			query = GetQueryableBySortModelField<TEntity>(orderByExpression);
			if (where != null)
			{
				query = query.Where(where);
			}
			if (selector == null)
			{
				return query.AsNoTracking().ToList<object>();
			}
			return selector(query);
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
			IQueryable<TEntity> query = _Context.Set<TEntity>();
			if (where != null)
			{
				query = query.Where(where);
			}

			if (orderby != null)
			{
				query = IsAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
			}
			if (selector == null)
			{
				return await Task.Run(() => query.AsNoTracking().ToList<object>());
			}
			return await Task.Run(() => selector(query));
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
			IQueryable<TEntity> query = _Context.Set<TEntity>();
			query = GetQueryableBySortModelField<TEntity>(orderByExpression);
			if (where != null)
			{
				query = query.Where(where);
			}
			if (selector == null)
			{
				return await Task.Run(() => query.AsNoTracking().ToList<object>());
			}
			return await Task.Run(() => selector(query));
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
			IQueryable<TEntity> query = _Context.Set<TEntity>();
			if (where != null)
			{
				query = query.Where(where);
			}

			if (orderby != null)
			{
				query = IsAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
			}
			if (selector == null)
			{
				return query.Cast<dynamic>().AsNoTracking().ToList();
			}
			return query.Select(selector).AsNoTracking().ToList();
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
			IQueryable<TEntity> query = _Context.Set<TEntity>();
			query = GetQueryableBySortModelField<TEntity>(orderByExpression);
			if (where != null)
			{
				query = query.Where(where);
			}

			if (selector == null)
			{
				return query.Cast<dynamic>().AsNoTracking().ToList();
			}
			return query.Select(selector).AsNoTracking().ToList();
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
			IQueryable<TEntity> query = _Context.Set<TEntity>();
			if (where != null)
			{
				query = query.Where(where);
			}

			if (orderby != null)
			{
				query = IsAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
			}
			if (selector == null)
			{
				return await Task.Run(() => query.Cast<dynamic>().AsNoTracking().ToList());
			}
			return await Task.Run(() => query.Select(selector).AsNoTracking().ToList());
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
			IQueryable<TEntity> query = _Context.Set<TEntity>();
			query = GetQueryableBySortModelField<TEntity>(orderByExpression);
			if (where != null)
			{
				query = query.Where(where);
			}

			if (selector == null)
			{
				return await Task.Run(() => query.Cast<dynamic>().AsNoTracking().ToList());
			}
			return await Task.Run(() => query.Select(selector).AsNoTracking().ToList());
		}
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
		public virtual IList<TResult> QueryEntity<TEntity, TOrderBy, TResult>
			(Expression<Func<TEntity, bool>> where,
			Expression<Func<TEntity, TOrderBy>> orderby,
			Expression<Func<TEntity, TResult>> selector,
			bool IsAsc, int pageIndex, int pageSize, out int Total)
			where TEntity : class
			where TResult : class
		{
			IQueryable<TEntity> query = _Context.Set<TEntity>();
			if (where != null)
			{
				query = query.Where(where);
			}
			Total = query.AsNoTracking().Count();

			if (orderby != null)
			{
				query = IsAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
			}

			if (selector == null)
			{
				return query.Cast<TResult>().Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList();
			}
			return query.Select(selector).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList();
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
			IQueryable<TEntity> query = _Context.Set<TEntity>();
			query = GetQueryableBySortModelField<TEntity>(orderByExpression);
			if (where != null)
			{
				query = query.Where(where);
			}
			Total = query.AsNoTracking().Count();


			if (selector == null)
			{
				return query.Cast<TResult>().Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList();
			}
			return query.Select(selector).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList();
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
			IQueryable<TEntity> query = _Context.Set<TEntity>();
			if (where != null)
			{
				query = query.Where(where);
			}
			Total = query.AsNoTracking().Count();

			if (orderby != null)
			{
				query = IsAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
			}

			if (selector == null)
			{
				return query.Cast<dynamic>().Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList();
			}
			return query.Select(selector).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList();
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
			IQueryable<TEntity> query = _Context.Set<TEntity>();
			query = GetQueryableBySortModelField<TEntity>(orderByExpression);
			if (where != null)
			{
				query = query.Where(where);
			}
			Total = query.AsNoTracking().Count();


			if (selector == null)
			{
				return query.Cast<dynamic>().Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList();
			}
			return query.Select(selector).Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList();
		}

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
		public virtual IList<object> QueryObject<TEntity, TOrderBy>
			(Expression<Func<TEntity, bool>> where,
			Expression<Func<TEntity, TOrderBy>> orderby,
			Func<IQueryable<TEntity>,List<object>> selector,
			bool IsAsc, int pageIndex, int pageSize, out int Total)
			where TEntity : class
		{
			IQueryable<TEntity> query = _Context.Set<TEntity>();
			if (where != null)
			{
				query = query.Where(where);
			}
			Total = query.AsNoTracking().Count();
			if (orderby != null)
			{
				query = IsAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
			}
			if (selector == null)
			{
				return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList<object>();
			}
			return selector(query).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
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
			IQueryable<TEntity> query = _Context.Set<TEntity>();
			query = GetQueryableBySortModelField<TEntity>(orderByExpression);
			if (where != null)
			{
				query = query.Where(where);
			}
			Total = query.AsNoTracking().Count();
			if (selector == null)
			{
				return query.Skip((pageIndex - 1) * pageSize).Take(pageSize).AsNoTracking().ToList<object>();
			}
			return selector(query).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
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
		public virtual IList<T> GetList(int startRowIndexId, int maxNumberRows, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total)
		{
			Total = 0;
			return GetList<T>(startRowIndexId, maxNumberRows, SortColumn, StrColumn, Sorts, Filter, TableName, out Total);
		}
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
		public virtual IList<TResult> GetList<TResult>(int startRowIndexId, int maxNumberRows, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total) where TResult : new()
		{
			Total = 0;
			DataTable dt = GetDataTable(startRowIndexId, maxNumberRows, SortColumn, StrColumn, Sorts, Filter, TableName, out Total);
			var propts = typeof(TResult).GetProperties();
			var rtnList = new List<TResult>();
			TResult model;
			object val;
			foreach (DataRow row in dt.Rows)
			{
				model = new TResult();
				foreach (var l in propts)
				{
					try
					{
						val = row[l.Name];
					}
					catch
					{
						continue;
					}
					if (val == DBNull.Value)
					{
						l.SetValue(model, null);
					}
					else
					{
						l.SetValue(model, val);
					}
				}
				rtnList.Add(model);
			}
			return rtnList;
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
		public virtual IList<T> GetListBySortColumn(int startRowIndexId, int maxNumberRows, string PrimaryColumn, string SortColumnDbType, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total)
		{
			Total = 0;
			return GetListBySortColumn<T>(startRowIndexId, maxNumberRows, PrimaryColumn, SortColumnDbType, SortColumn, StrColumn, Sorts, Filter, TableName, out Total);
		}
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
		public virtual IList<TResult> GetListBySortColumn<TResult>(int startRowIndexId, int maxNumberRows, string PrimaryColumn, string SortColumnDbType, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total) where TResult : new()
		{
			Total = 0;
			DataTable dt = GetDataTableBySortColumn(startRowIndexId, maxNumberRows, PrimaryColumn, SortColumnDbType, SortColumn, StrColumn, Sorts, Filter, TableName, out Total);
			var propts = typeof(TResult).GetProperties();
			var rtnList = new List<TResult>();
			TResult model;
			object val;
			foreach (DataRow row in dt.Rows)
			{
				model = new TResult();
				foreach (var l in propts)
				{
					try
					{
						val = row[l.Name];
					}
					catch
					{
						continue;
					}
					if (val == DBNull.Value)
					{
						l.SetValue(model, null);
					}
					else
					{
						l.SetValue(model, val);
					}
				}
				rtnList.Add(model);
			}
			return rtnList;
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
			Total = 0;
			if (string.IsNullOrEmpty(SortColumn))
			{
				SortColumn = "ID";
			}
			if (string.IsNullOrEmpty(StrColumn))
			{
				StrColumn = " * ";
			}
			if (string.IsNullOrEmpty(Sorts))
			{
				Sorts = "DESC";
			}
			if (string.IsNullOrEmpty(TableName))
			{
				TableName = GetTableName(TableName);
			}
			SqlParameter parmStartRows = new SqlParameter("StartRows", startRowIndexId);
			SqlParameter parmPageSize = new SqlParameter("PageSize", maxNumberRows);
			SqlParameter parmSortColumn = new SqlParameter("SortColumn", SortColumn);
			SqlParameter parmStrColumn = new SqlParameter("StrColumn", StrColumn);
			SqlParameter parmSorts = new SqlParameter("Sorts", Sorts);
			SqlParameter parmTableName = new SqlParameter("TableName", TableName);
			SqlParameter parmFilter = new SqlParameter("Filter", Filter);
			SqlParameter parmTotal = new SqlParameter("Total", 0);
			parmTotal.Direction = ParameterDirection.Output;
			IDataParameter[] parameterArray = new IDataParameter[8];
			parameterArray[0] = parmStartRows;
			parameterArray[1] = parmPageSize;
			parameterArray[2] = parmSortColumn;
			parameterArray[3] = parmStrColumn;
			parameterArray[4] = parmSorts;
			parameterArray[5] = parmTableName;
			parameterArray[6] = parmFilter;
			parameterArray[7] = parmTotal;
			DataTable dt = CreateDataTable("Common_GetList",true, parameterArray);
			string strWhere = (!string.IsNullOrEmpty(Filter)) ? " where " + Filter : "";
			string strSQLCount = "select count(*) from "+ TableName + " "+ strWhere;
			var resultCount = SqlQueryOne<int>(strSQLCount);
			Total = resultCount[0];//Convert.ToInt32(parmTotal.Value);
			return dt;
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
			Total = 0;
			if (string.IsNullOrEmpty(PrimaryColumn))
			{
				PrimaryColumn = "ID";
			}
			if (string.IsNullOrEmpty(SortColumnDbType))
			{
				SortColumnDbType = "int";
			}
			if (string.IsNullOrEmpty(SortColumn))
			{
				SortColumn = "ID";
			}
			if (string.IsNullOrEmpty(StrColumn))
			{
				StrColumn = " * ";
			}
			if (string.IsNullOrEmpty(Sorts))
			{
				Sorts = "DESC";
			}
			if (string.IsNullOrEmpty(TableName))
			{
				TableName = GetTableName(TableName);
			}
			SqlParameter parmStartRows = new SqlParameter("StartRows", startRowIndexId);
			SqlParameter parmPageSize = new SqlParameter("PageSize", maxNumberRows);
			SqlParameter parmPrimaryColumn = new SqlParameter("PrimaryColumn", PrimaryColumn);
			SqlParameter parmSortColumnDbType = new SqlParameter("SortColumnDbType", SortColumnDbType);
			SqlParameter parmSortColumn = new SqlParameter("SortColumn", SortColumn);
			SqlParameter parmStrColumn = new SqlParameter("StrColumn", StrColumn);
			SqlParameter parmSorts = new SqlParameter("Sorts", Sorts);
			SqlParameter parmTableName = new SqlParameter("TableName", TableName);
			SqlParameter parmFilter = new SqlParameter("Filter", Filter);
			SqlParameter parmTotal = new SqlParameter("Total", SqlDbType.Int);
			parmTotal.Direction = ParameterDirection.Output;
			IDataParameter[] parameterArray = new IDataParameter[10];
			parameterArray[0] = parmStartRows;
			parameterArray[1] = parmPageSize;
			parameterArray[2] = parmPrimaryColumn;
			parameterArray[3] = parmSortColumnDbType;
			parameterArray[4] = parmSortColumn;
			parameterArray[5] = parmStrColumn;
			parameterArray[6] = parmSorts;
			parameterArray[7] = parmTableName;
			parameterArray[8] = parmFilter;
			parameterArray[9] = parmTotal;
			DataTable dt = CreateDataTable("Common_GetListBySortColumn", true, parameterArray);
			string strWhere = (!string.IsNullOrEmpty(Filter)) ? " where " + Filter : "";
			string strSQLCount = "select count(*) from " + TableName + " " + strWhere;
			var resultCount = SqlQueryOne<int>(strSQLCount);
			Total = resultCount[0];//Convert.ToInt32(parmTotal.Value);
			return dt;
		}
		#endregion

		#region 执行SQL，检验是否存在数据
		/// <summary>
		/// 执行SQL，检验是否存在数据
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		public virtual bool IsExistBySql(string sql, params IDataParameter[] para)
		{
			bool bExist = false;
			//注意：不要对GetDbConnection获取到的conn进行using或者调用Dispose，否则DbContext后续不能再进行使用了，会抛异常 
			var conn = _Context.Database.GetDbConnection();
			try
			{
				conn.Open();
				using (var command = conn.CreateCommand())
				{
					var param = CheckParamDBNull(para);
					command.CommandText = sql;
					command.Parameters.AddRange(param);
					using (var reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							bExist = true;
						}
					}
				}
			}
			finally
			{
				conn.Close();
			}
			return bExist;
		}
		/// <summary>
		/// 执行SQL，检验是否存在数据
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		public virtual async Task<bool> IsExistBySqlAsync(string sql, params IDataParameter[] para)
		{
			bool bExist = false;
			//注意：不要对GetDbConnection获取到的conn进行using或者调用Dispose，否则DbContext后续不能再进行使用了，会抛异常 
			var conn = _Context.Database.GetDbConnection();
			try
			{
				conn.Open();
				using (var command = conn.CreateCommand())
				{
					var param = CheckParamDBNull(para);
					command.CommandText = sql;
					command.Parameters.AddRange(param);
					using (var reader = await command.ExecuteReaderAsync())
					{
						if (reader.Read())
						{
							bExist = true;
						}
					}
				}
			}
			finally
			{
				conn.Close();
			}
			return bExist;
		}

		/// <summary>
		/// 执行SQL，检验是否存在数据
		/// </summary>
		/// <param name="sql">带参数的SQL语句</param>
		/// <param name="paraName">参数名数组</param>
		/// <param name="paraValue">参数值数组</param>
		/// <returns>有返回true,没有返回false</returns>
		public virtual bool IsExistBySql(string sql, string[] paraName, object[] paraValue)
		{
			var param = CreateParameters(paraName, paraValue);
			return IsExistBySql(sql,param);
		}
		/// <summary>
		/// 执行SQL，检验是否存在数据
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="paraName"></param>
		/// <param name="paraValue"></param>
		/// <returns></returns>
		public virtual async Task<bool> IsExistBySqlAsync(string sql, string[] paraName, object[] paraValue)
		{
			var param = CreateParameters(paraName, paraValue);
			return await IsExistBySqlAsync(sql, param);
		}

		/// <summary>
		/// 执行SQL，检验是否存在数据
		/// </summary>
		/// <param name="sql">带参数的SQL语句</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual bool IsExistBySql(string sql, Dictionary<string, object> dict)
		{
			var param = CreateParameters(dict);
			return IsExistBySql(sql, param);
		}
		/// <summary>
		/// 执行SQL，检验是否存在数据
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		public virtual async Task<bool> IsExistBySqlAsync(string sql, Dictionary<string, object> dict)
		{
			var param = CreateParameters(dict);
			return await IsExistBySqlAsync(sql, param);
		}
		#endregion

		#region 执行SQL，返回受影响的行数
		/// <summary>
		/// 执行SQL语句，返回受影响的行数
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		public virtual int ExeSQL(string sql, params IDataParameter[] para)
		{
			var parameter = CheckParamDBNull(para);
			return _Context.Database.ExecuteSqlCommand(sql, parameter);
		}
		/// <summary>
		/// 执行SQL语句，返回受影响的行数
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="para"></param>
		/// <returns></returns>
		public virtual async Task<int> ExeSQLAsync(string sql, params IDataParameter[] para)
		{
			var parameter = CheckParamDBNull(para);
			return await _Context.Database.ExecuteSqlCommandAsync(sql, parameter);
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
			if (paraName == null || paraValue == null)
			{
				return _Context.Database.ExecuteSqlCommand(sql);
			}
			var parameterArray = CreateParameters(paraName, paraValue);
			return _Context.Database.ExecuteSqlCommand(sql, parameterArray);
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
			if (paraName == null || paraValue == null)
			{
				return await _Context.Database.ExecuteSqlCommandAsync(sql);
			}
			var parameterArray = CreateParameters(paraName, paraValue);
			return await _Context.Database.ExecuteSqlCommandAsync(sql, parameterArray);
		}

		/// <summary>
		/// 执行SQL语句，返回受影响的行数
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		public virtual int ExeSQL(string sql, Dictionary<string, object> dict)
		{
			if (dict == null)
			{
				return _Context.Database.ExecuteSqlCommand(sql);
			}
			var parameterArray = CreateParameters(dict);
			return _Context.Database.ExecuteSqlCommand(sql, parameterArray);
		}
		/// <summary>
		/// 执行SQL语句，返回受影响的行数
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		public virtual async Task<int> ExeSQLAsync(string sql, Dictionary<string, object> dict)
		{
			if (dict == null)
			{
				return await _Context.Database.ExecuteSqlCommandAsync(sql);
			}
			var parameterArray = CreateParameters(dict);
			return await _Context.Database.ExecuteSqlCommandAsync(sql, parameterArray);
		}
		#endregion

		#region 执行SQL，返回结果，返回值必须在实体类中
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
		public virtual TResult GetBySQL<TResult>(string sql, Expression<Func<T, TResult>> scalar, params IDataParameter[] para)
		{
			try
			{
				var parameter = CheckParamDBNull(para);
				return _Context.Set<T>().FromSql(sql, parameter).Select(scalar).First();
			}
			catch
			{
				return default(TResult);
			}
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
		public virtual async Task<TResult> GetBySQLAsync<TResult>(string sql, Expression<Func<T, TResult>> scalar, params IDataParameter[] para)
		{
			try
			{
				var parameter = CheckParamDBNull(para);
				return await _Context.Set<T>().FromSql(sql, parameter).Select(scalar).FirstAsync();
			}
			catch
			{
				return default(TResult);
			}
		}

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
		public virtual TResult GetBySQL<TResult>(string sql, Expression<Func<T, TResult>> scalar, string[] paraName, object[] paraValue)
		{
			try
			{
				var parameter = CreateParameters(paraName, paraValue);
				return _Context.Set<T>().FromSql(sql, parameter).Select(scalar).First();
			}
			catch
			{
				return default(TResult);
			}
		}
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
		public virtual async Task<TResult> GetBySQLAsync<TResult>(string sql, Expression<Func<T, TResult>> scalar, string[] paraName, object[] paraValue)
		{
			try
			{
				var parameter = CreateParameters(paraName, paraValue);
				return await _Context.Set<T>().FromSql(sql, parameter).Select(scalar).FirstAsync();
			}
			catch
			{
				return default(TResult);
			}
		}

		/// <summary>
		/// 执行SQL，返回结果，返回值必须在实体类中。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="scalar"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		public virtual TResult GetBySQL<TResult>(string sql, Expression<Func<T, TResult>> scalar, Dictionary<string, object> dict)
		{
			try
			{
				var parameter = CreateParameters(dict);
				return _Context.Set<T>().FromSql(sql, parameter).Select(scalar).First();
			}
			catch
			{
				return default(TResult);
			}
		}
		/// <summary>
		/// 执行SQL，返回结果，返回值必须在实体类中。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="scalar"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		public virtual async Task<TResult> GetBySQLAsync<TResult>(string sql, Expression<Func<T, TResult>> scalar, Dictionary<string, object> dict)
		{
			try
			{
				var parameter = CreateParameters(dict);
				return await _Context.Set<T>().FromSql(sql, parameter).Select(scalar).FirstAsync();
			}
			catch
			{
				return default(TResult);
			}
		}
		#endregion

		#region 执行SQL，返回查询结果。主要用于返回实体类或者值类型
		/// <summary>
		/// 执行SQL，返回查询结果。主要用于返回实体类或者值类型，返回参数需要带有空白构造函数。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public virtual IList<TResult> SqlQuery<TResult>(string sql, params IDataParameter[] parameters) where TResult : new()
		{
			//注意：不要对GetDbConnection获取到的conn进行using或者调用Dispose，否则DbContext后续不能再进行使用了，会抛异常 
			var conn = _Context.Database.GetDbConnection();
			try
			{
				conn.Open();
				using (var command = conn.CreateCommand())
				{
					var param = CheckParamDBNull(parameters);
					command.CommandText = sql;
					command.Parameters.AddRange(param);
					var propts = typeof(TResult).GetProperties();
					var rtnList = new List<TResult>();
					TResult model;
					object val;
					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							if (propts.Length == 0)
							{
								model = default(TResult);
								model = (TResult)reader[0];
							}
							else
							{
								model = new TResult();
								foreach (var l in propts)
								{
									try
									{
										val = reader[l.Name];
									}
									catch
									{
										continue;
									}
									if (val == DBNull.Value)
									{
										l.SetValue(model, null);
									}
									else
									{
										l.SetValue(model, val);
									}
								}
							}
							rtnList.Add(model);
						}
					}
					return rtnList;
				}
			}
			finally
			{
				conn.Close();
			}
		}
		/// <summary>
		/// 执行SQL，返回查询结果。主要用于返回实体类或者值类型，返回参数需要带有空白构造函数。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public virtual async Task<IList<TResult>> SqlQueryAsync<TResult>(string sql, params IDataParameter[] parameters) where TResult : new()
		{
			//注意：不要对GetDbConnection获取到的conn进行using或者调用Dispose，否则DbContext后续不能再进行使用了，会抛异常 
			var conn = _Context.Database.GetDbConnection();
			try
			{
				conn.Open();
				using (var command = conn.CreateCommand())
				{
					var param = CheckParamDBNull(parameters);
					command.CommandText = sql;
					command.Parameters.AddRange(param);
					var propts = typeof(TResult).GetProperties();
					var rtnList = new List<TResult>();
					TResult model;
					object val;
					using (var reader = await command.ExecuteReaderAsync())
					{
						while (reader.Read())
						{
							if (propts.Length == 0)
							{
								model = default(TResult);
								model = (TResult)reader[0];
							}
							else
							{
								model = new TResult();
								foreach (var l in propts)
								{
									try
									{
										val = reader[l.Name];
									}
									catch
									{
										continue;
									}
									if (val == DBNull.Value)
									{
										l.SetValue(model, null);
									}
									else
									{
										l.SetValue(model, val);
									}
								}
							}
							rtnList.Add(model);
						}
					}
					return rtnList;
				}
			}
			finally
			{
				conn.Close();
			}
		}

		/// <summary>
		/// 执行SQL，返回查询结果。主要用于返回实体类或者值类型，返回参数需要带有空白构造函数。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="paraName"></param>
		/// <param name="paraValue"></param>
		/// <returns></returns>
		public virtual IList<TResult> SqlQuery<TResult>(string sql, string[] paraName, object[] paraValue) where TResult : new()
		{
			var param = CreateParameters(paraName, paraValue);
			return SqlQuery<TResult>(sql,param);
		}
		/// <summary>
		/// 执行SQL，返回查询结果。主要用于返回实体类或者值类型，返回参数需要带有空白构造函数。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="paraName"></param>
		/// <param name="paraValue"></param>
		/// <returns></returns>
		public virtual async Task<IList<TResult>> SqlQueryAsync<TResult>(string sql, string[] paraName, object[] paraValue) where TResult : new()
		{
			var param = CreateParameters(paraName, paraValue);
			return await SqlQueryAsync<TResult>(sql, param);
		}

		/// <summary>
		/// 执行SQL，返回查询结果。主要用于返回实体类或者值类型，返回参数需要带有空白构造函数。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		public virtual IList<TResult> SqlQuery<TResult>(string sql, Dictionary<string, object> dict) where TResult : new()
		{
			var param = CreateParameters(dict);
			return SqlQuery<TResult>(sql, param);
		}
		/// <summary>
		/// 执行SQL，返回查询结果。主要用于返回实体类或者值类型，返回参数需要带有空白构造函数。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		public virtual async Task<IList<TResult>> SqlQueryAsync<TResult>(string sql, Dictionary<string, object> dict) where TResult : new()
		{
			var param = CreateParameters(dict);
			return await SqlQueryAsync<TResult>(sql, param);
		}
		#endregion

		#region 执行SQL，返回查询结果。主要用于返回IList《string》
		/// <summary>
		/// 执行SQL，返回查询结果。主要用于返回IList《string》。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public virtual IList<TResult> SqlQueryOne<TResult>(string sql, params IDataParameter[] parameters)
		{
			//注意：不要对GetDbConnection获取到的conn进行using或者调用Dispose，否则DbContext后续不能再进行使用了，会抛异常 
			var conn = _Context.Database.GetDbConnection();
			try
			{
				conn.Open();
				using (var command = conn.CreateCommand())
				{
					var param = CheckParamDBNull(parameters);
					command.CommandText = sql;
					command.Parameters.AddRange(param);
					var propts = typeof(TResult).GetProperties();
					var rtnList = new List<TResult>();
					TResult model;
					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							model = default(TResult);
							model = (TResult)reader[0];
							rtnList.Add(model);
						}
					}
					return rtnList;
				}
			}
			finally
			{
				conn.Close();
			}
		}
		/// <summary>
		/// 执行SQL，返回查询结果。主要用于返回IList《string》。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public virtual async Task<IList<TResult>> SqlQueryOneAsync<TResult>(string sql, params IDataParameter[] parameters)
		{
			//注意：不要对GetDbConnection获取到的conn进行using或者调用Dispose，否则DbContext后续不能再进行使用了，会抛异常 
			var conn = _Context.Database.GetDbConnection();
			try
			{
				conn.Open();
				using (var command = conn.CreateCommand())
				{
					var param = CheckParamDBNull(parameters);
					command.CommandText = sql;
					command.Parameters.AddRange(param);
					var propts = typeof(TResult).GetProperties();
					var rtnList = new List<TResult>();
					TResult model;
					using (var reader = await command.ExecuteReaderAsync())
					{
						while (reader.Read())
						{
							model = default(TResult);
							model = (TResult)reader[0];
							rtnList.Add(model);
						}
					}
					return rtnList;
				}
			}
			finally
			{
				conn.Close();
			}
		}

		/// <summary>
		/// 执行SQL，返回第一列的数据列表。主要用于返回IList《string》。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="paraName"></param>
		/// <param name="paraValue"></param>
		/// <returns></returns>
		public virtual IList<TResult> SqlQueryOne<TResult>(string sql, string[] paraName, object[] paraValue)
		{
			var param = CreateParameters(paraName, paraValue);
			return SqlQueryOne<TResult>(sql, param);
		}
		/// <summary>
		/// 执行SQL，返回第一列的数据列表。主要用于返回IList《string》。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="paraName"></param>
		/// <param name="paraValue"></param>
		/// <returns></returns>
		public virtual async Task<IList<TResult>> SqlQueryOneAsync<TResult>(string sql, string[] paraName, object[] paraValue)
		{
			var param = CreateParameters(paraName, paraValue);
			return await SqlQueryOneAsync<TResult>(sql, param);
		}

		/// <summary>
		/// 执行SQL，返回第一列的数据列表。主要用于返回IList《string》。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		public virtual IList<TResult> SqlQueryOne<TResult>(string sql, Dictionary<string, object> dict)
		{
			var param = CreateParameters(dict);
			return SqlQueryOne<TResult>(sql, param);
		}
		/// <summary>
		/// 执行SQL，返回第一列的数据列表。主要用于返回IList《string》。
		/// </summary>
		/// <typeparam name="TResult"></typeparam>
		/// <param name="sql"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		public virtual async Task<IList<TResult>> SqlQueryOneAsync<TResult>(string sql, Dictionary<string, object> dict)
		{
			var param = CreateParameters(dict);
			return await SqlQueryOneAsync<TResult>(sql, param);
		}
		#endregion

		#region 执行SQL，返回DataTable
		/// <summary>
		/// 执行SQL，返回DataTable
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public virtual DataTable GetDataTableBySql(string sql, params IDataParameter[] parameters)
		{
			var dt = CreateDataTable(sql,false,parameters);
			return dt;
		}
		/// <summary>
		/// 执行SQL，返回DataTable
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public virtual async Task<DataTable> GetDataTableBySqlAsync(string sql, params IDataParameter[] parameters)
		{
			var dt = await Task.Run(()=>CreateDataTable(sql, false, parameters));
			return dt;
		}

		/// <summary>
		/// 执行SQL，返回DataTable
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="paraName"></param>
		/// <param name="paraValue"></param>
		/// <returns></returns>
		public virtual DataTable GetDataTableBySql(string sql, string[] paraName, object[] paraValue)
		{
			var param = CreateParameters(paraName, paraValue);
			return GetDataTableBySql(sql, param);
		}
		/// <summary>
		/// 执行SQL，返回DataTable
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="paraName"></param>
		/// <param name="paraValue"></param>
		/// <returns></returns>
		public virtual async Task<DataTable> GetDataTableBySqlAsync(string sql, string[] paraName, object[] paraValue)
		{
			var param = CreateParameters(paraName, paraValue);
			return await GetDataTableBySqlAsync(sql, param);
		}

		/// <summary>
		/// 执行SQL，返回DataTable
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		public virtual DataTable GetDataTableBySql(string sql, Dictionary<string, object> dict)
		{
			var param = CreateParameters(dict);
			return GetDataTableBySql(sql, param);
		}
		/// <summary>
		/// 执行SQL，返回DataTable
		/// </summary>
		/// <param name="sql"></param>
		/// <param name="dict"></param>
		/// <returns></returns>
		public virtual async Task<DataTable> GetDataTableBySqlAsync(string sql, Dictionary<string, object> dict)
		{
			var param = CreateParameters(dict);
			return await GetDataTableBySqlAsync(sql, param);
		}
		#endregion

		#region 辅助方法
		private DataTable CreateDataTable(string sql,bool isProc=true, params IDataParameter[] parameters)
		{
			//注意：不要对GetDbConnection获取到的conn进行using或者调用Dispose，否则DbContext后续不能再进行使用了，会抛异常
			var conn = _Context.Database.GetDbConnection();
			try
			{
				if (conn.State != ConnectionState.Open)
				{
					conn.Open();
				}
				using (var command = conn.CreateCommand())
				{
					var param = CheckParamDBNull(parameters);
					command.CommandText = sql;
					command.Parameters.AddRange(param);
					if (isProc)
					{
						command.CommandType = CommandType.StoredProcedure;
					}
					var dap = new SqlDataAdapter((SqlCommand)command);
					DataTable table = new DataTable();
					dap.Fill(table);
					return table;
				}
			}
			finally
			{
				conn.Close();
			}
		}
		private IQueryable<TEntity> GetQueryableBySortModelField<TEntity>(params SortModelField[] orderByExpression) where TEntity : class
		{
			IQueryable<TEntity> query = _Context.Set<TEntity>();
			//创建表达式变量参数
			var parameter = Expression.Parameter(typeof(TEntity), "o");
			if (orderByExpression != null && orderByExpression.Length > 0)
			{
				for (int i = 0; i < orderByExpression.Length; i++)
				{
					//根据排序字段名获取属性
					var property = typeof(TEntity).GetProperty(orderByExpression[i].SortName);
					//创建一个访问属性的表达式
					var propertyAccess = Expression.MakeMemberAccess(parameter, property);
					var orderByExp = Expression.Lambda(propertyAccess, parameter);
					//创建调用排序方法的表达式
					string OrderName = "";
					if (i > 0)
					{
						OrderName = orderByExpression[i].IsDESC ? "ThenByDescending" : "ThenBy";
					}
					else
					{
						OrderName = orderByExpression[i].IsDESC ? "OrderByDescending" : "OrderBy";
					}
					MethodCallExpression resultExp = Expression.Call(typeof(Queryable), OrderName, new Type[] { typeof(T), property.PropertyType }, query.Expression, Expression.Quote(orderByExp));

					query = query.Provider.CreateQuery<TEntity>(resultExp);
				}
			}
			return query;
		}
		private string GetTableName(string tableName="")
		{
			var result = "";
			if (string.IsNullOrEmpty(tableName))
			{
				result = typeof(T).Name;
			}
			if (result.EndsWith("Entity"))
			{
				result = result.Replace("Entity", "");
			}
			return result;
		}
		private IDataParameter[] CheckParamDBNull(IDataParameter[] para)
		{
			if (para == null)
				return para;
			IDataParameter[] parameterArray = new IDataParameter[para.Length];
			for (int j = 0; j < para.Length; j++)
			{
				if (para[j].Value == null)
				{
					para[j].Value = DBNull.Value;
				}
				parameterArray[j] = new SqlParameter()
				{
					ParameterName = para[j].ParameterName,
					Value = para[j].Value
				};
			}
			return parameterArray;
		}
		/// <summary>
		/// 生成参数对象
		/// </summary>
		/// <param name="paraName">参数名数组</param>
		/// <param name="paraValue">参数值数组</param>
		private IDataParameter[] CreateParameters(string[] paraName, object[] paraValue)
		{
			if (paraName == null || paraValue == null)
			{
				return null;
			}
			IDataParameter[] parameterArray = new IDataParameter[paraName.Length];
			for (int j = 0; j < paraName.Length; j++)
			{
				parameterArray[j] = new SqlParameter();
				parameterArray[j].ParameterName = paraName[j].ToString();
				parameterArray[j].Value = paraValue[j];
				if (parameterArray[j].Value == null)
				{
					parameterArray[j].Value = DBNull.Value;
				}
			}
			return parameterArray;
		}
		/// <summary>
		/// 生成参数对象
		/// </summary>
		/// <param name="dict">参数的名/值集合</param>
		private IDataParameter[] CreateParameters(Dictionary<string, object> dict)
		{
			if (dict == null)
			{
				return null;
			}
			var parameterArray = new IDataParameter[dict.Count];
			int i = 0;
			foreach (KeyValuePair<string, object> kvp in dict)
			{
				parameterArray[i] = new SqlParameter();
				parameterArray[i].ParameterName = kvp.Key;
				parameterArray[i].Value = (kvp.Value == null) ? DBNull.Value : kvp.Value;
				i++;
			}
			return parameterArray;
		}
		#endregion
	}
}
