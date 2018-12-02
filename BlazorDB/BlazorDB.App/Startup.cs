using BlazorDB.App.Interfaces;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using BlazorDB.App.Services;

namespace BlazorDB.App
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<IStudentService, StudentService>();
			services.AddScoped<IFacultyService, FacultyService>();
			services.AddScoped<IClassService, ClassService>();
		}

		public void Configure(IBlazorApplicationBuilder app)
		{
			app.AddComponent<App>("app");
		}
	}
}