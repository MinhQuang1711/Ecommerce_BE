using Ecommerce_BE.Data.Domains;

namespace Ecommerce_BE.Repositories.ImportBills
{
    public interface IImportBillRepo
    {
       
        public Task CreateImportBill(ImportBill importBill);
        public Task UpdateImportBill(ImportBill importBill);
        public Task<List<ImportBill>> GetAllImportBill();
        public Task DeleteImportBill(string id);
    }
}
