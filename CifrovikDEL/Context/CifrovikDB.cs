using CifrovikDEL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CifrovikDEL.Context
{
    public class CifrovikDB : DbContext
    {
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<ProductPrice> Prices { get; set; }
        public DbSet<OrderDetails> Details { get; set; }
        public DbSet<CategoryTree> Tree { get; set; }
        public CifrovikDB(DbContextOptions<CifrovikDB> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryTree>().HasIndex(i => i.DescendantId).IsUnique();
            modelBuilder.Entity<ProductPrice>().HasIndex(i => new { i.ProductId, i.Amount, i.Price }).IsUnique()
                                               .HasName("IX_UnProdAmoPrice");
        }
    }
}
