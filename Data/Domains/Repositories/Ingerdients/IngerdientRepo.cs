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
            _context.ingerdients.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteIngredient(string id)
        {
            var deleteIngredient= await _context.ingerdients.SingleAsync(i=> i.id==id);
            if (deleteIngredient != null)
            {
                _context.ingerdients.Remove(deleteIngredient);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Ingerdient?> FindIngredientById(string id)
        {
            return await _context.ingerdients.SingleOrDefaultAsync(i=> i.id==id);
        }

        public async Task<List<Ingerdient>> GetAllIngredient()
        {
            return await _context.ingerdients.ToListAsync();
        }


        public async Task<string?> UpdateIngredient(Ingerdient model, string id)
        {
            var _ingredientResult = await _context.ingerdients.SingleOrDefaultAsync(i => i.id == id);
            if (_ingredientResult != null)
            {
                _ingredientResult = model;
                _context.ingerdients.Update(_ingredientResult);
                await _context.SaveChangesAsync();
                return null;
            }
            return BusinessMessage.NotFoundIngredient;
            
        }

        public List<Ingerdient> SearchByName(string name)
        {
            var ingredientsResult = _context.ingerdients.Where(ingredient
                    => ingredient.Name.Contains(name,StringComparison.OrdinalIgnoreCase)
               );
            return ingredientsResult.ToList();  
        }
    }
}
