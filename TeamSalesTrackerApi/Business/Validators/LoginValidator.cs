using FluentValidation;
using TeamSalesTrackerApi.Business.Commands;

namespace TeamSalesTrackerApi.Business.Validators
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("El email no puede estar vacio")
                .NotNull().WithMessage("El email es un campo requerido")
                .EmailAddress().WithMessage("Debe ingresar un email válido");
            RuleFor(u => u.Password)
                .NotNull().WithMessage("La contraseña es un campo requerido")
                .NotEmpty().WithMessage("La contraseña no puede estar vacia");
        }
    }
}
