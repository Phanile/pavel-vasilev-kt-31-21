using Microsoft.EntityFrameworkCore;
using PavelVasilevKT_31_21.DataBase;
using PavelVasilevKT_31_21.DTOs;
using PavelVasilevKT_31_21.Interfaces;
using PavelVasilevKT_31_21.Models;

namespace PavelVasilevKT_31_21.Services
{
    public class DisciplineService : IDisciplineService
    {
        private readonly TeachersDbContext _dbContext;

        public DisciplineService(TeachersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateDisciplineAsync(CreateDisciplineDTO dto)
        {
            await _dbContext.Disciplines.AddAsync(
                new Discipline
                {
                    Title = dto.Title
                }
            );

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDisciplineAsync(DeleteDisciplineDTO dto)
        {
            var discipline = await _dbContext.Disciplines.FirstOrDefaultAsync(discipline => discipline.Title == dto.Title);

            if (discipline != null)
            {
                _dbContext.Remove(discipline);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateDisciplineAsync(UpdateDisciplineDTO dto)
        {
            var discipline = await _dbContext.Disciplines.FirstOrDefaultAsync(discipline => discipline.Title == dto.OldTitle);

            if (discipline != null)
            {
                discipline.Title = dto.NewTitle;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
