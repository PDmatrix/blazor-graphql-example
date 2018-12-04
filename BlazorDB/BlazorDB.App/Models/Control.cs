using System.Collections.Generic;

namespace BlazorDB.App.Models
{
	public class Control : Node
	{
		public int Id { get; set; }
		public int StudentId { get; set; }
		public int LecturerId { get; set; }
		public int DisciplineId { get; set; }
		public int Grade { get; set; }
		public string FormControl { get; set; }
		public int SemesterNum { get; set; }

		public Student Student { get; set; }
		public Lecturer Lecturer { get; set; }
		public Discipline Discipline { get; set; }

		public ICollection<Student> Students { get; set; }
		public ICollection<Lecturer> Lecturers{ get; set; }
		public ICollection<Discipline> Disciplines { get; set; }

		public Control()
		{
			Students = new List<Student>();
			Lecturers = new List<Lecturer>();
			Disciplines = new List<Discipline>();
		}
	}	
}