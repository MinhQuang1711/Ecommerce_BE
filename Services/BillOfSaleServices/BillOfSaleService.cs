using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.Domains.Repositories;
using Ecommerce_BE.Data.DTO.BillOfSales;
using Ecommerce_BE.Data.DTO.DetailBillOfSales;
using Ecommerce_BE.Messages;
using Ecommerce_BE.Services.ManagerServices;

namespace Ecommerce_BE.Services.BillOfSaleServices
{
    public class BillOfSaleService : IBillOfSaleService
    {
     
        private readonly IRepositoryManager _repositoryManager;

        public BillOfSaleService(IRepositoryManager repositoryManager) {

            _repositoryManager = repositoryManager;
        }

        public async Task<string?> Create(CreateBillOfSaleDto model, string id)
        {
            var _total =await GetTotal(model.DetailBillOfSales);
            if (_total != null)
            {
                var _billOfSale = new BillOfSale()
                {
                    Id = id,
                    Discount = model.Discount ?? 0,
                    TotalPrice = _total??0, 
                    FinalPrice= _total??0 -model.Discount ?? 0, 
                    SaleDate =DateTime.Now.ToString(),
                    PaymentType = model.PaymentType,    
                    
                };

                await _repositoryManager.billOfSaleRepo.CreateBillOfSale(_billOfSale);


                return null;
            }
            return BusinessMessage.ProductNotExist;

          
        }

        public async Task<List<BillOfSale>> GetAll()
        {
            return await _repositoryManager.billOfSaleRepo.GetAll();
        }

        public async Task<double?> GetTotal(List<CreateDetailBillOfSaleDto> detailBillOfSale)
        {
           
            double total = 0;    
            foreach (var item in detailBillOfSale)
            {
                var _productResult= await _repositoryManager.productRepo.SearchById(item.ProductId);
                if (_productResult != null)
                {
                    total = total+ item.Quantity * _productResult.Price;
                }
                else
                {
                    return null;
                }
            }

            return total;
        }

    }
}
