using FluentValidation;
using TeamSalesTrackerApi.Business.Commands;

namespace TeamSalesTrackerApi.Business.Validators
{
    public class PaginationValidator : AbstractValidator<ProductPaginationCommand>
    {
        public PaginationValidator()
        {
            RuleFor(p => p.PageNumber)
                .NotNull().WithMessage("El numero de pagina es un campo requerido")
                .GreaterThanOrEqualTo(0).WithMessage("El numero de pagina debe ser  mayor o igual a 0");
            RuleFor(p => p.pageSize)
                .NotNull().WithMessage("El tamaño de pagina es un campo requerido")
                .GreaterThan(0).WithMessage("El tamaño de pagina debe ser mayor a 0");
        }
    }
}
