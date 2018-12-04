using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorDB.App.PageLogic
{
	public class PulpitPageBase : PageBase<Pulpit>, IPageLogic
	{
	protected override async Task OnInitAsync()
	{
		Collection = await PulpitService.GetAsync().ConfigureAwait(false);
	}

	public async Task Add()
	{
		await PulpitService.AddAsync(Current).ConfigureAwait(false);
		Collection = await PulpitService.GetAsync().ConfigureAwait(false);
		StateHasChanged();
	}

	public async Task ShowModal()
	{
		Current = new Pulpit { Faculties = await FacultyService.GetAsync()};
	}

	public async Task ShowModal(int id)
	{
		Current = await PulpitService.GetAsync(id).ConfigureAwait(false);
		Current.Faculties = await FacultyService.GetAsync();
	}

	public async Task Update()
	{
		if (Collection is List<Pulpit> pulpits)
		{
			pulpits[pulpits.FindIndex(r => r.Id == Current.Id)] = Current;
		}
		else
		{
			Collection = await PulpitService.GetAsync().ConfigureAwait(false);
		}

		StateHasChanged();
		Current = await PulpitService.UpdateAsync(Current).ConfigureAwait(false);
	}

	public async Task Delete(int id)
	{
		Collection = Collection.Where(r => r.Id != id).ToList();
		StateHasChanged();
		await PulpitService.DeleteAsync(id).ConfigureAwait(false);
	}
	}
}