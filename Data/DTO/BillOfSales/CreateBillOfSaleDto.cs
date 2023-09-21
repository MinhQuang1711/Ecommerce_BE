using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.DTO.DetailBillOfSales;

namespace Ecommerce_BE.Data.DTO.BillOfSales
{
    public class CreateBillOfSaleDto 
    {
        public List<CreateDetailBillOfSaleDto> DetailBillOfSales { get; set; } 
        public double? Discount { get; set; }
        public int PaymentType { get; set; }    

        public CreateBillOfSaleDto() { }
    }
}
