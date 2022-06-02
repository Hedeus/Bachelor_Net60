using Cifrovik.Interfaces;
using CifrovikDEL.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifrovikDEL
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDB(this IServiceCollection services) => services
            .AddTransient<IRepository<Categories>, DBRepository<Categories>>()
            .AddTransient<IRepository<CategoryTree>, DBRepository<CategoryTree>>()
            .AddTransient<IRepository<OrderDetails>, DBRepository<OrderDetails>>()
            .AddTransient<IRepository<Orders>, DBRepository<Orders>>()
            .AddTransient<IRepository<ProductPrice>, DBRepository<ProductPrice>>()
            .AddTransient<IRepository<Products>, ProductRepository>()
            ;        
    }
}
