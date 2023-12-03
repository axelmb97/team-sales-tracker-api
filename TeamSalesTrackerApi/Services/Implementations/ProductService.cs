using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamSalesTrackerApi.Business.Commands;
using TeamSalesTrackerApi.Data;
using TeamSalesTrackerApi.Dtos;
using TeamSalesTrackerApi.Models;
using TeamSalesTrackerApi.Services.Interfaces;

namespace TeamSalesTrackerApi.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly SalesTrackerDB _data;
        private readonly IMapper _mapper;
        private readonly IPaginationService _paginationService;
        public ProductService(SalesTrackerDB data, IMapper mapper, IPaginationService paginationService)
        {
            _data = data;
            _mapper = mapper;
            _paginationService = paginationService;
        }

        public async Task<Product> CreateProduct(CreateProductCommand productData)
        {
            var newProduct = _mapper.Map<Product>(productData);
            _data.Products.Add(newProduct);
            await _data.SaveChangesAsync();
            return newProduct;
        }

        public async Task<Product> DeleteProduct(long productId)
        {
            var product = await _data.Products.FirstOrDefaultAsync(p => p.ProductId.Equals(productId));
            _data.Products.Remove(product);
            await _data.SaveChangesAsync();
            return product;
        }

        public async Task<bool> Exists(string productName)
        {
            var existingProduct = await _data.Products
                .FirstOrDefaultAsync(p => p.Name.ToUpper().Equals(productName.ToUpper()));
            return existingProduct != null;
        }

        public async Task<bool> ExistsById(long productId)
        {
            var existingProduct = await _data.Products.FirstOrDefaultAsync(p => p.ProductId.Equals(productId));
            return existingProduct != null;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _data.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetById(long productId)
        {
           var product = await _data.Products.FirstOrDefaultAsync(p => p.ProductId.Equals(productId));
            return product;
        }

        public async Task<Pagination<Product>> GetPaginatedProducts(PaginationCommand paginationParams)
        {
            var query = _data.Products;
            return  await _paginationService.CreatePageGenericResults<Product>(
                query,
                paginationParams.PageNumber,
                paginationParams.pageSize,
                paginationParams.OrderBy,
                paginationParams.OrderAsc);
        }

        public async Task<Product> UpdateProduct(UpdateProductCommand productData)
        {
            var product = await _data.Products.FirstOrDefaultAsync(p => p.ProductId.Equals(productData.ProductId));
            product.ProductId = productData.ProductId;
            product.Name = productData.Name;
            product.Remarks = productData.Remarks;

            _data.Products.Update(product);
            await _data.SaveChangesAsync();
            return product;
        }
    }
}
