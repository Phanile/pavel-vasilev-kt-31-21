using Microsoft.AspNetCore.Mvc;
using PavelVasilevKT_31_21.Filters;
using PavelVasilevKT_31_21.Interfaces;

namespace PavelVasilevKT_31_21.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TeachersController : ControllerBase
    {
        private readonly ILogger<TeachersController> _logger;
        private readonly ITeacherService _teacherService;

        public TeachersController(ILogger<TeachersController> logger, ITeacherService teacherService)
        {
            _logger = logger;
            _teacherService = teacherService;
        }

        [HttpPost(Name = "GetTeacherByName")]
        public async Task<IActionResult> GetTeacherByFullName(TeacherNameFilter filter, CancellationToken cancellationToken)
        {
            var result =  await _teacherService.GetTeacherByNameAsync(filter, cancellationToken);

            return Ok(result);
        }
    }
}
