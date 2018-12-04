using System.Collections.Generic;

namespace BlazorDB.App.Models
{
	public class Pulpit : Node
	{
		public int Id { get; set; }
		public string PulpitName { get; set; }
		public int FacultyId { get; set; }

		public Faculty Faculty { get; set; }
		
		public ICollection<Faculty> Faculties { get; set; }
		public Pulpit()
		{
			Faculties = new List<Faculty>();
		}
	}
}