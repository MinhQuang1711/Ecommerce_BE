using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.DTO.DetaiProducts;

namespace Ecommerce_BE.Services.DetailProductServices
{
    public interface IDetailProductService
    {
        public Task<string?> Create(DetailProductDto detailProduct, string productId,string productName);
        public double GetTotalCost(Ingerdient ingredient,double Weight); 
        public Task<List<GetDetailProductDto>> GetByProductId(string productId);
        public Task DeleteByProductId(string productId);

    }
}
