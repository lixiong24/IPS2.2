using Microsoft.AspNetCore.Builder;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
	/// <summary>
	/// 自定义扩展类
	/// </summary>
	public static class Extensions
	{
		/// <summary>
		/// IServiceCollection对象的扩展方法
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddExtensionsDI(this IServiceCollection services)
		{
			return services;
		}
		/// <summary>
		/// IApplicationBuilder对象的扩展方法
		/// </summary>
		/// <param name="builder"></param>
		/// <returns></returns>
		public static IApplicationBuilder UseExtensionsDI(this IApplicationBuilder builder)
		{
			DI.ServiceProvider = builder.ApplicationServices;
			return builder;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public static class DI
	{
		/// <summary>
		/// 
		/// </summary>
		public static IServiceProvider ServiceProvider
		{
			get; set;
		}
	}
}
