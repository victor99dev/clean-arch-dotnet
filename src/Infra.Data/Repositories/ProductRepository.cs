using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        ApplicationDbContext _productContext;
        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(string? id)
        {
            return await _productContext.products.FindAsync(id);
        }

        public async Task<Product> GetProductCategoryAsync(string? id)
        {

            Guid productId = Guid.TryParse(id, out Guid parsedId) ? parsedId : Guid.Empty;

            return await _productContext.products
            .Include(c => c.Category)
            .SingleOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productContext.products.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}