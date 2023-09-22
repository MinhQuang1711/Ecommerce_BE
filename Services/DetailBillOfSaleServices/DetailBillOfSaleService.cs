using AutoMapper;
using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.Domains.Repositories;
using Ecommerce_BE.Data.DTO.DetailBillOfSales;
using Ecommerce_BE.Messages;

namespace Ecommerce_BE.Services.DetailBillOfSaleServices
{
    public class DetailBillOfSaleService : IDetailBillOfSaleService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;

        public DetailBillOfSaleService(IRepositoryManager repositoryManager,IMapper mapper) 
        {
            _repoManager= repositoryManager;
            _mapper= mapper;
        }

        public async Task<string?> Create(CreateDetailBillOfSaleDto model,string billId)
        {
            var _productResult = await _repoManager.productRepo.SearchById(model.ProductId);
            if (_productResult != null)
            {
                var _totalPrice = GetTotal(model.Quantity,_productResult.Price);
                var _detailBill = new DetailBillOfSale()
                {
                    BillId= billId,
                    TotalPrice= _totalPrice,
                    Quantity= model.Quantity,
                    ProductId = model.ProductId,
                    Id = Guid.NewGuid().ToString(),
                };
                await _repoManager.detailBillOfSaleRepo.Create(_detailBill);
            }
            return BusinessMessage.NotFoundProduct; 
        }

        public  double GetTotal(double quantity, double price)
        {
          return quantity * price;  
        }

        public async Task<List<GetDetailBillOfSaleDto>> SearchByBillId(string billId)
        {
            var _detailBillOfSaleList= await _repoManager.detailBillOfSaleRepo.SearchByBillId(billId);
            var _getDetailDto = _mapper.Map<List<GetDetailBillOfSaleDto>>(_detailBillOfSaleList);
            for (int i=0; i< _getDetailDto.Count; i++)
            {
                var _productResult = await _repoManager.productRepo.SearchById(_getDetailDto[i].ProductId);
                _getDetailDto[i].ProductName = _productResult.Name; 
            }
            return _getDetailDto; 
        }
    }
}
