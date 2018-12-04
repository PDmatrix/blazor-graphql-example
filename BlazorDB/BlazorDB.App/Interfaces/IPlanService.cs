using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Models;

namespace BlazorDB.App.Interfaces
{
	public interface IPlanService : IBaseGraphQlService<Plan>
	{
		Task<ICollection<Plan>> GetAsync();
		Task<Plan> GetAsync(int id);
		Task<Plan> UpdateAsync(Plan update);
		Task<Plan> DeleteAsync(int id);
		Task<Plan> AddAsync(Plan add);
	}
}