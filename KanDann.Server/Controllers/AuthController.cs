using KanDann.Server.Models;
using KanDann.Server.Models.Context;
using KanDann.Server.Services.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace KanDann.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService) {
               _authService = authService;
        }

        // --------------------------
        // 1) Iniciar login (Challenge)
        // --------------------------
        // GET /api/auth/signin?returnUrl=https://localhost:56205/
        [HttpGet("signin")]
        public IActionResult SignIn([FromQuery] string? returnUrl = null)
        {
            return Challenge(_authService.BuildAuthenticationProperties(), OpenIdConnectDefaults.AuthenticationScheme);
        }

        // --------------------------
        // 2) Endpoint que ejecuta la lógica después del signin
        // --------------------------
        // GET /api/auth/postsignin?returnUrl=...
        [HttpGet("postsignin")]
        public async Task<IActionResult> PostSignIn([FromQuery] string? returnUrl = null)
        {
            var userPrincipal = await _authService.AuthWithCookies();
            if (userPrincipal == null) {
                return BadRequest("No se pudo autenticar");
            }

            var userClaims = _authService.getUserClaims(userPrincipal);
            if (userClaims == null) {
                return BadRequest("No se encontraron claims validas");
            }

            await _authService.SaveUserInDb(userClaims);

            // Finalmente redirigimos al frontend (o al returnUrl si fue provisto)
            var redirect = returnUrl ?? "https://localhost:56205/new-user";
            return Redirect(redirect);
        }

        // --------------------------
        // 3) Logout (local cookie only)
        // --------------------------
        // GET /api/auth/signout
        [HttpGet("signout")]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // Redirigir al frontend
            return Redirect("https://localhost:56205/");
        }

        // --------------------------
        // 4) Info del usuario (consume la SPA con credentials: 'include')
        // --------------------------
        // GET /api/auth/user
        [HttpGet("user")]
        public async Task<IActionResult> GetUser()
        {
            var auth = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!auth.Succeeded || auth.Principal == null || !(auth.Principal.Identity?.IsAuthenticated ?? false))
            {
                return Unauthorized();
            }

            var claims = auth.Principal.Claims.Select(c => new { c.Type, c.Value }).ToList();
            return Ok(new { claims });
        }

        // --------------------------
        // 5) Ejemplo: usar access_token para llamar Google People API (desde server)
        // --------------------------
        // GET /api/auth/google/profile
        //[HttpGet("google/profile")]
        //public async Task<IActionResult> GetGoogleProfile()
        //{
        //    var auth = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    if (!auth.Succeeded || auth.Principal == null)
        //        return Unauthorized();

        //    // access_token fue guardado en AuthenticationProperties por SaveTokens = true
        //    var accessToken = auth.Properties.GetTokenValue("access_token");
        //    var refreshToken = auth.Properties.GetTokenValue("refresh_token");
        //    var expiresAt = auth.Properties.GetTokenValue("expires_at");

        //    if (string.IsNullOrEmpty(accessToken))
        //        return StatusCode(403, "Access token missing");

        //    var client = _httpClientFactory.CreateClient();
        //    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

        //    var resp = await client.GetAsync("https://people.googleapis.com/v1/people/me?personFields=names,emailAddresses,photos");
        //    if (!resp.IsSuccessStatusCode)
        //    {
        //        var txt = await resp.Content.ReadAsStringAsync();
        //        return StatusCode((int)resp.StatusCode, "Google API error");
        //    }

        //    var content = await resp.Content.ReadAsStringAsync();
        //    return Content(content, "application/json");
        //}
    }
}
