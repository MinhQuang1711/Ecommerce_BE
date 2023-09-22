using Ecommerce_BE.Data.Domains;

namespace Ecommerce_BE.Repositories.Products
{
    public interface IProductRepository
    {
        public Task<Product?> SearchById(string id); 

        public Task DeleteProduct(String id);

        public Task<List<Product>> GetAllProduct(); 

        public Task CreateProduct(Product product); 

        public Task<List<Product>> SearchByName(string name);

        public Task UpdateProduct(Product product,string id);
       

    }
}
