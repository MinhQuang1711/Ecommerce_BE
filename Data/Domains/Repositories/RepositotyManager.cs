using Ecommerce_BE.Data.Domains.Repositories.DetailProductRepo;
using Ecommerce_BE.Repositories.BillOfSales;
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
        private readonly Lazy<IBillOfSaleRepo> _lazyBillOfSaleRepository;
        private readonly Lazy<IDetailProductRepo> _lazyDetailProductRepository;

        public RepositoryManager(EcommerceContext context) {
            _lazyIngredientRepository = new Lazy<IIngredientRepo>(() => new IngredientRepo(context)) ;
            _lazyProductRepository= new Lazy<IProductRepository>(() => new ProductRepository(context)) ;
            _lazyBillOfSaleRepository = new Lazy<IBillOfSaleRepo>(() => new BillOfSaleRepo(context));
            _lazyDetailProductRepository = new Lazy<IDetailProductRepo>(() => new DetailProductRepo.DetailProductRepo(context));
        }

        public IProductRepository productRepo => _lazyProductRepository.Value;

        public IImportBillRepo importBillRepo => throw new NotImplementedException();

        public IBillOfSaleRepo billOfSaleRepo => _lazyBillOfSaleRepository.Value;

        public IIngredientRepo ingredientRepo => _lazyIngredientRepository.Value;

        public IDetailProductRepo detailProductRepo => _lazyDetailProductRepository.Value;
    }
}
