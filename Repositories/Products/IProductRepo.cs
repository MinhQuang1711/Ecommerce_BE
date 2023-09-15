using Ecommerce_BE.Data.Domains;

namespace Ecommerce_BE.Repositories.Products
{
    public interface IProductRepo
    {
        public Task<List<Product>> GetAllProduct(); 
        public Task CreateProduct(Product product);
        public Task UpdateProduct(Product product);
        public Task DeleteProduct(String id);
    }
}
