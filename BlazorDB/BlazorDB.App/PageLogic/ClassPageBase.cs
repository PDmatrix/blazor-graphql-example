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
		protected ICollection<Group> Groups { get; set; }
		protected Group EditGroup { get; set; }

		protected override async Task OnInitAsync()
		{
			Groups = await ClassService.GetAsync().ConfigureAwait(false);
		}
    
		public async Task Add()
		{
			await ClassService.AddAsync(EditGroup).ConfigureAwait(false);
			Groups = await ClassService.GetAsync().ConfigureAwait(false);
			StateHasChanged();
		}
    
		public async Task ShowModal()
		{
			EditGroup = new Group {Faculties = await FacultyService.GetAsync()};
		}
    
		public async Task ShowModal(int id)
		{
			EditGroup = await ClassService.GetAsync(id).ConfigureAwait(false);
			EditGroup.Faculties = await FacultyService.GetAsync();
		}
    
		public async Task Update()
		{
			if (Groups is List<Group> groups)
			{
				groups[groups.FindIndex(r => r.Id == EditGroup.Id)] = EditGroup;
			}
			else
			{
				Groups = await ClassService.GetAsync().ConfigureAwait(false);
			}
			StateHasChanged();
			EditGroup = await ClassService.UpdateAsync(EditGroup).ConfigureAwait(false);
		}
    
		public async Task Delete(int id)
		{
			Groups = Groups.Where(r => r.Id != id).ToList();
			StateHasChanged();
			await ClassService.DeleteAsync(id).ConfigureAwait(false);
		}
	}
}