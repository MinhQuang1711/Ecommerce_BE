using Ecommerce_BE.Data.DTO.BillOfSales;
using Ecommerce_BE.Services.ManagerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_BE.Controllers
{
    [Route("api/bill-of-sales")]
    [ApiController]
    public class BillOfSales : ControllerBase
    {
        private readonly IManagerService _managerService;

        public BillOfSales(IManagerService managerService) { 
            _managerService=managerService;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var _billOfSaleList= await _managerService.BillOfSaleService.GetAll();
                return Ok(_billOfSaleList);
            }
            catch(Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateBillOfSaleDto model)
        {
            var id = Guid.NewGuid().ToString();
            var _message =await _managerService.BillOfSaleService.Create(model,id);
            if (_message == null)
            {
                foreach (var item in model.DetailBillOfSales)
                {
                    await _managerService.detailBillOfSaleService.Create(item,id);
                }
                return Ok();
            }
            return BadRequest(_message);
        }

        [HttpPost("search-by-date")]
        public async Task<IActionResult> SearchByDate(SearchBillOfSaleByDateDto searchByDateDto)
        {
            var _billOfSales= await _managerService.BillOfSaleService.SearchByDate(searchByDateDto.startTime, searchByDateDto.endTime);  
            return Ok(_billOfSales);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var _message = await _managerService.BillOfSaleService.Delete(id);
            if (_message != null)
            {
                return BadRequest(_message);
            }
            return Ok();
        }

    }
}
