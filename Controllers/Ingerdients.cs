using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.Domains.Repositories;
using Ecommerce_BE.Data.DTO.Ingredients;
using Ecommerce_BE.Messages;
using Ecommerce_BE.Repositories.Ingerdients;
using Ecommerce_BE.Services.ManagerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZstdSharp.Unsafe;

namespace Ecommerce_BE.Controllers
{
    [Route("api/ingredient")]
    [ApiController]
    public class Ingredients : ControllerBase
    {
        private readonly IManagerService _managerService;
       

        public Ingredients(EcommerceContext context,IRepositoryManager repo,IManagerService managerService) {
            _managerService= managerService;

        }

        [HttpGet("get-all")]
        public async Task<IActionResult>GetAll() {
            try
            {
                return Ok(await _managerService.ingredientService.GetAll());
            } 
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
            
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateIngredient(CreateIngredient ingredientDto)
        {
            try 
            {
                var message = await _managerService.ingredientService.Create(ingredientDto);

                if (message == null)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(message);
                }
            } catch (Exception ex) {
                return StatusCode(500,ex.Message);  
            
            }
           
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteIngredient(string id)
        {
            if (await _managerService.ingredientService.SearchById(id) == null)
            {
                return NotFound(BusinessMessage.NotFoundIngredient);
            }

            else if(await _managerService.ingredientService.Delete(id)) 
            {
                return Ok();
            }
            return BadRequest();
           
        }

        [HttpPut ("update")]
        public async Task<IActionResult> UpdateIngredient(UpdateIngredient ingredient,string id)
        {
            if (await _managerService.ingredientService.SearchById(id) == null)
            {
                return NotFound(BusinessMessage.NotFoundIngredient);
            }

            else if (await _managerService.ingredientService.Update(ingredient,id)==null)
            {
                return Ok();
            }
            return BadRequest(await _managerService.ingredientService.Update(ingredient, id));

        }

        [HttpGet ("searchById")]
        public async Task<IActionResult> SearchById(string id)
        {
            return Ok(await _managerService.ingredientService.SearchById(id));
        }

    }
}
