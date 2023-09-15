using Ecommerce_BE.Data.Domains;

namespace Ecommerce_BE.Repositories.SaleOfBills
{
    public interface IBillOfSaleRepo
    {
        public Task CreateBillOfSale(BillOfSale billOfSale);
        public Task UpdateBillOfSale(BillOfSale billOfSale);
        public Task<List<BillOfSale>> GetAllBillOfSale();
        public Task DeleteBillOfSale(string id);
    }
}
