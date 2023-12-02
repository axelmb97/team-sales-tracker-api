using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TeamSalesTrackerApi.Models;
using TeamSalesTrackerApi.Services.Interfaces;

namespace TeamSalesTrackerApi.Services.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _symmetricSecutiryKey;
        private readonly IConfiguration _configs;
        public TokenService(IConfiguration configs)
        {
            _configs = configs;
            this._symmetricSecutiryKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configs["JWT:key"]));
        }

        public string CreateToken(User user)
        {
            var credentials = new SigningCredentials(_symmetricSecutiryKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())

            };

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(240),
                SigningCredentials = credentials,
                Issuer = _configs["JWT:Issuer"],
                Audience = _configs["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GetClaims(ClaimsIdentity identity)
        {
            var claims = identity.Claims;

            return claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Email)).Value;
        }
    }
}
