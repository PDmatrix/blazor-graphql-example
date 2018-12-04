using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Models;

namespace BlazorDB.App.Interfaces
{
	public interface ITraineeshipService : IBaseGraphQlService<Traineeship>
	{
		Task<ICollection<Traineeship>> GetAsync();
		Task<Traineeship> GetAsync(int id);
		Task<Traineeship> UpdateAsync(Traineeship update);
		Task<Traineeship> DeleteAsync(int id);
		Task<Traineeship> AddAsync(Traineeship add);
	}
}