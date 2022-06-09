using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CifrovikDEL.Context
{
    public class YourDbContextFactory : IDesignTimeDbContextFactory<CifrovikDB>
    {
        public CifrovikDB CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CifrovikDB>();
            optionsBuilder.UseMySql("server=localhost;uid=root;pwd=1h9e8d7;database=cifrovictest;", new MySqlServerVersion(new Version(8, 0, 27)));

            return new CifrovikDB(optionsBuilder.Options);
        }
    }
}
