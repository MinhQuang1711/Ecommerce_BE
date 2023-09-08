namespace Ecommerce_BE.Data.Domains
{
    public class Ingerdient: BaseModel
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double ImportPrice { get; set; }
        public double pricePerGram { get; set; }

        public Ingerdient() { }
    }
}
