using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.DTO.BillOfSales;

namespace Ecommerce_BE.Repositories.SaleOfBills
{
    public interface IBillOfSaleRepo
    {
        public Task<BillOfSale?> SearchById(string id);
        public Task<string?> Delete(string id);
        public Task<List<BillOfSale>> GetAll();
        public Task CreateBillOfSale(BillOfSale billOfSale);
        public Task<List<BillOfSale>> Search(SearchBillOfSaleByDateDto searchBillOfSaleByDateDto);
    }
}
