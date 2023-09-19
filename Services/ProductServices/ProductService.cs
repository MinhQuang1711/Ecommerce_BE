using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.Domains.Repositories;
using Ecommerce_BE.Data.DTO.Products;

namespace Ecommerce_BE.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ProductService(IRepositoryManager repositoryManager) {
            _repositoryManager= repositoryManager;
        }


        public Task<string>? DeleteProduct(string productId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetAll(List<Product> productList)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> SearchById(string productId)
        {
            throw new NotImplementedException();
        }

        public List<ProductDto> SearchByName(string productName)
        {
            throw new NotImplementedException();
        }

        public Task<string>? UpdateProduct(UpdateProductDto model)
        {
            throw new NotImplementedException();
        }
    }
}
