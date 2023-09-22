using AutoMapper;
using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.DTO.BillOfSales;
using Ecommerce_BE.Data.DTO.DetailBillOfSales;
using Ecommerce_BE.Data.DTO.Products;

namespace Ecommerce_BE.Helpers.Mappers
{
    public class BusinessMapper: Profile
    {
        public BusinessMapper() {
            CreateMap<Product,GetProductDto>().ReverseMap();
            CreateMap<DetailBillOfSale, GetDetailBillOfSaleDto>().ReverseMap();
            CreateMap<GetBillOfSaleDto,BillOfSale>().ReverseMap();

        }
    }
}
