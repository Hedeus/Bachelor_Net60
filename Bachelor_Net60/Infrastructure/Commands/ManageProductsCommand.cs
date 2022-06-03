using Bachelor_Net60.Infrastructure.Commands.Base;
using Bachelor_Net60.Views.Windows;
using System;
using System.Windows;

namespace Bachelor_Net60.Infrastructure.Commands
{
    internal class ManageProductsCommand : Command
    {
        private ProductsManagementWindow _Window;
        protected override bool CanExecute(object p) => _Window == null;

        protected override void Execute(object p)
        {
            var window = new ProductsManagementWindow
            {
                Owner = App.Current.MainWindow
            };
            _Window = window;
            window.Closed += OnWindowClosed;
            window.Show();
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            ((Window)sender).Closed -= OnWindowClosed;
            _Window = null;
        }
    }
}
