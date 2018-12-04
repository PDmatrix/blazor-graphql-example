using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;

namespace BlazorDB.App.Services
{
	public class AdvocacyService : BaseGraphQlService<Advocacy>, IAdvocacyService
	{
		public async Task<ICollection<Advocacy>> GetAsync()
		{
			const string query = 
				@"
				{
				  allAdvocacies {
					nodes {
					  id
					  lecturerId
					  yearEnd
					  advocacyType
					  theme
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					}
				  }
				}
				";

			return await GetAll(query, "allAdvocacies");
		}
		
		public async Task<Advocacy> GetAsync(int id)
		{
			const string query = 
				@"
				query GetAdvocacyById($id: Int!) {
				  advocacyById(id: $id) {
					id
					lecturerId
					yearEnd
					advocacyType
					theme
					lecturer: lecturerByLecturerId {
					  id
					  surname
					}
				  }
				}
				";

			return await GetOne(query, "advocacyById", id);
		}
		
		public async Task<Advocacy> UpdateAsync(Advocacy advocacy)
		{
			const string query = 
				@"
				mutation UpdateAdvocacy($input: UpdateAdvocacyByIdInput!) {
				  updateAdvocacyById(input: $input) {
					advocacy {
					  id
					  lecturerId
					  yearEnd
					  advocacyType
					  theme
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					}
				  }
				}
				";

			return await Mutate(query, "updateAdvocacyById.advocacy", new
			{
				input = new {
					id = advocacy.Id,
					advocacyPatch = new {
						lecturerId = advocacy.LecturerId,
						yearEnd = advocacy.YearEnd,
						advocacyType = advocacy.AdvocacyType,
						theme = advocacy.Theme
					}
				}
			});
		}
		
		public async Task<Advocacy> DeleteAsync(int id)
		{
			const string query = 
				@"
				mutation DeleteAdvocacy($input: DeleteAdvocacyByIdInput!) {
				  deleteAdvocacyById(input: $input) {
					advocacy {
					  id
					  lecturerId
					  yearEnd
					  advocacyType
					  theme
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					}
				  }
				}
				";

			return await Mutate(query, "deleteAdvocacyById.advocacy", new
			{
				input = new {
					id
				}
			});
		}
		
		public async Task<Advocacy> AddAsync(Advocacy advocacy)
		{
			const string query = 
				@"
				mutation CreateAdvocacy($input: CreateAdvocacyInput!) {
				  createAdvocacy(input: $input) {
					advocacy {
					  id
					  lecturerId
					  yearEnd
					  advocacyType
					  theme
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					}
				  }
				}
				";

			return await Mutate(query, "createAdvocacy.advocacy", new
			{
				input = new {
					advocacy = new {
						lecturerId = advocacy.LecturerId,
						yearEnd = advocacy.YearEnd,
						advocacyType = advocacy.AdvocacyType,
						theme = advocacy.Theme
					}
				}
			});
		}
	}
}