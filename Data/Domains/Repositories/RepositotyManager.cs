using Ecommerce_BE.Repositories.ImportBills;
using Ecommerce_BE.Repositories.Ingerdients;
using Ecommerce_BE.Repositories.Products;
using Ecommerce_BE.Repositories.SaleOfBills;

namespace Ecommerce_BE.Data.Domains.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IIngredientRepo> _lazyIngredientRepository;

        public RepositoryManager(EcommerceContext context) {
            _lazyIngredientRepository = new Lazy<IIngredientRepo>(() => new IngredientRepo(context)) ;
        }

        public IProductRepo productRepo => throw new NotImplementedException();

        public IImportBillRepo importBillRepo => throw new NotImplementedException();

        public IBillOfSaleRepo billOfSaleRepo => throw new NotImplementedException();

        public IIngredientRepo ingredientRepo => _lazyIngredientRepository.Value;
    }
}
