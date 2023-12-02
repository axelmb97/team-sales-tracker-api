using FluentValidation;
using TeamSalesTrackerApi.Business.Commands;

namespace TeamSalesTrackerApi.Business.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("El nombre del producto es requerido")
                .NotEmpty().WithMessage("El nombre del producto no puede estar vacio")
                .MaximumLength(50).WithMessage("El nombre del producto no puede superar los 50 carácteres");
        }
    }
}
