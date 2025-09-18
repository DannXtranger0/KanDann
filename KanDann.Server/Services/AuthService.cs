using Azure.Core;
using KanDann.Server.Controllers;
using KanDann.Server.Models;
using KanDann.Server.Models.Context;
using KanDann.Server.Models.dtos;
using KanDann.Server.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;

namespace KanDann.Server.Services
{
    public class AuthService : IAuthService
    {
        private readonly MyDbContext _context;
        private readonly IHttpContextAccessor _contextAccesor;
        private readonly ILogger<AuthController> _logger;
        private readonly LinkGenerator _linkGenerator;
        private readonly ChallengeResult _challengeResult;
        private readonly IUserRepository _userRepo;
        public AuthService(IUserRepository userRepo, LinkGenerator linkGenerator, MyDbContext db, IHttpContextAccessor contextAccesor)
        {
            _context = db;
            _contextAccesor = contextAccesor;
            _linkGenerator = linkGenerator;
            _userRepo = userRepo;
        }

        public async Task<ClaimsPrincipal> AuthWithCookies()
        {
            // Autenticar con el esquema de cookies
            // (El OIDC Middleware debería haber iniciado sesión y creado la cookie)
            var authResult = await _contextAccesor.HttpContext!.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!authResult.Succeeded || authResult.Principal == null)
            {
                return null;
                //return BadRequest("No se encontró una sesión válida después del login.");
            }

            return  authResult.Principal;
        }

        public AuthenticationProperties BuildAuthenticationProperties( string? returnUrl = null)
        {
            // Construimos la URL absoluta donde queremos que el BFF procese y luego llame a PostSignIn.
            // Url.Action con protocol genera una URL absoluta con el mismo host que está ejecutando la petición (backend).

            var httpContext = _contextAccesor.HttpContext;
        
            var postSignInUrl = _linkGenerator.GetUriByAction(
                httpContext!,
                action: "PostSignIn",
                controller:"Auth",
                values: new {returnUrl}
                );

            return new AuthenticationProperties
            {
                RedirectUri = postSignInUrl // after the middleware processes /signin-oidc it will redirect here
            };
        }

        public UserClaimsDto getUserClaims(ClaimsPrincipal claimsPrincipal)
        {
            // Extraer claims comunes (usa MapInboundClaims = false así tenemos 'sub','email','name','picture')
            string? googleId = claimsPrincipal.FindFirst("sub")?.Value;
            string? email = claimsPrincipal.FindFirst("email")?.Value ?? claimsPrincipal.FindFirst(ClaimTypes.Email)?.Value;
            string? name = claimsPrincipal.FindFirst("name")?.Value ?? claimsPrincipal.FindFirst(ClaimTypes.Name)?.Value;
            string? picture = claimsPrincipal.FindFirst("picture")?.Value;

            if (string.IsNullOrEmpty(googleId) || string.IsNullOrEmpty(email))
            {
                return null;
            }
        
             return new UserClaimsDto
             {
                 Email = email,
                 GoogleId = googleId,
                 Name  = name,
                 Picture = picture

             };
        }

        public async Task<IActionResult> PostSignIn([FromQuery] string? returnUrl = null)
        {
            throw new NotImplementedException();

        }

        public async Task SaveUserInDb(UserClaimsDto userClaimsDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => 
            u.GoogleUserId == userClaimsDto.GoogleId);

            if (user == null)
            {
                await _userRepo.SaveUser(userClaimsDto);
            }
            else
            {
                await _userRepo.UpdateUser(userClaimsDto, user);
            }

        }

        public async Task<IActionResult> SignOut()
        {
            throw new NotImplementedException();
        }

     
    }
}
