using Ecommerce_BE.Data.Domains.Repositories;
using Ecommerce_BE.Services.IngredientServices;
using Ecommerce_BE.Services.ProductServices;

namespace Ecommerce_BE.Services.ManagerServices
{
    public class ManagerService : IManagerService
    {
        private readonly Lazy<IIngredientService> _lazyIngredientService;
        private readonly Lazy<IProductService> _lazyProductService;

        public ManagerService(IRepositoryManager repositoryManager) { 
            _lazyIngredientService= new Lazy<IIngredientService>(()=>new IngredientService(repositoryManager));
            _lazyProductService = new Lazy<IProductService>(() => new ProductService(repositoryManager));
        }

        public IIngredientService ingredientService => _lazyIngredientService.Value;

        public IProductService productService => _lazyProductService.Value;
    }
}
