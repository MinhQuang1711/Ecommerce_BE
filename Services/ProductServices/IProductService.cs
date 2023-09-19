using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.DTO.Products;

namespace Ecommerce_BE.Services.ProductServices
{
    public interface IProductService
    {

        public Task<string>? DeleteProduct(string productId);

        public Task<ProductDto> SearchById(string productId);

        public List<ProductDto> SearchByName(string productName);

        public Task<string>? UpdateProduct(UpdateProductDto model);

        public Task<List<ProductDto>> GetAll(List<Product> productList);
    }
}
