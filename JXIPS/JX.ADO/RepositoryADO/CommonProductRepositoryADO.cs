using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;
using JX.Infrastructure.Common;
using MyADO;

namespace JX.ADO
{
	/// <summary>
	/// 数据库表：CommonProduct 的仓储实现类.
	/// </summary>
	public partial class CommonProductRepositoryADO : ICommonProductRepositoryADO
	{
		#region 数据上下文
		/// <summary>
		/// 数据上下文
		/// </summary>
		private IDBOperator _DB;

		/// <summary>
		/// 构造器注入
		/// </summary>
		/// <param name="DB"></param>
		public CommonProductRepositoryADO(IDBOperator DB)
		{
			_DB = DB;
		}
		#endregion
		
		#region 得到第一行第一列的值
		/// <summary>
		/// 得到第一行第一列的值
		/// </summary>
		/// <param name="statistic">要返回的字段（如：count(*) 或者 UserName）</param>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual string GetScalar(string statistic, string strWhere = "", Dictionary<string, object> dict = null)
		{
			string strSQL = "select " + statistic + " from CommonProduct where 1=1 ";
			if (!string.IsNullOrEmpty(strWhere))
			{
				strSQL += strWhere;
			}
			return _DB.ExeSQLScalar(strSQL, dict);
		}
		/// <summary>
		/// 得到第一行第一列的值（异步方式）
		/// </summary>
		/// <param name="statistic">要返回的字段（如：count(*) 或者 UserName）</param>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual async Task<string> GetScalarAsync(string statistic, string strWhere = "", Dictionary<string, object> dict = null)
		{
			string strSQL = "select " + statistic + " from CommonProduct where 1=1 ";
			if (!string.IsNullOrEmpty(strWhere))
			{
				strSQL += strWhere;
			}
			return await Task.Run(() => _DB.ExeSQLScalar(strSQL, dict));
		}
		#endregion
		
		#region 得到所有行数
		/// <summary>
		/// 得到所有行数
		/// </summary>
		/// <returns></returns>
		public virtual int GetCount()
		{
			return DataConverter.CLng(GetScalar("count(*)"), 0);
		}
		/// <summary>
		/// 得到所有行数（异步方式）
		/// </summary>
		/// <returns></returns>
		public virtual async Task<int> GetCountAsync()
		{
			return DataConverter.CLng(await GetScalarAsync("count(*)"), 0);
		}

		/// <summary>
		/// 得到所有行数
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual int GetCount(string strWhere, Dictionary<string, object> dict = null)
		{
			return DataConverter.CLng(GetScalar("count(*)", strWhere, dict), 0);
		}
		/// <summary>
		/// 得到所有行数（异步方式）
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual async Task<int> GetCountAsync(string strWhere, Dictionary<string, object> dict = null)
		{
			return DataConverter.CLng(await GetScalarAsync("count(*)", strWhere, dict), 0);
		}
		#endregion
		
		#region 得到最大ID、最新ID
		/// <summary>
		/// 得到数据表中第一个主键的最大数值
		/// </summary>
		/// <returns></returns>
		public virtual int GetMaxID()
		{
			return _DB.GetMaxID("CommonProduct", "ProductID");
		}
		/// <summary>
		/// 得到数据表中第一个主键的最大数值（异步方式）
		/// </summary>
		/// <returns></returns>
		public virtual async Task<int> GetMaxIDAsync()
		{
			return await Task.Run(() => _DB.GetMaxID("CommonProduct", "ProductID"));
		}

		/// <summary>
		/// 得到数据表中第一个主键的最大数值加1
		/// </summary>
		/// <returns></returns>
		public virtual int GetNewID()
		{
			return GetMaxID() + 1;
		}
		/// <summary>
		/// 得到数据表中第一个主键的最大数值加1（异步方式）
		/// </summary>
		/// <returns></returns>
		public virtual async Task<int> GetNewIDAsync()
		{
			return await GetMaxIDAsync() + 1;
		}
		#endregion
		
