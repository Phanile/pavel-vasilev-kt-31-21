namespace PavelVasilevKT_31_21.Models
{
	public class Load
	{
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int DisciplineId { get; set; }
        public Teacher Teacher { get; set; }
        public Discipline Discipline { get; set; }
        public int LoadInHours { get; set; } = 1;
    }
}
