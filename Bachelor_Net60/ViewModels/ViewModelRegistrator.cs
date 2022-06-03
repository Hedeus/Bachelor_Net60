using Microsoft.Extensions.DependencyInjection;

namespace Bachelor_Net60.ViewModels
{
    internal static class ViewModelRegistrator
    {
        public static IServiceCollection AddViews(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            .AddSingleton<ProductsManagementViewModel>()
            //.AddTransient<TreeViewModel>()
            .AddSingleton<FullTreeViewModel>()
        ;
    }
}