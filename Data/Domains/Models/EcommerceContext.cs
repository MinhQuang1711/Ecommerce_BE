using Microsoft.EntityFrameworkCore;

namespace Ecommerce_BE.Data.Domains
{
    public class EcommerceContext: DbContext
    {
        public EcommerceContext(DbContextOptions options) : base(options) {  }

        public DbSet<Product> products { get; set; }
        public DbSet<Ingerdient> ingredients { get; set; }
        public DbSet<DetailProduct> detailProducts { get; set; }

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
               
                entity.Property(e => e.Cost).IsRequired();
                entity.Property(e => e.Price).IsRequired();
                entity.HasKey(e => e.id);

            });

            modelBuilder.Entity<DetailProduct>(entity => {
                entity.HasOne<Ingerdient>().WithMany().HasForeignKey(e => e.IngredientID);
                entity.HasOne<Product>().WithMany().HasForeignKey(e => e.ProductID);
            });
            modelBuilder.Entity<Ingerdient>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PricePerGram).IsRequired();
                entity.Property(e => e.ImportPrice).IsRequired();
                entity.HasKey(e => e.id);
            });

            modelBuilder.Entity<DetailProduct>(entity =>
            {
                entity.Property(e => e.ProductID).IsRequired();
                entity.Property(e => e.IngredientID).IsRequired();
                entity.Property(e => e.SumCost).IsRequired();
                entity.Property(e => e.Weight).IsRequired();
            });

            modelBuilder.Entity<BillOfSale>(entity =>
            {
               
                entity.HasKey(e => e.id);
                
            });

            modelBuilder.Entity<DetailBillOfSale>(entity =>
            {
                entity.HasOne<Product>().WithMany().HasForeignKey(e => e.ProductId);
                entity.HasOne<BillOfSale>().WithMany().HasForeignKey(e => e.BillId);
            });

            modelBuilder.Entity<ImportBill>(entity =>
            {
                entity.HasKey(e => e.id);
                

               
            });
            modelBuilder.Entity<DetailImportBill>(entity => {
                entity.HasOne<Ingerdient>().WithMany().HasForeignKey(e => e.IngerdientId);
                entity.HasOne<ImportBill>().WithMany().HasForeignKey(e => e.ImportBillId);
            });
        }
    }
}
