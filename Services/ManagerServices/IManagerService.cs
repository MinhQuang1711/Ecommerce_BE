using Ecommerce_BE.Services.BillOfSaleServices;
using Ecommerce_BE.Services.DetailBillOfSaleServices;
using Ecommerce_BE.Services.DetailProductServices;
using Ecommerce_BE.Services.IngredientServices;
using Ecommerce_BE.Services.ProductServices;

namespace Ecommerce_BE.Services.ManagerServices
{
    public interface IManagerService
    {
       public IBillOfSaleService BillOfSaleService { get; }
       public IIngredientService ingredientService { get; }
       public IProductService productService { get; }   
       public IDetailProductService detailProductService { get; }
        public IDetailBillOfSaleService detailBillOfSaleService { get; }
    }
}
