using AutoMapper;
using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.DTO.Products;

namespace Ecommerce_BE.Helpers.Mappers
{
    public class BusinessMapper: Profile
    {
        public BusinessMapper() {
            CreateMap<Product,GetProductDto>().ReverseMap();
         

        }
    }
}
