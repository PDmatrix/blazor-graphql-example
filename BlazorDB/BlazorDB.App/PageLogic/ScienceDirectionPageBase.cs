using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;
using BlazorDB.App.Services;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorDB.App.PageLogic
{
	public class ScienceDirectionPageBase : PageBase<ScienceDirection>, IPageLogic
	{
		protected override async Task OnInitAsync()
		{
			Collection = await ScienceDirectionService.GetAsync().ConfigureAwait(false);
		}
    
		public async Task Add()
		{
			await ScienceDirectionService.AddAsync(Current).ConfigureAwait(false);
			Collection = await ScienceDirectionService.GetAsync().ConfigureAwait(false);
			StateHasChanged();
		}
    
		public async Task ShowModal()
		{
			Current = new ScienceDirection
			{
				Lecturers = await LecturerService.GetAsync()
			};
		}
    
		public async Task ShowModal(int id)
		{
			Current = await ScienceDirectionService.GetAsync(id).ConfigureAwait(false);
			Current.Lecturers = await LecturerService.GetAsync();
		}
    
		public async Task Update()
		{
			if (Collection is List<ScienceDirection> scienceDirections)
			{
				scienceDirections[scienceDirections.FindIndex(r => r.Id == Current.Id)] = Current;
			}
			else
			{
				Collection = await ScienceDirectionService.GetAsync().ConfigureAwait(false);
			}
			StateHasChanged();
			Current = await ScienceDirectionService.UpdateAsync(Current).ConfigureAwait(false);
		}
    
		public async Task Delete(int id)
		{
			Collection = Collection.Where(r => r.Id != id).ToList();
			StateHasChanged();
			await ScienceDirectionService.DeleteAsync(id).ConfigureAwait(false);
		}
	}
}