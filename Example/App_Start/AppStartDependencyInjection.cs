using System.Web;
using AspNetDependencyInjection;
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
			_di = new ApplicationDependencyInjectionBuilder()
				.ConfigureServices(ConfigureServices)
				.Build();
		}

		private static void ConfigureServices(IServiceCollection services)
		{
			services
				.AddDefaultHttpContextAccessor()
				.AddWebConfiguration();

			// Custom configuration
			services.AddScoped<TestObject>();
		}

		public static T GetService<T>()
		{
			return _di
				.GetServiceProviderForCurrentHttpContext(HttpContext.Current)
				.GetRequiredService<T>();
		}
	}
}
