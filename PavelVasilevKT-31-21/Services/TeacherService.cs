using Microsoft.EntityFrameworkCore;
using PavelVasilevKT_31_21.DataBase;
using PavelVasilevKT_31_21.Filters;
using PavelVasilevKT_31_21.Interfaces;
using PavelVasilevKT_31_21.Models;

namespace PavelVasilevKT_31_21.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly TeachersDbContext _dbContext;

        public TeacherService(TeachersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Teacher> GetTeacherByNameAsync(TeacherNameFilter filter, CancellationToken cancellationToken)
        {
            var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(teacher => teacher.Name == filter.Name);

            if (teacher != null)
            {
                return teacher;
            }

            return null;
        }
    }
}
