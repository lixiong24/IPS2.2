using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace JX.Infrastructure.Common
{
	/// <summary>
	/// 对Microsoft.AspNetCore.Http.HttpContext对象的扩展。
	/// 使用方法：
	/// 1、在Startup.cs文件的ConfigureServices方法中，添加services.AddMyHttpContextAccessor();
	/// 2、修改Configure方法，添加代码：app.UseStaticMyHttpContext();
	/// </summary>
	public static class MyHttpContext
	{
		private static IHttpContextAccessor _contextAccessor;

		/// <summary>
		/// 得到当前HTTP 请求的HttpContext 对象
		/// </summary>
		public static HttpContext Current => _contextAccessor.HttpContext;

		/// <summary>
		/// 注入IHttpContextAccessor对象到内部属性中
		/// </summary>
		/// <param name="contextAccessor"></param>
		public static void Configure(IHttpContextAccessor contextAccessor)
		{
			_contextAccessor = contextAccessor;
		}

		/// <summary>
		/// 在Startup.cs文件的ConfigureServices方法中注册服务
		/// </summary>
		/// <param name="services"></param>
		public static void AddMyHttpContextAccessor(this IServiceCollection services)
		{
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
		}
		/// <summary>
		/// 在Startup.cs文件的Configure方法中启用服务
		/// </summary>
		/// <param name="app"></param>
		/// <returns></returns>
		public static IApplicationBuilder UseStaticMyHttpContext(this IApplicationBuilder app)
		{
			var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
			Configure(httpContextAccessor);
			return app;
		}
	}
}
