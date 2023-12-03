using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Models;
using TeamSalesTrackerApi.Results.Products;
using TeamSalesTrackerApi.Services.Interfaces;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResult>
    {
        private readonly IValidator<CreateProductCommand> _validator;
        private readonly IProductService _productService;
        public CreateProductHandler(IValidator<CreateProductCommand> validator, IProductService productService)
        {
            _validator = validator;
            _productService = productService;
        }

        public async Task<ProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var result = new ProductResult();
            var validations = await _validator.ValidateAsync(request);
            if (!validations.IsValid) {
                var errors = String.Join(Environment.NewLine, validations.Errors);
                result.SetError(errors, HttpStatusCode.BadRequest);
                return result;
            }


            var existingProduct = await _productService.Exists(request.Name);
            if (existingProduct) {
                result.SetError("Ya existe un producto con este nombre", HttpStatusCode.BadRequest);
                return result;
            }

            result.Message = "Producto registrado con éxito";
            result.Product = await _productService.CreateProduct(request);


            return result;
        }
    }
}
