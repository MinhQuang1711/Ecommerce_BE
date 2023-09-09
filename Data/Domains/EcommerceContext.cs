using Microsoft.EntityFrameworkCore;

namespace Ecommerce_BE.Data.Domains
{
    public class EcommerceContext: DbContext
    {
        public EcommerceContext(DbContextOptions options) : base(options) {  }

        public DbSet<Product> products { get; set; }
        public DbSet<Ingerdient> ingerdients { get; set; }
        public DbSet<IngerProduct> detailProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            const string connectionString = "Server=localhost;User ID=root;Password=Tlua35016;Database=ecommerce";
            optionsBuilder.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));  

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasMany(e => e.Ingerdients)
                .WithMany(e => e.Products)
                .UsingEntity<IngerProduct>(
                    l=> l.HasOne<Ingerdient>().WithMany().HasForeignKey(e=> e.IngerdientID), 
                    r=> r.HasOne<Product>().WithMany().HasForeignKey(e=>e.ProductID)
                 );
                entity.Property(e => e.Cost).IsRequired();
                entity.Property(e=>e.Price).IsRequired();
                entity.HasKey(e => e.id);
                
            });

            modelBuilder.Entity<Ingerdient>(entity => 
            {
                entity.Property(e=> e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e=> e.PricePerGram).IsRequired(); 
                entity.Property(e => e.ImportPrice).IsRequired();
                entity.HasKey(e => e.id);
            });

            modelBuilder.Entity <IngerProduct>( entity=>
            {
                entity.Property(e => e.ProductID).IsRequired(); 
                entity.Property(e=> e.IngerdientID).IsRequired();
                entity.Property(e=> e.SumCost).IsRequired();
                entity.Property(e=> e.Weight).IsRequired();
            });
        }
    }
}
