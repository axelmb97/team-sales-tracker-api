using FluentValidation;
using TeamSalesTrackerApi.Business.Commands;

namespace TeamSalesTrackerApi.Business.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(c => c.ProductId)
                .NotEmpty().WithMessage("El id del producto no puede estar vacio")
                .NotNull().WithMessage("El id del producto es requerido")
                .GreaterThan(0).WithMessage("El id del producto no puede ser menor a 1");
            RuleFor(p => p.Name).NotNull().WithMessage("El nombre del producto es requerido")
                .NotEmpty().WithMessage("El nombre del producto no puede estar vacio")
                .MaximumLength(50).WithMessage("El nombre del producto no puede superar los 50 carácteres");
        }
    }
}
