using System.ComponentModel.DataAnnotations;

namespace Ecommerce_BE.Data.DTO.DetailBillOfSales
{
    public class CreateDetailBillOfSaleDto
    {
        [Required(ErrorMessage = "Product id không được trống")]
        public string ProductId { get; set; }
        [Range(0,int.MaxValue)]
        public double Quantity { get; set; }
    }
}
