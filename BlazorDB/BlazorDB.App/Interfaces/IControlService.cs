using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Models;

namespace BlazorDB.App.Interfaces
{
	public interface IControlService : IBaseGraphQlService<Control>
	{
		Task<ICollection<Control>> GetAsync();
		Task<Control> GetAsync(int id);
		Task<Control> UpdateAsync(Control update);
		Task<Control> DeleteAsync(int id);
		Task<Control> AddAsync(Control add);
	}
}