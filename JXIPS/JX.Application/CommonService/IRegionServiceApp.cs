using JX.Core.Entity;
using System.Collections.Generic;

namespace JX.Application
{
	/// <summary>
	/// 数据库表：Region 的应用层服务接口.
	/// </summary>
	public partial interface IRegionServiceApp : IServiceApp<RegionEntity>
	{
		/// <summary>
		/// 检查区县是否存在
		/// </summary>
		/// <param name="province"></param>
		/// <param name="city"></param>
		/// <param name="area"></param>
		/// <returns></returns>
		bool AreaExists(string province, string city, string area);
		/// <summary>
		/// 检查街道是否存在
		/// </summary>
		/// <param name="province"></param>
		/// <param name="city"></param>
		/// <param name="area"></param>
		/// <param name="area1"></param>
		/// <returns></returns>
		bool Area1Exists(string province, string city, string area, string area1);
		/// <summary>
		/// 检查小区是否存在
		/// </summary>
		/// <param name="province"></param>
		/// <param name="city"></param>
		/// <param name="area"></param>
		/// <param name="area1"></param>
		/// <param name="area2"></param>
		/// <returns></returns>
		bool Area2Exists(string province, string city, string area, string area1, string area2);
		/// <summary>
		/// 通过邮政编码的前2位来判断是否存在相同的邮政编码
		/// </summary>
		/// <param name="postCode"></param>
		/// <returns></returns>
		bool PostCodeExists(string postCode);
		/// <summary>
		/// 得到符合条件的邮政编码
		/// </summary>
		/// <param name="country"></param>
		/// <param name="province"></param>
		/// <param name="city"></param>
		/// <param name="area"></param>
		/// <returns></returns>
		string GetZipCodeByArea(string country, string province, string city, string area);
		/// <summary>
		/// 通过邮政编码得到实体类。先从缓存中取得对象，如果不存在，则从数据库中取并加入缓存。
		/// </summary>
		/// <param name="postCode"></param>
		/// <returns></returns>
		RegionEntity GetByPostCodeOfFourNumber(string postCode);
		/// <summary>
		/// 得到所有国家的列表。先从缓存中取得对象，如果不存在，则从数据库中取并加入缓存。
		/// </summary>
		/// <returns></returns>
		IList<RegionEntity> GetCountryList();
		/// <summary>
		/// 通过国家得到省份列表。先从缓存中取得对象，如果不存在，则从数据库中取并加入缓存。
		/// </summary>
		/// <param name="country"></param>
		/// <returns></returns>
		IList<RegionEntity> GetProvinceListByCountry(string country);
		/// <summary>
		/// 通过省份得到城市列表。先从缓存中取得对象，如果不存在，则从数据库中取并加入缓存。
		/// </summary>
		/// <param name="province"></param>
		/// <returns></returns>
		IList<RegionEntity> GetCityListByProvince(string province);
		/// <summary>
		/// 通过城市得到区县列表。先从缓存中取得对象，如果不存在，则从数据库中取并加入缓存。
		/// </summary>
		/// <param name="city"></param>
		/// <returns></returns>
		IList<RegionEntity> GetAreaListByCity(string city);
		/// <summary>
		/// 通过区县得到街道列表。先从缓存中取得对象，如果不存在，则从数据库中取并加入缓存。
		/// </summary>
		/// <param name="area"></param>
		/// <returns></returns>
		IList<RegionEntity> GetArea1ListByArea(string area);
		/// <summary>
		/// 通过街道得到小区列表。先从缓存中取得对象，如果不存在，则从数据库中取并加入缓存。
		/// </summary>
		/// <param name="area1"></param>
		/// <returns></returns>
		IList<RegionEntity> GetArea2ListByArea1(string area1);
	}
}