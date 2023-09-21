using AutoMapper;
using Ecommerce_BE.Data.Domains.Repositories;
using Ecommerce_BE.Services.BillOfSaleServices;
using Ecommerce_BE.Services.DetailBillOfSaleServices;
using Ecommerce_BE.Services.DetailProductServices;
using Ecommerce_BE.Services.IngredientServices;
using Ecommerce_BE.Services.ProductServices;

namespace Ecommerce_BE.Services.ManagerServices
{
    public class ManagerService : IManagerService
    {
        private readonly Lazy<IBillOfSaleService> _lazyBillOfSaleService;
        private readonly Lazy<IIngredientService> _lazyIngredientService;
        private readonly Lazy<IProductService> _lazyProductService;
        private readonly Lazy<IDetailProductService> _lazyDetailProductService;
        private readonly Lazy<IDetailBillOfSaleService> _lazyDetailBillOfSaleService;

        public ManagerService(IRepositoryManager repositoryManager,IMapper mapper) {
            _lazyBillOfSaleService = new Lazy<IBillOfSaleService>(() => new BillOfSaleService(repositoryManager));
            _lazyIngredientService = new Lazy<IIngredientService>(()=>new IngredientService(repositoryManager));
            _lazyProductService = new Lazy<IProductService>(() => new ProductService(repositoryManager,mapper));
            _lazyDetailProductService = new Lazy<IDetailProductService>(() => new DetailProductService(repositoryManager));
            _lazyDetailBillOfSaleService = new Lazy<IDetailBillOfSaleService>(() => new DetailBillOfSaleService(repositoryManager));
        }

        public IIngredientService ingredientService => _lazyIngredientService.Value;

        public IProductService productService => _lazyProductService.Value;

        public IDetailProductService detailProductService => _lazyDetailProductService.Value;

        public IBillOfSaleService BillOfSaleService => _lazyBillOfSaleService.Value;

        public IDetailBillOfSaleService detailBillOfSaleService => _lazyDetailBillOfSaleService.Value;
    }
}
