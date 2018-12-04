using System.Collections.Generic;

namespace BlazorDB.App.Models
{
	public class Diploma : Node
	{
		public int Id { get; set; }
		public string Theme { get; set; }
		public int StudentId { get; set; }
		public int LecturerId { get; set; }

		public Student Student { get; set; }
		public Lecturer Lecturer { get; set; }
		
		public ICollection<Student> Students { get; set; }
		public ICollection<Lecturer> Lecturers{ get; set; }

		public Diploma()
		{
			Students = new List<Student>();
			Lecturers = new List<Lecturer>();
		}
	}
}