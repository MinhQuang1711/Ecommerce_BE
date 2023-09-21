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

    }
}
