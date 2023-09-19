using Ecommerce_BE.Repositories.ImportBills;
using Ecommerce_BE.Repositories.Ingerdients;
using Ecommerce_BE.Repositories.Products;
using Ecommerce_BE.Repositories.SaleOfBills;

namespace Ecommerce_BE.Data.Domains.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IIngredientRepo> _lazyIngredientRepository;
        private readonly Lazy<IProductRepository> _lazyProductRepository;

        public RepositoryManager(EcommerceContext context) {
            _lazyIngredientRepository = new Lazy<IIngredientRepo>(() => new IngredientRepo(context)) ;
            _lazyProductRepository= new Lazy<IProductRepository>(() => new ProductRepository(context)) ;
        }

        public IProductRepository productRepo => _lazyProductRepository.Value;

        public IImportBillRepo importBillRepo => throw new NotImplementedException();

        public IBillOfSaleRepo billOfSaleRepo => throw new NotImplementedException();

        public IIngredientRepo ingredientRepo => _lazyIngredientRepository.Value;
    }
}
