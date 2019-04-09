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
	/// 数据库表：Store 的仓储实现类.
	/// </summary>
	public partial class StoreRepositoryADO : IStoreRepositoryADO
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
		public StoreRepositoryADO(IDBOperator DB)
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
			string strSQL = "select " + statistic + " from Store where 1=1 ";
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
			string strSQL = "select " + statistic + " from Store where 1=1 ";
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
			return _DB.GetMaxID("Store", "ID");
		}
		/// <summary>
		/// 得到数据表中第一个主键的最大数值（异步方式）
		/// </summary>
		/// <returns></returns>
		public virtual async Task<int> GetMaxIDAsync()
		{
			return await Task.Run(() => _DB.GetMaxID("Store", "ID"));
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
		public virtual bool Add(StoreEntity entity)
		{
			
			Dictionary<string, object> dict = new Dictionary<string, object>();
			GetParameters(entity,dict);

			string strSQL = "insert into Store ("+
							"StoreMerchantID,"+
							"StoreType,"+
							"StoreName,"+
							"StoreLinkman,"+
							"StoreLinkmanPosition,"+
							"StoreLinkmanTel,"+
							"StoreLinkmanMobile,"+
							"StoreSize,"+
							"StoreNum,"+
							"BusinessHours1,"+
							"BusinessHours2,"+
							"EstimatedNum,"+
							"StoreAccountName,"+
							"StoreBankHeadOffice,"+
							"StoreBankHeadOfficeOther,"+
							"StoreBankBranch,"+
							"StoreBankBranchProvince,"+
							"StoreBankBranchCity,"+
							"StoreBankBranchArea,"+
							"StoreBankAccount,"+
							"StoreZipCode,"+
							"StoreProvince,"+
							"StoreCity,"+
							"StoreArea,"+
							"StoreAddress,"+
							"StoreIDCardPic,"+
							"StoreFieldPic1,"+
							"StoreFieldPic2,"+
							"StoreConfirmLetterPic,"+
							"HouseRentalAgreementPic,"+
							"StoreStatus,"+
							"StoreRemark,"+
							"SaleID,"+
							"SaleManageID,"+
							"SaleCityManageID,"+
							"SaleLargeAreaManageID,"+
							"ProductIDs) "+
							"values("+
							"@StoreMerchantID,"+
							"@StoreType,"+
							"@StoreName,"+
							"@StoreLinkman,"+
							"@StoreLinkmanPosition,"+
							"@StoreLinkmanTel,"+
							"@StoreLinkmanMobile,"+
							"@StoreSize,"+
							"@StoreNum,"+
							"@BusinessHours1,"+
							"@BusinessHours2,"+
							"@EstimatedNum,"+
							"@StoreAccountName,"+
							"@StoreBankHeadOffice,"+
							"@StoreBankHeadOfficeOther,"+
							"@StoreBankBranch,"+
							"@StoreBankBranchProvince,"+
							"@StoreBankBranchCity,"+
							"@StoreBankBranchArea,"+
							"@StoreBankAccount,"+
							"@StoreZipCode,"+
							"@StoreProvince,"+
							"@StoreCity,"+
							"@StoreArea,"+
							"@StoreAddress,"+
							"@StoreIDCardPic,"+
							"@StoreFieldPic1,"+
							"@StoreFieldPic2,"+
							"@StoreConfirmLetterPic,"+
							"@HouseRentalAgreementPic,"+
							"@StoreStatus,"+
							"@StoreRemark,"+
							"@SaleID,"+
							"@SaleManageID,"+
							"@SaleCityManageID,"+
							"@SaleLargeAreaManageID,"+
							"@ProductIDs)";
			
			return _DB.ExeSQLResult(strSQL,dict);
		}
		/// <summary>
		/// 增加一条记录（异步方式）
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <returns></returns>
		public virtual async Task<bool> AddAsync(StoreEntity entity)
		{
			
			Dictionary<string, object> dict = new Dictionary<string, object>();
			GetParameters(entity, dict);

			string strSQL = "insert into Store ("+
							"StoreMerchantID,"+
							"StoreType,"+
							"StoreName,"+
							"StoreLinkman,"+
							"StoreLinkmanPosition,"+
							"StoreLinkmanTel,"+
							"StoreLinkmanMobile,"+
							"StoreSize,"+
							"StoreNum,"+
							"BusinessHours1,"+
							"BusinessHours2,"+
							"EstimatedNum,"+
							"StoreAccountName,"+
							"StoreBankHeadOffice,"+
							"StoreBankHeadOfficeOther,"+
							"StoreBankBranch,"+
							"StoreBankBranchProvince,"+
							"StoreBankBranchCity,"+
							"StoreBankBranchArea,"+
							"StoreBankAccount,"+
							"StoreZipCode,"+
							"StoreProvince,"+
							"StoreCity,"+
							"StoreArea,"+
							"StoreAddress,"+
							"StoreIDCardPic,"+
							"StoreFieldPic1,"+
							"StoreFieldPic2,"+
							"StoreConfirmLetterPic,"+
							"HouseRentalAgreementPic,"+
							"StoreStatus,"+
							"StoreRemark,"+
							"SaleID,"+
							"SaleManageID,"+
							"SaleCityManageID,"+
							"SaleLargeAreaManageID,"+
							"ProductIDs) "+
							"values("+
							"@StoreMerchantID,"+
							"@StoreType,"+
							"@StoreName,"+
							"@StoreLinkman,"+
							"@StoreLinkmanPosition,"+
							"@StoreLinkmanTel,"+
							"@StoreLinkmanMobile,"+
							"@StoreSize,"+
							"@StoreNum,"+
							"@BusinessHours1,"+
							"@BusinessHours2,"+
							"@EstimatedNum,"+
							"@StoreAccountName,"+
							"@StoreBankHeadOffice,"+
							"@StoreBankHeadOfficeOther,"+
							"@StoreBankBranch,"+
							"@StoreBankBranchProvince,"+
							"@StoreBankBranchCity,"+
							"@StoreBankBranchArea,"+
							"@StoreBankAccount,"+
							"@StoreZipCode,"+
							"@StoreProvince,"+
							"@StoreCity,"+
							"@StoreArea,"+
							"@StoreAddress,"+
							"@StoreIDCardPic,"+
							"@StoreFieldPic1,"+
							"@StoreFieldPic2,"+
							"@StoreConfirmLetterPic,"+
							"@HouseRentalAgreementPic,"+
							"@StoreStatus,"+
							"@StoreRemark,"+
							"@SaleID,"+
							"@SaleManageID,"+
							"@SaleCityManageID,"+
							"@SaleLargeAreaManageID,"+
							"@ProductIDs)";
			
			return await Task.Run(() => _DB.ExeSQLResult(strSQL, dict));
		}

		/// <summary>
		/// 增加一条记录，返回新的ID号。需要有一个单一主键，并且开启有标识符属性
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <returns></returns>
		public virtual int Insert(StoreEntity entity)
		{
						
			Dictionary<string, object> dict = new Dictionary<string, object>();
			GetParameters(entity,dict);

			string strSQL = "insert into Store ("+
							"StoreMerchantID,"+
							"StoreType,"+
							"StoreName,"+
							"StoreLinkman,"+
							"StoreLinkmanPosition,"+
							"StoreLinkmanTel,"+
							"StoreLinkmanMobile,"+
							"StoreSize,"+
							"StoreNum,"+
							"BusinessHours1,"+
							"BusinessHours2,"+
							"EstimatedNum,"+
							"StoreAccountName,"+
							"StoreBankHeadOffice,"+
							"StoreBankHeadOfficeOther,"+
							"StoreBankBranch,"+
							"StoreBankBranchProvince,"+
							"StoreBankBranchCity,"+
							"StoreBankBranchArea,"+
							"StoreBankAccount,"+
							"StoreZipCode,"+
							"StoreProvince,"+
							"StoreCity,"+
							"StoreArea,"+
							"StoreAddress,"+
							"StoreIDCardPic,"+
							"StoreFieldPic1,"+
							"StoreFieldPic2,"+
							"StoreConfirmLetterPic,"+
							"HouseRentalAgreementPic,"+
							"StoreStatus,"+
							"StoreRemark,"+
							"SaleID,"+
							"SaleManageID,"+
							"SaleCityManageID,"+
							"SaleLargeAreaManageID,"+
							"ProductIDs) "+
							"values("+
							"@StoreMerchantID,"+
							"@StoreType,"+
							"@StoreName,"+
							"@StoreLinkman,"+
							"@StoreLinkmanPosition,"+
							"@StoreLinkmanTel,"+
							"@StoreLinkmanMobile,"+
							"@StoreSize,"+
							"@StoreNum,"+
							"@BusinessHours1,"+
							"@BusinessHours2,"+
							"@EstimatedNum,"+
							"@StoreAccountName,"+
							"@StoreBankHeadOffice,"+
							"@StoreBankHeadOfficeOther,"+
							"@StoreBankBranch,"+
							"@StoreBankBranchProvince,"+
							"@StoreBankBranchCity,"+
							"@StoreBankBranchArea,"+
							"@StoreBankAccount,"+
							"@StoreZipCode,"+
							"@StoreProvince,"+
							"@StoreCity,"+
							"@StoreArea,"+
							"@StoreAddress,"+
							"@StoreIDCardPic,"+
							"@StoreFieldPic1,"+
							"@StoreFieldPic2,"+
							"@StoreConfirmLetterPic,"+
							"@HouseRentalAgreementPic,"+
							"@StoreStatus,"+
							"@StoreRemark,"+
							"@SaleID,"+
							"@SaleManageID,"+
							"@SaleCityManageID,"+
							"@SaleLargeAreaManageID,"+
							"@ProductIDs)";
			return _DB.ReturnID(strSQL,dict);
		}
		/// <summary>
		/// 增加一条记录，返回新的ID号。需要有一个单一主键，并且开启有标识符属性（异步方式）
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <returns></returns>
		public virtual async Task<int> InsertAsync(StoreEntity entity)
		{
						
			Dictionary<string, object> dict = new Dictionary<string, object>();
			GetParameters(entity,dict);

			string strSQL = "insert into Store ("+
							"StoreMerchantID,"+
							"StoreType,"+
							"StoreName,"+
							"StoreLinkman,"+
							"StoreLinkmanPosition,"+
							"StoreLinkmanTel,"+
							"StoreLinkmanMobile,"+
							"StoreSize,"+
							"StoreNum,"+
							"BusinessHours1,"+
							"BusinessHours2,"+
							"EstimatedNum,"+
							"StoreAccountName,"+
							"StoreBankHeadOffice,"+
							"StoreBankHeadOfficeOther,"+
							"StoreBankBranch,"+
							"StoreBankBranchProvince,"+
							"StoreBankBranchCity,"+
							"StoreBankBranchArea,"+
							"StoreBankAccount,"+
							"StoreZipCode,"+
							"StoreProvince,"+
							"StoreCity,"+
							"StoreArea,"+
							"StoreAddress,"+
							"StoreIDCardPic,"+
							"StoreFieldPic1,"+
							"StoreFieldPic2,"+
							"StoreConfirmLetterPic,"+
							"HouseRentalAgreementPic,"+
							"StoreStatus,"+
							"StoreRemark,"+
							"SaleID,"+
							"SaleManageID,"+
							"SaleCityManageID,"+
							"SaleLargeAreaManageID,"+
							"ProductIDs) "+
							"values("+
							"@StoreMerchantID,"+
							"@StoreType,"+
							"@StoreName,"+
							"@StoreLinkman,"+
							"@StoreLinkmanPosition,"+
							"@StoreLinkmanTel,"+
							"@StoreLinkmanMobile,"+
							"@StoreSize,"+
							"@StoreNum,"+
							"@BusinessHours1,"+
							"@BusinessHours2,"+
							"@EstimatedNum,"+
							"@StoreAccountName,"+
							"@StoreBankHeadOffice,"+
							"@StoreBankHeadOfficeOther,"+
							"@StoreBankBranch,"+
							"@StoreBankBranchProvince,"+
							"@StoreBankBranchCity,"+
							"@StoreBankBranchArea,"+
							"@StoreBankAccount,"+
							"@StoreZipCode,"+
							"@StoreProvince,"+
							"@StoreCity,"+
							"@StoreArea,"+
							"@StoreAddress,"+
							"@StoreIDCardPic,"+
							"@StoreFieldPic1,"+
							"@StoreFieldPic2,"+
							"@StoreConfirmLetterPic,"+
							"@HouseRentalAgreementPic,"+
							"@StoreStatus,"+
							"@StoreRemark,"+
							"@SaleID,"+
							"@SaleManageID,"+
							"@SaleCityManageID,"+
							"@SaleLargeAreaManageID,"+
							"@ProductIDs)";
			return await Task.Run(() => _DB.ReturnID(strSQL,dict));
		}

		/// <summary>
		/// 增加或更新一条记录
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsSave">是否增加</param>
		/// <returns></returns>
		public virtual bool AddOrUpdate(StoreEntity entity, bool IsSave)
		{
			return IsSave ? Add(entity) : Update(entity);
		}
		/// <summary>
		/// 增加或更新一条记录（异步方式）
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <param name="IsSave">是否增加</param>
		/// <returns></returns>
		public virtual async Task<bool> AddOrUpdateAsync(StoreEntity entity, bool IsSave)
		{
			return IsSave ? await AddAsync(entity) : await UpdateAsync(entity);
		}
		#endregion
		
		#region 删除
		/// <summary>
		/// 通过主键删除
		/// </summary>
		/// <returns></returns>
		public bool Delete(System.Int32 id)
		{
			string strSQL = "delete from Store where " +
			
			"ID = @ID"; 
			
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("ID", id);
			
			return _DB.ExeSQLResult(strSQL, dict);
		}
		/// <summary>
		/// 通过主键删除
		/// </summary>
		/// <returns></returns>
		public async Task<bool> DeleteAsync(System.Int32 id)
		{
			string strSQL = "delete from Store where " +
			
			"ID = @ID"; 
			
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("ID", id);
			
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
			string strSQL = "delete from Store where 1=1 " + strWhere;
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
			string strSQL = "delete from Store where 1=1 " + strWhere;
			return await Task.Run(() => _DB.ExeSQLResult(strSQL, dict));
		}
		#endregion
		
		#region 修改
		/// <summary>
		/// 更新一条记录
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <returns></returns>
		public virtual bool Update(StoreEntity entity)
		{
			Dictionary<string, object> dict = new Dictionary<string, object>();
			GetParameters(entity, dict);
			string strSQL = "Update Store SET "+
			"StoreMerchantID = @StoreMerchantID,"+
			"StoreType = @StoreType,"+
			"StoreName = @StoreName,"+
			"StoreLinkman = @StoreLinkman,"+
			"StoreLinkmanPosition = @StoreLinkmanPosition,"+
			"StoreLinkmanTel = @StoreLinkmanTel,"+
			"StoreLinkmanMobile = @StoreLinkmanMobile,"+
			"StoreSize = @StoreSize,"+
			"StoreNum = @StoreNum,"+
			"BusinessHours1 = @BusinessHours1,"+
			"BusinessHours2 = @BusinessHours2,"+
			"EstimatedNum = @EstimatedNum,"+
			"StoreAccountName = @StoreAccountName,"+
			"StoreBankHeadOffice = @StoreBankHeadOffice,"+
			"StoreBankHeadOfficeOther = @StoreBankHeadOfficeOther,"+
			"StoreBankBranch = @StoreBankBranch,"+
			"StoreBankBranchProvince = @StoreBankBranchProvince,"+
			"StoreBankBranchCity = @StoreBankBranchCity,"+
			"StoreBankBranchArea = @StoreBankBranchArea,"+
			"StoreBankAccount = @StoreBankAccount,"+
			"StoreZipCode = @StoreZipCode,"+
			"StoreProvince = @StoreProvince,"+
			"StoreCity = @StoreCity,"+
			"StoreArea = @StoreArea,"+
			"StoreAddress = @StoreAddress,"+
			"StoreIDCardPic = @StoreIDCardPic,"+
			"StoreFieldPic1 = @StoreFieldPic1,"+
			"StoreFieldPic2 = @StoreFieldPic2,"+
			"StoreConfirmLetterPic = @StoreConfirmLetterPic,"+
			"HouseRentalAgreementPic = @HouseRentalAgreementPic,"+
			"StoreStatus = @StoreStatus,"+
			"StoreRemark = @StoreRemark,"+
			"SaleID = @SaleID,"+
			"SaleManageID = @SaleManageID,"+
			"SaleCityManageID = @SaleCityManageID,"+
			"SaleLargeAreaManageID = @SaleLargeAreaManageID,"+
			"ProductIDs = @ProductIDs"+
			" WHERE "+
			
			"ID = @ID"; 
			
			return _DB.ExeSQLResult(strSQL, dict);
		}
		/// <summary>
		/// 更新一条记录（异步方式）
		/// </summary>
		/// <param name="entity">实体模型</param>
		/// <returns></returns>
		public virtual async Task<bool> UpdateAsync(StoreEntity entity)
		{
			Dictionary<string, object> dict = new Dictionary<string, object>();
			GetParameters(entity, dict);
			string strSQL = "Update Store SET "+
			"StoreMerchantID = @StoreMerchantID,"+
			"StoreType = @StoreType,"+
			"StoreName = @StoreName,"+
			"StoreLinkman = @StoreLinkman,"+
			"StoreLinkmanPosition = @StoreLinkmanPosition,"+
			"StoreLinkmanTel = @StoreLinkmanTel,"+
			"StoreLinkmanMobile = @StoreLinkmanMobile,"+
			"StoreSize = @StoreSize,"+
			"StoreNum = @StoreNum,"+
			"BusinessHours1 = @BusinessHours1,"+
			"BusinessHours2 = @BusinessHours2,"+
			"EstimatedNum = @EstimatedNum,"+
			"StoreAccountName = @StoreAccountName,"+
			"StoreBankHeadOffice = @StoreBankHeadOffice,"+
			"StoreBankHeadOfficeOther = @StoreBankHeadOfficeOther,"+
			"StoreBankBranch = @StoreBankBranch,"+
			"StoreBankBranchProvince = @StoreBankBranchProvince,"+
			"StoreBankBranchCity = @StoreBankBranchCity,"+
			"StoreBankBranchArea = @StoreBankBranchArea,"+
			"StoreBankAccount = @StoreBankAccount,"+
			"StoreZipCode = @StoreZipCode,"+
			"StoreProvince = @StoreProvince,"+
			"StoreCity = @StoreCity,"+
			"StoreArea = @StoreArea,"+
			"StoreAddress = @StoreAddress,"+
			"StoreIDCardPic = @StoreIDCardPic,"+
			"StoreFieldPic1 = @StoreFieldPic1,"+
			"StoreFieldPic2 = @StoreFieldPic2,"+
			"StoreConfirmLetterPic = @StoreConfirmLetterPic,"+
			"HouseRentalAgreementPic = @HouseRentalAgreementPic,"+
			"StoreStatus = @StoreStatus,"+
			"StoreRemark = @StoreRemark,"+
			"SaleID = @SaleID,"+
			"SaleManageID = @SaleManageID,"+
			"SaleCityManageID = @SaleCityManageID,"+
			"SaleLargeAreaManageID = @SaleLargeAreaManageID,"+
			"ProductIDs = @ProductIDs"+
			" WHERE "+
			
			"ID = @ID"; 
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
			string strSQL = "Update Store SET " + strColumns + " where 1=1 " + strWhere;

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
			string strSQL = "Update Store SET " + strColumns + " where 1=1 " + strWhere;

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
		public StoreEntity GetEntity(System.Int32 id)
		{
			string strCondition = string.Empty;
			strCondition += " and ID = @ID";
			
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("ID", id);
			
			return GetEntity(strCondition,dict);
		}
		/// <summary>
		/// 通过主键返回第一条信息的实体类。
		/// </summary>
		/// <returns></returns>
		public async Task<StoreEntity> GetEntityAsync(System.Int32 id)
		{
			string strCondition = string.Empty;
			strCondition += " and ID = @ID";
			
			Dictionary<string, object> dict = new Dictionary<string, object>();
			dict.Add("ID", id);
			
			return await GetEntityAsync(strCondition,dict);
		}
		
		/// <summary>
		/// 获取实体
		/// </summary>
		/// <param name="strWhere">参数化查询条件(例如: and Name = @Name )</param>
		/// <param name="dict">参数的名/值集合</param>
		/// <returns></returns>
		public virtual StoreEntity GetEntity(string strWhere, Dictionary<string, object> dict = null)
		{
			StoreEntity obj = null;
			string strSQL = "select top 1 * from Store where 1=1 " + strWhere;
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
		public virtual async Task<StoreEntity> GetEntityAsync(string strWhere, Dictionary<string, object> dict = null)
		{
			StoreEntity obj = null;
			string strSQL = "select top 1 * from Store where 1=1 " + strWhere;
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
		public virtual IList<StoreEntity> GetEntityList(string strWhere="", Dictionary<string, object> dict = null)
		{
			IList<StoreEntity> list = new List<StoreEntity>();
			string strSQL = "select * from Store where 1=1 ";
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
		public virtual async Task<IList<StoreEntity>> GetEntityListAsync(string strWhere = "", Dictionary<string, object> dict = null)
		{
			IList<StoreEntity> list = new List<StoreEntity>();
			string strSQL = "select * from Store where 1=1 ";
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
			string strSQL = "select * from Store where 1=1 ";
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
			string strSQL = "select * from Store where 1=1 ";
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
			string strSQL = "select " + strExtended + " from Store where 1=1 ";
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
			string strSQL = "select " + strExtended + " from Store where 1=1 ";
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
		public IList<StoreEntity> GetList(int startRowIndexId, int maxNumberRows,string Filter, out int Total)
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
		public virtual IList<StoreEntity> GetList(int startRowIndexId, int maxNumberRows, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total)
		{
			IList<StoreEntity> list = new List<StoreEntity>();
			if (string.IsNullOrEmpty(SortColumn))
			{
				SortColumn = "ID";
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
				TableName = "Store";
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
		public IList<StoreEntity> GetListBySortColumn(int startRowIndexId, int maxNumberRows,string Filter, out int Total)
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
		public IList<StoreEntity> GetListBySortColumn(int startRowIndexId, int maxNumberRows,string Sorts,string Filter, out int Total)
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
		public virtual IList<StoreEntity> GetListBySortColumn(int startRowIndexId, int maxNumberRows, string PrimaryColumn, string SortColumnDbType, string SortColumn, string StrColumn, string Sorts, string Filter, string TableName, out int Total)
		{
			IList<StoreEntity> list = new List<StoreEntity>();
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
				StrColumn = "*";
			}
			if (string.IsNullOrEmpty(Sorts))
			{
				Sorts = "DESC";
			}
			if (string.IsNullOrEmpty(TableName))
			{
				TableName = "Store";
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
		private static void GetParameters(StoreEntity entity, Dictionary<string, object> dict)
		{
			dict.Add("ID", entity.ID);
			dict.Add("StoreMerchantID", entity.StoreMerchantID);
			dict.Add("StoreType", entity.StoreType);
			dict.Add("StoreName", entity.StoreName);
			dict.Add("StoreLinkman", entity.StoreLinkman);
			dict.Add("StoreLinkmanPosition", entity.StoreLinkmanPosition);
			dict.Add("StoreLinkmanTel", entity.StoreLinkmanTel);
			dict.Add("StoreLinkmanMobile", entity.StoreLinkmanMobile);
			dict.Add("StoreSize", entity.StoreSize);
			dict.Add("StoreNum", entity.StoreNum);
			dict.Add("BusinessHours1", entity.BusinessHours1);
			dict.Add("BusinessHours2", entity.BusinessHours2);
			dict.Add("EstimatedNum", entity.EstimatedNum);
			dict.Add("StoreAccountName", entity.StoreAccountName);
			dict.Add("StoreBankHeadOffice", entity.StoreBankHeadOffice);
			dict.Add("StoreBankHeadOfficeOther", entity.StoreBankHeadOfficeOther);
			dict.Add("StoreBankBranch", entity.StoreBankBranch);
			dict.Add("StoreBankBranchProvince", entity.StoreBankBranchProvince);
			dict.Add("StoreBankBranchCity", entity.StoreBankBranchCity);
			dict.Add("StoreBankBranchArea", entity.StoreBankBranchArea);
			dict.Add("StoreBankAccount", entity.StoreBankAccount);
			dict.Add("StoreZipCode", entity.StoreZipCode);
			dict.Add("StoreProvince", entity.StoreProvince);
			dict.Add("StoreCity", entity.StoreCity);
			dict.Add("StoreArea", entity.StoreArea);
			dict.Add("StoreAddress", entity.StoreAddress);
			dict.Add("StoreIDCardPic", entity.StoreIDCardPic);
			dict.Add("StoreFieldPic1", entity.StoreFieldPic1);
			dict.Add("StoreFieldPic2", entity.StoreFieldPic2);
			dict.Add("StoreConfirmLetterPic", entity.StoreConfirmLetterPic);
			dict.Add("HouseRentalAgreementPic", entity.HouseRentalAgreementPic);
			dict.Add("StoreStatus", entity.StoreStatus);
			dict.Add("StoreRemark", entity.StoreRemark);
			dict.Add("SaleID", entity.SaleID);
			dict.Add("SaleManageID", entity.SaleManageID);
			dict.Add("SaleCityManageID", entity.SaleCityManageID);
			dict.Add("SaleLargeAreaManageID", entity.SaleLargeAreaManageID);
			dict.Add("ProductIDs", entity.ProductIDs);
		}
		/// <summary>
		/// 通过数据读取器生成实体类
		/// </summary>
		/// <param name="rdr"></param>
		/// <returns></returns>
		private static StoreEntity GetEntityFromrdr(NullableDataReader rdr)
		{
			StoreEntity info = new StoreEntity();
			info.ID = rdr.GetInt32("ID");
			info.StoreMerchantID = rdr.GetInt32("StoreMerchantID");
			info.StoreType = rdr.GetString("StoreType");
			info.StoreName = rdr.GetString("StoreName");
			info.StoreLinkman = rdr.GetString("StoreLinkman");
			info.StoreLinkmanPosition = rdr.GetString("StoreLinkmanPosition");
			info.StoreLinkmanTel = rdr.GetString("StoreLinkmanTel");
			info.StoreLinkmanMobile = rdr.GetString("StoreLinkmanMobile");
			info.StoreSize = rdr.GetDouble("StoreSize");
			info.StoreNum = rdr.GetInt32("StoreNum");
			info.BusinessHours1 = rdr.GetString("BusinessHours1");
			info.BusinessHours2 = rdr.GetString("BusinessHours2");
			info.EstimatedNum = rdr.GetInt32("EstimatedNum");
			info.StoreAccountName = rdr.GetString("StoreAccountName");
			info.StoreBankHeadOffice = rdr.GetString("StoreBankHeadOffice");
			info.StoreBankHeadOfficeOther = rdr.GetString("StoreBankHeadOfficeOther");
			info.StoreBankBranch = rdr.GetString("StoreBankBranch");
			info.StoreBankBranchProvince = rdr.GetString("StoreBankBranchProvince");
			info.StoreBankBranchCity = rdr.GetString("StoreBankBranchCity");
			info.StoreBankBranchArea = rdr.GetString("StoreBankBranchArea");
			info.StoreBankAccount = rdr.GetString("StoreBankAccount");
			info.StoreZipCode = rdr.GetString("StoreZipCode");
			info.StoreProvince = rdr.GetString("StoreProvince");
			info.StoreCity = rdr.GetString("StoreCity");
			info.StoreArea = rdr.GetString("StoreArea");
			info.StoreAddress = rdr.GetString("StoreAddress");
			info.StoreIDCardPic = rdr.GetString("StoreIDCardPic");
			info.StoreFieldPic1 = rdr.GetString("StoreFieldPic1");
			info.StoreFieldPic2 = rdr.GetString("StoreFieldPic2");
			info.StoreConfirmLetterPic = rdr.GetString("StoreConfirmLetterPic");
			info.HouseRentalAgreementPic = rdr.GetString("HouseRentalAgreementPic");
			info.StoreStatus = rdr.GetInt32("StoreStatus");
			info.StoreRemark = rdr.GetString("StoreRemark");
			info.SaleID = rdr.GetInt32("SaleID");
			info.SaleManageID = rdr.GetInt32("SaleManageID");
			info.SaleCityManageID = rdr.GetInt32("SaleCityManageID");
			info.SaleLargeAreaManageID = rdr.GetInt32("SaleLargeAreaManageID");
			info.ProductIDs = rdr.GetString("ProductIDs");
			return info;
		}
		#endregion
	}
}