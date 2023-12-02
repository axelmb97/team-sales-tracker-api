using FluentValidation;
using TeamSalesTrackerApi.Business.Commands;

namespace TeamSalesTrackerApi.Business.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(u => u.FirstName).NotNull().WithMessage("El nombre no puede ser nulo")
                .NotEmpty().WithMessage("El nombre no puede estar vacio");
            RuleFor(u => u.LastName).NotNull().WithMessage("El apellido no puede ser nulo")
                .NotEmpty().WithMessage("El apellido no puede estar vacio");
            RuleFor(u => u.Email).NotNull().WithMessage("El email es un campo requerido")
                .NotEmpty().WithMessage("El email no puede estarr vacio")
                .EmailAddress().WithMessage("Debe ingresar un email válido");
            RuleFor(u => u.Password)
                .MinimumLength(8).WithMessage("La contraseña debe contener al menos 8 caracteres");
            RuleFor(u => u.DateOfBirth)
                .Must(ValidDate).WithMessage("La fecha no puede ser posterior a la actual")
                .Must(ValidateAge).WithMessage("Debes tener al menos 18 años para registrate");
        }
        private bool ValidDate(DateTime date) {
            return DateTime.Today > date;
        }
        private bool ValidateAge(DateTime bornDate) {
            int age = DateTime.Today.Year - bornDate.Year;
            if (bornDate.Month > DateTime.Today.Month) {
                age--;
            }
            return age >= 18;
        }
    }
}
