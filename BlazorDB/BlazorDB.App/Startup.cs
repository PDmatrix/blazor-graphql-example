using System.Net.Http;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using BlazorDB.App.Services;
using GraphQL.Common.Request;

namespace BlazorDB.App
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton<WeatherForecastService>();
			services.AddSingleton<GraphqQlService>();
			services.AddScoped<HttpClient>();
		}

		public void Configure(IBlazorApplicationBuilder app)
		{
			app.AddComponent<App>("app");
		}
	}
}