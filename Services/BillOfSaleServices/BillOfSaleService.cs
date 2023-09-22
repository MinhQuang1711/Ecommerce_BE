using AutoMapper;
using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.Domains.Repositories;
using Ecommerce_BE.Data.DTO.BillOfSales;
using Ecommerce_BE.Data.DTO.DetailBillOfSales;
using Ecommerce_BE.Messages;
using Ecommerce_BE.Services.ManagerServices;
using MySql.Data.MySqlClient;

namespace Ecommerce_BE.Services.BillOfSaleServices
{
    public class BillOfSaleService : IBillOfSaleService
    {
     
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public BillOfSaleService(IRepositoryManager repositoryManager,IMapper mapper) {

            _repositoryManager = repositoryManager;
            _mapper=mapper;
        }

        public async Task<string?> Create(CreateBillOfSaleDto model, string id)
        {
            var _total =await GetTotal(model.DetailBillOfSales);
            if (_total != null)
            {
                var _discount = model.Discount ?? 0;
                var total = _total ?? 0;
                var _finalPrice = total- _discount;
                var _billOfSale = new BillOfSale()
                {
                    Id = id,
                    Discount = _discount,
                    TotalPrice = _total??0, 
                    FinalPrice= _finalPrice,
                    SaleDate =DateTime.Now,
                    PaymentType = model.PaymentType,    
                    
                };

               await _repositoryManager.billOfSaleRepo.CreateBillOfSale(_billOfSale);


                return null;
            }
            return BusinessMessage.ProductNotExist;

          
        }

        public async Task<string?> Delete(string id)
        {
            return await _repositoryManager.billOfSaleRepo.Delete(id);
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

        public async Task<List<BillOfSale>> SearchByDate(DateTime startTime, DateTime endTime)
        {
            return await _repositoryManager.billOfSaleRepo.SearchByDate(startTime, endTime);    
        }

        public async Task<GetBillOfSaleDto?> SearchById(string id)
        {
            var _billOfSaleResult = await _repositoryManager.billOfSaleRepo.SearchById(id);
            if (_billOfSaleResult != null) 
            {
                var dtos = _mapper.Map<GetBillOfSaleDto>(_billOfSaleResult);
                return dtos;
            }
            return null;
        }
    }
}
