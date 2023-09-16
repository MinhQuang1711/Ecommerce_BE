namespace Ecommerce_BE.Data.Domains
{
    public class DetailImportBill: BaseModel
    {
        public string IngerdientId { get; set; }    
        public string ImportBillId { get; set; }    
        public double Quantity { get; set; }    
        public double TotalPrice { get; set; }

        public DetailImportBill() { }   
    }
}
