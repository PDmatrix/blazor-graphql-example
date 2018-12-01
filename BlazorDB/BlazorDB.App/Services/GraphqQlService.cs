using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Models;
using GraphQL.Client.Http;
using GraphQL.Common.Request;
using GraphQL.Common.Response;

namespace BlazorDB.App.Services
{
	public class GraphqQlService
	{
		private static async Task<ICollection<T>> GetAll<T>(string query, string name) 
		{
			var req = new GraphQLRequest
			{
				Query = query
			};
			
			var client = new GraphQLHttpClient($"{Environment.GetEnvironmentVariable("ASPNETCORE_API_URL")}");
			var res = await client.SendQueryAsync(req);
			return res.GetDataFieldAs<ConnectionGraphQl<T>>(name).Nodes;
		}
		
		private static async Task<T> GetOne<T>(string query, string name, int id) 
		{
			var req = new GraphQLRequest
			{
				Query = query,
				Variables = new { id }
			};
			
			var client = new GraphQLHttpClient($"{Environment.GetEnvironmentVariable("ASPNETCORE_API_URL")}");
			var res = await client.SendQueryAsync(req);
			return res.ExtGetDataFieldAs<T>(name);
		}
		
		private static async Task<T> Mutate<T>(string query, string name, object variables) 
		{
			var req = new GraphQLRequest
			{
				Query = query,
				Variables = variables
			};
			
			var client = new GraphQLHttpClient($"{Environment.GetEnvironmentVariable("ASPNETCORE_API_URL")}");
			var res = await client.SendQueryAsync(req);
			return res.ExtGetDataFieldAs<T>(name);
		}
		
		public static async Task<ICollection<Student>> GetStudentsAsync()
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

			return await GetAll<Student>(query, "allStudents");
		}
		
		public static async Task<ICollection<Faculty>> GetFacultiesAsync()
		{
			const string query = 
				@"
				{
				  allFaculties {
					nodes {
					  facultyName
					}
				  }
				}";

			return await GetAll<Faculty>(query, "allFaculties");
		}
		
		public static async Task<Faculty> GetFacultyAsync(int id)
		{
			const string query = 
				@"
				query GetFacultyById($id: Int!) {
				  facultyById(id: $id) {
					facultyName
				  }
				}
				";

			return await GetOne<Faculty>(query, "facultyById", id);
		}
		
		public static async Task<Student> GetStudentAsync(int id)
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
				  }
				}
				";

			return await GetOne<Student>(query, "studentById", id);
		}

		public static async Task<ICollection<Group>> GetGroupsAsync()
		{
			const string query = 
				@"
				{
					allClasses {
						nodes {
							id
							className
						}
					}
				}
				";

			return await GetAll<Group>(query, "allClasses");
		} 
		
		public static async Task<ICollection<Lecturer>> GetLecturersAsync()
		{
			const string query = 
				@"
				{
				  allLecturers {
					nodes {
					  lecturerName
					  surname
					  lecturerType
					  gender
					  birthYear
					  children
					  salary
					}
				  }
				}";

			return await GetAll<Lecturer>(query, "allLecturers");
		}
		
		public static async Task<Student> UpdateStudentAsync(Student student)
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
					}
				  }
				}";

			return await Mutate<Student>(query, "updateStudentById.student", new
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
		
		public static async Task<Faculty> UpdateFacultyAsync(Faculty faculty)
		{
			const string query = 
				@"
				mutation UpdateFaculty($input: UpdateFacultyByIdInput!) {
				  updateFacultyById(input: $input){
					faculty {
					  facultyName
					}
				  }
				}";

			return await Mutate<Faculty>(query, "updateFacultyById.faculty", new
			{
				input = new {
					id = faculty.Id,
					facultyPatch = new {
						facultyName = faculty.FacultyName
					}
				}
			});
		}
		
		public static async Task<Student> DeleteStudentAsync(int id)
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
					}
				  }
				}
				";

			return await Mutate<Student>(query, "deleteStudentById.student", new
			{
				input = new {
					id
				}
			});
		}
		
		public static async Task<Student> AddStudentAsync(Student student)
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
					}
				  }
				}
				";

			return await Mutate<Student>(query, "createStudent.student", new
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