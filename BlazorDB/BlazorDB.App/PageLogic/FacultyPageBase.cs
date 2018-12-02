using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorDB.App.PageLogic
{
	public class FacultyPageBase : PageBase<Faculty>, IPageLogic
	{
		protected override async Task OnInitAsync()
		{
			Collection = await FacultyService.GetAsync().ConfigureAwait(false);
		}
    
		public async Task Add()
		{
			await FacultyService.AddAsync(Current).ConfigureAwait(false);
			Collection = await FacultyService.GetAsync().ConfigureAwait(false);
			StateHasChanged();
		}
    
		public Task ShowModal()
		{
			Current = new Faculty();
			return Task.CompletedTask;
		}
    
		public async Task ShowModal(int id)
		{
			Current = await FacultyService.GetAsync(id).ConfigureAwait(false);
		}
    
		public async Task Update()
		{
			if (Collection is List<Faculty> facultyList)
			{
				facultyList[facultyList.FindIndex(r => r.Id == Current.Id)] = Current;
			}
			else
			{
				Collection = await FacultyService.GetAsync().ConfigureAwait(false);
			}
			StateHasChanged();
			Current = await FacultyService.UpdateAsync(Current).ConfigureAwait(false);
		}
    
		public async Task Delete(int id)
		{
			Collection = Collection.Where(r => r.Id != id).ToList();
			StateHasChanged();
			await FacultyService.DeleteAsync(id).ConfigureAwait(false);
		}
	}
}