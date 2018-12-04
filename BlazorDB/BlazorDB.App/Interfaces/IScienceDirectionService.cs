using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Models;

namespace BlazorDB.App.Interfaces
{
	public interface IScienceDirectionService : IBaseGraphQlService<ScienceDirection>
	{
		Task<ICollection<ScienceDirection>> GetAsync();
		Task<ScienceDirection> GetAsync(int id);
		Task<ScienceDirection> UpdateAsync(ScienceDirection update);
		Task<ScienceDirection> DeleteAsync(int id);
		Task<ScienceDirection> AddAsync(ScienceDirection add);
	}
}