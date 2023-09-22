using Ecommerce_BE.Data.Domains;

namespace Ecommerce_BE.Repositories.SaleOfBills
{
    public interface IBillOfSaleRepo
    {
        public Task<string?> Delete(string id);
        public Task<List<BillOfSale>> GetAll();
        public Task CreateBillOfSale(BillOfSale billOfSale);
        public Task<List<BillOfSale>> SearchByDate(DateTime fromTime, DateTime endTime);
    }
}
