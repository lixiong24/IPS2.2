using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 配置文件读写帮助类:配置文件必须存放在网站程序根目录的config目录下
	/// </summary>
	public static class ConfigHelper
	{
		/// <summary>
		/// 包含应用程序目录的绝对路径
		/// </summary>
		private static string m_ContentRootPath = DI.ServiceProvider.GetRequiredService<IHostingEnvironment>().ContentRootPath;
		/// <summary>
		/// AppSetting.json配置文件的根节点
		/// </summary>
		public static IConfigurationRoot AppSettingConfiguration { get; }

		/// <summary>
		/// 初始化AppSettingConfiguration属性
		/// </summary>
		static ConfigHelper()
		{
			AppSettingConfiguration = new ConfigurationBuilder()
				.SetBasePath(m_ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.Build();
		}

		/// <summary>
		/// 得到appsettings.json配置文件中的配置
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T GetAppSettingSection<T>() where T : class, new()
		{
			T instance = new ServiceCollection()
				.AddOptions()
				.Configure<T>(AppSettingConfiguration.GetSection(typeof(T).Name))
				.BuildServiceProvider()
				.GetService<IOptions<T>>()
				.Value;
			return instance;
		}

		/// <summary>
		/// 得到根目录下Config文件夹中的配置文件的实例对象。只支持“.json”格式。
		/// 先从缓存中取得对象，如果不存在，则从文件中取并加入缓存。
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T Get<T>() where T : class, new()
		{
			T instance = CacheHelper.CacheServiceProvider.Get<T>("CK_SiteConfigCode_" + typeof(T).Name);
			if (instance == null)
			{
				var build = new ConfigurationBuilder()
					.SetBasePath(m_ContentRootPath)
					.AddJsonFile("Config/" + typeof(T).Name + ".json", optional: true, reloadOnChange: true)
					.Build();
				instance = new ServiceCollection()
					.AddOptions()
					.Configure<T>(build)
					.BuildServiceProvider()
					.GetService<IOptions<T>>()
					.Value;
				CacheHelper.CacheServiceProvider.AddOrUpdate("CK_SiteConfigCode_" + typeof(T).Name, instance);
			}
			return instance;
		}
		/// <summary>
		/// 得到根目录下Config文件夹中的配置文件的实例对象。只支持“.xml”格式。
		/// 先从缓存中取得对象，如果不存在，则从文件中取并加入缓存。
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T GetXml<T>() where T : class, new()
		{
			T instance = CacheHelper.CacheServiceProvider.Get<T>("CK_SiteConfigCode_XML_" + typeof(T).Name);
			if (instance == null)
			{
				var build = new ConfigurationBuilder()
					.SetBasePath(m_ContentRootPath)
					.AddXmlFile("Config/" + typeof(T).Name + ".xml", optional: true, reloadOnChange: true)
					.Build();
				instance = new ServiceCollection()
					.AddOptions()
					.Configure<T>(build)
					.BuildServiceProvider()
					.GetService<IOptions<T>>()
					.Value;
				CacheHelper.CacheServiceProvider.AddOrUpdate("CK_SiteConfigCode_XML_" + typeof(T).Name, instance);
			}
			return instance;
		}
		/// <summary>
		/// 得到根目录下Config文件夹中的配置文件的实例对象。只支持“.ini”格式。
		/// 先从缓存中取得对象，如果不存在，则从文件中取并加入缓存。
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T GetIni<T>() where T : class, new()
		{
			T instance = CacheHelper.CacheServiceProvider.Get<T>("CK_SiteConfigCode_INI_" + typeof(T).Name);
			if (instance == null)
			{
				var build = new ConfigurationBuilder()
					.SetBasePath(m_ContentRootPath)
					.AddIniFile("Config/" + typeof(T).Name + ".ini", optional: true, reloadOnChange: true)
					.Build();
				instance = new ServiceCollection()
					.AddOptions()
					.Configure<T>(build)
					.BuildServiceProvider()
					.GetService<IOptions<T>>()
					.Value;
				CacheHelper.CacheServiceProvider.AddOrUpdate("CK_SiteConfigCode_INI_" + typeof(T).Name, instance);
			}
			return instance;
		}

		/// <summary>
		/// 保存根目录下Config文件夹中的配置文件。只支持“.json”格式。
		/// 保存成功，会删除对应的缓存对象，以保持配置数据和缓存数据的一致性。
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="config"></param>
		public static void Save<T>(T config) where T : class, new()
		{
			FileHelper.WriteFile("Config/" + typeof(T).Name + ".json", JsonConvert.SerializeObject(config));
			CacheHelper.CacheServiceProvider.Remove("CK_SiteConfigCode_" + typeof(T).Name);
		}
		/// <summary>
		/// 保存根目录下Config文件夹中的配置文件。只支持“.xml”格式。
		/// 保存成功，会删除对应的缓存对象，以保持配置数据和缓存数据的一致性。
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="config"></param>
		public static void SaveXml<T>(T config) where T : class, new()
		{
			FileHelper.WriteFile("Config/" + typeof(T).Name + ".xml", config.ToXml());
			CacheHelper.CacheServiceProvider.Remove("CK_SiteConfigCode_XML_" + typeof(T).Name);
		}
	}
}
