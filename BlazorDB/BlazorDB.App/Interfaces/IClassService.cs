using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Models;

namespace BlazorDB.App.Interfaces
{
	public interface IClassService : IBaseGraphQlService<Group>
	{
		Task<ICollection<Group>> GetAsync();
		Task<Group> GetAsync(int id);
		Task<Group> UpdateAsync(Group update);
		Task<Group> DeleteAsync(int id);
		Task<Group> AddAsync(Group add);
	}
}