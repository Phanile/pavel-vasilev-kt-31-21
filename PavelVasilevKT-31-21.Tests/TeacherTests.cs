using PavelVasilevKT_31_21.Models;

namespace PavelVasilevKT_31_21.Tests
{
    public class TeacherTests
    {
        [Fact]
        public void ChechTeacherHasLongPatronymic_Ivanovich_True()
        {
            var testTeacher = new Teacher
            {
                Name = "Ivan",
                Surname = "Ivanov",
                Patronymic = "Ivanovich"
            };

            var result = testTeacher.HasLongPatronymic;

            Assert.True(result);
        }
    }
}