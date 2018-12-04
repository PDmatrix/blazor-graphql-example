using System.Collections.Generic;

namespace BlazorDB.App.Models
{
	public class ScienceTheme : Node
	{
		public int Id { get; set; }
		public string ThemeName { get; set; }
		public int LecturerId { get; set; }
		
		public Lecturer Lecturer { get; set; }
		
		public ICollection<Lecturer> Lecturers { get; set; }

		public ScienceTheme()
		{
			Lecturers = new List<Lecturer>();
		}
	}
}