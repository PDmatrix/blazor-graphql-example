using System.Collections.Generic;

namespace BlazorDB.App.Models
{
	public class Advocacy : Node
	{
		public int Id { get; set; }
		public int LecturerId { get; set; }
		public int YearEnd { get; set; }
		public string AdvocacyType { get; set; }
		public string Theme { get; set; }

		public Lecturer Lecturer { get; set; }

		public ICollection<Lecturer> Lecturers { get; set; }

		public Advocacy()
		{
			Lecturers = new List<Lecturer>();
		}
	}
}