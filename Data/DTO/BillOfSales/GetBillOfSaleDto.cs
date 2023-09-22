using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.DTO.DetailBillOfSales;

namespace Ecommerce_BE.Data.DTO.BillOfSales
{
    public class GetBillOfSaleDto:BillOfSale
    {
        public List<GetDetailBillOfSaleDto> DetailBillOfSales { get; set; } 
    }
}
