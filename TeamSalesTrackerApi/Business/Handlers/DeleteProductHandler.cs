using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Models;
using TeamSalesTrackerApi.Results.Products;

namespace TeamSalesTrackerApi.Business.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ProductResult>
    {
        private readonly SalesTrackerDB _data;
        public DeleteProductHandler(SalesTrackerDB data)
        {
            _data = data;
        }

        public async Task<ProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var result = new ProductResult();
            if (request.ProductId < 1) {
                result.SetError("El id del producto no puede ser menor a 1", System.Net.HttpStatusCode.BadRequest);
                return result;
            }
            var product = await _data.Products.FirstOrDefaultAsync(p => p.ProductId.Equals(request.ProductId));
            if (product == null)
            {
                result.SetError("No puede eliminar un objeto que no existe", System.Net.HttpStatusCode.BadRequest);
                return result;
            }
            _data.Products.Remove(product);
            await _data.SaveChangesAsync();

            result.Product = new Product { 
                ProductId = request.ProductId,
                Name = product.Name,
                Remarks = product.Remarks
            };
            result.Message = "Producto eliminado con éxito";
            return result;
        }
    }
}
