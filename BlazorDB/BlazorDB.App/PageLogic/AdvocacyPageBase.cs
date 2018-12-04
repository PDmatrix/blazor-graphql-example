using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;
using BlazorDB.App.Services;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorDB.App.PageLogic
{
	public class AdvocacyPageBase : PageBase<Advocacy>, IPageLogic
	{
		protected override async Task OnInitAsync()
		{
			Collection = await AdvocacyService.GetAsync().ConfigureAwait(false);
		}
    
		public async Task Add()
		{
			await AdvocacyService.AddAsync(Current).ConfigureAwait(false);
			Collection = await AdvocacyService.GetAsync().ConfigureAwait(false);
			StateHasChanged();
		}
    
		public async Task ShowModal()
		{
			Current = new Advocacy {Lecturers = await LecturerService.GetAsync()};
		}
    
		public async Task ShowModal(int id)
		{
			Current = await AdvocacyService.GetAsync(id).ConfigureAwait(false);
			Current.Lecturers = await LecturerService.GetAsync();
		}
    
		public async Task Update()
		{
			if (Collection is List<Advocacy> advocacies)
			{
				advocacies[advocacies.FindIndex(r => r.Id == Current.Id)] = Current;
			}
			else
			{
				Collection = await AdvocacyService.GetAsync().ConfigureAwait(false);
			}
			StateHasChanged();
			Current = await AdvocacyService.UpdateAsync(Current).ConfigureAwait(false);
		}
    
		public async Task Delete(int id)
		{
			Collection = Collection.Where(r => r.Id != id).ToList();
			StateHasChanged();
			await AdvocacyService.DeleteAsync(id).ConfigureAwait(false);
		}
	}
}