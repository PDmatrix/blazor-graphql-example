using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;
using BlazorDB.App.Services;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorDB.App.PageLogic
{
	public class ControlPageBase : PageBase<Control>, IPageLogic
	{
		protected override async Task OnInitAsync()
		{
			Collection = await ControlService.GetAsync().ConfigureAwait(false);
		}
    
		public async Task Add()
		{
			await ControlService.AddAsync(Current).ConfigureAwait(false);
			Collection = await ControlService.GetAsync().ConfigureAwait(false);
			StateHasChanged();
		}
    
		public async Task ShowModal()
		{
			Current = new Control
			{
				Lecturers = await LecturerService.GetAsync(),
				Disciplines = await DisciplineService.GetAsync(),
				Students = await StudentService.GetAsync()
			};
		}
    
		public async Task ShowModal(int id)
		{
			Current = await ControlService.GetAsync(id).ConfigureAwait(false);
			Current.Lecturers = await LecturerService.GetAsync();
			Current.Disciplines = await DisciplineService.GetAsync();
			Current.Students = await StudentService.GetAsync();
		}
    
		public async Task Update()
		{
			if (Collection is List<Control> controls)
			{
				controls[controls.FindIndex(r => r.Id == Current.Id)] = Current;
			}
			else
			{
				Collection = await ControlService.GetAsync().ConfigureAwait(false);
			}
			StateHasChanged();
			Current = await ControlService.UpdateAsync(Current).ConfigureAwait(false);
		}
    
		public async Task Delete(int id)
		{
			Collection = Collection.Where(r => r.Id != id).ToList();
			StateHasChanged();
			await ControlService.DeleteAsync(id).ConfigureAwait(false);
		}
	}
}