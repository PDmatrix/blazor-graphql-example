using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorDB.App.PageLogic
{
	public class ClassPageBase : PageBase<Group>, IPageLogic
	{
		protected override async Task OnInitAsync()
		{
			Collection = await ClassService.GetAsync().ConfigureAwait(false);
		}
    
		public async Task Add()
		{
			await ClassService.AddAsync(Current).ConfigureAwait(false);
			Collection = await ClassService.GetAsync().ConfigureAwait(false);
			StateHasChanged();
		}
    
		public async Task ShowModal()
		{
			Current = new Group {Faculties = await FacultyService.GetAsync()};
		}
    
		public async Task ShowModal(int id)
		{
			Current = await ClassService.GetAsync(id).ConfigureAwait(false);
			Current.Faculties = await FacultyService.GetAsync();
		}
    
		public async Task Update()
		{
			if (Collection is List<Group> groups)
			{
				groups[groups.FindIndex(r => r.Id == Current.Id)] = Current;
			}
			else
			{
				Collection = await ClassService.GetAsync().ConfigureAwait(false);
			}
			StateHasChanged();
			Current = await ClassService.UpdateAsync(Current).ConfigureAwait(false);
		}
    
		public async Task Delete(int id)
		{
			Collection = Collection.Where(r => r.Id != id).ToList();
			StateHasChanged();
			await ClassService.DeleteAsync(id).ConfigureAwait(false);
		}
	}
}