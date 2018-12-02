using System.Threading.Tasks;

namespace BlazorDB.App.Interfaces
{
	public interface IPageLogic
	{
		Task Add();
		Task ShowModal();
		Task ShowModal(int id);
		Task Update();
		Task Delete(int id);
	}
}