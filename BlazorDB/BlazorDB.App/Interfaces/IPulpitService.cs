using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Models;

namespace BlazorDB.App.Interfaces
{
	public interface IPulpitService : IBaseGraphQlService<Pulpit>
	{
		Task<ICollection<Pulpit>> GetAsync();
		Task<Pulpit> GetAsync(int id);
		Task<Pulpit> UpdateAsync(Pulpit update);
		Task<Pulpit> DeleteAsync(int id);
		Task<Pulpit> AddAsync(Pulpit add);
	}
}