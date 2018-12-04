using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;

namespace BlazorDB.App.Services
{
	public class ControlService : BaseGraphQlService<Control>, IControlService
	{
		public async Task<ICollection<Control>> GetAsync()
		{
			const string query = 
				@"
				{
				  allControls {
					nodes {
					  id
					  studentId
					  lecturerId
					  disciplineId
					  grade
					  formControl
					  semesterNum
					  student: studentByStudentId {
						id
						surname
					  }
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					  discipline: disciplineByDisciplineId {
						id
						disciplineName
					  }
					}
				  }
				}
				";

			return await GetAll(query, "allControls");
		}
		
		public async Task<Control> GetAsync(int id)
		{
			const string query = 
				@"
				query GetControlById($id: Int!) {
				  controlById(id: $id) {
					  id
					  studentId
					  lecturerId
					  disciplineId
					  grade
					  formControl
					  semesterNum
					  student: studentByStudentId {
						id
						surname
					  }
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					  discipline: disciplineByDisciplineId {
						id
						disciplineName
					  }
				  }
				}
				";

			return await GetOne(query, "controlById", id);
		}
		
		public async Task<Control> UpdateAsync(Control control)
		{
			const string query = 
				@"
				mutation UpdateControl($input: UpdateControlByIdInput!) {
				  updateControlById(input: $input) {
					control {
					  id
					  studentId
					  lecturerId
					  disciplineId
					  grade
					  formControl
					  semesterNum
					  student: studentByStudentId {
						id
						surname
					  }
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					  discipline: disciplineByDisciplineId {
						id
						disciplineName
					  }
					}
				  }
				}
				";

			return await Mutate(query, "updateControlById.control", new
			{
				input = new {
					id = control.Id,
					controlPatch = new {
						studentId = control.StudentId,
						lecturerId = control.LecturerId,
						disciplineId = control.DisciplineId,
						grade = control.Grade,
						formControl = control.FormControl,
						semesterNum = control.SemesterNum
					}
				}
			});
		}
		
		public async Task<Control> DeleteAsync(int id)
		{
			const string query = 
				@"
				mutation DeleteControl($input: DeleteControlByIdInput!) {
				  deleteControlById(input: $input) {
					control {
					  id
					  studentId
					  lecturerId
					  disciplineId
					  grade
					  formControl
					  semesterNum
					  student: studentByStudentId {
						id
						surname
					  }
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					  discipline: disciplineByDisciplineId {
						id
						disciplineName
					  }
					}
				  }
				}
				";

			return await Mutate(query, "deleteControlById.control", new
			{
				input = new {
					id
				}
			});
		}
		
		public async Task<Control> AddAsync(Control control)
		{
			const string query = 
				@"
				mutation AddControl($input: CreateControlInput!) {
				  createControl(input: $input) {
					control {
					  id
					  studentId
					  lecturerId
					  disciplineId
					  grade
					  formControl
					  semesterNum
					  student: studentByStudentId {
						id
						surname
					  }
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					  discipline: disciplineByDisciplineId {
						id
						disciplineName
					  }
					}
				  }
				}
				";

			return await Mutate(query, "createControl.control", new
			{
				input = new {
					control = new {
						studentId = control.StudentId,
						lecturerId = control.LecturerId,
						disciplineId = control.DisciplineId,
						grade = control.Grade,
						formControl = control.FormControl,
						semesterNum = control.SemesterNum
					}
				}
			});
		}
	}
}