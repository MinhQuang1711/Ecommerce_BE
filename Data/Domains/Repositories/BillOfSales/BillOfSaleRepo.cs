using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Messages;
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

        public async Task CreateBillOfSale(BillOfSale billOfSale)
        {
            await _context.billOfSales.AddAsync(billOfSale);
            await _context.SaveChangesAsync();  
        }

        public async Task<string?> Delete(string id)
        {
           var _result= await _context.billOfSales.SingleOrDefaultAsync(b=> b.Id==id);
            if (_result != null)
            {
                _context.billOfSales.Remove(_result); 
                await _context.SaveChangesAsync();
                return null;
            }
            return BusinessMessage.BillOfSaleNotExist;
        }

        public async Task<List<BillOfSale>> GetAll()
        {
            return await _context.billOfSales.ToListAsync();
        }

        public async Task<List<BillOfSale>> SearchByDate(DateTime fromTime, DateTime endTime)
        {
            var _billOfSaleList = await _context.billOfSales.Where(b=> fromTime<=b.SaleDate && b.SaleDate<= endTime).ToListAsync();

            return _billOfSaleList;
        }
    }
}
