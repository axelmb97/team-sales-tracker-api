using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Results.Auth;

namespace TeamSalesTrackerApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<RegisterResult> RegisterUser(RegisterUserCommand userData);
        Task<string> VerifyCredentials(string email, string password);
    }
}
