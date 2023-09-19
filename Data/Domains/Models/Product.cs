namespace Ecommerce_BE.Data.Domains
{
    public class Product: BaseModel
    {
        public string Name { get; set; }
        public double Price { get; set; }   
        public double Cost { get; set; }
        public double SalePrice { get; set; }   
        public double PercentProfit { get; set; }   

        public Product() {  }

    }
}
