using Ecommerce_BE.Data.Domains;

namespace Ecommerce_BE.Repositories.Ingerdients
{
    public interface IIngredientRepo
    {
        public Task<List<Ingerdient>> GetAllIngredient();
        public Task CreateIngredient(Ingerdient model);
        public Task UpdateIngredient(Ingerdient model); 
        public Task DeleteIngredient(string id);
        

    }
}
