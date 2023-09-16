using Ecommerce_BE.Data.Domains;
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
            var deleteIngredient= await _context.ingerdients.SingleOrDefaultAsync(i=> i.id==id);
            if (deleteIngredient != null)
            {
                _context.ingerdients.Remove(deleteIngredient);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Ingerdient>> GetAllIngredient()
        {
            return await _context.ingerdients.ToListAsync();
        }

        public async Task<bool> UpdateIngredient(Ingerdient model)
        {
            var updateIngredient = await _context.ingerdients.SingleOrDefaultAsync(i => i.id == model.id);
            if (updateIngredient != null)
            {
              
                updateIngredient.Name = model.Name;
                updateIngredient.Loss = model.Loss;
                updateIngredient.NetWeight = model.NetWeight;
                updateIngredient.NetWeight= model.NetWeight;
                updateIngredient.ImportPrice = model.ImportPrice;

                _context.ingerdients.Update(updateIngredient);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
            
        }
    }
}
