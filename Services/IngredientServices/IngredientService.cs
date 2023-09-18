using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.Domains.Repositories;
using Ecommerce_BE.Data.DTO.Ingredients;
using Ecommerce_BE.Messages;

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
            var ingredient = new Ingerdient()
            {
                id = Guid.NewGuid().ToString(),
                Name = model.Name,
                ImportPrice = model.ImportPrice,
                NetWeight = model.NetWeight,
                Loss = model.Loss??0,
                RealWeight = model.NetWeight - model.Loss==null?0: model.NetWeight * (model.Loss??0 / 100),
                PricePerGram = model.ImportPrice / model.NetWeight - model.NetWeight * (model.Loss ?? 0 / 100),
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

        public async Task<bool> Update(Ingerdient model)
        {
            return await _repositoryManager.ingredientRepo.UpdateIngredient(model);
        }
    }
}
