using FluentValidation;
using MediatR;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Results.Auth;
using TeamSalesTrackerApi.Services.Interfaces;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResult>
    {
        private readonly IValidator<LoginCommand> _validator;
        private readonly IAuthService _authService;
        public LoginHandler(IValidator<LoginCommand> validator, IAuthService authService)
        {
            this._validator = validator;
            this._authService = authService;
        }
        public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = new LoginResult();
            var validations = await _validator.ValidateAsync(request);
            if (!validations.IsValid) {
                var errors = String.Join(Environment.NewLine, validations.Errors);
                result.SetError(errors, System.Net.HttpStatusCode.BadRequest);
                return result;
            }
            var token = await _authService.VerifyCredentials(request.Email, request.Password);
            if (String.IsNullOrEmpty(token)) {
                result.SetError("El email o contraseña son incorrectos", System.Net.HttpStatusCode.Unauthorized);
                return result;
            }
            result.Token = token;
            result.Message = "Se ha logueado correctamente";
            return result;
        }
    }
}
