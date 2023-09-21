using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Repositories.SaleOfBills;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_BE.Repositories.BillOfSales
{
    public class BillOfSaleRepo : IBillOfSaleRepo
    {
        private readonly EcommerceContext _context;

        public BillOfSaleRepo(EcommerceContext context) 
        {
            _context=context;
        }

        public async Task<List<BillOfSale>> GetAll()
        {
            return await _context.billOfSales.ToListAsync();
        }
    }
}
