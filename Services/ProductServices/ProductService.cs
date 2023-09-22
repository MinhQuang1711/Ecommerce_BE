﻿using AutoMapper;
using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.Domains.Repositories;
using Ecommerce_BE.Data.DTO.DetaiProducts;
using Ecommerce_BE.Data.DTO.Products;
using Ecommerce_BE.Messages;

namespace Ecommerce_BE.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager repositoryManager,IMapper mapper) {
            _repositoryManager= repositoryManager;
            _mapper = mapper;
        }

        public async Task<string?> CreateProduct(CreateProductDto model, string id)
        {
            var _cost = await GetTotalCost(model.DetailProductsList);
            if (_cost != null)
            {
                var _productModel = new Product()
                {
                    Id = id,
                    Name = model.Name,
                    Price = model.Price,
                    SalePrice = 0,
                    Cost = _cost??0,
                    PercentProfit = (_cost??0 / model.Price) * 100

                };
                await _repositoryManager.productRepo.CreateProduct(_productModel);
                return null;

            }
            return BusinessMessage.IngredientNotExist;
           
        }

        public async Task<string?> Delete(string id)
        {
           var _result=await _repositoryManager.productRepo.SearchById(id);
            if (_result!=null)
            {
                await _repositoryManager.productRepo.DeleteProduct(id);
                return null;
            }
            return BusinessMessage.NotFoundProduct;
        }

        public async Task<List<GetProductDto>> GetAll()
        {
            var _productList = await _repositoryManager.productRepo.GetAllProduct();

            return _mapper.Map<List<GetProductDto>>(_productList);
        }

        public async Task<double?> GetTotalCost(List<DetailProductDto> detailProductDtoList)
        {
            double _totalCost = 0;
            foreach (var product in detailProductDtoList)
            {
                var _ingredient=await _repositoryManager.ingredientRepo.FindIngredientById(product.IngredientID);
                if(_ingredient!=null)
                {
                    double _costOfIngredient = product.Weight * _ingredient.PricePerGram;
                    _totalCost = _totalCost + _costOfIngredient;
                }
                else
                {
                    return null;
                } 

                 
            }
            return _totalCost;
        }

        public async Task<List<GetProductDto>> SearchByName(string name)
        {
            var _productList =await  _repositoryManager.productRepo.SearchByName(name);
            return _mapper.Map<List<GetProductDto>>(_productList);
        }
    }
}
