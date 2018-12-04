using System.Collections.Generic;

namespace BlazorDB.App.Models
{
	public class ScienceDirection : Node
	{
		public int Id { get; set; }
		public string DirectionName { get; set; }
		public int LecturerId { get; set; }
		
		public Lecturer Lecturer { get; set; }

		public ICollection<Lecturer> Lecturers { get; set; }

		public ScienceDirection()
		{
			Lecturers = new List<Lecturer>();
		}
	}
}