using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;

namespace BlazorDB.App.Services
{
	public class DisciplineService : BaseGraphQlService<Discipline>, IDisciplineService
	{
		public async Task<ICollection<Discipline>> GetAsync()
		{
			const string query = 
				@"
				{
				  allDisciplines {
					nodes {
					  id
					  disciplineName
					}
				  }
				}
				";

			return await GetAll(query, "allDisciplines");
		}
		
		public async Task<Discipline> GetAsync(int id)
		{
			const string query = 
				@"
				query GetDisciplineById($id: Int!) {
				  disciplineById(id: $id) {
					id
					disciplineName
				  }
				}
				";

			return await GetOne(query, "disciplineById", id);
		}
		
		public async Task<Discipline> UpdateAsync(Discipline discipline)
		{
			const string query = 
				@"
				mutation UpdateDiscipline($input: UpdateDisciplineByIdInput!) {
				  updateDisciplineById(input: $input) {
					discipline {
					  id
					  disciplineName
					}
				  }
				}
				";

			return await Mutate(query, "updateDisciplineById.discipline", new
			{
				input = new {
					id = discipline.Id,
					disciplinePatch = new {
						disciplineName = discipline.DisciplineName
					}
				}
			});
		}
		
		public async Task<Discipline> DeleteAsync(int id)
		{
			const string query = 
				@"
				mutation DeleteDiscipline($input: DeleteDisciplineByIdInput!) {
				  deleteDisciplineById(input: $input) {
					discipline {
					  id
					  disciplineName
					}
				  }
				}
				";

			return await Mutate(query, "deleteDisciplineById.discipline", new
			{
				input = new {
					id
				}
			});
		}
		
		public async Task<Discipline> AddAsync(Discipline discipline)
		{
			const string query = 
				@"
				mutation AddDiscipline($input: CreateDisciplineInput!) {
				  createDiscipline(input: $input) {
					discipline {
					  id
					  disciplineName
					}
				  }
				}
				";

			return await Mutate(query, "createDiscipline.discipline", new
			{
				input = new {
					discipline = new {
						disciplineName = discipline.DisciplineName
					}
				}
			});
		}
	}
}