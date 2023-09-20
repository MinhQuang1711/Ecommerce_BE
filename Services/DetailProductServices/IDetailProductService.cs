using Ecommerce_BE.Data.DTO.DetaiProducts;

namespace Ecommerce_BE.Services.DetailProductServices
{
    public interface IDetailProductService
    {
        public Task<string?> Create(DetailProductDto detailProduct, string productId);
        public Task<double?> GetTotalCost(DetailProductDto detailProduct); 

    }
}