		#region 验证是否存在
		/// <summary>
		/// 检查数据是否存在
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual bool IsExist(string strWhere, Dictionary<string, object> dict = null)
		{
			if (GetCount(strWhere, dict) == 0)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// 检查数据是否存在（异步方式）
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual async Task<bool> IsExistAsync(string strWhere, Dictionary<string, object> dict = null)
		{
			int count = await GetCountAsync(strWhere, dict);
			if (count == 0)
			{
				return false;
			}
			return true;
		}
		#endregion
		
		#region 添加
		/// <summary>
		/// 增加一条记录
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <returns></returns>
		public virtual bool Add(CommonProductEntity entity)
		{
			if(entity.ProductID <= 0) entity.ProductID=GetNewID();
			Dictionary<string, object> dict = new Dictionary<string, object>();
			GetParameters(entity,dict);

			string strSQL = "insert into CommonProduct ("+
							"ProductID,"+
							"TableName,"+
							"ProductName,"+
							"ProductNum,"+
							"ProductType,"+
							"Unit,"+
							"ProductThumb,"+
							"ProductPic,"+
							"ServiceTermUnit,"+
							"ServiceTerm,"+
							"Price,"+
							"Price_Market,"+
							"Price_Activity,"+
							"Price_Settlement,"+
							"Price_Member,"+
							"Price_Agent,"+
							"IsStockOutBuy,"+
							"IsWholesale,"+
							"Price_Wholesale1,"+
							"Price_Wholesale2,"+
							"Price_Wholesale3,"+
							"Number_Wholesale1,"+
							"Number_Wholesale2,"+
							"Number_Wholesale3,"+
							"PresentID,"+
							"PresentNumber,"+
							"PresentPoint,"+
							"PresentExp,"+
							"PresentMoney,"+
							"StocksProject,"+
							"SalePromotionType,"+
							"AlarmNum,"+
							"BuyTimes,"+
							"MinNumber,"+
							"Discount,"+
							"IncludeTax,"+
							"TaxRate,"+
							"Properties,"+
							"Weight,"+
							"LimitNum,"+
							"IsEnableSale,"+
							"IsSingleSell,"+
							"ProductKind,"+
							"DependentProducts,"+
							"Stocks,"+
							"OrderNum,"+
							"DownloadUrl,"+
							"Remark,"+
							"ProductCharacter,"+
							"Keyword,"+
							"ProducerName,"+
							"TrademarkName,"+
							"BarCode,"+
							"ProductIntro,"+
							"ProductExplain,"+
							"IsNew,"+
							"IsHot,"+
							"IsBest,"+
							"Stars,"+
							"Minimum,"+
							"MultiplePhoto,"+
							"IsEnableHP) "+
							"values("+
							"@ProductID,"+
							"@TableName,"+
							"@ProductName,"+
							"@ProductNum,"+
							"@ProductType,"+
							"@Unit,"+
							"@ProductThumb,"+
							"@ProductPic,"+
							"@ServiceTermUnit,"+
							"@ServiceTerm,"+
							"@Price,"+
							"@Price_Market,"+
							"@Price_Activity,"+
							"@Price_Settlement,"+
							"@Price_Member,"+
							"@Price_Agent,"+
							"@IsStockOutBuy,"+
							"@IsWholesale,"+
							"@Price_Wholesale1,"+
							"@Price_Wholesale2,"+
							"@Price_Wholesale3,"+
							"@Number_Wholesale1,"+
							"@Number_Wholesale2,"+
							"@Number_Wholesale3,"+
							"@PresentID,"+
							"@PresentNumber,"+
							"@PresentPoint,"+
							"@PresentExp,"+
							"@PresentMoney,"+
							"@StocksProject,"+
							"@SalePromotionType,"+
							"@AlarmNum,"+
							"@BuyTimes,"+
							"@MinNumber,"+
							"@Discount,"+
							"@IncludeTax,"+
							"@TaxRate,"+
							"@Properties,"+
							"@Weight,"+
							"@LimitNum,"+
							"@IsEnableSale,"+
							"@IsSingleSell,"+
							"@ProductKind,"+
							"@DependentProducts,"+
							"@Stocks,"+
							"@OrderNum,"+
							"@DownloadUrl,"+
							"@Remark,"+
							"@ProductCharacter,"+
							"@Keyword,"+
							"@ProducerName,"+
							"@TrademarkName,"+
							"@BarCode,"+
							"@ProductIntro,"+
							"@ProductExplain,"+
							"@IsNew,"+
							"@IsHot,"+
							"@IsBest,"+
							"@Stars,"+
							"@Minimum,"+
							"@MultiplePhoto,"+
							"@IsEnableHP)";
			
			return _DB.ExeSQLResult(strSQL,dict);
		}
		/// <summary>
		/// 增加一条记录（异步方式）
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <returns></returns>
		public virtual async Task<bool> AddAsync(CommonProductEntity entity)
		{
			if(entity.ProductID <= 0) entity.ProductID=GetNewID();
			Dictionary<string, object> dict = new Dictionary<string, object>();
			GetParameters(entity, dict);

			string strSQL = "insert into CommonProduct ("+
							"ProductID,"+
							"TableName,"+
							"ProductName,"+
							"ProductNum,"+
							"ProductType,"+
							"Unit,"+
							"ProductThumb,"+
							"ProductPic,"+
							"ServiceTermUnit,"+
							"ServiceTerm,"+
							"Price,"+
							"Price_Market,"+
							"Price_Activity,"+
							"Price_Settlement,"+
							"Price_Member,"+
							"Price_Agent,"+
							"IsStockOutBuy,"+
							"IsWholesale,"+
							"Price_Wholesale1,"+
							"Price_Wholesale2,"+
							"Price_Wholesale3,"+
							"Number_Wholesale1,"+
							"Number_Wholesale2,"+
							"Number_Wholesale3,"+
							"PresentID,"+
							"PresentNumber,"+
							"PresentPoint,"+
							"PresentExp,"+
							"PresentMoney,"+
							"StocksProject,"+
							"SalePromotionType,"+
							"AlarmNum,"+
							"BuyTimes,"+
							"MinNumber,"+
							"Discount,"+
							"IncludeTax,"+
							"TaxRate,"+
							"Properties,"+
							"Weight,"+
							"LimitNum,"+
							"IsEnableSale,"+
							"IsSingleSell,"+
							"ProductKind,"+
							"DependentProducts,"+
							"Stocks,"+
							"OrderNum,"+
							"DownloadUrl,"+
							"Remark,"+
							"ProductCharacter,"+
							"Keyword,"+
							"ProducerName,"+
							"TrademarkName,"+
							"BarCode,"+
							"ProductIntro,"+
							"ProductExplain,"+
							"IsNew,"+
							"IsHot,"+
							"IsBest,"+
							"Stars,"+
							"Minimum,"+
							"MultiplePhoto,"+
							"IsEnableHP) "+
							"values("+
							"@ProductID,"+
							"@TableName,"+
							"@ProductName,"+
							"@ProductNum,"+
							"@ProductType,"+
							"@Unit,"+
							"@ProductThumb,"+
							"@ProductPic,"+
							"@ServiceTermUnit,"+
							"@ServiceTerm,"+
							"@Price,"+
							"@Price_Market,"+
							"@Price_Activity,"+
							"@Price_Settlement,"+
							"@Price_Member,"+
							"@Price_Agent,"+
							"@IsStockOutBuy,"+
							"@IsWholesale,"+
							"@Price_Wholesale1,"+
							"@Price_Wholesale2,"+
							"@Price_Wholesale3,"+
							"@Number_Wholesale1,"+
							"@Number_Wholesale2,"+
							"@Number_Wholesale3,"+
							"@PresentID,"+
							"@PresentNumber,"+
							"@PresentPoint,"+
							"@PresentExp,"+
							"@PresentMoney,"+
							"@StocksProject,"+
							"@SalePromotionType,"+
							"@AlarmNum,"+
							"@BuyTimes,"+
							"@MinNumber,"+
							"@Discount,"+
							"@IncludeTax,"+
							"@TaxRate,"+
							"@Properties,"+
							"@Weight,"+
							"@LimitNum,"+
							"@IsEnableSale,"+
							"@IsSingleSell,"+
							"@ProductKind,"+
							"@DependentProducts,"+
							"@Stocks,"+
							"@OrderNum,"+
							"@DownloadUrl,"+
							"@Remark,"+
							"@ProductCharacter,"+
							"@Keyword,"+
							"@ProducerName,"+
							"@TrademarkName,"+
							"@BarCode,"+
							"@ProductIntro,"+
							"@ProductExplain,"+
							"@IsNew,"+
							"@IsHot,"+
							"@IsBest,"+
							"@Stars,"+
							"@Minimum,"+
							"@MultiplePhoto,"+
							"@IsEnableHP)";
			
			return await Task.Run(() => _DB.ExeSQLResult(strSQL, dict));
		}

		/// <summary>
		/// 增加一条记录，返回新的ID号。需要有一个单一主键，并且开启有标识符属性
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <returns></returns>
		public virtual int Insert(CommonProductEntity entity)
		{
			if(entity.ProductID <= 0) entity.ProductID=GetNewID();			
			Dictionary<string, object> dict = new Dictionary<string, object>();
			GetParameters(entity,dict);

			string strSQL = "insert into CommonProduct ("+
							"ProductID,"+
							"TableName,"+
							"ProductName,"+
							"ProductNum,"+
							"ProductType,"+
							"Unit,"+
							"ProductThumb,"+
							"ProductPic,"+
							"ServiceTermUnit,"+
							"ServiceTerm,"+
							"Price,"+
							"Price_Market,"+
							"Price_Activity,"+
							"Price_Settlement,"+
							"Price_Member,"+
							"Price_Agent,"+
							"IsStockOutBuy,"+
							"IsWholesale,"+
							"Price_Wholesale1,"+
							"Price_Wholesale2,"+
							"Price_Wholesale3,"+
							"Number_Wholesale1,"+
							"Number_Wholesale2,"+
							"Number_Wholesale3,"+
							"PresentID,"+
							"PresentNumber,"+
							"PresentPoint,"+
							"PresentExp,"+
							"PresentMoney,"+
							"StocksProject,"+
							"SalePromotionType,"+
							"AlarmNum,"+
							"BuyTimes,"+
							"MinNumber,"+
							"Discount,"+
							"IncludeTax,"+
							"TaxRate,"+
							"Properties,"+
							"Weight,"+
							"LimitNum,"+
							"IsEnableSale,"+
							"IsSingleSell,"+
							"ProductKind,"+
							"DependentProducts,"+
							"Stocks,"+
							"OrderNum,"+
							"DownloadUrl,"+
							"Remark,"+
							"ProductCharacter,"+
							"Keyword,"+
							"ProducerName,"+
							"TrademarkName,"+
							"BarCode,"+
							"ProductIntro,"+
							"ProductExplain,"+
							"IsNew,"+
							"IsHot,"+
							"IsBest,"+
							"Stars,"+
							"Minimum,"+
							"MultiplePhoto,"+
							"IsEnableHP) "+
							"values("+
							"@ProductID,"+
							"@TableName,"+
							"@ProductName,"+
							"@ProductNum,"+
							"@ProductType,"+
							"@Unit,"+
							"@ProductThumb,"+
							"@ProductPic,"+
							"@ServiceTermUnit,"+
							"@ServiceTerm,"+
							"@Price,"+
							"@Price_Market,"+
							"@Price_Activity,"+
							"@Price_Settlement,"+
							"@Price_Member,"+
							"@Price_Agent,"+
							"@IsStockOutBuy,"+
							"@IsWholesale,"+
							"@Price_Wholesale1,"+
							"@Price_Wholesale2,"+
							"@Price_Wholesale3,"+
							"@Number_Wholesale1,"+
							"@Number_Wholesale2,"+
							"@Number_Wholesale3,"+
							"@PresentID,"+
							"@PresentNumber,"+
							"@PresentPoint,"+
							"@PresentExp,"+
							"@PresentMoney,"+
							"@StocksProject,"+
							"@SalePromotionType,"+
							"@AlarmNum,"+
							"@BuyTimes,"+
							"@MinNumber,"+
							"@Discount,"+
							"@IncludeTax,"+
							"@TaxRate,"+
							"@Properties,"+
							"@Weight,"+
							"@LimitNum,"+
							"@IsEnableSale,"+
							"@IsSingleSell,"+
							"@ProductKind,"+
							"@DependentProducts,"+
							"@Stocks,"+
							"@OrderNum,"+
							"@DownloadUrl,"+
							"@Remark,"+
							"@ProductCharacter,"+
							"@Keyword,"+
							"@ProducerName,"+
							"@TrademarkName,"+
							"@BarCode,"+
							"@ProductIntro,"+
							"@ProductExplain,"+
							"@IsNew,"+
							"@IsHot,"+
							"@IsBest,"+
							"@Stars,"+
							"@Minimum,"+
							"@MultiplePhoto,"+
							"@IsEnableHP)";
			if(_DB.ExeSQLResult(strSQL,dict))
			{
				return DataConverter.CLng(entity.ProductID);
			}
			return -1;
		}
		/// <summary>
		/// 增加一条记录，返回新的ID号。需要有一个单一主键，并且开启有标识符属性（异步方式）
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <returns></returns>
		public virtual async Task<int> InsertAsync(CommonProductEntity entity)
		{
			if(entity.ProductID <= 0) entity.ProductID=GetNewID();			
			Dictionary<string, object> dict = new Dictionary<string, object>();
			GetParameters(entity,dict);

			string strSQL = "insert into CommonProduct ("+
							"ProductID,"+
							"TableName,"+
							"ProductName,"+
							"ProductNum,"+
							"ProductType,"+
							"Unit,"+
							"ProductThumb,"+
							"ProductPic,"+
							"ServiceTermUnit,"+
							"ServiceTerm,"+
							"Price,"+
							"Price_Market,"+
							"Price_Activity,"+
							"Price_Settlement,"+
							"Price_Member,"+
							"Price_Agent,"+
							"IsStockOutBuy,"+
							"IsWholesale,"+
							"Price_Wholesale1,"+
							"Price_Wholesale2,"+
							"Price_Wholesale3,"+
							"Number_Wholesale1,"+
							"Number_Wholesale2,"+
							"Number_Wholesale3,"+
							"PresentID,"+
							"PresentNumber,"+
							"PresentPoint,"+
							"PresentExp,"+
							"PresentMoney,"+
							"StocksProject,"+
							"SalePromotionType,"+
							"AlarmNum,"+
							"BuyTimes,"+
							"MinNumber,"+
							"Discount,"+
							"IncludeTax,"+
							"TaxRate,"+
							"Properties,"+
							"Weight,"+
							"LimitNum,"+
							"IsEnableSale,"+
							"IsSingleSell,"+
							"ProductKind,"+
							"DependentProducts,"+
							"Stocks,"+
							"OrderNum,"+
							"DownloadUrl,"+
							"Remark,"+
							"ProductCharacter,"+
							"Keyword,"+
							"ProducerName,"+
							"TrademarkName,"+
							"BarCode,"+
							"ProductIntro,"+
							"ProductExplain,"+
							"IsNew,"+
							"IsHot,"+
							"IsBest,"+
							"Stars,"+
							"Minimum,"+
							"MultiplePhoto,"+
							"IsEnableHP) "+
							"values("+
							"@ProductID,"+
							"@TableName,"+
							"@ProductName,"+
							"@ProductNum,"+
							"@ProductType,"+
							"@Unit,"+
							"@ProductThumb,"+
							"@ProductPic,"+
							"@ServiceTermUnit,"+
							"@ServiceTerm,"+
							"@Price,"+
							"@Price_Market,"+
							"@Price_Activity,"+
							"@Price_Settlement,"+
							"@Price_Member,"+
							"@Price_Agent,"+
							"@IsStockOutBuy,"+
							"@IsWholesale,"+
							"@Price_Wholesale1,"+
							"@Price_Wholesale2,"+
							"@Price_Wholesale3,"+
							"@Number_Wholesale1,"+
							"@Number_Wholesale2,"+
							"@Number_Wholesale3,"+
							"@PresentID,"+
							"@PresentNumber,"+
							"@PresentPoint,"+
							"@PresentExp,"+
							"@PresentMoney,"+
							"@StocksProject,"+
							"@SalePromotionType,"+
							"@AlarmNum,"+
							"@BuyTimes,"+
							"@MinNumber,"+
							"@Discount,"+
							"@IncludeTax,"+
							"@TaxRate,"+
							"@Properties,"+
							"@Weight,"+
							"@LimitNum,"+
							"@IsEnableSale,"+
							"@IsSingleSell,"+
							"@ProductKind,"+
							"@DependentProducts,"+
							"@Stocks,"+
							"@OrderNum,"+
							"@DownloadUrl,"+
							"@Remark,"+
							"@ProductCharacter,"+
							"@Keyword,"+
							"@ProducerName,"+
							"@TrademarkName,"+
							"@BarCode,"+
							"@ProductIntro,"+
							"@ProductExplain,"+
							"@IsNew,"+
							"@IsHot,"+
							"@IsBest,"+
							"@Stars,"+
							"@Minimum,"+
							"@MultiplePhoto,"+
							"@IsEnableHP)";
			if(await Task.Run(() => _DB.ExeSQLResult(strSQL, dict)))
			{
				return DataConverter.CLng(entity.ProductID);
			}
			return -1;
		}

		/// <summary>
		/// 增加或更新一条记录
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsSave">是否增加</param>
		/// <returns></returns>
		public virtual bool AddOrUpdate(CommonProductEntity entity, bool IsSave)
		{
			return IsSave ? Add(entity) : Update(entity);
		}
		/// <summary>
		/// 增加或更新一条记录（异步方式）
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsSave">是否增加</param>
		/// <returns></returns>
		public virtual async Task<bool> AddOrUpdateAsync(CommonProductEntity entity, bool IsSave)
		{
			return IsSave ? await AddAsync(entity) : await UpdateAsync(entity);
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 通过主键删除
		/// </summary>
		/// <returns></returns>
		public bool Delete(System.Int32 productID)
		{
			string strSQL = "delete from CommonProduct where " +
			
			"ProductID = @ProductID"; 
			
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("ProductID", productID);
			
			return _DB.ExeSQLResult(strSQL, dict);
		}
		/// <summary>
		/// 通过主键删除
		/// </summary>
		/// <returns></returns>
		public async Task<bool> DeleteAsync(System.Int32 productID)
		{
			string strSQL = "delete from CommonProduct where " +
			
			"ProductID = @ProductID"; 
			
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("ProductID", productID);
			
			return await Task.Run(() => _DB.ExeSQLResult(strSQL, dict));
		}
		
		/// <summary>
		/// 删除一条或多条记录
		/// </summary>
		/// <param name="strWhere">参数化删除条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual bool Delete(string strWhere, Dictionary<string, object> dict = null)
		{
			string strSQL = "delete from CommonProduct where 1=1 " + strWhere;
			return _DB.ExeSQLResult(strSQL, dict);
		}
		/// <summary>
		/// 删除一条或多条记录（异步方式）
		/// </summary>
		/// <param name="strWhere">参数化删除条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual async Task<bool> DeleteAsync(string strWhere, Dictionary<string, object> dict = null)
		{
			string strSQL = "delete from CommonProduct where 1=1 " + strWhere;
			return await Task.Run(() => _DB.ExeSQLResult(strSQL, dict));
		}
		#endregion
		
		#region 修改
		/// <summary>
		/// 更新一条记录
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <returns></returns>
		public virtual bool Update(CommonProductEntity entity)
		{
			Dictionary<string, object> dict = new Dictionary<string, object>();
			GetParameters(entity, dict);
			string strSQL = "Update CommonProduct SET "+
			"TableName = @TableName,"+
			"ProductName = @ProductName,"+
			"ProductNum = @ProductNum,"+
			"ProductType = @ProductType,"+
			"Unit = @Unit,"+
			"ProductThumb = @ProductThumb,"+
			"ProductPic = @ProductPic,"+
			"ServiceTermUnit = @ServiceTermUnit,"+
			"ServiceTerm = @ServiceTerm,"+
			"Price = @Price,"+
			"Price_Market = @Price_Market,"+
			"Price_Activity = @Price_Activity,"+
			"Price_Settlement = @Price_Settlement,"+
			"Price_Member = @Price_Member,"+
			"Price_Agent = @Price_Agent,"+
			"IsStockOutBuy = @IsStockOutBuy,"+
			"IsWholesale = @IsWholesale,"+
			"Price_Wholesale1 = @Price_Wholesale1,"+
			"Price_Wholesale2 = @Price_Wholesale2,"+
			"Price_Wholesale3 = @Price_Wholesale3,"+
			"Number_Wholesale1 = @Number_Wholesale1,"+
			"Number_Wholesale2 = @Number_Wholesale2,"+
			"Number_Wholesale3 = @Number_Wholesale3,"+
			"PresentID = @PresentID,"+
			"PresentNumber = @PresentNumber,"+
			"PresentPoint = @PresentPoint,"+
			"PresentExp = @PresentExp,"+
			"PresentMoney = @PresentMoney,"+
			"StocksProject = @StocksProject,"+
			"SalePromotionType = @SalePromotionType,"+
			"AlarmNum = @AlarmNum,"+
			"BuyTimes = @BuyTimes,"+
			"MinNumber = @MinNumber,"+
			"Discount = @Discount,"+
			"IncludeTax = @IncludeTax,"+
			"TaxRate = @TaxRate,"+
			"Properties = @Properties,"+
			"Weight = @Weight,"+
			"LimitNum = @LimitNum,"+
			"IsEnableSale = @IsEnableSale,"+
			"IsSingleSell = @IsSingleSell,"+
			"ProductKind = @ProductKind,"+
			"DependentProducts = @DependentProducts,"+
			"Stocks = @Stocks,"+
			"OrderNum = @OrderNum,"+
			"DownloadUrl = @DownloadUrl,"+
			"Remark = @Remark,"+
			"ProductCharacter = @ProductCharacter,"+
			"Keyword = @Keyword,"+
			"ProducerName = @ProducerName,"+
			"TrademarkName = @TrademarkName,"+
			"BarCode = @BarCode,"+
			"ProductIntro = @ProductIntro,"+
			"ProductExplain = @ProductExplain,"+
			"IsNew = @IsNew,"+
			"IsHot = @IsHot,"+
			"IsBest = @IsBest,"+
			"Stars = @Stars,"+
			"Minimum = @Minimum,"+
			"MultiplePhoto = @MultiplePhoto,"+
			"IsEnableHP = @IsEnableHP"+
			" WHERE "+
			
			"ProductID = @ProductID"; 
			
			return _DB.ExeSQLResult(strSQL, dict);
		}
		/// <summary>
		/// 更新一条记录（异步方式）
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <returns></returns>
		public virtual async Task<bool> UpdateAsync(CommonProductEntity entity)
		{
			Dictionary<string, object> dict = new Dictionary<string, object>();
			GetParameters(entity, dict);
			string strSQL = "Update CommonProduct SET "+
			"TableName = @TableName,"+
			"ProductName = @ProductName,"+
			"ProductNum = @ProductNum,"+
			"ProductType = @ProductType,"+
			"Unit = @Unit,"+
			"ProductThumb = @ProductThumb,"+
			"ProductPic = @ProductPic,"+
			"ServiceTermUnit = @ServiceTermUnit,"+
			"ServiceTerm = @ServiceTerm,"+
			"Price = @Price,"+
			"Price_Market = @Price_Market,"+
			"Price_Activity = @Price_Activity,"+
			"Price_Settlement = @Price_Settlement,"+
			"Price_Member = @Price_Member,"+
			"Price_Agent = @Price_Agent,"+
			"IsStockOutBuy = @IsStockOutBuy,"+
			"IsWholesale = @IsWholesale,"+
			"Price_Wholesale1 = @Price_Wholesale1,"+
			"Price_Wholesale2 = @Price_Wholesale2,"+
			"Price_Wholesale3 = @Price_Wholesale3,"+
			"Number_Wholesale1 = @Number_Wholesale1,"+
			"Number_Wholesale2 = @Number_Wholesale2,"+
			"Number_Wholesale3 = @Number_Wholesale3,"+
			"PresentID = @PresentID,"+
			"PresentNumber = @PresentNumber,"+
			"PresentPoint = @PresentPoint,"+
			"PresentExp = @PresentExp,"+
			"PresentMoney = @PresentMoney,"+
			"StocksProject = @StocksProject,"+
			"SalePromotionType = @SalePromotionType,"+
			"AlarmNum = @AlarmNum,"+
			"BuyTimes = @BuyTimes,"+
			"MinNumber = @MinNumber,"+
			"Discount = @Discount,"+
			"IncludeTax = @IncludeTax,"+
			"TaxRate = @TaxRate,"+
			"Properties = @Properties,"+
			"Weight = @Weight,"+
			"LimitNum = @LimitNum,"+
			"IsEnableSale = @IsEnableSale,"+
			"IsSingleSell = @IsSingleSell,"+
			"ProductKind = @ProductKind,"+
			"DependentProducts = @DependentProducts,"+
			"Stocks = @Stocks,"+
			"OrderNum = @OrderNum,"+
			"DownloadUrl = @DownloadUrl,"+
			"Remark = @Remark,"+
			"ProductCharacter = @ProductCharacter,"+
			"Keyword = @Keyword,"+
			"ProducerName = @ProducerName,"+
			"TrademarkName = @TrademarkName,"+
			"BarCode = @BarCode,"+
			"ProductIntro = @ProductIntro,"+
			"ProductExplain = @ProductExplain,"+
			"IsNew = @IsNew,"+
			"IsHot = @IsHot,"+
			"IsBest = @IsBest,"+
			"Stars = @Stars,"+
			"Minimum = @Minimum,"+
			"MultiplePhoto = @MultiplePhoto,"+
			"IsEnableHP = @IsEnableHP"+
			" WHERE "+
			
			"ProductID = @ProductID"; 
			return await Task.Run(() => _DB.ExeSQLResult(strSQL, dict));
		}

		/// <summary>
		/// 修改一条或多条记录
		/// </summary>
		/// <param name="strColumns">参数化要修改的列（如：ID = @ID,Name = @Name）</param>
		/// <param name="dictColumns">包含要修改的名称和值的集合,对应strColumns参数中要修改列的值</param>
		/// <param name="strWhere">参数化修改条件(例如: and ID = @ID)</param>
		/// <param name="dictWhere">包含查询名称和值的集合,对应strWhere参数中的值</param>
		/// <returns></returns>
		public virtual bool Update(string strColumns, Dictionary<string, object> dictColumns = null, string strWhere = "", Dictionary<string, object> dictWhere = null)
		{
			if (string.IsNullOrEmpty(strColumns))
				return false;

			strColumns = StringHelper.ReplaceIgnoreCase(strColumns, "@", "@UP_");
			string strSQL = "Update CommonProduct SET " + strColumns + " where 1=1 " + strWhere;

			Dictionary<string, object> dict = new Dictionary<string, object>();
			//生成要修改列的参数
			foreach (KeyValuePair<string, object> kvp in dictColumns)
			{
				dict.Add("@UP_" + kvp.Key,kvp.Value);
			}
			//生成查询条件的参数
			foreach (KeyValuePair<string, object> kvp in dictWhere)
			{
				dict.Add(kvp.Key, kvp.Value);
			}

			return _DB.ExeSQLResult(strSQL, dict);
		}
		/// <summary>
		/// 修改一条或多条记录（异步方式）
		/// </summary>
		/// <param name="strColumns">参数化要修改的列（如：ID = @ID,Name = @Name）</param>
		/// <param name="dictColumns">包含要修改的名称和值的集合,对应strColumns参数中要修改列的值</param>
		/// <param name="strWhere">参数化修改条件(例如: and ID = @ID)</param>
		/// <param name="dictWhere">包含查询名称和值的集合,对应strWhere参数中的值</param>
		/// <returns></returns>
		public virtual async Task<bool> UpdateAsync(string strColumns, Dictionary<string, object> dictColumns = null, string strWhere = "", Dictionary<string, object> dictWhere = null)
		{
			if (string.IsNullOrEmpty(strColumns))
				return false;

			strColumns = StringHelper.ReplaceIgnoreCase(strColumns, "@", "@UP_");
			string strSQL = "Update CommonProduct SET " + strColumns + " where 1=1 " + strWhere;

			Dictionary<string, object> dict = new Dictionary<string, object>();
			//生成要修改列的参数
			foreach (KeyValuePair<string, object> kvp in dictColumns)
			{
				dict.Add("@UP_" + kvp.Key, kvp.Value);
			}
			//生成查询条件的参数
			foreach (KeyValuePair<string, object> kvp in dictWhere)
			{
				dict.Add(kvp.Key, kvp.Value);
			}
			return await Task.Run(() => _DB.ExeSQLResult(strSQL, dict));
		}
		#endregion
		
		#region 得到实体
		/// <summary>
		/// 通过主键返回第一条信息的实体类。
		/// </summary>
		/// <returns></returns>
		public CommonProductEntity GetEntity(System.Int32 productID)
		{
			string strCondition = string.Empty;
			strCondition += " and ProductID = @ProductID";
			
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("ProductID", productID);
			
			return GetEntity(strCondition,dict);
		}
		/// <summary>
		/// 通过主键返回第一条信息的实体类。
		/// </summary>
		/// <returns></returns>
		public async Task<CommonProductEntity> GetEntityAsync(System.Int32 productID)
		{
			string strCondition = string.Empty;
			strCondition += " and ProductID = @ProductID";
			
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("ProductID", productID);
			
			return await GetEntityAsync(strCondition,dict);
		}
		
		/// <summary>
		/// 获取实体
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual CommonProductEntity GetEntity(string strWhere, Dictionary<string, object> dict = null)
		{
			CommonProductEntity obj = null;
			string strSQL = "select top 1 * from CommonProduct where 1=1 " + strWhere;
			using (NullableDataReader reader = _DB.GetDataReader(strSQL, dict))
			{
				if (reader.Read())
				{
					obj = GetEntityFromrdr(reader);
				}
			}
			return obj;
		}
		/// <summary>
		/// 获取实体（异步方式）
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual async Task<CommonProductEntity> GetEntityAsync(string strWhere, Dictionary<string, object> dict = null)
		{
			CommonProductEntity obj = null;
			string strSQL = "select top 1 * from CommonProduct where 1=1 " + strWhere;
			using (NullableDataReader reader = await Task.Run(() => _DB.GetDataReader(strSQL, dict)))
			{
				if (reader.Read())
				{
					obj = GetEntityFromrdr(reader);
				}
			}
			return obj;
		}
		#endregion
		
		#region 得到实体列表
		/// <summary>
		/// 得到实体列表
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual IList<CommonProductEntity> GetEntityList(string strWhere="", Dictionary<string, object> dict = null)
		{
			IList<CommonProductEntity> list = new List<CommonProductEntity>();
			string strSQL = "select * from CommonProduct where 1=1 ";
			if(!string.IsNullOrEmpty(strWhere))
			{
				strSQL += strWhere;
			}
			using (NullableDataReader reader = _DB.GetDataReader(strSQL, dict))
			{
				while (reader.Read())
				{
					list.Add(GetEntityFromrdr(reader));
				}
			}
			return list;
		}
		/// <summary>
		/// 得到实体列表（异步方式）
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual async Task<IList<CommonProductEntity>> GetEntityListAsync(string strWhere = "", Dictionary<string, object> dict = null)
		{
			IList<CommonProductEntity> list = new List<CommonProductEntity>();
			string strSQL = "select * from CommonProduct where 1=1 ";
			if (!string.IsNullOrEmpty(strWhere))
			{
				strSQL += strWhere;
			}
			using (NullableDataReader reader = await Task.Run(() => _DB.GetDataReader(strSQL, dict)))
			{
				while (reader.Read())
				{
					list.Add(GetEntityFromrdr(reader));
				}
			}
			return list;
		}
		#endregion
		
		#region 得到数据列表
		/// <summary>
		/// 返回所有信息
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual DataTable GetAllData(string strWhere = "", Dictionary<string, object> dict = null)
		{
			string strSQL = "select * from CommonProduct where 1=1 ";
			if(!string.IsNullOrEmpty(strWhere))
			{
				strSQL += strWhere;
			}
			return _DB.GetDataTable(strSQL, dict);
		}
		/// <summary>
		/// 返回所有信息（异步方式）
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual async Task<DataTable> GetAllDataAsync(string strWhere = "", Dictionary<string, object> dict = null)
		{
			string strSQL = "select * from CommonProduct where 1=1 ";
			if(!string.IsNullOrEmpty(strWhere))
			{
				strSQL += strWhere;
			}
			return await Task.Run(() => _DB.GetDataTable(strSQL, dict));
		}

		/// <summary>
		/// 返回所有信息
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <param name="strExtended">返回的指定列(例如: extended = id + name 或 distinct name)</param>
		/// <returns></returns>
		public virtual DataTable GetAllData(string strWhere = "", Dictionary<string, object> dict = null, string strExtended="*")
		{
			string strSQL = "select " + strExtended + " from CommonProduct where 1=1 ";
			if(!string.IsNullOrEmpty(strWhere))
			{
				strSQL += strWhere;
			}
			return _DB.GetDataTable(strSQL, dict);
		}
		/// <summary>
		/// 返回所有信息（异步方式）
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <param name="strExtended">返回的指定列(例如: extended = id + name 或 distinct name)</param>
		/// <returns></returns>
		public virtual async Task<DataTable> GetAllDataAsync(string strWhere = "", Dictionary<string, object> dict = null, string strExtended = "*")
		{
			string strSQL = "select " + strExtended + " from CommonProduct where 1=1 ";
			if(!string.IsNullOrEmpty(strWhere))
			{
				strSQL += strWhere;
			}
			return await Task.Run(() => _DB.GetDataTable(strSQL, dict));
		}
		#endregion
		
		#region 分页
		/// <summary>
		/// 通过存储过程"Common_GetList"，得到分页后的数据
		/// </summary>
		/// <param name="startRowIndexId">开始行索引</param>
        /// <param name="maxNumberRows">每页最大显示数量</param>
        /// <param name="Filter">查询条件(例如: Name = 'name' and id=1 )</param>
		/// <param name="Total">输出参数：查询总数</param>
		/// <returns></returns>
		public IList<CommonProductEntity> GetList(int startRowIndexId, int maxNumberRows,string Filter, out int Total)
		{
			Total = 0;
			return GetList(startRowIndexId,maxNumberRows,"","","",Filter,"",out Total);
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
		public virtual IList<CommonProductEntity> GetList(int startRowIndexId, int maxNumberRows, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total)
		{
			IList<CommonProductEntity> list = new List<CommonProductEntity>();
			if (string.IsNullOrEmpty(SortColumn))
			{
				SortColumn = "ProductID";
			}
			if (string.IsNullOrEmpty(StrColumn))
			{
				StrColumn = "*";
			}
			if (string.IsNullOrEmpty(Sorts))
			{
				Sorts = "DESC";
			}
			if (string.IsNullOrEmpty(TableName))
			{
				TableName = "CommonProduct";
			}
			string storedProcedureName = "Common_GetList";
			SqlParameter parmStartRows = new SqlParameter("StartRows", startRowIndexId);
			SqlParameter parmPageSize = new SqlParameter("PageSize", maxNumberRows);
			SqlParameter parmSortColumn = new SqlParameter("SortColumn", SortColumn);
			SqlParameter parmStrColumn = new SqlParameter("StrColumn", StrColumn);
			SqlParameter parmSorts = new SqlParameter("Sorts", Sorts);
			SqlParameter parmTableName = new SqlParameter("TableName", TableName);
			SqlParameter parmFilter = new SqlParameter("Filter", Filter);
			SqlParameter parmTotal = new SqlParameter("Total", SqlDbType.Int);
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
			using (NullableDataReader reader = _DB.GetDataReaderByProc(storedProcedureName, parameterArray))
			{
				while (reader.Read())
				{
					list.Add(GetEntityFromrdr(reader));
				}
			}
			Total = (int)parmTotal.Value;
			return list;
		}

		/// <summary>
		/// 通过存储过程"Common_GetListBySortColumn"，得到分页后的数据
		/// </summary>
		/// <param name="startRowIndexId">开始行索引</param>
        /// <param name="maxNumberRows">每页最大显示数量</param>
        /// <param name="Filter">查询条件(例如: Name = 'name' and id=1 )</param>
		/// <param name="Total">输出参数：查询总数</param>
		/// <returns></returns>
		public IList<CommonProductEntity> GetListBySortColumn(int startRowIndexId, int maxNumberRows,string Filter, out int Total)
		{
			Total = 0;
			return GetListBySortColumn(startRowIndexId,maxNumberRows,"","","","","",Filter,"",out Total);
		}
		/// <summary>
		/// 通过存储过程"Common_GetListBySortColumn"，得到分页后的数据
		/// </summary>
		/// <param name="startRowIndexId">开始行索引</param>
        /// <param name="maxNumberRows">每页最大显示数量</param>
		/// <param name="Sorts">排序方式（DESC,ASC）</param>
        /// <param name="Filter">查询条件(例如: Name = 'name' and id=1 )</param>
		/// <param name="Total">输出参数：查询总数</param>
		/// <returns></returns>
		public IList<CommonProductEntity> GetListBySortColumn(int startRowIndexId, int maxNumberRows,string Sorts,string Filter, out int Total)
		{
			Total = 0;
			return GetListBySortColumn(startRowIndexId,maxNumberRows,"","","","",Sorts,Filter,"",out Total);
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
		public virtual IList<CommonProductEntity> GetListBySortColumn(int startRowIndexId, int maxNumberRows, string PrimaryColumn, string SortColumnDbType, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total)
		{
			IList<CommonProductEntity> list = new List<CommonProductEntity>();
			if (string.IsNullOrEmpty(PrimaryColumn))
			{
				PrimaryColumn = "ProductID";
			}
			if (string.IsNullOrEmpty(SortColumnDbType))
			{
				SortColumnDbType = "int";
			}
			if (string.IsNullOrEmpty(SortColumn))
			{
				SortColumn = "ProductID";
			}
			if (string.IsNullOrEmpty(StrColumn))
			{
				StrColumn = "*";
			}
			if (string.IsNullOrEmpty(Sorts))
			{
				Sorts = "DESC";
			}
			if (string.IsNullOrEmpty(TableName))
			{
				TableName = "CommonProduct";
			}
			string storedProcedureName = "Common_GetListBySortColumn";
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
			using (NullableDataReader reader = _DB.GetDataReaderByProc(storedProcedureName, parameterArray))
			{
				while (reader.Read())
				{
					list.Add(GetEntityFromrdr(reader));
				}
			}
			Total = (int)parmTotal.Value;
			return list;
		}
		#endregion
		
		#region 辅助方法
		/// <summary>
		/// 把实体类转换成键/值对集合
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="dict"></param>
		private static void GetParameters(CommonProductEntity entity, Dictionary<string, object> dict)
		{
			dict.Add("ProductID", entity.ProductID);
			dict.Add("TableName", entity.TableName);
			dict.Add("ProductName", entity.ProductName);
			dict.Add("ProductNum", entity.ProductNum);
			dict.Add("ProductType", entity.ProductType);
			dict.Add("Unit", entity.Unit);
			dict.Add("ProductThumb", entity.ProductThumb);
			dict.Add("ProductPic", entity.ProductPic);
			dict.Add("ServiceTermUnit", entity.ServiceTermUnit);
			dict.Add("ServiceTerm", entity.ServiceTerm);
			dict.Add("Price", entity.Price);
			dict.Add("Price_Market", entity.Price_Market);
			dict.Add("Price_Activity", entity.Price_Activity);
			dict.Add("Price_Settlement", entity.Price_Settlement);
			dict.Add("Price_Member", entity.Price_Member);
			dict.Add("Price_Agent", entity.Price_Agent);
			dict.Add("IsStockOutBuy", entity.IsStockOutBuy);
			dict.Add("IsWholesale", entity.IsWholesale);
			dict.Add("Price_Wholesale1", entity.Price_Wholesale1);
			dict.Add("Price_Wholesale2", entity.Price_Wholesale2);
			dict.Add("Price_Wholesale3", entity.Price_Wholesale3);
			dict.Add("Number_Wholesale1", entity.Number_Wholesale1);
			dict.Add("Number_Wholesale2", entity.Number_Wholesale2);
			dict.Add("Number_Wholesale3", entity.Number_Wholesale3);
			dict.Add("PresentID", entity.PresentID);
			dict.Add("PresentNumber", entity.PresentNumber);
			dict.Add("PresentPoint", entity.PresentPoint);
			dict.Add("PresentExp", entity.PresentExp);
			dict.Add("PresentMoney", entity.PresentMoney);
			dict.Add("StocksProject", entity.StocksProject);
			dict.Add("SalePromotionType", entity.SalePromotionType);
			dict.Add("AlarmNum", entity.AlarmNum);
			dict.Add("BuyTimes", entity.BuyTimes);
			dict.Add("MinNumber", entity.MinNumber);
			dict.Add("Discount", entity.Discount);
			dict.Add("IncludeTax", entity.IncludeTax);
			dict.Add("TaxRate", entity.TaxRate);
			dict.Add("Properties", entity.Properties);
			dict.Add("Weight", entity.Weight);
			dict.Add("LimitNum", entity.LimitNum);
			dict.Add("IsEnableSale", entity.IsEnableSale);
			dict.Add("IsSingleSell", entity.IsSingleSell);
			dict.Add("ProductKind", entity.ProductKind);
			dict.Add("DependentProducts", entity.DependentProducts);
			dict.Add("Stocks", entity.Stocks);
			dict.Add("OrderNum", entity.OrderNum);
			dict.Add("DownloadUrl", entity.DownloadUrl);
			dict.Add("Remark", entity.Remark);
			dict.Add("ProductCharacter", entity.ProductCharacter);
			dict.Add("Keyword", entity.Keyword);
			dict.Add("ProducerName", entity.ProducerName);
			dict.Add("TrademarkName", entity.TrademarkName);
			dict.Add("BarCode", entity.BarCode);
			dict.Add("ProductIntro", entity.ProductIntro);
			dict.Add("ProductExplain", entity.ProductExplain);
			dict.Add("IsNew", entity.IsNew);
			dict.Add("IsHot", entity.IsHot);
			dict.Add("IsBest", entity.IsBest);
			dict.Add("Stars", entity.Stars);
			dict.Add("Minimum", entity.Minimum);
			dict.Add("MultiplePhoto", entity.MultiplePhoto);
			dict.Add("IsEnableHP", entity.IsEnableHP);
		}
		/// <summary>
		/// 通过数据读取器生成实体类
		/// </summary>
		/// <param name="rdr"></param>
		/// <returns></returns>
		private static CommonProductEntity GetEntityFromrdr(NullableDataReader rdr)
		{
			CommonProductEntity info = new CommonProductEntity();
			info.ProductID = rdr.GetInt32("ProductID");
			info.TableName = rdr.GetString("TableName");
			info.ProductName = rdr.GetString("ProductName");
			info.ProductNum = rdr.GetString("ProductNum");
			info.ProductType = rdr.GetInt32("ProductType");
			info.Unit = rdr.GetString("Unit");
			info.ProductThumb = rdr.GetString("ProductThumb");
			info.ProductPic = rdr.GetString("ProductPic");
			info.ServiceTermUnit = rdr.GetInt32("ServiceTermUnit");
			info.ServiceTerm = rdr.GetDouble("ServiceTerm");
			info.Price = rdr.GetDecimal("Price");
			info.Price_Market = rdr.GetDecimal("Price_Market");
			info.Price_Activity = rdr.GetDecimal("Price_Activity");
			info.Price_Settlement = rdr.GetDecimal("Price_Settlement");
			info.Price_Member = rdr.GetDecimal("Price_Member");
			info.Price_Agent = rdr.GetDecimal("Price_Agent");
			info.IsStockOutBuy = rdr.GetBoolean("IsStockOutBuy");
			info.IsWholesale = rdr.GetBoolean("IsWholesale");
			info.Price_Wholesale1 = rdr.GetDecimal("Price_Wholesale1");
			info.Price_Wholesale2 = rdr.GetDecimal("Price_Wholesale2");
			info.Price_Wholesale3 = rdr.GetDecimal("Price_Wholesale3");
			info.Number_Wholesale1 = rdr.GetInt32("Number_Wholesale1");
			info.Number_Wholesale2 = rdr.GetInt32("Number_Wholesale2");
			info.Number_Wholesale3 = rdr.GetInt32("Number_Wholesale3");
			info.PresentID = rdr.GetInt32("PresentID");
			info.PresentNumber = rdr.GetInt32("PresentNumber");
			info.PresentPoint = rdr.GetInt32("PresentPoint");
			info.PresentExp = rdr.GetInt32("PresentExp");
			info.PresentMoney = rdr.GetDecimal("PresentMoney");
			info.StocksProject = rdr.GetInt32("StocksProject");
			info.SalePromotionType = rdr.GetInt32("SalePromotionType");
			info.AlarmNum = rdr.GetInt32("AlarmNum");
			info.BuyTimes = rdr.GetInt32("BuyTimes");
			info.MinNumber = rdr.GetInt32("MinNumber");
			info.Discount = rdr.GetDouble("Discount");
			info.IncludeTax = rdr.GetInt32("IncludeTax");
			info.TaxRate = rdr.GetDouble("TaxRate");
			info.Properties = rdr.GetString("Properties");
			info.Weight = rdr.GetDouble("Weight");
			info.LimitNum = rdr.GetInt32("LimitNum");
			info.IsEnableSale = rdr.GetBoolean("IsEnableSale");
			info.IsSingleSell = rdr.GetBoolean("IsSingleSell");
			info.ProductKind = rdr.GetInt32("ProductKind");
			info.DependentProducts = rdr.GetString("DependentProducts");
			info.Stocks = rdr.GetInt32("Stocks");
			info.OrderNum = rdr.GetInt32("OrderNum");
			info.DownloadUrl = rdr.GetString("DownloadUrl");
			info.Remark = rdr.GetString("Remark");
			info.ProductCharacter = rdr.GetInt32("ProductCharacter");
			info.Keyword = rdr.GetString("Keyword");
			info.ProducerName = rdr.GetString("ProducerName");
			info.TrademarkName = rdr.GetString("TrademarkName");
			info.BarCode = rdr.GetString("BarCode");
			info.ProductIntro = rdr.GetString("ProductIntro");
			info.ProductExplain = rdr.GetString("ProductExplain");
			info.IsNew = rdr.GetBoolean("IsNew");
			info.IsHot = rdr.GetBoolean("IsHot");
			info.IsBest = rdr.GetBoolean("IsBest");
			info.Stars = rdr.GetInt32("Stars");
			info.Minimum = rdr.GetInt32("Minimum");
			info.MultiplePhoto = rdr.GetString("MultiplePhoto");
			info.IsEnableHP = rdr.GetBoolean("IsEnableHP");
			return info;
		}
		#endregion
	}
}