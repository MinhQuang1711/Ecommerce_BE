using Microsoft.EntityFrameworkCore;

namespace Ecommerce_BE.Data.Domains
{
    public class EcommerceContext: DbContext
    {
        public EcommerceContext(DbContextOptions options) : base(options) {  }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            const string connectionString = "Server=localhost;User ID=root;Password=Tlua35016;Database=ecommerce";
            optionsBuilder.UseMySQL(connectionString);  

        }
    }
}
