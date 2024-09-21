using PavelVasilevKT_31_21.Filters;
using PavelVasilevKT_31_21.Models;

namespace PavelVasilevKT_31_21.Interfaces
{
    public interface ITeacherService
    {
        Task<Teacher> GetTeacherByNameAsync(TeacherNameFilter filter, CancellationToken cancellationToken);
    }
}
