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
    }
}
