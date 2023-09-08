namespace Ecommerce_BE.Data.Domains
{
    public class DetailProduct: BaseModel
    {

        public double weight { get; set; }
        public double sumCost { get; set; }
        public string productID { get; set; }
        public string ingerdientID { get; set; }

        DetailProduct() { }

    }
}
