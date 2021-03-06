using Bachelor_Net60.Services.Interfaces;
using Bachelor_Net60.Services.Management;
using Microsoft.Extensions.DependencyInjection;

namespace Bachelor_Net60.Services
{
    static class ServiceRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services            
            .AddTransient<IUserDialog, UserDialog>()
            .AddSingleton<ProductsManager>()
            .AddSingleton<OrderManager>()
            ;
    }
}

