using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.DTO.Ingredients;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_BE.Repositories.Ingerdients
{
    public interface IIngredientRepo
    {
        
        public Task<bool> DeleteIngredient(string id);

        public Task CreateIngredient(Ingerdient model);

        public Task<List<Ingerdient>> GetAllIngredient();

        public Task<Ingerdient?> FindIngredientById(string id);

        public Task<string?> UpdateIngredient(UpdateIngredient model, string id); 

    }
}
