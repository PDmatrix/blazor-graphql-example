using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorDB.App.PageLogic
{
	public class StudentPageBase : PageBase<Student>, IPageLogic
	{
		protected override async Task OnInitAsync()
		{
			Collection = await StudentService.GetAsync().ConfigureAwait(false);
		}
    
		public async Task Add()
		{
			await StudentService.AddAsync(Current).ConfigureAwait(false);
			Collection = await StudentService.GetAsync().ConfigureAwait(false);
			StateHasChanged();
		}
    
		public async Task ShowModal()
		{
			Current = new Student {Groups = await ClassService.GetAsync()};
		}
    
		public async Task ShowModal(int id)
		{
			Current = await StudentService.GetAsync(id).ConfigureAwait(false);
			Current.Groups = await ClassService.GetAsync();
		}
    
		public async Task Update()
		{
			if (Collection is List<Student> studentList)
			{
				studentList[studentList.FindIndex(r => r.Id == Current.Id)] = Current;
			}
			else
			{
				Collection = await StudentService.GetAsync().ConfigureAwait(false);
			}
			StateHasChanged();
			Current = await StudentService.UpdateAsync(Current).ConfigureAwait(false);
		}
    
		public async Task Delete(int id)
		{
			Collection = Collection.Where(r => r.Id != id).ToList();
			StateHasChanged();
			await StudentService.DeleteAsync(id).ConfigureAwait(false);
		}
	}
}