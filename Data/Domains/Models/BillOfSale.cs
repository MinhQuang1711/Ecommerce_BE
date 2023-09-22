namespace Ecommerce_BE.Data.Domains
{
    public class BillOfSale : BaseModel
    {
        public DateTime SaleDate { get; set; }
        public double Discount { get; set; }
        public double FinalPrice { get; set; }
        public double TotalPrice { get; set; }
        public int PaymentType { get; set; }

       public BillOfSale() { }
    }
}
