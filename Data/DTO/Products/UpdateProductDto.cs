using Ecommerce_BE.Data.DTO.DetaiProducts;

namespace Ecommerce_BE.Data.DTO.Products
{
    public class UpdateProductDto
    {
        public string? Name { get; set; }
        public double? Price { get; set; }
        public List<DetailProductDto>? DetailProductsList { get; set; }

        public UpdateProductDto() { }
    }
}
