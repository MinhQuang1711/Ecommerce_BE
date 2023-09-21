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
        public async Task<string?> Create(DetailProductDto detailProductDto, string productId, string productName)
        {
            
            var _ingredient= await _repoManager.ingredientRepo.FindIngredientById(detailProductDto.IngredientID);
            if (_ingredient != null)
            {
                var _name= _ingredient.Name;
                var _cost = GetTotalCost(_ingredient ??new Ingerdient(), detailProductDto.Weight) ;
                var _detailProduct = new DetailProduct()
                {
                    SumCost= _cost,
                    ProductID = productId,
                    ProductName = productName,
                    Id = Guid.NewGuid().ToString(),
                    Weight =detailProductDto.Weight,
                    IngredientID = detailProductDto.IngredientID,
                    IngredientName = _name??"lỗi lưu tên",
                };
               await _repoManager.detailProductRepo.Create(_detailProduct);
               return null;
            }
            return BusinessMessage.NotFoundIngredient; 
            
        }

        public async Task DeleteByProductId(string productId)
        {
            await _repoManager.detailProductRepo.DeleteByProductId(productId);
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
                    IngredientName= item.IngredientName,
                    Weight = item.Weight,
                    IngredientId = item.IngredientID,
                    ProductName = item.ProductName,

                };

                _detailProductDtoList.Add(_detailProductDto);
            }

            return _detailProductDtoList;
        }

        public double GetTotalCost(Ingerdient ingredient,double Weight)
        {
           return ingredient.PricePerGram * Weight;
          
        }
    }
}
