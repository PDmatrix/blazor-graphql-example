using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Models;

namespace BlazorDB.App.Interfaces
{
	public interface IFacultyService : IBaseGraphQlService<Faculty>
	{
		Task<ICollection<Faculty>> GetAsync();
		Task<Faculty> GetAsync(int id);
		Task<Faculty> UpdateAsync(Faculty update);
		Task<Faculty> DeleteAsync(int id);
		Task<Faculty> AddAsync(Faculty add);
	}
}