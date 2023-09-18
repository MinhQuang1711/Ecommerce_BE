using Ecommerce_BE.Services.IngredientServices;

namespace Ecommerce_BE.Services.ManagerServices
{
    public interface IManagerService
    {
       public IIngredientService ingredientService { get; }
    }
}
