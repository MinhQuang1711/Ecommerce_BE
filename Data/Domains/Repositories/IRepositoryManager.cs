using Ecommerce_BE.Data.Domains.Repositories.DetailProductRepo;
using Ecommerce_BE.Repositories.ImportBills;
using Ecommerce_BE.Repositories.Ingerdients;
using Ecommerce_BE.Repositories.Products;
using Ecommerce_BE.Repositories.SaleOfBills;

namespace Ecommerce_BE.Data.Domains.Repositories
{
    public interface IRepositoryManager
    {
       
        public IProductRepository productRepo { get; }
        public IImportBillRepo importBillRepo { get; }
        public IBillOfSaleRepo billOfSaleRepo { get; }
        public IIngredientRepo ingredientRepo { get; }
        public IDetailProductRepo detailProductRepo { get; }
    }
}
