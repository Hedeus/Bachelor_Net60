using Bachelor_Net60.Infrastructure.Commands;
using Bachelor_Net60.Infrastructure.Commands.Base;
using Bachelor_Net60.Services.ProductsCategories;
using Bachelor_Net60.ViewModels.Base;
using Cifrovik.Interfaces;
using CifrovikDEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bachelor_Net60.ViewModels
{
    internal class ProductEditViewModel : ViewModel
    {
        /*---------------------------------------Свойства---------------------------------------------*/
        private readonly ProductsManager _ProductsManager;

        private string _Category;
        public string Category
        {
            get => _Category;
            set => Set(ref _Category, value);
        }

        private string _Product;
        public string Product
        {
            get => _Product;
            set => Set(ref _Product, value);
        }

        /*-----------------------------------------Методы---------------------------------------------*/


        /*----------------------------------------Команды----------------------------------------------*/

        #region CancelEditCommand
        private Command _CancelEditCommand;
        public Command CancelEditCommand => _CancelEditCommand
            ??= new LambdaCommand(OnCancelEditCommandExecuted, CanCancelEditCommandExecute);
        private bool CanCancelEditCommandExecute(object p) => _ProductsManager.SelectedCategory != null;
        private void OnCancelEditCommandExecuted(object p)
        {
            _ProductsManager.CurrentModel = new ProductDetailsViewModel(_ProductsManager);
        }
        #endregion

        /*--------------------------------------Конструктор---------------------------------------------*/
        public ProductEditViewModel(ProductsManager productsManager, bool IsAdd = false)        
        {
            _ProductsManager = productsManager;

           _Category = _ProductsManager.SelectedCategory.Name;   

            _Product = "Продукт не выбрана";
            if (_ProductsManager.SelectedProduct != null)
                _Product = _ProductsManager.SelectedProduct.Name;
            
        }
    }
}
