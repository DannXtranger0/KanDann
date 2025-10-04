using KanDann.Server.Models.Dtos;
using KanDann.Server.Services.Auth;
using KanDann.Server.Services.Workplace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KanDann.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkplaceController : ControllerBase
    {
        private readonly IWorkplaceService _workplaceService;
        public WorkplaceController(IWorkplaceService workplaceService)
        {
            _workplaceService = workplaceService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WorkPlaceDto model)
        {
            string userGoogleId = User.Claims.FirstOrDefault(c=>c.Type == "sub")!.Value;

            await _workplaceService.Create(model, userGoogleId);
            return Ok(new {success =true, message="Workplace creado"});
        }
    }
}
