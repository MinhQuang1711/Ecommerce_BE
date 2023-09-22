namespace Ecommerce_BE.Data.DTO.BillOfSales
{
    public class SearchBillOfSaleByDateDto
    {
        public int? PaymentType { get; set; }    
        public DateTime? startTime { get; set; }
        public DateTime? endTime { get; set; }
    }
}
