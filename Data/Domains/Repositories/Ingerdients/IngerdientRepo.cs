using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.DTO.Ingredients;
using Ecommerce_BE.Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ecommerce_BE.Repositories.Ingerdients
{
    public class IngredientRepo : IIngredientRepo
    {
        private readonly EcommerceContext _context;
    

        public IngredientRepo(EcommerceContext context) {
            _context = context;
        }

        public async Task CreateIngredient(Ingerdient model)
        {
            _context.ingredients.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteIngredient(string id)
        {
            var deleteIngredient= await _context.ingredients.SingleAsync(i=> i.Id ==id);
            if (deleteIngredient != null)
            {
                _context.ingredients.Remove(deleteIngredient);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Ingerdient?> FindIngredientById(string id)
        {
            return await _context.ingredients.SingleOrDefaultAsync(i=> i.Id ==id);
        }

        public async Task<List<Ingerdient>> GetAllIngredient()
        {
            return await _context.ingredients.ToListAsync();
        }


        public async Task<string?> UpdateIngredient(Ingerdient model, string id)
        {
            var _ingredientResult = await _context.ingredients.SingleOrDefaultAsync(i => i.Id == id);
            if (_ingredientResult != null)
            {
                _ingredientResult = model;
                _context.ingredients.Update(_ingredientResult);
                await _context.SaveChangesAsync();
                return null;
            }
            return BusinessMessage.NotFoundIngredient;
            
        }

        public List<Ingerdient> SearchByName(string name)
        {
            var ingredientsResult = _context.ingredients.Where(ingredient
                    => ingredient.Name.Contains(name,StringComparison.OrdinalIgnoreCase)
               );
            return ingredientsResult.ToList();  
        }
    }
}
