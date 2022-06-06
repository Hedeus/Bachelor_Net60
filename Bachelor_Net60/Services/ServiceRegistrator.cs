using Bachelor_Net60.Services.Interfaces;
using Bachelor_Net60.Services.ProductsCategories;
using Microsoft.Extensions.DependencyInjection;

namespace Bachelor_Net60.Services
{
    static class ServiceRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            //.AddTransient<IDataService, DataService>()
            .AddTransient<IUserDialog, UserDialog>()
            .AddSingleton<ProductsManager>()                    
            ;
    }
}

