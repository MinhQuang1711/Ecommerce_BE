namespace Ecommerce_BE.Data.DTO.DetailBillOfSales
{
    public class GetDetailBillOfSaleDto
    {
        public string ProductId { get; set; }   
        public string ProductName { get; set; }
        public double TotalPrice { get; set; }   
        public int Quantity { get; set; }   
    }
}
