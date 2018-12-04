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
			services.AddScoped<ILecturerService, LecturerService>();
			services.AddScoped<IPulpitService, PulpitService>();
			
			services.AddScoped<IAdvocacyService, AdvocacyService>();
			services.AddScoped<IControlService, ControlService>();
			services.AddScoped<IDiplomaService, DiplomaService>();
			services.AddScoped<IDisciplineService, DisciplineService>();
			services.AddScoped<IPlanService, PlanService>();
			services.AddScoped<IScienceDirectionService, ScienceDirectionService>();
			services.AddScoped<IScienceThemeService, ScienceThemeService>();
			services.AddScoped<ITraineeshipService, TraineeshipService>();
		}

		public void Configure(IBlazorApplicationBuilder app)
		{
			app.AddComponent<App>("app");
		}
	}
}