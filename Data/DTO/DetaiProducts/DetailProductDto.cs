using Ecommerce_BE.Data.DTO.Ingredients;

namespace Ecommerce_BE.Data.DTO.DetaiProducts
{
    public class DetailProductDto
    {
        public string IngredientID { get; set; } 
        public double Weight { get; set; }

        public DetailProductDto() { }
    }
}
