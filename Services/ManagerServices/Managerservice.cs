using Ecommerce_BE.Data.Domains.Repositories;
using Ecommerce_BE.Services.IngredientServices;

namespace Ecommerce_BE.Services.ManagerServices
{
    public class ManagerService : IManagerService
    {
        private readonly Lazy<IIngredientService> _lazyIngredientService;

        public ManagerService(IRepositoryManager repositoryManager) { 
            _lazyIngredientService= new Lazy<IIngredientService>(()=>new IngredientService(repositoryManager));
        }


        public IIngredientService ingredientService => _lazyIngredientService.Value;
    }
}
