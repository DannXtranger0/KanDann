using System.Security.Claims;

namespace KanDann.Server.Services
{
    public interface ITokenService
    {
        string CreateToken(ClaimsPrincipal principal);
    }
}
