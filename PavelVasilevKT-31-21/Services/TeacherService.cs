using Microsoft.EntityFrameworkCore;
using PavelVasilevKT_31_21.DataBase;
using PavelVasilevKT_31_21.DTOs;
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

        public async Task CreateTeacherAsync(CreateTeacherDTO dto, CancellationToken cancellationToken)
        {
            await _dbContext.Teachers.AddAsync(
                new Teacher
                {
                    Name = dto.Name,
                    Surname = dto.Surname,
                    Patronymic = dto.Patronymic,
                    DepartmentId = dto.DepartmentId
                }
            );

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTeacherAsync(UpdateTeacherDTO dto, CancellationToken cancellationToken)
        {
            var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(teacher => teacher.Id == dto.Id);

            if (teacher != null)
            {
                var department = await _dbContext.Departments.FirstOrDefaultAsync(department => department.Id == dto.DepartmentId);

                if (department != null)
                {
                    teacher.Name = dto.Name;
                    teacher.Surname = dto.Surname;
                    teacher.Patronymic = dto.Patronymic;
                    teacher.DepartmentId = dto.DepartmentId;

                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Department с таким Id не существует!");
                }
            }
            else
            {
                throw new Exception("Teacher с таким Id не существует!");
            }
        }

        public async Task DeleteTeacherAsync(DeleteTeacherDTO dto, CancellationToken cancellationToken)
        {
            var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(teacher => teacher.Id == dto.Id);

            if (teacher != null)
            {
                _dbContext.Teachers.Remove(teacher);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Teacher с таким Id не существует!");
            }
        }

        public async Task<Teacher> GetTeacherByNameAsync(TeacherNameFilter filter, CancellationToken cancellationToken)
        {
            var teacher = await _dbContext.Teachers.FirstOrDefaultAsync(teacher => teacher.Name == filter.Name);

            if (teacher != null)
            {
                return teacher;
            }
            else
            {
                throw new Exception("Такого Teacher не существует!");
            }
        }
    }
}
