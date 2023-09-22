using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.DTO.DetailBillOfSales;

namespace Ecommerce_BE.Services.DetailBillOfSaleServices
{
    public interface IDetailBillOfSaleService
    {
        public Task<string?> Create(CreateDetailBillOfSaleDto createDetailBillOfSaleDto,string billId);
        public Task<List<GetDetailBillOfSaleDto>> SearchByBillId(string billId);
        public double GetTotal(double quantity, double price);
        public Task DeleteByBillId(string billId);
    }
}
