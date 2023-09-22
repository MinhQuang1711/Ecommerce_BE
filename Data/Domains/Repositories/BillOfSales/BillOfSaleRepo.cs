using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.DTO.BillOfSales;
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

        public async Task<List<BillOfSale>> Search(SearchBillOfSaleByDateDto model)
        {

            if(model.startTime.HasValue && model.endTime.HasValue)
            {
                if (!string.IsNullOrEmpty(model.PaymentType.ToString()))
                {
                    var _list = await _context.billOfSales.Where(b 
                        =>b.SaleDate >= model.startTime 
                        && b.SaleDate <= model.endTime 
                        && b.PaymentType == model.PaymentType
                        ).ToListAsync();
                    return _list;
                }
                else 
                {
                    var _list = await _context.billOfSales.Where(b
                   => b.SaleDate >= model.startTime
                   && b.SaleDate <= model.endTime
                   ).ToListAsync();
                    return _list;
                }

               
            }
            else if (!string.IsNullOrEmpty(model.PaymentType.ToString()))
            {
                var _list = await _context.billOfSales.Where(b
                      =>  b.PaymentType == model.PaymentType
                      ).ToListAsync();
                return _list;   
            }
            

            return await GetAll();
        }

        public async Task<BillOfSale?> SearchById(string id)
        {
            var _result = await _context.billOfSales.SingleOrDefaultAsync(e=>e.Id==id);
            return _result;
        }
    }
}
