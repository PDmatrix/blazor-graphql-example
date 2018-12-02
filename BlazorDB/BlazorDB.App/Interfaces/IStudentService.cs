using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Models;

namespace BlazorDB.App.Interfaces
{
	public interface IStudentService : IBaseGraphQlService<Student>
	{
		Task<ICollection<Student>> GetAsync();
		Task<Student> GetAsync(int id);
		Task<Student> UpdateAsync(Student update);
		Task<Student> DeleteAsync(int id);
		Task<Student> AddAsync(Student add);
	}
}