using Microsoft.EntityFrameworkCore;
using PavelVasilevKT_31_21.DataBase;
using PavelVasilevKT_31_21.Filters;
using PavelVasilevKT_31_21.Interfaces;
using PavelVasilevKT_31_21.Models;

namespace PavelVasilevKT_31_21.Services
{
    public class LoadService : ILoadService
    {
        private readonly TeachersDbContext _dbContext;

        public LoadService(TeachersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Load>> GetLoadsAsync(LoadFilter filter)
        {
            var query = _dbContext.Loads.AsQueryable();

            query = ApplyFilters(query, filter);

            return await query.AsNoTracking().ToListAsync();
        }

        private IQueryable<Load> ApplyFilters(IQueryable<Load> query, LoadFilter filter)
        {
            if (!string.IsNullOrWhiteSpace(filter.TeacherName))
            {
                query = query.Where(load => load.Teacher.Name == filter.TeacherName);
            }

            if (!string.IsNullOrWhiteSpace(filter.DepartmentTitle))
            {
                query = query.Where(load => load.Teacher.Department.Title == filter.DepartmentTitle);
            }

            if (!string.IsNullOrWhiteSpace(filter.DisciplineTitle))
            {
                query = query.Where(load => load.Discipline.Title == filter.DisciplineTitle);
            }

            return query;
        }
    }
}
