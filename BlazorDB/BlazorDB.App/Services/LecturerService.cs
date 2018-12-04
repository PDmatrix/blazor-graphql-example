using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;

namespace BlazorDB.App.Services
{
	public class LecturerService : BaseGraphQlService<Lecturer>, ILecturerService
	{
		public async Task<ICollection<Lecturer>> GetAsync()
		{
			const string query = 
				@"
				{
				  allLecturers {
					nodes {
					  lecturerName
					  surname
					  id
					  pulpitId
					  lecturerType
					  gender
					  birthYear
					  children
					  salary
					  pulpit: pulpitByPulpitId {
						pulpitName
						id
					  }
					}
				  }
				}
				";

			return await GetAll(query, "allLecturers");
		}
		
		public async Task<Lecturer> GetAsync(int id)
		{
			const string query = 
				@"
				query GetLecturerById($id: Int!) {
				  lecturerById(id: $id) {
					lecturerName
					surname
					id
					pulpitId
					lecturerType
					gender
					birthYear
					children
					salary
					pulpit: pulpitByPulpitId {
						pulpitName
						id
					}
				  }
				}
				";

			return await GetOne(query, "lecturerById", id);
		}
		
		public async Task<Lecturer> UpdateAsync(Lecturer lecturer)
		{
			const string query = 
				@"
				mutation UpdateLecturer($input: UpdateLecturerByIdInput!) {
				  updateLecturerById(input: $input) {
					lecturer {
					  lecturerName
					  surname
					  id
					  pulpitId
					  lecturerType
					  gender
					  birthYear
					  children
					  salary
					  pulpit: pulpitByPulpitId {
						pulpitName
						id
					  }
					}
				  }
				}
				";

			return await Mutate(query, "updateLecturerById.lecturer", new
			{
				input = new {
					id = lecturer.Id,
					lecturerPatch = new {
						lecturerName = lecturer.LecturerName,
						surname = lecturer.Surname,
						pulpitId = lecturer.PulpitId,
						lecturerType = lecturer.LecturerType,
						gender = lecturer.Gender,
						birthYear = lecturer.BirthYear,
						children = lecturer.Children,
						salary = lecturer.Salary
					}
				}
			});
		}
		
		public async Task<Lecturer> DeleteAsync(int id)
		{
			const string query = 
				@"
				mutation DeleteLecturer($input: DeleteLecturerByIdInput!) {
				  deleteLecturerById(input: $input) {
					lecturer {
					  lecturerName
					  surname
					  id
					  pulpitId
					  lecturerType
					  gender
					  birthYear
					  children
					  salary
					  pulpit: pulpitByPulpitId {
						pulpitName
						id
					  }
					}
				  }
				}
				";

			return await Mutate(query, "deleteLecturerById.lecturer", new
			{
				input = new {
					id
				}
			});
		}
		
		public async Task<Lecturer> AddAsync(Lecturer lecturer)
		{
			const string query = 
				@"
				mutation AddLecturer($input: CreateLecturerInput!) {
				  createLecturer(input: $input) {
					lecturer {
					  lecturerName
					  surname
					  id
					  pulpitId
					  lecturerType
					  gender
					  birthYear
					  children
					  salary
					  pulpit: pulpitByPulpitId {
						pulpitName
						id
					  }
					}
				  }
				}
				";

			return await Mutate(query, "createLecturer.lecturer", new
			{
				input = new {
					lecturer = new {
						lecturerName = lecturer.LecturerName,
						surname = lecturer.Surname,
						pulpitId = lecturer.PulpitId,
						lecturerType = lecturer.LecturerType,
						gender = lecturer.Gender,
						birthYear = lecturer.BirthYear,
						children = lecturer.Children,
						salary = lecturer.Salary
					}
				}
			});
		}
	}
}