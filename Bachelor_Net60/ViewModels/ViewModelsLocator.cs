using Microsoft.Extensions.DependencyInjection;

namespace Bachelor_Net60.ViewModels
{
    internal class ViewModelsLocator
    {       
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
