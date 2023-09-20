using Ecommerce_BE.Services.DetailProductServices;
using Ecommerce_BE.Services.IngredientServices;
using Ecommerce_BE.Services.ProductServices;

namespace Ecommerce_BE.Services.ManagerServices
{
    public interface IManagerService
    {
       public IIngredientService ingredientService { get; }
       public IProductService productService { get; }   
       public IDetailProductService detailProductService { get; }
    }
}
