using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Models;

namespace BlazorDB.App.Interfaces
{
	public interface IAdvocacyService : IBaseGraphQlService<Advocacy>
	{
		Task<ICollection<Advocacy>> GetAsync();
		Task<Advocacy> GetAsync(int id);
		Task<Advocacy> UpdateAsync(Advocacy update);
		Task<Advocacy> DeleteAsync(int id);
		Task<Advocacy> AddAsync(Advocacy add);
	}
}