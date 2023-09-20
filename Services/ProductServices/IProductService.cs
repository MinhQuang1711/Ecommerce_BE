using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.DTO.DetaiProducts;
using Ecommerce_BE.Data.DTO.Products;

namespace Ecommerce_BE.Services.ProductServices
{
    public interface IProductService
    {
        public Task<List<ProductDto>> GetAll();

        public Task<string?> CreateProduct(CreateProductDto model,string id);

        public Task<double?> GetTotalCost(List<DetailProductDto> detailProductDtoList);


    }
}
