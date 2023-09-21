using Ecommerce_BE.Data.Domains;

namespace Ecommerce_BE.Services.BillOfSaleServices
{
    public interface IBillOfSaleService
    {
        public Task<List<BillOfSale>> GetAll();
    }
}
