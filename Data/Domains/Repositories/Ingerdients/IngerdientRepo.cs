using Ecommerce_BE.Data.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ecommerce_BE.Repositories.Ingerdients
{
    public class IngredientRepo : IIngredientRepo
    {
        private readonly EcommerceContext _context;
        private readonly ILogger<IngredientRepo> _logger;

        public IngredientRepo(EcommerceContext context,ILogger<IngredientRepo> logger) {
            _context = context;
            _logger= logger;
        }

        public async Task CreateIngredient(Ingerdient model)
        {
            _context.ingerdients.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteIngredient(string id)
        {
            var deleteIngredient= await _context.ingerdients.SingleOrDefaultAsync(i=> i.id==id);
            if (deleteIngredient != null)
            {
                _context.ingerdients.Remove(deleteIngredient);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task<List<Ingerdient>> GetAllIngredient()
        {
            return await _context.ingerdients.ToListAsync();
        }

        public async Task UpdateIngredient(Ingerdient model)
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
            }else 
            { 
                throw new NotImplementedException(); 
            }
            
        }
    }
}
