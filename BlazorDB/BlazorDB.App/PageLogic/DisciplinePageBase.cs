using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;
using BlazorDB.App.Services;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorDB.App.PageLogic
{
	public class DisciplinePageBase : PageBase<Discipline>, IPageLogic
	{
		protected override async Task OnInitAsync()
		{
			Collection = await DisciplineService.GetAsync().ConfigureAwait(false);
		}
    
		public async Task Add()
		{
			await DisciplineService.AddAsync(Current).ConfigureAwait(false);
			Collection = await DisciplineService.GetAsync().ConfigureAwait(false);
			StateHasChanged();
		}
    
		public Task ShowModal()
		{
			Current = new Discipline();
			return Task.CompletedTask;
		}
    
		public async Task ShowModal(int id)
		{
			Current = await DisciplineService.GetAsync(id).ConfigureAwait(false);
		}
    
		public async Task Update()
		{
			if (Collection is List<Discipline> disciplines)
			{
				disciplines[disciplines.FindIndex(r => r.Id == Current.Id)] = Current;
			}
			else
			{
				Collection = await DisciplineService.GetAsync().ConfigureAwait(false);
			}
			StateHasChanged();
			Current = await DisciplineService.UpdateAsync(Current).ConfigureAwait(false);
		}
    
		public async Task Delete(int id)
		{
			Collection = Collection.Where(r => r.Id != id).ToList();
			StateHasChanged();
			await DisciplineService.DeleteAsync(id).ConfigureAwait(false);
		}
	}
}