using CifrovikDEL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CifrovikDEL.Context
{
    public class CifrovikDB : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductPrice> Prices { get; set; }
        public DbSet<OrderDetails> Details { get; set; }
        public DbSet<CategoryTree> Tree { get; set; }
        public CifrovikDB(DbContextOptions<CifrovikDB> options) : base(options) { }
    }
}
