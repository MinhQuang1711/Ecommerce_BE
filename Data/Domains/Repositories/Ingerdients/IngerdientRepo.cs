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

        public double? GetCostOfIngredient(double importPrice, double realWeight)
        {
            if(realWeight >= 0)
            {
                return importPrice / realWeight;
            }
            return null;
        }

        public double GetRealWeight(double netWeight, double? loss)
        {   
            var _realWeight = netWeight - netWeight * (loss??0 / 100);
            return _realWeight;
        }


        public async Task<string?> UpdateIngredient(UpdateIngredient model, string id)
        {
            var updateIngredient = await _context.ingerdients.SingleOrDefaultAsync(i => i.id == id);
            if (updateIngredient != null)
            {
                var _loss= model.Loss??updateIngredient.Loss;
                var _netWeight = model.NetWeight ?? updateIngredient.NetWeight;
                var _importPrice= model.ImportPrice??updateIngredient.ImportPrice;
                
                updateIngredient.Name= model.Name ?? updateIngredient.Name;
                updateIngredient.Loss = _loss; 

                if (_importPrice > 0)
                    updateIngredient.ImportPrice = _importPrice; 
                else
                    return BusinessMessage.IngredientPriceRequied; 
              
                if (model.NetWeight > 0)
                    updateIngredient.NetWeight=_netWeight;
                else
                    return BusinessMessage.IngredientWeightRequied;

                var _realWight = GetRealWeight(_netWeight,_loss);
                var _pricePerGram = GetCostOfIngredient(_importPrice,_realWight);

                updateIngredient.RealWeight = _realWight;
                updateIngredient.PricePerGram = _pricePerGram??updateIngredient.PricePerGram;

                _context.ingerdients.Update(updateIngredient);
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
