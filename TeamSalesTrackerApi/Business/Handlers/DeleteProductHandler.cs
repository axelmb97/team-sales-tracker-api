using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Models;
using TeamSalesTrackerApi.Results.Products;
using TeamSalesTrackerApi.Services.Interfaces;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ProductResult>
    {
        
        private readonly IProductService _productService;
        public DeleteProductHandler(IProductService service)
        {
            _productService = service;
        }

        public async Task<ProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var result = new ProductResult();
            if (request.ProductId < 1) {
                result.SetError("El id del producto no puede ser menor a 1", System.Net.HttpStatusCode.BadRequest);
                return result;
            }
            var product = await _productService.ExistsById(request.ProductId);
            if (!product)
            {
                result.SetError("No puede eliminar un objeto que no existe", System.Net.HttpStatusCode.BadRequest);
                return result;
            }

            result.Product = await _productService.DeleteProduct(request.ProductId);
            result.Message = "Producto eliminado con éxito";
            return result;
        }
    }
}
