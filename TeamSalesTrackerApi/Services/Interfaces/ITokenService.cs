using System.Security.Claims;
using TeamSalesTrackerApi.Models;

namespace TeamSalesTrackerApi.Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
        string GetClaims(ClaimsIdentity identity);
    }
}
