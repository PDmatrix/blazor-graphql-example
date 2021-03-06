using System.Collections.Generic;
using BlazorDB.App.Interfaces;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorDB.App.PageLogic
{
	public abstract class PageBase<T> : BlazorComponent
	{
		[Inject]
		protected IClassService ClassService { get; set; }
		[Inject]
		protected IFacultyService FacultyService { get; set; }
		[Inject]
		protected IStudentService StudentService { get; set; }
		[Inject]
		protected ILecturerService LecturerService { get; set; }
		[Inject]
		protected IPulpitService PulpitService { get; set; }
		[Inject]
		protected IAdvocacyService AdvocacyService { get; set; }
		[Inject]
		protected IControlService ControlService { get; set; }
		[Inject]
		protected IDiplomaService DiplomaService { get; set; }
		[Inject]
		protected IDisciplineService DisciplineService { get; set; }
		[Inject]
		protected IPlanService PlanService { get; set; }
		[Inject]
		protected IScienceDirectionService ScienceDirectionService { get; set; }
		[Inject]
		protected IScienceThemeService ScienceThemeService { get; set; }
		[Inject]
		protected ITraineeshipService TraineeshipService { get; set; }
		
		protected ICollection<T> Collection { get; set; }
		protected T Current { get; set; }
	}
}