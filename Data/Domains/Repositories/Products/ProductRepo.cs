using Ecommerce_BE.Data.Domains;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_BE.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceContext _context;

        public ProductRepository(EcommerceContext context) {
            _context = context;
        }

        public async Task CreateProduct(Product product)
        {
            await _context.products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(string id)
        {
            var _productResult= await _context.products.SingleAsync(p=> p.Id ==id);
            _context.products.Remove(_productResult);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _context.products.ToListAsync();
        }

        public async Task UpdateProduct(Product model,string id)
        {
            var _productResult = await _context.products.SingleAsync(p => p.Id == id);
            _productResult = model;
             _context.products.Update(_productResult);
            await _context.SaveChangesAsync();

            
        }

        public async Task<Product?> SearchById(string id)
        {
            return await _context.products.SingleOrDefaultAsync(p=> p.Id ==id);
        }

        public async Task<List<Product>> SearchByName(string name)
        {
            var result = _context.products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            return await result.ToListAsync(); 
        }
    }
}
