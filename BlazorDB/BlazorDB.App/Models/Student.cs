using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Services;

namespace BlazorDB.App.Models
{
	public class Student : Node
	{
		public string StudentName { get; set; }
		public string Surname { get; set; }
		public int Id { get; set; }
		public int ClassId { get; set; }
		public string Gender { get; set; }
		public int BirthYear { get; set; }
		public int Children { get; set; }	
		public int Scholarship { get; set; }
		public string Fullname { get; set; }
		public Group ClassByClassId { get; set; }
		
		public IEnumerable<Group> Groups { get; set; }

		public Student()
		{
			Groups = new List<Group>();
			ClassId = 1;
		}

		public async Task FillGroups()
		{
			Groups = await GraphqQlService.GetGroupsAsync().ConfigureAwait(false);
		}
	}
}