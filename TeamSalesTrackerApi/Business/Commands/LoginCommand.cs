using MediatR;
using TeamSalesTrackerApi.Results.Auth;

namespace TeamSalesTrackerApi.Business.Commands
{
    public class LoginCommand :IRequest<LoginResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
