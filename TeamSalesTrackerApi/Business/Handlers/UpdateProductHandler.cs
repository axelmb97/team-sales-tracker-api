using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Models;
using TeamSalesTrackerApi.Results.Products;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductResult>
    {
        private readonly SalesTrackerDB _data;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateProductCommand> _validator;

        public UpdateProductHandler(SalesTrackerDB data, IMapper mapper, IValidator<UpdateProductCommand> validator)
        {
            _data = data;
            _mapper = mapper;
            _validator = validator;
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
            var existingProduct = await _data.Products.FirstOrDefaultAsync(p => p.ProductId.Equals(request.ProductId));
            if (existingProduct == null) { 
                result.SetError($"El producto con id {request.ProductId} no existe", HttpStatusCode.BadRequest);
                return result;
            }

            existingProduct.ProductId = request.ProductId;
            existingProduct.Name = request.Name;
            existingProduct.Remarks = request.Remarks;

            _data.Products.Update(existingProduct);
             await _data.SaveChangesAsync();

            result.Product = existingProduct;
            result.Message = "Producto modificado con éxito";

            return result;
        }
    }
}
