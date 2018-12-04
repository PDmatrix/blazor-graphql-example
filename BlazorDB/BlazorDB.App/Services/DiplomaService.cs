using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;

namespace BlazorDB.App.Services
{
	public class DiplomaService : BaseGraphQlService<Diploma>, IDiplomaService
	{
		public async Task<ICollection<Diploma>> GetAsync()
		{
			const string query = 
				@"
				{
				  allDiplomas {
					nodes {
					  id
					  theme
					  studentId
					  lecturerId
					  student: studentByStudentId {
						id
						surname
					  }
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					}
				  }
				}
				";

			return await GetAll(query, "allDiplomas");
		}
		
		public async Task<Diploma> GetAsync(int id)
		{
			const string query = 
				@"
				query GetDiplomaById($id: Int!) {
				  diplomaById(id: $id) {
					  id
					  theme
					  studentId
					  lecturerId
					  student: studentByStudentId {
						id
						surname
					  }
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
				  }
				}
				";

			return await GetOne(query, "lecturerById", id);
		}
		
		public async Task<Diploma> UpdateAsync(Diploma diploma)
		{
			const string query = 
				@"
				mutation UpdateDiploma($input: UpdateDiplomaByIdInput!) {
				  updateDiplomaById(input: $input) {
					diploma {
					  id
					  theme
					  studentId
					  lecturerId
					  student: studentByStudentId {
						id
						surname
					  }
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					}
				  }
				}
				";

			return await Mutate(query, "updateDiplomaById.diploma", new
			{
				input = new {
					id = diploma.Id,
					diplomaPatch = new {
						theme = diploma.Theme,
						studentId = diploma.StudentId,
						lecturerId = diploma.LecturerId
					}
				}
			});
		}
		
		public async Task<Diploma> DeleteAsync(int id)
		{
			const string query = 
				@"
				mutation DeleteDiploma($input: DeleteDiplomaByIdInput!) {
				  deleteDiplomaById(input: $input) {
					diploma {
					  id
					  theme
					  studentId
					  lecturerId
					  student: studentByStudentId {
						id
						surname
					  }
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					}
				  }
				}
				";

			return await Mutate(query, "deleteDiplomaById.diploma", new
			{
				input = new {
					id
				}
			});
		}
		
		public async Task<Diploma> AddAsync(Diploma diploma)
		{
			const string query = 
				@"
				mutation AddDiploma($input: CreateDiplomaInput!) {
				  createDiploma(input: $input) {
					diploma {
					  id
					  theme
					  studentId
					  lecturerId
					  student: studentByStudentId {
						id
						surname
					  }
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					}
				  }
				}
				";

			return await Mutate(query, "createDiploma.diploma", new
			{
				input = new {
					diploma = new {
						theme = diploma.Theme,
						studentId = diploma.StudentId,
						lecturerId = diploma.LecturerId
					}
				}
			});
		}
	}
}