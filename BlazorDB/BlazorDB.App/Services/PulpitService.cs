using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;

namespace BlazorDB.App.Services
{
	public class PulpitService : BaseGraphQlService<Pulpit>, IPulpitService
	{		
		public async Task<ICollection<Pulpit>> GetAsync()
		{
			const string query = 
				@"
				{
				  allPulpits {
					nodes {
					  pulpitName
					  facultyId
					  id
					  faculty: facultyByFacultyId {
						facultyName
						id
					  }
					}
				  }
				}";

			return await GetAll(query, "allPulpits");
		}
		
		public async Task<Pulpit> GetAsync(int id)
		{
			const string query = 
				@"
				query GetPulpitById($id: Int!) {
				  pulpitById(id: $id) {
					pulpitName
					facultyId
					id
					faculty: facultyByFacultyId {
					  facultyName
					  id
					}
				  }
				}
				";

			return await GetOne(query, "pulpitById", id);
		}
		
		public async Task<Pulpit> UpdateAsync(Pulpit pulpit)
		{
			const string query = 
				@"
				mutation UpdatePulpit($input: UpdatePulpitByIdInput!) {
				  updatePulpit(input: $input) {
					pulpit {
					  pulpitName
					  facultyId
					  id
					  faculty: facultyByFacultyId {
						facultyName
						id
					  }
					}
				  }
				}
				";

			return await Mutate(query, "updatePulpit.pulpit", new
			{
				input = new {
					id = pulpit.Id,
					pulpitPatch = new {
						pulpitName = pulpit.PulpitName,
						facultyId = pulpit.FacultyId
					}
				}
			});
		}
		
		public async Task<Pulpit> DeleteAsync(int id)
		{
			const string query = 
				@"
				mutation DeletePulpit($input: DeletePulpitByIdInput!) {
				  deletePulpitById(input: $input) {
					pulpit {
					  pulpitName
					  facultyId
					  id
					  faculty: facultyByFacultyId {
						facultyName
						id
					  }
					}
				  }
				}
				";

			return await Mutate(query, "deletePulpitById.pulpit", new
			{
				input = new {
					id
				}
			});
		}
		
		public async Task<Pulpit> AddAsync(Pulpit pulpit)
		{
			const string query = 
				@"
				mutation AddPulpit($input: CreatePulpitInput!) {
				  createPulpit(input: $input) {
					pulpit {
					  pulpitName
					  facultyId
					  id
					  faculty: facultyByFacultyId {
						facultyName
						id
					  }
					}
				  }
				}
				";

			return await Mutate(query, "createPulpit.pulpit", new
			{
				input = new {
					pulpit = new {
						pulpitName = pulpit.PulpitName,
						facultyId = pulpit.FacultyId
					}
				}
			});
		}
	}
}