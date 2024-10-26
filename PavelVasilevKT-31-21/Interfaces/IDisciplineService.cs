using PavelVasilevKT_31_21.DTOs;

namespace PavelVasilevKT_31_21.Interfaces
{
    public interface IDisciplineService
    {
        Task CreateDisciplineAsync(CreateDisciplineDTO dto);
        Task UpdateDisciplineAsync(UpdateDisciplineDTO dto);
        Task DeleteDisciplineAsync(DeleteDisciplineDTO dto);
    }
}
