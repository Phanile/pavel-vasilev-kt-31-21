using Microsoft.EntityFrameworkCore;
using PavelVasilevKT_31_21.DataBase;
using PavelVasilevKT_31_21.Filters;
using PavelVasilevKT_31_21.Models;
using PavelVasilevKT_31_21.Services;

namespace PavelVasilevKT_31_21.Tests
{
    public class TeacherIntegrationTests
    {
        public readonly DbContextOptions<TeachersDbContext> _dbContext;

        public TeacherIntegrationTests()
        {
            _dbContext = new DbContextOptionsBuilder<TeachersDbContext>()
                .UseInMemoryDatabase(databaseName: "TeachersDB")
                .Options;
        }

        [Fact]
        public async Task GetLoadsByDisciplineAsync_Math_Object()
        {
            var dbContext = new TeachersDbContext(_dbContext);
            var loadService = new LoadService(dbContext);

            var department = new Department
            {
                Title = "ИВТ",
                HeadId = 1
            };

            await dbContext.Departments.AddAsync(department);

            var teachers = new List<Teacher>
            {
                new Teacher
                {
                    Name = "Ivan",
                    Surname = "Ivanov",
                    Patronymic = "Ivanovich",
                    DepartmentId = 1
                },
                new Teacher
                {
                    Name = "Petr",
                    Surname = "Petrov",
                    Patronymic = "Petrovich",
                    DepartmentId = 1
                }
            };

            await dbContext.Teachers.AddRangeAsync(teachers);

            var disciplines = new List<Discipline>
            {
                new Discipline
                {
                    Title = "Math",
                    TeacherId = 1
                },
                new Discipline
                {
                    Title = "Biology",
                    TeacherId = 1
                },
                new Discipline
                {
                    Title = "Coding",
                    TeacherId = 2
                }
            };

            await dbContext.Disciplines.AddRangeAsync(disciplines);

            var loads = new List<Load>
            {
                new Load
                {
                    TeacherId = 1,
                    DisciplineId = 1
                },
                new Load
                {
                    TeacherId = 1,
                    DisciplineId = 2
                },
                new Load
                {
                    TeacherId = 2,
                    DisciplineId = 3
                }
            };
            
            await dbContext.Loads.AddRangeAsync(loads);

            await dbContext.SaveChangesAsync();

            var filter = new LoadFilter
            {
                DisciplineTitle = "Math"
            };

            var result = await loadService.GetLoadsAsync(filter);

            Assert.Single(result);
        }
    }
}
