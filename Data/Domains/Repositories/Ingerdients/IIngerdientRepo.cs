using Ecommerce_BE.Data.Domains;

namespace Ecommerce_BE.Repositories.Ingerdients
{
    public interface IIngredientRepo
    {
        public Task<bool> DeleteIngredient(string id);
        public Task CreateIngredient(Ingerdient model);
        public Task<List<Ingerdient>> GetAllIngredient();
        public Task<bool> UpdateIngredient(Ingerdient model); 
        public Task<Ingerdient?> FindIngredientById(string id);
        

    }
}
