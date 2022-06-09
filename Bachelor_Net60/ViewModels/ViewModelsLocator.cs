using Microsoft.Extensions.DependencyInjection;

namespace Bachelor_Net60.ViewModels
{
    internal class ViewModelsLocator
    {       
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
        public ProductsManagementViewModel ProductsManagementModel => App.Services.GetRequiredService<ProductsManagementViewModel>();
        //public ProductEditViewModel ProductsEditModel => App.Services.GetRequiredService<ProductEditViewModel>();
        //public CategoryEditViewModel CategoryEditModel => App.Services.GetRequiredService<CategoryEditViewModel>();
        //public ProductDetailsViewModel ProductDetailsModel => App.Services.GetRequiredService<ProductDetailsViewModel>();   
    }
}
