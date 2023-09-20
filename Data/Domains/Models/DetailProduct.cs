namespace Ecommerce_BE.Data.Domains
{
    public class DetailProduct: BaseModel
    {

        public double Weight { get; set; }
        public double SumCost { get; set; }
        public string ProductID { get; set; }
        public string IngredientID { get; set; }

        public DetailProduct() { }

    }
}
