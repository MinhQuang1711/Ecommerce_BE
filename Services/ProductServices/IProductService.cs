﻿using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.DTO.DetaiProducts;
using Ecommerce_BE.Data.DTO.Products;

namespace Ecommerce_BE.Services.ProductServices
{
    public interface IProductService
    {
        public Task<string?> Delete(string id);

        public Task<List<GetProductDto>> GetAll();

        public Task<List<GetProductDto>> SearchByName(string name);

        public Task<string?> CreateProduct(CreateProductDto model,string id);

        public Task<double?> GetTotalCost(List<DetailProductDto> detailProductDtoList);

        


    }
}
