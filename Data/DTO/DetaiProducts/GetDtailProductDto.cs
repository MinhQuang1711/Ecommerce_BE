using Ecommerce_BE.Data.Domains;

namespace Ecommerce_BE.Data.DTO.DetaiProducts
{
    public class GetDetailProductDto: BaseModel
    {
        public string ProductName { get; set; }
        public string IngredientName { get; set; }
        public string IngredientId { get; set; }
        public double Weight { get; set; }

        public GetDetailProductDto() { }
    }
}
