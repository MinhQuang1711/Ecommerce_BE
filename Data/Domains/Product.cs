namespace Ecommerce_BE.Data.Domains
{
    public class Product: BaseModel
    {
        public string Name { get; set; }
        public double Price { get; set; }   
        public double Cost { get; set; }
        public List<Ingerdient> Ingerdients { get; set; }   

        Product() {  }

    }
}
