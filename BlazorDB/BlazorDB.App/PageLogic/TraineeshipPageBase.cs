using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;
using BlazorDB.App.Services;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorDB.App.PageLogic
{
	public class TraineeshipPageBase : PageBase<Traineeship>, IPageLogic
	{
		protected override async Task OnInitAsync()
		{
			Collection = await TraineeshipService.GetAsync().ConfigureAwait(false);
		}
    
		public async Task Add()
		{
			await TraineeshipService.AddAsync(Current).ConfigureAwait(false);
			Collection = await TraineeshipService.GetAsync().ConfigureAwait(false);
			StateHasChanged();
		}
    
		public async Task ShowModal()
		{
			Current = new Traineeship
			{
				Lecturers = await LecturerService.GetAsync()
			};
		}
    
		public async Task ShowModal(int id)
		{
			Current = await TraineeshipService.GetAsync(id).ConfigureAwait(false);
			Current.Lecturers = await LecturerService.GetAsync();
		}
    
		public async Task Update()
		{
			if (Collection is List<Traineeship> controls)
			{
				controls[controls.FindIndex(r => r.Id == Current.Id)] = Current;
			}
			else
			{
				Collection = await TraineeshipService.GetAsync().ConfigureAwait(false);
			}
			StateHasChanged();
			Current = await TraineeshipService.UpdateAsync(Current).ConfigureAwait(false);
		}
    
		public async Task Delete(int id)
		{
			Collection = Collection.Where(r => r.Id != id).ToList();
			StateHasChanged();
			await TraineeshipService.DeleteAsync(id).ConfigureAwait(false);
		}
	}
}