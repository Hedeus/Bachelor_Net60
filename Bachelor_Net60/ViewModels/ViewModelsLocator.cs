using Microsoft.Extensions.DependencyInjection;

namespace Bachelor_Net60.ViewModels
{
    internal class ViewModelsLocator
    {       
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
        public ProductsManagementViewModel ProductsManagementModel => App.Services.GetRequiredService<ProductsManagementViewModel>();
        public FullTreeViewModel FullTreeModel => App.Services.GetRequiredService<FullTreeViewModel>();
        //public TreeViewModel TreeModel => App.Services.GetRequiredService<TreeViewModel>();
    }
}
