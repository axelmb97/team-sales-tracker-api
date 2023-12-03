using FluentValidation;
using MediatR;
using System.Net;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Results.Auth;
using TeamSalesTrackerApi.Services.Interfaces;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, RegisterResult>
    {
        private readonly IAuthService _authService;
        private readonly IValidator<RegisterUserCommand> _validator;
        public RegisterUserHandler(IAuthService service, IValidator<RegisterUserCommand> validator)
        {
            this._authService = service;
            this._validator = validator;
        }

        public async Task<RegisterResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            //TODO: REVISAR RELACION CON ADDRESS
            var result = new RegisterResult();
            var validations = await _validator.ValidateAsync(request);
            if (!validations.IsValid) {
                var error = String.Join(Environment.NewLine, validations.Errors);
                result.SetError(error, HttpStatusCode.BadRequest);
                return result;
            }
            result = await _authService.RegisterUser(request);
            return result;
        }
    }
}
