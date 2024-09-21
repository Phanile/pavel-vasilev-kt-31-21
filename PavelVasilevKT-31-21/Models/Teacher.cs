namespace PavelVasilevKT_31_21.Models
{
	public class Teacher
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Patronymic { get; set; }
		public ICollection<Discipline> Disciplines { get; set; }
	}
}
