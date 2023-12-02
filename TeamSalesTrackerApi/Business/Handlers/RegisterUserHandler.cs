using MediatR;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Results.Auth;
using TeamSalesTrackerApi.Services.Interfaces;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, RegisterResult>
    {
        private readonly IAuthService _authService;
        public RegisterUserHandler(IAuthService service)
        {
            this._authService = service;
        }

        public async Task<RegisterResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var result = new RegisterResult();
            result = await _authService.RegisterUser(request);
            return result;
        }
    }
}
