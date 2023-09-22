namespace Ecommerce_BE.Data.Domains.Repositories.DetailbillOfSales
{
    public interface IDetailBillOfSaleRepo
    {
        public Task Create(DetailBillOfSale model);
        public Task<List<DetailBillOfSale>> SearchByBillId(string billId);
        public Task DeleteByBillId(string billId);
    }
}
