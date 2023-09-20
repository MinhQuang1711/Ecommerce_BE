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
                    id = Guid.NewGuid().ToString(),
                    Weight =detailProductDto.Weight,
                    IngredientID = detailProductDto.IngredientID,
                };
               await _repoManager.detailProductRepo.Create(_detailProduct);
               return null;
            }
            return BusinessMessage.NotFoundIngredient; 
            
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
