using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;
using BlazorDB.App.Services;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorDB.App.PageLogic
{
	public class DiplomaPageBase : PageBase<Diploma>, IPageLogic
	{
		protected override async Task OnInitAsync()
		{
			Collection = await DiplomaService.GetAsync().ConfigureAwait(false);
		}
    
		public async Task Add()
		{
			await DiplomaService.AddAsync(Current).ConfigureAwait(false);
			Collection = await DiplomaService.GetAsync().ConfigureAwait(false);
			StateHasChanged();
		}
    
		public async Task ShowModal()
		{
			Current = new Diploma
			{
				Lecturers = await LecturerService.GetAsync(),
				Students = await StudentService.GetAsync()
			};
		}
    
		public async Task ShowModal(int id)
		{
			Current = await DiplomaService.GetAsync(id).ConfigureAwait(false);
			Current.Lecturers = await LecturerService.GetAsync();
			Current.Students = await StudentService.GetAsync();
		}
    
		public async Task Update()
		{
			if (Collection is List<Diploma> diplomas)
			{
				diplomas[diplomas.FindIndex(r => r.Id == Current.Id)] = Current;
			}
			else
			{
				Collection = await DiplomaService.GetAsync().ConfigureAwait(false);
			}
			StateHasChanged();
			Current = await DiplomaService.UpdateAsync(Current).ConfigureAwait(false);
		}
    
		public async Task Delete(int id)
		{
			Collection = Collection.Where(r => r.Id != id).ToList();
			StateHasChanged();
			await DiplomaService.DeleteAsync(id).ConfigureAwait(false);
		}
	}
}