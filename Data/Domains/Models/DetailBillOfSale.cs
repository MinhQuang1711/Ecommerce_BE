namespace Ecommerce_BE.Data.Domains
{
    public class DetailBillOfSale: BaseModel
    {
        public string BillId { get; set; }
        public int Quantity { get; set; }
        public string ProductId { get; set; }     
        public double TotalPrice { get; set; }

        public DetailBillOfSale() { }
    }
}
