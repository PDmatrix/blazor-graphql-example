using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Models;

namespace BlazorDB.App.Interfaces
{
	public interface IScienceThemeService : IBaseGraphQlService<ScienceTheme>
	{
		Task<ICollection<ScienceTheme>> GetAsync();
		Task<ScienceTheme> GetAsync(int id);
		Task<ScienceTheme> UpdateAsync(ScienceTheme update);
		Task<ScienceTheme> DeleteAsync(int id);
		Task<ScienceTheme> AddAsync(ScienceTheme add);
	}
}