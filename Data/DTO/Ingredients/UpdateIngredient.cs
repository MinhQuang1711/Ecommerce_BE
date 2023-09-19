namespace Ecommerce_BE.Data.DTO.Ingredients
{
    public class UpdateIngredient
    {
        public string? Name { get; set; }
        public double? Loss { get; set; }
        public double? NetWeight { get; set; }
        public double? ImportPrice { get; set; }
        public UpdateIngredient() { }
    }
}
