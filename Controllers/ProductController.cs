using Ecommerce_BE.Data.DTO.Products;
using Ecommerce_BE.Services.ManagerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_BE.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IManagerService _managerService;
        public ProductController(IManagerService managerService)
        {
            _managerService=managerService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> Get()
        {
            var _productDtoList= await _managerService.productService.GetAll();
            for (int i=0;i< _productDtoList.Count; i++)
            {
                var _listDetailDto = await _managerService.detailProductService.GetByProductId(_productDtoList[i].Id);
                _productDtoList[i].DetailProducts = _listDetailDto;
            }

            return Ok(_productDtoList);
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
                    await _managerService.detailProductService.Create(item, id,model.Name);
                }
                return Ok();
            }
            catch (Exception ex) { 
                return StatusCode(500, ex.Message); 
            }
            
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                
                var _message = await _managerService.productService.Delete(id);
                if (_message != null)
                {
                    return BadRequest(_message);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }






    }
}
