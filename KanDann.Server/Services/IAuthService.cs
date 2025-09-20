using KanDann.Server.Models.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KanDann.Server.Services
{
    public interface IAuthService
    {
        public AuthenticationProperties BuildAuthenticationProperties([FromQuery] string? returnUrl = null);
        public Task<IActionResult> PostSignIn([FromQuery] string? returnUrl = null);
        public Task<IActionResult> SignOut();
        public Task<ClaimsPrincipal> AuthWithCookies();
        public UserClaimsDto getUserClaims(ClaimsPrincipal claimsPrincipal);
        public Task SaveUserInDb(UserClaimsDto userClaimsDto);

    }
}
