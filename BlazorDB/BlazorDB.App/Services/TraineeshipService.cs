using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;

namespace BlazorDB.App.Services
{
	public class TraineeshipService : BaseGraphQlService<Traineeship>, ITraineeshipService
	{
		public async Task<ICollection<Traineeship>> GetAsync()
		{
			const string query = 
				@"
				{
				  allTraineeships {
					nodes {
					  id
					  lecturerId
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					}
				  }
				}
				";

			return await GetAll(query, "allTraineeships");
		}
		
		public async Task<Traineeship> GetAsync(int id)
		{
			const string query = 
				@"
				query GetTraineeshipById($id: Int!) {
				  traineeshipById(id: $id) {
					  id
					  lecturerId
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
				  }
				}
				";

			return await GetOne(query, "traineeshipById", id);
		}
		
		public async Task<Traineeship> UpdateAsync(Traineeship traineeship)
		{
			const string query = 
				@"
				mutation UpdateTraineeship($input: UpdateTraineeshipByIdInput!) {
				  updateTraineeshipById(input: $input) {
					traineeship {
					  id
					  lecturerId
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					}
				  }
				}
				";

			return await Mutate(query, "updateTraineeshipById.traineeship", new
			{
				input = new {
					id = traineeship.Id,
					traineeshipPatch = new {
						lecturerId = traineeship.LecturerId
					}
				}
			});
		}
		
		public async Task<Traineeship> DeleteAsync(int id)
		{
			const string query = 
				@"
				mutation DeleteTraineeship($input: DeleteTraineeshipByIdInput!) {
				  deleteTraineeshipById(input: $input) {
					traineeship {
					  id
					  lecturerId
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					}
				  }
				}
				";

			return await Mutate(query, "deleteTraineeshipById.traineeship", new
			{
				input = new {
					id
				}
			});
		}
		
		public async Task<Traineeship> AddAsync(Traineeship traineeship)
		{
			const string query = 
				@"
				mutation AddTraineeship($input: CreateTraineeshipInput!) {
				  createTraineeship(input: $input) {
					traineeship {
					  id
					  lecturerId
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					}
				  }
				}
				";

			return await Mutate(query, "createTraineeship.traineeship", new
			{
				input = new {
					traineeship = new {
						lecturerId = traineeship.LecturerId
					}
				}
			});
		}
	}
}