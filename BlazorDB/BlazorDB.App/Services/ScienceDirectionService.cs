using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;

namespace BlazorDB.App.Services
{
	public class ScienceDirectionService : BaseGraphQlService<ScienceDirection>, IScienceDirectionService
	{
		public async Task<ICollection<ScienceDirection>> GetAsync()
		{
			const string query = 
				@"
				{
				  allScienceDirections {
					nodes {
					  id
					  directionName
					  lecturerId
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					}
				  }
				}
				";

			return await GetAll(query, "allScienceDirections");
		}
		
		public async Task<ScienceDirection> GetAsync(int id)
		{
			const string query = 
				@"
				query GetScienceDirectionById($id: Int!) {
				  scienceDirectionById(id: $id) {
					  id
					  directionName
					  lecturerId
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
				  }
				}
				";

			return await GetOne(query, "scienceDirectionById", id);
		}
		
		public async Task<ScienceDirection> UpdateAsync(ScienceDirection scienceDirection)
		{
			const string query = 
				@"
				mutation UpdateScienceDirection($input: UpdateScienceDirectionByIdInput!) {
				  updateScienceDirectionById(input: $input) {
					scienceDirection {
					  id
					  directionName
					  lecturerId
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					}
				  }
				}
				";

			return await Mutate(query, "updateScienceDirectionById.scienceDirection", new
			{
				input = new {
					id = scienceDirection.Id,
					scienceDirectionPatch = new {
						directionName = scienceDirection.DirectionName,
						lecturerId = scienceDirection.LecturerId
					}
				}
			});
		}
		
		public async Task<ScienceDirection> DeleteAsync(int id)
		{
			const string query = 
				@"
				mutation DeleteScienceDirection($input: DeleteScienceDirectionByIdInput!) {
				  deleteScienceDirectionById(input: $input) {
					scienceDirection {
					  id
					  directionName
					  lecturerId
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					}
				  }
				}
				";

			return await Mutate(query, "deleteScienceDirectionById.scienceDirection", new
			{
				input = new {
					id
				}
			});
		}
		
		public async Task<ScienceDirection> AddAsync(ScienceDirection scienceDirection)
		{
			const string query = 
				@"
				mutation AddScienceDirection($input: CreateScienceDirectionInput!) {
				  createScienceDirection(input: $input) {
					scienceDirection {
					  id
					  directionName
					  lecturerId
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					}
				  }
				}
				";

			return await Mutate(query, "createScienceDirection.scienceDirection", new
			{
				input = new {
					scienceDirection = new {
						directionName = scienceDirection.DirectionName,
						lecturerId = scienceDirection.LecturerId
					}
				}
			});
		}
	}
}