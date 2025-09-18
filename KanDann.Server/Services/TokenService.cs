using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KanDann.Server.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _signingKey;
        private readonly string _issuer;
        private readonly string _audience;

        public TokenService(IConfiguration configuration)
        {
            //Read the Jwt section from appsettings
            var jwtConfig = configuration.GetSection("Jwt");
            var secret = jwtConfig["Key"]!;
            _issuer = jwtConfig["Issuer"]!;
            _audience = jwtConfig["Audience"]!;

            //create the symmetric key from the secret(Key)
            _signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

        }
        public string CreateToken(ClaimsPrincipal principal)
        {
            //Sign credentials
            var creds = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);

            //Claims Section
            var claims = principal.Claims
                .Where(c =>
                    c.Type == ClaimTypes.NameIdentifier ||
                    c.Type == ClaimTypes.Email ||
                    c.Type == ClaimTypes.Name)
                .Select(c => new Claim(c.Type, c.Value))
                .ToList();

            //create descriptor token
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
                );

            //serialize token
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
