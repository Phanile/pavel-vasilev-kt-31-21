namespace PavelVasilevKT_31_21.Models
{
	public class Teacher
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public ICollection<Discipline> Disciplines { get; set; }
	}
}
