namespace Ecommerce_BE.Data.Domains
{
    public class IngerProduct: BaseModel
    {

        public double Weight { get; set; }
        public double SumCost { get; set; }
        public string ProductID { get; set; }
        public string IngerdientID { get; set; }

        IngerProduct() { }

    }
}
