using Ecommerce_BE.Repositories.SaleOfBills;

namespace Ecommerce_BE.Data.Domains.Repositories.DetailbillOfSales
{
    public class DetailBillOfSaleRepo : IDetailBillOfSaleRepo
    {
        private readonly EcommerceContext _context;

        public DetailBillOfSaleRepo(EcommerceContext context) {
            _context=context;
        }
        public async Task Create(DetailBillOfSale model)
        {
           await _context.detailBillOfSales.AddAsync(model);
           await _context.SaveChangesAsync();
        }

    }
}
