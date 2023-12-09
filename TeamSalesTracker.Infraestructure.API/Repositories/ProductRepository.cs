using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSalesTracker.Domain;
using TeamSalesTracker.Domain.Interfaces;
using TeamSalesTracker.Infraestructure.Data.Contexts;

namespace TeamSalesTracker.Infraestructure.Data.Repositories
{
    public class ProductRepository : IBaseRepository<Product, long>
    {
        private readonly TeamSaleTrackerData _data;
        public ProductRepository(TeamSaleTrackerData data)
        {
            _data = data;
        }

        public async Task<Product> Add(Product entity)
        {
            await _data.Products.AddAsync(entity);
            return entity;
        }

        public async Task<Product> Delete(long entityId)
        {
            var product = await _data.Products.FirstOrDefaultAsync(p => p.ProductId.Equals(entityId));
            if (product != null) { 
                _data.Products.Remove(product);
            }
            return product;
        }

        public async Task<Product> Edit(Product entity)
        {
            var product = await _data.Products.FirstOrDefaultAsync(p => p.ProductId.Equals(entity.ProductId));
            if (product != null) { 
                product.Name = entity.Name;
                product.Remarks = entity.Remarks;
                _data.Entry(product).State = EntityState.Modified;
                _data.Products.Update(product);
            }
            return product;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _data.Products.ToListAsync();
            return products;
        }

        public async Task<Product> GetById(long entityId)
        {
            var product = await _data.Products.FirstOrDefaultAsync(p => p.ProductId.Equals(entityId));
            return product;
        }

        public async Task Save()
        {
            await _data.SaveChangesAsync();
        }
    }
}
