using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Models;

namespace BlazorDB.App.Interfaces
{
	public interface ILecturerService : IBaseGraphQlService<Lecturer>
	{
		Task<ICollection<Lecturer>> GetAsync();
		Task<Lecturer> GetAsync(int id);
		Task<Lecturer> UpdateAsync(Lecturer update);
		Task<Lecturer> DeleteAsync(int id);
		Task<Lecturer> AddAsync(Lecturer add);
	}
}