using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Models;

namespace BlazorDB.App.Services
{
	public class StudentService : BaseGraphQlService<Student>
	{
		public override async Task<ICollection<Student>> GetAsync()
		{
			const string query = 
				@"
				{
				  allStudents {
					nodes {
					  studentName
					  surname
					  id
					  classId
					  gender
					  birthYear
					  children
					  scholarship
					  fullName
					  classByClassId {
					    className
					  }
					}
				  }
				}";

			return await GetAll(query, "allStudents");
		}
		
		public override async Task<Student> GetAsync(int id)
		{
			const string query = 
				@"
				query GetStudentById($id: Int!) {
				  studentById(id: $id) {
					studentName
					surname
					id
					classId
					gender
					birthYear
					children
					scholarship
					fullName
					classByClassId {
					  className
					}
				  }
				}
				";

			return await GetOne(query, "studentById", id);
		}
	
		public override async Task<Student> UpdateAsync(Student student)
		{
			const string query = 
				@"
				mutation UpdateStudent($input: UpdateStudentByIdInput!) {
				  updateStudentById(input : $input) {
					student {
					  studentName
					  surname
					  id
					  classId
					  gender
					  birthYear
					  children
					  scholarship
					  fullName
					  classByClassId {
					    className
					  }
					}
				  }
				}";

			return await Mutate(query, "updateStudentById.student", new
			{
				input = new {
					id = student.Id,
					studentPatch = new {
						studentName = student.StudentName,
						surname = student.Surname,
						gender = student.Gender,
						birthYear = student.BirthYear,
						children = student.Children,
						scholarship = student.Scholarship,
						classId = student.ClassId
					}
				}
			});
		}
		
		public override async Task<Student> DeleteAsync(int id)
		{
			const string query = 
				@"
				mutation DeleteStudent($input: DeleteStudentByIdInput!) {
				  deleteStudentById(input: $input) {
					student {
					  studentName
					  surname
					  id
					  classId
					  gender
					  birthYear
					  children
					  scholarship
					  fullName
					  classByClassId {
					    className
					  }
					}
				  }
				}
				";

			return await Mutate(query, "deleteStudentById.student", new
			{
				input = new {
					id
				}
			});
		}
		
		public override async Task<Student> AddAsync(Student student)
		{
			const string query = 
				@"
				mutation AddStudent($input: CreateStudentInput!) {
				  createStudent(input: $input) {
					student {
					  studentName
					  surname
					  id
					  classId
					  gender
					  birthYear
					  children
					  scholarship
					  fullName
					  classByClassId {
					    className
					  }
					}
				  }
				}
				";

			return await Mutate(query, "createStudent.student", new
			{
				input = new {
					student = new {
						studentName = student.StudentName,
						surname = student.Surname,
						gender = student.Gender,
						birthYear = student.BirthYear,
						children = student.Children,
						scholarship = student.Scholarship,
						classId = student.ClassId
					}
				}
			});
		}
	}
}