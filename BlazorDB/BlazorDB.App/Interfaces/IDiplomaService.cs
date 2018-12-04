using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Models;

namespace BlazorDB.App.Interfaces
{
	public interface IDiplomaService : IBaseGraphQlService<Diploma>
	{
		Task<ICollection<Diploma>> GetAsync();
		Task<Diploma> GetAsync(int id);
		Task<Diploma> UpdateAsync(Diploma update);
		Task<Diploma> DeleteAsync(int id);
		Task<Diploma> AddAsync(Diploma add);
	}
}