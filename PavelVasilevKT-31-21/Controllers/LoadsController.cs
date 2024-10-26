using Microsoft.AspNetCore.Mvc;
using PavelVasilevKT_31_21.DTOs;
using PavelVasilevKT_31_21.Filters;
using PavelVasilevKT_31_21.Interfaces;
using PavelVasilevKT_31_21.Services;

namespace PavelVasilevKT_31_21.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LoadsController : ControllerBase
    {
        private readonly ILoadService _loadService;

        public LoadsController(ILoadService loadService)
        {
            _loadService = loadService;
        }

        [HttpPost(Name = "GetLoads")]
        public async Task<IActionResult> GetLoads(LoadFilter filter)
        {
            var result = await _loadService.GetLoadsAsync(filter);

            return Ok(result);
        }
    }
}
