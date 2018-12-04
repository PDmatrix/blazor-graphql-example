using System;
using System.Collections.Generic;

namespace BlazorDB.App.Models
{
	public class Plan : Node
	{
		public int Id { get; set; }
		public int HourCount { get; set; }
		public string OccupationType { get; set; }
		public string FormControl { get; set; }
		public string DateStart { get; set; }
		public string DateEnd { get; set; }
		public int DisciplineId { get; set; }
		public int LecturerId { get; set; }

		public Discipline Discipline { get; set; }
		public Lecturer Lecturer { get; set; }

		public ICollection<Discipline> Disciplines { get; set; }
		public ICollection<Lecturer> Lecturers { get; set; }

		public Plan()
		{
			Disciplines = new List<Discipline>();
			Lecturers = new List<Lecturer>();
		}
	}
}