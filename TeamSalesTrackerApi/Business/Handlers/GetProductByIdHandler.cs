using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamSalesTrackerApi.Business.Queries;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Results.Products;
using TeamSalesTrackerApi.Services.Interfaces;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResult>
    {
        private readonly IProductService _productService;
        public GetProductByIdHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new ProductResult();
            if (request.ProductId <= 0) {
                result.SetError("El id del producto no puede ser menor a 1", System.Net.HttpStatusCode.BadRequest);
                return result;
            }
            var product = await _productService.GetById(request.ProductId);
            if (product == null) {
                result.SetError($"No existe un producto registrado con id {request.ProductId}", System.Net.HttpStatusCode.NotFound);
                return result;
            }
            result.Product = product;
            result.Message = "Producto recuperado con éxito";

            return result;
        }
    }
}
