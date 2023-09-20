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

        public ProductService(IRepositoryManager repositoryManager) {
            _repositoryManager= repositoryManager;
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

        public async Task<List<GetProductDto>> GetAll()
        {
            var _productList = await _repositoryManager.productRepo.GetAllProduct();
            var _productDtoList= new List<GetProductDto>();

            foreach (var _product in _productList)
            {
                var _productDto = new GetProductDto() 
                {
                    Id = _product.Id,
                    Name = _product.Name,
                    Price = _product.Price,
                    DetailProducts= new List<GetDetailProductDto>(),

                };
                _productDtoList.Add(_productDto);
            }

            return _productDtoList;
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
    }
}
