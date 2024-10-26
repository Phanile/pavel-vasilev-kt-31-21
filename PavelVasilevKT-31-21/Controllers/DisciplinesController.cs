using Microsoft.AspNetCore.Mvc;
using PavelVasilevKT_31_21.DTOs;
using PavelVasilevKT_31_21.Filters;
using PavelVasilevKT_31_21.Interfaces;
using PavelVasilevKT_31_21.Services;

namespace PavelVasilevKT_31_21.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DisciplinesController : ControllerBase
    {
        private readonly IDisciplineService _disciplineService;

        public DisciplinesController(IDisciplineService disciplineService)
        {
            _disciplineService = disciplineService;
        }

        [HttpPost(Name = "CreateDiscipline")]
        public async Task<IActionResult> CreateDiscipline(CreateDisciplineDTO dto)
        {
            await _disciplineService.CreateDisciplineAsync(dto);

            return Ok();
        }

        [HttpPost(Name = "UpdateDiscipline")]
        public async Task<IActionResult> UpdateDiscipline(UpdateDisciplineDTO dto)
        {
            await _disciplineService.UpdateDisciplineAsync(dto);

            return Ok();
        }

        [HttpPost(Name = "DeleteDiscipline")]
        public async Task<IActionResult> DeleteDiscipline(DeleteDisciplineDTO dto)
        {
            await _disciplineService.DeleteDisciplineAsync(dto);

            return Ok();
        }
    }
}
