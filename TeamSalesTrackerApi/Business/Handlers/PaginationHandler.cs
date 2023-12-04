using FluentValidation;
using MediatR;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Models;
using TeamSalesTrackerApi.Results.Pagination;
using TeamSalesTrackerApi.Services.Interfaces;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class PaginationHandler : IRequestHandler<ProductPaginationCommand, PaginationResult<Product>>
    {
        private readonly IProductService _productService;
        private readonly IValidator<ProductPaginationCommand> _validator;
        public PaginationHandler(IProductService productService, IValidator<ProductPaginationCommand> validator)
        {
            _productService = productService;
            _validator = validator;
        }

        public async Task<PaginationResult<Product>> Handle(ProductPaginationCommand request, CancellationToken cancellationToken)
        {
            var result = new PaginationResult<Product>();
            var validations = await _validator.ValidateAsync(request);
            if (!validations.IsValid) {
                var errors = String.Join(Environment.NewLine, validations.Errors);
                result.SetError(errors, System.Net.HttpStatusCode.BadRequest);
                return result;
            }
            var products = await _productService.GetPaginatedProducts(request);
            result.Result = products;
            result.Message = "Productos recuperados con éxitos";
            return result;
        }
    }
}
