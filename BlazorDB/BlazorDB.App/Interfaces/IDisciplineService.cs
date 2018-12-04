using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Models;

namespace BlazorDB.App.Interfaces
{
	public interface IDisciplineService : IBaseGraphQlService<Discipline>
	{
		Task<ICollection<Discipline>> GetAsync();
		Task<Discipline> GetAsync(int id);
		Task<Discipline> UpdateAsync(Discipline update);
		Task<Discipline> DeleteAsync(int id);
		Task<Discipline> AddAsync(Discipline add);
	}
}