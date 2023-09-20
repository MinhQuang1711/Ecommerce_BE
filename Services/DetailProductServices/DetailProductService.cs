using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.Domains.Repositories;
using Ecommerce_BE.Data.DTO.DetaiProducts;
using Ecommerce_BE.Messages;

namespace Ecommerce_BE.Services.DetailProductServices
{
    public class DetailProductService : IDetailProductService
    {
        private readonly IRepositoryManager _repoManager;

        public DetailProductService(IRepositoryManager repositoryManager) { 
            _repoManager=repositoryManager;
        }
        public async Task<string?> Create(DetailProductDto detailProductDto, string productId)
        {
            var _cost = await GetTotalCost(detailProductDto);
            if (_cost != null)
            {
                var _detailProduct = new DetailProduct()
                {
                    SumCost=_cost??0,
                    ProductID = productId,
                    Id = Guid.NewGuid().ToString(),
                    Weight =detailProductDto.Weight,
                    IngredientID = detailProductDto.IngredientID,
                };
               await _repoManager.detailProductRepo.Create(_detailProduct);
               return null;
            }
            return BusinessMessage.NotFoundIngredient; 
            
        }

        public async Task<List<GetDetailProductDto>> GetByProductId(string productId)
        {
            var _detailProductList= await _repoManager.detailProductRepo.GetByProductId(productId);
            var _detailProductDtoList= new List<GetDetailProductDto>();
            foreach (var item in _detailProductList)
            {
                var _detailProductDto = new GetDetailProductDto() 
                {
                    Id = item.Id,
                    Weight = item.Weight,
                    IngredientId = item.IngredientID,
                    ProductName = item.ProductName,

                };

                _detailProductDtoList.Add(_detailProductDto);
            }

            return _detailProductDtoList;
        }

        public async Task<double?> GetTotalCost(DetailProductDto detailProduct)
        {
            var _ingredientResult=await _repoManager.ingredientRepo.FindIngredientById(detailProduct.IngredientID);
            if (_ingredientResult != null)
            {
                return _ingredientResult.PricePerGram * detailProduct.Weight;
            }
            return null;
        }
    }
}
