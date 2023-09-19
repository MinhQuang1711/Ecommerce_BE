using Ecommerce_BE.Data.DTO.Products;
using Ecommerce_BE.Services.ManagerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IManagerService _managerService;
        public ProductController(IManagerService managerService)
        {
            _managerService=managerService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await _managerService.productService.GetAll());
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateProductDto model)
        {
            try
            {
                var _message= await _managerService.productService.CreateProduct(model);
                if (_message != null)
                {
                    return BadRequest(_message);
                }
                return Ok();
            }
            catch (Exception ex) { 
                return StatusCode(500, ex.Message); 
            }
            
        }




    }
}
