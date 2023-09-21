using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.DTO.DetailBillOfSales;

namespace Ecommerce_BE.Services.DetailBillOfSaleServices
{
    public interface IDetailBillOfSaleService
    {
        public Task<string?> Create(CreateDetailBillOfSaleDto createDetailBillOfSaleDto,string billId);
        public double GetTotal(double quantity, double price);
    }
}
