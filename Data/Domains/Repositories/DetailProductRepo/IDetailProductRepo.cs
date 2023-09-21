using Ecommerce_BE.Data.DTO.DetaiProducts;

namespace Ecommerce_BE.Data.Domains.Repositories.DetailProductRepo
{
    public interface IDetailProductRepo
    {
        public Task Create(DetailProduct model);
        public Task DeleteByProductId(string productId);
        public Task<List<DetailProduct>> GetByProductId(string productId);
        
    }
}
