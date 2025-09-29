using KanDann.Server.Services.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KanDann.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("user-is-new")]
        public async Task<ActionResult<bool>> UserIsNew()
        {
            string emailClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email || c.Type == "email").Value;
            return Ok(await _userService.UserIsNew(emailClaim));
        }
    }
}
