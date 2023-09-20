using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.Domains.Repositories;
using Ecommerce_BE.Data.DTO.Ingredients;
using Ecommerce_BE.Messages;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_BE.Services.IngredientServices
{
    public class IngredientService : IIngredientService
    {
        private readonly IRepositoryManager _repositoryManager;

        public IngredientService(IRepositoryManager repositoryManager) 
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<string?> Create(CreateIngredient model)
        {
            if (model.ImportPrice == 0)
            {
                return BusinessMessage.IngredientPriceRequied;
            }
            else if (model.NetWeight == 0)
            {
                return BusinessMessage.IngredientWeightRequied;
            }
            var _realWeight = GetRealWeight(model.NetWeight, model.Loss);
            var ingredient = new Ingerdient()
            {

                Name = model.Name,
                Loss = model.Loss ?? 0,
                RealWeight = _realWeight,
                NetWeight = model.NetWeight,
                Id = Guid.NewGuid().ToString(),
                ImportPrice = model.ImportPrice,
                PricePerGram = GetPricePerGram(_realWeight, model.ImportPrice),
            };
            await _repositoryManager.ingredientRepo.CreateIngredient(ingredient);
            return null;
           
        }

        public Task<bool> Delete(string id)
        {
            return _repositoryManager.ingredientRepo.DeleteIngredient(id);
        }

        public async Task<List<Ingerdient>> GetAll()
        {
            return await _repositoryManager.ingredientRepo.GetAllIngredient();
        }

        public async Task<Ingerdient?> SearchById(string id)
        {
            return await _repositoryManager.ingredientRepo.FindIngredientById(id);
        }

        

        public async Task<string?> Update(UpdateIngredient model, string id)
        {
            var _ingredientResult = await _repositoryManager.ingredientRepo.FindIngredientById(id);
            if (_ingredientResult != null)
            {
                var _name = model.Name??_ingredientResult.Name;
                var _loss = model.Loss ?? _ingredientResult.Loss;
                var _netWeight = model.NetWeight ?? _ingredientResult.NetWeight;
                var _importPrice = model.ImportPrice ?? _ingredientResult.ImportPrice;

                _ingredientResult.Loss = _loss;
                _ingredientResult.Name = _name;

                if (_importPrice > 0)
                    _ingredientResult.ImportPrice = _importPrice;
                else
                    return BusinessMessage.IngredientPriceRequied;

                if (model.NetWeight > 0)
                    _ingredientResult.NetWeight = _netWeight;
                else
                    return BusinessMessage.IngredientWeightRequied;

                var _realWeight = GetRealWeight(_netWeight, _loss);
                _ingredientResult.RealWeight = _realWeight;
                _ingredientResult.PricePerGram= GetPricePerGram(_realWeight, _importPrice);

                return await _repositoryManager.ingredientRepo.UpdateIngredient(_ingredientResult, id);


            }


            return BusinessMessage.NotFoundIngredient;
        }

        public List<Ingerdient> SearchByName(string name)
        {
            return _repositoryManager.ingredientRepo.SearchByName(name);    
        }

        public double GetRealWeight(double netWeight, double? loss)
        {
           
            var _loss = loss  ??0;
            var _weightLoss= netWeight * (_loss / 100);
            var _realWeight = netWeight - _weightLoss;
            return _realWeight;
        }

        public double GetPricePerGram(double realWeight, double importPrice)
        {
            return importPrice / realWeight;
            
        }
    }
}
