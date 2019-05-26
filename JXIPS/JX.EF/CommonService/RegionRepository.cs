using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using JX.Core;
using JX.Core.Entity;

namespace JX.EF.Repository
{
	/// <summary>
	/// 数据库表：Region 的仓储实现类.
	/// </summary>
	public partial class RegionRepository : Repository<RegionEntity>, IRegionRepository
	{
		/// <summary>
		/// 检查区县是否存在
		/// </summary>
		/// <param name="province"></param>
		/// <param name="city"></param>
		/// <param name="area"></param>
		/// <returns></returns>
		public bool AreaExists(string province, string city, string area)
		{
			return IsExist(p => p.Province == province && p.City == city && p.Area == area);
		}
		/// <summary>
		/// 检查街道是否存在
		/// </summary>
		/// <param name="province"></param>
		/// <param name="city"></param>
		/// <param name="area"></param>
		/// <param name="area1"></param>
		/// <returns></returns>
		public bool Area1Exists(string province, string city, string area, string area1)
		{
			return IsExist(p => p.Province == province && p.City == city && p.Area == area && p.Area1==area1);
		}
		/// <summary>
		/// 检查小区是否存在
		/// </summary>
		/// <param name="province"></param>
		/// <param name="city"></param>
		/// <param name="area"></param>
		/// <param name="area1"></param>
		/// <param name="area2"></param>
		/// <returns></returns>
		public bool Area2Exists(string province, string city, string area, string area1, string area2)
		{
			return IsExist(p => p.Province == province && p.City == city && p.Area == area && p.Area1 == area1 && p.Area2 == area2);
		}

		/// <summary>
		/// 通过邮政编码的前2位来判断是否存在相同的邮政编码。
		/// </summary>
		/// <param name="postCode"></param>
		/// <returns></returns>
		public bool PostCodeExists(string postCode)
		{
			string strSQL = "SELECT RegionID FROM Region WHERE LEFT(PostCode, 2) = LEFT(@PostCode, 2)";
			int count = GetBySQL<int>(strSQL, m => m.RegionID, new SqlParameter("PostCode", postCode));
			return (count > 0) ? true : false;
		}

		/// <summary>
		/// 得到符合条件的邮政编码
		/// </summary>
		/// <param name="country"></param>
		/// <param name="province"></param>
		/// <param name="city"></param>
		/// <param name="area"></param>
		/// <returns></returns>
		public string GetZipCodeByArea(string country, string province, string city, string area)
		{
			string strSQL = "SELECT TOP 1 postcode FROM Region WHERE country = @country AND province = @province AND city = @city AND area = @area";
			DbParameter[] parameters = new DbParameter[4];
			parameters[0] = new SqlParameter("country", country);
			parameters[1] = new SqlParameter("province", province);
			parameters[2] = new SqlParameter("city", city);
			parameters[3] = new SqlParameter("area", area);
			return GetBySQL<string>(strSQL, m => m.PostCode, parameters);
		}

		/// <summary>
		/// 通过邮政编码得到实体类
		/// </summary>
		/// <param name="postCode"></param>
		/// <returns></returns>
		public RegionEntity GetByPostCodeOfFourNumber(string postCode)
		{
			string strSQL = "";
			if (postCode.Substring(0, 4) == "9990")
			{
				strSQL = "SELECT * FROM Region WHERE LEFT(PostCode, 6) = LEFT(@PostCode, 6)";
			}
			else
			{
				strSQL = "SELECT * FROM Region WHERE LEFT(PostCode, 4) = LEFT(@PostCode, 4)";
			}
			return GetBySQL<RegionEntity>(strSQL,m=>m,new SqlParameter("PostCode", postCode));
		}

		/// <summary>
		/// 得到所有国家的列表
		/// </summary>
		/// <returns></returns>
		public IList<RegionEntity> GetCountryList()
		{
			string strSQL = "SELECT DISTINCT Country FROM Region ORDER BY Country";
			var queryResult = SqlQuery<RegionEntity>(strSQL);
			return queryResult;
		}
		/// <summary>
		/// 通过国家得到省份列表
		/// </summary>
		/// <param name="country"></param>
		/// <returns></returns>
		public IList<RegionEntity> GetProvinceListByCountry(string country)
		{
			string strSQL = "SELECT Province FROM Region WHERE Country = @Country group by Province order by min(RegionID)";
			var queryResult = SqlQuery<RegionEntity>(strSQL, new SqlParameter("Country", country));
			return queryResult;
		}
		/// <summary>
		/// 通过省份得到城市列表
		/// </summary>
		/// <param name="province"></param>
		/// <returns></returns>
		public IList<RegionEntity> GetCityListByProvince(string province)
		{
			string strSQL = "SELECT City FROM Region WHERE Province = @Province group by City order by min(RegionID)";
			var queryResult = SqlQuery<RegionEntity>(strSQL, new SqlParameter("Province", province));
			return queryResult;
		}
		/// <summary>
		/// 通过城市得到区县列表
		/// </summary>
		/// <param name="city"></param>
		/// <returns></returns>
		public IList<RegionEntity> GetAreaListByCity(string city)
		{
			string strSQL = "SELECT Area FROM Region WHERE City = @City group by Area order by min(RegionID)";
			var queryResult = SqlQuery<RegionEntity>(strSQL, new SqlParameter("City", city));
			return queryResult;
		}
		/// <summary>
		/// 通过区县得到街道列表
		/// </summary>
		/// <param name="area"></param>
		/// <returns></returns>
		public IList<RegionEntity> GetArea1ListByArea(string area)
		{
			string strSQL = "SELECT DISTINCT Area1 FROM Region WHERE Area = @Area order by area1";
			var queryResult = SqlQuery<RegionEntity>(strSQL, new SqlParameter("Area", area));
			return queryResult;
		}
		/// <summary>
		/// 通过街道得到小区列表
		/// </summary>
		/// <param name="area1"></param>
		/// <returns></returns>
		public IList<RegionEntity> GetArea2ListByArea1(string area1)
		{
			string strSQL = "SELECT DISTINCT Area2 FROM Region WHERE Area1 = @Area1 order by area2";
			var queryResult = SqlQuery<RegionEntity>(strSQL, new SqlParameter("Area1", area1));
			return queryResult;
		}
	}
}