using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Models;

namespace TeamSalesTrackerApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<bool> Exists(string productName);
        Task<bool> ExistsById(long productId);
        Task<Product> CreateProduct(CreateProductCommand productData);
        Task<Product> UpdateProduct(UpdateProductCommand productData);
        Task<Product> DeleteProduct(long productId);
        Task<List<Product>> GetAll();
        Task<Product> GetById(long productId);
    }
}
