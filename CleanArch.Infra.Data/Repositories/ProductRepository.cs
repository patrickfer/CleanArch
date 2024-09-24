using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _productContext;
        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productContext.Products.ToListAsync();
        }

        public async Task<Product> GetById(int? id)
        {
            var product = await _productContext.Products.FindAsync(id);

            return product;
        }

        public async Task<IEnumerable<Product>> GetProductCategoryAsync(int? id)
        {
            return await _productContext.Products.Where(p => p.CategoryId == id).ToListAsync();
        }
        public async Task<Product> Create(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Delete(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();

            return product;
        }
    }
}
