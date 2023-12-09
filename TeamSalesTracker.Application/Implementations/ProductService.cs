using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TeamSalesTracker.Application.Interfaces;
using TeamSalesTracker.Domain;
using TeamSalesTracker.Domain.Interfaces;

namespace TeamSalesTracker.Application.Implementations
{
    public class ProductService : IBaseService<Product, long>
    {
        private readonly IBaseRepository<Product, long> _productRepository;
        public ProductService(IBaseRepository<Product, long> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Add(Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException("El producto es requerido");
            var product = await _productRepository.Add(entity);
            await _productRepository.Save();
            return product;
        }

        public async Task<Product> Delete(long entityId)
        {
            var deletedProduct = await _productRepository.Delete(entityId);
            await _productRepository.Save();
            return deletedProduct;
        }

        public async Task<Product> Edit(Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException("El producto es requerido");
            var updatedProduct = await _productRepository.Edit(entity);
            await _productRepository.Save();
            return updatedProduct;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetById(long entityId)
        {
            return await _productRepository.GetById(entityId);
        }
    }
}
