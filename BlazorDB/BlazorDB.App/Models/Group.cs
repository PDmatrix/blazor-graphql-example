using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorDB.App.Services;

namespace BlazorDB.App.Models
{
	public class Group
	{
		public int Id { get; set; }
		public string ClassName { get; set; }
		public int FacultyId { get; set; }
		public Faculty Faculty { get; set; }

		public ICollection<Faculty> Faculties { get; set; }
		public Group()
		{
			Faculties = new List<Faculty>();
			FacultyId = 1;
		}
	}
}