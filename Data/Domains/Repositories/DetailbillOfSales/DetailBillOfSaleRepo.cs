using Ecommerce_BE.Repositories.SaleOfBills;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<DetailBillOfSale>> SearchByBillId(string billId)
        {
            var _detailBillOfSaleList= await _context.detailBillOfSales.Where(d=> d.BillId==billId).ToListAsync();
            return _detailBillOfSaleList;   
        }
    }
}
