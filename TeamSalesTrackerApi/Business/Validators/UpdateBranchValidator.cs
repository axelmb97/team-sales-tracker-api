using FluentValidation;
using TeamSalesTrackerApi.Business.Commands;

namespace TeamSalesTrackerApi.Business.Validators
{
    public class UpdateBranchValidator : AbstractValidator<UpdateBranchCommand>
    {
        public UpdateBranchValidator()
        {
            
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("El nombre de la sucursal no puede estar vacio")
                .NotNull().WithMessage("El nombre de la sucursal es un campo requerido")
                .MinimumLength(4).WithMessage("El nombre de la sucursal debe tener al menos 4 carácteres");
            RuleFor(b => b.BranchNumber)
                .NotEmpty().WithMessage("El nro de sucursal no puede estar vacio")
                .NotNull().WithMessage("El nro de sucursal es un campo requerido")
                .GreaterThan(0).WithMessage("El nro de sucursal no puede ser menor a 1");
            RuleFor(b => b.StreetName)
               .NotEmpty().WithMessage("El campo calle no puede estar vacio")
               .NotNull().WithMessage("La calle es un campo requerido")
               .MinimumLength(4).WithMessage("La calle debe contener al menos 4 caracteres")
               .MaximumLength(200).WithMessage("La calle puede tener un máximo de 200 carácteres");
            RuleFor(b => b.StreetNumber)
               .NotEmpty().WithMessage("El nro de direccion no puede estar vacio")
               .NotNull().WithMessage("El nro de direccion es un campo requerido")
               .GreaterThan(0).WithMessage("El nro de direccion no puede ser menor a 1");

            RuleFor(b => b.BranchId)
                .NotEmpty().WithMessage("El id de la sucursal no puede estar vacio")
                .NotNull().WithMessage("El id de la sucursal es un campo requerido");
            RuleFor(b => b.AddressId)
               .NotEmpty().WithMessage("El id de la direccion de la sucursal no puede estar vacio")
               .NotNull().WithMessage("El id de la direccion de la sucursall es un campo requerido");

        }
    }
}
