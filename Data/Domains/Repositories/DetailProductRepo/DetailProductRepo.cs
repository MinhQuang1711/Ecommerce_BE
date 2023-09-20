using Microsoft.EntityFrameworkCore;

namespace Ecommerce_BE.Data.Domains.Repositories.DetailProductRepo
{
    public class DetailProductRepo : IDetailProductRepo
    {
        private readonly EcommerceContext _context;


        public DetailProductRepo(EcommerceContext context)
        {
            _context = context;
        }

        public async Task Create(DetailProduct model)
        {
            await _context.detailProducts.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DetailProduct>> GetByProductId(string productId)
        {
            return await _context.detailProducts.Where(d=> d.ProductID==productId).ToListAsync();
        }
    }
}
