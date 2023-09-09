namespace Ecommerce_BE.Data.Domains
{
    public class Ingerdient: BaseModel
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double ImportPrice { get; set; }
        public double PricePerGram { get; set; }
        public List<IngerProduct> IngerProducts { get; set; }    

        public Ingerdient() { }
    }
}
