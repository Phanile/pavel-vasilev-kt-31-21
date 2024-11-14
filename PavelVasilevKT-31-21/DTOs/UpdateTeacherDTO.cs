namespace PavelVasilevKT_31_21.DTOs
{
    public class UpdateTeacherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int DepartmentId { get; set; }
    }
}
