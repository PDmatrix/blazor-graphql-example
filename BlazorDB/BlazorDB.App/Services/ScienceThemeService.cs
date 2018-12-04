using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Interfaces;
using BlazorDB.App.Models;

namespace BlazorDB.App.Services
{
	public class ScienceThemeService : BaseGraphQlService<ScienceTheme>, IScienceThemeService
	{
		public async Task<ICollection<ScienceTheme>> GetAsync()
		{
			const string query = 
				@"
				{
				  allScienceThemes {
					nodes {
					  id
					  themeName
					  lecturerId
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					}
				  }
				}
				";

			return await GetAll(query, "allScienceThemes");
		}
		
		public async Task<ScienceTheme> GetAsync(int id)
		{
			const string query = 
				@"
				query GetScienceThemeById($id: Int!) {
				  scienceThemeById(id: $id) {
					  id
					  themeName
					  lecturerId
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
				  }
				}
				";

			return await GetOne(query, "scienceThemeById", id);
		}
		
		public async Task<ScienceTheme> UpdateAsync(ScienceTheme scienceTheme)
		{
			const string query = 
				@"
				mutation UpdateScienceTheme($input: UpdateScienceThemeByIdInput!) {
				  updateScienceThemeById(input: $input) {
					scienceTheme {
					  id
					  themeName
					  lecturerId
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					}
				  }
				}
				";

			return await Mutate(query, "updateScienceThemeById.scienceTheme", new
			{
				input = new {
					id = scienceTheme.Id,
					scienceThemePatch = new {
						themeName = scienceTheme.ThemeName,
						lecturerId = scienceTheme.LecturerId
					}
				}
			});
		}
		
		public async Task<ScienceTheme> DeleteAsync(int id)
		{
			const string query = 
				@"
				mutation DeleteScienceTheme($input: DeleteScienceThemeByIdInput!) {
				  deleteScienceThemeById(input: $input) {
					scienceTheme {
					  id
					  themeName
					  lecturerId
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					}
				  }
				}
				";

			return await Mutate(query, "deleteScienceThemeById.scienceTheme", new
			{
				input = new {
					id
				}
			});
		}
		
		public async Task<ScienceTheme> AddAsync(ScienceTheme scienceTheme)
		{
			const string query = 
				@"
				mutation AddScienceTheme($input: CreateScienceThemeInput!) {
				  createScienceTheme(input: $input) {
					scienceTheme {
					  id
					  themeName
					  lecturerId
					  lecturer: lecturerByLecturerId {
						id
						surname
					  }
					}
				  }
				}
				";

			return await Mutate(query, "createScienceTheme.scienceTheme", new
			{
				input = new {
					scienceTheme = new {
						themeName = scienceTheme.ThemeName,
						lecturerId = scienceTheme.LecturerId
					}
				}
			});
		}
	}
}