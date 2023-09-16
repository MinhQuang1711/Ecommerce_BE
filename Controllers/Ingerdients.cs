using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Repositories.Ingerdients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZstdSharp.Unsafe;

namespace Ecommerce_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Ingredients : ControllerBase
    {
        private readonly EcommerceContext _context;
        private readonly IIngredientRepo _repo;

        public Ingredients(EcommerceContext context,IIngredientRepo repo) {
            _context = context;
            _repo = repo;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult>GetAll() {
            try
            {
                return Ok(await _repo.GetAllIngredient());
            } 
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateIngredient(Ingerdient ingredient)
        {
            try
            {
                await _repo.CreateIngredient(ingredient);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteIngredient(string id)
        {
            try
            {
                await _repo.DeleteIngredient(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut ("update")]
        public async Task<IActionResult> UpdateIngreient(Ingerdient ingerdient)
        {
            try
            {
                await _repo.UpdateIngredient(ingerdient); 
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
