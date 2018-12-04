using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorDB.App.PageLogic
{
	public class LecturerPageBase : PageBase<Lecturer>, IPageLogic
	{
		protected override async Task OnInitAsync()
		{
			Collection = await LecturerService.GetAsync().ConfigureAwait(false);
		}
    
		public async Task Add()
		{
			await LecturerService.AddAsync(Current).ConfigureAwait(false);
			Collection = await LecturerService.GetAsync().ConfigureAwait(false);
			StateHasChanged();
		}
    
		public async Task ShowModal()
		{
			Current = new Lecturer{Pulpits = await PulpitService.GetAsync()};
		}
    
		public async Task ShowModal(int id)
		{
			Current = await LecturerService.GetAsync(id).ConfigureAwait(false);
			Current.Pulpits = await PulpitService.GetAsync();
		}
    
		public async Task Update()
		{
			if (Collection is List<Lecturer> lecturers)
			{
				lecturers[lecturers.FindIndex(r => r.Id == Current.Id)] = Current;
			}
			else
			{
				Collection = await LecturerService.GetAsync().ConfigureAwait(false);
			}
			StateHasChanged();
			Current = await LecturerService.UpdateAsync(Current).ConfigureAwait(false);
		}
    
		public async Task Delete(int id)
		{
			Collection = Collection.Where(r => r.Id != id).ToList();
			StateHasChanged();
			await LecturerService.DeleteAsync(id).ConfigureAwait(false);
		}
	}
}