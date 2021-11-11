using System;
using System.Diagnostics;
using System.Web;
using System.Web.Http;
using AspNetDependencyInjection;
using AspNetDependencyInjection.Services;
using Example;
using Example.App_Data;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AppStartDependencyInjection), nameof(AppStartDependencyInjection.PreStart))]

namespace Example
{
	internal class AppStartDependencyInjection
	{
		private static ApplicationDependencyInjection _di;

		internal static void PreStart()
		{
			var webApiConfig = GlobalConfiguration.Configuration;

			_di = new ApplicationDependencyInjectionBuilder()
				.ConfigureServices(ConfigureServices)
				.AddWebApiDependencyResolver(webApiConfig)
				.Build();
		}

		private static void ConfigureServices(IServiceCollection services)
		{
			services
				.AddDefaultHttpContextAccessor()
				.AddWebConfiguration();

			// Custom configuration
			services.AddScoped<TestObject>(c =>
			{
				if (HttpContext.Current == null)
					throw new InvalidOperationException();

				Debugger.Log(1, "log", $"Making TestObject [Context (Thread) Hashcode: {HttpContext.Current.GetHashCode()}]{Environment.NewLine}");

				// Throws on WebAPI
				var context = c.GetService<IHttpContextAccessor>();

				// Comment out the IHttpContextAccessor call above and uncomment this line to allow WebAPI controller to be created.
				//	var context = new DefaultHttpContextAccessor(new HttpContextWrapper(HttpContext.Current));

				return new TestObject(context);
			});
		}

		public static T GetService<T>()
		{
			return _di
				.GetServiceProviderForThreadLocalHttpContext()
				.GetRequiredService<T>();
		}
	}
}
