namespace Ecommerce_BE.Data.Domains
{
    public class Ingerdient: BaseModel
    {
        public string Name { get; set; }
        public string Loss { get; set; }
        public string RealWeight { get; set; }
        public double NetWeight { get; set; }
        public double ImportPrice { get; set; }
        public double PricePerGram { get; set; }
    

        public Ingerdient() { }
    }
}
