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
	/// 数据库表：Region 的应用层服务接口实现类.
	/// </summary>
	public partial class RegionServiceApp : IRegionServiceApp
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
			return _repository.IsExist(p => p.Province == province && p.City == city && p.Area == area);
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
			return _repository.IsExist(p => p.Province == province && p.City == city && p.Area == area && p.Area1 == area1);
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
			return _repository.IsExist(p => p.Province == province && p.City == city && p.Area == area && p.Area1 == area1 && p.Area2 == area2);
		}

		/// <summary>
		/// 通过邮政编码的前2位来判断是否存在相同的邮政编码。
		/// </summary>
		/// <param name="postCode"></param>
		/// <returns></returns>
		public bool PostCodeExists(string postCode)
		{
			return _repository.PostCodeExists(postCode);
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
			return _repository.GetZipCodeByArea(country,province,city,area);
		}

		/// <summary>
		/// 通过邮政编码得到实体类。先从缓存中取得对象，如果不存在，则从数据库中取并加入缓存。
		/// </summary>
		/// <param name="postCode"></param>
		/// <returns></returns>
		public RegionEntity GetByPostCodeOfFourNumber(string postCode)
		{
			string cacheKey = "CK_Region_RegionEntity_" + postCode;
			RegionEntity result = CacheHelper.CacheServiceProvider.Get<RegionEntity>(cacheKey);
			if (result == null)
			{
				result = _repository.GetByPostCodeOfFourNumber(postCode);
				if (result != null)
				{
					CacheHelper.CacheServiceProvider.AddOrUpdate(cacheKey, result);
				}
			}
			return result;
		}

		/// <summary>
		/// 得到所有国家的列表。先从缓存中取得对象，如果不存在，则从数据库中取并加入缓存。
		/// </summary>
		/// <returns></returns>
		public IList<RegionEntity> GetCountryList()
		{
			string cacheKey = "CK_Region_AllCountry";
			IList<RegionEntity> result = CacheHelper.CacheServiceProvider.Get<IList<RegionEntity>>(cacheKey);
			if (result == null)
			{
				result = _repository.GetCountryList();
				if(result != null && result.Count > 0)
				{
					CacheHelper.CacheServiceProvider.AddOrUpdate(cacheKey, result);
				}
			}
			return result;
		}
		/// <summary>
		/// 通过国家得到省份列表。先从缓存中取得对象，如果不存在，则从数据库中取并加入缓存。
		/// </summary>
		/// <param name="country"></param>
		/// <returns></returns>
		public IList<RegionEntity> GetProvinceListByCountry(string country)
		{
			string cacheKey = "CK_Region_Province_" + country;
			IList<RegionEntity> result = CacheHelper.CacheServiceProvider.Get<IList<RegionEntity>>(cacheKey);
			if(result == null)
			{
				result = _repository.GetProvinceListByCountry(country);
				if (result != null && result.Count > 0)
				{
					CacheHelper.CacheServiceProvider.AddOrUpdate(cacheKey, result);
				}
			}
			return result;
		}
		/// <summary>
		/// 通过省份得到城市列表。先从缓存中取得对象，如果不存在，则从数据库中取并加入缓存。
		/// </summary>
		/// <param name="province"></param>
		/// <returns></returns>
		public IList<RegionEntity> GetCityListByProvince(string province)
		{
			string cacheKey = "CK_Region_City_" + province;
			IList<RegionEntity> result = CacheHelper.CacheServiceProvider.Get<IList<RegionEntity>>(cacheKey);
			if (result == null)
			{
				result = _repository.GetCityListByProvince(province);
				if (result != null && result.Count > 0)
				{
					CacheHelper.CacheServiceProvider.AddOrUpdate(cacheKey, result);
				}
			}
			return result;
		}
		/// <summary>
		/// 通过城市得到区县列表。先从缓存中取得对象，如果不存在，则从数据库中取并加入缓存。
		/// </summary>
		/// <param name="city"></param>
		/// <returns></returns>
		public IList<RegionEntity> GetAreaListByCity(string city)
		{
			string cacheKey = "CK_Region_Area_" + city;
			IList<RegionEntity> result = CacheHelper.CacheServiceProvider.Get<IList<RegionEntity>>(cacheKey);
			if (result == null)
			{
				result = _repository.GetAreaListByCity(city);
				if (result != null && result.Count > 0)
				{
					CacheHelper.CacheServiceProvider.AddOrUpdate(cacheKey, result);
				}
			}
			return result;
		}
		/// <summary>
		/// 通过区县得到街道列表。先从缓存中取得对象，如果不存在，则从数据库中取并加入缓存。
		/// </summary>
		/// <param name="area"></param>
		/// <returns></returns>
		public IList<RegionEntity> GetArea1ListByArea(string area)
		{
			string cacheKey = "CK_Region_Area1_" + area;
			IList<RegionEntity> result = CacheHelper.CacheServiceProvider.Get<IList<RegionEntity>>(cacheKey);
			if (result == null)
			{
				result = _repository.GetArea1ListByArea(area);
				if (result != null && result.Count > 0)
				{
					CacheHelper.CacheServiceProvider.AddOrUpdate(cacheKey, result);
				}
			}
			return result;
		}
		/// <summary>
		/// 通过街道得到小区列表。先从缓存中取得对象，如果不存在，则从数据库中取并加入缓存。
		/// </summary>
		/// <param name="area1"></param>
		/// <returns></returns>
		public IList<RegionEntity> GetArea2ListByArea1(string area1)
		{
			string cacheKey = "CK_Region_Area2_" + area1;
			IList<RegionEntity> result = CacheHelper.CacheServiceProvider.Get<IList<RegionEntity>>(cacheKey);
			if (result == null)
			{
				result = _repository.GetArea2ListByArea1(area1);
				if (result != null && result.Count > 0)
				{
					CacheHelper.CacheServiceProvider.AddOrUpdate(cacheKey, result);
				}
			}
			return result;
		}
	}
}