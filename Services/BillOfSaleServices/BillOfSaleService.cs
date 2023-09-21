using Ecommerce_BE.Data.Domains;
using Ecommerce_BE.Data.Domains.Repositories;
using Ecommerce_BE.Services.ManagerServices;

namespace Ecommerce_BE.Services.BillOfSaleServices
{
    public class BillOfSaleService : IBillOfSaleService
    {
     
        private readonly IRepositoryManager _repositoryManager;

        public BillOfSaleService(IRepositoryManager repositoryManager) {

            _repositoryManager = repositoryManager;
        }

        public async Task<List<BillOfSale>> GetAll()
        {
            return await _repositoryManager.billOfSaleRepo.GetAll();
        }
    }
}
