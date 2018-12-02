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
		
		protected ICollection<T> Collection { get; set; }
		protected T Current { get; set; }
	}
}