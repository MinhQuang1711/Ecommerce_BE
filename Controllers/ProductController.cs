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

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateProductDto model)
        {
            try
            {
                var id= Guid.NewGuid().ToString(); 
                var _message= await _managerService.productService.CreateProduct(model,id);
                if (_message != null)
                {
                    return BadRequest(_message);
                }
                foreach (var item in model.DetailProductsList)
                {
                    await _managerService.detailProductService.Create(item, id);
                }
                return Ok();
            }
            catch (Exception ex) { 
                return StatusCode(500, ex.Message); 
            }
            
        }




    }
}
