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
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductResult>
    {
        private readonly IValidator<UpdateProductCommand> _validator;
        private readonly IProductService _productService;
        public UpdateProductHandler(IValidator<UpdateProductCommand> validator, IProductService productService)
        {
            _validator = validator;
            _productService = productService;
        }

        public async Task<ProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var result = new ProductResult();
            var validations = await _validator.ValidateAsync(request);
            if (!validations.IsValid) {
                var errors = String.Join(Environment.NewLine, validations.Errors);
                result.SetError(errors, HttpStatusCode.BadRequest);
                return result;
            }
            var existingProduct = await _productService.ExistsById(request.ProductId);
            if (!existingProduct) { 
                result.SetError($"El producto con id {request.ProductId} no existe", HttpStatusCode.BadRequest);
                return result;
            }

            result.Product = await _productService.UpdateProduct(request);
            result.Message = "Producto modificado con éxito";

            return result;
        }
    }
}
