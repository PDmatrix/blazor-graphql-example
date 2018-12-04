using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;
using BlazorDB.App.Services;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorDB.App.PageLogic
{
	public class ScienceThemePageBase : PageBase<ScienceTheme>, IPageLogic
	{
		protected override async Task OnInitAsync()
		{
			Collection = await ScienceThemeService.GetAsync().ConfigureAwait(false);
		}
    
		public async Task Add()
		{
			await ScienceThemeService.AddAsync(Current).ConfigureAwait(false);
			Collection = await ScienceThemeService.GetAsync().ConfigureAwait(false);
			StateHasChanged();
		}
    
		public async Task ShowModal()
		{
			Current = new ScienceTheme
			{
				Lecturers = await LecturerService.GetAsync()
			};
		}
    
		public async Task ShowModal(int id)
		{
			Current = await ScienceThemeService.GetAsync(id).ConfigureAwait(false);
			Current.Lecturers = await LecturerService.GetAsync();
		}
    
		public async Task Update()
		{
			if (Collection is List<ScienceTheme> scienceThemes)
			{
				scienceThemes[scienceThemes.FindIndex(r => r.Id == Current.Id)] = Current;
			}
			else
			{
				Collection = await ScienceThemeService.GetAsync().ConfigureAwait(false);
			}
			StateHasChanged();
			Current = await ScienceThemeService.UpdateAsync(Current).ConfigureAwait(false);
		}
    
		public async Task Delete(int id)
		{
			Collection = Collection.Where(r => r.Id != id).ToList();
			StateHasChanged();
			await ScienceThemeService.DeleteAsync(id).ConfigureAwait(false);
		}
	}
}