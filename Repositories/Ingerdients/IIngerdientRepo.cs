using Ecommerce_BE.Data.Domains;

namespace Ecommerce_BE.Repositories.Ingerdients
{
    public interface IIngerdientRepo
    {
        public Task<List<Ingerdient>> GetAllIngerdient();
        public Task CreateIngerdient(Ingerdient model);
        public Task UpdateIngerdient(Ingerdient model); 
        public Task DeleteIngerdient(string id);
        

    }
}
