namespace Ecommerce_BE.Data.Domains
{
    public class ImportBill: BaseModel
    {
    
        public string ImportDate { get; set; }  
        public double TotalPrice { get; set; }  
        public int PaymentType { get; set; }

        public ImportBill() { } 
    }
}
