using Ecommerce_BE.Data.Domains;

namespace Ecommerce_BE.Repositories.SaleOfBills
{
    public interface IBillOfSaleRepo
    {
        public Task<List<BillOfSale>> GetAll();
        public Task CreateBillOfSale(BillOfSale billOfSale);
    }
}
