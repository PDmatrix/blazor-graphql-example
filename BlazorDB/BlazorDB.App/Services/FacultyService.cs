using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;

namespace BlazorDB.App.Services
{
	public class FacultyService : BaseGraphQlService<Faculty>, IFacultyService
	{		
		public async Task<ICollection<Faculty>> GetAsync()
		{
			const string query = 
				@"
				{
				  allFaculties {
					nodes {
					  id
					  facultyName
					}
				  }
				}";

			return await GetAll(query, "allFaculties");
		}
		
		public async Task<Faculty> GetAsync(int id)
		{
			const string query = 
				@"
				query GetFacultyById($id: Int!) {
				  facultyById(id: $id) {
					id
					facultyName
				  }
				}
				";

			return await GetOne(query, "facultyById", id);
		}
		
		public async Task<Faculty> UpdateAsync(Faculty faculty)
		{
			const string query = 
				@"
				mutation UpdateFaculty($input: UpdateFacultyByIdInput!) {
				  updateFacultyById(input: $input){
					faculty {
					  id
					  facultyName
					}
				  }
				}";

			return await Mutate(query, "updateFacultyById.faculty", new
			{
				input = new {
					id = faculty.Id,
					facultyPatch = new {
						facultyName = faculty.FacultyName
					}
				}
			});
		}
		
		public async Task<Faculty> DeleteAsync(int id)
		{
			const string query = 
				@"
				mutation DeleteFaculty($input: DeleteFacultyByIdInput!) {
				  deleteFacultyById(input: $input) {
					faculty {
					  id
					  facultyName
					}
				  }
				}
				";

			return await Mutate(query, "deleteFacultyById.faculty", new
			{
				input = new {
					id
				}
			});
		}
		
		public async Task<Faculty> AddAsync(Faculty faculty)
		{
			const string query = 
				@"
				mutation AddFaculty($input: CreateFacultyInput!) {
				  createFaculty(input: $input) {
					faculty {
					  id
					  facultyName
					}
				  }
				}
				";

			return await Mutate(query, "createFaculty.faculty", new
			{
				input = new {
					faculty = new {
						facultyName = faculty.FacultyName
					}
				}
			});
		}
	}
}