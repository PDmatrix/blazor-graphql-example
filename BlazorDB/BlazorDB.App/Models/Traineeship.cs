using System.Collections.Generic;

namespace BlazorDB.App.Models
{
	public class Traineeship : Node
	{
		public int Id { get; set; }
		public int LecturerId { get; set; }

		public Lecturer Lecturer { get; set; }
		
		public ICollection<Lecturer> Lecturers { get; set; }

		public Traineeship()
		{
			Lecturers = new List<Lecturer>();
		}
	}
}