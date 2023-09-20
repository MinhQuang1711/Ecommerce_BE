using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.DTO.DetaiProducts;

namespace Ecommerce_BE.Data.DTO.Products
{
    public class GetProductDto: BaseModel
    {
        public string Name { get; set; }    
        public double Price { get; set; }
        public List<GetDetailProductDto> DetailProducts { get; set; }

        public GetProductDto() { }
    }
}
