using System.Collections.Generic;

namespace BlazorDB.App.Models
{
	public class Lecturer : Node
	{
		public string LecturerName { get; set; }
		public string Surname { get; set; }
		public string LecturerType { get; set; }
		public string Gender { get; set; }
		public int BirthYear { get; set; }
		public int Children { get; set; }
		public int Salary { get; set; }
		public int Id { get; set; }
		public int PulpitId { get; set; }

		public Pulpit Pulpit { get; set; }
		
		public ICollection<Pulpit> Pulpits { get; set; }
		public Lecturer()
		{
			Pulpits = new List<Pulpit>();
		}
	}
}