using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Messages;
using Ecommerce_BE.Repositories.Ingerdients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZstdSharp.Unsafe;

namespace Ecommerce_BE.Controllers
{
    [Route("api/ingredient")]
    [ApiController]
    public class Ingredients : ControllerBase
    {
     
        private readonly EcommerceContext _context;
        private readonly IIngredientRepo _repo;

        public Ingredients(EcommerceContext context,IIngredientRepo repo) {
            _context = context;
            _repo = repo;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult>GetAll() {
            try
            {
                return Ok(await _repo.GetAllIngredient());
            } 
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
            
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateIngredient(Ingerdient ingredient)
        {
            try
            {
                await _repo.CreateIngredient(ingredient);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteIngredient(string id)
        {
            if(await _repo.DeleteIngredient(id) == false) 
            {
                return NotFound(BusinessMessage.NotFoundIngredient);
            }
            return Ok();
           
        }

        [HttpPut ("update")]
        public async Task<IActionResult> UpdateIngredient(Ingerdient ingerdient)
        {
            if (await _repo.UpdateIngredient(ingerdient) == false)
            {
                return NotFound(BusinessMessage.NotFoundIngredient);
            }
            return Ok();

        }
    }
}
