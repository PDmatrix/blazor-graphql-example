using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;

namespace BlazorDB.App.Services
{
	public class ClassService : BaseGraphQlService<Group>, IClassService
	{
		public async Task<ICollection<Group>> GetAsync()
		{
			const string query = 
				@"
				{
				  allClasses {
					nodes {
					  id
					  className
					  facultyId
					  faculty: facultyByFacultyId {
						facultyName
					  }
					}
				  }
				}
				";

			return await GetAll(query, "allClasses");
		}
		
		public async Task<Group> GetAsync(int id)
		{
			const string query = 
				@"
				query GetClassById($id: Int!) {
				  classById(id: $id) {
					id
					className
					facultyId
					faculty: facultyByFacultyId {
					  facultyName
					}
				  }
				}
				";

			return await GetOne(query, "classById", id);
		}
		
		public async Task<Group> UpdateAsync(Group group)
		{
			const string query = 
				@"
				mutation UpdateClass($input: UpdateClassByIdInput!) {
				  updateClassById(input: $input) {
					class {
					  id
					  className
					  facultyId
					  faculty: facultyByFacultyId {
						facultyName
					  }
					}
				  }
				}
				";

			return await Mutate(query, "updateClassById.class", new
			{
				input = new {
					id = group.Id,
					classPatch = new {
						className = group.ClassName,
						facultyId = group.FacultyId
					}
				}
			});
		}
		
		public async Task<Group> DeleteAsync(int id)
		{
			const string query = 
				@"
				mutation DeleteClass($input: DeleteClassByIdInput!) {
				  deleteClassById(input: $input) {
					class {
					  id
					  className
					  facultyId
					  faculty: facultyByFacultyId {
						facultyName
					  }
					}
				  }
				}
				";

			return await Mutate(query, "deleteClassById.class", new
			{
				input = new {
					id
				}
			});
		}
		
		public async Task<Group> AddAsync(Group group)
		{
			const string query = 
				@"
				mutation AddClass($input: CreateClassInput!) {
				  createClass(input: $input) {
					class {
					  id
					  className
					  facultyId
					  faculty: facultyByFacultyId {
						facultyName
					  }
					}
				  }
				}
				";

			return await Mutate(query, "createClass.class", new
			{
				input = new {
					@class = new {
						className = group.ClassName,
						facultyId = group.FacultyId
					}
				}
			});
		}
	}
}