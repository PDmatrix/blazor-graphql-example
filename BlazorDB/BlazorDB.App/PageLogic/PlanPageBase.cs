using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;
using BlazorDB.App.Services;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorDB.App.PageLogic
{
	public class PlanPageBase : PageBase<Plan>, IPageLogic
	{
		protected override async Task OnInitAsync()
		{
			Collection = await PlanService.GetAsync().ConfigureAwait(false);
		}
    
		public async Task Add()
		{
			await PlanService.AddAsync(Current).ConfigureAwait(false);
			Collection = await PlanService.GetAsync().ConfigureAwait(false);
			StateHasChanged();
		}
    
		public async Task ShowModal()
		{
			Current = new Plan
			{
				Lecturers = await LecturerService.GetAsync(),
				Disciplines = await DisciplineService.GetAsync()
			};
		}
    
		public async Task ShowModal(int id)
		{
			Current = await PlanService.GetAsync(id).ConfigureAwait(false);
			Current.Lecturers = await LecturerService.GetAsync();
			Current.Disciplines = await DisciplineService.GetAsync();
		}
    
		public async Task Update()
		{
			if (Collection is List<Plan> plans)
			{
				plans[plans.FindIndex(r => r.Id == Current.Id)] = Current;
			}
			else
			{
				Collection = await PlanService.GetAsync().ConfigureAwait(false);
			}
			StateHasChanged();
			Current = await PlanService.UpdateAsync(Current).ConfigureAwait(false);
		}
    
		public async Task Delete(int id)
		{
			Collection = Collection.Where(r => r.Id != id).ToList();
			StateHasChanged();
			await PlanService.DeleteAsync(id).ConfigureAwait(false);
		}
	}
}