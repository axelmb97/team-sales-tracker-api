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
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResult>
    {
        private readonly SalesTrackerDB _data;
        private readonly IValidator<CreateProductCommand> _validator;
        private readonly IMapper _mapper;
        public CreateProductHandler(SalesTrackerDB data, IValidator<CreateProductCommand> validator, IMapper mapper)
        {
            _data = data;
            _validator = validator;
            _mapper = mapper;   
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

            var existingProduct = await _data.Products
                .FirstOrDefaultAsync( p => p.Name.ToUpper().Equals(request.Name.ToUpper()));

            if (existingProduct != null) {
                result.SetError("Ya existe un producto con este nombre", HttpStatusCode.BadRequest);
                return result;
            }

            var newProduct = _mapper.Map<Product>(request);
            _data.Products.Add(newProduct);
            await _data.SaveChangesAsync();

            result.Message = "Producto registrado con éxito";
            result.Product = newProduct;


            return result;
        }
    }
}
