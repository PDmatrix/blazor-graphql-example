using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDB.App.Interfaces
{
	public interface IBaseGraphQlService<T>
	{
		Task<ICollection<T>> GetAll(string query, string name);
		Task<T> GetOne(string query, string name, int id);
		Task<T> Mutate(string query, string name, object variables);
	}
}